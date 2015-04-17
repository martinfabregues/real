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
        int AddDetalle(RemitoProveedorDetalle detalle, NpgsqlConnection _db, NpgsqlTransaction tx);
        int ActualizarPendiente(int proveedor_id, int sucursal_id, int cantidad, int producto_id , int orden_id, NpgsqlConnection _db, NpgsqlTransaction tx);
        int Add(RemitoProveedor remito, NpgsqlConnection _db, NpgsqlTransaction tx);
        IList<RemitoProveedorDetalle> FindIngresos();
        IList<RemitoProveedorDetalle> FindIngresosCondicional(string remito_numero, string producto, int? proveedor_id, int? sucursal_id, DateTime? desde, DateTime? hasta);
        IList<RemitoProveedor> FindAllByIdFactura(int factura_id);
        IList<RemitoProveedor> FindAllSinFactura();
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


        public int AddDetalle(RemitoProveedorDetalle detalle, NpgsqlConnection _db, NpgsqlTransaction tx)
        {
            string query = "INSERT INTO REMITOPROVEEDORDETALLE (remitoproveedor_id, prdid, cantidad, odcid) " +
                                "VALUES (@remitoproveedor_id, @producto, @cantidad, @orden)";
                
                return _db.Execute(query, new
                {
                    remitoproveedor_id = detalle.remitoproveedor_id,
                    producto = detalle.producto_id,
                    cantidad = detalle.cantidad,
                    orden = detalle.orden_id
                }, tx);
            
        }


        public int ActualizarPendiente(int proveedor_id, int sucursal_id, int cantidad, int producto_id, int orden_id, NpgsqlConnection _db, NpgsqlTransaction tx)
        {
            string queryPendiente = "UPDATE ORDENCOMPRAPENDIENTE SET OCDCANTIDAD = OCDCANTIDAD - @cantidad " +
                                   "WHERE PRDID = @producto AND ODCID = @orden AND PROID = @proveedor AND SUCID = @sucursal";

                return _db.Execute(queryPendiente, new
                {
                    cantidad = cantidad,
                    producto = producto_id,
                    orden = orden_id,
                    proveedor = proveedor_id,
                    sucursal = sucursal_id
                }, tx);
                 
        }


        public int Add(RemitoProveedor remito, NpgsqlConnection _db, NpgsqlTransaction tx)
        {
            string query = "INSERT INTO " +
                           "REMITOPROVEEDOR (remitoproveedor_numero, remitoproveedor_fecha, " +
                           "remitoproveedor_fecharecepcion, sucid, proid, estid, observaciones) " +
                           "VALUES (@numero, @fecha, @recepcion, @sucursal, @proveedor, @estado, @observaciones); " +
                           "SELECT CURRVAL('remitoproveedor_remitoproveedor_id_seq'); ";

                return _db.Query<int>(query, new
                {
                    numero = remito.numero,
                    fecha = remito.fechaemision,
                    recepcion = remito.fecharecepcion,
                    sucursal = remito.sucursal_id,
                    proveedor = remito.proveedor_id,
                    estado = 1,
                    observaciones = remito.observaciones
                }, tx).Single();

            
        }


        public IList<RemitoProveedorDetalle> FindIngresos()
        {
            string query = "SELECT * FROM REMITOPROVEEDORDETALLE " +
                "INNER JOIN REMITOPROVEEDOR ON REMITOPROVEEDOR.REMITOPROVEEDOR_ID = " +
                "REMITOPROVEEDORDETALLE.REMITOPROVEEDOR_ID " +
                "INNER JOIN PRODUCTO ON PRODUCTO.PRDID = REMITOPROVEEDORDETALLE.PRDID " +
                "INNER JOIN ORDENCOMPRA ON ORDENCOMPRA.ODCID = REMITOPROVEEDORDETALLE.ODCID " +
                "INNER JOIN SUCURSAL ON SUCURSAL.SUCID = REMITOPROVEEDOR.SUCID " + 
                "INNER JOIN PROVEEDOR ON PROVEEDOR.PROID = REMITOPROVEEDOR.PROID " + 
                "ORDER BY REMITOPROVEEDOR.REMITOPROVEEDOR_FECHARECEPCION DESC";

            using (IDbConnection _db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
            {
                return _db.Query<RemitoProveedorDetalle, RemitoProveedor, Producto, OrdenCompra, Sucursal, Proveedor, RemitoProveedorDetalle>
                    (query, (detalle, remito, producto, orden, sucursal, proveedor) => { 
                        detalle.remitoproveedor = remito;
                        detalle.producto = producto;
                        detalle.ordencompra = orden;
                        detalle.remitoproveedor.sucursal = sucursal;
                        detalle.remitoproveedor.proveedor = proveedor;
                        return detalle; }, splitOn: "remitoproveedor_id, prdid, odcid, sucid, proid").ToList();
            }
        }


        public IList<RemitoProveedorDetalle> FindIngresosCondicional(string remito_numero, string prod, int? proveedor_id, int? sucursal_id, DateTime? desde, DateTime? hasta)
        {
            string query = "SELECT * FROM REMITOPROVEEDORDETALLE " +
               "INNER JOIN REMITOPROVEEDOR ON REMITOPROVEEDOR.REMITOPROVEEDOR_ID = " +
               "REMITOPROVEEDORDETALLE.REMITOPROVEEDOR_ID " +
               "INNER JOIN PRODUCTO ON PRODUCTO.PRDID = REMITOPROVEEDORDETALLE.PRDID " +
               "INNER JOIN ORDENCOMPRA ON ORDENCOMPRA.ODCID = REMITOPROVEEDORDETALLE.ODCID " +
               "INNER JOIN SUCURSAL ON SUCURSAL.SUCID = REMITOPROVEEDOR.SUCID " +
               "INNER JOIN PROVEEDOR ON PROVEEDOR.PROID = REMITOPROVEEDOR.PROID " + 
               "WHERE ((REMITOPROVEEDOR.REMITOPROVEEDOR_NUMERO = @remito_numero) OR (@remito_numero IS NULL)) " + 
               "AND ((PRODUCTO.PRDDENOMINACION LIKE CONCAT('%', @producto, '%')) OR (@producto IS NULL)) " +
               "AND ((REMITOPROVEEDOR.PROID = @proveedor_id) OR (@proveedor_id IS NULL)) " + 
               "AND ((REMITOPROVEEDORDETALLE.SUCID = @sucursal_id) OR (@sucursal_id IS NULL)) " + 
               "AND ((REMITOPROVEEDOR.REMITOPROVEEDOR_FECHARECEPCION BETWEEN @desde AND @hasta) OR ((@desde IS NULL) OR (@hasta IS NULL))) " +
               "ORDER BY REMITOPROVEEDOR.REMITOPROVEEDOR_FECHARECEPCION DESC";

            using (IDbConnection _db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
            {
                return _db.Query<RemitoProveedorDetalle, RemitoProveedor, Producto, OrdenCompra, Sucursal, Proveedor, RemitoProveedorDetalle>
                    (query, (detalle, remito, producto, orden, sucursal, proveedor) =>
                    {
                        detalle.remitoproveedor = remito;
                        detalle.producto = producto;
                        detalle.ordencompra = orden;
                        detalle.remitoproveedor.sucursal = sucursal;
                        detalle.remitoproveedor.proveedor = proveedor;
                        return detalle;
                    }, new { 
                        remito_numero = remito_numero, 
                        producto = prod, 
                        proveedor_id = proveedor_id, 
                        sucursal_id = sucursal_id, 
                        desde = desde, 
                        hasta = hasta }, splitOn: "remitoproveedor_id, prdid, odcid, sucid, proid").ToList();
            }
        }


        public IList<RemitoProveedor> FindAllByIdFactura(int factura_id)
        {
            string query = "SELECT REMITOPROVEEDOR.REMITOPROVEEDOR_ID, " +
                "REMITOPROVEEDOR.REMITOPROVEEDOR_NUMERO, " + 
                "REMITOPROVEEDOR.REMITOPROVEEDOR_FECHA " + 
                "FROM FACTURAPROVEEDOR_REMITOPROVEEDOR " +
                "INNER JOIN REMITOPROVEEDOR ON REMITOPROVEEDOR.REMITOPROVEEDOR_ID = FACTURAPROVEEDOR_REMITOPROVEEDOR.REMITOPROVEEDOR_ID " +
                "WHERE FACTURAPROVEEDOR_REMITOPROVEEDOR.FACTURAPROVEEDOR_ID = @factura_id ";

            using (IDbConnection _db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
            {
                return _db.Query<RemitoProveedor>(query, new { factura_id = factura_id}).ToList();
            }
        }


        public IList<RemitoProveedor> FindAllSinFactura()
        {
            string query = "SELECT * FROM REMITOPROVEEDOR " +
                    "INNER JOIN SUCURSAL ON SUCURSAL.SUCID = REMITOPROVEEDOR.SUCID " + 
                    "INNER JOIN PROVEEDOR ON PROVEEDOR.PROID = REMITOPROVEEDOR.PROID " +
                    "WHERE  NOT EXISTS (SELECT * FROM FACTURAPROVEEDOR_REMITOPROVEEDOR " + 
                    "WHERE FACTURAPROVEEDOR_REMITOPROVEEDOR.REMITOPROVEEDOR_ID = REMITOPROVEEDOR.REMITOPROVEEDOR_ID)";

            using (IDbConnection _db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
            {
                return _db.Query<RemitoProveedor, Sucursal, Proveedor, RemitoProveedor>(query,
                    (remito, sucursal, proveedor) => 
                    { remito.sucursal = sucursal; 
                        remito.proveedor = proveedor; 
                        return remito; }, splitOn:"sucid, proid").ToList();
            }
        }
    }
}
