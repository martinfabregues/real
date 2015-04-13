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
    public class FacturaProveedorDAL
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private static FacturaProveedor CargarFacturaProveedor(NpgsqlDataReader reader)
        {
            FacturaProveedor facturaproveedor = new FacturaProveedor();

            facturaproveedor.activo = Convert.ToInt32(reader["estid"]);
            facturaproveedor.fecha = Convert.ToDateTime(reader["fapfecha"]);
            facturaproveedor.fecharecepcion = Convert.ToDateTime(reader["fapfecharecepcion"]);
            facturaproveedor.id = Convert.ToInt32(reader["fapid"]);
            facturaproveedor.importe = Convert.ToDecimal(reader["fapimporte"]);
            facturaproveedor.numero = reader["fapnumero"].ToString();
            facturaproveedor.numeroremito = reader["fapremito"].ToString();
            facturaproveedor.proveedor_id = Convert.ToInt32(reader["proid"]);
            facturaproveedor.sucursal_id = Convert.ToInt32(reader["sucid"]);
         
            return facturaproveedor;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<FacturaProveedor> GetTodo()
        {
            List<FacturaProveedor> list = new List<FacturaProveedor>();
            using (NpgsqlConnection db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
            {
                try
                {
                    NpgsqlCommand command = new NpgsqlCommand("sp_facturaproveedor_gettodo", db);
                    command.CommandType = CommandType.StoredProcedure;
                    db.Open();
                    NpgsqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        list.Add(CargarFacturaProveedor(reader));
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
        /// <param name="fapid"></param>
        /// <returns></returns>
        public static FacturaProveedor GetPorId(int fapid)
        {
            FacturaProveedor facturaproveedor = null;

            using (NpgsqlConnection db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
            {

                NpgsqlCommand command = new NpgsqlCommand("sp_facturaproveedor_gettodoporid", db);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("fap_id", fapid);

                db.Open();
                NpgsqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    facturaproveedor = CargarFacturaProveedor(reader);
                }

            }

            return facturaproveedor;          
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fapnumero"></param>
        /// <returns></returns>
        public static FacturaProveedor GetPorNumero(string fapnumero)
        {

            FacturaProveedor facturaproveedor = null;

            using (NpgsqlConnection db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
            {

                NpgsqlCommand command = new NpgsqlCommand("sp_facturaproveedor_gettodopornumero", db);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("fap_numero", fapnumero);

                db.Open();
                NpgsqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    facturaproveedor = CargarFacturaProveedor(reader);
                }

            }

            return facturaproveedor;                    
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="facturaproveedor"></param>
        /// <returns></returns>
        public static FacturaProveedor Create(FacturaProveedor facturaproveedor)
        {

            return facturaproveedor;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="facturaproveedor"></param>
        /// <returns></returns>
        public static FacturaProveedor Update(FacturaProveedor facturaproveedor)
        {

            return facturaproveedor;
        }

    }
}
