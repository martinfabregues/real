using DAL;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Negocio
{
    public class TiposComprobante
    {

        public static List<TipoComprobante> GetTodos()
        {
            List<TipoComprobante> list = TipoComprobanteDAL.GetTodo();
            return list;
        }
    }
}
