using Real.UI.Depositos.Entidad;
using Real.UI.Depositos.Interface;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DapperExtensions;

namespace Real.UI.Depositos.Repository
{
    public interface IProveedorRepository : IRepository<Proveedor>
    {

    }

    public class ProveedorRepository : IProveedorRepository
    {
        readonly IDbConnection _db;

        public IEnumerable<Proveedor> FindAll()
        {
            const string query = "SELECT * FROM PROVEEDORES";

            using(IDbConnection _db = new SqlConnection(ConfigurationManager.ConnectionStrings["rworldContext"].ToString()))
            {
                return _db.Query<Proveedor>(query);
            }
        }

        public IQueryable<Proveedor> Find(System.Linq.Expressions.Expression<Func<Proveedor, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Proveedor FindById(int id)
        {
            throw new NotImplementedException();
        }

        public int Add(Proveedor entity)
        {
            const string query = "INSERT INTO PROVEEDORES (FECHA_REGISTRO, RAZON_SOCIAL, ACTIVO) " +
                "VALUES (@fecha_registro, @razon_social, @activo) ";

            using (IDbConnection _db = new SqlConnection(ConfigurationManager.ConnectionStrings["rworldContext"].ToString()))
            {
                return _db.Execute(query, new { 
                    fecha_registro = DateTime.Now, 
                    razon_social = entity.razon_social, 
                    activo = entity.activo });
            }
        }

        public bool Remover(int id)
        {
            throw new NotImplementedException();
        }

        public int Modify(Proveedor entity)
        {
            throw new NotImplementedException();
        }
    }
}
