using DAL;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Negocio
{
    public class Ventas
    {

        public static List<Venta> GetTodo()
        {
            List<Venta> list = VentaDAL.GetTodo();
            return list;
        }

    }
}
