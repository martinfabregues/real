using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class OrdenCompra
    {
        public int odcid { get; set; }
        public string odcnumero { get; set; }
        public DateTime odcfecha { get; set; }
        public Proveedor proveedor { get; set; }
        public int proid { get; set; }
        public decimal odcimporte { get; set; }
        public int estid { get; set; }
        public string odcobservacion { get; set; }
        public int odcactivo { get; set; }
        public IList<OrdenCompraDetalle> Detalle { get; set; }
    }
}
