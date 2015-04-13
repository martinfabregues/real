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
    public class Marcas
    {

        public static int MarcaInsertar(Marca mar)
        {

            string procedureName = "sp_marca_insertar";

            List<NpgsqlParameter> parametros = new List<NpgsqlParameter>();
            parametros.Add(Datos.DAL.crearParametro("proid", NpgsqlDbType.Integer, mar.proid));
            parametros.Add(Datos.DAL.crearParametro("mardenominacion", NpgsqlDbType.Text, mar.mardenominacion));
            int resultado = Datos.DAL.EjecutarStoreInsert(procedureName, parametros);
            return resultado;

        }

        public static List<Marca> GetTodas()
        {
            List<Marca> mars = new List<Marca>();
            string procedureName = "sp_marca_obtenertodo";
            DataTable dt = new DataTable();
            dt = Datos.DAL.EjecutarStoreConsulta(procedureName);
            if(dt.Rows.Count >  0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Marca mar = new Marca();
                    mar.mardenominacion = dr["mardenominacion"].ToString();
                    mar.marid = Convert.ToInt32(dr["marid"]);
                    mar.proid = Convert.ToInt32(dr["proid"]);
                    mars.Add(mar);
                }
            }

            return mars;
        }

        public static DataTable GetMarcaPorIdProveedor(int proid)
        {
            string procedureName = "sp_marca_obtenerporidproveedor";
            List<NpgsqlParameter> parametros = new List<NpgsqlParameter>();
            parametros.Add(Datos.DAL.crearParametro("id", NpgsqlDbType.Integer, proid));
            DataTable dt = Datos.DAL.EjecutarStoreConsultaConParametros(procedureName, parametros);
            return dt;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<Marca> GetTodos()
        {
            List<Marca> list = new List<Marca>();
            try
            {
                list = DAL.MarcaDAL.GetTodo();
            }
            catch (Exception)
            {
                throw;
            }
            return list;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="proid"></param>
        /// <returns></returns>
        public static List<Marca> GetPorIdProveedor(int proid)
        {
            List<Marca> list = new List<Marca>();
            try
            {
                list = DAL.MarcaDAL.GetPorIdProveedor(proid);
            }
            catch (Exception)
            {
                throw;
            }
            return list;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="marid"></param>
        /// <returns></returns>
        public static Marca GetPorId(int marid)
        {
            Marca marca = new Marca();
            try
            {
                marca = DAL.MarcaDAL.GetPorId(marid);
            }
            catch (Exception)
            {
                throw;
            }
            return marca;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="marca"></param>
        /// <returns></returns>
        public static Marca Create(Marca marca)
        {
            try
            {
                marca = MarcaDAL.Create(marca);
            }
            catch (Exception)
            {
                throw;
            }

            return marca;
        }
    }
}
