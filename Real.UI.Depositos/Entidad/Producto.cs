using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Real.UI.Depositos.Entidad
{
    public class Producto
    {
        public int id { get; set; }
        public int proveedor_id { get; set; }
        public int marca_id {get;set;}
        public int categoria_id { get; set; }
        public string denominacion { get; set; }
        public decimal costo { get; set; }
        public decimal metros_cubicos { get; set; }
        public int activo { get; set; }
    }
}
