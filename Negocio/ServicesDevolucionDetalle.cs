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
    public class ServicesDevolucionDetalle
    {

        public static int ServiceDevolucionDetalleInsertar(ServiceDevolucionDetalle sde)
        {
            string procedureName = "sp_servicedevoluciondetalle_insertar";
            List<NpgsqlParameter> parametros = new List<NpgsqlParameter>();
            parametros.Add(Datos.DAL.crearParametro("sid", NpgsqlDbType.Integer, sde.sedid));
            parametros.Add(Datos.DAL.crearParametro("serviceid", NpgsqlDbType.Integer, sde.serid));
            int resultado = Datos.DAL.EjecutarStoreInsert(procedureName, parametros);
            return resultado;
        }
    }
}
