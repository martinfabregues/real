using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidad
{
    public class ListaPrecio
    {
        public int listaprecio_id { get; set; }
        public Proveedor proveedor { get; set; }
        public string listaprecio_denominacion { get; set; }
        public DateTime listaprecio_fechacreacion { get; set; }
        public DateTime listaprecio_fechainicio {get; set;}
        public DateTime listaprecio_fechafin { get; set; }
        public Estado estado { get; set; }
    }
}
