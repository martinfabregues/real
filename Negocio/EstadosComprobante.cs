using DAL;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Negocio
{
    public class EstadosComprobante
    {

        public static List<EstadoComprobante> GetTodo()
        {
            List<EstadoComprobante> list = EstadoComprobanteDAL.GetTodo();
            return list;
        }
    }
}
