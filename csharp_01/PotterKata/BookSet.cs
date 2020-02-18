using System.Collections.Generic;
using System.Linq;

namespace PotterKata
{
    public class BookSet
    {
        private readonly IList<Book> _books;
        private readonly Dictionary<int, decimal> _discounts;

        public BookSet(IEnumerable<Book> books)
        {
            _books = books.ToList();
            _discounts = new Dictionary<int, decimal>
            {
                { 1, 0 },
                { 2, 0.05m },
                { 3, 0.10m },
                { 4, 0.20m },
                { 5, 0.25m }
            };
        }

        public decimal Total
        {
            get
            {
                return _books.Sum(b => b.Price) * (1 - _discounts[_books.Count]);
            }
        }
    }
}
