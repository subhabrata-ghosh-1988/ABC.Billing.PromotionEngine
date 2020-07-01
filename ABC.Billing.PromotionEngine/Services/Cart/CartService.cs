using ABC.Billing.PromotionEngine.Models;
using ABC.Billing.PromotionEngine.Services.Pricing;
using System;
using System.Collections.Generic;
using System.Text;

namespace ABC.Billing.PromotionEngine.Services.Cart
{
    public class CartService : ICartService
    {
        private IPriceListService _priceListService;

        public CartService(IPriceListService priceListService)
        {
            throw new NotImplementedException();
        }


        public void AddItem(string skuId, int quantity)
        {
            throw new NotImplementedException();
        }

        public CartItem EditItem(string skuId, int quantity)
        {
            throw new NotImplementedException();
        }

        public List<CartItem> GetCartItems()
        {
            throw new NotImplementedException();
        }

        public decimal Price()
        {
            throw new NotImplementedException();
        }

        public int RemoveItem(string skuId)
        {
            throw new NotImplementedException();
        }
    }
}
