using Datos;
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
    public class Usuarios
    {
        public static DataTable GetLogin(string usunombre, string usuclave)
        {
            string procedureName = "sp_usuario_obtenerlogin";
            List<NpgsqlParameter> parametros = new List<NpgsqlParameter>();
            parametros.Add(Datos.DAL.crearParametro("usunombre", NpgsqlDbType.Text, usunombre));
            parametros.Add(Datos.DAL.crearParametro("usuclave", NpgsqlDbType.Text, usuclave));
            DataTable dt = Datos.DAL.EjecutarStoreConsultaConParametros(procedureName, parametros);
            return dt;
        }


    }
}
