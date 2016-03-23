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
        IList<Entrega> FindAllFiltro(DateTime? desde, DateTime? hasta, string nro_remito);
        int ModificarDetalle(EntregaDetalle detalle);
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


        public IList<Entrega> FindAllFiltro(DateTime? desde, DateTime? hasta, string nro_remito)
        {
            const string query = "SELECT * FROM ENTREGA " +
                "INNER JOIN BARRIO ON BARRIO.BARID = ENTREGA.BARID " +
                "INNER JOIN SUCURSAL ON SUCURSAL.SUCID = ENTREGA.SUCID " +
                "INNER JOIN TIPOENTREGA ON TIPOENTREGA.TPEID = ENTREGA.TPEID " +
                "INNER JOIN TIPOSALIDA ON TIPOSALIDA.TPSID = ENTREGA.TPSID " +
                "INNER JOIN ESTADOENTREGA ON ESTADOENTREGA.ESEID = ENTREGA.ESEID " +
                "WHERE ((ENTREGA.REMNUMERO = @nro_remito) OR (@nro_remito IS NULL)) " +
                "AND ((ENTREGA.ENTFECHA BETWEEN @desde AND @hasta) OR ((@desde IS NULL) OR (@hasta IS NULL)))";

            using (IDbConnection _cnn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
            {
                return _cnn.Query<Entrega, Barrio, Sucursal, TipoEntrega, TipoSalida, EstadoEntrega, Entrega>(query,
                    (entrega, barrio, sucursal, tipoentrega, tiposalida, estadoentrega) =>
                    {
                        entrega.barrio = barrio;
                        entrega.sucursal = sucursal;
                        entrega.tipo_entrega = tipoentrega;
                        entrega.tipo_salida = tiposalida;
                        entrega.estado_entrega = estadoentrega;
                        return entrega;
                    }, new { 
                        nro_remito = nro_remito, 
                        desde = desde, 
                        hasta = hasta }, 
                    splitOn: "barid, sucid, tpeid, tpsid, eseid").ToList();
            }
        }


        public int ModificarDetalle(EntregaDetalle detalle)
        {
            string query = "UPDATE ENTREGADETALLE SET EDEPRODUCTO = @producto, " +
                "EDECANTIDAD = @cantidad, EDESALIDA = @salida " +
                "WHERE EDEID = @id";

            using (IDbConnection _cnn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
            {
                return _cnn.Execute(query, new
                {
                    producto = detalle.edeproducto,
                    cantidad = detalle.edecantidad,
                    salida = detalle.edesalida,
                    id = detalle.edeid
                });
            }
        }
    }
}
