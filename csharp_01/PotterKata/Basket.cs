using System.Collections.Generic;
using System.Linq;

namespace PotterKata
{
    public class Basket
    {
        private IList<Book> _books;
        private IList<BookSet> _bookSets;

        public Basket()
        {
            _books = new List<Book>();
            _bookSets = new List<BookSet>();
        }

        public void Add(int[] books)
        {
            _books = new List<Book>(books.Select(book => new Book(book)));
            AddBooksToBookSetsWithBestDiscount();
        }

        public decimal Total
        {
            get
            {
                return CalculateTotalOfBookSets(_bookSets);
            }
        }

        private void AddBooksToBookSetsWithBestDiscount()
        {
            var sortedBasket = _books.OrderBy(book => book);

            foreach (var book in _books)
            {
                if (!_bookSets.Any(bookSet => bookSet.CanInclude(book)))
                {
                    _bookSets.Add(new BookSet(book));
                    continue;
                }

                var cheapestOption = _bookSets
                    .Where(s => s.CanInclude(book))
                    .OrderBy(w => CalculateTotalOfBookSetsIncludingBookInSpecificBookSet(w, book))
                    .First();
                cheapestOption.Add(book);
            }
        }

        private decimal CalculateTotalOfBookSets(IEnumerable<BookSet> bookSets)
        {
            return bookSets.Sum(s => s.Total);
        }

        public decimal CalculateTotalOfBookSetsIncludingBookInSpecificBookSet(BookSet bookSet, Book book)
        {
            var bookSets = _bookSets.Where(s => s.Id != bookSet.Id);
            return CalculateTotalOfBookSets(bookSets) + bookSet.CalculateTotalIncludingBook(book);
        }
    }
}
