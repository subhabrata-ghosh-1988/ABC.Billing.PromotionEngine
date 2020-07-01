using System;
using System.Collections.Generic;
using System.Text;

namespace ABC.Billing.PromotionEngine.Models
{
    public class CartItem
    {
        /// <summary>
        /// Sku ID of the item
        /// </summary>
        public string SkuId { get; set; }
        /// <summary>
        /// Total Quantity of the Cart Item.
        /// </summary>
        public int Quantity { get; set; }

    }
}
