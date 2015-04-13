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
    public class TarjetaCreditoDAL
    {
        public static TarjetaCredito CargarTarjetaCredito(NpgsqlDataReader reader)
        {
            TarjetaCredito tarjetacredito = new TarjetaCredito();
            tarjetacredito.tarid = Convert.ToInt32(reader["tarid"]);
            tarjetacredito.tarnombre = reader["tarnombre"].ToString();

            return tarjetacredito;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<TarjetaCredito> GetTodo()
        {

            List<TarjetaCredito> list = new List<TarjetaCredito>();
            using (NpgsqlConnection db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
            {
                try
                {
                    NpgsqlCommand command = new NpgsqlCommand("sp_tarjetacredito_obtenertodo", db);
                    command.CommandType = CommandType.StoredProcedure;
                    db.Open();
                    NpgsqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        list.Add(CargarTarjetaCredito(reader));
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


        public static TarjetaCredito GetPorId(int tarjetacredito_id)
        {
            TarjetaCredito tarjetacredito = new TarjetaCredito();

            using (NpgsqlConnection db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
            {
                try
                {
                    NpgsqlCommand command = new NpgsqlCommand("sp_tarjetacredito_getporid", db);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("tarjetacredito_id", tarjetacredito_id);
                    db.Open();

                    NpgsqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        tarjetacredito = CargarTarjetaCredito(reader);
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

            return tarjetacredito;
        }


        public static TarjetaCredito Crear(TarjetaCredito tarjeta)
        {

            using (NpgsqlConnection db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
            {
                try
                {
                    NpgsqlCommand command = new NpgsqlCommand("sp_tarjetacredito_insertar", db);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("tarnombre", tarjeta.tarnombre);
                    db.Open();
                    tarjeta.tarid = Convert.ToInt32(command.ExecuteScalar());

                }
                catch (Exception)
                {
                    tarjeta = null;
                    throw;
                }
                finally
                {
                    db.Close();
                }
            }
            return tarjeta;
        }

    }
}
