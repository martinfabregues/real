using Entidad;
using Entidad.Criteria;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;

namespace DAL
{
    public class ProductoDAL
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private static Producto CargarProducto(NpgsqlDataReader reader)
        {
            Producto producto = new Producto();

            producto.catid = Convert.ToInt32(reader["catid"]);
            producto.estid = Convert.ToInt32(reader["estid"]);
            producto.marid = Convert.ToInt32(reader["marid"]);
            producto.prdcodigo = reader["prdcodigo"].ToString();
            producto.prdcosto = Convert.ToDecimal(reader["prdcosto"]);
            producto.prddenominacion = reader["prddenominacion"].ToString();
            producto.prddescripcion = reader["prddescripcion"].ToString();
            producto.prdfecharegistro = Convert.ToDateTime(reader["prdfecharegistro"]);
            producto.prdgarantia = Convert.ToInt32(reader["prdgarantia"]);
            producto.prdid = Convert.ToInt32(reader["prdid"]);
            producto.prdiva = Convert.ToDecimal(reader["prdiva"]);
            producto.prdmargen = Convert.ToDecimal(reader["prdmargen"]);
            producto.prdmetros = Convert.ToDecimal(reader["prdmetros"]);
            producto.proid = Convert.ToInt32(reader["proid"]);
            producto.categoria = CategoriaDAL.GetPorId(producto.catid);
            producto.marca = MarcaDAL.GetPorId(producto.marid);
            producto.estado = EstadoDAL.GetPorId(producto.estid);
            producto.proveedor = ProveedorDAL.GetPorId(producto.proid);
            producto.prdflete = Convert.ToDouble(reader["prdflete"]);
            producto.prdingbrutos = Convert.ToDouble(reader["prdingbrutos"]);

            return producto;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="producto"></param>
        /// <returns></returns>
        public static Producto Create(Producto producto, ListaPrecioProducto listaproducto)
        {
            NpgsqlTransaction transaccion = null;
            using (NpgsqlConnection db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
            {
                try
                {
                    db.Open();
                    transaccion = db.BeginTransaction();

                    NpgsqlCommand command = new NpgsqlCommand("sp_producto_insertar", db);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("prodenominacion", producto.prddenominacion);
                    command.Parameters.AddWithValue("catid", producto.categoria.catid);
                    command.Parameters.AddWithValue("proid", producto.proveedor.proid);
                    command.Parameters.AddWithValue("marid", producto.marca.marid);
                    command.Parameters.AddWithValue("prdfecharegistro", producto.prdfecharegistro);
                    command.Parameters.AddWithValue("prdgarantia", producto.prdgarantia);
                    command.Parameters.AddWithValue("prdcosto", producto.prdcosto);
                    command.Parameters.AddWithValue("prdmargen", producto.prdmargen);
                    command.Parameters.AddWithValue("prddescripcion", producto.prddescripcion);
                    command.Parameters.AddWithValue("estid", producto.estado.estid);
                    command.Parameters.AddWithValue("prdiva", producto.prdiva);
                    command.Parameters.AddWithValue("prd_metros", producto.prdmetros);
                    command.Parameters.AddWithValue("prd_flete", producto.prdflete);
                    command.Parameters.AddWithValue("prd_ingbrutos", producto.prdingbrutos);

                    //db.Open();
                    producto.prdid = Convert.ToInt32(command.ExecuteScalar());


                    command.Parameters.Clear();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "sp_listaprecioproducto_existe";
                    command.Parameters.AddWithValue("prd_id", producto.prdid);
                    command.Parameters.AddWithValue("listaprecio_id", listaproducto.listaprecio.listaprecio_id);

                    int existe = Convert.ToInt32(command.ExecuteScalar());
                    if (existe == 0)
                    {

                        //INSERTAR LISTAPRECIOPRODUCTO
                        command.Parameters.Clear();
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandText = "sp_listaprecioproducto_insertar";
                        command.Parameters.AddWithValue("listaprecio_id", listaproducto.listaprecio.listaprecio_id);
                        command.Parameters.AddWithValue("prdid", producto.prdid);
                        command.Parameters.AddWithValue("listaprecioproducto_costobruto", listaproducto.listaprecioproducto_costobruto);
                        command.Parameters.AddWithValue("listaprecioproducto_costoneto", listaproducto.listaprecioproducto_costoneto);
                        command.Parameters.AddWithValue("listaprecioproducto_precioventa", listaproducto.listaprecioproducto_precioventa);

                        listaproducto.listaprecioproducto_id = Convert.ToInt32(command.ExecuteScalar());
                    }
                    else
                    {
                        //UPDATE
                        command.Parameters.Clear();
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandText = "sp_listaprecioproducto_actualizar";
                        command.Parameters.AddWithValue("listaprecio_id", listaproducto.listaprecio.listaprecio_id);
                        command.Parameters.AddWithValue("prdid", producto.prdid);
                        command.Parameters.AddWithValue("listaprecioproducto_costobruto", listaproducto.listaprecioproducto_costobruto);
                        command.Parameters.AddWithValue("listaprecioproducto_costoneto", listaproducto.listaprecioproducto_costoneto);
                        command.Parameters.AddWithValue("listaprecioproducto_precioventa", listaproducto.listaprecioproducto_precioventa);

                        int filasActualizadas = Convert.ToInt32(command.ExecuteScalar());
                        if (filasActualizadas == 0)
                        {
                            transaccion.Rollback();
                            producto = null;
                        }
                    }

                    transaccion.Commit();
                }
                catch (Exception)
                {
                    transaccion.Rollback();
                    producto = null;
                    throw;
                }
                finally
                {
                    db.Close();
                }

            }
            return producto;
        }

        /// <summary>
        /// Actualizar una orden de compra
        /// </summary>
        /// <param name="ordencompra"></param>
        /// <returns></returns>
        public static Boolean Update(Producto producto, ListaPrecioProducto listaproducto)
        {
            bool resultado = true;
            NpgsqlTransaction transaccion = null;
                using (NpgsqlConnection db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
                {
                    try
                    {
                        db.Open();
                        transaccion = db.BeginTransaction();
                        //actualizo el producto
                        NpgsqlCommand command = new NpgsqlCommand("sp_producto_actualizar", db);
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("prd_id", producto.prdid);
                        command.Parameters.AddWithValue("prd_denominacion", producto.prddenominacion);
                        command.Parameters.AddWithValue("catid", producto.categoria.catid);
                        command.Parameters.AddWithValue("proid", producto.proveedor.proid);
                        command.Parameters.AddWithValue("marid", producto.marca.marid);
                        command.Parameters.AddWithValue("prdfecharegistro", producto.prdfecharegistro);
                        command.Parameters.AddWithValue("prdgarantia", producto.prdgarantia);
                        command.Parameters.AddWithValue("prdcosto", producto.prdcosto);
                        command.Parameters.AddWithValue("prdmargen", producto.prdmargen);
                        command.Parameters.AddWithValue("prddescripcion", producto.prddescripcion);
                        command.Parameters.AddWithValue("estid", producto.estado.estid);
                        command.Parameters.AddWithValue("prdiva", producto.prdiva);
                        command.Parameters.AddWithValue("prd_metros", producto.prdmetros);
                        command.Parameters.AddWithValue("prd_flete", producto.prdflete);
                        command.Parameters.AddWithValue("prd_ingbrutos", producto.prdingbrutos);

                        int filasAfectadas = Convert.ToInt32(command.ExecuteScalar());

                        command.Parameters.Clear();
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandText = "sp_listaprecioproducto_existe";
                        command.Parameters.AddWithValue("prd_id", producto.prdid);
                        command.Parameters.AddWithValue("listaprecio_id", listaproducto.listaprecio.listaprecio_id);

                        int existe = Convert.ToInt32(command.ExecuteScalar());
                        if (existe == 0)
                        {

                            //INSERTAR LISTAPRECIOPRODUCTO
                            command.Parameters.Clear();
                            command.CommandType = CommandType.StoredProcedure;
                            command.CommandText = "sp_listaprecioproducto_insertar";
                            command.Parameters.AddWithValue("listaprecio_id", listaproducto.listaprecio.listaprecio_id);
                            command.Parameters.AddWithValue("prdid", producto.prdid);
                            command.Parameters.AddWithValue("listaprecioproducto_costobruto", listaproducto.listaprecioproducto_costobruto);
                            command.Parameters.AddWithValue("listaprecioproducto_costoneto", listaproducto.listaprecioproducto_costoneto);
                            command.Parameters.AddWithValue("listaprecioproducto_precioventa", listaproducto.listaprecioproducto_precioventa);

                            listaproducto.listaprecioproducto_id = Convert.ToInt32(command.ExecuteScalar());
                        }
                        else
                        {
                            //UPDATE
                            command.Parameters.Clear();
                            command.CommandType = CommandType.StoredProcedure;
                            command.CommandText = "sp_listaprecioproducto_actualizar";
                            command.Parameters.AddWithValue("listaprecio_id", listaproducto.listaprecio.listaprecio_id);
                            command.Parameters.AddWithValue("prdid", producto.prdid);
                            command.Parameters.AddWithValue("listaprecioproducto_costobruto", listaproducto.listaprecioproducto_costobruto);
                            command.Parameters.AddWithValue("listaprecioproducto_costoneto", listaproducto.listaprecioproducto_costoneto);
                            command.Parameters.AddWithValue("listaprecioproducto_precioventa", listaproducto.listaprecioproducto_precioventa);

                            int filasActualizadas = Convert.ToInt32(command.ExecuteScalar());
                            if (filasActualizadas == 0)
                            {
                                transaccion.Rollback();
                                return false;
                            }
                        }


                        transaccion.Commit();
                    }
                    catch (Exception)
                    {
                        producto = null;
                        transaccion.Rollback();
                        throw;
                    }
                    finally
                    {
                        db.Close();
                    }


                }
            
            return resultado;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<Producto> GetTodos()
        {
            List<Producto> list = new List<Producto>();
            
            using (NpgsqlConnection db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
            {
                try
                {
                    NpgsqlCommand command = new NpgsqlCommand("sp_producto_gettodo", db);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    db.Open();

                    NpgsqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Producto producto = new Producto();
                        producto.catid = Convert.ToInt32(reader["catid"]);
                        producto.estid = Convert.ToInt32(reader["estid"]);
                        producto.marid = Convert.ToInt32(reader["marid"]);
                        producto.prdcodigo = reader["prdcodigo"].ToString();
                        producto.prdcosto = Convert.ToDecimal(reader["prdcosto"]);
                        producto.prddenominacion = reader["prddenominacion"].ToString();
                        producto.prddescripcion = reader["prddescripcion"].ToString();
                        producto.prdfecharegistro = Convert.ToDateTime(reader["prdfecharegistro"]);
                        producto.prdgarantia = Convert.ToInt32(reader["prdgarantia"]);
                        producto.prdid = Convert.ToInt32(reader["prdid"]);
                        producto.prdiva = Convert.ToDecimal(reader["prdiva"]);
                        producto.prdmargen = Convert.ToDecimal(reader["prdmargen"]);
                        producto.prdmetros = Convert.ToDecimal(reader["prdmetros"]);
                        producto.proid = Convert.ToInt32(reader["proid"]);

                        list.Add(producto);
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
        /// <returns></returns>
        public static List<Producto> GetTodosConsulta()
        {
            List<Producto> list = new List<Producto>();
            using (NpgsqlConnection db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
            {
                try
                {
                    NpgsqlCommand command = new NpgsqlCommand("SP_PRODUCTO_GETTODOCONSULTA", db);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    db.Open();

                    NpgsqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Producto producto = new Producto();
                        producto.proveedor = new Proveedor();
                        producto.categoria = new Categoria();
                        producto.estado = new Estado();
                        producto.marca = new Marca();

                        producto.prdcodigo = reader["PRDCODIGO"].ToString();
                        producto.prdcosto = Convert.ToDecimal(reader["PRDCOSTO"]);
                        producto.prddenominacion = reader["PRDDENOMINACION"].ToString();
                        producto.prdid = Convert.ToInt32(reader["PRDID"]);
                        producto.prdmetros = Convert.ToDecimal(reader["PRDMETROS"]);

                        //REVISAR
                        //producto.prdcostoneto = CalcularCostoNeto(producto);

                        producto.proveedor.proid = Convert.ToInt32(reader["PROID"]);
                        producto.proveedor.pronombre = reader["PRONOMBRE"].ToString();
                        producto.marca.mardenominacion = reader["MARDENOMINACION"].ToString();
                        producto.categoria.catnombre = reader["CATNOMBRE"].ToString();
                        producto.estado.estid = Convert.ToInt32(reader["ESTID"]);
                        producto.estado.estestado = reader["ESTESTADO"].ToString();

                        list.Add(producto);
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
        /// <param name="filtro"></param>
        /// <returns></returns>
        public static List<Producto> GetFiltro(ProductoCriteria filtro)       
        {
            string sql = @"SELECT P.PRDID, 
                                  PRO.PRONOMBRE, 
                                  M.MARDENOMINACION, 
                                  C.CATNOMBRE, 
                                  P.PRDCODIGO, 
                                  P.PRDDENOMINACION, 
                                  P.PRDCOSTO, 
                                  P.PRDMETROS, 
                                  E.ESTESTADO
                        FROM PRODUCTO P 
                        INNER JOIN PROVEEDOR PRO ON PRO.PROID = P.PROID 
                        INNER JOIN MARCA M ON M.MARID = P.MARID
                        INNER JOIN CATEGORIA C ON C.CATID = P.CATID
                        INNER JOIN ESTADO E ON E.ESTID = P.ESTID
                        WHERE ((@prddenominacion IS NULL) OR (P.PRDDENOMINACION LIKE '%' || @prddenominacion || '%')) 
                        AND ((@proveedor IS NULL) OR (P.PROID =  @proveedor))
                        ORDER BY P.PRDCODIGO ASC
                        LIMIT 40";


            List<Producto> list = new List<Producto>();
            using (NpgsqlConnection db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
            {
                try
                {
                    db.Open();
                    NpgsqlCommand command = new NpgsqlCommand(sql, db);

                    if (string.IsNullOrEmpty(filtro.prddenominacion))
                        command.Parameters.AddWithValue("@prddenominacion", DBNull.Value);
                    else
                        command.Parameters.AddWithValue("@prddenominacion", filtro.prddenominacion);

                    command.Parameters.AddWithValue("@proveedor", filtro.proveedor == null ? (object)DBNull.Value: filtro.proveedor.proid);

                    NpgsqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Producto producto = new Producto();
                        producto.proveedor = new Proveedor();
                        producto.categoria = new Categoria();
                        producto.estado = new Estado();
                        producto.marca = new Marca();

                        producto.prdcodigo = reader["PRDCODIGO"].ToString();
                        producto.prdcosto = Convert.ToDecimal(reader["PRDCOSTO"]);
                        producto.prddenominacion = reader["PRDDENOMINACION"].ToString();
                        producto.prdid = Convert.ToInt32(reader["PRDID"]);
                        producto.prdmetros = Convert.ToDecimal(reader["PRDMETROS"]);

                        producto.proveedor.pronombre = reader["PRONOMBRE"].ToString();
                        producto.marca.mardenominacion = reader["MARDENOMINACION"].ToString();
                        producto.categoria.catnombre = reader["CATNOMBRE"].ToString();
                        producto.estado.estestado = reader["ESTESTADO"].ToString();

                        list.Add(producto);
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
        /// <param name="proid"></param>
        /// <returns></returns>
        public static Producto GetPorId(int proid)
        {
            Producto producto = new Producto();
            using (NpgsqlConnection db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
            {
                
                try
                {
                    NpgsqlCommand command = new NpgsqlCommand("sp_producto_obtenerporid", db);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("id", proid);
                    db.Open();

                    NpgsqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        producto = CargarProducto(reader);
                    }
                    else
                    {
                        producto = null;
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
            return producto;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="prdcodigo"></param>
        /// <returns></returns>
        public static Producto GetPorCodigo(string prdcodigo)
        {
            Producto producto = new Producto();
            using (NpgsqlConnection db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
            {

                try
                {
                    NpgsqlCommand command = new NpgsqlCommand("SP_PRODUCTO_GETPORCODIGO", db);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("prd_codigo", prdcodigo);
                    db.Open();

                    NpgsqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        producto = CargarProducto(reader);
                    }
                    else
                    {
                        producto = null;
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
            return producto;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="prdid"></param>
        /// <returns></returns>
        public static Double CalcularCostoNeto(Producto producto)
        {
            Double precioNeto = 0;
            try
            {
                List<BonificacionProducto> list = BonificacionProductoDAL.GetPorProducto(producto.prdid);
                if (list.Count > 0)
                {
                    double total = 100;
                    foreach (BonificacionProducto fila in list)
                    {
                        total = total * Convert.ToDouble(fila.bonificacion.bondescuento);
                    }
                    precioNeto = Math.Round((Convert.ToDouble(producto.prdcosto) * total)/100, 2);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return precioNeto;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="proveedor"></param>
        /// <returns></returns>
        public static List<Producto> GetTodosPorIdProveedor(Proveedor proveedor)
        {
            List<Producto> list = new List<Producto>();
            using (NpgsqlConnection db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
            {
                try
                {
                    NpgsqlCommand command = new NpgsqlCommand("sp_producto_gettodoporidproveedor", db);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("pro_id", proveedor.proid);
                    db.Open();

                    NpgsqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        list.Add(CargarProducto(reader));
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
