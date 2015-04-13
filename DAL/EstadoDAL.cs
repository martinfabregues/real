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
    public class EstadoDAL
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private static Estado CargarEstado(NpgsqlDataReader reader)
        {
            Estado estado = new Estado();
            estado.estid = Convert.ToInt32(reader["estid"]);
            estado.estestado = reader["estestado"].ToString();
            
            return estado;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<Estado> GetTodo()
        {
            List<Estado> list = new List<Estado>();
            using (NpgsqlConnection db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
            {
                try
                {
                    NpgsqlCommand command = new NpgsqlCommand("sp_estado_obtenertodo", db);
                    command.CommandType = CommandType.StoredProcedure;
                    db.Open();
                    NpgsqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        list.Add(CargarEstado(reader));
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
        /// <param name="estid"></param>
        /// <returns></returns>
        public static Estado GetPorId(int estid)
        {
            Estado estado = null;

            using (NpgsqlConnection db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
            {

                NpgsqlCommand command = new NpgsqlCommand("sp_estado_gettodoporid", db);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("est_id", estid);

                db.Open();
                NpgsqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    estado = CargarEstado(reader);
                }

            }

            return estado;        
        }


    }
}
