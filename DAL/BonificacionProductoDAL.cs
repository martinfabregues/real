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
    public class BonificacionProductoDAL
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static BonificacionProducto CargarBonificacionProducto(NpgsqlDataReader reader)
        {
            BonificacionProducto bonificacionproducto = new BonificacionProducto();

            bonificacionproducto.bopid = Convert.ToInt32(reader["bopid"]);
            bonificacionproducto.bonificacion = BonificacionDAL.GetDatosPorId(Convert.ToInt32(reader["bonid"]));
            bonificacionproducto.producto = ProductoDAL.GetPorId(Convert.ToInt32(reader["prdid"]));          

            return bonificacionproducto;
        }


        /// <summary>
        /// Obtengo Bonificaciones por un producto determinado
        /// </summary>
        /// <param name="prdid">Int id de producto</param>
        /// <returns>ArrayList de tipo BonificacionProducto</returns>
        public static List<BonificacionProducto> GetPorProducto(int prdid)
        {
            List<BonificacionProducto> list = new List<BonificacionProducto>();

            using (NpgsqlConnection db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
            {
                NpgsqlCommand command = new NpgsqlCommand("sp_producto_obtenerbonificacionestodas", db);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("prd_id", prdid);
                command.Parameters.AddWithValue("fecha", DateTime.Today.Date);

                db.Open();
                NpgsqlDataReader reader = command.ExecuteReader();
                while(reader.Read())
                {
                    list.Add(CargarBonificacionProducto(reader));
                }

            }
            return list;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bonificacionproducto"></param>
        /// <returns></returns>
        public static BonificacionProducto Insertar(BonificacionProducto bonificacionproducto)
        {
            using (NpgsqlConnection db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
            {
                try
                {
                    NpgsqlCommand command = new NpgsqlCommand("sp_bonificacionproducto_insertar", db);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("bon_id", bonificacionproducto.bonid);
                    command.Parameters.AddWithValue("prd_id", bonificacionproducto.prdid);

                    db.Open();
                    bonificacionproducto.bopid = Convert.ToInt16(command.ExecuteScalar());

                }
                catch (Exception)
                {
                    bonificacionproducto = null;
                    throw;
                }
                finally
                {
                    db.Close();
                }


            }
            return bonificacionproducto;
        }

    }
}
