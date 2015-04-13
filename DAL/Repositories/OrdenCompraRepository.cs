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


        public IList<OrdenCompra> BusquedaCondicional(string? numero, int? proveedor_id, DateTime? desde, DateTime? hasta)
        {
            string query = "SELECT * FROM ORDENCOMPRA " + 
                "WHERE ((ODCNUMERO LIKE CONCAT('%', @numero, '%')) OR (@numero IS NULL)) " + 
                "AND ((PROID = @proveedor_id) OR (@proveedor_id IS NULL)) " +
                "AND ((ODCFECHA BETWEEN @desde AND @hasta) OR (@desde IS NULL OR @hasta IS NULL)) " + 
                "ORDER BY ODCFECHA DESC";

            using (_cnn)
            {
                return _cnn.Query<OrdenCompra>(query, new { 
                    numero = numero, 
                    proveedor_id = proveedor_id, 
                    desde = desde, 
                    hasta = hasta }).ToList();
            }
        }
    }
}
