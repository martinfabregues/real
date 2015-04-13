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
    public class EstadosEntrega
    {

        public static DataTable EstadoEntregaObtenerTodo()
        {
            DataTable dt = new DataTable();
            string procedureName = "sp_estadoentrega_obtenertodo";
            dt = Datos.DAL.EjecutarStoreConsulta(procedureName);
            return dt;
        }

        public static List<EstadoEntrega> GetTodos()
        {
            List<EstadoEntrega> ests = new List<EstadoEntrega>();
            DataTable dt = new DataTable();
            string procedureName = "sp_estadoentrega_obtenertodo";
            dt = Datos.DAL.EjecutarStoreConsulta(procedureName);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    EstadoEntrega ese = new EstadoEntrega();
                    ese.eseestado = dr["eseestado"].ToString();
                    ese.eseid = Convert.ToInt32(dr["eseid"]);
                    ests.Add(ese);
                }

            }
            return ests;
        }

    }
}
