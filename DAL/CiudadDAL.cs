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
    public class CiudadDAL
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private static Ciudad CargarCiudad(NpgsqlDataReader reader)
        {
            Ciudad ciudad = new Ciudad();

            ciudad.ciuid = Convert.ToInt32(reader["ciuid"]);
            ciudad.ciunombre = reader["ciunombre"].ToString();
            ciudad.prvid = Convert.ToInt32(reader["prvid"]);

            return ciudad;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<Ciudad> GetTodo()
        {

            List<Ciudad> list = new List<Ciudad>();
            using (NpgsqlConnection db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
            {
                try
                {
                    NpgsqlCommand command = new NpgsqlCommand("sp_ciudad_obtenertodo", db);
                    command.CommandType = CommandType.StoredProcedure;
                    db.Open();
                    NpgsqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        list.Add(CargarCiudad(reader));
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


        public static Ciudad GetPorId(int ciuid)
        {
            Ciudad ciudad = new Ciudad();

            using (NpgsqlConnection db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
            {
                try
                {
                    NpgsqlCommand command = new NpgsqlCommand("sp_ciudad_getporid", db);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("ciu_id", ciuid);
                    db.Open();

                    NpgsqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        ciudad = CargarCiudad(reader);
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

            return ciudad;
        }
    }
}
