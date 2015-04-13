using DAL;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Negocio
{
    public class Vendedores
    {

        public static Vendedor Crear(Vendedor vendedor)
        {
            vendedor = VendedorDAL.Crear(vendedor);
            return vendedor;
        }

        public static List<Vendedor> GetTodos()
        {
            List<Vendedor> list = VendedorDAL.GetTodo();
            return list;
        }

        public static Vendedor GetPorId(int vendedor_id)
        {
            Vendedor vendedor = VendedorDAL.GetPorId(vendedor_id);
            return vendedor;
        }

        public static Boolean Actualizar(Vendedor vendedor)
        {
            bool resultado = VendedorDAL.Actualizar(vendedor);
            return resultado;
        }
    }
}
