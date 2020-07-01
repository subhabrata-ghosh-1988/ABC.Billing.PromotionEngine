using ABC.Billing.PromotionEngine.Services.Cart;
using ABC.Billing.PromotionEngine.Services.Pricing;
using System;
using System.Collections.Generic;
using System.Text;

namespace ABC.Billing.PromotionEngine.Services.Promotions
{
    /// <summary>
    /// Promotional service
    /// </summary>
    public interface IPromotionServices
    {
        void SetCart(ICartService cartService);
        void SetPriceList(IPriceListService priceListService);
        decimal Price();
    }
}
