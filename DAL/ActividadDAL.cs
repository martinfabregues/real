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
    public class ActividadDAL
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private static Actividad CargarActividad(NpgsqlDataReader reader)
        {
            Actividad actividad = new Actividad();

            actividad.actid = Convert.ToInt32(reader["actid"]);
            actividad.actnombre = reader["actnombre"].ToString();
     
            return actividad;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<Actividad> GetTodo()
        {
             List<Actividad> list = new List<Actividad>();
             using (NpgsqlConnection db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
             {
                 try
                 {
                     NpgsqlCommand command = new NpgsqlCommand("sp_actividad_obtenertodo", db);
                     command.CommandType = CommandType.StoredProcedure;
                     db.Open();
                     NpgsqlDataReader reader = command.ExecuteReader();

                     while (reader.Read())
                     {
                         list.Add(CargarActividad(reader));
                     }
                 }
                 catch(Exception)
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
        /// <param name="actid"></param>
        /// <returns></returns>
        public static Actividad GetPorId(int actid)
        {

            Actividad actividad = null;
            using (NpgsqlConnection db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
            {

                NpgsqlCommand command = new NpgsqlCommand("sp_actividad_gettodoporid", db);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("act_id", actid);

                db.Open();
                NpgsqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    actividad = CargarActividad(reader);
                }

            }
           
        return actividad;
        }

    }
}
