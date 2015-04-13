using DAL;
using Datos;
using Entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Actividades
    {
        public static DataTable ActividadObtenerTodo()
        {

            DataTable dtActividad = new DataTable();

            string procedureName = "sp_actividad_obtenertodo";
            dtActividad = Datos.DAL.EjecutarStoreConsulta(procedureName);

            return dtActividad;

        }


        public static Actividad GetPorId(int actid)
        {
            Actividad act = new Actividad();
            string procedureName = "sp_actividad_gettodoporid";
            DataTable dt = Datos.DAL.EjecutarStoreConParametro(procedureName, "act_id", actid);
            if (dt.Rows.Count > 0)
            {
                act.actid = Convert.ToInt32(dt.Rows[0]["actid"]);
                act.actnombre = dt.Rows[0]["actnombre"].ToString();
            }

            return act;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<Actividad> GetTodo()
        {
            List<Actividad> list = new List<Actividad>();
            try
            {
                list = ActividadDAL.GetTodo();
            }
            catch (Exception)
            {
                throw;
            }
            return list;
        }


    }
}
