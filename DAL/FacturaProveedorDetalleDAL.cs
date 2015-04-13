using Entidad;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;

namespace DAL
{
    public class FacturaProveedorDetalleDAL
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private static FacturaProveedorDetalle CargarFacturaDetalle(NpgsqlDataReader reader)
        {
            FacturaProveedorDetalle facturadetalle = new FacturaProveedorDetalle();

            facturadetalle.fapid = Convert.ToInt32(reader["fapid"]);
            facturadetalle.fpdcantidad = Convert.ToInt32(reader["fpdcantidad"]);
            facturadetalle.fpdid = Convert.ToInt32(reader["fpdid"]);
            facturadetalle.fpdimporteunit = Convert.ToDecimal(reader["fpdimporteunit"]);
            facturadetalle.odcid = Convert.ToInt32(reader["odcid"]);
            facturadetalle.prdid = Convert.ToInt32(reader["prdid"]);

            return facturadetalle;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<FacturaProveedorDetalle> GetTodo()
        {
            List<FacturaProveedorDetalle> list = new List<FacturaProveedorDetalle>();
            using (NpgsqlConnection db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
            {
                try
                {
                    NpgsqlCommand command = new NpgsqlCommand("sp_facturaproveedor_obtenertodo", db);
                    command.CommandType = CommandType.StoredProcedure;
                    db.Open();
                    NpgsqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        list.Add(CargarFacturaDetalle(reader));
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
        /// <param name="prddenominacion"></param>
        /// <returns></returns>
        public static List<FacturaProveedorDetalle> GetTodoPorNombreProducto(string prddenominacion)
        {
            List<FacturaProveedorDetalle> list = new List<FacturaProveedorDetalle>();
            using (NpgsqlConnection db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
            {
                try
                {
                    NpgsqlCommand command = new NpgsqlCommand("sp_facturaproveedor_obtenertodolikeproducto", db);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("prd_denominacion", prddenominacion);
                    db.Open();
                    NpgsqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        list.Add(CargarFacturaDetalle(reader));
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
        /// <param name="fapnumero"></param>
        /// <returns></returns>
        public static List<FacturaProveedorDetalle> GetTodoPorNumeroFactura(string fapnumero)
        {
            List<FacturaProveedorDetalle> list = new List<FacturaProveedorDetalle>();
            using (NpgsqlConnection db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
            {
                try
                {
                    NpgsqlCommand command = new NpgsqlCommand("sp_facturaproveedor_obtenertodolikefactura", db);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("fap_fapnumero", fapnumero);
                    db.Open();
                    NpgsqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        list.Add(CargarFacturaDetalle(reader));
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
        /// <param name="fapremito"></param>
        /// <returns></returns>
        public static List<FacturaProveedorDetalle> GetTodoPorNumeroRemito(string fapremito)
        {
            List<FacturaProveedorDetalle> list = new List<FacturaProveedorDetalle>();
            using (NpgsqlConnection db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
            {
                try
                {
                    NpgsqlCommand command = new NpgsqlCommand("sp_facturaproveedor_obtenertodolikeremito", db);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("fap_fapremito", fapremito);
                    db.Open();
                    NpgsqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        list.Add(CargarFacturaDetalle(reader));
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
        /// <param name="desde"></param>
        /// <param name="hasta"></param>
        /// <returns></returns>
        public static List<FacturaProveedorDetalle> GetTodoEntreFechas(DateTime desde, DateTime hasta)
        {
            List<FacturaProveedorDetalle> list = new List<FacturaProveedorDetalle>();
            using (NpgsqlConnection db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
            {
                try
                {
                    NpgsqlCommand command = new NpgsqlCommand("sp_facturaproveedor_obtenertodoentrefechas", db);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("desde", desde);
                    command.Parameters.AddWithValue("hasta", hasta);
                    db.Open();
                    NpgsqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        list.Add(CargarFacturaDetalle(reader));
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
        /// <param name="proid"></param>
        /// <returns></returns>
        public static List<FacturaProveedorDetalle> GetTodoPorIdProveedor(int proid)
        {
            List<FacturaProveedorDetalle> list = new List<FacturaProveedorDetalle>();
            using (NpgsqlConnection db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
            {
                try
                {
                    NpgsqlCommand command = new NpgsqlCommand("sp_facturaproveedor_obtenertodoporidproveedor", db);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("pro_id", proid);
                    db.Open();
                    NpgsqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        list.Add(CargarFacturaDetalle(reader));
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
        /// <param name="sucid"></param>
        /// <returns></returns>
        public static List<FacturaProveedorDetalle> GetTodoPorIdSucursal(int sucid)
        {
            List<FacturaProveedorDetalle> list = new List<FacturaProveedorDetalle>();
            using (NpgsqlConnection db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
            {
                try
                {
                    NpgsqlCommand command = new NpgsqlCommand("sp_facturaproveedor_obtenertodoporidsucursal", db);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("suc_id", sucid);
                    db.Open();
                    NpgsqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        list.Add(CargarFacturaDetalle(reader));
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
        /// <param name="fapid"></param>
        /// <returns></returns>
        public static List<FacturaProveedorDetalle> GetPorIdFactura(int fapid)
        {
            List<FacturaProveedorDetalle> list = new List<FacturaProveedorDetalle>();
            using (NpgsqlConnection db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
            {
                try
                {
                    NpgsqlCommand command = new NpgsqlCommand("sp_facturaproveedordetalle_gettodoporidfactura", db);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("fap_id", fapid);
                    db.Open();
                    NpgsqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        list.Add(CargarFacturaDetalle(reader));
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
        /// <param name="fpdid"></param>
        /// <returns></returns>
        public static int DeleteProducto(int fpdid)
        {

            return fpdid;
        }

    }
}
