using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeInventario.Models
{
    public class ProviderProduct
    {
        public int ProviderID { get; set; }

        public int ProductID { get; set; }

        public Provider Provider { get; set; }

        public Product Product { get; set; }
    }
}
