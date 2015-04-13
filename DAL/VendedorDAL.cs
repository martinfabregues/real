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
    public class VendedorDAL
    {

        private static Vendedor CargarVendedor(NpgsqlDataReader reader)
        {
            Vendedor vendedor = new Vendedor();
            vendedor.vendedor_direccion = reader["vendedor_direccion"].ToString();
            vendedor.vendedor_email = reader["vendedor_email"].ToString();
            vendedor.vendedor_nombre = reader["vendedor_nombre"].ToString();
            vendedor.vendedor_id = Convert.ToInt32(reader["vendedor_id"]);
            vendedor.vendedor_telefonocelular = reader["vendedor_telefonocelular"].ToString();
            vendedor.vendedor_telefonofijo = reader["vendedor_telefonofijo"].ToString();
            vendedor.estado = EstadoDAL.GetPorId(Convert.ToInt32(reader["estid"]));

            return vendedor;
        }

        public static Vendedor Crear(Vendedor vendedor)
        {
            using (NpgsqlConnection db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
            {
                try
                {
                    NpgsqlCommand command = new NpgsqlCommand("sp_vendedor_insertar", db);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("vendedor_nombre", vendedor.vendedor_nombre);
                    command.Parameters.AddWithValue("vendedor_direccion", vendedor.vendedor_direccion);
                    command.Parameters.AddWithValue("vendedor_telefonofijo", vendedor.vendedor_telefonofijo);
                    command.Parameters.AddWithValue("vendedor_telefonocelular", vendedor.vendedor_telefonocelular);
                    command.Parameters.AddWithValue("vendedor_email", vendedor.vendedor_email);
                    command.Parameters.AddWithValue("est_id", vendedor.estado.estid);

                    db.Open();
                    vendedor.vendedor_id = Convert.ToInt32(command.ExecuteScalar());
                }
                catch (Exception)
                {
                    vendedor = null;
                    throw;
                }
                finally
                {
                    db.Close();
                }
            }
            return vendedor;
        }

        public static List<Vendedor> GetTodo()
        {

            List<Vendedor> list = new List<Vendedor>();
            using (NpgsqlConnection db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
            {
                try
                {
                    NpgsqlCommand command = new NpgsqlCommand("sp_vendedor_obtenertodo", db);
                    command.CommandType = CommandType.StoredProcedure;
                    db.Open();
                    NpgsqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        list.Add(CargarVendedor(reader));
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

        public static Vendedor GetPorId(int vendedor_id)
        {
            Vendedor vendedor = new Vendedor();

            using (NpgsqlConnection db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
            {
                try
                {
                    NpgsqlCommand command = new NpgsqlCommand("sp_vendedor_gettodoporid", db);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("vendedor_id", vendedor_id);
                    db.Open();

                    NpgsqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        vendedor = CargarVendedor(reader);
                    }
                    else
                    {
                        vendedor = null;
                    }

                }
                catch (Exception)
                {
                    vendedor = null;
                    throw;
                }
                finally
                {
                    db.Close();
                }

            }

            return vendedor;
        }

        public static Boolean Actualizar(Vendedor vendedor)
        {
            bool resultado = false;
            using (NpgsqlConnection db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
            {
                try
                {
                    NpgsqlCommand command = new NpgsqlCommand("sp_vendedor_actualizar", db);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("vendedor_nombre", vendedor.vendedor_nombre);
                    command.Parameters.AddWithValue("vendedor_direccion", vendedor.vendedor_direccion);
                    command.Parameters.AddWithValue("vendedor_telefonofijo", vendedor.vendedor_telefonofijo);
                    command.Parameters.AddWithValue("vendedor_telefonocelular", vendedor.vendedor_telefonocelular);
                    command.Parameters.AddWithValue("vendedor_email", vendedor.vendedor_email);
                    command.Parameters.AddWithValue("est_id", vendedor.estado.estid);
                    command.Parameters.AddWithValue("vendedor_id", vendedor.vendedor_id);

                    db.Open();
                    int filasAfectadas = Convert.ToInt32(command.ExecuteScalar());
                    if (filasAfectadas > 0)
                    {
                        resultado = true;
                    }
                }
                catch (Exception)
                {                   
                    throw;
                }
            }
            return resultado;
        }
    }
}
