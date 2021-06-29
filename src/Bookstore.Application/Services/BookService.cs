using Bookstore.Application.Interfaces;
using Bookstore.Application.ViewModels;
using Bookstore.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Bookstore.Application.Configuration;

namespace Bookstore.Application
{
    /// <summary>
    /// Simple book service responsible to display the book details, get orders from user and calculates Invoice.
    /// </summary>
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly ILogger _logger;
        IOptions<BookConfiguration> _config;
        public BookService(IBookRepository bookRepository, ILogger<BookService> logger, IOptions<BookConfiguration> config)
        {
            _bookRepository = bookRepository;
            _logger = logger;
            _config = config;
        }

        /// <summary>
        /// Main method which do the operations of a bookstore
        /// </summary>
        public void OpenBookStore()
        {
            try
            {
                var books = GetBooks().ToList();
                DisplayBooks(books);
                var order = GetUserOrder();
                CalculateAndPrintInvoice(order, books);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }
        }

        private IEnumerable<BookViewModel> GetBooks()
        {
            var books = _bookRepository.GetBooks();
            var generes = _bookRepository.GetBookCategories();

            var model = from book in books
                        join genere in generes
                             on book.CategoryId equals genere.CategoryId
                        select new BookViewModel
                        {
                            BookId = book.BookId,
                            Title = book.Title,
                            Author = book.Author,
                            Genre = genere.CategoryName,
                            Price = book.Price,
                            Discount = (book.Price * genere.DiscountPerc) / 100
                        };

            return model;
        }

        /// <summary>
        /// This method will display the book details
        /// </summary>
        /// <param name="books"></param>
        public void DisplayBooks(IEnumerable<BookViewModel> books)
        {
            Console.Clear();
            Console.WriteLine("{0,50}", "BOOKSTORE LIST");
            Console.WriteLine(new string('*', 110));
            Console.WriteLine("{0,5}|{1,23}|{2,35}|{3,10}|{4,10}",
            "Sl#", "Title", "Author", "Genre", "Unit Price (AUD) *GST not applied");
            Console.WriteLine(new string('*', 110));

            foreach (var book in books)
            {
                Console.WriteLine("{0,5}|{1,23}|{2,35}|{3,10}|{4,10}",
                          book.BookId,
                          book.Title,
                          book.Author,
                          book.Genre,
                          book.Price);
            }
        }

        /// <summary>
        /// This method will get the user inputs
        /// </summary>
        /// <returns></returns>
        private string[] GetUserOrder()
        {
            Console.WriteLine("Enter the 5 BookId's you want to purchase.");
            string[] orders = new string[5];
            for (int i = 0; i < orders.Length; i++)
            {
                orders[i] = Console.ReadLine();
            }

            return orders;
        }

        /// <summary>
        /// This method will calculate and display the final invoice.
        /// </summary>
        /// <param name="orders"></param>
        /// <param name="books"></param>
        private void CalculateAndPrintInvoice(string[] orders, IEnumerable<BookViewModel> books)
        {
            decimal totalOrderCost = 0;
            decimal totalDiscount = 0;

            Console.WriteLine("{0,50}", "INVOICE");
            Console.WriteLine(new string('*', 110));

            Console.WriteLine("{0,23}|{1,10}|{2,5}|{3,5}|{4,5}",
           "Title", "Genre", "Quantity", "Price $", "Discount $");
            Console.WriteLine(new string('*', 110));

            foreach (var bookid in orders)
            {
                var book = books.Where(x => x.BookId == Convert.ToInt32(bookid)).FirstOrDefault();

                Console.WriteLine("{0,23}|{1,10}|{2,5}|{3,5}|{4,5}",
                          book.Title,
                          book.Genre,
                          1,
                          book.Price,
                          book.Discount);

                totalOrderCost += book.Price;
                totalDiscount += book.Discount;
            }
            var totalCost = totalOrderCost - totalDiscount;
            var totalCostGST = totalCost + ((totalCost * _config.Value.GSTPercentage) / 100);
            var deliveryFee = totalCostGST < _config.Value.MinimumOrderFee ? _config.Value.DeliveryFee : 0;

            Console.WriteLine(new string('*', 110));
            Console.WriteLine("{0,35}|{1,1}", "Total Book cost", totalOrderCost);
            Console.WriteLine("{0,35}|{1,1}", "Total Discount", totalDiscount);
            Console.WriteLine("{0,35}|{1,1}", "Total purchase cost (without GST)", totalCost);
            Console.WriteLine("{0,35}|{1,1}", "GST %", _config.Value.GSTPercentage);
            Console.WriteLine("{0,35}|{1,1}", "Total purchase cost including GST", totalCostGST);
            Console.WriteLine("{0,35}|{1,1}", "Delivery Fee if any", deliveryFee);
            Console.WriteLine(new string('*', 110));
            Console.WriteLine("{0,35}|{1,1}", "FINAL AMOUNT PAYABLE", totalCostGST + deliveryFee);
        }
    }
}
