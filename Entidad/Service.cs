using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class Service
    {
        public int serid { get; set; }
        public string sernumero { get; set; }
        public Proveedor proveedor { get; set; }
        public Sucursal sucursal { get; set; }
        public string serremito { get; set; }
        public int essid { get; set; }
        public Cliente cliente { get; set; }
        public DateTime serfecha { get; set; }
        public DateTime serfechacompra { get; set; }
        public string serfotocopiaremito { get; set; }
        public string serfotocopiafactura { get; set; }
        public string serfajagarantia { get; set; }
        public string sercertfabricacion { get; set; }
        public IList<ServiceDetalle> detalle { get; set; }
    }
}
