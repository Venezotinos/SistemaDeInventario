using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeInventario.Models
{
    public class Sell
    {
        public int ID { get; set; }

        public DateTime SellDate { get; set; }

        public int Quantity { get; set; }

        public double Income { get; set; }

        public int ProductID { get; set; }

        public Product Product { get; set; }
    }
}
