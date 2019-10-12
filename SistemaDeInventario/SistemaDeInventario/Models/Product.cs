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

        public DateTime BuyDate { get; set; }

        public DateTime SellDate { get; set; }

        public ICollection<ProductCategory> Categories { get; set; }
    }
}
