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
    public interface IFacturaProveedorRepository : IRepository<FacturaProveedor>
    {
        int Add(FacturaProveedor factura, NpgsqlConnection _db, NpgsqlTransaction tx);
        int VerificarFactura(string numero);
        int AddRelacionFacturaRemito(int factura_id, int remito_id, NpgsqlConnection _db, NpgsqlTransaction tx);
        int AddDetalle(FacturaProveedorDetalle detalle, NpgsqlConnection _db, NpgsqlTransaction tx);
        IList<FacturaProveedorDetalle> FindDetalleById(int factura_id, NpgsqlConnection _db, NpgsqlTransaction tx);
        IList<FacturaProveedor> GetAll(NpgsqlConnection _db, NpgsqlTransaction tx);
        String FindFacturaProveedorPorIdRemito(int remito_id);
    }

    public class FacturaProveedorRepository : IFacturaProveedorRepository
    {
        readonly NpgsqlConnection _cnn;

        public FacturaProveedorRepository()
        {
            _cnn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString());
        }

        public IList<FacturaProveedor> FindAll()
        {
            string query = "SELECT * FROM FACTURAPROVEEDOR";

            using (IDbConnection _db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
            {
                return _db.Query<FacturaProveedor>(query).ToList();
            }
            
        }

        public IQueryable<FacturaProveedor> Find(System.Linq.Expressions.Expression<Func<FacturaProveedor, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public FacturaProveedor FindById(int id)
        {
            throw new NotImplementedException();
        }

        public int add(FacturaProveedor newEntity)
        {
            string query = "INSERT INTO FACTURAPROVEEDOR(FAPNUMERO, FAPFECHA, FAPFECHARECEPCION, " +
                "SUCID, PROID, FAPREMITO, ESTID, FAPIMPORTE, OBSERVACIONES, SUBTOTAL, IVA, INGBRUTOS) " +
                "VALUES (@numero, @fecha, @fecharecepcion, @sucursal, @proveedor, " +
                "@remito, @estado, @importe, @observaciones, @subtotal, @iva, @ingbrutos);" +
                "SELECT CURRVAL('facturaproveedor_fapid_seq');";


            using (IDbConnection _db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
            {

                //inserto el encabezado de la factura
                return _db.Query<int>(query, new
                {
                    numero = newEntity.numero,
                    fecha = newEntity.fecha,
                    fecharecepcion = newEntity.fecharecepcion,
                    sucursal = newEntity.sucursal_id,
                    proveedor = newEntity.proveedor_id,
                    remito = string.Empty,
                    estado = 1,
                    importe = newEntity.importe,
                    observaciones = newEntity.observaciones,
                    subtotal = newEntity.subtotal,
                    iva = newEntity.iva,
                    ingbrutos = newEntity.ingbrutos

                }).Single();
            }
        }

        public bool remove(int id)
        {
            throw new NotImplementedException();
        }

        public int Modify(FacturaProveedor entity)
        {
            throw new NotImplementedException();
        }



        public int VerificarFactura(string numero)
        {
            string query = "SELECT COUNT(*) FROM FACTURAPROVEEDOR " +
                "WHERE FAPNUMERO = @numero";

            using (IDbConnection _db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
            {
                return _db.Query<int>(query, new { numero = numero }).Single();
            }
        }


        public int AddRelacionFacturaRemito(int factura_id, int remito_id, NpgsqlConnection _db, NpgsqlTransaction tx)
        {
            string query = "INSERT INTO FACTURAPROVEEDOR_REMITOPROVEEDOR (FACTURAPROVEEDOR_ID, REMITOPROVEEDOR_ID) " +
                "VALUES (@factura, @remito)";
       
                return _db.Execute(query, new { factura = factura_id, remito = remito_id }, tx);            
        }


        public int AddDetalle(FacturaProveedorDetalle detalle, NpgsqlConnection _db, NpgsqlTransaction tx)
        {
            string query = "INSERT INTO FACTURAPROVEEDORDETALLE (FAPID, PRDID, FPDIMPORTEUNIT, " +
              "FPDCANTIDAD, ODCID) VALUES (@factura_id, @producto_id, @importeunit, @cantidad, @orden_id)";

                return _db.Execute(query, new
                {
                    factura_id = detalle.fapid,
                    producto_id = detalle.prdid,
                    importeunit = detalle.fpdimporteunit,
                    cantidad = detalle.fpdcantidad,
                    orden_id = detalle.odcid
                }, tx);
            
        }

        public int Add(FacturaProveedor factura, NpgsqlConnection _db, NpgsqlTransaction tx)
        {
            string query = "INSERT INTO FACTURAPROVEEDOR(FAPNUMERO, FAPFECHA, FAPFECHARECEPCION, " +
              "SUCID, PROID, FAPREMITO, ESTID, FAPIMPORTE, OBSERVACIONES, SUBTOTAL, IVA, INGBRUTOS) " +
              "VALUES (@numero, @fecha, @fecharecepcion, @sucursal, @proveedor, " +
              "@remito, @estado, @importe, @observaciones, @subtotal, @iva, @ingbrutos);" +
              "SELECT CURRVAL('facturaproveedor_fapid_seq');";


                //inserto el encabezado de la factura
                return _db.Query<int>(query, new
                {
                    numero = factura.numero,
                    fecha = factura.fecha,
                    fecharecepcion = factura.fecharecepcion,
                    sucursal = factura.sucursal_id,
                    proveedor = factura.proveedor_id,
                    remito = string.Empty,
                    estado = 1,
                    importe = factura.importe,
                    observaciones = factura.observaciones,
                    subtotal = factura.subtotal,
                    iva = factura.iva,
                    ingbrutos = factura.ingbrutos

                }, tx).Single();           
        }


        public IList<FacturaProveedorDetalle> FindDetalleById(int factura_id, NpgsqlConnection _db, NpgsqlTransaction tx)
        {
            string query = "SELECT * FROM FACTURAPROVEEDORDETALLE " +
                "WHERE FAPID = @id";


                return _db.Query<FacturaProveedorDetalle>(query, new { id = factura_id }, tx).ToList();
            
        }


        public IList<FacturaProveedor> GetAll(NpgsqlConnection _db, NpgsqlTransaction tx)
        {

            string query = "SELECT * FROM FACTURAPROVEEDOR";

            return _db.Query<FacturaProveedor>(query, tx).ToList() ;
        }


        public String FindFacturaProveedorPorIdRemito(int remito_id)
        {
            string resultado = string.Empty;
            string query = "SELECT " + 
                "FAPNUMERO " +
                "FROM FACTURAPROVEEDOR_REMITOPROVEEDOR " +
                "INNER JOIN FACTURAPROVEEDOR ON FACTURAPROVEEDOR.FAPID = FACTURAPROVEEDOR_REMITOPROVEEDOR.FACTURAPROVEEDOR_ID " +
                "WHERE FACTURAPROVEEDOR_REMITOPROVEEDOR.REMITOPROVEEDOR_ID = @remito_id";

            using (IDbConnection _db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
            {
                resultado =  _db.Query<string>(query, new { remito_id = remito_id }).Single();
                if (string.IsNullOrEmpty(resultado))
                    resultado = "S/F";
            }
            return resultado;
        }
    }
}
