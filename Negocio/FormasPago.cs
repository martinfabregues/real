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
    public class FormasPago
    {

        public static DataTable FormaPagoGetTodo()
        {
            DataTable dt = new DataTable();
            string procedureName = "sp_formapago_obtenertodo";
            dt = Datos.DAL.EjecutarStoreConsulta(procedureName);
            return dt;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<FormaPago> GetTodos()
        {
            List<FormaPago> list = FormaPagoDAL.GetTodo();
            return list;
        }
    }
}
