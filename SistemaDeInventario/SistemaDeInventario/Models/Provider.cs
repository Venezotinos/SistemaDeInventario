using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeInventario.Models
{
    public class Provider
    {
        public int ProviderID { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public ICollection<ProviderProduct> Products { get; set; }
    }
}
