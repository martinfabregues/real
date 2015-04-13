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
    public class VentaDAL
    {

        public static List<Venta> GetTodo()
        {
            List<Venta> list = new List<Venta>();
            using (NpgsqlConnection db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
            {
                try
                {
                    NpgsqlCommand command = new NpgsqlCommand("sp_ventas_gettodoanalisisrentabilidad", db);
                    command.CommandType = CommandType.StoredProcedure;
                    db.Open();
                    NpgsqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Venta venta = new Venta();
                        venta.ganancia = Convert.ToDouble(reader["ganancia"]);
                        venta.margenganancia = Convert.ToDouble(reader["margenganancia"]);
                        venta.remito_fecha = Convert.ToDateTime(reader["remito_fecha"]);
                        venta.remito_numero = reader["remito_numero"].ToString();
                        venta.remito_id = Convert.ToInt32(reader["remito_id"]);
                        venta.remito_importe = Convert.ToDouble(reader["remito_importe"]);
                        venta.sucnombre = reader["sucnombre"].ToString();
                        venta.totalcostosiniva = Convert.ToDouble(reader["totalcostosiniva"]);
                        venta.totalgastofinanciacion = Convert.ToDouble(reader["totalgastofinanciacion"]);
                        venta.totalprecioventateorico = Convert.ToDouble(reader["totalprecioventateorico"]);
                        venta.totalventa = Convert.ToDouble(reader["totalventa"]);
                        venta.vendedor_nombre = reader["vendedor_nombre"].ToString();
                        
                        list.Add(venta);
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

    }
}
