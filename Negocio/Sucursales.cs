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
    public class Sucursales
    {
        public static DataTable SucursalObtenerTodo()
        {
            DataTable dtSucursal = new DataTable();
            string procedureName = "sp_sucursal_obtenertodo";
            dtSucursal = Datos.DAL.EjecutarStoreConsulta(procedureName);
            return dtSucursal;
        }

        public static List<Sucursal> GetTodos()
        {
            List<Sucursal> sucs = new List<Sucursal>();
            DataTable dt = new DataTable();
            string procedureName = "sp_sucursal_obtenertodo";
            dt = Datos.DAL.EjecutarStoreConsulta(procedureName);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Sucursal suc = new Sucursal();
                    suc.sucdireccion = dr["sucdireccion"].ToString();
                    suc.sucid = Convert.ToInt32(dr["sucid"]);
                    suc.sucnombre = dr["sucnombre"].ToString();
                    sucs.Add(suc);
                }

            }
            return sucs;
        }

        public static DataTable SucursalObtenerNombrePorId(int sucid)
        {
            DataTable dtSucursal = new DataTable();
            string procedureName = "sp_sucursal_obtenernombreporid";
            List<NpgsqlParameter> parametros = new List<NpgsqlParameter>();
            parametros.Add(Datos.DAL.crearParametro("sucid", NpgsqlDbType.Integer, sucid));
            dtSucursal = Datos.DAL.EjecutarStoreConsultaConParametros(procedureName, parametros);
            return dtSucursal;
        }

        public static DataTable SucursalObtenerCantidadEntregas(DateTime desde, DateTime hasta)
        {
            DataTable dt = new DataTable();
            string procedureName = "sp_sucursal_obtenercantidadentregasentrefechas";
            List<NpgsqlParameter> parametros = new List<NpgsqlParameter>();
            parametros.Add(Datos.DAL.crearParametro("desde", NpgsqlDbType.Date, desde));
            parametros.Add(Datos.DAL.crearParametro("hasta", NpgsqlDbType.Date, hasta));
            dt = Datos.DAL.EjecutarStoreConsultaConParametros(procedureName, parametros);
            return dt;
        }

        public static Sucursal GetPorId(int sucid)
        {
             Sucursal suc = new Sucursal();
             string procedureName = "sp_sucursal_gettodoporid";
             DataTable dt = Datos.DAL.EjecutarStoreConParametro(procedureName, "suc_id", sucid);
             if (dt.Rows.Count > 0)
             {
                 suc.sucdireccion = dt.Rows[0]["sucdireccion"].ToString();
                 suc.sucid = Convert.ToInt32(dt.Rows[0]["sucid"]);
                 suc.sucnombre = dt.Rows[0]["sucnombre"].ToString();
                 
             }
             return suc;
        }


    }
}
