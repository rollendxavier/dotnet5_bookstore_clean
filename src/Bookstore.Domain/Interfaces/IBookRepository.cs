using Bookstore.Domain.Models;
using System.Collections.Generic;

namespace Bookstore.Domain.Interfaces
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetBooks();
        IEnumerable<BookCategory> GetBookCategories();
    }
}
