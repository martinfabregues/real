using DAL;
using Datos;
using Entidad;
using Entidad.Criteria;
using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Negocio
{
    public class Bonificaciones
    {

        public static int BonificacionInsertar(Bonificacion bon)
        {
            string procedureName = "sp_bonificacion_insertar";
            List<NpgsqlParameter> parametros = new List<NpgsqlParameter>();
            parametros.Add(Datos.DAL.crearParametro("pro_id", NpgsqlDbType.Integer, bon.proid));
            parametros.Add(Datos.DAL.crearParametro("bon_nombre", NpgsqlDbType.Text, bon.bonnombre));
            parametros.Add(Datos.DAL.crearParametro("bon_fechacreacion", NpgsqlDbType.Date, bon.bonfechacreacion));
            parametros.Add(Datos.DAL.crearParametro("bon_fechainicio", NpgsqlDbType.Date, bon.bonfechainicio));
            parametros.Add(Datos.DAL.crearParametro("bon_fechafin", NpgsqlDbType.Date, bon.bonfechafin));
            parametros.Add(Datos.DAL.crearParametro("bon_descuento", NpgsqlDbType.Numeric, bon.bondescuento));
            parametros.Add(Datos.DAL.crearParametro("est_id", NpgsqlDbType.Integer, bon.estid));
            int resultado = Datos.DAL.EjecutarStoreInsert(procedureName, parametros);
            return resultado;
        }

        public static int BonificacionModificar(Bonificacion bon)
        {
            string procedureName = "sp_bonificacion_modificar";
            List<NpgsqlParameter> parametros = new List<NpgsqlParameter>();
            parametros.Add(Datos.DAL.crearParametro("bon_id", NpgsqlDbType.Integer, bon.bonid));
            parametros.Add(Datos.DAL.crearParametro("pro_id", NpgsqlDbType.Integer, bon.proid));
            parametros.Add(Datos.DAL.crearParametro("bon_nombre", NpgsqlDbType.Text, bon.bonnombre));
            parametros.Add(Datos.DAL.crearParametro("bon_fechainicio", NpgsqlDbType.Date, bon.bonfechainicio));
            parametros.Add(Datos.DAL.crearParametro("bon_fechafin", NpgsqlDbType.Date, bon.bonfechafin));
            parametros.Add(Datos.DAL.crearParametro("bon_descuento", NpgsqlDbType.Numeric, bon.bondescuento));
            parametros.Add(Datos.DAL.crearParametro("est_id", NpgsqlDbType.Integer, bon.estid));
            int resultado = Datos.DAL.EjecutarStoreInsert(procedureName, parametros);
            return resultado;
        }


        public static DataTable BonificacionObtenerTodo()
        {
            DataTable dtBarrio = new DataTable();
            string procedureName = "sp_bonificacion_obtenertodo";
            dtBarrio = Datos.DAL.EjecutarStoreConsulta(procedureName);
            return dtBarrio;
        }


        public static DataTable GetBonificacionPorIdProveedor(int proid)
        {
            string procedureName = "sp_bonificacion_obtenertodoporproveedor";
            List<NpgsqlParameter> parametros = new List<NpgsqlParameter>();
            parametros.Add(Datos.DAL.crearParametro("pro_id", NpgsqlDbType.Integer, proid));
            DataTable dt = Datos.DAL.EjecutarStoreConsultaConParametros(procedureName, parametros);
            return dt;
        }


        public static DataTable GetBonificacionDatosPorId(int bonid)
        {
           
            string procedureName = "sp_bonificacion_obtenerdatosporid";
            List<NpgsqlParameter> parametros = new List<NpgsqlParameter>();
            parametros.Add(Datos.DAL.crearParametro("bon_id", NpgsqlDbType.Integer, bonid));
            DataTable dt = Datos.DAL.EjecutarStoreConsultaConParametros(procedureName, parametros);
            return dt;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="bonificacion"></param>
        /// <returns></returns>
        public static Bonificacion Create(Bonificacion bonificacion)
        {
            try
            {
                bonificacion = BonificacionDAL.Create(bonificacion);
            }
            catch (Exception)
            {
                throw;
            }
            return bonificacion;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="bonificacion"></param>
        /// <returns></returns>
        public static Boolean Update(Bonificacion bonificacion)
        {
            bool resultado;
            try
            {
                resultado = BonificacionDAL.Update(bonificacion);
            }
            catch (Exception)
            {
                throw;
            }

            return resultado;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<Bonificacion> GetTodoConsulta()
        {
            List<Bonificacion> list = new List<Bonificacion>();
            try
            {
                list = BonificacionDAL.GetTodosConsulta();
            }
            catch (Exception)
            {
                throw;
            }
            return list;
        }


        public static List<Bonificacion> GetFiltro(BonificacionCriteria filtro)
        {
            List<Bonificacion> list = new List<Bonificacion>();
            try
            {
                list = BonificacionDAL.GetFiltro(filtro);
            }
            catch (Exception)
            {
                throw;
            }
            return list;
        }

    }
}
