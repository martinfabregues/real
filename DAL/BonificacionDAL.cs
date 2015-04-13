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
    public class BonificacionDAL
    {

        /// <summary>
        /// Set propiedades del objeto
        /// </summary>
        /// <param name="reader">NpgsqlDataReader con datos</param>
        private static Bonificacion CargarBonificacion(NpgsqlDataReader reader)
        {
            Bonificacion bonificacion = new Bonificacion();

            bonificacion.bondescuento = Convert.ToDecimal(reader["bondescuento"]);
            bonificacion.bonfechacreacion = Convert.ToDateTime(reader["bonfechacreacion"]);
            bonificacion.bonfechafin = Convert.ToDateTime(reader["bonfechafin"]);
            bonificacion.bonfechainicio = Convert.ToDateTime(reader["bonfechainicio"]);
            bonificacion.bonid = Convert.ToInt32(reader["bonid"]);
            bonificacion.bonnombre = reader["bonnombre"].ToString();
            bonificacion.estid = Convert.ToInt32(reader["estid"]);
            bonificacion.proid = Convert.ToInt32(reader["proid"]);          

            return bonificacion;
        }

        /// <summary>
        /// Inserto una bonificacion
        /// </summary>
        /// <param name="bon">Objeto Bonificacion</param>
        /// <returns>Objeto Bonificacion</returns>
        public static Bonificacion Create(Bonificacion bonificacion)
        {
            using (NpgsqlConnection db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
            {
                try
                {
                    //inserto la bonificacion
                    NpgsqlCommand command = new NpgsqlCommand("sp_bonificacion_insertar", db);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("pro_id", bonificacion.proveedor.proid);
                    command.Parameters.AddWithValue("bon_nombre", bonificacion.bonnombre);
                    command.Parameters.AddWithValue("bon_fechacreacion", bonificacion.bonfechacreacion);
                    command.Parameters.AddWithValue("bon_fechainicio", bonificacion.bonfechainicio);
                    command.Parameters.AddWithValue("bon_fechafin", bonificacion.bonfechafin);
                    command.Parameters.AddWithValue("bon_descuento", bonificacion.bondescuento);
                    command.Parameters.AddWithValue("est_id", bonificacion.estado.estid);

                    db.Open();
                    bonificacion.bonid = Convert.ToInt32(command.ExecuteScalar());
                }
                catch (Exception)
                {
                    bonificacion = null;
                    throw;
                }
                finally
                {
                    db.Close();
                }
           
            }

            return bonificacion;
        }

        /// <summary>
        /// Modificar Bonificacion
        /// </summary>
        /// <param name="bonificacion">Objeto Bonificacion</param>
        /// <returns>Objeto Bonificacion</returns>
        public static Boolean Update(Bonificacion bonificacion)
        {
            bool resultado = false;
            using (NpgsqlConnection db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
            {
                try
                {
                    //inserto la bonificacion
                    NpgsqlCommand command = new NpgsqlCommand("sp_bonificacion_modificar", db);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("bon_id", bonificacion.bonid);
                    command.Parameters.AddWithValue("pro_id", bonificacion.proid);
                    command.Parameters.AddWithValue("bon_nombre", bonificacion.bonnombre);
                    command.Parameters.AddWithValue("bon_fechainicio", bonificacion.bonfechainicio);
                    command.Parameters.AddWithValue("bon_fechafin", bonificacion.bonfechafin);
                    command.Parameters.AddWithValue("bon_descuento", bonificacion.bondescuento);
                    command.Parameters.AddWithValue("est_id", bonificacion.estid);

                    db.Open();
                    int filasafectadas = Convert.ToInt32(command.ExecuteScalar());
                    if (filasafectadas > 0)
                    {
                        resultado = true;
                    }

                }
                catch (Exception)
                {
                    bonificacion = null;
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
        /// Obtener Bonificaciones todas
        /// </summary>
        /// <returns>ArrayList Bonificacion</returns>
        public static List<Bonificacion> GetTodo()
        {
            List<Bonificacion> list = new List<Bonificacion>();
            using (NpgsqlConnection db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
            {
                try
                {
                    NpgsqlCommand command = new NpgsqlCommand("sp_bonificacion_obtenertodo", db);
                    command.CommandType = CommandType.StoredProcedure;
                    db.Open();
                    NpgsqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        list.Add(CargarBonificacion(reader));
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
        /// Obtener Bonificaciones por Proveedor
        /// </summary>
        /// <param name="proid">Int id Proveedor</param>
        /// <returns>ArrayList tipo Bonificacion</returns>
        public static List<Bonificacion> GetPorIdProveedor(int proid)
        {
            List<Bonificacion> list = new List<Bonificacion>();
            using (NpgsqlConnection db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
            {               
                try
                {
                    NpgsqlCommand command = new NpgsqlCommand("sp_bonificacion_obtenertodoporproveedor", db);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("pro_id", proid);
                    db.Open();
                    NpgsqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                         list.Add(CargarBonificacion(reader));
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
        /// Obtiene los datos de la bonificacion
        /// </summary>
        /// <param name="bonid">Int id Bonificacion</param>
        /// <returns>Objeto Bonificacion</returns>
        public static Bonificacion GetDatosPorId(int bonid)
        {
            Bonificacion bonificacion = null;
            using (NpgsqlConnection db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
            {
                NpgsqlCommand command = new NpgsqlCommand("sp_bonificacion_obtenerdatosporid", db);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("bon_id", bonid);
                db.Open();
                NpgsqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    bonificacion = CargarBonificacion(reader);
                }
            }

            return bonificacion;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<Bonificacion> GetTodosConsulta()
        {
            List<Bonificacion> list = new List<Bonificacion>();
            using (NpgsqlConnection db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
            {
                try
                {
                    NpgsqlCommand command = new NpgsqlCommand("sp_bonificacion_getdatostodos", db);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    db.Open();

                    NpgsqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Bonificacion bonificacion = new Bonificacion();
                        bonificacion.proveedor = new Proveedor();
                        bonificacion.estado = new Estado();

                        bonificacion.bondescuento = Convert.ToDecimal(reader["bondescuento"]);
                        bonificacion.bonfechacreacion = Convert.ToDateTime(reader["bonfechacreacion"]);
                        bonificacion.bonfechafin = Convert.ToDateTime(reader["bonfechafin"]);
                        bonificacion.bonfechainicio = Convert.ToDateTime(reader["bonfechainicio"]);
                        bonificacion.bonid = Convert.ToInt32(reader["bonid"]);
                        bonificacion.bonnombre = reader["bonnombre"].ToString();
                        bonificacion.estado.estestado = reader["estestado"].ToString();
                        bonificacion.proveedor.pronombre = reader["pronombre"].ToString();
                  
                        list.Add(bonificacion);
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
        public static List<Bonificacion> GetFiltro(BonificacionCriteria filtro)
        {
            string sql = @"SELECT B.BONID, 
                                  P.PRONOMBRE, 
                                  B.BONNOMBRE, 
                                  B.BONFECHACREACION, 
                                  B.BONFECHAINICIO, 
                                  B.BONFECHAFIN, 
                                  B.BONDESCUENTO,
                                  E.ESTESTADO
                        FROM BONIFICACION B 
                        INNER JOIN PROVEEDOR P ON P.PROID = B.PROID 
                        INNER JOIN ESTADO E ON E.ESTID = B.ESTID
                        WHERE ((@bonnombre IS NULL) OR (B.BONNOMBRE LIKE '%' || @bonnombre || '%')) 
                        AND ((@proveedor IS NULL) OR (B.PROID =  @proveedor))
                        ORDER BY B.BONID ASC
                        LIMIT 40";


            List<Bonificacion> list = new List<Bonificacion>();
            using (NpgsqlConnection db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
            {
                try
                {
                    db.Open();
                    NpgsqlCommand command = new NpgsqlCommand(sql, db);

                    if (string.IsNullOrEmpty(filtro.bonnombre))
                        command.Parameters.AddWithValue("@bonnombre", DBNull.Value);
                    else
                        command.Parameters.AddWithValue("@bonnombre", filtro.bonnombre);

                    command.Parameters.AddWithValue("@proveedor", filtro.proveedor == null ? (object)DBNull.Value : filtro.proveedor.proid);

                    NpgsqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Bonificacion bonificacion = new Bonificacion();
                        bonificacion.proveedor = new Proveedor();
                        bonificacion.estado = new Estado();

                        bonificacion.bondescuento = Convert.ToDecimal(reader["bondescuento"]);
                        bonificacion.bonfechacreacion = Convert.ToDateTime(reader["bonfechacreacion"]);
                        bonificacion.bonfechafin = Convert.ToDateTime(reader["bonfechafin"]);
                        bonificacion.bonfechainicio = Convert.ToDateTime(reader["bonfechainicio"]);
                        bonificacion.bonid = Convert.ToInt32(reader["bonid"]);
                        bonificacion.bonnombre = reader["bonnombre"].ToString();
                        bonificacion.estado.estestado = reader["estestado"].ToString();
                        bonificacion.proveedor.pronombre = reader["pronombre"].ToString();

                        list.Add(bonificacion);
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
