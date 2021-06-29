using Bookstore.Domain.Models;

namespace Bookstore.Application.ViewModels
{
    public class BookViewModel
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
    }
}
