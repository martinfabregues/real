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
    public class TiposEntrega
    {
        public static DataTable GetTipoEntregaDatos()
        {
            string procedureName = "sp_tipoentrega_obtenertodo";
            DataTable dt = Datos.DAL.EjecutarStoreConsulta(procedureName);
            return dt;
        }

        public static List<TipoEntrega> GetTodos()
        {
            List<TipoEntrega> tpes = new List<TipoEntrega>();
            string procedureName = "sp_tipoentrega_obtenertodo";
            DataTable dt = Datos.DAL.EjecutarStoreConsulta(procedureName);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    TipoEntrega tpe = new TipoEntrega();
                    tpe.tpeid = Convert.ToInt32(dr["tpeid"]);
                    tpe.tpetipo = dr["tpetipo"].ToString();
                    tpes.Add(tpe);
                }

            }
            return tpes;
        }

        public static TipoEntrega GetPorId(int tpeid)
        {
            TipoEntrega tpe = new TipoEntrega();
            string procedureName = "sp_tipoentrega_gettodoporid";
            DataTable dt = Datos.DAL.EjecutarStoreConParametro(procedureName, "tpe_id", tpeid);
            if (dt.Rows.Count > 0)
            {
                tpe.tpeid = Convert.ToInt32(dt.Rows[0]["tpeid"]);
                tpe.tpetipo = dt.Rows[0]["tpetipo"].ToString();
            }
            return tpe;
        }


    }
}
