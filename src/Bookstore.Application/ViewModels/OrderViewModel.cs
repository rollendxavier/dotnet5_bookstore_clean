using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Application.ViewModels
{
    /// <summary>
    /// This is the view model which outputs the total order cost with and without tax.
    /// </summary>
    public class OrderViewModel
    {
        public int OrderId { get; set; }
        public string Title { get; set; }
        public int Quantity { get; set; }
    }
}
