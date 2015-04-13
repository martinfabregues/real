using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class OrdenCompraPendiente
    {
        public int ocpid { get; set; }
        public int odcid { get; set; }
        public int prdid { get; set; }
        public int ocdcantidad {get;set;}
        public decimal ocdimporte { get; set; }
        public int sucid { get; set; }
        public int proid { get; set; }
        public int espid { get; set; }

        public OrdenCompra ordencompra { get; set; }
        public Producto producto { get; set; }
        public Sucursal sucursal { get; set; }
        public Proveedor proveedor { get; set; }


    }
}
