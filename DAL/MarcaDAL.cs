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
    public class MarcaDAL
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private static Marca CargarMarca(NpgsqlDataReader reader)
        {
            Marca marca = new Marca();

            marca.mardenominacion = reader["mardenominacion"].ToString();
            marca.marid = Convert.ToInt32(reader["marid"]);
            marca.proid = Convert.ToInt32(reader["proid"]);

            return marca;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mar"></param>
        /// <returns></returns>
        public static Marca Create(Marca marca)
        {

            using (NpgsqlConnection db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
            {
                try
                {
                    //inserto la marca
                    NpgsqlCommand command = new NpgsqlCommand("sp_marca_insertar", db);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("proid", marca.proid);
                    command.Parameters.AddWithValue("mardenominacion", marca.mardenominacion);                    

                    db.Open();
                    marca.marid = Convert.ToInt32(command.ExecuteScalar());
                }
                catch (Exception)
                {
                    marca = null;
                    throw;
                }
                finally
                {
                    db.Close();
                }
               
            }          
            return marca;
        }
  
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<Marca> GetTodo()
        {

            List<Marca> list = new List<Marca>();
            using (NpgsqlConnection db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
            {
                try
                {
                    NpgsqlCommand command = new NpgsqlCommand("sp_marca_obtenertodo", db);
                    command.CommandType = CommandType.StoredProcedure;
                    db.Open();
                    NpgsqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        list.Add(CargarMarca(reader));
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
        /// <param name="marid"></param>
        /// <returns></returns>
        public static Marca GetPorId(int marid)
        {
            Marca marca = new Marca();

            using (NpgsqlConnection db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
            {
                try
                {
                    NpgsqlCommand command = new NpgsqlCommand("sp_marca_getporid", db);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("mar_id", marid);
                    db.Open();

                    NpgsqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        marca = CargarMarca(reader);
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

            return marca;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="proid"></param>
        /// <returns></returns>
        public static List<Marca> GetPorIdProveedor(int proid)
        {
            List<Marca> list = new List<Marca>();
            using (NpgsqlConnection db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
            {
                try
                {
                    NpgsqlCommand command = new NpgsqlCommand("sp_marca_obtenerporidproveedor", db);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("id", proid);
                    db.Open();
                    NpgsqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        list.Add(CargarMarca(reader));
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
