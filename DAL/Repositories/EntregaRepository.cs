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
    public interface IEntregaRepository : IRepository<Entrega>
    {
        
    }

    public class EntregaRepository : IEntregaRepository
    {

        readonly IDbConnection _cnn;

        public EntregaRepository()
        {
            _cnn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString());           
        }


        public IList<Entrega> FindAll()
        {
            using (IDbConnection _cnn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
            {
                IList<Entrega> datos = _cnn.Query<Entrega>("SELECT * FROM ENTREGA").ToList();
                return datos;
            }
            
        }

     


        public IQueryable<Entrega> Find(System.Linq.Expressions.Expression<Func<Entrega, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Entrega FindById(int id)
        {
            throw new NotImplementedException();
        }

        public int add(Entrega newEntity)
        {
            throw new NotImplementedException();
        }

        public bool remove(int id)
        {
            throw new NotImplementedException();
        }

        public int Modify(Entrega entity)
        {
            throw new NotImplementedException();
        }




        public IList<Entrega> FindAllDT()
        {
            throw new NotImplementedException();
        }




 
    }
}
