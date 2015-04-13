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
    public class FormaPagoDAL
    {

        public static FormaPago CargarFormaPago(NpgsqlDataReader reader)
        {
            FormaPago formapago = new FormaPago();
            formapago.fpaid = Convert.ToInt32(reader["fpaid"]);
            formapago.fpaforma = reader["fpaforma"].ToString();
           
            return formapago;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<FormaPago> GetTodo()
        {

            List<FormaPago> list = new List<FormaPago>();
            using (NpgsqlConnection db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
            {
                try
                {
                    NpgsqlCommand command = new NpgsqlCommand("sp_formapago_obtenertodo", db);
                    command.CommandType = CommandType.StoredProcedure;
                    db.Open();
                    NpgsqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        list.Add(CargarFormaPago(reader));
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
        public static FormaPago GetPorId(int fpaid)
        {
            FormaPago formapago = new FormaPago();

            using (NpgsqlConnection db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
            {
                try
                {
                    NpgsqlCommand command = new NpgsqlCommand("sp_formapago_getporid", db);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("fpa_id", fpaid);
                    db.Open();

                    NpgsqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        formapago = CargarFormaPago(reader);
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

            return formapago;
        }

    }
}
