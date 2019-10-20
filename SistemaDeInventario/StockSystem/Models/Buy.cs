using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockSystem.Models
{
    public class Buy
    {
        public int ID { get; set; }

        public DateTime BuyDate { get; set; }

        public int Quantity { get; set; }

        public double Ammount { get; set; }

        public int ProductID { get; set; }

        public Product Product { get; set; }
    }
}
