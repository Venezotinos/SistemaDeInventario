using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeInventario.Models
{
    public class Branch
    {
        public int BranchID { get; set; }

        public string Name { get; set; }

        public ICollection<BranchProduct> Products { get; set; }
    }
}
