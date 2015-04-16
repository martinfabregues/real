using DAL.Interfases;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using Dapper;
using DapperExtensions;
using Entidad;

namespace DAL.Repositories
{
    public class ProveedorRepository :IProveedorRepository
    {
        readonly NpgsqlConnection _cnn;

        public ProveedorRepository()
        {
            _cnn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString());           
        }


        public IList<Entidad.Proveedor> FindAll()
        {
            string query = "SELECT * FROM proveedor";
            using (_cnn)
            {
                return _cnn.Query<Proveedor>(query).ToList();
            }
        }

        public IQueryable<Entidad.Proveedor> Find(System.Linq.Expressions.Expression<Func<Entidad.Proveedor, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Entidad.Proveedor FindById(int id)
        {
            throw new NotImplementedException();
        }

        public int add(Entidad.Proveedor newEntity)
        {
            throw new NotImplementedException();
        }

        public bool remove(int id)
        {
            throw new NotImplementedException();
        }

        public int Modify(Entidad.Proveedor entity)
        {
            throw new NotImplementedException();
        }


    }

}
