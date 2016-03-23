using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Interfases
{
    public interface IListaPrecioRepository : IRepository<ListaPrecio>
    {
        double FindImporteProducto(int lista_id, int producto_id);
        ListaPrecio FindUltimaActivaByProveedor(int proveedor_id);
    }
}
