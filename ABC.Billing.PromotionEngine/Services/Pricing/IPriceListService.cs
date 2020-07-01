using System;
using System.Collections.Generic;
using System.Text;

namespace ABC.Billing.PromotionEngine.Services.Pricing
{
    public interface IPriceListService
    {
        decimal GetPriceBySkuID(string skuId);
        Dictionary<string, decimal> GetAllPrices();
    }
}
