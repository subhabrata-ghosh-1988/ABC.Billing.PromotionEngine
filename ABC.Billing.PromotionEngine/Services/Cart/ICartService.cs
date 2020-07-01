using ABC.Billing.PromotionEngine.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ABC.Billing.PromotionEngine.Services.Cart
{
    public interface ICartService
    {
        public void AddItem(string skuId, int quantity);
        public int RemoveItem(string skuId);

        public CartItem EditItem(string skuId, int quantity);
        public decimal Price();

        public List<CartItem> GetCartItems();

    }
}
