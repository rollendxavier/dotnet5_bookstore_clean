using Bookstore.Domain.Models;
using CsvHelper.Configuration;

namespace Bookstore.Data.Mappings
{
    public sealed class  BookCategoryMap : ClassMap<BookCategory>
    {
        public BookCategoryMap()
        {
            Map(x => x.CategoryId).Name("CategoryId");
            Map(x => x.CategoryName).Name("CategoryName");
            Map(x => x.DiscountPerc).Name("DiscountPerc");
        }
    }
}
