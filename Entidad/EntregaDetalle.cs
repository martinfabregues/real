using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class EntregaDetalle 
    {
        public int edeid { get; set; }
        public int entid { get; set; }      
        public int edecantidad { get; set; }
        public string edeproducto { get; set; }
        public string edesalida { get; set; }
    }
}
