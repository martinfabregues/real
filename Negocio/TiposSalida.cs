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
    public class TiposSalida
    {
        public static DataTable TipoSalidaObtenerTodo()
        {
            DataTable dt = new DataTable();
            string procedureName = "sp_tiposalida_obtenertodo";
            dt = Datos.DAL.EjecutarStoreConsulta(procedureName);
            return dt;
        }

        public static List<TipoSalida> GetTodos()
        {
            List<TipoSalida> tpss = new List<TipoSalida>();
            DataTable dt = new DataTable();
            string procedureName = "sp_tiposalida_obtenertodo";
            dt = Datos.DAL.EjecutarStoreConsulta(procedureName);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    TipoSalida tps = new TipoSalida();
                    tps.tpsid = Convert.ToInt32(dr["tpsid"]);
                    tps.tpstipo = dr["tpstipo"].ToString();
                    tpss.Add(tps);
                }
            }
            return tpss;
        }


        public static DataTable TipoSalidaObtenerACliente(DateTime desde, DateTime hasta)
        {
            DataTable dt = new DataTable();
            string procedureName = "sp_entrega_obtenercantidadacliente";
            List<NpgsqlParameter> parametros = new List<NpgsqlParameter>();
            parametros.Add(Datos.DAL.crearParametro("desde", NpgsqlDbType.Date, desde));
            parametros.Add(Datos.DAL.crearParametro("hasta", NpgsqlDbType.Date, hasta));
            dt = Datos.DAL.EjecutarStoreConsultaConParametros(procedureName, parametros);
            return dt;
        }

        public static DataTable TipoSalidaObtenerInterna(DateTime desde, DateTime hasta)
        {
            DataTable dt = new DataTable();
            string procedureName = "sp_entrega_obtenercantidadinterna";
            List<NpgsqlParameter> parametros = new List<NpgsqlParameter>();
            parametros.Add(Datos.DAL.crearParametro("desde", NpgsqlDbType.Date, desde));
            parametros.Add(Datos.DAL.crearParametro("hasta", NpgsqlDbType.Date, hasta));
            dt = Datos.DAL.EjecutarStoreConsultaConParametros(procedureName, parametros);
            return dt;
        }

        public static DataTable TipoSalidaObtenerConCargo(DateTime desde, DateTime hasta)
        {
            DataTable dt = new DataTable();
            string procedureName = "sp_entrega_obtenercantidadaclienteconcargo";
            List<NpgsqlParameter> parametros = new List<NpgsqlParameter>();
            parametros.Add(Datos.DAL.crearParametro("desde", NpgsqlDbType.Date, desde));
            parametros.Add(Datos.DAL.crearParametro("hasta", NpgsqlDbType.Date, hasta));
            dt = Datos.DAL.EjecutarStoreConsultaConParametros(procedureName, parametros);
            return dt;
        }


        public static TipoSalida GetPorId(int tpsid)
        {
            TipoSalida tps = new TipoSalida();
            string procedureName = "sp_tiposalida_gettodoporid";
            DataTable dt = Datos.DAL.EjecutarStoreConParametro(procedureName, "tps_id", tpsid);
            if (dt.Rows.Count > 0)
            {
                tps.tpsid = Convert.ToInt32(dt.Rows[0]["tpsid"]);
                tps.tpstipo = dt.Rows[0]["tpstipo"].ToString();
            }
            return tps;
        }

    }
}
