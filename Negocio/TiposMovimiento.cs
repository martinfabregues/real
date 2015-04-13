using DAL;
using Datos;
using Entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Negocio
{
    public class TiposMovimiento
    {

        public static DataTable TipoMovimentosGetTodo()
        {
            DataTable dt = new DataTable();
            string procedureName = "sp_tipomovimiento_obtenertodo";
            dt = Datos.DAL.EjecutarStoreConsulta(procedureName);
            return dt;
        }

        public static List<TipoMovimiento> GetTodos()
        {
            List<TipoMovimiento> list = TipoMovimientoDAL.GetTodo();
            return list;
        }
    }
}
