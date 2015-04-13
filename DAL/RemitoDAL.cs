using Entidad;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Transactions;

namespace DAL
{
    public class RemitoDAL
    {

        public static Remito CargarRemito(NpgsqlDataReader reader)
        {
            Remito remito = new Remito();
            remito.cliente = ClienteDAL.GetPorId(Convert.ToInt32(reader["cliid"]));
            remito.estadocomprobante = EstadoComprobanteDAL.GetPorId(Convert.ToInt32(reader["estadocomprobante_id"]));
            //remito.formapago = FormaPagoDAL.GetPorId(Convert.ToInt32(reader["fpaid"]));
            remito.movimiento = MovimientoDAL.GetPorId(Convert.ToInt32(reader["movid"])) ;
            remito.remito_fecha = Convert.ToDateTime(reader["remito_fecha"]);
            remito.remito_id = Convert.ToInt32(reader["remito_id"]);
            remito.remito_importe = Convert.ToDouble(reader["remito_importe"]);
            remito.remito_numero = reader["remito_numero"].ToString();
            remito.remito_numerofactura = reader["remito_numerofactura"].ToString();
            remito.sucursal = SucursalDAL.GetPorId(Convert.ToInt32(reader["sucid"]));
            remito.tipocomprobante =TipoComprobanteDAL.GetPorId(Convert.ToInt32(reader["tipocomprobante_id"]));
            remito.tipomovimiento = TipoMovimientoDAL.GetPorId(Convert.ToInt32(reader["tmoid"]));
            remito.vendedor = VendedorDAL.GetPorId(Convert.ToInt32(reader["vendedor_id"]));
            remito.cobrocontado = GetCobroContado(Convert.ToInt32(reader["remito_id"]));
            remito.cobrocredito = GetCobroCredito(Convert.ToInt32(reader["remito_id"]));
            remito.detalle = GetDetallePorId(Convert.ToInt32(reader["remito_id"]));


            return remito;
        }

