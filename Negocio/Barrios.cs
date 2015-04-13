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
    public class Barrios
    {
        public static int BarrioInsertar(Barrio bar)
        {
            string procedureName = "sp_barrio_insertar";
            List<NpgsqlParameter> parametros = new List<NpgsqlParameter>();
            parametros.Add(Datos.DAL.crearParametro("barnombre", NpgsqlDbType.Text, bar.barnombre));
            parametros.Add(Datos.DAL.crearParametro("ciuid", NpgsqlDbType.Integer, bar.ciuid));
            parametros.Add(Datos.DAL.crearParametro("barcosto", NpgsqlDbType.Numeric, bar.barcosto));
            int resultado = Datos.DAL.EjecutarStoreInsert(procedureName, parametros);
            return resultado;
        }

        public static DataTable BarrioObtenerTodo()
        {
            DataTable dtBarrio = new DataTable();
            string procedureName = "sp_barrio_obtenertodo";
            dtBarrio = Datos.DAL.EjecutarStoreConsulta(procedureName);
            return dtBarrio;
        }

        public static List<Barrio> GetTodos()
        {
            List<Barrio> bars = new List<Barrio>();
            DataTable dt = new DataTable();
            string procedureName = "sp_barrio_obtenertodo";
            dt = Datos.DAL.EjecutarStoreConsulta(procedureName);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Barrio bar = new Barrio();
                    bar.barcosto = Convert.ToDecimal(dr["barcosto"]);
                    bar.barid = Convert.ToInt32(dr["barid"]);
                    bar.barnombre = dr["barnombre"].ToString();
                    bar.ciuid = Convert.ToInt32(dr["ciuid"]);
                    bars.Add(bar);
                }
            }
            return bars;
        }

        public static DataTable BarrioObtenerCostoPorId(int barid)
        {
            string procedureName = "sp_barrio_obtenercostoporid";
            List<NpgsqlParameter> parametros = new List<NpgsqlParameter>();
            parametros.Add(Datos.DAL.crearParametro("barid", NpgsqlDbType.Integer, barid));
            DataTable dt = Datos.DAL.EjecutarStoreConsultaConParametros(procedureName, parametros);
            return dt;
        }

        public static DataTable BarrioObtenerEntregasPorBarrio(DateTime desde, DateTime hasta)
        {         
            string procedureName = "sp_barriocantidad_obtenertodoentrefechas";
            List<NpgsqlParameter> parametros = new List<NpgsqlParameter>();
            parametros.Add(Datos.DAL.crearParametro("desde", NpgsqlDbType.Date, desde));
            parametros.Add(Datos.DAL.crearParametro("hasta", NpgsqlDbType.Date, hasta));
            DataTable dt = Datos.DAL.EjecutarStoreConsultaConParametros(procedureName, parametros);
            return dt;
        }

        public static DataTable BarrioObtenerNombrePorId(int barid)
        {
            string procedureName = "sp_barrio_obtenernombreporid";
            List<NpgsqlParameter> parametros = new List<NpgsqlParameter>();
            parametros.Add(Datos.DAL.crearParametro("barid", NpgsqlDbType.Integer, barid));
            DataTable dt = Datos.DAL.EjecutarStoreConsultaConParametros(procedureName, parametros);
            return dt;
        }

        public static DataTable BarrioObtenerLikeNombre(string barnombre)
        {
            string procedureName = "sp_barrio_obtenerlikenombre";
            List<NpgsqlParameter> parametros = new List<NpgsqlParameter>();
            parametros.Add(Datos.DAL.crearParametro("barnombre", NpgsqlDbType.Text, barnombre));
            DataTable dt = Datos.DAL.EjecutarStoreConsultaConParametros(procedureName, parametros);
            return dt;
        }

        public static List<Barrio> GetLikeNombre(string barnombre)
        {
            List<Barrio> bars = new List<Barrio>();
            string procedureName = "sp_barrio_obtenerlikenombre";
            DataTable dt = Datos.DAL.EjecutarStoreConParametro(procedureName, "barnombre", barnombre);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Barrio bar = new Barrio();
                    bar.barcosto = Convert.ToDecimal(dr["barcosto"]);
                    bar.barid = Convert.ToInt32(dr["barid"]);
                    bar.barnombre = dr["barnombre"].ToString();
                    bar.ciuid = Convert.ToInt32(dr["ciuid"]);
                    bars.Add(bar);

                }
            }
            return bars;
        }

        public static Barrio GetPorId(int barid)
        {
            Barrio bar = new Barrio();
            string procedureName = "sp_barrio_gettodoporid";
            DataTable dt = Datos.DAL.EjecutarStoreConParametro(procedureName, "bar_id", barid);
            if (dt.Rows.Count > 0)
            {
                bar.barcosto = Convert.ToDecimal(dt.Rows[0]["barcosto"]);
                bar.barid = Convert.ToInt32(dt.Rows[0]["barid"]);
                bar.barnombre = dt.Rows[0]["barnombre"].ToString();
                bar.ciuid = Convert.ToInt32(dt.Rows[0]["ciuid"]);
            }
            return bar;
        }

    }
}
