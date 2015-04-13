using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class Proveedor
    {
        public int proid {get;set;}
        public string procodigo { get; set; }
        public string prorazonsocial {get;set;}
        public string pronombre { get; set; }
        public string prodireccion { get; set; }
        public string probarrio { get; set; }
        public string procodpostal { get; set; }
        public int locid { get; set; }
        public string protelefono { get; set; }
        public int tpiid { get; set; }
        public string procuit { get; set; }
        public string proingbrutos { get; set; }
        public int actid { get; set; }
        public string proemail { get; set; }
        public double proingbrutostributo { get; set; }

        //public Localidad localidad { get; set; }
        //public TipoIva tipoiva { get; set; }
        //public Actividad actividad { get; set; }
    }
}
