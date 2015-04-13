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
        int VerificarFactura(string numero);
        int AddRelacionFacturaRemito(int factura_id, int remito_id);
        int AddDetalle(FacturaProveedorDetalle detalle);
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
            using (IDbConnection _db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
            {
            }
            throw new NotImplementedException();
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
                "PROID, ESTID, FAPIMPORTE, OBSERVACIONES, SUBTOTAL, IVA, INGBRUTOS) " +
                "VALUES (@numero, @fecha, @fecharecepcion, @proveedor, " +
                "@estado, @importe, @observaciones, @subtotal, @iva, @ingbrutos);" +
                "SELECT CURRVAL('facturaproveedor_fapid_seq');";


            using (IDbConnection _db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
            {

                //inserto el encabezado de la factura
                return _db.Query<int>(query, new
                {
                    numero = newEntity.numero,
                    fecha = newEntity.fecha,
                    fecharecepcion = newEntity.fecharecepcion,
                    proveedor = newEntity.proveedor_id,
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


        public int AddRelacionFacturaRemito(int factura_id, int remito_id)
        {
            string query = "INSERT INTO FACTURAPROVEEDOR_REMITOPROVEEDOR (FACTURAPROVEEDOR_ID, REMITOPROVEEDOR_ID) " +
                "VALUES (@factura, @remito)";

            using (IDbConnection _db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
            {
                return _db.Execute(query, new { factura = factura_id, remito = remito_id });
            }
        }


        public int AddDetalle(FacturaProveedorDetalle detalle)
        {
            string query = "INSERT INTO FACTURAPROVEEDORDETALLE (FAPID, PRDID, FPDIMPORTEUNIT, " +
              "FPDCANTIDAD, ODCID) VALUES (@factura_id, @producto_id, @importeunit, @cantidad, @orden_id)";

            using (IDbConnection _db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
            {
                return _db.Execute(query, new
                {
                    factura_id = detalle.fapid,
                    producto_id = detalle.prdid,
                    importeunit = detalle.fpdimporteunit,
                    cantidad = detalle.fpdcantidad,
                    orden_id = detalle.odcid
                });
            }
        }
    }
}
