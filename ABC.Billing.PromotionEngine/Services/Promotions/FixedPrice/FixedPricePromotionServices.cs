using ABC.Billing.PromotionEngine.Services.Cart;
using ABC.Billing.PromotionEngine.Services.Pricing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ABC.Billing.PromotionEngine.Services.Promotions.FixedPrice
{/// <summary>
/// Calculate price with Fixed promotions
/// </summary>
    public class FixedPricePromotionServices : IPromotionServices
    {
        private ICartService _cartService;
        private IPriceListService _priceListService;

        private List<string> _skuIds;
        private decimal _price;

        public FixedPricePromotionServices(List<string> skuIds, decimal price)
        {
            _skuIds = skuIds;
            _price = price;
        }
        /// <summary>
        /// Calculate the price for the cart - with promotion code.
        /// </summary>
        /// <returns></returns>
        public decimal Price()
        {
            if (_cartService != null && _priceListService != null)
            {
                var cartItems = _cartService.GetCartItems();
                int minQty = Int32.MaxValue;
                foreach (var _skuId in _skuIds)
                {
                    int qty = cartItems.Where(x => x.SkuId == _skuId).Select(r => r.Quantity).FirstOrDefault();
                    if ( qty < minQty)
                    {
                        minQty = qty;
                    }
                }
                if (minQty == 0)
                {
                    return _cartService.Price();
                }

                decimal fixed_price = minQty * _price;


                decimal price = cartItems.Where(x => !_skuIds.Contains(x.SkuId)).Select(r => r.Quantity * _priceListService.GetPriceBySkuID(r.SkuId)).Sum()
                                          + cartItems.Where(x => _skuIds.Contains(x.SkuId)).Select(r => (r.Quantity - minQty) * _priceListService.GetPriceBySkuID(r.SkuId)).Sum()
                                          + fixed_price;


                return price;
            }
            return 0;
        }
        /// <summary>
        /// Set cart for discount.
        /// </summary>
        /// <param name="cartService"></param>
        public void SetCart(ICartService cartService)
        {
            _cartService = cartService;
        }
        /// <summary>
        /// Price list service.
        /// </summary>
        /// <param name="priceListService"></param>
        public void SetPriceList(IPriceListService priceListService)
        {
            _priceListService = priceListService;
        }
    }
}
