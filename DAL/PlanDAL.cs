using Entidad;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;

namespace DAL
{
    public class PlanDAL
    {
        private static Plan CargarPlan(NpgsqlDataReader reader)
        {
            Plan plan = new Plan() ;
            plan.plan_id = Convert.ToInt32(reader["plan_id"]);
            plan.plan_costofinanciero = Convert.ToDouble(reader["plan_costofinanciero"]);
            plan.plan_denominacion = reader["plan_denominacion"].ToString();
            plan.plan_comision = Convert.ToDouble(reader["plan_comision"]);
            plan.plan_margenfinanciero = Convert.ToDouble(reader["plan_margenfinanciero"]);
            plan.tarjetacredito = TarjetaCreditoDAL.GetPorId(Convert.ToInt32(reader["tarjetacredito_id"]));

            return plan;
        }

        public static List<Plan> GetTodoPorIdTarjeta(int tarjetacredito_id)
        {
            List<Plan> list = new List<Plan>();

            using (NpgsqlConnection db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
            {
                try
                {
                    NpgsqlCommand command = new NpgsqlCommand("sp_plan_getporidtarjeta", db);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("tarjetacredito_id", tarjetacredito_id);
                    db.Open();

                    NpgsqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        list.Add(CargarPlan(reader));
                    }

                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    db.Close();
                }

            }

            return list;
        }

        public static Plan Crear(Plan plan)
        {
            using (NpgsqlConnection db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
            {
                try
                {

                    NpgsqlCommand command = new NpgsqlCommand("sp_plan_insertar", db);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("plan_denominacion", plan.plan_denominacion);
                    command.Parameters.AddWithValue("tar_id", plan.tarjetacredito.tarid);
                    command.Parameters.AddWithValue("plan_costofinanciero", plan.plan_costofinanciero);
                    command.Parameters.AddWithValue("plan_margenfinanciero", plan.plan_margenfinanciero);
                    command.Parameters.AddWithValue("plan_comision", plan.plan_comision);
                    command.Parameters.AddWithValue("plan_costoinflacionario", plan.plan_costoinflacionario);
                   
                    db.Open();
                    plan.plan_id =  Convert.ToInt32(command.ExecuteScalar());
                    
                }
                catch (Exception)
                {
                    plan = null;
                    throw;
                }
                finally
                {
                    db.Close();
                }

            }
            return plan;
        }

        public static Plan GetPorId(int plan_id)
        {
            Plan plan = new Plan();

            using (NpgsqlConnection db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
            {
                try
                {
                    NpgsqlCommand command = new NpgsqlCommand("sp_plan_gettodoporid", db);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("plan_id", plan_id);
                    db.Open();

                    NpgsqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        plan = CargarPlan(reader);
                    }
                    else
                    {
                        plan = null;
                    }

                }
                catch (Exception)
                {
                    plan = null;
                    throw;
                }
                finally
                {
                    db.Close();
                }
            }

            return plan;
        }

        public static List<Plan> GetTodo()
        {
            List<Plan> list = new List<Plan>();
            using (NpgsqlConnection db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
            {
                try
                {
                    NpgsqlCommand command = new NpgsqlCommand("sp_plan_obtenertodo", db);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    db.Open();

                    NpgsqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        list.Add(CargarPlan(reader));
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    db.Close();
                }



            }
            return list;
        }

        public static Boolean Actualizar(Plan plan)
        {
            bool resultado = false;
            using (NpgsqlConnection db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
            {
                try
                {
                    NpgsqlCommand command = new NpgsqlCommand("sp_plan_actualizar", db);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("plan_denominacion", plan.plan_denominacion);
                    command.Parameters.AddWithValue("tar_id", plan.tarjetacredito.tarid);
                    command.Parameters.AddWithValue("plan_costofinanciero", plan.plan_costofinanciero);
                    command.Parameters.AddWithValue("plan_margenfinanciero", plan.plan_margenfinanciero);
                    command.Parameters.AddWithValue("plan_comision", plan.plan_comision);
                    command.Parameters.AddWithValue("plan_costoinflacionario", plan.plan_costoinflacionario);
                    command.Parameters.AddWithValue("plan_id", plan.plan_id);

                    db.Open();
                    int filasAfectadas = Convert.ToInt32(command.ExecuteScalar());
                    if (filasAfectadas > 0)
                    {
                        resultado = true;
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return resultado;
        }

        public static Double CalcularCostoPlan(Plan plan, Double importe)
        {
            double total = 0;
            double comision = (importe * plan.plan_comision) - importe ;
            double costofinanciero = (importe * plan.plan_costofinanciero) - importe ;

            total = comision + costofinanciero;

            return total;
        }

    }
}
