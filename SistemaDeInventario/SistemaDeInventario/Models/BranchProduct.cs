using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeInventario.Models
{
    public class BranchProduct
    {
        public int BranchID { get; set; }
        
        public int ProductID { get; set; }

        public Branch Branch { get; set; }

        public Product Product { get; set; } 
    }
}
