using Entidad;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Transactions;

namespace DAL
{
    public class OrdenCompraDAL
    {
        /// <summary>
        /// Set propiedades del objeto
        /// </summary>
        /// <param name="reader">NpgsqlDataReader con datos</param>
        private static OrdenCompra CargarOrdenCompra(NpgsqlDataReader reader)
        {
            OrdenCompra ordencompra = new OrdenCompra();

            ordencompra.estado_id = Convert.ToInt32(reader["estid"]);
            ordencompra.fecha = Convert.ToDateTime(reader["odcfecha"]);
            ordencompra.id = Convert.ToInt32(reader["odcid"]);
            ordencompra.importe = Convert.ToDecimal(reader["odcimporte"]);
            ordencompra.numero = reader["odcnumero"].ToString();
            ordencompra.observacion = reader["odcobservacion"].ToString();
            ordencompra.proveedor_id = Convert.ToInt32(reader["proid"]);

            ordencompra.proveedor = ProveedorDAL.GetPorId(Convert.ToInt32(reader["proid"]));

            return ordencompra;
        }

        /// <summary>
        /// Crea una Orden de Compra
        /// </summary>
        /// <param name="ordencompra">Parametro objeto Orden de Compra</param>
        /// <param name="detalle">Parametro DataGridView detalle</param>
        /// <returns>Objeto Orden de Compra</returns>
        public static OrdenCompra Create(OrdenCompra ordencompra)
        {
            NpgsqlTransaction transaccion = null;

            using (NpgsqlConnection db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
            {
                
                    try
                    {
                        db.Open();
                       
                        transaccion = db.BeginTransaction();
                        //inserto la orden de compra
                        NpgsqlCommand command = new NpgsqlCommand("sp_ordencompra_insertar", db);
                        command.CommandTimeout = 5 * 60;
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("odc_fecha", ordencompra.fecha);
                        command.Parameters.AddWithValue("pro_id", ordencompra.proveedor_id);
                        command.Parameters.AddWithValue("odc_importe", ordencompra.importe);
                        command.Parameters.AddWithValue("est_id", ordencompra.estado_id);
                        command.Parameters.AddWithValue("odc_observacion", ordencompra.observacion);

                        
                        ordencompra.id = Convert.ToInt32(command.ExecuteScalar());
                        //inserto el detalle de orden de compra
                        foreach (OrdenCompraDetalle filadetalle in ordencompra.Detalle)
                        {
                            command.Parameters.Clear();
                            command.CommandType = CommandType.StoredProcedure;
                            command.CommandText = "sp_ordencompradetalle_insertar";
                            command.Parameters.AddWithValue("odc_id", ordencompra.id);
                            command.Parameters.AddWithValue("prd_id", filadetalle.producto_id);
                            command.Parameters.AddWithValue("ocd_cantidad", filadetalle.cantidad);
                            command.Parameters.AddWithValue("ocd_importeunit", filadetalle.importe_unitario);
                            command.Parameters.AddWithValue("suc_id", filadetalle.sucursal_id);
                            command.Parameters.AddWithValue("ecd_id", filadetalle.estado_id);

                            int resultadodetalle = Convert.ToInt32(command.ExecuteScalar());

                            //inserto los items como pendientes
                            command.Parameters.Clear();
                            command.CommandType = CommandType.StoredProcedure;
                            command.CommandText = "sp_ordencomprapendiente_insertar";
                            command.Parameters.AddWithValue("odc_id", ordencompra.id);
                            command.Parameters.AddWithValue("prd_id", filadetalle.producto_id);
                            command.Parameters.AddWithValue("ocd_cantidad", filadetalle.cantidad);
                            command.Parameters.AddWithValue("ocd_importeunit", filadetalle.importe_unitario);
                            command.Parameters.AddWithValue("suc_id", filadetalle.sucursal_id);
                            command.Parameters.AddWithValue("pro_id", ordencompra.proveedor_id);
                            command.Parameters.AddWithValue("esp_id", 1);

                            int resultadopendiente = Convert.ToInt32(command.ExecuteScalar());

                            List<BonificacionProducto> bonificaciones = new List<BonificacionProducto>();
                            bonificaciones = BonificacionProductoDAL.GetPorProducto(Convert.ToInt32(filadetalle.producto_id));
                            if (bonificaciones.Count > 0)
                            {
                                foreach (BonificacionProducto fila in bonificaciones)
                                {
                                    command.Parameters.Clear();
                                    command.CommandType = CommandType.StoredProcedure;
                                    command.CommandText = "sp_ordencompradetallebonificacion_insertar";
                                    command.Parameters.AddWithValue("ocd_id", resultadodetalle);
                                    command.Parameters.AddWithValue("prd_id", filadetalle.producto_id);
                                    command.Parameters.AddWithValue("bon_id", fila.bonificacion.bonid);                                 

                                    int resultadobonificacion = Convert.ToInt32(command.ExecuteScalar());
                                }

                            }

                        }
                        //si no ocurre un error completo la transaccion                     
                        transaccion.Commit();
                    }
                    catch (Exception)
                    {
                        ordencompra = null;
                        transaccion.Rollback();                    
                        throw;
                    }
                    finally
                    {
                        db.Close();
                    }
                
            }



            return ordencompra;
        }


        /// <summary>
        /// Actualizar una orden de compra
        /// </summary>
        /// <param name="ordencompra"></param>
        /// <returns></returns>
        public static Boolean Update(OrdenCompra ordencompra)
        {
            bool resultado = true;
            NpgsqlTransaction transaccion = null;
           
                using (NpgsqlConnection db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
                {
                    try
                    {
                        db.Open();
                        transaccion = db.BeginTransaction();
                        //actualizo la orden de compra
                        NpgsqlCommand command = new NpgsqlCommand("sp_ordencompra_actualizar", db);
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("odc_id", ordencompra.id);
                        command.Parameters.AddWithValue("odc_importe", ordencompra.importe);
                        command.Parameters.AddWithValue("odc_observacion", ordencompra.observacion);
                       
                        int resultadoorden = Convert.ToInt32(command.ExecuteScalar());

                        if (resultadoorden > 0)
                        {

                        }
                        else
                        {
                            resultado = false;
                            return false;
                        }

                        foreach (OrdenCompraDetalle filadetalle in ordencompra.Detalle)
                        {
                            command.Parameters.Clear();
                            command.CommandType = CommandType.StoredProcedure;
                            command.CommandText = "sp_ordencompradetalle_insertar";
                            command.Parameters.AddWithValue("odc_id", ordencompra.id);
                            command.Parameters.AddWithValue("prd_id", filadetalle.producto_id);
                            command.Parameters.AddWithValue("ocd_cantidad", filadetalle.cantidad);
                            command.Parameters.AddWithValue("ocd_importeunit", filadetalle.importe_unitario);
                            command.Parameters.AddWithValue("suc_id", filadetalle.sucursal_id);
                            command.Parameters.AddWithValue("ecd_id", filadetalle.estado_id);

                            //si el detalle no tiene id, lo inserto ya que no esta registrado en la base de datos
                            if (filadetalle.id == 0)
                            {
                                int resultadodetalle = Convert.ToInt32(command.ExecuteScalar());

                                if (resultadodetalle > 0)
                                {

                                }
                                else
                                {
                                    resultado = false;
                                    return false;
                                }


                                //inserto los items como pendientes
                                command.Parameters.Clear();
                                command.CommandType = CommandType.StoredProcedure;
                                command.CommandText = "sp_ordencomprapendiente_insertar";
                                command.Parameters.AddWithValue("odc_id", ordencompra.id);
                                command.Parameters.AddWithValue("prd_id", filadetalle.producto_id);
                                command.Parameters.AddWithValue("ocd_cantidad", filadetalle.cantidad);
                                command.Parameters.AddWithValue("ocd_importeunit", filadetalle.importe_unitario);
                                command.Parameters.AddWithValue("suc_id", filadetalle.sucursal_id);
                                command.Parameters.AddWithValue("pro_id", ordencompra.proveedor_id);
                                command.Parameters.AddWithValue("esp_id", 1);

                                int resultadopendiente = Convert.ToInt32(command.ExecuteScalar());
                                if (resultadopendiente > 0)
                                {

                                }
                                else
                                {
                                    resultado = false;
                                    return false;
                                }

                                List<BonificacionProducto> bonificaciones = new List<BonificacionProducto>();
                                bonificaciones = BonificacionProductoDAL.GetPorProducto(Convert.ToInt32(filadetalle.producto_id));
                                if (bonificaciones.Count > 0)
                                {
                                    foreach (BonificacionProducto fila in bonificaciones)
                                    {
                                        command.Parameters.Clear();
                                        command.CommandType = CommandType.StoredProcedure;
                                        command.CommandText = "sp_ordencompradetallebonificacion_insertar";
                                        command.Parameters.AddWithValue("ocd_id", resultadodetalle);
                                        command.Parameters.AddWithValue("prd_id", filadetalle.producto_id);
                                        command.Parameters.AddWithValue("bon_id", fila.bonificacion.bonid);

                                        int resultadobonificacion = Convert.ToInt32(command.ExecuteScalar());
                                        if (resultadobonificacion > 0)
                                        {

                                        }
                                        else
                                        {
                                            resultado = false;
                                            return false;
                                        }
                                    }

                                }
                            }
                        }
                        //si no ocurre ningun error completo la transaccion
                        transaccion.Commit();
                    }
                    catch (Exception ex)
                    {
                        ordencompra = null;
                        transaccion.Rollback();
                        throw;
                    }
                    finally
                    {
                        db.Close();
                    }


                }
            

            return resultado;
        }


        /// <summary>
        /// Obtiene todas las Ordenes de Compra generadas.
        /// </summary>
        /// <returns>List del </returns>
        public static List<OrdenCompra> GetTodo()
        {
            List<OrdenCompra> list = new List<OrdenCompra>();
            using (NpgsqlConnection db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
            {
                try
                {
                    NpgsqlCommand command = new NpgsqlCommand("sp_ordencompra_gettodo", db);
                    command.CommandType = CommandType.StoredProcedure;
                    db.Open();
                    NpgsqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        list.Add(CargarOrdenCompra(reader));
                    }

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

            return list;
        }

        /// <summary>
        /// Obtiene datos de una Orden de Compra por su id.
        /// </summary>
        /// <param name="odcid">Int id de Orden de Compra.</param>
        /// <returns>DataTable</returns>
        public static OrdenCompra GetDatosPorId(int odcid)
        {
            OrdenCompra ordencompra = null;

            using (NpgsqlConnection db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
            {

                NpgsqlCommand command = new NpgsqlCommand("sp_ordencompra_gettodoporid", db);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("odc_id", odcid);

                db.Open();
                NpgsqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    ordencompra = CargarOrdenCompra(reader);
                }

            }
           
            return ordencompra;
        }

        /// <summary>
        /// Obtiene datos de una orden de compra por su numero
        /// </summary>
        /// <param name="odcnumero">N° de Orden de Compra</param>
        /// <returns>Objeto Orden de Compra</returns>
        public static OrdenCompra GetDatosPorNumero(string odcnumero)
        {
            OrdenCompra ordencompra = null;

            using (NpgsqlConnection db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
            {
                NpgsqlCommand command = new NpgsqlCommand("sp_ordencompra_obtenertodopornumeroorden", db);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("odc_numero", odcnumero);

                db.Open();
                NpgsqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    ordencompra = CargarOrdenCompra(reader);
                }

            }

            return ordencompra;           
        }

        /// <summary>
        /// Obtiene Ordenes de Compra relacionadas a un proveedor en particular.
        /// </summary>
        /// <param name="proid">Int Id de Proveedor</param>
        /// <returns>ArrayList tipo OrdenCompra</returns>
        public static List<OrdenCompra> GetPorIdProveedor(int proid)
        {
            List<OrdenCompra> list = new List<OrdenCompra>();
            using (NpgsqlConnection db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
            {
                try
                {
                    NpgsqlCommand command = new NpgsqlCommand("sp_ordencompra_obtenertodoporidproveedor", db);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("pro_id", proid);

                    db.Open();
                    NpgsqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        list.Add(CargarOrdenCompra(reader));
                    }

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

            return list;
        }

        /// <summary>
        /// Obtiene datos de ordenes de compra like numero de orden.
        /// </summary>
        /// <param name="odcnumero">Numero de Orden de Compra</param>
        /// <returns>ArrayList tipo Orden de Compra</returns>
        public static List<OrdenCompra> GetDatosLikeNumero(string odcnumero)
        {
            List<OrdenCompra> list = new List<OrdenCompra>();
            using (NpgsqlConnection db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
            {
                try
                {
                    NpgsqlCommand command = new NpgsqlCommand("sp_ordencompra_obtenertodolikenumero", db);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("odc_numero", odcnumero);

                    db.Open();
                    NpgsqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        list.Add(CargarOrdenCompra(reader));
                    }

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

            return list;            
        }

        

    }
}
