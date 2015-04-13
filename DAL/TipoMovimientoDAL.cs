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
    public class TipoMovimientoDAL
    {
        public static TipoMovimiento CargarTipoMovimiento(NpgsqlDataReader reader)
        {
            TipoMovimiento tipomovimiento = new TipoMovimiento();
            tipomovimiento.tmoid = Convert.ToInt32(reader["tmoid"]);
            tipomovimiento.tmotipo = reader["tmotipo"].ToString();

            return tipomovimiento;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<TipoMovimiento> GetTodo()
        {

            List<TipoMovimiento> list = new List<TipoMovimiento>();
            using (NpgsqlConnection db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
            {
                try
                {
                    NpgsqlCommand command = new NpgsqlCommand("sp_tipomovimiento_obtenertodo", db);
                    command.CommandType = CommandType.StoredProcedure;
                    db.Open();
                    NpgsqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        list.Add(CargarTipoMovimiento(reader));
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


        public static TipoMovimiento GetPorId(int tmoid)
        {
            TipoMovimiento tipomovimiento = new TipoMovimiento();

            using (NpgsqlConnection db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
            {
                try
                {
                    NpgsqlCommand command = new NpgsqlCommand("sp_tipomovimiento_getporid", db);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("tmo_id", tmoid);
                    db.Open();

                    NpgsqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        tipomovimiento = CargarTipoMovimiento(reader);
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

            return tipomovimiento;
        }

    }
}
