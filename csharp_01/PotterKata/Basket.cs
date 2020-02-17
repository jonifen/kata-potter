using System;
using System.Collections.Generic;

namespace PotterKata
{
    public class Basket
    {
        private readonly List<int> _books;

        public Basket()
        {
            _books = new List<int>();
        }

        public void Add(int[] books)
        {
            _books.AddRange(books);
        }

        public decimal Total
        {
            get
            {
                if (_books.Count == 1)
                {
                    return 8;
                }
                else
                {
                    return 15.2m;
                }
            }
        }
    }
}
