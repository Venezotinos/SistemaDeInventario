using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockSystem.Models
{
    public class Category
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<CategoryProduct> Products { get; set; }
    }
}
