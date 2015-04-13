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
    public class MovimientoDAL
    {

        public static Movimiento CargarMovimiento(NpgsqlDataReader reader)
        {
            Movimiento movimiento = new Movimiento();
            movimiento.movid = Convert.ToInt32(reader["movid"]);
            movimiento.movnombre = reader["movnombre"].ToString();

            return movimiento;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<Movimiento> GetTodo()
        {

            List<Movimiento> list = new List<Movimiento>();
            using (NpgsqlConnection db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
            {
                try
                {
                    NpgsqlCommand command = new NpgsqlCommand("sp_movimiento_obtenertodo", db);
                    command.CommandType = CommandType.StoredProcedure;
                    db.Open();
                    NpgsqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        list.Add(CargarMovimiento(reader));
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
        /// <param name="movid"></param>
        /// <returns></returns>
        public static Movimiento GetPorId(int movid)
        {
            Movimiento movimiento = new Movimiento();

            using (NpgsqlConnection db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
            {
                try
                {
                    NpgsqlCommand command = new NpgsqlCommand("sp_movimiento_getporid", db);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("mov_id", movid);
                    db.Open();

                    NpgsqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        movimiento = CargarMovimiento(reader);
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

            return movimiento;
        }

    }
}
