using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class Producto
    {
        public int prdid { get; set; }
        public string prdcodigo { get; set; }
        public string prddenominacion { get; set; }
        public int catid { get; set; }
        public int proid { get; set; }
        public int marid { get; set; }
        public DateTime prdfecharegistro { get; set; }
        public int prdgarantia { get; set; }
        public decimal prdcosto { get; set; }
        public double prdcostoneto { get; set; }
        public decimal prdmargen { get; set; }
        public string prddescripcion { get; set; }
        public int estid { get; set; }
        public decimal prdiva { get; set; }
        public decimal prdmetros { get; set; }
        public Proveedor proveedor { get; set; }
        public Estado estado { get; set; }
        public Categoria categoria { get; set; }
        public Marca marca { get; set; }
        public double prdflete { get; set; }
        public double prdingbrutos { get; set; }

    }
}
