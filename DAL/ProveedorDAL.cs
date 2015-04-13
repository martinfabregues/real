using Entidad;
using Entidad.Criteria;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace DAL
{
    public class ProveedorDAL
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static Proveedor CargarProveedor(NpgsqlDataReader reader)
        {
            Proveedor proveedor = new Proveedor();

            proveedor.actid = Convert.ToInt32(reader["actid"]);
            proveedor.locid = Convert.ToInt32(reader["locid"]);
            proveedor.probarrio = reader["probarrio"].ToString();
            proveedor.procodigo = reader["procodigo"].ToString();
            proveedor.procodpostal = reader["procodpostal"].ToString();
            proveedor.procuit = reader["procuit"].ToString();
            proveedor.prodireccion = reader["prodireccion"].ToString();
            proveedor.proemail = reader["proemail"].ToString();
            proveedor.proid = Convert.ToInt32(reader["proid"]);
            proveedor.proingbrutos = reader["proingbrutos"].ToString();
            proveedor.proingbrutostributo = Convert.ToDouble(reader["proingbrutostributo"]);
            proveedor.pronombre = reader["pronombre"].ToString();
            proveedor.prorazonsocial = reader["prorazonsocial"].ToString();
            proveedor.protelefono = reader["protelefono"].ToString();
            proveedor.tpiid = Convert.ToInt32(reader["tpiid"]);

            return proveedor;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pro"></param>
        /// <returns></returns>
        public static Proveedor Create(Proveedor proveedor)
        {

            using (NpgsqlConnection db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
            {
                try
                {
                    NpgsqlCommand command = new NpgsqlCommand("sp_proveedor_insertar", db);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("p_rs", proveedor.prorazonsocial);
                    command.Parameters.AddWithValue("p_n", proveedor.pronombre);
                    command.Parameters.AddWithValue("p_d", proveedor.prodireccion);
                    command.Parameters.AddWithValue("p_b", proveedor.probarrio);
                    command.Parameters.AddWithValue("p_cp", proveedor.procodpostal);
                    command.Parameters.AddWithValue("l_locid", proveedor.locid);
                    command.Parameters.AddWithValue("p_tel", proveedor.protelefono);
                    command.Parameters.AddWithValue("p_tpi", proveedor.tpiid);
                    command.Parameters.AddWithValue("p_cuit", proveedor.procuit);
                    command.Parameters.AddWithValue("p_ingb", proveedor.proingbrutos);
                    command.Parameters.AddWithValue("a_act", proveedor.actid);
                    command.Parameters.AddWithValue("p_email", proveedor.proemail);
                    command.Parameters.AddWithValue("p_tributo", proveedor.proingbrutostributo);

                    NpgsqlParameter return_value = new NpgsqlParameter("return_value", NpgsqlTypes.NpgsqlDbType.Integer);
                    return_value.Direction = System.Data.ParameterDirection.Output;
                    command.Parameters.Add(return_value);

                    db.Open();
                    int filasAfectadas = Convert.ToInt32(command.ExecuteScalar());

                    if (filasAfectadas > 0)
                    {
                        proveedor.proid = Convert.ToInt32(command.Parameters["return_value"].Value);
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
                finally
                {
                    db.Close();
                }
            }

            return proveedor;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="proveedor"></param>
        /// <returns></returns>
        public static Boolean Update(Proveedor proveedor)
        {
            bool resultado = false;
            using (NpgsqlConnection db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
            {
                try
                {
                    NpgsqlCommand command = new NpgsqlCommand("sp_proveedor_actualizar", db);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("p_rs", proveedor.prorazonsocial);
                    command.Parameters.AddWithValue("p_n", proveedor.pronombre);
                    command.Parameters.AddWithValue("p_d", proveedor.prodireccion);
                    command.Parameters.AddWithValue("p_b", proveedor.probarrio);
                    command.Parameters.AddWithValue("p_cp", proveedor.procodpostal);
                    command.Parameters.AddWithValue("l_locid", proveedor.locid);
                    command.Parameters.AddWithValue("p_tel", proveedor.protelefono);
                    command.Parameters.AddWithValue("p_tpi", proveedor.tpiid);
                    command.Parameters.AddWithValue("p_cuit", proveedor.procuit);
                    command.Parameters.AddWithValue("p_ingb", proveedor.proingbrutos);
                    command.Parameters.AddWithValue("a_act", proveedor.actid);
                    command.Parameters.AddWithValue("p_email", proveedor.proemail);
                    command.Parameters.AddWithValue("pro_id", proveedor.proid);
                    command.Parameters.AddWithValue("p_tributo", proveedor.proingbrutostributo);

                    NpgsqlParameter return_value = new NpgsqlParameter("return_value", NpgsqlTypes.NpgsqlDbType.Integer);
                    return_value.Direction = System.Data.ParameterDirection.Output;
                    command.Parameters.Add(return_value);

                    db.Open();
                    int filasAfectadas = Convert.ToInt32(command.ExecuteScalar());

                    if (filasAfectadas > 0)
                        resultado = true;
                    
                }
                catch (Exception ex)
                {
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
        public static List<Proveedor> GetTodos()
        {
            List<Proveedor> list = new List<Proveedor>();
            using (NpgsqlConnection db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
            {
                try
                {
                    NpgsqlCommand command = new NpgsqlCommand("sp_proveedor_obtenertodo", db);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    db.Open();

                    NpgsqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        list.Add(CargarProveedor(reader));
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
        /// <param name="pronombre"></param>
        /// <returns></returns>
        public static List<Proveedor> GetLikeNombre(string pronombre)
        {
            List<Proveedor> list = new List<Proveedor>();
            using (NpgsqlConnection db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
            {
                try
                {
                    NpgsqlCommand command = new NpgsqlCommand("sp_proveedor_gettodopornombre", db);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("pro_nombre", pronombre);
                    db.Open();

                    NpgsqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        list.Add(CargarProveedor(reader));
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
        public static Proveedor GetPorId(int proid)
        {
            Proveedor proveedor = new Proveedor();

            using (NpgsqlConnection db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
            {
                try
                {
                    NpgsqlCommand command = new NpgsqlCommand("sp_proveedor_getporid", db);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("pro_id", proid);
                    db.Open();

                    NpgsqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        proveedor = CargarProveedor(reader);
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

            return proveedor;
        }


        public static List<Proveedor> GetFiltro(ProveedorCriteria filtro)
        {
            string sql = @"SELECT P.PROID, 
                                  P.PROCODIGO, 
                                  P,PRORAZONSOCIAL, 
                                  P.PRONOMBRE, 
                                  P.PRODIRECCION, 
                                  P.PROBARRIO, 
                                  P.PROCODPOSTAL, 
                                  P.LOCID, 
                                  P.PROTELEFONO,
                                  P.TPIID,
                                  P.PROCUIT,
                                  P.PROINGBRUTOS,
                                  P.ACTID,
                                  P.PROEMAIL,
                                  P.PROINGBRUTOSTRIBUTO
                        FROM PROVEEDOR P
                        WHERE ((@pronombre IS NULL) OR (P.PRONOMBRE LIKE '%' || @pronombre || '%'))
                        ORDER BY P.PROID ASC
                        LIMIT 40";


            List<Proveedor> list = new List<Proveedor>();
            using (NpgsqlConnection db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
            {
                try
                {
                    db.Open();
                    NpgsqlCommand command = new NpgsqlCommand(sql, db);

                    if (string.IsNullOrEmpty(filtro.pronombre))
                        command.Parameters.AddWithValue("@pronombre", DBNull.Value);
                    else
                        command.Parameters.AddWithValue("@pronombre", filtro.pronombre);

                  

                    NpgsqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {                        
                        list.Add(CargarProveedor(reader));
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
