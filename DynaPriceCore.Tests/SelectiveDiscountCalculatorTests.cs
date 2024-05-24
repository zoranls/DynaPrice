using DynaPrice;
using NUnit.Framework;


namespace DynaPriceCore.Tests
{
    [TestFixture]
    public class SelectiveDiscountCalculatorTests
    {
        [Test]
        public void CalculateDiscount_WithUniversalAndUPCDiscount_ReturnsCorrectDiscount()
        {
            // Arrange
            const decimal universalDiscountPercentage = 10m;
            const decimal upcDiscountPercentage = 5m;
            const string upc = "12345";
            const decimal price = 100m;
            var calculator = new SelectiveDiscountCalculator(universalDiscountPercentage, upcDiscountPercentage, upc);

            // Act
            var discount = calculator.CalculateDiscount(price);

            // Assert
            const decimal expectedDiscount = price * (universalDiscountPercentage / 100) + price * (upcDiscountPercentage / 100);
            Assert.That(expectedDiscount == discount);
        }

        [Test]
        public void CalculateDiscount_WithUniversalAndRandomUPCDiscount_ReturnsCorrectDiscount()
        {
            // Arrange
            const decimal universalDiscountPercentage = 10m;
            const decimal upcDiscountPercentage = 5m;
            const string upc = "67890"; // Different from "12345"
            const decimal price = 100m;
            var calculator = new SelectiveDiscountCalculator(universalDiscountPercentage, upcDiscountPercentage, upc);

            // Act
            var discount = calculator.CalculateDiscount(price);

            // Assert
            const decimal universalDiscountAmount = price * (universalDiscountPercentage / 100);
            const decimal minExpectedDiscount = universalDiscountAmount + price * (2m / 100);
            const decimal maxExpectedDiscount = universalDiscountAmount + price * (25m / 100);
            Assert.That(discount, Is.InRange(minExpectedDiscount, maxExpectedDiscount));
        }

        [Test]
        public void CalculateDiscount_WithNoDiscounts_ReturnsZeroDiscount()
        {
            // Arrange
            const decimal universalDiscountPercentage = 0m;
            const decimal upcDiscountPercentage = 0m;
            const string upc = "12345";
            const decimal price = 100m;
            var calculator = new SelectiveDiscountCalculator(universalDiscountPercentage, upcDiscountPercentage, upc);

            // Act
            var discount = calculator.CalculateDiscount(price);

            // Assert
            Assert.That(0m == discount);
        }

        [Test]
        public void CalculateDiscount_WithUniversalDiscountOnly_ReturnsCorrectDiscount()
        {
            // Arrange
            const decimal universalDiscountPercentage = 10m;
            const decimal upcDiscountPercentage = 10m;
            const string upc = "67890";
            const decimal price = 100m;
            var calculator = new SelectiveDiscountCalculator(universalDiscountPercentage, upcDiscountPercentage, upc);

            // Act
            var discount = calculator.CalculateDiscount(price);

            // Assert
            const decimal universalDiscountAmount = price * (universalDiscountPercentage / 100);
            const decimal minExpectedDiscount = universalDiscountAmount + price * (2m / 100);
            const decimal maxExpectedDiscount = universalDiscountAmount + price * (25m / 100);
            Assert.That(discount, Is.InRange(minExpectedDiscount, maxExpectedDiscount));
        }
    }
}
