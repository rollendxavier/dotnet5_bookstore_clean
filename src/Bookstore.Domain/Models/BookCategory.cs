namespace Bookstore.Domain.Models
{
    public abstract class BookCategory
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int DiscountPerc { get; set; }
    }
}
