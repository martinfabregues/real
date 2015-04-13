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
    public class ServicesDetalle
    {
        public static int ServiceDetalleInsertar(ServiceDetalle sde)
        {

            string procedureName = "sp_servicedetalle_insertar";

            List<NpgsqlParameter> parametros = new List<NpgsqlParameter>();
            parametros.Add(Datos.DAL.crearParametro("prdid", NpgsqlDbType.Integer, sde.prdid));
            parametros.Add(Datos.DAL.crearParametro("sdecantidad", NpgsqlDbType.Integer, sde.sdecantidad));
            parametros.Add(Datos.DAL.crearParametro("sdemotivo", NpgsqlDbType.Text, sde.sdemotivo));
            parametros.Add(Datos.DAL.crearParametro("serid", NpgsqlDbType.Integer, sde.serid));
            int resultado = Datos.DAL.EjecutarStoreInsert(procedureName, parametros);
            return resultado;

        }
    }
}
