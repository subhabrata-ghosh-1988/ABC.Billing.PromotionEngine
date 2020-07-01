using ABC.Billing.PromotionEngine.Models;
using ABC.Billing.PromotionEngine.Services.Pricing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ABC.Billing.PromotionEngine.Services.Cart
{
    /// <summary>
    /// This class is for the basic cart operations  - Add item , Remove items, Calculate Price
    /// </summary>
    public class CartService : ICartService
    {
        private IPriceListService _priceListService;
        private List<CartItem> _cartItems;

        /// <summary>
        /// The constructor takes the price list as dependency to calculate the price.
        /// It initializes an empty cart.
        /// </summary>
        /// <param name="priceListService"></param>
        public CartService(IPriceListService priceListService)
        {
            _priceListService = priceListService;
            _cartItems = new List<CartItem>();
        }
        /// <summary>
        /// Add items to the cart.
        /// </summary>
        /// <param name="skuId"></param>
        /// <param name="quantity"></param>
        public void AddItem(string skuId, int quantity)
        {
            var cartitem = _cartItems.Find(x => x.SkuId == skuId.ToUpper());
            if (cartitem == null)
            {
                // Add item to the list
                _cartItems.Add(new CartItem() { SkuId = skuId, Quantity = quantity });
            }
            else
            {
                // Add to the quantity if an item exists.
                cartitem.Quantity += quantity;
            }
        }

        /// <summary>
        /// Get all the cart items.
        /// </summary>
        /// <returns></returns>
        public List<CartItem> GetCartItems()
        {
            return _cartItems;
        }
        /// <summary>
        /// Calculate the total price from the cart.
        /// </summary>
        /// <returns></returns>
        public decimal Price()
        {
            var price = (from item in _cartItems
                         select item.Quantity * _priceListService.GetPriceBySkuID(item.SkuId)).Sum();
            return price;
        }
        /// <summary>
        /// Removes items based on SKU ID.
        /// </summary>
        /// <param name="skuId"></param>
        /// <returns></returns>
        public int RemoveItem(string skuId)
        {
            return _cartItems.RemoveAll(x => x.SkuId == skuId.ToUpper());
        }
        /// <summary>
        /// Edit a particular item in the cart. 
        /// Throws exception in case the item does not exists.
        /// </summary>
        /// <param name="skuId"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public CartItem EditItem(string skuId, int quantity)
        {
            var cartitem = _cartItems.Find(x => x.SkuId == skuId.ToUpper());
            if (cartitem == null)
            {
                throw new ArgumentException("The Sku Id is not valid.");
            }
            cartitem.Quantity = quantity;
            return cartitem;
        }
    }
}
