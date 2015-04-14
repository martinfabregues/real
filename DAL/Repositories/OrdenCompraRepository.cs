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
    }
}
