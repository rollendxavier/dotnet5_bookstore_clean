using Bookstore.Domain.Models;
using CsvHelper.Configuration;

namespace Bookstore.Data.Mappings
{
    public sealed class BookMap : ClassMap<Book>
    {
        public BookMap()
        {
            Map(x => x.BookId).Name("BookId");
            Map(x => x.Title).Name("Title");
            Map(x => x.Author).Name("Author");
            Map(x => x.CategoryId).Name("CategoryId");
            Map(x => x.Price).Name("Price");
        }
    }
}
