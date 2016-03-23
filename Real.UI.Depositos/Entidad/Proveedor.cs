using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Real.UI.Depositos.Entidad
{
    public class Proveedor
    {
        public int id { get; set; }
        public DateTime fecha_registro { get; set; }
        public string razon_social { get; set; }
        public int activo { get; set; }
    }
}
