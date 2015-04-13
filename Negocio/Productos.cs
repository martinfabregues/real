using DAL;
using DAL.Interfases;
using DAL.Repositories;
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
using System.Threading.Tasks;

namespace Negocio
{
    public class Productos
    {

        public static int ProductoInsertar(Producto prd)
        {
            try
            {
                string procedureName = "sp_producto_insertar";
                List<NpgsqlParameter> parametros = new List<NpgsqlParameter>();
                parametros.Add(Datos.DAL.crearParametro("prddenominacion", NpgsqlDbType.Text, prd.prddenominacion));
                parametros.Add(Datos.DAL.crearParametro("catid", NpgsqlDbType.Integer, prd.catid));
                parametros.Add(Datos.DAL.crearParametro("proid", NpgsqlDbType.Integer, prd.proid));
                parametros.Add(Datos.DAL.crearParametro("marid", NpgsqlDbType.Integer, prd.marid));
                parametros.Add(Datos.DAL.crearParametro("prdfecharegistro", NpgsqlDbType.Date, prd.prdfecharegistro));
                parametros.Add(Datos.DAL.crearParametro("prdgarantia", NpgsqlDbType.Integer, prd.prdgarantia));
                parametros.Add(Datos.DAL.crearParametro("prdcosto", NpgsqlDbType.Numeric, prd.prdcosto));
                parametros.Add(Datos.DAL.crearParametro("prdmargen", NpgsqlDbType.Numeric, prd.prdmargen));
                parametros.Add(Datos.DAL.crearParametro("prddescripcion", NpgsqlDbType.Text, prd.prddescripcion));
                parametros.Add(Datos.DAL.crearParametro("estid", NpgsqlDbType.Integer, prd.estid));
                parametros.Add(Datos.DAL.crearParametro("prdiva", NpgsqlDbType.Numeric, prd.prdiva));
                parametros.Add(Datos.DAL.crearParametro("prd_metros", NpgsqlDbType.Numeric, prd.prdmetros));
                int resultado = Datos.DAL.EjecutarStoreInsert(procedureName, parametros);
                return resultado;

            }
            catch (NpgsqlException Npgsqlex)
            {
                throw Npgsqlex;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }


        public static int ProductoActualizar(Producto prd)
        {
            try
            {
                string procedureName = "sp_producto_actualizar";
                List<NpgsqlParameter> parametros = new List<NpgsqlParameter>();
                parametros.Add(Datos.DAL.crearParametro("prd_id", NpgsqlDbType.Integer, prd.prdid));
                parametros.Add(Datos.DAL.crearParametro("prddenominacion", NpgsqlDbType.Text, prd.prddenominacion));
                parametros.Add(Datos.DAL.crearParametro("catid", NpgsqlDbType.Integer, prd.catid));
                parametros.Add(Datos.DAL.crearParametro("proid", NpgsqlDbType.Integer, prd.proid));
                parametros.Add(Datos.DAL.crearParametro("marid", NpgsqlDbType.Integer, prd.marid));
                parametros.Add(Datos.DAL.crearParametro("prdfecharegistro", NpgsqlDbType.Date, prd.prdfecharegistro));
                parametros.Add(Datos.DAL.crearParametro("prdgarantia", NpgsqlDbType.Integer, prd.prdgarantia));
                parametros.Add(Datos.DAL.crearParametro("prdcosto", NpgsqlDbType.Numeric, prd.prdcosto));
                parametros.Add(Datos.DAL.crearParametro("prdmargen", NpgsqlDbType.Numeric, prd.prdmargen));
                parametros.Add(Datos.DAL.crearParametro("prddescripcion", NpgsqlDbType.Text, prd.prddescripcion));
                parametros.Add(Datos.DAL.crearParametro("estid", NpgsqlDbType.Integer, prd.estid));
                parametros.Add(Datos.DAL.crearParametro("prdiva", NpgsqlDbType.Numeric, prd.prdiva));
                parametros.Add(Datos.DAL.crearParametro("prdmetros", NpgsqlDbType.Numeric, prd.prdmetros));
                int resultado = Datos.DAL.EjecutarStoreInsert(procedureName, parametros);
                return resultado;

            }
            catch (NpgsqlException Npgsqlex)
            {
                throw Npgsqlex;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public static DataTable GetProductosTodos()
        {
            string procedureName = "sp_producto_obtenertodos";
            DataTable dt = Datos.DAL.EjecutarStoreConsulta(procedureName);
            return dt;
        }


        public static List<Producto> GetTodo()
        {
            List<Producto> prds = new List<Producto>();
            prds = ProductoDAL.GetTodos();
            //string procedureName = "sp_producto_gettodo";
            //DataTable dt = Datos.DAL.EjecutarStoreConsulta(procedureName);
            //if (dt.Rows.Count > 0)
            //{
            //    foreach (DataRow dr in dt.Rows)
            //    {
            //        Producto prd = new Producto();
            //        prd.prdid = Convert.ToInt32(dr["prdid"]);
            //        prd.prddenominacion = dr["prddenominacion"].ToString();
            //        prd.catid = Convert.ToInt32(dr["catid"]);
            //        prd.proid = Convert.ToInt32(dr["proid"]);
            //        prd.marid = Convert.ToInt32(dr["marid"]);
            //        prd.prdfecharegistro = Convert.ToDateTime(dr["prdfecharegistro"]);
            //        prd.prdgarantia = Convert.ToInt32(dr["prdgarantia"]);
            //        prd.prdcosto = Convert.ToDecimal(dr["prdcosto"]);
            //        prd.prdmargen = Convert.ToDecimal(dr["prdmargen"]);
            //        prd.prddescripcion = dr["prddescripcion"].ToString();
            //        prd.estid = Convert.ToInt32(dr["estid"]);
            //        prd.prdcodigo = dr["prdcodigo"].ToString();
            //        prd.prdiva = Convert.ToDecimal(dr["prdiva"]);
            //        prds.Add(prd);
            //    }
            //}
            return prds;
        }


        public static DataTable GetProductoNombrePorId(int prdid)
        {
            string procedureName = "sp_producto_obtenernombreporid";
            List<NpgsqlParameter> parametros = new List<NpgsqlParameter>();
            parametros.Add(Datos.DAL.crearParametro("id", NpgsqlDbType.Integer, prdid));
            DataTable dt = Datos.DAL.EjecutarStoreConsultaConParametros(procedureName, parametros);
            return dt;
        }

        public static DataTable GetProductoObtenerPorId(int prdid)
        {
            string procedureName = "sp_producto_obtenerporid";
            List<NpgsqlParameter> parametros = new List<NpgsqlParameter>();
            parametros.Add(Datos.DAL.crearParametro("id", NpgsqlDbType.Integer, prdid));
            DataTable dt = Datos.DAL.EjecutarStoreConsultaConParametros(procedureName, parametros);
            return dt;
        }


        
        public static DataTable GetProductoLikeNombre(string prddenominacion)
        {
            string procedureName = "sp_producto_obtenerlikenombre";
            List<NpgsqlParameter> parametros = new List<NpgsqlParameter>();
            parametros.Add(Datos.DAL.crearParametro("prddenom", NpgsqlDbType.Text, prddenominacion));
            DataTable dt = Datos.DAL.EjecutarStoreConsultaConParametros(procedureName, parametros);
            return dt;
        }

        public static List<Producto> GetLikeNombre(string prddenominacion)
        {
            List<Producto> prds = new List<Producto>();
            string procedureName = "sp_producto_getlikenombre";
            List<NpgsqlParameter> parametros = new List<NpgsqlParameter>();
            parametros.Add(Datos.DAL.crearParametro("prddenom", NpgsqlDbType.Text, prddenominacion));
            DataTable dt = Datos.DAL.EjecutarStoreConsultaConParametros(procedureName, parametros);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Producto prd = new Producto();
                    prd.prdid = Convert.ToInt32(dr["prdid"]);
                    prd.prdcodigo = dr["prdcodigo"].ToString();
                    prd.prddenominacion = dr["prddenominacion"].ToString();
                    prd.proid = Convert.ToInt32(dr["proid"]);
                    prd.catid = Convert.ToInt32(dr["catid"]);
                    prd.marid = Convert.ToInt32(dr["marid"]);
                    prds.Add(prd);
                }

            }
            return prds;
        }



        public static DataTable GetProductoPorIdProveedor(int proid)
        {
            string procedureName = "sp_producto_obtenertodosporidproveedor";
            List<NpgsqlParameter> parametros = new List<NpgsqlParameter>();
            parametros.Add(Datos.DAL.crearParametro("pro_id", NpgsqlDbType.Integer, proid));
            DataTable dt = Datos.DAL.EjecutarStoreConsultaConParametros(procedureName, parametros);
            return dt;
        }
        

        public static DataTable GetProductoPorNombreProducto(string prddenominacion)
        {
            string procedureName = "sp_producto_obtenertodospornombre";
            List<NpgsqlParameter> parametros = new List<NpgsqlParameter>();
            parametros.Add(Datos.DAL.crearParametro("prd_denominacion", NpgsqlDbType.Text, prddenominacion));
            DataTable dt = Datos.DAL.EjecutarStoreConsultaConParametros(procedureName, parametros);
            return dt;
        }

        public static DataTable GetProductoDatosPorIdProducto(int prdid)
        {
            string procedureName = "sp_producto_obtenerddatosporid";
            List<NpgsqlParameter> parametros = new List<NpgsqlParameter>();
            parametros.Add(Datos.DAL.crearParametro("prd_id", NpgsqlDbType.Integer, prdid));
            DataTable dt = Datos.DAL.EjecutarStoreConsultaConParametros(procedureName, parametros);
            return dt;
        }


        public static DataTable GetProductoDatosPorCodigo(string prdcodigo)
        {
            //Producto prd = new Producto();
            string procedureName = "sp_producto_obtenerddatosporcodigo";
            List<NpgsqlParameter> parametros = new List<NpgsqlParameter>();
            parametros.Add(Datos.DAL.crearParametro("prd_codigo", NpgsqlDbType.Text, prdcodigo));
            DataTable dt = Datos.DAL.EjecutarStoreConsultaConParametros(procedureName, parametros);
            //if (dt.Rows.Count > 0)
            //{
            //    prd.catid = Convert.ToInt32(dt.Rows[0]["catid"]);
            //    prd.estid = Convert.ToInt32(dt.Rows[0]["estid"]);
            //    prd.marid = Convert.ToInt32(dt.Rows[0]["marid"]);
            //    prd.prdbonifcinco = Convert.ToDecimal(dt.Rows[0]["prdbonifcinco"]);
            //    prd.prdbonifcuatro = Convert.ToDecimal(dt.Rows[0]["prdbonifcuatro"]);
            //    prd.prdbonifdos = Convert.ToDecimal(dt.Rows[0]["prdbonifdos"]);
            //    prd.prdboniftres = Convert.ToDecimal(dt.Rows[0]["prdboniftres"]);
            //    prd.prdbonifuno = Convert.ToDecimal(dt.Rows[0]["prdbonifuno"]);
            //    prd.prdcodigo = dt.Rows[0]["prdcodigo"].ToString();
            //    prd.prdcosto = Convert.ToDecimal(dt.Rows[0]["prdcosto"]);
            //    prd.prddenominacion = dt.Rows[0]["prddenominacion"].ToString();
            //    prd.prddescripcion = dt.Rows[0]["prddescripcion"].ToString();
            //    prd.prdfecharegistro = Convert.ToDateTime(dt.Rows[0]["prdfecharegistro"]);
            //    prd.prdgarantia = Convert.ToInt32(dt.Rows[0]["prdgarantia"]);
            //    prd.prdid = Convert.ToInt32(dt.Rows[0]["prdid"]);
            //    prd.prdimportedesc = Convert.ToDecimal(dt.Rows[0]["prdimportedesc"]);
            //    prd.prdiva = Convert.ToDecimal(dt.Rows[0]["prdiva"]);
            //    prd.prdmargen = Convert.ToDecimal(dt.Rows[0]["prdmargen"]);
            //    prd.prdmetros = Convert.ToDecimal(dt.Rows[0]["prdmetros"]);
            //    prd.proid = Convert.ToInt32(dt.Rows[0]["proid"]);
                
            //}
            return dt;
        }

        public static DataTable GetProductoMetrosPorId(int prdid)
        {
            string procedureName = "sp_producto_obtenerdmetrosporid";
            List<NpgsqlParameter> parametros = new List<NpgsqlParameter>();
            parametros.Add(Datos.DAL.crearParametro("prd_id", NpgsqlDbType.Integer, prdid));
            DataTable dt = Datos.DAL.EjecutarStoreConsultaConParametros(procedureName, parametros);
            return dt;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<Producto> GetTodosConsulta()
        {
            try
            {
                List<Producto> list = DAL.ProductoDAL.GetTodosConsulta();
                return list;
            }
            catch (Exception)
            {
                throw;
            }
           
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        public static List<Producto> GetFiltro(ProductoCriteria filtro)
        {
            List<Producto> list = new List<Producto>();
            try
            {
                list = DAL.ProductoDAL.GetFiltro(filtro);
                
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
        /// <param name="producto"></param>
        /// <returns></returns>
        public static Producto Create(Producto producto, ListaPrecioProducto listaproducto)
        {
            try
            {
                producto = ProductoDAL.Create(producto, listaproducto);
            }
            catch (Exception)
            {
                throw;
            }
            return producto;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="producto"></param>
        /// <returns></returns>
        public static Boolean Update(Producto producto, ListaPrecioProducto listaproducto)
        {
            bool resultado;
            try
            {
                resultado = ProductoDAL.Update(producto, listaproducto);
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
        /// <param name="proid"></param>
        /// <returns></returns>
        public static Producto GetPorId(int proid)
        {
            Producto producto = new Producto();
            try
            {
                producto = ProductoDAL.GetPorId(proid);
            }
            catch (Exception)
            {
                throw;
            }
            return producto;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="prdcodigo"></param>
        /// <returns></returns>
        public static Producto GetPorCodigo(string prdcodigo)
        {
            Producto producto = new Producto();
            try
            {
                producto = ProductoDAL.GetPorCodigo(prdcodigo);
            }
            catch (Exception)
            {
                throw;
            }
            return producto;
        }


        public static IList<Producto> FindAll()
        {
            IArticuloRepository _articuloRepository = new ArticuloRepository();
            return _articuloRepository.FindAll();
        }

    }



}
