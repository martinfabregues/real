using Entidad;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Interfases
{
    public interface IOrdenCompraRepository :IRepository<OrdenCompra>
    {
        OrdenCompra GetByIdWithDetalle(int id);
        IList<OrdenCompra> BusquedaCondicional(string numero, int? proveedor_id, DateTime? desde, DateTime? hasta);
        IList<OrdenCompraPendiente> FindPendientes();
        IList<OrdenCompraPendiente> FindPendientesCondicional(int? proveedor_id, int? sucursal_id, string numero_orden, string prod);
        int Modificar(OrdenCompra orden, NpgsqlConnection _db, NpgsqlTransaction tx);
        int ModificarDetalle(OrdenCompraDetalle detalle, NpgsqlConnection _db, NpgsqlTransaction tx);
        int AgregarDetalle(OrdenCompraDetalle detalle, NpgsqlConnection _db, NpgsqlTransaction tx);
        int AgregarPendiente(OrdenCompraPendiente pendiente, NpgsqlConnection _db, NpgsqlTransaction tx);
        int EliminarPendiente(OrdenCompraPendiente pendiente, NpgsqlConnection _db, NpgsqlTransaction tx);
    }
}
