using System;
using System.Collections.Generic;
using System.Linq;

namespace PotterKata
{
    public class Basket
    {
        private readonly decimal _bookPrice = 8m;
        private readonly List<int> _books;
        private readonly Dictionary<int, decimal> _discounts;

        public Basket()
        {
            _books = new List<int>();
            _discounts = new Dictionary<int, decimal>
            {
                { 1, 0 },
                { 2, 0.05m },
                { 3, 0.10m },
                { 4, 0.20m },
                { 5, 0.25m }
            };
        }

        public void Add(int[] books)
        {
            _books.AddRange(books);
        }

        public decimal Total
        {
            get
            {
                decimal runningTotal = 0;
                var remainingBooks = new List<int>(_books);

                while (remainingBooks.Count > 0)
                {
                    var currentBookSet = remainingBooks.Distinct().ToList();

                    foreach(var book in currentBookSet)
                    {
                        remainingBooks.Remove(book);
                    }

                    runningTotal += (currentBookSet.Count * _bookPrice) * (1 - _discounts[currentBookSet.Count]);
                }

                return runningTotal;
            }
        }
    }
}
