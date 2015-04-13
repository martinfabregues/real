using DAL;
using Datos;
using Entidad;
using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Ciudades
    {
        public static int CiudadInsertar(Ciudad ciu)
        {
            string procedureName = "sp_ciudad_insertar";
            List<NpgsqlParameter> parametros = new List<NpgsqlParameter>();
            parametros.Add(Datos.DAL.crearParametro("ciunombre", NpgsqlDbType.Text, ciu.ciunombre));
            parametros.Add(Datos.DAL.crearParametro("prvid", NpgsqlDbType.Integer, ciu.prvid));
            int resultado = Datos.DAL.EjecutarStoreInsert(procedureName, parametros);
            return resultado;
        }

        public static DataTable CiudadObtenerTodo()
        {
            DataTable dtCiudad = new DataTable();
            string procedureName = "sp_ciudad_obtenertodo";
            dtCiudad = Datos.DAL.EjecutarStoreConsulta(procedureName);
            return dtCiudad;
        }


        public static Ciudad GetPorId(int ciuid)
        {
            Ciudad ciu = new Ciudad();
            string procedureName = "sp_ciudad_gettodoporid";
            DataTable dt = Datos.DAL.EjecutarStoreConParametro(procedureName, "ciu_id", ciuid);
            if (dt.Rows.Count > 0)
            {
                ciu.ciuid = Convert.ToInt32(dt.Rows[0]["ciuid"]);
                ciu.ciunombre = dt.Rows[0]["ciunombre"].ToString();
                ciu.prvid = Convert.ToInt32(dt.Rows[0]["prvid"]);
                
            }

            return ciu;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<Ciudad> GetTodo()
        {
            List<Ciudad> list = new List<Ciudad>();
            try
            {
                list = CiudadDAL.GetTodo();
            }
            catch (Exception)
            {
                throw;
            }
            return list;
        }

    }
}
