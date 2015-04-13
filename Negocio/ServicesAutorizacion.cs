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
    public class ServicesAutorizacion
    {

        public static int ServiceAutorizacionInsertar(ServiceAutorizacion sea)
        {
            string procedureName = "sp_serviceautorizacion_insertar";
            List<NpgsqlParameter> parametros = new List<NpgsqlParameter>();
            parametros.Add(Datos.DAL.crearParametro("sid", NpgsqlDbType.Integer, sea.serid));
            parametros.Add(Datos.DAL.crearParametro("sfecha", NpgsqlDbType.Date, sea.seafecha));
            parametros.Add(Datos.DAL.crearParametro("scobertura", NpgsqlDbType.Integer, sea.seacobertura));
            parametros.Add(Datos.DAL.crearParametro("simporte", NpgsqlDbType.Numeric, sea.seaimporte));
            int resultado = Datos.DAL.EjecutarStoreInsert(procedureName, parametros);
            return resultado;
        }

    }
}
