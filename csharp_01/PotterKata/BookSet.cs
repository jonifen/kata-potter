using System;
using System.Collections.Generic;
using System.Linq;

namespace PotterKata
{
    public class BookSet
    {
        private readonly IList<Book> _books = new List<Book>();
        private readonly Dictionary<int, decimal> _discounts = new Dictionary<int, decimal>
        {
            { 1, 0 },
            { 2, 0.05m },
            { 3, 0.10m },
            { 4, 0.20m },
            { 5, 0.25m }
        };

        public BookSet(Book book)
        {
            Add(book);
            Id = Guid.NewGuid();
        }

        public void Add(Book book)
        {
            _books.Add(book);
        }

        public decimal Total
        {
            get
            {
                return _books.Sum(b => b.Price) * (1 - _discounts[_books.Count]);
            }
        }

        public bool CanInclude(Book book)
        {
            var match = _books.Where(b => b.Id == book.Id).FirstOrDefault();
            return match == null;
        }

        public decimal CalculateTotalIncludingBook(Book book)
        {
            var tempBookSet = new List<Book>(_books);
            tempBookSet.Add(book);
            return tempBookSet.Sum(b => b.Price) * (1 - _discounts[tempBookSet.Count]);
        }

        public Guid Id { get; private set; }
    }
}
