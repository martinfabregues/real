using DAL;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Negocio
{
    public class ListasPrecio
    {

        public static ListaPrecio Crear(ListaPrecio listaprecio)
        {
            listaprecio = ListaPrecioDAL.Crear(listaprecio);
            return listaprecio;
        }


        public static List<ListaPrecio> GetTodos()
        {
            List<ListaPrecio> list = ListaPrecioDAL.GetTodo();
            return list;
        }

        public static List<ListaPrecio> GetTodosPorIdProveedor(Proveedor proveedor)
        {
            List<ListaPrecio> list = ListaPrecioDAL.GetTodoPorIdProveedor(proveedor);
            return list;
        }

        public static List<ListaPrecio> GetTodosPorIdProveedorVigenteActiva(Proveedor proveedor, DateTime fecha)
        {
            List<ListaPrecio> list = ListaPrecioDAL.GetTodoPorIdProveedorVigenteActiva(proveedor, fecha);
            return list;
        }


        public static Boolean Modificar(ListaPrecio listaprecio)
        {
            bool resultado = ListaPrecioDAL.Modificar(listaprecio);
            return resultado;
        }


        public static ListaPrecio GetPorId(int listaprecio_id)
        {
            ListaPrecio listaprecio = new ListaPrecio();
            listaprecio = ListaPrecioDAL.GetPorId(listaprecio_id);
            return listaprecio;
        }

    }
}
