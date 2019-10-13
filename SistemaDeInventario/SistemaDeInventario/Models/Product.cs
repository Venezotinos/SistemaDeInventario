using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeInventario.Models
{
    public class Product
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Price { get; set; }

        public double BuyPrice { get; set; }

        public DateTime ExpirationDate { get; set; }

        public int CategoryID { get; set; }

        public Category Category { get; set; }
    }
}
