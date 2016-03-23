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
        int EliminarPendiente(int ordencomprapendiente_id);
        IList<OrdenCompraDetalle> FindDetalleByIdOrden(int orden_id);
        int Agregar(OrdenCompra newEntity, NpgsqlConnection _db, NpgsqlTransaction tx);
        int DescontarPendiente(OrdenCompraPendiente pendiente, NpgsqlConnection _db, NpgsqlTransaction tx);
        int ProximoNumeroOrden(int proveedor_id, NpgsqlConnection _db, NpgsqlTransaction tx);
        int ActualizarProximoNumeroOrden(int proveedor_id, string numero, NpgsqlConnection _db, NpgsqlTransaction tx);
        int InsertarProximoNumeroOrden(int proveedor_id, string numero, NpgsqlConnection _db, NpgsqlTransaction tx);
        int ActualizarIngreso(int ordendetalle_id, int cantidad, NpgsqlConnection _db, NpgsqlTransaction tx);
        int ModificarPendiente(OrdenCompraPendiente pendiente, NpgsqlConnection _db, NpgsqlTransaction tx);
        int EliminarItemDetalle(int id, NpgsqlConnection _db, NpgsqlTransaction tx);
        int EliminarItemPendiente(int id, NpgsqlConnection _db, NpgsqlTransaction tx);
    }
}
