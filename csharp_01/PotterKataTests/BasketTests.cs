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
        public void ScanOneBookGetPrice()
        {
            _basket.Add(new int[] { 1 });
            Assert.AreEqual(8, _basket.Total);
        }

        [Test]
        public void ScanTwoDifferentBooksGetPrice()
        {
            _basket.Add(new int[] { 1, 2 });
            Assert.AreEqual(15.2m, _basket.Total);
        }
    }
}