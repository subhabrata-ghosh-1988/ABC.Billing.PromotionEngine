using ABC.Billing.PromotionEngine.Services.Cart;
using ABC.Billing.PromotionEngine.Services.Pricing;
using ABC.Billing.PromotionEngine.Services.Promotions;
using ABC.Billing.PromotionEngine.Services.Promotions.NoPromotions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ABC.Billing.PromotionEngine.Tests
{
    /// <summary>
    /// This a test for service without promotions
    /// </summary>
    public class NoPromotionServiceTests
    {
        IPriceListService _priceListService;
        ICartService _cartService;
        /// <summary>
        /// Test setup.
        /// </summary>
        public NoPromotionServiceTests()
        {
            _priceListService = new PriceListService();
            _cartService = new CartService(_priceListService);
            _cartService.AddItem("A", 4);
            _cartService.AddItem("D", 3);
        }
        /// <summary>
        /// Test without a valid promotion services.
        /// </summary>
        [Fact]
        public void PromotionWithNoCartsTests()
        {
            IPromotionServices _promotionServices = new NoPromotionServices();
            Assert.Equal(0, _promotionServices.Price());
        }
        /// <summary>
        /// Test with a valid promotion - However the result should be the original cart price.
        /// </summary>
        [Fact]
        public void PromotionWithCartsTests()
        {
            IPromotionServices _promotionServices = new NoPromotionServices();
            _promotionServices.SetCart(_cartService);
            Assert.Equal(245, _promotionServices.Price());
        }

    }
}
