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
    public class ListaPrecioDAL
    {

        private static ListaPrecio CargarListaPrecio(NpgsqlDataReader reader)
        {
            ListaPrecio listaprecio = new ListaPrecio();

            listaprecio.listaprecio_denominacion = reader["listaprecio_denominacion"].ToString();
            listaprecio.estado = EstadoDAL.GetPorId(Convert.ToInt32(reader["estid"]));
            listaprecio.listaprecio_fechacreacion = Convert.ToDateTime(reader["listaprecio_fechacreacion"]);
            listaprecio.listaprecio_fechafin = Convert.ToDateTime(reader["listaprecio_fechafin"]);
            listaprecio.listaprecio_fechainicio = Convert.ToDateTime(reader["listaprecio_fechainicio"]);
            listaprecio.listaprecio_id = Convert.ToInt32(reader["listaprecio_id"]);
            listaprecio.proveedor = ProveedorDAL.GetPorId(Convert.ToInt32(reader["proid"]));

            return listaprecio;
        }


        public static ListaPrecio Crear(ListaPrecio listaprecio)
        {
            NpgsqlTransaction transaccion = null;
            using (NpgsqlConnection db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
            {
                try
                {
                    db.Open();
                    transaccion = db.BeginTransaction();
                    
                    NpgsqlCommand command = new NpgsqlCommand("sp_listaprecio_insertar", db);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("pro_id", listaprecio.proveedor.proid);
                    command.Parameters.AddWithValue("listaprecio_denominacion", listaprecio.listaprecio_denominacion);
                    command.Parameters.AddWithValue("listaprecio_fechacreacion", listaprecio.listaprecio_fechacreacion);
                    command.Parameters.AddWithValue("listaprecio_fechainicio", listaprecio.listaprecio_fechainicio);
                    command.Parameters.AddWithValue("listaprecio_fechafin", listaprecio.listaprecio_fechafin);
                    command.Parameters.AddWithValue("est_id", listaprecio.estado.estid);
                                      
                    listaprecio.listaprecio_id = Convert.ToInt32(command.ExecuteScalar());

                    List<Producto> list = ProductoDAL.GetTodosPorIdProveedor(listaprecio.proveedor);
                    foreach (Producto fila in list)
                    {
                        command.Parameters.Clear();
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandText = "sp_listaprecioproducto_insertar";
                        command.Parameters.AddWithValue("listaprecio_id", listaprecio.listaprecio_id);
                        command.Parameters.AddWithValue("prdid", fila.prdid);
                        command.Parameters.AddWithValue("listaprecioproducto_costobruto", 0);
                        command.Parameters.AddWithValue("listaprecioproducto_costoneto", 0);
                        command.Parameters.AddWithValue("listaprecioproducto_precioventa", 0);

                        int resultado = Convert.ToInt32(command.ExecuteScalar());
                    }

                    transaccion.Commit();
                }
                catch (Exception)
                {
                    listaprecio = null;
                    transaccion.Rollback();
                    throw;
                }
                finally
                {
                    db.Close();
                }

            }
            return listaprecio;
        }


        public static List<ListaPrecio> GetTodo()
        {

            List<ListaPrecio> list = new List<ListaPrecio>();
            using (NpgsqlConnection db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
            {
                try
                {
                    NpgsqlCommand command = new NpgsqlCommand("sp_listaprecio_obtenertodo", db);
                    command.CommandType = CommandType.StoredProcedure;
                    db.Open();
                    NpgsqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        list.Add(CargarListaPrecio(reader));
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


        public static List<ListaPrecio> GetTodoPorIdProveedor(Proveedor proveedor)
        {

            List<ListaPrecio> list = new List<ListaPrecio>();
            using (NpgsqlConnection db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
            {
                try
                {
                    NpgsqlCommand command = new NpgsqlCommand("sp_listaprecio_obtenertodoporidproveedor", db);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("pro_id", proveedor.proid);

                    db.Open();
                    NpgsqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        list.Add(CargarListaPrecio(reader));
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


        public static List<ListaPrecio> GetTodoPorIdProveedorVigenteActiva(Proveedor proveedor, DateTime fecha)
        {

            List<ListaPrecio> list = new List<ListaPrecio>();
            using (NpgsqlConnection db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
            {
                try
                {
                    NpgsqlCommand command = new NpgsqlCommand("sp_listaprecio_obtenertodoporidproveedorvigenteactiva", db);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("pro_id", proveedor.proid);
                    command.Parameters.AddWithValue("fecha", fecha);

                    db.Open();
                    NpgsqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        list.Add(CargarListaPrecio(reader));
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


        public static ListaPrecio GetPorId(int listaprecio_id)
        {
            ListaPrecio listaprecio = new ListaPrecio();

            using (NpgsqlConnection db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
            {
                try
                {
                    NpgsqlCommand command = new NpgsqlCommand("sp_listaprecio_getporid", db);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("listaprecio_id", listaprecio_id);
                    db.Open();

                    NpgsqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        listaprecio = CargarListaPrecio(reader);
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

            return listaprecio;
        }


        public static Boolean Modificar(ListaPrecio listaprecio)
        {
            bool resultado = false;
            using (NpgsqlConnection db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
            {
                try
                {

                    NpgsqlCommand command = new NpgsqlCommand("sp_listaprecio_modificar", db);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("pro_id", listaprecio.proveedor.proid);
                    command.Parameters.AddWithValue("listaprecio_denominacion", listaprecio.listaprecio_denominacion);
                    command.Parameters.AddWithValue("listaprecio_fechacreacion", listaprecio.listaprecio_fechacreacion);
                    command.Parameters.AddWithValue("listaprecio_fechainicio", listaprecio.listaprecio_fechainicio);
                    command.Parameters.AddWithValue("listaprecio_fechafin", listaprecio.listaprecio_fechafin);
                    command.Parameters.AddWithValue("est_id", listaprecio.estado.estid);
                    command.Parameters.AddWithValue("listaprecio_id", listaprecio.listaprecio_id);

                    db.Open();
                    int filasafectadas = Convert.ToInt32(command.ExecuteScalar());
                    if (filasafectadas > 0)
                    {
                        resultado = true;
                    }
                   
                }
                catch (Exception ex)
                {
                    return false;
                    throw;
                }
                finally
                {
                    db.Close();
                }

            }
            return resultado;
        }

    }
}
