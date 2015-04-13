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
    public class TiposIva
    {
        public static DataTable TipoIvaObtenerTodo()
        {

            DataTable dtTipoIva = new DataTable();

            string procedureName = "sp_tipoiva_obtenertodo";
            dtTipoIva = Datos.DAL.EjecutarStoreConsulta(procedureName);

            return dtTipoIva;

        }

        public static TipoIva GetPorId(int tpiid)
        {
            TipoIva tpi = new TipoIva();
            string procedureName = "sp_tipoiva_gettodoporid";
            DataTable dt = Datos.DAL.EjecutarStoreConParametro(procedureName, "tpi_id", tpiid);
            if (dt.Rows.Count > 0)
            {
                tpi.tpiId = Convert.ToInt32(dt.Rows[0]["tpiid"]);
                tpi.tpitipo = dt.Rows[0]["tpitipo"].ToString();
            }

            return tpi;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<TipoIva> GetTodos()
        {
            List<TipoIva> list = new List<TipoIva>();
            try
            {
                list = TipoIvaDAL.GetTodo();
            }
            catch (Exception)
            {

            }
            return list;
        }

    }
}
