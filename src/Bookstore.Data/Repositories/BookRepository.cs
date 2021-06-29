using Bookstore.Domain.Interfaces;
using Bookstore.Domain.Models;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace Bookstore.Data
{
    public class BookRepository : IBookRepository
    {

        public BookRepository()
        {
        }
        public IEnumerable<Book> GetBooks()
        {
            string bookLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data\\Books.csv");

            try
            {
                var reader = new StreamReader(bookLocation);
                var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
                var records = csv.GetRecords<Book>();
                return records;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IEnumerable<BookCategory> GetBookCategories()
        {
            string categoryLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data\\BookCategories.csv");

            try
            {
                var reader = new StreamReader(categoryLocation);
                var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
                var records = csv.GetRecords<BookCategory>();
                return records;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
