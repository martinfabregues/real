using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class FacturaProveedorDetalle
    {
        public int fpdid { get; set; }
        public int fapid { get; set; }
        public int prdid { get; set; }
        public decimal fpdimporteunit { get; set; }
        public int fpdcantidad { get; set; }
        public int odcid { get; set; }

    }
}
