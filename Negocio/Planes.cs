using DAL;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Negocio
{
    public class Planes
    {


        public static List<Plan> GetTodoPorIdTarjeta(int tarjetacredito_id)
        {
            List<Plan> list = PlanDAL.GetTodoPorIdTarjeta(tarjetacredito_id);
            return list;
        }


        public static Plan Crear(Plan plan)
        {
            plan = PlanDAL.Crear(plan);
            return plan;
        }

        public static Plan GetPorId(int plan_id)
        {
            Plan plan = PlanDAL.GetPorId(plan_id);
            return plan;
        }


        public static Boolean Actualizar(Plan plan)
        {
            bool resultado = PlanDAL.Actualizar(plan);
            return resultado;

        }


        public static List<Plan> GetTodo()
        {
            List<Plan> list = PlanDAL.GetTodo();
            return list;
        }


    }
}
