using DAL.Interfases;
using Dapper;
using DapperExtensions;
using Entidad;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DAL.Repositories
{
    public class ServiceRepository :IServiceRepository
    {
        private NpgsqlConnection Cnn;

        public ServiceRepository()
        {

        }

        public IList<Service> FindAll()
        {
            using (Cnn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
            {
                const string query = @"SELECT * FROM service S
                                       JOIN proveedor P ON P.proid = S.proid
                                        JOIN cliente C ON C.cliid = S.cliid
                                        JOIN sucursal SU on SU.sucid = S.sucid";

                var datos = Cnn.Query<Service, Proveedor, Cliente, Sucursal, Service>
                    (query, (service, proveedor, cliente, sucursal) =>
                    {
                        service.proveedor = proveedor;
                        service.cliente = cliente;
                        service.sucursal = sucursal;

                        return service;
                    }, splitOn: "proid, cliid, sucid");

                return datos.ToList(); 
            }
            
        }

        public IQueryable<Service> Find(Expression<Func<Service, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Service FindById(int id)
        {
            Service service;
            using (Cnn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
            {
                service = Cnn.Query<Service>("SELECT * FROM service WHERE serid = @id", new { id = id }).SingleOrDefault();
            }
            return service;
        }

        public int add(Service newEntity)
        {
            NpgsqlTransaction transaccion = null;
            using (Cnn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
            {

                try
                {
                    Cnn.Open();
                    transaccion = Cnn.BeginTransaction();
                    NpgsqlCommand command = new NpgsqlCommand("sp_service_insert", Cnn);
                    command.CommandTimeout = 5 * 60;
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("pro_id", newEntity.proveedor.proid);
                    command.Parameters.AddWithValue("suc_id", newEntity.sucursal.sucid);
                    command.Parameters.AddWithValue("ser_remito", newEntity.serremito);
                    command.Parameters.AddWithValue("ess_id", newEntity.essid);
                    command.Parameters.AddWithValue("cli_id", newEntity.cliente.cliid);
                    command.Parameters.AddWithValue("ser_fecha", newEntity.serfecha);
                    command.Parameters.AddWithValue("ser_fechacompra", newEntity.serfechacompra);
                    command.Parameters.AddWithValue("ser_fotocopiaremito", newEntity.serfotocopiaremito);
                    command.Parameters.AddWithValue("ser_fotocopiafactura", newEntity.serfotocopiafactura);
                    command.Parameters.AddWithValue("ser_fajagarantia", newEntity.serfajagarantia);
                    command.Parameters.AddWithValue("ser_certfabricacion", newEntity.sercertfabricacion);
                    
                    newEntity.serid = Convert.ToInt32(command.ExecuteScalar());

                    bool correcto = true;
                    foreach (ServiceDetalle detalle in newEntity.detalle)
                    {
                        const string query = @"INSERT INTO servicedetalle (prdid, sdecantidad, sdemotivo, serid)
                                            VALUES(@prdid, @sdecantidad, @sdemotivo, @serid)";


                        int resultadodetalle = Cnn.Execute(query, new
                        {                          
                            detalle.prdid,
                            detalle.sdecantidad,
                            detalle.sdemotivo,
                            newEntity.serid,
                        });

                        if (resultadodetalle <= 0)
                        {
                            correcto = false;
                        }
                    }

                    if (correcto == true)
                    {
                        transaccion.Commit();
                    }
                    else
                    {
                        transaccion.Rollback();
                    }
                    
                }
                catch(Exception ex)
                {                    
                    transaccion.Rollback();
                    throw ex;
                }
                finally
                {
                    Cnn.Close();
                }


                return newEntity.serid;
            }
        }

        public bool remove(int id)
        {
            throw new NotImplementedException();
        }

        public int Modify(Service entity)
        {
            throw new NotImplementedException();
        }
    }
}
