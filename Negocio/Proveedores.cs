using Entidad;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NpgsqlTypes;
using Datos;
using System.Data;
using DAL;
using Entidad.Criteria;
using DAL.Interfases;
using DAL.Repositories;
namespace Negocio
{
    public class Proveedores
    {

        public static int ProveedorInsertar(Proveedor pro)
        {

            string procedureName = "sp_proveedor_insertar";
            
            List<NpgsqlParameter> parametros = new List<NpgsqlParameter>();
            parametros.Add(Datos.DAL.crearParametro("p_rs", NpgsqlDbType.Text, pro.prorazonsocial));
            parametros.Add(Datos.DAL.crearParametro("p_n", NpgsqlDbType.Text, pro.pronombre));
            parametros.Add(Datos.DAL.crearParametro("p_d", NpgsqlDbType.Text, pro.prodireccion));
            parametros.Add(Datos.DAL.crearParametro("p_b", NpgsqlDbType.Text, pro.probarrio));
            parametros.Add(Datos.DAL.crearParametro("p_cp", NpgsqlDbType.Text, pro.procodpostal));
            parametros.Add(Datos.DAL.crearParametro("l_locid", NpgsqlDbType.Integer, pro.locid));
            parametros.Add(Datos.DAL.crearParametro("p_tel", NpgsqlDbType.Text, pro.protelefono));
            parametros.Add(Datos.DAL.crearParametro("t_tpi", NpgsqlDbType.Integer, pro.tpiid));
            parametros.Add(Datos.DAL.crearParametro("p_cuit", NpgsqlDbType.Text, pro.procuit));
            parametros.Add(Datos.DAL.crearParametro("p_ingb", NpgsqlDbType.Text, pro.proingbrutos));
            parametros.Add(Datos.DAL.crearParametro("a_act", NpgsqlDbType.Integer, pro.actid));
            parametros.Add(Datos.DAL.crearParametro("p_email", NpgsqlDbType.Text, pro.proemail));
            parametros.Add(Datos.DAL.crearParametro("p_tributo", NpgsqlDbType.Numeric, pro.proingbrutostributo));
            int resultado = Datos.DAL.EjecutarStoreInsert(procedureName, parametros);
            return resultado;

        }

        public static int ProveedorModificar(Proveedor pro)
        {

            string procedureName = "sp_proveedor_actualizar";

            List<NpgsqlParameter> parametros = new List<NpgsqlParameter>();
            parametros.Add(Datos.DAL.crearParametro("p_rs", NpgsqlDbType.Text, pro.prorazonsocial));
            parametros.Add(Datos.DAL.crearParametro("p_n", NpgsqlDbType.Text, pro.pronombre));
            parametros.Add(Datos.DAL.crearParametro("p_d", NpgsqlDbType.Text, pro.prodireccion));
            parametros.Add(Datos.DAL.crearParametro("p_b", NpgsqlDbType.Text, pro.probarrio));
            parametros.Add(Datos.DAL.crearParametro("p_cp", NpgsqlDbType.Text, pro.procodpostal));
            parametros.Add(Datos.DAL.crearParametro("l_locid", NpgsqlDbType.Integer, pro.locid));
            parametros.Add(Datos.DAL.crearParametro("p_tel", NpgsqlDbType.Text, pro.protelefono));
            parametros.Add(Datos.DAL.crearParametro("t_tpi", NpgsqlDbType.Integer, pro.tpiid));
            parametros.Add(Datos.DAL.crearParametro("p_cuit", NpgsqlDbType.Text, pro.procuit));
            parametros.Add(Datos.DAL.crearParametro("p_ingb", NpgsqlDbType.Text, pro.proingbrutos));
            parametros.Add(Datos.DAL.crearParametro("a_act", NpgsqlDbType.Integer, pro.actid));
            parametros.Add(Datos.DAL.crearParametro("p_email", NpgsqlDbType.Text, pro.proemail));
            parametros.Add(Datos.DAL.crearParametro("pro_id", NpgsqlDbType.Integer, pro.proid));
            parametros.Add(Datos.DAL.crearParametro("p_tributo", NpgsqlDbType.Numeric, pro.proingbrutostributo));
            int resultado = Datos.DAL.EjecutarStoreInsert(procedureName, parametros);
            return resultado;

        }



        //public static List<Proveedor> GetTodos()
        //{
        //    List<Proveedor> pros = new List<Proveedor>();
        //    string procedureName = "sp_proveedor_obtenertodo";
        //    DataTable dt = Datos.DAL.EjecutarStoreConsulta(procedureName);
        //    if (dt.Rows.Count > 0)
        //    {
        //        foreach(DataRow dr in dt.Rows)
        //        {
        //            Proveedor pro = new Proveedor();
        //            pro.proid = Convert.ToInt32(dr["proid"]);
        //            pro.procodigo = dr["procodigo"].ToString();
        //            pro.prorazonsocial = dr["prorazonsocial"].ToString();
        //            pro.pronombre = dr["pronombre"].ToString();
        //            pro.prodireccion = dr["prodireccion"].ToString();
        //            pro.probarrio = dr["probarrio"].ToString();
        //            pro.procodpostal = dr["procodpostal"].ToString();
        //            pro.locid = Convert.ToInt32(dr["locid"]);
        //            pro.protelefono = dr["protelefono"].ToString();
        //            pro.tpiid = Convert.ToInt32(dr["tpiid"]);
        //            pro.procuit = dr["procuit"].ToString();
        //            pro.proingbrutos = dr["proingbrutos"].ToString();
        //            pro.actid = Convert.ToInt32(dr["actid"]);
        //            pro.proemail = dr["proemail"].ToString();
        //            pro.proingbrutostributo = Convert.ToDouble(dr["proingbrutostributo"]);
        //            pros.Add(pro);
        //        }
        //    }
        //    return pros;
        //}


