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
    public class ClienteDAL
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static Cliente CargarCliente(NpgsqlDataReader reader)
        {
            Cliente cliente = new Cliente();

            cliente.ciudad = CiudadDAL.GetPorId(Convert.ToInt32(reader["ciuid"]));
            cliente.clibarrio = reader["clibarrio"].ToString();
            cliente.clicalle = reader["clicalle"].ToString();
            cliente.clicodigo = reader["clicodigo"].ToString();
            cliente.clidepto = reader["clidepto"].ToString();
            cliente.clidocumento = reader["clidocumento"].ToString();
            cliente.cliemail = reader["cliemail"].ToString();
            cliente.clifecha = Convert.ToDateTime(reader["clifecha"]);
            cliente.cliid = Convert.ToInt32(reader["cliid"]);
            cliente.clinombre = reader["clinombre"].ToString();
            cliente.clinumero = reader["clinumero"].ToString();
            cliente.clipiso = reader["clipiso"].ToString();
            cliente.clitelefonocelular = reader["clitelefonocelular"].ToString();
            cliente.clitelefonofijo = reader["clitelefonofijo"].ToString();
            cliente.estado = EstadoDAL.GetPorId(Convert.ToInt32(reader["estid"]));
            cliente.tipoiva = TipoIvaDAL.GetPorId(Convert.ToInt32(reader["tpiid"]));
            return cliente;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cliente"></param>
        /// <returns></returns>
        public static Cliente Crear(Cliente cliente)
        {
            using (NpgsqlConnection db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
            {
                try
                {
                    //inserto la marca
                    NpgsqlCommand command = new NpgsqlCommand("sp_cliente_insertar", db);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("clinombre", cliente.clinombre);
                    command.Parameters.AddWithValue("clidocumento", cliente.clidocumento);
                    command.Parameters.AddWithValue("tpiid", cliente.tipoiva.tpiId);
                    command.Parameters.AddWithValue("ciuid", cliente.ciudad.ciuid);
                    command.Parameters.AddWithValue("clicalle", cliente.clicalle);
                    command.Parameters.AddWithValue("clinumero", cliente.clinumero);
                    command.Parameters.AddWithValue("clipiso", cliente.clipiso);
                    command.Parameters.AddWithValue("clidepto", cliente.clidepto);
                    command.Parameters.AddWithValue("clitelefonofijo", cliente.clitelefonofijo);
                    command.Parameters.AddWithValue("clitelefonocelular", cliente.clitelefonocelular);
                    command.Parameters.AddWithValue("cliemail", cliente.cliemail);
                    command.Parameters.AddWithValue("estid", cliente.estado.estid);
                    command.Parameters.AddWithValue("clifecha", cliente.clifecha);
                    command.Parameters.AddWithValue("clibarrio", cliente.clibarrio);

                    db.Open();
                    cliente.cliid = Convert.ToInt32(command.ExecuteScalar());
                }
                catch (Exception)
                {
                    cliente = null;
                    throw;
                }
                finally
                {
                    db.Close();
                }

            }          
            return cliente;
        }



        public static Boolean Modificar(Cliente cliente)
        {
            bool resultado = false;
            using (NpgsqlConnection db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
            {
                try
                {
                    //inserto la marca
                    NpgsqlCommand command = new NpgsqlCommand("sp_cliente_modificar", db);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("clinombre", cliente.clinombre);
                    command.Parameters.AddWithValue("clidocumento", cliente.clidocumento);
                    command.Parameters.AddWithValue("tpiid", cliente.tipoiva.tpiId);
                    command.Parameters.AddWithValue("ciuid", cliente.ciudad.ciuid);
                    command.Parameters.AddWithValue("clicalle", cliente.clicalle);
                    command.Parameters.AddWithValue("clinumero", cliente.clinumero);
                    command.Parameters.AddWithValue("clipiso", cliente.clipiso);
                    command.Parameters.AddWithValue("clidepto", cliente.clidepto);
                    command.Parameters.AddWithValue("clitelefonofijo", cliente.clitelefonofijo);
                    command.Parameters.AddWithValue("clitelefonocelular", cliente.clitelefonocelular);
                    command.Parameters.AddWithValue("cliemail", cliente.cliemail);
                    command.Parameters.AddWithValue("estid", cliente.estado.estid);
                    command.Parameters.AddWithValue("clifecha", cliente.clifecha);
                    command.Parameters.AddWithValue("clibarrio", cliente.clibarrio);
                    command.Parameters.AddWithValue("cliid", cliente.cliid);

                    db.Open();
                    cliente.cliid = Convert.ToInt32(command.ExecuteScalar());
                    if (cliente.cliid > 0)
                    {
                        resultado = true;
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
            return resultado;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="catid"></param>
        /// <returns></returns>
        public static Cliente GetPorId(int cliid)
        {
            Cliente cliente = new Cliente();

            using (NpgsqlConnection db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
            {
                try
                {
                    NpgsqlCommand command = new NpgsqlCommand("sp_cliente_getporid", db);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("cli_id", cliid);
                    db.Open();

                    NpgsqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        cliente = CargarCliente(reader);
                    }
                    else
                    {
                        cliente = null;
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

            return cliente;
        }


        public static List<Cliente> GetTodo()
        {
            List<Cliente> list = new List<Cliente>();
            using (NpgsqlConnection db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
            {
                try
                {
                    NpgsqlCommand command = new NpgsqlCommand("sp_cliente_obtenertodo", db);
                    command.CommandType = CommandType.StoredProcedure;
                    db.Open();
                    NpgsqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        list.Add(CargarCliente(reader));
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


        public static List<Cliente> GetTodoConsulta()
        {
            List<Cliente> list = new List<Cliente>();
            using (NpgsqlConnection db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
            {
                try
                {
                    NpgsqlCommand command = new NpgsqlCommand("sp_cliente_obtenertodoconsulta", db);
                    command.CommandType = CommandType.StoredProcedure;
                    db.Open();
                    NpgsqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Cliente cliente = new Cliente();
                        cliente.estado = new Estado();
                        cliente.tipoiva = new TipoIva();

                        cliente.clibarrio = reader["clibarrio"].ToString();
                        cliente.clicalle = reader["clicalle"].ToString();
                        cliente.clicodigo = reader["clicodigo"].ToString();
                        cliente.clidepto = reader["clidepto"].ToString();
                        cliente.clidocumento = reader["clidocumento"].ToString();
                        cliente.cliemail = reader["cliemail"].ToString();
                        cliente.clifecha = Convert.ToDateTime(reader["clifecha"]);
                        cliente.cliid = Convert.ToInt32(reader["cliid"]);
                        cliente.clinombre = reader["clinombre"].ToString();
                        cliente.clinumero = reader["clinumero"].ToString();
                        cliente.clipiso = reader["clipiso"].ToString();
                        cliente.clitelefonocelular = reader["clitelefonocelular"].ToString();
                        cliente.clitelefonofijo = reader["clitelefonofijo"].ToString();
                        cliente.estado.estestado = reader["estestado"].ToString();
                        cliente.tipoiva.tpitipo = reader["tpitipo"].ToString();

                        list.Add(cliente);
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
