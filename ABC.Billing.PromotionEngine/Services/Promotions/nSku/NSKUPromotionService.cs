using ABC.Billing.PromotionEngine.Services.Cart;
using ABC.Billing.PromotionEngine.Services.Pricing;
using System;
using System.Collections.Generic;
using System.Text;

namespace ABC.Billing.PromotionEngine.Services.Promotions.nSku
{
    public class NSKUPromotionService : IPromotionServices
    {

        public NSKUPromotionService(string SkuId, int count, decimal price)
        {
            throw new NotImplementedException();
        }

        public decimal Price()
        {
            throw new NotImplementedException();
        }

        public void SetCart(ICartService cartService)
        {
            throw new NotImplementedException();
        }

        public void SetPriceList(IPriceListService priceListService)
        {
            throw new NotImplementedException();
        }
    }
}
