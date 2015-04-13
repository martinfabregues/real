using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidad.Criteria
{
    public class OrdenCompraPendienteCriteria
    {
        public Proveedor proveedor { get; set; }
        public Sucursal sucursal { get; set; }
        public Producto producto { get; set; }
    }
}
