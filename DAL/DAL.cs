using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using NpgsqlTypes;
using System.Configuration;

using System.Data;

namespace Datos
{
    public class DAL
    {

        public static NpgsqlConnection Conectar()
        {
            string cadena = ConfigurationManager.ConnectionStrings["RWORLD"].ConnectionString;
            NpgsqlConnection cnn = new NpgsqlConnection();

            cnn.ConnectionString = cadena;
            cnn.Open();
            return cnn;
        }


        /*
         * Este método ejecuta un stored procedure y devuelve un datatable.
         * recibe un sólo parametro string.
         * */
        /// <summary>
        /// Este método ejecuta un stored procedure y devuelve un datatable. Recibe un sólo parametro string.
        /// </summary>
        /// <param name="procedure">Nombre del procedimiento almacenado</param>
        /// <param name="param">Parámetro del stored procedure</param>
        /// <param name="value">Valor del parámetro (string)</param>
        /// <param name="dbString">Nombre de la base de datos</param>
        /// <returns>Datatable con resultado de store</returns>
        /// <remarks></remarks>
        public static DataTable EjecutarStoreConParametro(string procedure, string param, string value)
        {

            NpgsqlConnection db = Conectar();
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = db;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = procedure;
            NpgsqlParameter parametro = new NpgsqlParameter();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter();
            parametro.ParameterName = param;
            parametro.Direction = ParameterDirection.Input;
            parametro.NpgsqlDbType = NpgsqlDbType.Text;
            parametro.NpgsqlValue = value;
          
            cmd.Parameters.Add(parametro);
            da.SelectCommand = cmd;
            
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        /// <summary>
        /// Este método ejecuta un stored procedure y devuelve un datatable. Recibe un sólo parametro string.
        /// </summary>
        /// <param name="procedure">Nombre del procedimiento almacenado</param>
        /// <param name="param">Parámetro del stored procedure</param>
        /// <param name="value">Valor del parámetro (int)</param>
        /// <param name="dbName">Nombre de la base de datos</param>
        /// <returns>Datatable con resultado de store</returns>
        /// <remarks></remarks>
        public static DataTable EjecutarStoreConParametro(string procedure, string param, int value)
        {
            NpgsqlConnection db = Conectar();
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = db;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = procedure;
            NpgsqlParameter parametro = new NpgsqlParameter();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter();
            parametro.ParameterName = param;
            parametro.Direction = ParameterDirection.Input;
            parametro.NpgsqlDbType = NpgsqlDbType.Integer;
            parametro.NpgsqlValue = value;

            cmd.Parameters.Add(parametro);
            da.SelectCommand = cmd;

            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }


        /// <summary>
        /// Este método ejecuta un stored procedure sin parámetros y devuelve un datatable.
        /// </summary>
        /// <param name="procedure">Nombre del procedimiento almacenado</param>
        /// <param name="dbName">Nombre de la base de datos</param>
        /// <returns>Datatable con resultado de store</returns>
        /// <remarks></remarks>
        public static DataTable EjecutarStoreConsulta(string procedure)
        {
            try
            {
                NpgsqlConnection db = Conectar();
                NpgsqlDataAdapter da = new NpgsqlDataAdapter();
                NpgsqlCommand cmd = new NpgsqlCommand();
                cmd.Connection = db;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = procedure;

                da.SelectCommand = cmd;
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        /// <summary>
        /// Este método ejecuta un stored procedure con varios parámetros y devuelve un datatable.
        /// </summary>
        /// <param name="procedure">Nombre del procedimiento almacenado</param>
        /// <param name="parametros">Lista de parámetros del stored procedure</param>
        /// <param name="dbName">Nombre de la base de datos</param>
        /// <returns>Datatable con resultado de store</returns>
        /// <remarks></remarks>
        public static DataTable EjecutarStoreConsultaConParametros(string procedure, IList<NpgsqlParameter> parametros)
        {
            try
            {
                NpgsqlConnection db = Conectar();
                NpgsqlDataAdapter da = new NpgsqlDataAdapter();
                NpgsqlCommand cmd = new NpgsqlCommand();
                cmd.Connection = db;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = procedure;


                foreach (NpgsqlParameter param in parametros)
                {
                    cmd.Parameters.Add(param);
                }
                da.SelectCommand = cmd;
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


        /// <summary>
        /// Este método ejecuta un stored procedure con varios parámetros y devuelve un int que representa el Return 
        /// del stored procedure.
        /// </summary>
        /// <param name="procedure">Nombre del procedimiento almacenado</param>
        /// <param name="parametros">Lista de parámetros del stored procedure</param>
        /// <param name="dbName">Nombre de la base de datos</param>
        /// <returns>Int que contiene el Return del stored procedure</returns>
        /// <remarks></remarks>
        public static int EjecutarStoreConParametros(string procedure, IList<NpgsqlParameter> parametros)
        {
            try
            {
                NpgsqlConnection db = Conectar();
                NpgsqlDataAdapter da = new NpgsqlDataAdapter();
                NpgsqlCommand cmd = new NpgsqlCommand();
                cmd.Connection = db;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = procedure;

                foreach (NpgsqlParameter param in parametros)
                {
                    cmd.Parameters.Add(param);
                }
                NpgsqlParameter par = new NpgsqlParameter();
                par.NpgsqlDbType = NpgsqlDbType.Integer;
                par.Direction = ParameterDirection.ReturnValue;
                par.ParameterName = "@return_value";
                cmd.Parameters.Add(par);
                //db.AddParameter(cmd, "@return_value", DbType.Int32, ParameterDirection.ReturnValue, null, DataRowVersion.Default, null);
              
                int valorRetorno;
                valorRetorno = Convert.ToInt32(cmd.ExecuteScalar());
                return valorRetorno;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


        /// <summary>
        /// Este método ejecuta un stored procedure con un parámetro y devuelve un int que representa el Return 
        /// del stored procedure.
        /// </summary>
        /// <param name="procedure">Nombre del procedimiento almacenado</param>
        /// <param name="parametro">Parámetro del stored procedure (int)</param>
        /// <param name="value">Valor del parámetro</param>
        /// <param name="dbName">Nombre de la base de datos</param>
        /// <returns>Int que contiene el Return del stored procedure</returns>
        /// <remarks></remarks>
        public static int EjecutarStoreInsert(string procedure, string parametro, int value)
        {
            try
            {
                //NpgsqlConnection db = Conectar();
                NpgsqlDataAdapter da = new NpgsqlDataAdapter();
                NpgsqlCommand cmd = new NpgsqlCommand();
                //cmd.Connection = db;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = procedure;

                NpgsqlParameter par = new NpgsqlParameter();
                par.NpgsqlDbType = NpgsqlDbType.Integer;
                par.Direction = ParameterDirection.ReturnValue;
                par.ParameterName = "@return_value";
                cmd.Parameters.Add(par);

          
                int valorRetorno;
                valorRetorno = Convert.ToInt32(cmd.ExecuteScalar());
                return valorRetorno;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }



        /// <summary>
        /// Este método ejecuta un stored procedure con varios parámetros y devuelve un int que representa el Return 
        /// del stored procedure.
        /// </summary>
        /// <param name="procedure">Nombre del procedimiento almacenado</param>
        /// <param name="parametros">Parámetros del stored procedure (int)</param>
        /// <param name="dbName">Nombre de la base de datos</param>
        /// <returns>Int que contiene el Return del stored procedure</returns>
        /// <remarks></remarks>
        public static int EjecutarStoreInsert(string procedure, IList<NpgsqlParameter> parametros)
        {
            try
            {
                NpgsqlConnection db = Conectar();
                NpgsqlCommand cmd = new NpgsqlCommand();
                cmd.Connection = db;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = procedure;

                NpgsqlParameter par = new NpgsqlParameter();
                par.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer;
                par.Direction = ParameterDirection.ReturnValue;
                par.ParameterName = "return_value";
                cmd.Parameters.Add(par);

                foreach (NpgsqlParameter param in parametros)
                {
                    cmd.Parameters.Add(param);
                }

                
                int valorRetorno;
                valorRetorno = Convert.ToInt32(cmd.ExecuteScalar());
                return valorRetorno;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }



        /// <summary>
        /// Este método ejecuta un stored procedure con un parámetro y devuelve un int que representa el Return 
        /// del stored procedure.
        /// </summary>
        /// <param name="procedure">Nombre del procedimiento almacenado</param>
        /// <param name="parametro">Parámetro del stored procedure (int)</param>
        /// <param name="value">Valor del parámetro</param>
        /// <param name="dbName">Nombre de la base de datos</param>
        /// <returns>Int que contiene el Return del stored procedure</returns>
        /// <remarks></remarks>
        public static int EjecutarStoreInsertTransaccion(string procedure, string parametro, int value, NpgsqlConnection db)
        {
            try
            {
                //NpgsqlConnection db = Conectar();
                NpgsqlDataAdapter da = new NpgsqlDataAdapter();
                NpgsqlCommand cmd = new NpgsqlCommand();
                cmd.Connection = db;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = procedure;

                NpgsqlParameter par = new NpgsqlParameter();
                par.NpgsqlDbType = NpgsqlDbType.Integer;
                par.Direction = ParameterDirection.ReturnValue;
                par.ParameterName = "@return_value";
                cmd.Parameters.Add(par);


                int valorRetorno;
                valorRetorno = Convert.ToInt32(cmd.ExecuteScalar());
                return valorRetorno;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }



        /// <summary>
        /// Este método ejecuta un stored procedure con varios parámetros y devuelve un int que representa el Return 
        /// del stored procedure.
        /// </summary>
        /// <param name="procedure">Nombre del procedimiento almacenado</param>
        /// <param name="parametros">Parámetros del stored procedure (int)</param>
        /// <param name="dbName">Nombre de la base de datos</param>
        /// <returns>Int que contiene el Return del stored procedure</returns>
        /// <remarks></remarks>
        public static int EjecutarStoreInsertTransaccion(string procedure, IList<NpgsqlParameter> parametros, NpgsqlConnection db)
        {
            try
            {             
                NpgsqlCommand cmd = new NpgsqlCommand();
                cmd.Connection = db;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = procedure;

                NpgsqlParameter par = new NpgsqlParameter();
                par.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer;
                par.Direction = ParameterDirection.ReturnValue;
                par.ParameterName = "return_value";
                cmd.Parameters.Add(par);

                foreach (NpgsqlParameter param in parametros)
                {
                    cmd.Parameters.Add(param);
                }


                int valorRetorno;
                valorRetorno = Convert.ToInt32(cmd.ExecuteScalar());
                return valorRetorno;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


        /// <summary>
        /// Este método ejecuta un stored procedure con varios parámetros y devuelve un datatable.
        /// </summary>
        /// <param name="procedure">Nombre del procedimiento almacenado</param>
        /// <param name="parametros">Lista de parámetros del stored procedure</param>
        /// <param name="dbName">Nombre de la base de datos</param>
        /// <returns>Datatable con resultado de store</returns>
        /// <remarks></remarks>
        public static DataTable EjecutarStoreConsultaConParametrosTransaccion(string procedure, IList<NpgsqlParameter> parametros, NpgsqlConnection db)
        {
            try
            {               
                NpgsqlDataAdapter da = new NpgsqlDataAdapter();
                NpgsqlCommand cmd = new NpgsqlCommand();
                cmd.Connection = db;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = procedure;


                foreach (NpgsqlParameter param in parametros)
                {
                    cmd.Parameters.Add(param);
                }
                da.SelectCommand = cmd;
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


        /// <summary>
        /// Este método ejecuta un stored procedure sin parámetros y devuelve un datatable.
        /// </summary>
        /// <param name="procedure">Nombre del procedimiento almacenado</param>
        /// <param name="dbName">Nombre de la base de datos</param>
        /// <returns>Datatable con resultado de store</returns>
        /// <remarks></remarks>
        public static DataTable EjecutarStoreConsultaTransaccion(string procedure, NpgsqlConnection db)
        {
            try
            {
                NpgsqlDataAdapter da = new NpgsqlDataAdapter();
                NpgsqlCommand cmd = new NpgsqlCommand();
                cmd.Connection = db;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = procedure;

                da.SelectCommand = cmd;
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }



        /// <summary>
        /// Este método crea un SqlParameter en base al valor que se le suministra.
        /// </summary>
        /// <param name="nombre">Nombre del parámetro</param>
        /// <param name="tipo">DBType del parámetro</param>
        /// <param name="valor">Valor del parámetro</param>
        /// <returns></returns>
        public static NpgsqlParameter crearParametro(string nombre, NpgsqlDbType tipo, object valor)
        {
            try
            {
                NpgsqlParameter param = new NpgsqlParameter();
                param.ParameterName = nombre;
                param.NpgsqlDbType = tipo;
                param.NpgsqlValue = valor;
                return param;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


    }

    }

