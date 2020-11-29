namespace PotterKata
{
    public class Book
    {
        public Book(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }

        public decimal Price {
            get
            {
                return 8.00m;
            }
        }
    }
}
