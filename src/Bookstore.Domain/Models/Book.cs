namespace Bookstore.Domain.Models
{
    public abstract class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int CategoryId { get; set; }
        public decimal Price { get; set; }
    }
}
