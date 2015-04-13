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
    public class EntregasDetalle
    {

        public static int EntregaDetalleInsertar(EntregaDetalle ede)
        {
            try
            {
                string procedureName = "sp_entregadetalle_insertar";
                List<NpgsqlParameter> parametros = new List<NpgsqlParameter>();
                parametros.Add(Datos.DAL.crearParametro("entid", NpgsqlDbType.Integer, ede.entid));
                parametros.Add(Datos.DAL.crearParametro("edeproducto", NpgsqlDbType.Text, ede.edeproducto));
                parametros.Add(Datos.DAL.crearParametro("edecantidad", NpgsqlDbType.Integer, ede.edecantidad));
                parametros.Add(Datos.DAL.crearParametro("edesalida", NpgsqlDbType.Text, ede.edesalida));
                int resultado = Datos.DAL.EjecutarStoreInsert(procedureName, parametros);
                return resultado;

            }
            catch (NpgsqlException Npgsqlex)
            {
                throw Npgsqlex;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public static DataTable GetEntregaDetallePorId(int entid)
        {
            string procedureName = "sp_entregadetalle_obtenerporidentrega";
            List<NpgsqlParameter> parametros = new List<NpgsqlParameter>();
            parametros.Add(Datos.DAL.crearParametro("entid", NpgsqlDbType.Integer, entid));
            DataTable dt = Datos.DAL.EjecutarStoreConsultaConParametros(procedureName, parametros);
            return dt;
        }

    }
}
