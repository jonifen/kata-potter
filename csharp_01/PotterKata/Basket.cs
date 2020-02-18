using System.Collections.Generic;
using System.Linq;

namespace PotterKata
{
    public class Basket
    {
        private IList<Book> _books;

        public Basket()
        {
            _books = new List<Book>();
        }

        public void Add(int[] books)
        {
            _books = new List<Book>(books.Select(book => new Book(book)));
        }

        public decimal Total
        {
            get
            {
                decimal runningTotal = 0;
                var remainingBooks = new List<Book>(_books);

                while (remainingBooks.Count > 0)
                {
                    var currentBookSet = remainingBooks
                        .GroupBy(b => b.Id)
                        .Select(g => g.First())
                        .ToList();

                    foreach(var book in currentBookSet)
                    {
                        remainingBooks.Remove(book);
                    }

                    runningTotal += new BookSet(currentBookSet).Total;
                }

                return runningTotal;
            }
        }
    }
}
