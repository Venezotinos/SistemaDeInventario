using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeInventario.Models
{
    public class CategoryProduct
    {
        public int CategoryID { get; set; }

        public int ProductID { get; set; }

        public Category Category { get; set; }

        public Product Product { get; set; }
    }
}
