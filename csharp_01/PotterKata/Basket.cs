using System.Collections.Generic;
using System.Linq;

namespace PotterKata
{
    public class Basket
    {
        private IList<BookSet> _bookSets;

        public Basket()
        {
            _bookSets = new List<BookSet>();
        }

        public void Add(int[] books)
        {
            AddBooksToBookSetsWithBestDiscount(new List<Book>(books.Select(book => new Book(book))));
        }

        public decimal Total
        {
            get
            {
                return CalculateTotalOfBookSets(_bookSets);
            }
        }

        private void AddBooksToBookSetsWithBestDiscount(IList<Book> books)
        {
            var sortedBasket = books.OrderBy(book => book);

            foreach (var book in books)
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
