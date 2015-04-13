using Datos;
using Entidad;
using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Provincias
    {
        public static int ProvinciaInsertar(Provincia prv)
        {

            string procedureName = "sp_provincia_insertar";
            List<NpgsqlParameter> parametros = new List<NpgsqlParameter>();
            parametros.Add(Datos.DAL.crearParametro("prvnombre", NpgsqlDbType.Text, prv.prvnombre));
            int resultado = Datos.DAL.EjecutarStoreInsert(procedureName, parametros);
            return resultado;

        }

        public static DataTable ProvinciaObtenerTodo()
        {

            DataTable dtProvincia = new DataTable();

            string procedureName = "sp_provincia_obtenertodo";
            dtProvincia = Datos.DAL.EjecutarStoreConsulta(procedureName);

            return dtProvincia;

        }
    }
}
