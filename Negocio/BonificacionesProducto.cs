using DAL;
using Datos;
using Entidad;
using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;

namespace Negocio
{
    public class BonificacionesProducto
    {

        public static DataTable GetProductosPorIdBonificacion(int bonid)
        {
            string procedureName = "sp_bonificacionproducto_obtenertodo";
            DataTable dt = Datos.DAL.EjecutarStoreConParametro(procedureName, "bon_id", bonid);
            return dt;
        }

        public static DataTable GetProductosPorIdBonificacionLikeProducto(int bonid, string prddenominacion)
        {
            string procedureName = "sp_bonificacionproducto_obtenerlikeproducto";
            List<NpgsqlParameter> parametros = new List<NpgsqlParameter>();
            parametros.Add(Datos.DAL.crearParametro("bon_id", NpgsqlDbType.Integer, bonid));
            parametros.Add(Datos.DAL.crearParametro("prd_denominacion", NpgsqlDbType.Text, prddenominacion));
            DataTable dt = Datos.DAL.EjecutarStoreConsultaConParametros(procedureName, parametros);
            return dt;
        }


        public static int BonificacionProductoInsertar(BonificacionProducto bop)
        {
            string procedureName = "sp_bonificacionproducto_insertar";
            List<NpgsqlParameter> parametros = new List<NpgsqlParameter>();
            //parametros.Add(Datos.DAL.crearParametro("bon_id", NpgsqlDbType.Integer, bop.bonid));
            //parametros.Add(Datos.DAL.crearParametro("prd_id", NpgsqlDbType.Integer, bop.prdid));
            int resultado = Datos.DAL.EjecutarStoreInsert(procedureName, parametros);
            return resultado;
        }

        public static int BonificacionProductoEliminar(BonificacionProducto bop)
        {
            string procedureName = "sp_bonificacionproducto_eliminar";
            List<NpgsqlParameter> parametros = new List<NpgsqlParameter>();
            parametros.Add(Datos.DAL.crearParametro("bop_id", NpgsqlDbType.Integer, bop.bopid));
            int resultado = Datos.DAL.EjecutarStoreInsert(procedureName, parametros);
            return resultado;
        }

        public static DataTable GetBonificacionesPorProducto(int prdid, DateTime fecha, NpgsqlConnection db)
        {
            string procedureName = "sp_producto_obtenerbonificacionestodas";
            List<NpgsqlParameter> parametros = new List<NpgsqlParameter>();
            parametros.Add(Datos.DAL.crearParametro("prd_id", NpgsqlDbType.Integer, prdid));
            parametros.Add(Datos.DAL.crearParametro("fecha", NpgsqlDbType.Date, fecha));
            DataTable dt = Datos.DAL.EjecutarStoreConsultaConParametrosTransaccion(procedureName, parametros, db);
            return dt;
        }

        public static DataTable GetBonificacionesPorProducto(int prdid, DateTime fecha)
        {
            string procedureName = "sp_producto_obtenerbonificacionestodas";
            List<NpgsqlParameter> parametros = new List<NpgsqlParameter>();
            parametros.Add(Datos.DAL.crearParametro("prd_id", NpgsqlDbType.Integer, prdid));
            parametros.Add(Datos.DAL.crearParametro("fecha", NpgsqlDbType.Date, fecha));
            DataTable dt = Datos.DAL.EjecutarStoreConsultaConParametros(procedureName, parametros);
            return dt;
        }






        /// <summary>
        /// 
        /// </summary>
        /// <param name="prdid"></param>
        /// <returns></returns>
        public static List<BonificacionProducto> GetPorProducto(int prdid)
        {
            List<BonificacionProducto> list = new List<BonificacionProducto>();
            try
            {
                list = DAL.BonificacionProductoDAL.GetPorProducto(prdid);
            }
            catch (Exception)
            {
                throw;
            }
          
            return list;
        }

        public static BonificacionProducto Insertar(BonificacionProducto bonificacionproducto)
        {
            bonificacionproducto = BonificacionProductoDAL.Insertar(bonificacionproducto);
            return bonificacionproducto;
        }


    }
}
