using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Real.UI.Depositos.Entidad
{
    public class Marca
    {
        public int id { get; set; }
        public int proveedor_id { get; set; }
        public string marca { get; set; }
        public int activo { get; set; }
    }
}
