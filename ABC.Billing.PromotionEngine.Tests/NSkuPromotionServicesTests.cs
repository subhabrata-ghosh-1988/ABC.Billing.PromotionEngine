using ABC.Billing.PromotionEngine.Services.Cart;
using ABC.Billing.PromotionEngine.Services.Pricing;
using ABC.Billing.PromotionEngine.Services.Promotions;
using ABC.Billing.PromotionEngine.Services.Promotions.nSku;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ABC.Billing.PromotionEngine.Tests
{
    /// <summary>
    /// This is a test for N-SKu promotions
    /// </summary>
    public class NSkuPromotionServicesTests
    {
        IPriceListService _priceListService;
        ICartService _cartService;
        /// <summary>
        /// Test setup
        /// </summary>
        public NSkuPromotionServicesTests()
        {
            _priceListService = new PriceListService();
            _cartService = new CartService(_priceListService);
            _cartService.AddItem("A", 4);
            _cartService.AddItem("D", 3);
        }
        /// <summary>
        /// Test without a valid promotion set up.
        /// </summary>
        [Fact]
        public void PromotionWithNoCartsTests()
        {
            IPromotionServices _promotionServices = new NSKUPromotionService("A", 3, 130);
            Assert.Equal(0, _promotionServices.Price());
        }

        /// <summary>
        /// Test without a valid price list set up.
        /// </summary>
        [Fact]
        public void PromotionWithNoPriceListsTests()
        {
            IPromotionServices _promotionServices = new NSKUPromotionService("A", 3, 130);
            _promotionServices.SetCart(_cartService);
            Assert.Equal(0, _promotionServices.Price());
        }

        /// <summary>
        /// Test without a valid promotion cart
        /// </summary>
        [Fact]
        public void PromotionWithNoSkuItemsTests()
        {
            IPromotionServices _promotionServices = new NSKUPromotionService("A", 3, 130);
            _cartService.RemoveItem("A");
            _promotionServices.SetCart(_cartService);
            _promotionServices.SetPriceList(_priceListService);
            Assert.Equal(_cartService.Price(), _promotionServices.Price());
        }
        /// <summary>
        /// Test with a valid promotion cart. part 1
        /// </summary>
        [Fact]
        public void PromotionAppliedTests_1()
        {
            IPromotionServices _promotionServices = new NSKUPromotionService("A", 3, 130);
            _promotionServices.SetCart(_cartService);
            _promotionServices.SetPriceList(_priceListService);
            Assert.Equal(225, _promotionServices.Price());
        }

        /// <summary>
        /// Test with a valid promotion cart. part 2
        /// </summary>
        [Fact]
        public void PromotionAppliedTests_2()
        {
            IPromotionServices _promotionServices = new NSKUPromotionService("B", 2, 45);
            _cartService.AddItem("B", 5);
            _cartService.AddItem("B", 2);
            _promotionServices.SetCart(_cartService);
            _promotionServices.SetPriceList(_priceListService);
            Assert.Equal(410, _promotionServices.Price());
        }
    }
}
