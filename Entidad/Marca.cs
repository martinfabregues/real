using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class Marca
    {
        public int marid { get; set; }
        public int proid { get; set; }
        public string mardenominacion { get; set; }
        public Proveedor proveedor { get; set; }
    }
}
