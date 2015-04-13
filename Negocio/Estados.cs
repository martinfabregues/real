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
    public class Estados
    {

        public static DataTable EstadosObtenerTodo()
        {
            DataTable dt = new DataTable();
            string procedureName = "sp_estado_obtenertodo";
            dt = Datos.DAL.EjecutarStoreConsulta(procedureName);
            return dt;
        }

        public static Estado ObtenerPorId(int estid)
        {
            Estado est = new Estado();
            string procedureName = "sp_estado_gettodoporid";
            DataTable dt = Datos.DAL.EjecutarStoreConParametro(procedureName, "est_id", estid);
            if (dt.Rows.Count > 0)
            {
                est.estid = Convert.ToInt32(dt.Rows[0]["estid"]);
                est.estestado = dt.Rows[0]["estestado"].ToString();
 
            }
            return est;
        }


        public static List<Estado> GetTodos()
        {
            List<Estado> list = new List<Estado>();
            try
            {
                list = DAL.EstadoDAL.GetTodo();
            }
            catch (Exception)
            {
                throw;
            }
            return list;
        }


        public static Estado GetPorId(int estid)
        {
            Estado estado = new Estado();
            try
            {
                estado = DAL.EstadoDAL.GetPorId(estid);
            }
            catch (Exception)
            {
                throw;
            }
            return estado;
        }

    }
}
