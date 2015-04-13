using Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Localidades
    {
        public static DataTable LocalidadObtenerTodo()
        {

            DataTable dtLocalidad = new DataTable();

            string procedureName = "sp_localidad_obtenertodo";
            dtLocalidad = Datos.DAL.EjecutarStoreConsulta(procedureName);

            return dtLocalidad;

        }
    }
}
