using System.Collections.Generic;
using System.Linq;

namespace PotterKata
{
    public class Discounter
    {
        private readonly Dictionary<int, decimal> _discounts = new Dictionary<int, decimal>
        {
            { 1, 0 },
            { 2, 0.05m },
            { 3, 0.10m },
            { 4, 0.20m },
            { 5, 0.25m }
        };

        public decimal ApplyDiscount(IList<Book> books)
        {
            var discount = (1 - _discounts[books.Count]);
            return books.Sum(b => b.Price) * discount;
        }
    }
}
