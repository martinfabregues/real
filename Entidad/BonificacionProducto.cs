using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidad
{
    public class BonificacionProducto
    {
        public int bopid { get; set; }
        public Bonificacion bonificacion { get; set; }        
        public Producto producto { get; set; }


        public int prdid { get; set; }
        public int bonid { get; set; }
    }
}
