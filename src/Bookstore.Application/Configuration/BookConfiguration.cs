using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Application.Configuration
{
    public class BookConfiguration
    {
        public decimal DeliveryFee { get; set; }
        public decimal MinimumOrderFee { get; set; }
        public int GSTPercentage { get; set; }
    }
}
