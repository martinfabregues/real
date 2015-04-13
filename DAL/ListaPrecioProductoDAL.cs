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
    public class ListaPrecioProductoDAL
    {

        public static ListaPrecioProducto CargarListaPrecioProducto(NpgsqlDataReader reader)
        {
            ListaPrecioProducto listaproducto = new ListaPrecioProducto();
            listaproducto.listaprecio = ListaPrecioDAL.GetPorId(Convert.ToInt32(reader["listaprecio_id"]));
            listaproducto.listaprecioproducto_costobruto = Convert.ToDouble(reader["listaprecioproducto_costobruto"]);
            listaproducto.listaprecioproducto_costoneto = Convert.ToDouble(reader["listaprecioproducto_costoneto"]);
            listaproducto.listaprecioproducto_precioventa = Convert.ToDouble(reader["listaprecioproducto_precioventa"]);
            listaproducto.producto = ProductoDAL.GetPorId(Convert.ToInt32(reader["prdid"]));
            
            return listaproducto;
        }

        public static ListaPrecioProducto GetListaProducto(ListaPrecio listaprecio, Producto producto)
        {
            ListaPrecioProducto listaproducto = new ListaPrecioProducto();

            using (NpgsqlConnection db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
            {
                try
                {
                    NpgsqlCommand command = new NpgsqlCommand("sp_listaprecioproducto_getporidlistaproducto", db);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("listaprecio_id", listaprecio.listaprecio_id);
                    command.Parameters.AddWithValue("prd_id", producto.prdid);
                    db.Open();

                    NpgsqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        listaproducto = CargarListaPrecioProducto(reader);
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

            return listaproducto;

        }


        public static List<ListaPrecioProducto> GetTodoPorIdLista(int listaprecio_id)
        {
            
            List<ListaPrecioProducto> list = new List<ListaPrecioProducto>();
            using (NpgsqlConnection db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
            {
                try
                {
                    NpgsqlCommand command = new NpgsqlCommand("sp_listaprecioproducto_obtenerdatosporidlista", db);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id", listaprecio_id);
                    db.Open();
                    NpgsqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        ListaPrecioProducto lista = new ListaPrecioProducto();
                        lista.listaprecio = new ListaPrecio();
                        lista.producto = new Producto();
                        lista.listaprecioproducto_id = Convert.ToInt32(reader["listaprecioproducto_id"]);
                        lista.listaprecio.listaprecio_denominacion = reader["listaprecio_denominacion"].ToString();
                        lista.producto.prddenominacion = reader["prddenominacion"].ToString();
                        lista.listaprecioproducto_costobruto = Convert.ToDouble(reader["listaprecioproducto_costobruto"]);
                        lista.listaprecioproducto_costoneto = Convert.ToDouble(reader["listaprecioproducto_costoneto"]);
                        lista.listaprecioproducto_precioventa = Convert.ToDouble(reader["listaprecioproducto_precioventa"]);

                        list.Add(lista);
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



        public static ListaPrecioProducto GetProductoPrecioVigente(Producto producto)
        {
            ListaPrecioProducto listaproducto = new ListaPrecioProducto();

            using (NpgsqlConnection db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
            {
                try
                {
                    NpgsqlCommand command = new NpgsqlCommand("sp_listaprecioproducto_getpreciovigenteporidproducto", db);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("prd_id", producto.prdid);
                    db.Open();

                    NpgsqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        listaproducto = CargarListaPrecioProducto(reader);
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
            return listaproducto;
        }


        public static Boolean ActualizarCostos(DataTable datos)
        {
            string query = @"UPDATE listaprecioproducto SET listaprecioproducto_costobruto = @costobruto,
                             listaprecioproducto_costoneto = @costoneto, listaprecioproducto_precioventa = @precioventa
                            WHERE listaprecioproducto_id = @id";
            bool resultado = false;
            NpgsqlTransaction transaccion = null ;
            try
            {

                using (NpgsqlConnection db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
                {

                    db.Open();
                    transaccion = db.BeginTransaction();

                    foreach (DataRow row in datos.Rows)
                    {
                        NpgsqlCommand command = new NpgsqlCommand(query, db);
                        command.Parameters.AddWithValue("@costobruto", row.ItemArray[3]);
                        command.Parameters.AddWithValue("@costoneto", row.ItemArray[4]);
                        command.Parameters.AddWithValue("@precioventa", row.ItemArray[5]);
                        command.Parameters.AddWithValue("@id", row.ItemArray[0]);
                        int filasAfectadas = Convert.ToInt32(command.ExecuteNonQuery());
                        if (filasAfectadas > 0)
                            resultado = true;
                    }
                    transaccion.Commit();
                }
            }
            catch (Exception)
            {
                transaccion.Rollback();
                resultado = false;
            }

            return resultado;
        }

    }
}
