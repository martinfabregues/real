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
    public class ArticuloRepository :IArticuloRepository
    {

        readonly NpgsqlConnection _cnn;

        public ArticuloRepository()
        {
            _cnn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString());           
        }


        public IList<Producto> FindAll()
        {
            using (_cnn)
            {
                return _cnn.Query<Producto>("SELECT * FROM Producto").ToList();
            }
        }

        public IQueryable<Producto> Find(Expression<Func<Producto, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Producto FindById(int id)
        {
            const string query = "SELECT * FROM PRODUCTO " + 
                "WHERE PRDID = @id";

            using (_cnn)
            {
                return _cnn.Query<Producto>(query, new { id = id }).SingleOrDefault();
            }
        }

        public int add(Producto newEntity)
        {
            throw new NotImplementedException();
        }

        public bool remove(int id)
        {
            throw new NotImplementedException();
        }

        public int Modify(Producto entity)
        {
            throw new NotImplementedException();
        }

        public Producto FindByCodigo(string codigo)
        {
            const string query = "SELECT * FROM PRODUCTO " +
                "WHERE PRDCODIGO = @codigo";

            using (_cnn)
            {
                return _cnn.Query<Producto>(query, new { codigo = codigo }).SingleOrDefault();
            }
        }
    }
}
