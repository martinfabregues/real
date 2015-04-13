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
   public class TipoComprobanteDAL
    {

        public static TipoComprobante CargarTipoComprobante(NpgsqlDataReader reader)
        {
            TipoComprobante tipocomprobante = new TipoComprobante();
            tipocomprobante.tipocomprobante_id = Convert.ToInt32(reader["tipocomprobante_id"]);
            tipocomprobante.tipocomprobante_denominacion = reader["tipocomprobante_denominacion"].ToString();

            return tipocomprobante;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<TipoComprobante> GetTodo()
        {

            List<TipoComprobante> list = new List<TipoComprobante>();
            using (NpgsqlConnection db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
            {
                try
                {
                    NpgsqlCommand command = new NpgsqlCommand("sp_tipocomprobante_obtenertodo", db);
                    command.CommandType = CommandType.StoredProcedure;
                    db.Open();
                    NpgsqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        list.Add(CargarTipoComprobante(reader));
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


        public static TipoComprobante GetPorId(int tipocomprobante_id)
        {
            TipoComprobante tipocomprobante = new TipoComprobante();

            using (NpgsqlConnection db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
            {
                try
                {
                    NpgsqlCommand command = new NpgsqlCommand("sp_tipocomprobante_getporid", db);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("tipocomprobante_id", tipocomprobante_id);
                    db.Open();

                    NpgsqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        tipocomprobante = CargarTipoComprobante(reader);
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

            return tipocomprobante;
        }


    }
}
