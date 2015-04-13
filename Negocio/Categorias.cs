using Datos;
using Entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Categorias
    {
        public static DataTable CategoriaObtenerTodo()
        {
            DataTable dtCiudad = new DataTable();
            string procedureName = "sp_categoria_obtenertodo";
            dtCiudad = Datos.DAL.EjecutarStoreConsulta(procedureName);
            return dtCiudad;
        }

        public static List<Categoria> GetTodas()
        {
            List<Categoria> cats = new List<Categoria>();
            string procedureName = "sp_categoria_obtenertodo";
            DataTable dt = new DataTable();
            dt = Datos.DAL.EjecutarStoreConsulta(procedureName);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Categoria cat = new Categoria();
                    cat.catid = Convert.ToInt32(dr["catid"]);
                    cat.catnombre = dr["catnombre"].ToString();
                    cats.Add(cat);
                }
            }
            return cats;
        }

        public static List<Categoria> GetTodos()
        {
            List<Categoria> list = new List<Categoria>();
            try
            {
                list = DAL.CategoriaDAL.GetTodo();
            }
            catch (Exception)
            {
                throw;
            }

            return list;
        }


        public static Categoria GetPorId(int catid)
        {
            Categoria categoria = new Categoria();
            try
            {
                categoria = DAL.CategoriaDAL.GetPorId(catid);
            }
            catch (Exception)
            {
                throw;
            }
            return categoria;
        }

    }
}
