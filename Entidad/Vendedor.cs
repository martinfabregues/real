using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidad
{
    public class Vendedor
    {
        public int vendedor_id { get; set; }
        public string vendedor_nombre { get; set; }
        public string vendedor_direccion { get; set; }
        public string vendedor_telefonofijo { get; set; }
        public string vendedor_telefonocelular { get; set; }
        public string vendedor_email { get; set; }
        public Estado estado { get; set; }
    }
}
