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
using System.Threading.Tasks;
using System.Transactions;

namespace Negocio
{
    public class OrdenesCompraDetalle
    {
        public static int Insertar(OrdenCompraDetalle ocd, NpgsqlConnection db)
        {
            try
            {
                string procedureName = "sp_ordencompradetalle_insertar";
                List<NpgsqlParameter> parametros = new List<NpgsqlParameter>();
                parametros.Add(Datos.DAL.crearParametro("odc_id", NpgsqlDbType.Integer, ocd.orden_id));
                parametros.Add(Datos.DAL.crearParametro("prd_id", NpgsqlDbType.Integer, ocd.producto_id));
                parametros.Add(Datos.DAL.crearParametro("ocd_cantidad", NpgsqlDbType.Integer, ocd.cantidad));
                parametros.Add(Datos.DAL.crearParametro("ocd_importeunit", NpgsqlDbType.Numeric, ocd.importe_unitario));
                parametros.Add(Datos.DAL.crearParametro("suc_id", NpgsqlDbType.Integer, ocd.sucursal_id));
                parametros.Add(Datos.DAL.crearParametro("ecd_id", NpgsqlDbType.Integer, ocd.estado_id));


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

        public static int OrdenCompraDetalleCambiarEstado(OrdenCompraDetalle ocd)
        {
            try
            {
                string procedureName = "sp_ordencompradetalle_actualizarmodificado";
                List<NpgsqlParameter> parametros = new List<NpgsqlParameter>();
                parametros.Add(Datos.DAL.crearParametro("odc_id", NpgsqlDbType.Integer, ocd.id));

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





        public static DataTable GetOrdencompraDetalleDatosPodId(int ocdid)
        {
            string procedureName = "sp_ordencompradetalle_obtenerdatosporid";
            List<NpgsqlParameter> parametros = new List<NpgsqlParameter>();
            parametros.Add(Datos.DAL.crearParametro("id", NpgsqlDbType.Integer, ocdid));
            DataTable dt = Datos.DAL.EjecutarStoreConsultaConParametros(procedureName, parametros);
            return dt;
        }

        public static DataTable GetOrdencompraDetalleDatosPodId(int ocdid, NpgsqlConnection db )
        {
            string procedureName = "sp_ordencompradetalle_obtenerdatosporid";
            List<NpgsqlParameter> parametros = new List<NpgsqlParameter>();
            parametros.Add(Datos.DAL.crearParametro("id", NpgsqlDbType.Integer, ocdid));
            DataTable dt = Datos.DAL.EjecutarStoreConsultaConParametrosTransaccion(procedureName, parametros, db);
            return dt;
        }

        
        public static int OrdenCompraDetalleEliminarFila(int ocdid)
        {
            string procedureName = "sp_ordencompradetalle_eliminar";
            List<NpgsqlParameter> parametros = new List<NpgsqlParameter>();
            parametros.Add(Datos.DAL.crearParametro("ocd_id", NpgsqlDbType.Integer, ocdid));
            int resultado = Datos.DAL.EjecutarStoreInsert(procedureName, parametros);
            return resultado;

        }


        public static int EliminarProducto(int ocdid, OrdenCompraPendiente ordenpendiente)
        {
            int filasafectadas = 0;
            
            using (TransactionScope transaccion = new TransactionScope())
            {
                using (NpgsqlConnection db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
                {
                    try
                    {
                        //elimino los detalles de bonificacion del producto
                        NpgsqlCommand command = new NpgsqlCommand("sp_ordencompradetallebonificacion_eliminar", db);
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("ocd_id", ocdid);

                        db.Open();
                        filasafectadas = Convert.ToInt32(command.ExecuteScalar());

                        //elimino del detalle el producto
                        command.Parameters.Clear();
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandText = "sp_ordencompradetalle_eliminar";
                        command.Parameters.AddWithValue("ocd_id", ocdid);

                        filasafectadas = Convert.ToInt32(command.ExecuteScalar());

                        //elimino del pendiente el producto
                        command.Parameters.Clear();
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandText = "sp_ordencomprapendiente_quitarproducto";
                        command.Parameters.AddWithValue("odc_id", ordenpendiente.orden_id);
                        command.Parameters.AddWithValue("prd_id", ordenpendiente.producto_id);
                        command.Parameters.AddWithValue("ocd_cantidad", ordenpendiente.cantidad);
                        command.Parameters.AddWithValue("suc_id", ordenpendiente.sucursal_id);
                        command.Parameters.AddWithValue("pro_id", ordenpendiente.proveedor_id);

                        filasafectadas = Convert.ToInt32(command.ExecuteScalar());

                        transaccion.Complete();
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                    finally
                    {
                        db.Close();
                    }
                }

            }

            return filasafectadas;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="ordencompra"></param>
        /// <returns></returns>
        public static List<OrdenCompraDetalle> GetPorIdOrden(OrdenCompra ordencompra)
        {
            List<OrdenCompraDetalle> list = new List<OrdenCompraDetalle>();
            try
            {
                list = OrdenCompraDetalleDAL.GetPorIdOrden(ordencompra.id);
            }
            catch (Exception)
            {
                throw;
            }
            return list;
        }

        public static DataTable GetTodo()
        {
            DataTable dt = new DataTable();
            try
            {
                dt = OrdenCompraDetalleDAL.GetTodo();
            }
            catch (Exception)
            {
                throw;
            }
            return dt;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ordencompradetalle"></param>
        /// <param name="ordencomprapendiente"></param>
        /// <returns></returns>
        public static Boolean DeleteProducto(OrdenCompraDetalle ordencompradetalle, OrdenCompraPendiente ordencomprapendiente)
        {
            bool resultado;
            try
            {
                resultado = OrdenCompraDetalleDAL.DeleteProducto(ordencompradetalle, ordencomprapendiente);
            }
            catch (Exception)
            {
                throw;
            }
            return resultado;
        }


    }
}
