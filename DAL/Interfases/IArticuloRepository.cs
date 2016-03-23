using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Interfases
{
    public interface IArticuloRepository : IRepository<Producto>
    {
        Producto FindByCodigo(string codigo);
    }
}
