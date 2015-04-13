using Entidad;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace DAL
{
    public class SucursalDAL
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static Sucursal CargarSucursal(NpgsqlDataReader reader)
        {
            Sucursal sucursal = new Sucursal();

            sucursal.sucdireccion = reader["sucdireccion"].ToString();
            sucursal.sucid = Convert.ToInt32(reader["sucid"]);
            sucursal.sucnombre = reader["sucnombre"].ToString();

            return sucursal;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<Sucursal> GetTodo()
        {
            List<Sucursal> list = new List<Sucursal>();
            using (NpgsqlConnection db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
            {
                try
                {
                    NpgsqlCommand command = new NpgsqlCommand("sp_sucursal_obtenertodo", db);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    db.Open();

                    NpgsqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        list.Add(CargarSucursal(reader));
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
        public static String GetNombrePorId(int sucid)
        {
            String nombre = string.Empty;
            using (NpgsqlConnection db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
            {
                try
                {
                    NpgsqlCommand command = new NpgsqlCommand("sp_sucursal_obtenernombreporid", db);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("sucid", sucid);

                    db.Open();

                    nombre = command.ExecuteScalar().ToString();
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

            return nombre;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sucid"></param>
        /// <returns></returns>
        public static Sucursal GetPorId(int sucid)
        {
            Sucursal sucursal = new Sucursal();

            using (NpgsqlConnection db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
            {
                try
                {
                    NpgsqlCommand command = new NpgsqlCommand("sp_sucursal_gettodoporid", db);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("suc_id", sucid);
                    db.Open();

                    NpgsqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        sucursal = CargarSucursal(reader);
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

            return sucursal;
        }


    }
}
