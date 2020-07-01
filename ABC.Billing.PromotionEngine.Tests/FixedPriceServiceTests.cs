using ABC.Billing.PromotionEngine.Services.Cart;
using ABC.Billing.PromotionEngine.Services.Pricing;
using ABC.Billing.PromotionEngine.Services.Promotions;
using ABC.Billing.PromotionEngine.Services.Promotions.FixedPrice;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ABC.Billing.PromotionEngine.Tests
{
    /// <summary>
    /// This is the test for Fixed Price service
    /// </summary>
    public class FixedPriceServiceTests
    {
        IPriceListService _priceListService;
        ICartService _cartService;
        /// <summary>
        /// Test set up
        /// </summary>
        public FixedPriceServiceTests()
        {
            _priceListService = new PriceListService();
            _cartService = new CartService(_priceListService);
            _cartService.AddItem("A", 4);
            _cartService.AddItem("B", 1);
            _cartService.AddItem("C", 1);
            _cartService.AddItem("D", 4);
        }

        /// <summary>
        /// Test with out a cart set up.
        /// </summary>
        [Fact]
        public void PromotionWithNoCartsTests()
        {
            IPromotionServices _promotionServices = new FixedPricePromotionServices(new List<string> { "C", "D" }, 30);
            Assert.Equal(0, _promotionServices.Price());
        }

        /// <summary>
        /// Test with out a price list set up
        /// </summary>
        [Fact]
        public void PromotionWithNoPriceListsTests()
        {
            IPromotionServices _promotionServices = new FixedPricePromotionServices(new List<string> { "C", "D" }, 30);
            _promotionServices.SetCart(_cartService);
            Assert.Equal(0, _promotionServices.Price());
        }
        /// <summary>
        /// Test with out a valid promotion set up
        /// </summary>
        [Fact]
        public void PromotionWithInvalidItemsTests()
        {
            IPromotionServices _promotionServices = new FixedPricePromotionServices(new List<string> { "C", "D" }, 30);
            _cartService.RemoveItem("C");
            _promotionServices.SetCart(_cartService);
            _promotionServices.SetPriceList(_priceListService);
            Assert.Equal(_cartService.Price(), _promotionServices.Price());
        }

        /// <summary>
        /// Test with a valid promotion set up..
        /// </summary>
        [Fact]
        public void PromotionWithValidSkuItemsTests()
        {
            IPromotionServices _promotionServices = new FixedPricePromotionServices(new List<string> { "C", "D" }, 30);
            _promotionServices.SetCart(_cartService);
            _promotionServices.SetPriceList(_priceListService);
            Assert.Equal(305, _promotionServices.Price());
        }
    }
}
