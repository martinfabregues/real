using DAL.Interfases;
using Entidad;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Dapper;
using DapperExtensions;

namespace DAL.Repositories
{
    public class OrdenCompraRepository :IOrdenCompraRepository
    {
        readonly NpgsqlConnection _cnn;

        public OrdenCompraRepository()
        {
            _cnn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString());           
        }

        public IList<OrdenCompra> FindAll()
        {
            string query = "SELECT * " +
                            "FROM OrdenCompra " +
                            "INNER JOIN Proveedor ON OrdenCompra.proid = Proveedor.proid " +
                            "ORDER BY OrdenCompra.odcfecha DESC";
            using (_cnn)
            {
                return _cnn.Query<OrdenCompra, Proveedor, OrdenCompra>(query, (orden, proveedor) => { orden.proveedor = proveedor; return orden; }, splitOn: "proid").ToList();
            }
        }

        public IQueryable<OrdenCompra> Find(Expression<Func<OrdenCompra, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public OrdenCompra FindById(int id)
        {
            throw new NotImplementedException();
        }

        public int add(OrdenCompra newEntity)
        {
            throw new NotImplementedException();
        }

        public bool remove(int id)
        {
            throw new NotImplementedException();
        }

        public int Modify(OrdenCompra entity)
        {
            throw new NotImplementedException();
        }

        public OrdenCompra GetByIdWithDetalle(int id)
        {
            string query = "SELECT * " +
                          "FROM OrdenCompra WHERE odcid = @id";

            string querydetalle = "SELECT * FROM ordencompradetalle " +
                                "INNER JOIN sucursal ON sucursal.sucid = ordencompradetalle.sucid " + 
                                "INNER JOIN producto ON producto.prdid = ordencompradetalle.prdid " +
                                    "WHERE ordencompradetalle.odcid = " + id;

            OrdenCompra orden = new OrdenCompra();          

            using (_cnn)
            {
                orden = _cnn.Query<OrdenCompra>(query, new { id= id}).SingleOrDefault();
                var det = _cnn.Query<OrdenCompraDetalle, Sucursal, Producto, OrdenCompraDetalle>(querydetalle, (detalle, sucursal, producto) => { detalle.sucursal = sucursal; detalle.producto = producto; return detalle; }, splitOn: "sucid, prdid").ToList();
                //var det = _cnn.Query<OrdenCompraDetalle, Sucursal, Producto, OrdenCompraDetalle>(querydetalle, (detalle, sucursal, producto) => { detalle.sucursal = sucursal; detalle.producto = producto; return detalle; },splitOn: "prdid, sucid").ToList();
                orden.Detalle = det;
                return orden;
            }
        }

        public IList<OrdenCompra> BusquedaCondicional(string numero, int? proveedor_id, DateTime? desde, DateTime? hasta)
        {
            string query = "SELECT * FROM ORDENCOMPRA " + 
                "INNER JOIN PROVEEDOR ON PROVEEDOR.PROID = ORDENCOMPRA.PROID " + 
                "WHERE ((ORDENCOMPRA.ODCNUMERO LIKE CONCAT('%', @numero, '%')) OR (@numero IS NULL)) " + 
                "AND ((ORDENCOMPRA.PROID = @proveedor_id) OR (@proveedor_id IS NULL)) " +
                "AND ((ORDENCOMPRA.ODCFECHA BETWEEN @desde AND @hasta) OR (@desde IS NULL OR @hasta IS NULL)) " +
                "ORDER BY ORDENCOMPRA.ODCFECHA DESC";

            using (_cnn)
            {
                return _cnn.Query<OrdenCompra, Proveedor, OrdenCompra>(query, (orden, proveedor) => {orden.proveedor = proveedor; return orden;}, new { 
                    numero = numero, 
                    proveedor_id = proveedor_id, 
                    desde = desde,
                    hasta = hasta
                }, splitOn: "proid").ToList();
            }
        }

        public IList<OrdenCompraPendiente> FindPendientes()
        {
            string query = "SELECT * FROM ORDENCOMPRAPENDIENTE " +
                "INNER JOIN PRODUCTO ON PRODUCTO.PRDID = ORDENCOMPRAPENDIENTE.PRDID " +
                "INNER JOIN ORDENCOMPRA ON ORDENCOMPRA.ODCID = ORDENCOMPRAPENDIENTE.ODCID " +
                "INNER JOIN SUCURSAL ON SUCURSAL.SUCID = ORDENCOMPRAPENDIENTE.SUCID " +
                "INNER JOIN PROVEEDOR ON PROVEEDOR.PROID = ORDENCOMPRAPENDIENTE.PROID " +
                "WHERE ORDENCOMPRAPENDIENTE.OCDCANTIDAD > 0 " +
                "ORDER BY ORDENCOMPRA.ODCFECHA DESC";

            using (_cnn)
            {
                return _cnn.Query<OrdenCompraPendiente, Producto, OrdenCompra, Sucursal, Proveedor, OrdenCompraPendiente>(query, 
                    (pendiente, producto, orden, sucursal, proveedor) =>
                    {
                        pendiente.producto = producto;
                        pendiente.ordencompra = orden;
                        pendiente.sucursal = sucursal;
                        pendiente.proveedor = proveedor;
                        return pendiente;
                    }, splitOn:"prdid, odcid, sucid, proid").ToList();
            }
        }

        public IList<OrdenCompraPendiente> FindPendientesCondicional(int? proveedor_id, int? sucursal_id, string numero_orden, string prod)
        {
            string query = "SELECT * FROM ORDENCOMPRAPENDIENTE " +
                "INNER JOIN PRODUCTO ON PRODUCTO.PRDID = ORDENCOMPRAPENDIENTE.PRDID " +
                "INNER JOIN ORDENCOMPRA ON ORDENCOMPRA.ODCID = ORDENCOMPRAPENDIENTE.ODCID " +
                "INNER JOIN SUCURSAL ON SUCURSAL.SUCID = ORDENCOMPRAPENDIENTE.SUCID " +
                "INNER JOIN PROVEEDOR ON PROVEEDOR.PROID = ORDENCOMPRAPENDIENTE.PROID " +
                "WHERE ORDENCOMPRAPENDIENTE.OCDCANTIDAD > 0 " +
                "AND ((ORDENCOMPRAPENDIENTE.PROID = @proveedor_id) OR (@proveedor_id IS NULL)) " + 
                "AND ((ORDENCOMPRAPENDIENTE.SUCID = @sucursal_id) OR (@sucursal_id IS NULL)) " +
                "AND ((ORDENCOMPRA.ODCNUMERO LIKE CONCAT('%', @numero_orden, '%')) OR (@numero_orden IS NULL)) " + 
                "AND ((PRODUCTO.PRDDENOMINACION LIKE CONCAT('%', @producto, '%')) OR (@producto IS NULL)) " + 
                "ORDER BY ORDENCOMPRA.ODCFECHA DESC";

            using (_cnn)
            {
                return _cnn.Query<OrdenCompraPendiente, Producto, OrdenCompra, Sucursal, Proveedor, OrdenCompraPendiente>(query,
                    (pendiente, producto, orden, sucursal, proveedor) =>
                    {
                        pendiente.producto = producto;
                        pendiente.ordencompra = orden;
                        pendiente.sucursal = sucursal;
                        pendiente.proveedor = proveedor;
                        return pendiente;
                    }, new { 
                        proveedor_id = proveedor_id, 
                        sucursal_id = sucursal_id, 
                        numero_orden = numero_orden, 
                        producto = prod }, splitOn: "prdid, odcid, sucid, proid").ToList();
            }
        }

        public int Modificar(OrdenCompra orden, NpgsqlConnection _db, NpgsqlTransaction tx)
        {
            string query = "UPDATE ORDENCOMPRA SET ODCNUMERO = @numero, ODCFECHA = @fecha, " +
                "PROID = @proveedor_id, ODCIMPORTE = @importe, ESTID = @estado, " +
                "ODCOBSERVACION = @observacion, ODCACTIVO = @activo " +
                "WHERE ODCID = @id";

            return _db.Execute(query, new
            {
                numero = orden.odcnumero,
                fecha = orden.odcfecha,
                proveedor_id = orden.proid,
                importe = orden.odcimporte,
                estado = orden.estid,
                observacion = orden.odcobservacion,
                activo = orden.odcactivo,
                id = orden.odcid
            }, tx);
        }

        public int ModificarDetalle(OrdenCompraDetalle detalle, NpgsqlConnection _db, NpgsqlTransaction tx)
        {
            string query = "UPDATE ORDENCOMPRADETALLE SET ODCID = @orden_id, PRDID = @producto_id, " +
                "OCDCANTIDAD = @cantidad, OCDIMPORTEUNIT = @importe_unitario, SUCID = @sucursal_id, " +
                "ECDID = @estado, OCDOBSERVACION = @observacion " +
                "WHERE OCDID = @id";

            return _db.Execute(query, new
            {
                orden_id = detalle.odcid,
                producto_id = detalle.prdid,
                cantidad = detalle.ocdcantidad,
                importe_unitario = detalle.ocdimporteunit,
                sucursal_id = detalle.sucid,
                estado = detalle.ecdid,
                observacion = string.Empty,
                id = detalle.ocdid

            }, tx);
        }

        public int AgregarDetalle(OrdenCompraDetalle detalle, NpgsqlConnection _db, NpgsqlTransaction tx)
        {
            string query = "INSERT INTO ORDENCOMPRADETALLE (ODCID, PRDID, OCDCANTIDAD, OCDIMPORTEUNIT, SUCID, ECDID, OCDOBSERVACION) " +
                "VALUES (@orden_id, @producto_id, @cantidad, @importe, @sucursal_id, @estado, @observacion)";

            return _db.Execute(query, new
            {
                orden_id = detalle.odcid,
                producto_id = detalle.prdid,
                cantidad = detalle.ocdcantidad,
                importe = detalle.ocdimporteunit,
                sucursal_id = detalle.sucid,
                estado = detalle.ecdid,
                observacion = detalle.ocdobservacion
            }, tx);
        }

        public int AgregarPendiente(OrdenCompraPendiente pendiente, NpgsqlConnection _db, NpgsqlTransaction tx)
        {
            string query = "INSERT INTO ORDENCOMPRAPENDIENTE (ODCID, PRDID, OCDCANTIDAD, OCDIMPORTE, SUCID, PROID, ESPID) " +
               "VALUES (@orden_id, @producto_id, @cantidad, @importe, @sucursal_id, @proveedor_id, @esp)";

            return _db.Execute(query, new
            {
                orden_id = pendiente.odcid,
                producto_id = pendiente.prdid,
                cantidad = pendiente.ocdcantidad,
                importe = pendiente.ocdimporte,
                sucursal_id = pendiente.sucid,
                proveedor_id = pendiente.proid,
                esp = pendiente.espid
            });
           
        }

        public int EliminarPendiente(OrdenCompraPendiente pendiente, NpgsqlConnection _db, NpgsqlTransaction tx)
        {
            throw new NotImplementedException();
        }

        public IList<OrdenCompraDetalle> FindDetalleByIdOrden(int orden_id)
        {
            string query = "SELECT * FROM ORDENCOMPRADETALLE " +
                "INNER JOIN ORDENCOMPRA ON ORDENCOMPRA.ODCID = ORDENCOMPRADETALLE.ODCID " +
                "INNER JOIN PRODUCTO ON PRODUCTO.PRDID = ORDENCOMPRADETALLE.PRDID " + 
                "INNER JOIN SUCURSAL ON SUCURSAL.SUCID = ORDENCOMPRADETALLE.SUCID " + 
                "WHERE ORDENCOMPRADETALLE.ODCID = @id";

            using (_cnn)
            {
                return _cnn.Query<OrdenCompraDetalle, OrdenCompra, Producto, Sucursal, OrdenCompraDetalle>(query,
                    (detalle, orden, producto, sucursal) =>
                    {
                        detalle.orden = orden;
                        detalle.producto = producto;
                        detalle.sucursal = sucursal;
                        return detalle;
                    }, new { id = orden_id }, splitOn: "odcid, prdid, sucid").ToList();
            }
        }
    }
}
