using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidad
{
    public class ListaPrecioProducto
    {
        public int listaprecioproducto_id { get; set; }
        public ListaPrecio listaprecio { get; set; }
        public Producto producto { get; set; }
        public double listaprecioproducto_costobruto { get; set; }
        public double listaprecioproducto_costoneto { get; set; }
        public double listaprecioproducto_precioventa { get; set; }
    }
}
