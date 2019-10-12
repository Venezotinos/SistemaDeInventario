using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeInventario.Models
{
    public class ProductCategory
    {
        public int ProductID { get; set; }

        public int CategoryID { get; set; }

        public Product Product { get; set; }

        public Category Category { get; set; }
    }
}
