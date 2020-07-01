using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace ABC.Billing.PromotionEngine.Services.Pricing
{
    /// <summary>
    /// This class reads the prices by SKU Ids from the configuration. 
    /// </summary>
    public class PriceListService : IPriceListService
    {
        private const string _filename = @"Data\PriceList.xml";
        private Dictionary<string, decimal> _priceListings;
        /// <summary>
        /// Make a dictionary based on the configuration xml.
        /// </summary>
        public PriceListService()
        {
            LoadPriceList();
        }

        /// <summary>
        /// This method Loads all the price list to the dictionary
        /// </summary>
        private void LoadPriceList()
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var priceFilepath = Path.Combine(currentDirectory, _filename);
            _priceListings = new Dictionary<string, decimal>();

            XElement priceList = XElement.Load(priceFilepath);

            _priceListings = (from item in priceList.Descendants("item")
                              select new
                              {
                                  Name = Convert.ToString(item.Attribute("skuid").Value),
                                  Value = Convert.ToDecimal(item.Attribute("price").Value)
                              }).ToDictionary(x => x.Name, x => x.Value);
        }

        /// <summary>
        /// Get price for a specific SKU ID. - Returns 0 for an invalid SKU ID.
        /// </summary>
        /// <param name="skuId">Provide a sku id</param>
        /// <returns>Price</returns>
        public decimal GetPriceBySkuID(string skuId)
        {
            if (!_priceListings.ContainsKey(skuId))
            {
                return 0;
            }
            return _priceListings[skuId];
        }
        /// <summary>
        /// Get all price listing in the form of a dictionary
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, decimal> GetAllPrices()
        {
            return _priceListings;
        }
    }
}
