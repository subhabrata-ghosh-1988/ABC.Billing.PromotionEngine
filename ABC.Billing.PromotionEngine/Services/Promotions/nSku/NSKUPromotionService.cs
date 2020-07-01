using ABC.Billing.PromotionEngine.Services.Cart;
using ABC.Billing.PromotionEngine.Services.Pricing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ABC.Billing.PromotionEngine.Services.Promotions.nSku
{
    /// <summary>
    /// Calculate price based on N-Sku promotions.
    /// </summary>
    public class NSKUPromotionService : IPromotionServices
    {
        private ICartService _cartService;
        private IPriceListService _priceListService;

        private string _SkuId;
        private int _count;
        private decimal _price;

        public NSKUPromotionService(string SkuId, int count, decimal price)
        {
            _SkuId = SkuId;
            _count = count;
            _price = price;
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
        /// Calculate the price based on the promotion criteria
        /// </summary>
        /// <returns></returns>
        public decimal Price()
        {
            if (_cartService != null && _priceListService != null)
            {
                var cartItems = _cartService.GetCartItems();
                var item = cartItems.Find(x => x.SkuId == _SkuId.ToUpper());
                if (item == null)
                {
                    return _cartService.Price();
                }

                int n = item.Quantity / _count;
                int remainingItems = item.Quantity - n * _count;

                decimal price = cartItems.Where(x => x.SkuId != _SkuId).Select(r => r.Quantity * _priceListService.GetPriceBySkuID(r.SkuId)).Sum()
                                       + (n * _price) + (remainingItems * _priceListService.GetPriceBySkuID(_SkuId));
                return price;
            }
            return 0;
        }

    }
}
