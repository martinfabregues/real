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
    public class EstadoComprobanteDAL
    {

        public static EstadoComprobante CargarEstadoComprobante(NpgsqlDataReader reader)
        {
            EstadoComprobante estadocomprobante = new EstadoComprobante();
            estadocomprobante.estadocomprobante_id = Convert.ToInt32(reader["estadocomprobante_id"]);
            estadocomprobante.estadocomprobante_denominacion = reader["estadocomprobante_denominacion"].ToString();

            return estadocomprobante;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<EstadoComprobante> GetTodo()
        {

            List<EstadoComprobante> list = new List<EstadoComprobante>();
            using (NpgsqlConnection db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
            {
                try
                {
                    NpgsqlCommand command = new NpgsqlCommand("sp_estadocomprobante_obtenertodo", db);
                    command.CommandType = CommandType.StoredProcedure;
                    db.Open();
                    NpgsqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        list.Add(CargarEstadoComprobante(reader));
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
        /// <param name="fpaid"></param>
        /// <returns></returns>
        public static EstadoComprobante GetPorId(int estadocomprobante_id)
        {
            EstadoComprobante estadocomprobante = new EstadoComprobante();

            using (NpgsqlConnection db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
            {
                try
                {
                    NpgsqlCommand command = new NpgsqlCommand("sp_estadocomprobante_getporid", db);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("estadocomprobante_id", estadocomprobante_id);
                    db.Open();

                    NpgsqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        estadocomprobante = CargarEstadoComprobante(reader);
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

            return estadocomprobante;
        }

    }
}
