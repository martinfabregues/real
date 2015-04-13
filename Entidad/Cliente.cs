using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class Cliente
    {
        public int cliid { get; set; }
        public string clicodigo { get; set; }
        public string clinombre { get; set; }
        public string clidocumento { get; set; }
        public TipoIva tipoiva { get; set; }
        public String clibarrio { get; set; }
        public Ciudad ciudad { get; set; }
        public string clicalle { get; set; }
        public string clinumero { get; set; }
        public string clipiso { get; set; }
        public string clidepto { get; set; }
        public string clitelefonofijo { get; set; }
        public string clitelefonocelular { get; set; }
        public string cliemail { get; set; }
        public Estado estado { get; set; }
        public DateTime clifecha { get; set; }
    }
}
