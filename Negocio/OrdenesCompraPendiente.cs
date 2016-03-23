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
    public class OrdenesCompraPendiente
    {

        public static DataTable GetOrdenCompraPendienteTodo()
        {
            DataTable dt = new DataTable();
            string procedureName = "sp_ordencomprapendiente_obtenertodo";
            dt = Datos.DAL.EjecutarStoreConsulta(procedureName);
            return dt;
        }


        public static int Insertar(OrdenCompraPendiente ocp, NpgsqlConnection db)
        {
            try
            {
                string procedureName = "sp_ordencomprapendiente_insertar";
                List<NpgsqlParameter> parametros = new List<NpgsqlParameter>();
                parametros.Add(Datos.DAL.crearParametro("odc_id", NpgsqlDbType.Integer, ocp.orden_id));
                parametros.Add(Datos.DAL.crearParametro("prd_id", NpgsqlDbType.Integer, ocp.producto_id));
                parametros.Add(Datos.DAL.crearParametro("odc_cantidad", NpgsqlDbType.Integer, ocp.cantidad));
                parametros.Add(Datos.DAL.crearParametro("ocd_importe", NpgsqlDbType.Numeric, ocp.importe_unitario));
                parametros.Add(Datos.DAL.crearParametro("suc_id", NpgsqlDbType.Integer, ocp.sucursal_id));
                parametros.Add(Datos.DAL.crearParametro("pro_id", NpgsqlDbType.Integer, ocp.proveedor_id));
                parametros.Add(Datos.DAL.crearParametro("esp_id", NpgsqlDbType.Integer, ocp.estado_id));

                int resultado = Datos.DAL.EjecutarStoreInsertTransaccion(procedureName, parametros, db);
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


        public static int Update(int odcid)
        {
            try
            {
                string procedureName = "sp_ordencomprapendiente_modificar";
                List<NpgsqlParameter> parametros = new List<NpgsqlParameter>();
                parametros.Add(Datos.DAL.crearParametro("odc_id", NpgsqlDbType.Integer, odcid));
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


        public static int OrdenCompraPendienteActualizar(OrdenCompraPendiente ocp)
        {
            try
            {
                string procedureName = "sp_ordencomprapendiente_actualiza";
                List<NpgsqlParameter> parametros = new List<NpgsqlParameter>();
                parametros.Add(Datos.DAL.crearParametro("odc_id", NpgsqlDbType.Integer, ocp.orden_id));
                parametros.Add(Datos.DAL.crearParametro("prd_id", NpgsqlDbType.Integer, ocp.producto_id));
                parametros.Add(Datos.DAL.crearParametro("suc_id", NpgsqlDbType.Integer, ocp.sucursal_id));
                parametros.Add(Datos.DAL.crearParametro("ocd_cantidad", NpgsqlDbType.Integer, ocp.cantidad));

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

        public static DataTable GetOrdenCompraPendientePorIdProveedor(int proId)
        {
            string procedureName = "sp_ordencomprapendiente_obtenertodoporidproveedor";
            List<NpgsqlParameter> parametros = new List<NpgsqlParameter>();
            parametros.Add(Datos.DAL.crearParametro("pro_id", NpgsqlDbType.Integer, proId));
            DataTable dt = Datos.DAL.EjecutarStoreConsultaConParametros(procedureName, parametros);
            return dt;
        }

        public static DataTable GetOrdenCompraPendientePorIdProveedorIdSucursal(int proId, int sucid)
        {
            string procedureName = "sp_ordencomprapendiente_obtenertodoporidproveedoridsucursal";
            List<NpgsqlParameter> parametros = new List<NpgsqlParameter>();
            parametros.Add(Datos.DAL.crearParametro("pro_id", NpgsqlDbType.Integer, proId));
            parametros.Add(Datos.DAL.crearParametro("suc_id", NpgsqlDbType.Integer, sucid));
            DataTable dt = Datos.DAL.EjecutarStoreConsultaConParametros(procedureName, parametros);
            return dt;
        }

         public static DataTable GetOrdenCompraPendientePorIdSucursal(int sucId)
        {
            string procedureName = "sp_ordencomprapendiente_obtenertodoporidsucursal";
            List<NpgsqlParameter> parametros = new List<NpgsqlParameter>();
            parametros.Add(Datos.DAL.crearParametro("suc_id", NpgsqlDbType.Integer, sucId));
            DataTable dt = Datos.DAL.EjecutarStoreConsultaConParametros(procedureName, parametros);
            return dt;
        }

        

          public static DataTable GetOrdenCompraPendientePorNumeroOrden(string odcnumero)
        {
            string procedureName = "sp_ordencomprapendiente_obtenertodopornumeroorden";
            List<NpgsqlParameter> parametros = new List<NpgsqlParameter>();
            parametros.Add(Datos.DAL.crearParametro("odc_numero", NpgsqlDbType.Text, odcnumero));
            DataTable dt = Datos.DAL.EjecutarStoreConsultaConParametros(procedureName, parametros);
            return dt;
        }


          public static DataTable GetOrdenCompraPendientePorNombreProducto(string prddenominacion)
          {
              string procedureName = "sp_ordencomprapendiente_obtenertodopornombreproducto";
              List<NpgsqlParameter> parametros = new List<NpgsqlParameter>();
              parametros.Add(Datos.DAL.crearParametro("prd_denominacion", NpgsqlDbType.Text, prddenominacion));
              DataTable dt = Datos.DAL.EjecutarStoreConsultaConParametros(procedureName, parametros);
              return dt;
          }

         public static DataTable GetOrdenCompraPendientePorNombreProductoPorProveedor(string prddenominacion, int proid)
          {
              string procedureName = "sp_ordencomprapendiente_obtenertodopornombreproductoyproveedor";
              List<NpgsqlParameter> parametros = new List<NpgsqlParameter>();
              parametros.Add(Datos.DAL.crearParametro("prd_denominacion", NpgsqlDbType.Text, prddenominacion));
              parametros.Add(Datos.DAL.crearParametro("pro_id", NpgsqlDbType.Integer, proid));
              DataTable dt = Datos.DAL.EjecutarStoreConsultaConParametros(procedureName, parametros);
              return dt;
          }

         public static DataTable GetOrdenCompraPendientePorNombreProductoPorProveedorPorSucursal(string prddenominacion, int proid, int sucid)
         {
             string procedureName = "sp_ordencomprapendiente_obtenertodopornombreproductoproveedorsu";
             List<NpgsqlParameter> parametros = new List<NpgsqlParameter>();
             parametros.Add(Datos.DAL.crearParametro("prd_denominacion", NpgsqlDbType.Text, prddenominacion));
             parametros.Add(Datos.DAL.crearParametro("pro_id", NpgsqlDbType.Integer, proid));
             parametros.Add(Datos.DAL.crearParametro("suc_id", NpgsqlDbType.Integer, sucid));
             DataTable dt = Datos.DAL.EjecutarStoreConsultaConParametros(procedureName, parametros);
             return dt;
         }
       

          public static int OrdenCompraPendienteEliminar(int odcid)
          {
              try
              {
                  string procedureName = "sp_ordencomprapendiente_eliminar";
                  List<NpgsqlParameter> parametros = new List<NpgsqlParameter>();
                  parametros.Add(Datos.DAL.crearParametro("odc_id", NpgsqlDbType.Integer, odcid));

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


          public static int OrdenCompraPendienteSumarProducto(OrdenCompraPendiente ocp)
          {
              try
              {
                  string procedureName = "sp_ordencomprapendiente_sumarproducto";
                  List<NpgsqlParameter> parametros = new List<NpgsqlParameter>();
                  parametros.Add(Datos.DAL.crearParametro("odc_id", NpgsqlDbType.Integer, ocp.orden_id));
                  parametros.Add(Datos.DAL.crearParametro("prd_id", NpgsqlDbType.Integer, ocp.producto_id));
                  parametros.Add(Datos.DAL.crearParametro("ocd_cantidad", NpgsqlDbType.Integer, ocp.cantidad));
                  parametros.Add(Datos.DAL.crearParametro("suc_id", NpgsqlDbType.Integer, ocp.sucursal_id));
                  parametros.Add(Datos.DAL.crearParametro("pro_id", NpgsqlDbType.Integer, ocp.proveedor_id));


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

          public static int OrdenCompraPendienteQuitarProducto(OrdenCompraPendiente ocp)
          {
              try
              {
                  string procedureName = "sp_ordencomprapendiente_quitarproducto";
                  List<NpgsqlParameter> parametros = new List<NpgsqlParameter>();
                  parametros.Add(Datos.DAL.crearParametro("odc_id", NpgsqlDbType.Integer, ocp.orden_id));
                  parametros.Add(Datos.DAL.crearParametro("prd_id", NpgsqlDbType.Integer, ocp.producto_id));
                  parametros.Add(Datos.DAL.crearParametro("ocd_cantidad", NpgsqlDbType.Integer, ocp.cantidad));
                  parametros.Add(Datos.DAL.crearParametro("suc_id", NpgsqlDbType.Integer, ocp.sucursal_id));
                  parametros.Add(Datos.DAL.crearParametro("pro_id", NpgsqlDbType.Integer, ocp.proveedor_id));


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


          public static DataTable GetOrdenCompraPendientePorIdProveedorPorSucursal(int proId, int sucid)
          {
              string procedureName = "sp_ordencomprapendiente_obtenertodoporidproveedorporidsucursal";
              List<NpgsqlParameter> parametros = new List<NpgsqlParameter>();
              parametros.Add(Datos.DAL.crearParametro("pro_id", NpgsqlDbType.Integer, proId));
              parametros.Add(Datos.DAL.crearParametro("suc_id", NpgsqlDbType.Integer, sucid));
              DataTable dt = Datos.DAL.EjecutarStoreConsultaConParametros(procedureName, parametros);
              return dt;
          }




          public static List<OrdenCompraPendiente> GetTodos()
          {
              List<OrdenCompraPendiente> list = OrdenCompraPendienteDAL.GetTodo();
              return list;
          }

          public static int EliminarPendiente(int ordencomprapendiente_id)
          {
              IOrdenCompraRepository _repository = new OrdenCompraRepository();
              return _repository.EliminarPendiente(ordencomprapendiente_id);
          }


          public static List<OrdenCompraPendiente> GetByCriteria(OrdenCompraPendienteCriteria filtro)
          {
              List<OrdenCompraPendiente> list = OrdenCompraPendienteDAL.GetByCriteria(filtro);
              return list;
          }

       

    }
}
