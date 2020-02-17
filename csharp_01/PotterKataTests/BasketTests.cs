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
        [TestCase(new int[] { 1 }, 8, TestName = "Scan One Book, Get Price")]
        [TestCase(new int[] { 1, 2 }, 15.20, TestName = "Scan Two Different Books, Get Price")]
        [TestCase(new int[] { 1, 2, 3 }, 21.60, TestName = "Scan Three Different Books, Get Price")]
        public void BasketTestCases(int[] books, decimal expectedPrice)
        {
            _basket.Add(books);
            Assert.AreEqual(expectedPrice, _basket.Total);
        }
    }
}