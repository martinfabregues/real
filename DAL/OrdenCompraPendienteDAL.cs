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
    public class OrdenCompraPendienteDAL
    {

        public static OrdenCompraPendiente CargarPendiente(NpgsqlDataReader reader)
        {
            OrdenCompraPendiente ordenpendiente = new OrdenCompraPendiente();
            ordenpendiente.espid = (Int32)reader["espid"];
            ordenpendiente.ocdcantidad = (Int32)reader["ocdcantidad"];
            ordenpendiente.ocdimporte = (Decimal)reader["ocdimporte"];
            ordenpendiente.ocpid = (Int32)reader["ocpid"];
            ordenpendiente.ordencompra = OrdenCompraDAL.GetDatosPorId(Convert.ToInt32(reader["odcid"]));
            ordenpendiente.producto = ProductoDAL.GetPorId(Convert.ToInt32(reader["prdid"]));
            ordenpendiente.proveedor = ProveedorDAL.GetPorId(Convert.ToInt32(reader["proid"]));
            ordenpendiente.sucursal = SucursalDAL.GetPorId(Convert.ToInt32(reader["sucid"]));

            return ordenpendiente;
        }


        public static List<OrdenCompraPendiente> GetTodo()
        {
            List<OrdenCompraPendiente> list = new List<OrdenCompraPendiente>();
            using (NpgsqlConnection db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
            {
                try
                {
                    NpgsqlCommand command = new NpgsqlCommand("sp_ordencomprapendiente_gettodo", db);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    db.Open();

                    NpgsqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        OrdenCompraPendiente ordenpendiente = new OrdenCompraPendiente();
                        ordenpendiente.ordencompra = new OrdenCompra();
                        ordenpendiente.sucursal = new Sucursal();
                        ordenpendiente.producto = new Producto();
                        ordenpendiente.proveedor = new Proveedor();

                        ordenpendiente.ocpid = (Int32)reader["ocpid"];
                        ordenpendiente.sucursal.sucnombre = (String)reader["sucnombre"];
                        ordenpendiente.proveedor.pronombre = (String)reader["pronombre"];
                        ordenpendiente.ordencompra.odcnumero = (String)reader["odcnumero"];
                        ordenpendiente.ordencompra.odcfecha = (DateTime)reader["odcfecha"];
                        ordenpendiente.ocdcantidad = (Int32)reader["ocdcantidad"];
                        ordenpendiente.producto.prdcodigo = (String)reader["prdcodigo"];
                        ordenpendiente.producto.prddenominacion = (String)reader["prddenominacion"];

                        list.Add(ordenpendiente);
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

        public static Boolean EliminarPendiente(int ocp_id)
        {
            bool resultado = false;
            using (NpgsqlConnection db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
            {
                try
                {
                    NpgsqlCommand command = new NpgsqlCommand("sp_pendiente_eliminar", db);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("ocp_id", ocp_id);
                    db.Open();
                    int filasafectadas = Convert.ToInt32(command.ExecuteScalar());
                    if (filasafectadas > 0)
                        resultado = true;
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
            return resultado;
        }

        public static List<OrdenCompraPendiente> GetByCriteria(OrdenCompraPendienteCriteria filtro)
        {
            string sql = @"SELECT OCP.ocpid, 
                                  S.sucnombre, 
                                  PR.pronombre, 
                                  OC.odcnumero, 
                                  OC.odcfecha, 
                                  OCP.ocdcantidad, 
                                  P.prdcodigo, 
                                  P.prddenominacion
                        FROM ORDENCOMPRAPENDIENTE OCP 
                        INNER JOIN ORDENCOMPRA OC on OC.odcid = OCP.odcid
                        INNER JOIN PRODUCTO P on P.prdid = OCP.prdid
                        INNER JOIN SUCURSAL S on S.sucid = OCP.sucid
                        INNER JOIN PROVEEDOR PR on PR.proid = OCP.proid
                        WHERE ((@producto IS NULL) OR (P.prddenominacion LIKE '%' || @producto || '%')) 
                        AND ((@proveedor IS NULL) OR (PR.proid =  @proveedor))
                        AND ((@sucursal IS NULL) OR (S.sucid =  @sucursal))
                        AND (OCP.ocdcantidad > 0 AND OCP.espid <> 2)";

            List<OrdenCompraPendiente> list = new List<OrdenCompraPendiente>();
            using (NpgsqlConnection db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
            {
                try
                {
                    db.Open();
                    NpgsqlCommand command = new NpgsqlCommand(sql, db);


                    command.Parameters.AddWithValue("@proveedor", filtro.proveedor == null ? (object)DBNull.Value : filtro.proveedor.proid);
                    command.Parameters.AddWithValue("@sucursal", filtro.sucursal == null ? (object)DBNull.Value : filtro.sucursal.sucid);
                    command.Parameters.AddWithValue("@producto", filtro.producto == null ? (object)DBNull.Value : filtro.producto.prddenominacion);

                    NpgsqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        OrdenCompraPendiente ordenpendiente = new OrdenCompraPendiente();
                        ordenpendiente.ordencompra = new OrdenCompra();
                        ordenpendiente.sucursal = new Sucursal();
                        ordenpendiente.producto = new Producto();
                        ordenpendiente.proveedor = new Proveedor();

                        ordenpendiente.ocpid = (Int32)reader["ocpid"];
                        ordenpendiente.sucursal.sucnombre = (String)reader["sucnombre"];
                        ordenpendiente.proveedor.pronombre = (String)reader["pronombre"];
                        ordenpendiente.ordencompra.odcnumero = (String)reader["odcnumero"];
                        ordenpendiente.ordencompra.odcfecha = (DateTime)reader["odcfecha"];
                        ordenpendiente.ocdcantidad = (Int32)reader["ocdcantidad"];
                        ordenpendiente.producto.prdcodigo = (String)reader["prdcodigo"];
                        ordenpendiente.producto.prddenominacion = (String)reader["prddenominacion"];

                        list.Add(ordenpendiente);
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
