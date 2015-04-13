using DAL;
using Datos;
using Entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Negocio
{
    public class TarjetasCredito
    {
        public static DataTable TarjetaCreditoGetTodo()
        {
            DataTable dt = new DataTable();
            string procedureName = "sp_tarjetacredito_obtenertodo";
            dt = Datos.DAL.EjecutarStoreConsulta(procedureName);
            return dt;
        }


        public static List<TarjetaCredito> GetTodos()
        {
            List<TarjetaCredito> list = TarjetaCreditoDAL.GetTodo();
            return list;
        }

        public static TarjetaCredito Crear(TarjetaCredito tarjeta)
        {
            tarjeta = TarjetaCreditoDAL.Crear(tarjeta);
            return tarjeta;
        }

    }
}
