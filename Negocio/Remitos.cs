using DAL;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Negocio
{
    public class Remitos
    {

        public static Remito Crear(Remito remito)
        {
            remito = RemitoDAL.Crear(remito);
            return remito;
        }


        public static Boolean Existe(Remito remito)
        {
            bool resultado = RemitoDAL.Existe(remito);
            return resultado;
        }


        public static List<Remito> GetTodo()
        {
            List<Remito> list = RemitoDAL.GetTodo();
            return list;
        }


        public static Remito GetPorId(int remito_id)
        {
            Remito remito = RemitoDAL.GetPorId(remito_id);
            return remito;
        }

        public static Boolean EliminarCobroContado(int cobroremito_id)
        {
            bool resultado = RemitoDAL.EliminarCobroContado(cobroremito_id);
            return resultado;
        }


        public static Boolean EliminarCobroCredito(int cobroremito_id)
        {
            bool resultado = RemitoDAL.EliminarCobroCredito(cobroremito_id);
            return resultado;
        }


        public static Boolean EliminarDetalle(int remitodetalle_id)
        {
            bool resultado = RemitoDAL.EliminarDetalle(remitodetalle_id);
            return resultado;
        }

        public static Boolean Modificar(Remito remito)
        {
            bool resultado = RemitoDAL.Modificar(remito);
            return resultado;
        }

    }
}
