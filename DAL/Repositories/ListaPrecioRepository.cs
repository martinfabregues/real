using DAL.Interfases;
using Entidad;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using Dapper;
using DapperExtensions;

namespace DAL.Repositories
{
    public class ListaPrecioRepository : IListaPrecioRepository
    {
        public IList<Entidad.ListaPrecio> FindAll()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Entidad.ListaPrecio> Find(System.Linq.Expressions.Expression<Func<Entidad.ListaPrecio, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Entidad.ListaPrecio FindById(int id)
        {
            throw new NotImplementedException();
        }

        public int add(Entidad.ListaPrecio newEntity)
        {
            throw new NotImplementedException();
        }

        public bool remove(int id)
        {
            throw new NotImplementedException();
        }

        public int Modify(Entidad.ListaPrecio entity)
        {
            throw new NotImplementedException();
        }

        public double FindImporteProducto(int lista_id, int producto_id)
        {
            string query = "SELECT * FROM LISTAPRECIOPRODUCTO LPP " +
                "JOIN LISTAPRECIO LP ON LP.LISTAPRECIO_ID = LPP.LISTAPRECIO_ID " +
                "WHERE LP.ESTID = 1 AND LPP.LISTAPRECIO_ID = @lista_id AND LPP.PRDID = @producto_id " +
                "ORDER BY LP.LISTAPRECIO_ID DESC";

            using (IDbConnection _db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
            {
                var result = _db.Query<ListaPrecioProducto>(query, new 
                { 
                    lista_id = lista_id, 
                    producto_id = producto_id 

                }).FirstOrDefault();

                return result.listaprecioproducto_costoneto;
            }
        }


        public ListaPrecio FindUltimaActivaByProveedor(int proveedor_id)
        {
            string query = "SELECT * FROM LISTAPRECIO " +
                "WHERE ESTID = 1 AND PROID = @proveedor_id " +
                "ORDER BY LISTAPRECIO_ID DESC";

            using (IDbConnection _db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
            {
                return _db.Query<ListaPrecio>(query, new 
                { 
                    proveedor_id = proveedor_id 

                }).FirstOrDefault();
            }

        }
    }
}
