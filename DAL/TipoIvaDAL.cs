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
    public class TipoIvaDAL
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private static TipoIva CargarTipoIva(NpgsqlDataReader reader)
        {
            TipoIva tipoiva = new TipoIva();

            tipoiva.tpiId = Convert.ToInt32(reader["tpiid"]);
            tipoiva.tpitipo = reader["tpitipo"].ToString();

            return tipoiva;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<TipoIva> GetTodo()
        {

            List<TipoIva> list = new List<TipoIva>();
            using (NpgsqlConnection db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
            {
                try
                {
                    NpgsqlCommand command = new NpgsqlCommand("sp_tipoiva_obtenertodo", db);
                    command.CommandType = CommandType.StoredProcedure;
                    db.Open();
                    NpgsqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        list.Add(CargarTipoIva(reader));
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
        /// <param name="tpiid"></param>
        /// <returns></returns>
        public static TipoIva GetPorId(int tpiid)
        {
            TipoIva tipoiva = new TipoIva();

            using (NpgsqlConnection db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
            {
                try
                {
                    NpgsqlCommand command = new NpgsqlCommand("sp_tipoiva_getporid", db);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("tpi_id", tpiid);
                    db.Open();

                    NpgsqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        tipoiva = CargarTipoIva(reader);
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

            return tipoiva;
        }

    }
}
