using Datos;
using Entidad;
using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ServicesDevolucion
    {
        public static int ServiceDevolucionInsertar(ServiceDevolucion sde)
        {
            string procedureName = "sp_servicedevolucion_insertar";
            List<NpgsqlParameter> parametros = new List<NpgsqlParameter>();
            parametros.Add(Datos.DAL.crearParametro("sfecha", NpgsqlDbType.Date, sde.sedfecha));
            parametros.Add(Datos.DAL.crearParametro("sobeservacion", NpgsqlDbType.Text, sde.sedobservacion));
            int resultado = Datos.DAL.EjecutarStoreInsert(procedureName, parametros);
            return resultado;
        }
    }
}
