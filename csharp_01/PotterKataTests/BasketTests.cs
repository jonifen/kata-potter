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
        [TestCase(new int[] { 1 }, 8.00, TestName = "Basics. Scan Book #1 only")]
        [TestCase(new int[] { 2 }, 8.00, TestName = "Basics. Scan Book #2 only")]
        [TestCase(new int[] { 3 }, 8.00, TestName = "Basics. Scan Book #3 only")]
        [TestCase(new int[] { 4 }, 8.00, TestName = "Basics. Scan Book #4 only")]
        [TestCase(new int[] { 5 }, 8.00, TestName = "Basics. Scan Book #5 only")]
        [TestCase(new int[] { 1, 1, 1 }, 24.00, TestName = "Basics. Scan 3x #1 only")]
        public void TestBasics(int[] books, decimal expectedPrice)
        {
            _basket.Add(books);
            Assert.AreEqual(expectedPrice, _basket.Total);
        }

        [Test]
        [TestCase(new int[] { 1, 2 }, 15.20, TestName = "Simple Discounts. Two different books = 5%")]
        [TestCase(new int[] { 1, 2, 3 }, 21.60, TestName = "Simple Discounts. Three different books = 10%")]
        [TestCase(new int[] { 1, 2, 3, 4 }, 25.60, TestName = "Simple Discounts. Four different books = 20%")]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 30.00, TestName = "Simple Discounts. Five different books = 25%")]
        public void TestSimpleDiscounts(int[] books, decimal expectedPrice)
        {
            _basket.Add(books);
            Assert.AreEqual(expectedPrice, _basket.Total);
        }

        [Test]
        [TestCase(new int[] { 1, 1, 2 }, 23.20, TestName = "Several Discounts. Two different books, one extra")]
        [TestCase(new int[] { 1, 1, 2, 2 }, 30.40, TestName = "Several Discounts. Two different books twice")]
        public void TestSeveralDiscounts(int[] books, decimal expectedPrice)
        {
            _basket.Add(books);
            Assert.AreEqual(expectedPrice, _basket.Total);
        }


        /*
            def testSeveralDiscounts
              assert_equal(8 + (8 * 2 * 0.95), price([0, 0, 1]))
              assert_equal(2 * (8 * 2 * 0.95), price([0, 0, 1, 1]))
              assert_equal((8 * 4 * 0.8) + (8 * 2 * 0.95), price([0, 0, 1, 2, 2, 3]))
              assert_equal(8 + (8 * 5 * 0.75), price([0, 1, 1, 2, 3, 4]))
            end

            def testEdgeCases
              assert_equal(2 * (8 * 4 * 0.8), price([0, 0, 1, 1, 2, 2, 3, 4]))
              assert_equal(3 * (8 * 5 * 0.75) + 2 * (8 * 4 * 0.8), 
                price([0, 0, 0, 0, 0, 
                       1, 1, 1, 1, 1, 
                       2, 2, 2, 2, 
                       3, 3, 3, 3, 3, 
                       4, 4, 4, 4]))
            end 
        */
    }
}