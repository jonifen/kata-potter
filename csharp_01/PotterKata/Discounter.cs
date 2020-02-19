using System.Collections.Generic;

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

        public decimal GetDiscount(IList<Book> books)
        {
            return (1 - _discounts[books.Count]);
        }
    }
}
