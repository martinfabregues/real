﻿using Entidad;
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
    public class OrdenCompraDetalleDAL
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private static OrdenCompraDetalle CargarOrdenCompraDetalle(NpgsqlDataReader reader)
        {
            OrdenCompraDetalle ordencompradetalle = new OrdenCompraDetalle();

            ordencompradetalle.ecdid = Convert.ToInt32(reader["ecdid"]);
            ordencompradetalle.ocdcantidad = Convert.ToInt32(reader["ocdcantidad"]);
            ordencompradetalle.ocdid = Convert.ToInt32(reader["ocdid"]);
            ordencompradetalle.ocdimporteunit = Convert.ToDecimal(reader["ocdimporteunit"]);
            ordencompradetalle.odcid = Convert.ToInt32(reader["odcid"]);
            ordencompradetalle.prdid = Convert.ToInt32(reader["prdid"]);
            ordencompradetalle.sucid = Convert.ToInt32(reader["sucid"]);

            ordencompradetalle.producto = ProductoDAL.GetPorId(Convert.ToInt32(reader["prdid"]));
            ordencompradetalle.sucursal = SucursalDAL.GetPorId(Convert.ToInt32(reader["sucid"]));

            return ordencompradetalle;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="odcid"></param>
        /// <returns></returns>
        public static List<OrdenCompraDetalle> GetPorIdOrden(int odcid)
        {
            List<OrdenCompraDetalle> list = new List<OrdenCompraDetalle>();
            using (NpgsqlConnection db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
            {
                try
                {
                    NpgsqlCommand command = new NpgsqlCommand("sp_ordencompradetalle_getporidorden", db);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("odc_id", odcid);

                    db.Open();
                    NpgsqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        list.Add(CargarOrdenCompraDetalle(reader));
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
        /// 
        /// </summary>
        /// <param name="ordencompradetalle"></param>
        /// <param name="ordencomprapendiente"></param>
        /// <returns></returns>
        public static Boolean DeleteProducto(OrdenCompraDetalle ordencompradetalle, OrdenCompraPendiente ordencomprapendiente)
        {
            bool resultado = true;
            using (TransactionScope transaccion = new TransactionScope())
            {
                using (NpgsqlConnection db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
                {
                    try
                    {
                        //elimino las bonificaciones asignadas al item
                        NpgsqlCommand command = new NpgsqlCommand("sp_ordencompradetallebonificacion_eliminar", db);
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("ocd_id", ordencompradetalle.ocdid);

                        db.Open();
                        int filasafectadas = Convert.ToInt32(command.ExecuteScalar());
                        if (filasafectadas <= 0)
                        {
                            resultado = false;
                            return resultado;
                        }
                     
                        command.Parameters.Clear();
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandText = "sp_ordencompradetalle_eliminar";
                        command.Parameters.AddWithValue("ocd_id", ordencompradetalle.ocdid);

                        int filasafectadasdetalle = Convert.ToInt32(command.ExecuteScalar());
                        if (filasafectadasdetalle <= 0)
                        {
                            resultado = false;
                            return resultado;
                        }


                        //elimino del pendiente el producto
                        command.Parameters.Clear();
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandText = "sp_ordencomprapendiente_quitarproducto";
                        command.Parameters.AddWithValue("odc_id", ordencomprapendiente.odcid);
                        command.Parameters.AddWithValue("prd_id", ordencomprapendiente.prdid);
                        command.Parameters.AddWithValue("ocd_cantidad", ordencomprapendiente.ocdcantidad);
                        command.Parameters.AddWithValue("suc_id", ordencomprapendiente.sucid);
                        command.Parameters.AddWithValue("pro_id", ordencomprapendiente.proid);

                        int filasafectadaspendiente = Convert.ToInt32(command.ExecuteScalar());
                        if (filasafectadaspendiente <= 0)
                        {
                            resultado = false;
                            return resultado;
                        }
                       
                        //si no ocurre un error completo la transaccion                     
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

            return resultado;
        }


        public static DataTable GetTodo()
        {
            DataTable dt = new DataTable();
            using (NpgsqlConnection db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
            {
                NpgsqlCommand command = new NpgsqlCommand();
                command.Connection = db;
                command.CommandText = "SELECT * FROM ordencompradetalle";
                command.CommandType = CommandType.Text;
                NpgsqlDataAdapter da = new NpgsqlDataAdapter();
                da.SelectCommand = command;
                da.Fill(dt);
            }
            return dt;
        }
    }
}
