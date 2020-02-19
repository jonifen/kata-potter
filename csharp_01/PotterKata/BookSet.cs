using System;
using System.Collections.Generic;
using System.Linq;

namespace PotterKata
{
    public class BookSet
    {
        private readonly IList<Book> _books = new List<Book>();
        private readonly Discounter _discounter = new Discounter();

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
                return _books.Sum(b => b.Price) * _discounter.GetDiscount(_books);
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
            return tempBookSet.Sum(b => b.Price) * _discounter.GetDiscount(tempBookSet);
        }

        public Guid Id { get; private set; }
    }
}