        public static List<Proveedor> GetTodosLikeNombre(string pronombre)
        {
            List<Proveedor> pros = new List<Proveedor>();
            string procedureName = "sp_proveedor_gettodopornombre";
            DataTable dt = Datos.DAL.EjecutarStoreConParametro(procedureName, "pro_nombre", pronombre);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Proveedor pro = new Proveedor();
                    pro.proid = Convert.ToInt32(dr["proid"]);
                    pro.procodigo = dr["procodigo"].ToString();
                    pro.prorazonsocial = dr["prorazonsocial"].ToString();
                    pro.pronombre = dr["pronombre"].ToString();
                    pro.prodireccion = dr["prodireccion"].ToString();
                    pro.probarrio = dr["probarrio"].ToString();
                    pro.procodpostal = dr["procodpostal"].ToString();
                    pro.locid = Convert.ToInt32(dr["locid"]);
                    pro.protelefono = dr["protelefono"].ToString();
                    pro.tpiid = Convert.ToInt32(dr["tpiid"]);
                    pro.procuit = dr["procuit"].ToString();
                    pro.proingbrutos = dr["proingbrutos"].ToString();
                    pro.actid = Convert.ToInt32(dr["actid"]);
                    pro.proemail = dr["proemail"].ToString();
                    pros.Add(pro);
                }
            }
            return pros;
        }


        public static DataTable GetProveedoresDatos()
        {
            string procedureName = "sp_proveedor_obtenertodo";
            DataTable dt = Datos.DAL.EjecutarStoreConsulta(procedureName);
            return dt;
        }


        public static DataTable GetProveedoresDatos(NpgsqlConnection db)
        {
            string procedureName = "sp_proveedor_obtenertodo";
            DataTable dt = Datos.DAL.EjecutarStoreConsultaTransaccion(procedureName, db);
            return dt;
        }


        //public static Proveedor GetPorId(int proid)
        //{
        //    Proveedor pro = new Proveedor();
        //    string procedureName = "sp_proveedor_gettodoporid";
        //    DataTable dt = Datos.DAL.EjecutarStoreConParametro(procedureName, "pro_id", proid);
        //    if (dt.Rows.Count > 0)
        //    {
        //        pro.actid = Convert.ToInt32(dt.Rows[0]["actid"]);
        //        pro.locid = Convert.ToInt32(dt.Rows[0]["locid"]);
        //        pro.probarrio = dt.Rows[0]["probarrio"].ToString();
        //        pro.procodigo = dt.Rows[0]["procodigo"].ToString();
        //        pro.procodpostal = dt.Rows[0]["procodpostal"].ToString();
        //        pro.procuit = dt.Rows[0]["procuit"].ToString();
        //        pro.prodireccion = dt.Rows[0]["prodireccion"].ToString();
        //        pro.proemail = dt.Rows[0]["proemail"].ToString();
        //        pro.proid = Convert.ToInt32(dt.Rows[0]["proid"]);
        //        pro.proingbrutos = dt.Rows[0]["proingbrutos"].ToString();
        //        pro.pronombre = dt.Rows[0]["pronombre"].ToString();
        //        pro.prorazonsocial = dt.Rows[0]["prorazonsocial"].ToString();
        //        pro.protelefono = dt.Rows[0]["protelefono"].ToString();
        //        pro.tpiid = Convert.ToInt32(dt.Rows[0]["tpiid"]);
        //        pro.proingbrutostributo = Convert.ToDouble(dt.Rows[0]["proingbrutostributo"]);
        //    }
        //    return pro;
        //}

        public static Double GetIngBrutosPorId(int proid)
        {
            double res = 0;
            string procedureName = "sp_proveedor_getingbrutosporid";
            DataTable dt = Datos.DAL.EjecutarStoreConParametro(procedureName, "pro_id", proid);
            if (dt.Rows.Count > 0)
            {
                res = Convert.ToDouble(dt.Rows[0][0]);
            }
            return res;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<Proveedor> GetTodos()
        {
            List<Proveedor> list = new List<Proveedor>();
            try
            {
                list = DAL.ProveedorDAL.GetTodos();
            }
            catch(Exception)
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
        public static Proveedor GetPorId(int proid)
        {
            Proveedor proveedor = new Proveedor();
            try
            {
                proveedor = ProveedorDAL.GetPorId(proid);
            }
            catch (Exception)
            {
                throw;
            }
            return proveedor;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="proveedor"></param>
        /// <returns></returns>
        public static Proveedor Create(Proveedor proveedor)
        {
            try
            {
                proveedor = ProveedorDAL.Create(proveedor);
            }
            catch (Exception)
            {
                throw;
            }
            return proveedor;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="proveedor"></param>
        /// <returns></returns>
        public static Boolean Update(Proveedor proveedor)
        {
            bool resultado;
            try
            {
                resultado = ProveedorDAL.Update(proveedor);
            }
            catch (Exception)
            {
                throw;
            }
            return resultado;
        }

        public static List<Proveedor> GetFiltro(ProveedorCriteria filtro)
        {
            List<Proveedor> list = new List<Proveedor>();
            try
            {
                list = ProveedorDAL.GetFiltro(filtro);
            }
            catch (Exception)
            {
                throw;
            }
            return list;
        }


        public static IList<Proveedor> FindAll()
        {
            IProveedorRepository _proveedorRepository = new ProveedorRepository();
            return _proveedorRepository.FindAll();
        }


    }
}
