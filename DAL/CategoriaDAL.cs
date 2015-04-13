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
    public class CategoriaDAL
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private static Categoria CargarCategoria(NpgsqlDataReader reader)
        {
            Categoria categoria = new Categoria();
            categoria.catid = Convert.ToInt32(reader["catid"]);
            categoria.catnombre = reader["catnombre"].ToString();            
            return categoria;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<Categoria> GetTodo()
        {
            List<Categoria> list = new List<Categoria>();
            using (NpgsqlConnection db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
            {
                try
                {
                    NpgsqlCommand command = new NpgsqlCommand("sp_categoria_obtenertodo", db);
                    command.CommandType = CommandType.StoredProcedure;
                    db.Open();
                    NpgsqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        list.Add(CargarCategoria(reader));
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
        /// <param name="catid"></param>
        /// <returns></returns>
        public static Categoria GetPorId(int catid)
        {
            Categoria categoria = new Categoria();

            using (NpgsqlConnection db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
            {
                try
                {
                    NpgsqlCommand command = new NpgsqlCommand("sp_categoria_getporid", db);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("cat_id", catid);
                    db.Open();

                    NpgsqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        categoria = CargarCategoria(reader);
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

            return categoria;
        }


    }
}
