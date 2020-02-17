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

        [Test]
        [TestCase(new int[] { 1 }, 8.00, TestName = "1) Scan One Book, Get Price")]
        [TestCase(new int[] { 1, 2 }, 15.20, TestName = "2) Scan Two Different Books, Get Price")]
        [TestCase(new int[] { 1, 2, 3 }, 21.60, TestName = "3) Scan Three Different Books, Get Price")]
        [TestCase(new int[] { 1, 2, 3, 4 }, 25.60, TestName = "4) Scan Four Different Books, Get Price")]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 30.00, TestName = "5) Scan Five Different Books, Get Price")]
        public void BasketTestCases(int[] books, decimal expectedPrice)
        {
            _basket.Add(books);
            Assert.AreEqual(expectedPrice, _basket.Total);
        }
    }
}