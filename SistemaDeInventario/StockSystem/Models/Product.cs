using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StockSystem.Models
{
    public class Product
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public double BuyPrice { get; set; }

        public DateTime ExpirationDate { get; set; }

        public ICollection<BranchProduct> Branches { get; set; }

        public ICollection<ProviderProduct> Providers { get; set; }

        public ICollection<CategoryProduct> Categories { get; set; }

        public ICollection<Buy> Buys { get; set; }

        public ICollection<Sell> Sells { get; set; }
    }
}
