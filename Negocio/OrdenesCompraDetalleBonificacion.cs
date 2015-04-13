using Datos;
using Entidad;
using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Negocio
{
    public class OrdenesCompraDetalleBonificacion
    {

        public static int Insertar(OrdenCompraDetalleBonificacion odb, NpgsqlConnection db)
        {
            string procedureName ="sp_ordencompradetallebonificacion_insertar";
            List<NpgsqlParameter> parametros = new List<NpgsqlParameter>();
            parametros.Add(Datos.DAL.crearParametro("ocd_id", NpgsqlDbType.Integer, odb.ocdid));
            parametros.Add(Datos.DAL.crearParametro("prd_id", NpgsqlDbType.Integer, odb.prdid));
            parametros.Add(Datos.DAL.crearParametro("bon_id", NpgsqlDbType.Integer, odb.bonid));
            int resultado = Datos.DAL.EjecutarStoreInsertTransaccion(procedureName, parametros, db);
            return resultado;
        }


    }
}
