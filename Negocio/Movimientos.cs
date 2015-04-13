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
    public class Movimientos
    {

        public static DataTable MovimentosGetTodo()
        {
            DataTable dt = new DataTable();
            string procedureName = "sp_movimiento_obtenertodo";
            dt = Datos.DAL.EjecutarStoreConsulta(procedureName);
            return dt;
        }


        public static List<Movimiento> GetTodos()
        {
            List<Movimiento> list = MovimientoDAL.GetTodo();
            return list;
        }

    }
}
