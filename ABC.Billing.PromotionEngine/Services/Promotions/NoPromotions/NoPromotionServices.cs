using ABC.Billing.PromotionEngine.Services.Cart;
using ABC.Billing.PromotionEngine.Services.Pricing;
using System;
using System.Collections.Generic;
using System.Text;

namespace ABC.Billing.PromotionEngine.Services.Promotions.NoPromotions
{
    /// <summary>
    /// This service calculates no promotions.
    /// </summary>
    public class NoPromotionServices : IPromotionServices
    {
        private ICartService _cartService;
        private IPriceListService _priceListService;


        public NoPromotionServices()
        {

        }
        /// <summary>
        /// Set cart for discount
        /// </summary>
        /// <param name="cartService"></param>
        public void SetCart(ICartService cartService)
        {
            _cartService = cartService;
        }
        /// <summary>
        /// Price List service
        /// </summary>
        /// <param name="priceListService"></param>
        public void SetPriceList(IPriceListService priceListService)
        {
            _priceListService = priceListService;
        }


        /// <summary>
        /// Calculate the original cart price
        /// </summary>
        /// <returns></returns>
        public decimal Price()
        {
            if (_cartService != null)
            {
                return _cartService.Price();
            }
            return 0;
        }
    }
}