        public static Remito Crear(Remito remito)
        {
            NpgsqlTransaction transaccion = null;
                using (NpgsqlConnection db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
                {
                    try
                    {
                        db.Open();
                        transaccion = db.BeginTransaction();

                        //inserto el remito
                        NpgsqlCommand command = new NpgsqlCommand("sp_remito_insertar", db);
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("remito_numero", remito.remito_numero);
                        command.Parameters.AddWithValue("remito_numerofactura", remito.remito_numerofactura);
                        command.Parameters.AddWithValue("remito_fecha", remito.remito_fecha);
                        command.Parameters.AddWithValue("remito_importe", remito.remito_importe);
                        command.Parameters.AddWithValue("estadocomprobante_id", remito.estadocomprobante.estadocomprobante_id);
                        command.Parameters.AddWithValue("suc_id", remito.sucursal.sucid);
                        command.Parameters.AddWithValue("cli_id", remito.cliente.cliid);
                        command.Parameters.AddWithValue("mov_id", remito.movimiento.movid);
                        command.Parameters.AddWithValue("tmo_id", remito.tipomovimiento.tmoid);
                        command.Parameters.AddWithValue("tipocomprobante_id", remito.tipocomprobante.tipocomprobante_id);
                        command.Parameters.AddWithValue("vendedor_id", remito.vendedor.vendedor_id);
                      
                        remito.remito_id = Convert.ToInt32(command.ExecuteScalar());
                       
                        //REGISTRAR COBROS CONTADO
                        foreach (CobroRemitoContado fila in remito.cobrocontado)
                        {
                            CobroRemito cobroremito = new CobroRemito();

                            command.Parameters.Clear();
                            command.CommandType = CommandType.StoredProcedure;
                            command.CommandText = "sp_cobroremito_insertar";
                            command.Parameters.AddWithValue("remito_id", remito.remito_id);
                            command.Parameters.AddWithValue("cobroremito_importe", fila.cobroremito_importe);
                            cobroremito.cobroremito_id = Convert.ToInt32(command.ExecuteScalar());

                            command.Parameters.Clear();
                            command.CommandType = CommandType.StoredProcedure;
                            command.CommandText = "sp_cobroremitocontado_insertar";
                            command.Parameters.AddWithValue("cobroremito_id", cobroremito.cobroremito_id);

                            int resultado = Convert.ToInt32(command.ExecuteScalar());
                        }


                        //REGISTRAR COBROS CREDITO
                        foreach (CobroRemitoCredito fila in remito.cobrocredito)
                        {
                            CobroRemito cobroremito = new CobroRemito();

                            command.Parameters.Clear();
                            command.CommandType = CommandType.StoredProcedure;
                            command.CommandText = "sp_cobroremito_insertar";
                            command.Parameters.AddWithValue("remito_id", remito.remito_id);
                            command.Parameters.AddWithValue("cobroremito_importe", fila.cobroremito_importe);
                            cobroremito.cobroremito_id = Convert.ToInt32(command.ExecuteScalar());

                            fila.plan = PlanDAL.GetPorId(fila.plan.plan_id);

                            command.Parameters.Clear();
                            command.CommandType = CommandType.StoredProcedure;
                            command.CommandText = "sp_cobroremitocredito_insertar";
                            command.Parameters.AddWithValue("cobroremito_id", cobroremito.cobroremito_id);
                            command.Parameters.AddWithValue("plan_id", fila.plan.plan_id);
                            command.Parameters.AddWithValue("cobroremitocredito_costoplan", PlanDAL.CalcularCostoPlan(fila.plan, fila.cobroremito_importe));

                            int resultado = Convert.ToInt32(command.ExecuteScalar());
                        }

                        //REGISTRAR DETALLE
                        foreach (RemitoDetalle fila in remito.detalle)
                        {
                            command.Parameters.Clear();
                            command.CommandType = CommandType.StoredProcedure;
                            command.CommandText = "sp_remitodetalle_insertar";
                            command.Parameters.AddWithValue("remito_id", remito.remito_id);
                            command.Parameters.AddWithValue("prdid", fila.producto.prdid);
                            command.Parameters.AddWithValue("remitodetalle_cantidad", fila.remitodetalle_cantidad);
                            command.Parameters.AddWithValue("remitodetalle_importeunitario", fila.remitodetalle_importeunitario);
                            command.Parameters.AddWithValue("remitodetalle_numeroreserva", DBNull.Value);
                            command.Parameters.AddWithValue("sucid", DBNull.Value);

                            fila.remitodetalle_id = Convert.ToInt32(command.ExecuteScalar());
                        }
                                                             
                        transaccion.Commit();
                    }
                    catch (Exception)
                    {
                        remito = null;
                        transaccion.Rollback();
                        throw;
                    }
                    finally
                    {
                        db.Close();
                    }
                }
          
            return remito;
        }

        public static Boolean Existe(Remito remito)
        {
            bool resultado = false;

            using (NpgsqlConnection db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
            {
                try
                {
                    NpgsqlCommand command = new NpgsqlCommand("sp_remito_existe", db);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("sucid", remito.sucursal.sucid);
                    command.Parameters.AddWithValue("remito_numero", remito.remito_numero);

                    db.Open();

                    remito.remito_id = Convert.ToInt32(command.ExecuteScalar());
                    if (remito.remito_id > 0)
                    {
                        resultado = true;
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
            return resultado;
        }

        public static List<Remito> GetTodo()
        {
            List<Remito> list = new List<Remito>();
            using (NpgsqlConnection db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
            {
                try
                {
                    NpgsqlCommand command = new NpgsqlCommand("sp_remito_getdatos", db);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    db.Open();

                    NpgsqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Remito remito = new Remito();
                        remito.sucursal = new Sucursal();
                        remito.vendedor = new Vendedor();
                        remito.movimiento = new Movimiento();
                        remito.estadocomprobante = new EstadoComprobante();

                        remito.remito_id = Convert.ToInt32(reader["remito_id"]);
                        remito.sucursal.sucnombre = reader["sucnombre"].ToString();
                        remito.remito_fecha = Convert.ToDateTime(reader["remito_fecha"]);
                        remito.remito_numero = reader["remito_numero"].ToString();
                        remito.remito_numerofactura = reader["remito_numerofactura"].ToString();
                        remito.remito_importe = Convert.ToDouble(reader["remito_importe"]);
                        remito.vendedor.vendedor_nombre = reader["vendedor_nombre"].ToString();
                        remito.movimiento.movnombre = reader["movnombre"].ToString();
                        remito.estadocomprobante.estadocomprobante_denominacion = reader["estadocomprobante_denominacion"].ToString();

                        list.Add(remito);
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

        public static Remito GetPorId(int remito_id)
        {
            Remito remito = new Remito();

            using (NpgsqlConnection db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
            {
                try
                {
                    NpgsqlCommand command = new NpgsqlCommand("sp_remito_getporid", db);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("remito_id", remito_id);
                    db.Open();

                    NpgsqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        remito = CargarRemito(reader);
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

            return remito;
        }

        public static List<CobroRemitoContado> GetCobroContado(int remito_id)
        {
            List<CobroRemitoContado> list = new List<CobroRemitoContado>();
            using (NpgsqlConnection db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
            {
                try
                {
                    NpgsqlCommand command = new NpgsqlCommand("sp_remito_getcobrocontado", db);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("rem_id", remito_id);
                    db.Open();

                    NpgsqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        CobroRemitoContado cobrocontado = new CobroRemitoContado();
                        cobrocontado.remito = new Remito();

                        cobrocontado.cobroremito_id = Convert.ToInt32(reader["cobroremito_id"]);
                        cobrocontado.remito.remito_id = Convert.ToInt32(reader["remito_id"]);
                        cobrocontado.cobroremito_importe = Convert.ToDouble(reader["cobroremito_importe"]);

                        list.Add(cobrocontado);
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
       
        public static List<CobroRemitoCredito> GetCobroCredito(int remito_id)
        {
            List<CobroRemitoCredito> list = new List<CobroRemitoCredito>();
            using (NpgsqlConnection db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
            {
                try
                {
                    NpgsqlCommand command = new NpgsqlCommand("sp_remito_getcobrocredito", db);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("rem_id", remito_id);
                    db.Open();

                    NpgsqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        CobroRemitoCredito cobrocredito = new CobroRemitoCredito();
                        cobrocredito.remito = new Remito();
                        cobrocredito.plan = new Plan();
                        cobrocredito.plan.tarjetacredito = new TarjetaCredito();

                        cobrocredito.cobroremito_id = Convert.ToInt32(reader["cobroremito_id"]);
                        cobrocredito.remito.remito_id = Convert.ToInt32(reader["remito_id"]);
                        cobrocredito.cobroremito_importe = Convert.ToDouble(reader["cobroremito_importe"]);
                        cobrocredito.plan.plan_denominacion = reader["plan_denominacion"].ToString();
                        cobrocredito.plan.tarjetacredito.tarnombre = reader["tarnombre"].ToString();

                        list.Add(cobrocredito);
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

        public static List<RemitoDetalle> GetDetallePorId(int remito_id)
        {
            List<RemitoDetalle> list = new List<RemitoDetalle>();
            using (NpgsqlConnection db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
            {
                try
                {
                    NpgsqlCommand command = new NpgsqlCommand("sp_remitodetalle_getporidremito", db);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("remito_id", remito_id);
                    db.Open();

                    NpgsqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        RemitoDetalle remitodetalle = new RemitoDetalle();
                        remitodetalle.remitodetalle_id = Convert.ToInt32(reader["remitodetalle_id"]);
                        remitodetalle.remitodetalle_cantidad = Convert.ToInt32(reader["remitodetalle_cantidad"]);
                        remitodetalle.remitodetalle_importeunitario = Convert.ToDouble(reader["remitodetalle_importeunitario"]);
                        remitodetalle.producto = ProductoDAL.GetPorId(Convert.ToInt32(reader["prdid"]));

                        list.Add(remitodetalle);
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

        public static Boolean Modificar(Remito remito)
        {
            bool resultado = false;
            bool resultadoremito = false;
            bool rescontado = false;
            bool rescredito = false;
            bool resdetalle = false;

            NpgsqlTransaction transaccion = null;
            using (NpgsqlConnection db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
            {

                try
                {
                    db.Open();
                    transaccion = db.BeginTransaction();
                     //inserto el remito
                    NpgsqlCommand command = new NpgsqlCommand("sp_remito_modificar", db);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("remito_numero", remito.remito_numero);
                    command.Parameters.AddWithValue("remito_numerofactura", remito.remito_numerofactura);
                    command.Parameters.AddWithValue("remito_fecha", remito.remito_fecha);
                    command.Parameters.AddWithValue("remito_importe", remito.remito_importe);
                    command.Parameters.AddWithValue("estadocomprobante_id", remito.estadocomprobante.estadocomprobante_id);
                    command.Parameters.AddWithValue("suc_id", remito.sucursal.sucid);
                    command.Parameters.AddWithValue("cli_id", remito.cliente.cliid);
                    command.Parameters.AddWithValue("mov_id", remito.movimiento.movid);
                    command.Parameters.AddWithValue("tmo_id", remito.tipomovimiento.tmoid);
                    command.Parameters.AddWithValue("tipocomprobante_id", remito.tipocomprobante.tipocomprobante_id);
                    command.Parameters.AddWithValue("vendedor_id", remito.vendedor.vendedor_id);
                    command.Parameters.AddWithValue("remito_id", remito.remito_id);

                    int filasafectadas = Convert.ToInt32(command.ExecuteScalar());

                    if (filasafectadas > 0)
                    {
                        resultadoremito = true;
                    }

                     //REGISTRAR COBROS CONTADO
                    int contcontado = 0;
                    foreach (CobroRemitoContado fila in remito.cobrocontado)
                    {
                        if (fila.cobroremito_id == 0)
                        {
                            contcontado = contcontado + 1;
                            CobroRemito cobroremito = new CobroRemito();

                            command.Parameters.Clear();
                            command.CommandType = CommandType.StoredProcedure;
                            command.CommandText = "sp_cobroremito_insertar";
                            command.Parameters.AddWithValue("remito_id", remito.remito_id);
                            command.Parameters.AddWithValue("cobroremito_importe", fila.cobroremito_importe);
                            cobroremito.cobroremito_id = Convert.ToInt32(command.ExecuteScalar());

                            command.Parameters.Clear();
                            command.CommandType = CommandType.StoredProcedure;
                            command.CommandText = "sp_cobroremitocontado_insertar";
                            command.Parameters.AddWithValue("cobroremito_id", cobroremito.cobroremito_id);

                            int resultadocontado = Convert.ToInt32(command.ExecuteScalar());
                           
                            if (resultadocontado > 0)
                            {
                                rescontado = true;
                            }
                        }
                    }

                    //SI ES = 0 NO HAY PAGOS CONTADO
                    if (contcontado == 0)
                    {
                        rescontado = true;
                    }

                    //REGISTRAR COBROS CREDITO
                    int contcredito = 0;
                    foreach (CobroRemitoCredito fila in remito.cobrocredito)
                    {

                        if (fila.cobroremito_id == 0)
                        {
                            contcredito = contcredito + 1;
                            CobroRemito cobroremito = new CobroRemito();

                            command.Parameters.Clear();
                            command.CommandType = CommandType.StoredProcedure;
                            command.CommandText = "sp_cobroremito_insertar";
                            command.Parameters.AddWithValue("remito_id", remito.remito_id);
                            command.Parameters.AddWithValue("cobroremito_importe", fila.cobroremito_importe);
                            cobroremito.cobroremito_id = Convert.ToInt32(command.ExecuteScalar());

                            fila.plan = PlanDAL.GetPorId(fila.plan.plan_id);

                            command.Parameters.Clear();
                            command.CommandType = CommandType.StoredProcedure;
                            command.CommandText = "sp_cobroremitocredito_insertar";
                            command.Parameters.AddWithValue("cobroremito_id", cobroremito.cobroremito_id);
                            command.Parameters.AddWithValue("plan_id", fila.plan.plan_id);
                            command.Parameters.AddWithValue("cobroremitocredito_costoplan", PlanDAL.CalcularCostoPlan(fila.plan, fila.cobroremito_importe));

                            int resultadocredito = Convert.ToInt32(command.ExecuteScalar());
                            
                            if(resultadocredito > 0)
                            {
                                rescredito = true;
                            }
                        }

                    }
                    //SI CONTADOR CREDITO = 0 NO HAY PAGOS CON CREDITO
                    if (contcredito == 0)
                    {
                        rescredito = true;
                    }

                     //REGISTRAR DETALLE
                    int contdetalle = 0;
                    foreach (RemitoDetalle filadetalle in remito.detalle)
                    {
                        if (filadetalle.remitodetalle_id == 0)
                        {
                            contdetalle = contdetalle + 1;
                            command.Parameters.Clear();
                            command.CommandType = CommandType.StoredProcedure;
                            command.CommandText = "sp_remitodetalle_insertar";
                            command.Parameters.AddWithValue("remito_id", remito.remito_id);
                            command.Parameters.AddWithValue("prdid", filadetalle.producto.prdid);
                            command.Parameters.AddWithValue("remitodetalle_cantidad", filadetalle.remitodetalle_cantidad);
                            command.Parameters.AddWithValue("remitodetalle_importeunitario", filadetalle.remitodetalle_importeunitario);
                            command.Parameters.AddWithValue("remitodetalle_numeroreserva", DBNull.Value);
                            command.Parameters.AddWithValue("sucid", DBNull.Value);

                            int resultadodetalle = Convert.ToInt32(command.ExecuteScalar());
                            
                            if(resultadodetalle > 0)
                            {
                                resdetalle = true;
                            }
                        }
                    }
                    //NO HAY DETALLE A INSERTAR
                    if (contdetalle == 0)
                    {
                        resdetalle = true;
                    }

                    if (resultadoremito == true && rescontado == true && rescredito == true && resdetalle == true)
                    {
                        transaccion.Commit();
                        resultado = true;
                    }
                    else
                    {
                        transaccion.Rollback();
                        resultado = false;
                    }


                }
                catch(Exception)
                {
                    remito = null;
                    transaccion.Rollback();
                    throw;
                }
                finally
                {
                     db.Close();
                }


            }

            return resultado;
        }
 
        public static Boolean EliminarCobroContado(int cobroremito_id)
        {
             bool resultado = false;
             NpgsqlTransaction transaccion = null;
             using (NpgsqlConnection db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
             {
                 try
                 {
                     db.Open();
                     transaccion = db.BeginTransaction();
                     NpgsqlCommand command = new NpgsqlCommand("sp_cobroremitocontado_eliminar", db);
                     command.CommandType = CommandType.StoredProcedure;
                     command.Parameters.AddWithValue("cobroremito_id", cobroremito_id);
                     
                     int filasafectadas = Convert.ToInt32(command.ExecuteScalar());

                     if (filasafectadas > 0)
                     {
                         command.Parameters.Clear();
                         command.CommandType = CommandType.StoredProcedure;
                         command.CommandText = "sp_cobroremito_eliminar";
                         command.Parameters.AddWithValue("cobroremito_id", cobroremito_id);

                         int afectadas = Convert.ToInt32(command.ExecuteScalar());

                         if (afectadas > 0)
                         {
                             transaccion.Commit();
                             resultado = true;
                         }
                         else
                         {
                             resultado = false;
                             transaccion.Rollback();
                         }

                     }
                     else
                     {
                         resultado = false;
                         transaccion.Rollback();
                     }
                 }
                 catch (Exception)
                 {
                     transaccion.Rollback();
                     throw;
                 }
             }
             return resultado;
        }

        public static Boolean EliminarCobroCredito(int cobroremito_id)
        {
            bool resultado = false;
            NpgsqlTransaction transaccion = null;
            using (NpgsqlConnection db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
            {
                try
                {
                    db.Open();
                    transaccion = db.BeginTransaction();
                    NpgsqlCommand command = new NpgsqlCommand("sp_cobroremitocredito_eliminar", db);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("cobroremito_id", cobroremito_id);

                    int filasafectadas = Convert.ToInt32(command.ExecuteScalar());

                    if (filasafectadas > 0)
                    {
                        command.Parameters.Clear();
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandText = "sp_cobroremito_eliminar";
                        command.Parameters.AddWithValue("cobroremito_id", cobroremito_id);

                        int afectadas = Convert.ToInt32(command.ExecuteScalar());

                        if (afectadas > 0)
                        {
                            transaccion.Commit();
                            resultado = true;
                        }
                        else
                        {
                            resultado = false;
                            transaccion.Rollback();
                        }

                    }
                    else
                    {
                        resultado = false;
                        transaccion.Rollback();
                    }
                }
                catch (Exception)
                {
                    transaccion.Rollback();
                    throw;
                }
            }
            return resultado;
        }

        public static Boolean EliminarDetalle(int remitodetalle_id)
        {
            bool resultado = false;
            using (NpgsqlConnection db = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString()))
            {
                try
                {

                    NpgsqlCommand command = new NpgsqlCommand("sp_remitodetalle_eliminar", db);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("remitodetalle_id", remitodetalle_id);

                    db.Open();
                    int filasafectadas = Convert.ToInt32(command.ExecuteScalar());

                    if (filasafectadas > 0)
                    {
                        resultado = true;
                    }
                    else
                    {
                        resultado = false;
                        
                    }
                }
                catch (Exception)
                {                
                    throw;
                }
            }
            return resultado;
        }
    }
}
