using NUnit.Framework;
using PotterKata;

namespace PotterKataTests
{
    public class BasketTests
    {
        [Test]
        public void ScanOneBookGetPrice()
        {
            var basket = new Basket();
            basket.Add(new int[] { 1 });
            Assert.AreEqual(8, basket.Total);
        }
    }
}