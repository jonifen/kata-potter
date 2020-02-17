using System;
using System.Collections.Generic;

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
                return (_books.Count * _bookPrice) * (1 - _discounts[_books.Count]);
            }
        }
    }
}
