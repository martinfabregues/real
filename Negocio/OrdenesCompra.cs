using DAL;
using DAL.Interfases;
using DAL.Repositories;
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
using System.Windows.Forms;

namespace Negocio
{
    public class OrdenesCompra
    {
        /// <summary>
        /// Metodo que inserta la orden de compra
        /// </summary>
        /// <param name="odc">Objeto Orden de Compra</param>
        /// <param name="db">Objeto conexion persistente en transaccion (Bloque Using)</param>
        /// <returns>Objeto Orden de Compra</returns>
        public static OrdenCompra Insertar(OrdenCompra odc, NpgsqlConnection db)
        {
            try
            {
                string procedureName = "sp_ordencompra_insertar";
                List<NpgsqlParameter> parametros = new List<NpgsqlParameter>();
                
                parametros.Add(Datos.DAL.crearParametro("odc_fecha", NpgsqlDbType.Date, odc.odcfecha));
                parametros.Add(Datos.DAL.crearParametro("pro_id", NpgsqlDbType.Integer, odc.proid));
                parametros.Add(Datos.DAL.crearParametro("odc_importe", NpgsqlDbType.Numeric, odc.odcimporte));
                parametros.Add(Datos.DAL.crearParametro("est_id", NpgsqlDbType.Integer, odc.estid));
                parametros.Add(Datos.DAL.crearParametro("odc_observacion", NpgsqlDbType.Text, odc.odcobservacion));
                int resultado = Datos.DAL.EjecutarStoreInsertTransaccion(procedureName, parametros, db);

                odc.odcid = resultado;
                return odc;

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

        /// <summary>
        /// Obtiene todas las ordenes de compra.
        /// </summary>
        /// <returns>DataTable</returns>
        public static DataTable GetOrdenCompraTodo()
        {
            DataTable dt = new DataTable();
            string procedureName = "sp_ordencompra_obtenertodo";
            dt = Datos.DAL.EjecutarStoreConsulta(procedureName);
            return dt;
        }

        /// <summary>
        /// Obtiene datos de ordenes de compra like numero de orden.
        /// </summary>
        /// <param name="odcnumero">Numero de Orden de Compra</param>
        /// <returns>DataTable</returns>
        public static DataTable GetDatosLikeNumero(string odcnumero)
        {
            string procedureName = "sp_ordencompra_obtenertodoporidproveedor";
            List<NpgsqlParameter> parametros = new List<NpgsqlParameter>();
            parametros.Add(Datos.DAL.crearParametro("odc_numero", NpgsqlDbType.Text, odcnumero));
            DataTable dt = Datos.DAL.EjecutarStoreConsultaConParametros(procedureName, parametros);
            return dt;
        }

        /// <summary>
        /// Obtiene Ordenes de Compra relacionadas a un proveedor en particular.
        /// </summary>
        /// <param name="proid">Int Id de Proveedor</param>
        /// <returns>DataTable</returns>
        public static DataTable GetPorIdProveedor(int proid)
        {
            string procedureName = "sp_ordencompra_obtenertodoporidproveedor";
            List<NpgsqlParameter> parametros = new List<NpgsqlParameter>();
            parametros.Add(Datos.DAL.crearParametro("pro_id", NpgsqlDbType.Integer, proid));
            DataTable dt = Datos.DAL.EjecutarStoreConsultaConParametros(procedureName, parametros);
            return dt;
        }

        /// <summary>
        /// Obtiene Datos de una Orden de Compra por su numero.
        /// </summary>
        /// <param name="odcnumero">String Numero de Orden de Compra</param>
        /// <returns>DataTable</returns>
        public static DataTable GetDatosPorNumero(string odcnumero)
        {
            string procedureName = "sp_ordencompra_obtenertodopornumeroorden";
            List<NpgsqlParameter> parametros = new List<NpgsqlParameter>();
            parametros.Add(Datos.DAL.crearParametro("odc_numero", NpgsqlDbType.Text, odcnumero));
            DataTable dt = Datos.DAL.EjecutarStoreConsultaConParametros(procedureName, parametros);
            return dt;
        }

        /// <summary>
        /// Obtiene el numero de Orden de Compra por su Id.
        /// </summary>
        /// <param name="odcid">Int Id de Orden de Compra</param>
        /// <returns>DataTable</returns>
        public static DataTable GetNumeroPorId(int odcid)
        {
            string procedureName = "sp_odencompra_obtenernumeroporid";
            List<NpgsqlParameter> parametros = new List<NpgsqlParameter>();
            parametros.Add(Datos.DAL.crearParametro("id", NpgsqlDbType.Integer, odcid));
            DataTable dt = Datos.DAL.EjecutarStoreConsultaConParametros(procedureName, parametros);
            return dt;
        }

        /// <summary>
        /// Obtiene el numero de Orden de Compra por su Id.
        /// </summary>
        /// <param name="odcid">Int Id de Orden de Compra</param>
        /// <returns>DataTable</returns>
        public static DataTable GetNumeroPorId(int odcid, NpgsqlConnection db)
        {
            string procedureName = "sp_odencompra_obtenernumeroporid";
            List<NpgsqlParameter> parametros = new List<NpgsqlParameter>();
            parametros.Add(Datos.DAL.crearParametro("id", NpgsqlDbType.Integer, odcid));
            DataTable dt = Datos.DAL.EjecutarStoreConsultaConParametrosTransaccion(procedureName, parametros, db);
            return dt;
        }

        /// <summary>
        /// Obtiene datos de una Orden de Compra por su id.
        /// </summary>
        /// <param name="odcid">Int id de Orden de Compra.</param>
        /// <returns>DataTable</returns>
        //public static DataTable GetDatosPorId(int odcid)
        //{
        //    string procedureName = "sp_ordencompra_obtenerdatosporid";
        //    List<NpgsqlParameter> parametros = new List<NpgsqlParameter>();
        //    parametros.Add(Datos.DAL.crearParametro("id", NpgsqlDbType.Integer, odcid));
        //    DataTable dt = Datos.DAL.EjecutarStoreConsultaConParametros(procedureName, parametros);
        //    return dt;
        //}


        /// <summary>
        /// Controlar Transaccion
        /// </summary>
        /// <param name="odc"></param>
        /// <returns></returns>
        public static int UpdateOrden(OrdenCompra odc)
        {
            try
            {
                string procedureName = "sp_ordencompra_actualizar";
                List<NpgsqlParameter> parametros = new List<NpgsqlParameter>();
                parametros.Add(Datos.DAL.crearParametro("odc_id", NpgsqlDbType.Integer, odc.odcid));
                parametros.Add(Datos.DAL.crearParametro("odc_importe", NpgsqlDbType.Numeric, odc.odcimporte));
                parametros.Add(Datos.DAL.crearParametro("odcobservacion", NpgsqlDbType.Text, odc.odcobservacion));
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

        /// <summary>
        /// Obtiene todas las Ordenes de Compra generadas.
        /// </summary>
        /// <returns>List del </returns>
        public static List<OrdenCompra> GetTodo()
        {
            string procedureName = "sp_ordencompra_gettodo";
            List<OrdenCompra> odcs = new List<OrdenCompra>();
            DataTable dt = Datos.DAL.EjecutarStoreConsulta(procedureName);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    OrdenCompra odc = new OrdenCompra();
                    odc.estid = Convert.ToInt32(dr["estid"]);
                    odc.odcfecha = Convert.ToDateTime(dr["odcfecha"]);
                    odc.odcid = Convert.ToInt32(dr["odcid"]);
                    odc.odcimporte = Convert.ToDecimal(dr["odcimporte"]);
                    odc.odcnumero = dr["odcnumero"].ToString();
                    odc.odcobservacion = dr["odcobservacion"].ToString();
                    odc.proid = Convert.ToInt32(dr["proid"]);
                    odcs.Add(odc);
                }
            }

            return odcs;
        }


        /// <summary>
        /// Crea una Orden de Compra
        /// </summary>
        /// <param name="ordencompra">Parametro objeto Orden de Compra</param>
        /// <param name="detalle">Parametro DataGridView detalle</param>
        /// <returns>Objeto Orden de Compra</returns>
        public static OrdenCompra Create(OrdenCompra ordencompra)
        {

            ordencompra = OrdenCompraDAL.Create(ordencompra);

            return ordencompra;
        }


        /// <summary>
        /// Actualizar una orden de compra
        /// </summary>
        /// <param name="ordencompra"></param>
        /// <returns></returns>
        //public static OrdenCompra Update(OrdenCompra ordencompra)
        //{
        //    using (TransactionScope transaccion = new TransactionScope())
        //    {
        //        using (NpgsqlConnection db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
        //        {
        //            try
        //            {
        //                //actualizo la orden de compra
        //                NpgsqlCommand command = new NpgsqlCommand("sp_ordencompra_actualizar", db);
        //                command.CommandType = CommandType.StoredProcedure;
        //                command.Parameters.AddWithValue("odc_id", ordencompra.odcid);
        //                command.Parameters.AddWithValue("odc_importe", ordencompra.odcimporte);
        //                command.Parameters.AddWithValue("odc_observacion", ordencompra.odcobservacion);

        //                db.Open();
        //                int resultadoorden = Convert.ToInt32(command.ExecuteScalar());

        //                foreach (OrdenCompraDetalle filadetalle in ordencompra.Detalle)
        //                {
        //                    command.Parameters.Clear();
        //                    command.CommandType = CommandType.StoredProcedure;
        //                    command.CommandText = "sp_ordencompradetalle_insertar";
        //                    command.Parameters.AddWithValue("odc_id", ordencompra.odcid);
        //                    command.Parameters.AddWithValue("prd_id", filadetalle.prdid);
        //                    command.Parameters.AddWithValue("ocd_cantidad", filadetalle.ocdcantidad);
        //                    command.Parameters.AddWithValue("ocd_importeunit", filadetalle.ocdimporteunit);
        //                    command.Parameters.AddWithValue("suc_id", filadetalle.sucid);
        //                    command.Parameters.AddWithValue("ecd_id", filadetalle.ecdid);

        //                    //si el detalle no tiene id, lo inserto ya que no esta registrado en la base de datos
        //                    if (filadetalle.ocdid == 0)
        //                    {
        //                        int resultadodetalle = Convert.ToInt32(command.ExecuteScalar());

        //                        //inserto los items como pendientes
        //                        command.Parameters.Clear();
        //                        command.CommandType = CommandType.StoredProcedure;
        //                        command.CommandText = "sp_ordencomprapendiente_insertar";
        //                        command.Parameters.AddWithValue("odc_id", ordencompra.odcid);
        //                        command.Parameters.AddWithValue("prd_id", filadetalle.prdid);
        //                        command.Parameters.AddWithValue("ocd_cantidad", filadetalle.ocdcantidad);
        //                        command.Parameters.AddWithValue("ocd_importeunit", filadetalle.ocdimporteunit);
        //                        command.Parameters.AddWithValue("suc_id", filadetalle.sucid);
        //                        command.Parameters.AddWithValue("pro_id", ordencompra.proid);
        //                        command.Parameters.AddWithValue("esp_id", 1);

        //                        int resultadopendiente = Convert.ToInt32(command.ExecuteScalar());

        //                        List<BonificacionProducto> bonificaciones = new List<BonificacionProducto>();
        //                        bonificaciones = BonificacionesProducto.GetPorProducto(Convert.ToInt32(filadetalle.prdid));
        //                        if (bonificaciones.Count > 0)
        //                        {
        //                            foreach (BonificacionProducto fila in bonificaciones)
        //                            {
        //                                command.Parameters.Clear();
        //                                command.CommandType = CommandType.StoredProcedure;
        //                                command.CommandText = "sp_ordencompradetallebonificacion_insertar";
        //                                command.Parameters.AddWithValue("ocd_id", resultadodetalle);
        //                                command.Parameters.AddWithValue("prd_id", filadetalle.prdid);
        //                                //command.Parameters.AddWithValue("bon_id", fila.bonid);

        //                                int resultadobonificacion = Convert.ToInt32(command.ExecuteScalar());
        //                            }

        //                        }
        //                    }
        //                }
        //                //si no ocurre ningun error completo la transaccion
        //                transaccion.Complete();
        //            }
        //            catch (Exception ex)
        //            {
        //                ordencompra = null;
        //                throw;
        //            }
        //            finally
        //            {
        //                db.Close();
        //            }


        //        }
        //    }

        //    return ordencompra;
        //}


        /// <summary>
        /// 
        /// </summary>
        /// <param name="ordencompra"></param>
        /// <returns></returns>
        public static Boolean Update(OrdenCompra ordencompra)
        {
            bool resultado;
            try
            {
                resultado = OrdenCompraDAL.Update(ordencompra);
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
        /// <param name="ordencompra"></param>
        /// <returns></returns>
        public static OrdenCompra GetDatosPorId(OrdenCompra ordencompra)
        {
            try
            {
                ordencompra = OrdenCompraDAL.GetDatosPorId(ordencompra.odcid);
            }
            catch (Exception)
            {
                throw;
            }
            return ordencompra;
        }


        public static IList<OrdenCompra> FindAll()
        {
            IOrdenCompraRepository _ordencompraRepository = new OrdenCompraRepository();
            return _ordencompraRepository.FindAll();
        }

        public static OrdenCompra FindByIdWithDetalle(int id)
        {
            IOrdenCompraRepository _ordencompraRepository = new OrdenCompraRepository();
            return _ordencompraRepository.GetByIdWithDetalle(id);
        }

        public static IList<OrdenCompra> BusquedaCondicional(string numero, int? proveedor_id, DateTime? desde, DateTime? hasta)
        {
            IOrdenCompraRepository _ordencompraRepository = new OrdenCompraRepository();
            return _ordencompraRepository.BusquedaCondicional(numero, proveedor_id, desde, hasta);
        }

        public static IList<OrdenCompraPendiente> FindPendientes()
        {
            IOrdenCompraRepository _repository = new OrdenCompraRepository();
            return _repository.FindPendientes();
        }

        public static IList<OrdenCompraPendiente> FindPendientesCondicional(int? proveedor_id, int? sucursal_id, string numero_orden, string prod)
        {
            IOrdenCompraRepository _repository = new OrdenCompraRepository();
            return _repository.FindPendientesCondicional(proveedor_id, sucursal_id, numero_orden, prod);
        }

        public static int Modificar(OrdenCompra orden)
        {
            IOrdenCompraRepository _repositoryOrden = new OrdenCompraRepository();
            int orden_id = 0;
            bool resultado = true;

            NpgsqlConnection _cnn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString());
            _cnn.Open();

            using (var trans = _cnn.BeginTransaction())
            {
                //modifico la orden de compra
                orden_id = _repositoryOrden.Modificar(orden, _cnn, trans);
                if(orden_id > 0)
                {
                    foreach(OrdenCompraDetalle fila in orden.Detalle)
                    {
                        //pregunto si tiene id, si tiene modifico
                        if(fila.ocdid != 0)
                        {
                            //actualizo el detalle
                            int actualizar = _repositoryOrden.ModificarDetalle(fila, _cnn, trans);
                            if(actualizar == 0)
                            {
                                trans.Rollback();
                                resultado = false;
                                orden_id = 0;
                                break;
                            }
                        }
                        else
                        {
                            //si no tiene id, lo inserto
                            int insertar = _repositoryOrden.AgregarDetalle(fila, _cnn, trans);
                            if (insertar > 0)
                            {
                                //creo el objeto OrdenCompraPendiente y asigno los valores
                                OrdenCompraPendiente _pendiente = new OrdenCompraPendiente();
                                _pendiente.odcid = fila.ocdid;
                                _pendiente.prdid = fila.prdid;
                                _pendiente.proid = orden.proid;
                                _pendiente.sucid = fila.sucid;
                                _pendiente.ocdcantidad = fila.ocdcantidad;
                                _pendiente.ocdimporte = fila.ocdimporteunit;
                                _pendiente.espid = 1;
                                
                                //agrego el item como pendiente de entrega
                                int pendiente = _repositoryOrden.AgregarPendiente(_pendiente, _cnn, trans);
                                if(pendiente == 0)
                                {
                                    trans.Rollback();
                                    resultado = false;
                                    orden_id = 0;
                                    break;
                                }
                                else
                                {
                                    trans.Commit();
                                }
                            }
                            else
                            {
                                trans.Rollback();
                                resultado = false;
                                orden_id = 0;
                                break;
                            }
                          
                        }
                    }
                    if(resultado == true)
                    {
                        trans.Commit();
                    }

                }
                else
                {
                    trans.Rollback();
                    orden_id = 0;
                }
            }
            return orden_id;
        }



    }
}
