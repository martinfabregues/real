using DAL;
using Entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Negocio
{
    public class ListasPrecioProducto
    {

        public static ListaPrecioProducto GetListaProducto(ListaPrecio listaprecio, Producto producto)
        {
            ListaPrecioProducto listaproducto = ListaPrecioProductoDAL.GetListaProducto(listaprecio, producto);
            return listaproducto;
        }


        public static ListaPrecioProducto GetProductoPrecioVigente(Producto producto)
        {
            ListaPrecioProducto listaproducto = ListaPrecioProductoDAL.GetProductoPrecioVigente(producto);
            return listaproducto;
        }

        public static List<ListaPrecioProducto> GetTodoPorIdLista(int listaprecio_id)
        {
            List<ListaPrecioProducto> listaprecio = ListaPrecioProductoDAL.GetTodoPorIdLista(listaprecio_id);
            return listaprecio;
        }

        public static Boolean ActualizarCostos(DataTable datos)
        {
            bool resultado = ListaPrecioProductoDAL.ActualizarCostos(datos);
            return resultado;
        }
    }
}
