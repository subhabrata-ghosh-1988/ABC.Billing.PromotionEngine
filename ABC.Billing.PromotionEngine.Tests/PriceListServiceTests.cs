using ABC.Billing.PromotionEngine.Services.Pricing;
using Xunit;

namespace ABC.Billing.PromotionEngine.Tests
{
    public class PriceListServiceTests
    {
        [Fact]
        public void PriceForValidItemsTests()
        {
            IPriceListService priceListService = new PriceListService();
            decimal price_a = priceListService.GetPriceBySkuID("A");
            Assert.True(price_a > 0);
        }

        [Fact]
        public void PriceForInValidItemsTest()
        {
            IPriceListService priceListService = new PriceListService();
            decimal price_a = priceListService.GetPriceBySkuID("ABC");
            Assert.True(price_a == 0);
        }


        [Fact]
        public void CheckPriceListsAllItems()
        {
            IPriceListService priceListService = new PriceListService();
            var dict = priceListService.GetAllPrices();
            Assert.True(dict.ContainsKey("A"));
        }
    }
}
