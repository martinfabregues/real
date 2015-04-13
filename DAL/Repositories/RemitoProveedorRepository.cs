using DAL.Interfases;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;
using DapperExtensions;
using Npgsql;
using System.Configuration;
using System.Data;

namespace DAL.Repositories
{
    public interface IRemitoProveedorRepository : IRepository<RemitoProveedor>
    {
        IList<RemitoProveedor> FindAllWithSucursal();
        IList<RemitoProveedor> FindAllLikeNumero(string numero);
        int AddDetalle(RemitoProveedorDetalle detalle);
        int ActualizarPendiente(int proveedor_id, int sucursal_id, int cantidad, int producto_id , int orden_id);
    }

    public class RemitoProveedorRepository : IRemitoProveedorRepository
    {

        readonly NpgsqlConnection _cnn;

        public RemitoProveedorRepository()
        {
            _cnn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString());           
        }

        public IList<RemitoProveedor> FindAll()
        {
            using (IDbConnection _db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
            {
                return _db.Query<RemitoProveedor>("SELECT * FROM REMITOPROVEEDOR").ToList();
            }           
        }

        public IQueryable<RemitoProveedor> Find(System.Linq.Expressions.Expression<Func<RemitoProveedor, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public RemitoProveedor FindById(int id)
        {
            throw new NotImplementedException();
        }

        public int add(RemitoProveedor newEntity)
        {
            string query = "INSERT INTO " +
                            "REMITOPROVEEDOR (remitoproveedor_numero, remitoproveedor_fecha, " +
                            "remitoproveedor_fecharecepcion, sucid, proid, estid, observaciones) " +
                            "VALUES (@numero, @fecha, @recepcion, @sucursal, @proveedor, @estado, @observaciones); " + 
                            "SELECT CURRVAL('remitoproveedor_remitoproveedor_id_seq'); ";
          

            using (IDbConnection _db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
            {
               
                return _db.Query<int>(query, new 
                { numero = newEntity.numero, 
                    fecha = newEntity.fechaemision, 
                    recepcion = newEntity.fecharecepcion, 
                    sucursal = newEntity.sucursal_id, 
                    proveedor = newEntity.proveedor_id, 
                    estado = 1 ,
                    observaciones = newEntity.observaciones}).Single();
               
            }
        }

        public bool remove(int id)
        {
            throw new NotImplementedException();
        }

        public int Modify(RemitoProveedor entity)
        {
            throw new NotImplementedException();
        }

        public IList<RemitoProveedor> FindAllWithSucursal()
        {
            string query = "SELECT * FROM REMITOPROVEEDOR " +
                "INNER JOIN SUCURSAL ON SUCURSAL.SUCID = REMITOPROVEEDOR.SUCID";

            using (IDbConnection _db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
            {
                return _db.Query<RemitoProveedor, Sucursal, RemitoProveedor>(query, (remito, sucursal) => { remito.sucursal = sucursal; return remito; }, splitOn:"sucid").ToList();
            }     
        }

        public IList<RemitoProveedor> FindAllLikeNumero(string numero)
        {
            string query = "SELECT * FROM REMITOPROVEEDOR " +
              "INNER JOIN SUCURSAL ON SUCURSAL.SUCID = REMITOPROVEEDOR.SUCID " +
              "WHERE REMITOPROVEEDOR.REMITOPROVEEDOR_NUMERO LIKE '%" + numero + "%'";

            using (IDbConnection _db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
            {
                return _db.Query<RemitoProveedor, Sucursal, RemitoProveedor>(query, (remito, sucursal) => { remito.sucursal = sucursal; return remito; }, splitOn: "sucid").ToList();
            }     
        }


        public int AddDetalle(RemitoProveedorDetalle detalle)
        {
            string query = "INSERT INTO REMITOPROVEEDORDETALLE (remitoproveedor_id, prdid, cantidad, odcid) " +
                                "VALUES (@remitoproveedor_id, @producto, @cantidad, @orden)";

            using (IDbConnection _db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
            {
                
                return _db.Execute(query, new
                {
                    remitoproveedor_id = detalle.remitoproveedor_id,
                    producto = detalle.producto_id,
                    cantidad = detalle.cantidad,
                    orden = detalle.orden_id
                });
            }
        }


        public int ActualizarPendiente(int proveedor_id, int sucursal_id, int cantidad, int producto_id, int orden_id)
        {
            string queryPendiente = "UPDATE ORDENCOMPRAPENDIENTE SET OCDCANTIDAD = OCDCANTIDAD - @cantidad " +
                                   "WHERE PRDID = @producto AND ODCID = @orden AND PROID = @proveedor AND SUCID = @sucursal";

            using (IDbConnection _db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
            {
                return _db.Execute(queryPendiente, new
                {
                    cantidad = cantidad,
                    producto = producto_id,
                    orden = orden_id,
                    proveedor = proveedor_id,
                    sucursal = sucursal_id
                });
            }


           

        }
    }
}
