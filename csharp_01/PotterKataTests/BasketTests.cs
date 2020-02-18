using NUnit.Framework;
using PotterKata;

namespace PotterKataTests
{
    public class BasketTests
    {
        private Basket _basket;

        [SetUp]
        public void Setup()
        {
            _basket = new Basket();
        }

        private void RunBasketTest(int[] books, decimal expectedPrice)
        {
            _basket.Add(books);
            Assert.AreEqual(expectedPrice, _basket.Total);
        }

        [Test]
        [TestCase(new int[] { 1 }, 8.00, TestName = "Basics. Scan Book #1 only")]
        [TestCase(new int[] { 2 }, 8.00, TestName = "Basics. Scan Book #2 only")]
        [TestCase(new int[] { 3 }, 8.00, TestName = "Basics. Scan Book #3 only")]
        [TestCase(new int[] { 4 }, 8.00, TestName = "Basics. Scan Book #4 only")]
        [TestCase(new int[] { 5 }, 8.00, TestName = "Basics. Scan Book #5 only")]
        [TestCase(new int[] { 1, 1, 1 }, 24.00, TestName = "Basics. Scan 3x #1 only")]
        public void TestBasics(int[] books, decimal expectedPrice) => RunBasketTest(books, expectedPrice);

        [Test]
        [TestCase(new int[] { 1, 2 }, 15.20, TestName = "Simple Discounts. Two different books = 5%")]
        [TestCase(new int[] { 1, 2, 3 }, 21.60, TestName = "Simple Discounts. Three different books = 10%")]
        [TestCase(new int[] { 1, 2, 3, 4 }, 25.60, TestName = "Simple Discounts. Four different books = 20%")]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 30.00, TestName = "Simple Discounts. Five different books = 25%")]
        public void TestSimpleDiscounts(int[] books, decimal expectedPrice) => RunBasketTest(books, expectedPrice);

        [Test]
        [TestCase(new int[] { 1, 1, 2 }, 23.20, TestName = "Several Discounts. 1x 5% and 1x single book")]
        [TestCase(new int[] { 1, 1, 2, 2 }, 30.40, TestName = "Several Discounts. 2x 5% discount")]
        [TestCase(new int[] { 1, 1, 2, 3, 3, 4 }, 40.80, TestName = "Several Discounts. 1x 20% and 1x 5% discount")]
        [TestCase(new int[] { 1, 2, 2, 3, 4, 5 }, 38.00, TestName = "Several Discounts. 1x 25% and 1x single book")]
        public void TestSeveralDiscounts(int[] books, decimal expectedPrice) => RunBasketTest(books, expectedPrice);

        //[Test]
        //[TestCase(new int[] { 1, 1, 2, 2, 3, 3, 4, 5 }, 51.20, TestName = "Edge Cases. 2x 20% discount")]
        //[TestCase(new int[] { 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 3, 3, 3, 3, 4, 4, 4, 4, 4, 5, 5, 5, 5 }, 141.20, TestName = "Edge Cases. 3x 25% and 2x 20% discount")]
        //public void TestEdgeCases(int[] books, decimal expectedPrice) => RunBasketTest(books, expectedPrice);
    }
}