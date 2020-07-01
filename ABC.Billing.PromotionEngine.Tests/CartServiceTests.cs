using ABC.Billing.PromotionEngine.Services.Cart;
using ABC.Billing.PromotionEngine.Services.Pricing;
using System;
using Xunit;

namespace ABC.Billing.PromotionEngine.Tests
{
    /// <summary>
    /// This is the test for the cart service
    /// </summary>
    public class CartServiceTests
    {
        IPriceListService _priceListService;
        ICartService _cartService;
        /// <summary>
        /// Test set up.
        /// </summary>
        public CartServiceTests()
        {
            _priceListService = new PriceListService();
            _cartService = new CartService(_priceListService);
            _cartService.AddItem("A", 4);
            _cartService.AddItem("D", 3);
        }
        /// <summary>
        /// Add to cart test
        /// </summary>
        [Fact]
        public void AddToCartTests()
        {
            _cartService.AddItem("A", 2);
            _cartService.AddItem("B", 1);
            _cartService.AddItem("C", 1);
            _cartService.AddItem("D", 1);
            decimal price = _cartService.Price();
            Assert.Equal(410, price);
        }
        /// <summary>
        /// Edit cart item test.
        /// </summary>
        [Fact]
        public void EditCartItemTests()
        {
            _cartService.EditItem("A", 2);
            decimal price = _cartService.Price();
            Assert.Equal(145, price);
        }

        /// <summary>
        /// Edit an invalid cart item.
        /// </summary>
        [Fact]
        public void EditInvalidCartItemTests()
        {
            var ex = Assert.Throws<ArgumentException>(() => _cartService.EditItem("AXXX", 2));
            Assert.Equal("The Sku Id is not valid.", ex.Message);

        }
        /// <summary>
        /// Remove a cart item.
        /// </summary>
        [Fact]
        public void RemoveCartItemTests()
        {
            _cartService.RemoveItem("A");
            decimal price = _cartService.Price();
            Assert.Equal(45, price);
        }

    }
}
