using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class OrdenCompraDetalle
    {
        public int ocdid { get; set; }
        public int odcid { get; set; }
        public int prdid { get; set; }
        public int ocdcantidad { get; set; }
        public int sucid { get; set; }
        public decimal ocdimporteunit { get; set; }
        public int ecdid { get; set; }
        public string ocdobservacion { get; set; }

        public Producto producto { get; set; }
        public Sucursal sucursal { get; set; }
    }
}
