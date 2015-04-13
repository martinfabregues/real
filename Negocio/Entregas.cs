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
    public class Entregas
    {

        public static int EntregaInsertar(Entrega ent)
        {
            try
            {
                string procedureName = "sp_entrega_insertar";
                List<NpgsqlParameter> parametros = new List<NpgsqlParameter>();
                parametros.Add(Datos.DAL.crearParametro("remnumero", NpgsqlDbType.Text, ent.remnumero));
                parametros.Add(Datos.DAL.crearParametro("entfecha", NpgsqlDbType.Date, ent.entfecha));
                parametros.Add(Datos.DAL.crearParametro("entcalle", NpgsqlDbType.Text, ent.entcalle));
                parametros.Add(Datos.DAL.crearParametro("entnumero", NpgsqlDbType.Text, ent.entnumero));
                parametros.Add(Datos.DAL.crearParametro("entpiso", NpgsqlDbType.Text, ent.entpiso));
                parametros.Add(Datos.DAL.crearParametro("entdepto", NpgsqlDbType.Text, ent.entdepto));
                parametros.Add(Datos.DAL.crearParametro("barid", NpgsqlDbType.Integer, ent.barid));
                parametros.Add(Datos.DAL.crearParametro("sucid", NpgsqlDbType.Integer, ent.sucid));
                parametros.Add(Datos.DAL.crearParametro("entcomentario", NpgsqlDbType.Text, ent.entcomentarios));
                parametros.Add(Datos.DAL.crearParametro("tpeid", NpgsqlDbType.Integer, ent.tpeid));
                parametros.Add(Datos.DAL.crearParametro("entcosto", NpgsqlDbType.Numeric, ent.entcosto));
                parametros.Add(Datos.DAL.crearParametro("eseid", NpgsqlDbType.Integer, ent.eseid));
                parametros.Add(Datos.DAL.crearParametro("tpsid", NpgsqlDbType.Integer, ent.tpsid));
                int resultado = Datos.DAL.EjecutarStoreInsert(procedureName, parametros);
                return resultado;

            }
            catch(NpgsqlException Npgsqlex)
            {
                throw Npgsqlex;
            }
            catch(Exception ex)
            {
                throw ex;
            }
          
        }

        public static int EntregaModificar(Entrega ent)
        {
            try
            {
                string procedureName = "sp_entrega_actualizar";
                List<NpgsqlParameter> parametros = new List<NpgsqlParameter>();
                parametros.Add(Datos.DAL.crearParametro("remnumero", NpgsqlDbType.Text, ent.remnumero));
                parametros.Add(Datos.DAL.crearParametro("entfecha", NpgsqlDbType.Date, ent.entfecha));
                parametros.Add(Datos.DAL.crearParametro("entcalle", NpgsqlDbType.Text, ent.entcalle));
                parametros.Add(Datos.DAL.crearParametro("entnumero", NpgsqlDbType.Text, ent.entnumero));
                parametros.Add(Datos.DAL.crearParametro("entpiso", NpgsqlDbType.Text, ent.entpiso));
                parametros.Add(Datos.DAL.crearParametro("entdepto", NpgsqlDbType.Text, ent.entdepto));
                parametros.Add(Datos.DAL.crearParametro("barid", NpgsqlDbType.Integer, ent.barid));
                parametros.Add(Datos.DAL.crearParametro("sucid", NpgsqlDbType.Integer, ent.sucid));
                parametros.Add(Datos.DAL.crearParametro("entcomentario", NpgsqlDbType.Text, ent.entcomentarios));
                parametros.Add(Datos.DAL.crearParametro("tpeid", NpgsqlDbType.Integer, ent.tpeid));
                parametros.Add(Datos.DAL.crearParametro("entcosto", NpgsqlDbType.Numeric, ent.entcosto));
                parametros.Add(Datos.DAL.crearParametro("eseid", NpgsqlDbType.Integer, ent.eseid));
                parametros.Add(Datos.DAL.crearParametro("tpsid", NpgsqlDbType.Integer, ent.tpsid));
                parametros.Add(Datos.DAL.crearParametro("ent_id", NpgsqlDbType.Integer, ent.entid));
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

        //public static DataTable GetEntregasDesdeHasta(DateTime desde, DateTime hasta)
        //{
        //    string procedureName = "sp_entrega_obtenertodoentrefechas";
        //    List<NpgsqlParameter> parametros = new List<NpgsqlParameter>();
        //    parametros.Add(DAL.crearParametro("desde", NpgsqlDbType.Date, desde));
        //    parametros.Add(DAL.crearParametro("hasta", NpgsqlDbType.Date, hasta));
        //    DataTable dt = DAL.EjecutarStoreConsultaConParametros(procedureName, parametros);
        //    return dt;
        //}


        public static List<Entrega> GetEntregasDesdeHasta(DateTime desde, DateTime hasta)
        {
            List<Entrega> ents = new List<Entrega>();
            string procedureName = "sp_entrega_obtenertodoentrefechas";
            List<NpgsqlParameter> parametros = new List<NpgsqlParameter>();
            parametros.Add(Datos.DAL.crearParametro("desde", NpgsqlDbType.Date, desde));
            parametros.Add(Datos.DAL.crearParametro("hasta", NpgsqlDbType.Date, hasta));
            DataTable dt = Datos.DAL.EjecutarStoreConsultaConParametros(procedureName, parametros);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Entrega ent = new Entrega();
                    ent.barid = Convert.ToInt32(dr["barid"]);
                    ent.entcalle = dr["entcalle"].ToString();
                    ent.entcomentarios = dr["entcomentarios"].ToString();
                    ent.entcosto = Convert.ToDecimal(dr["entcosto"]);
                    ent.entdepto = dr["entdepto"].ToString();
                    ent.entfecha = Convert.ToDateTime(dr["entfecha"]);
                    ent.entnumero = dr["entnumero"].ToString();
                    ent.entid = Convert.ToInt32(dr["entid"]);
                    ent.entpiso = dr["entpiso"].ToString();
                    ent.eseid = Convert.ToInt32(dr["eseid"]);
                    ent.remnumero = dr["remnumero"].ToString();
                    ent.sucid = Convert.ToInt32(dr["sucid"]);
                    ent.tpeid = Convert.ToInt32(dr["tpeid"]);
                    ent.tpsid = Convert.ToInt32(dr["tpsid"]);

                    ents.Add(ent);
                }
            }
            return ents;
        }



        public static List<Entrega> GetEntregasPorFecha(DateTime fecha)
        {
            List<Entrega> ents = new List<Entrega>();
            string procedureName = "sp_entrega_obtenertodoporfecha";
            List<NpgsqlParameter> parametros = new List<NpgsqlParameter>();
            parametros.Add(Datos.DAL.crearParametro("desde", NpgsqlDbType.Date, fecha));
            DataTable dt = Datos.DAL.EjecutarStoreConsultaConParametros(procedureName, parametros);
            if (dt.Rows.Count > 0)
            {
                foreach(DataRow dr in dt.Rows)
                {
                    Entrega ent = new Entrega();
                    ent.barid = Convert.ToInt32(dr["barid"]);
                    ent.entcalle = dr["entcalle"].ToString();
                    ent.entcomentarios = dr["entcomentarios"].ToString();
                    ent.entcosto = Convert.ToDecimal(dr["entcosto"]);
                    ent.entdepto = dr["entdepto"].ToString();
                    ent.entfecha = Convert.ToDateTime(dr["entfecha"]);
                    ent.entnumero = dr["entnumero"].ToString();
                    ent.entid = Convert.ToInt32(dr["entid"]);
                    ent.entpiso = dr["entpiso"].ToString();
                    ent.eseid = Convert.ToInt32(dr["eseid"]);
                    ent.remnumero = dr["remnumero"].ToString();
                    ent.sucid = Convert.ToInt32(dr["sucid"]);
                    ent.tpeid = Convert.ToInt32(dr["tpeid"]);
                    ent.tpsid = Convert.ToInt32(dr["tpsid"]);
                    
                    ents.Add(ent);
                }
            }


            return ents;
        }



        public static DataTable GetEntregasPorDia(DateTime fecha)
        {
            string procedureName = "sp_entrega_obtenertodopordia";
            List<NpgsqlParameter> parametros = new List<NpgsqlParameter>();
            parametros.Add(Datos.DAL.crearParametro("desde", NpgsqlDbType.Date, fecha));
            DataTable dt = Datos.DAL.EjecutarStoreConsultaConParametros(procedureName, parametros);
            return dt;
        }


        public static DataTable GetEntregasTodas()
        {
            string procedureName = "sp_entrega_obtenertodo";
            DataTable dt = Datos.DAL.EjecutarStoreConsulta(procedureName);
            return dt;
        }


        public static List<Entrega> GetTodos()
        {
            List<Entrega> ents = new List<Entrega>();
            string procedureName = "sp_entrega_gettodo";
            DataTable dt = Datos.DAL.EjecutarStoreConsulta(procedureName);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Entrega ent = new Entrega();
                    ent.remnumero = dr["remnumero"].ToString();
                    ent.entfecha = Convert.ToDateTime(dr["entfecha"]);
                    ent.entcalle = dr["entcalle"].ToString();
                    ent.entnumero = dr["entnumero"].ToString();
                    ent.entpiso = dr["entpiso"].ToString();
                    ent.entdepto = dr["entdepto"].ToString();
                    ent.barid = Convert.ToInt32(dr["barid"]);
                    ent.sucid = Convert.ToInt32(dr["sucid"]);
                    ent.tpeid = Convert.ToInt32(dr["tpeid"]);
                    ent.entcosto = Convert.ToDecimal(dr["entcosto"]);
                    ent.tpsid = Convert.ToInt32(dr["tpsid"]);
                    ent.eseid = Convert.ToInt32(dr["eseid"]);
                    ents.Add(ent);
                }
            }
            return ents;
        }
    

        public static DataTable GetEntregasTodasConId()
        {
            string procedureName = "sp_entrega_obtenertodas";
            DataTable dt = Datos.DAL.EjecutarStoreConsulta(procedureName);
            return dt;
        }

       

        public static DataTable GetEntregasDesdeHastaX(DateTime desde, DateTime hasta)
        {
            string procedureName = "sp_entrega_obtenertododesdehasta";
            List<NpgsqlParameter> parametros = new List<NpgsqlParameter>();
            parametros.Add(Datos.DAL.crearParametro("desde", NpgsqlDbType.Date, desde));
            parametros.Add(Datos.DAL.crearParametro("hasta", NpgsqlDbType.Date, hasta));
            DataTable dt = Datos.DAL.EjecutarStoreConsultaConParametros(procedureName, parametros);
            return dt;
        }

         public static DataTable GetEntregasFecha(DateTime fecha, DateTime hasta)
        {
            string procedureName = "sp_entrega_obtenerporfecha";
            List<NpgsqlParameter> parametros = new List<NpgsqlParameter>();
            parametros.Add(Datos.DAL.crearParametro("fec", NpgsqlDbType.Date, fecha));
            parametros.Add(Datos.DAL.crearParametro("has", NpgsqlDbType.Date, hasta));
            DataTable dt = Datos.DAL.EjecutarStoreConsultaConParametros(procedureName, parametros);
            return dt;
        }


         public static List<Entrega> GetEntreFechas(DateTime desde, DateTime hasta)
         {
             List<Entrega> ents = new List<Entrega>();
             string procedureName = "sp_entrega_getentrefechas";
             List<NpgsqlParameter> parametros = new List<NpgsqlParameter>();
             parametros.Add(Datos.DAL.crearParametro("fec", NpgsqlDbType.Date, desde));
             parametros.Add(Datos.DAL.crearParametro("has", NpgsqlDbType.Date, hasta));
             DataTable dt = Datos.DAL.EjecutarStoreConsultaConParametros(procedureName, parametros);
             if (dt.Rows.Count > 0)
             {
                 foreach (DataRow dr in dt.Rows)
                 {
                     Entrega ent = new Entrega();
                     ent.remnumero = dr["remnumero"].ToString();
                     ent.entfecha = Convert.ToDateTime(dr["entfecha"]);
                     ent.entcalle = dr["entcalle"].ToString();
                     ent.entnumero = dr["entnumero"].ToString();
                     ent.entpiso = dr["entpiso"].ToString();
                     ent.entdepto = dr["entdepto"].ToString();
                     ent.barid = Convert.ToInt32(dr["barid"]);
                     ent.sucid = Convert.ToInt32(dr["sucid"]);
                     ent.tpeid = Convert.ToInt32(dr["tpeid"]);
                     ent.entcosto = Convert.ToDecimal(dr["entcosto"]);
                     ent.tpsid = Convert.ToInt32(dr["tpsid"]);
                     ent.eseid = Convert.ToInt32(dr["eseid"]);
                     ents.Add(ent);
                 }
             }
             return ents;
         }


         public static DataTable GetEntregasFechas(DateTime fecha, DateTime hasta)
         {
             string procedureName = "sp_entrega_obtenerporfechas";
             List<NpgsqlParameter> parametros = new List<NpgsqlParameter>();
             parametros.Add(Datos.DAL.crearParametro("fec", NpgsqlDbType.Date, fecha));
             parametros.Add(Datos.DAL.crearParametro("has", NpgsqlDbType.Date, hasta));
             DataTable dt = Datos.DAL.EjecutarStoreConsultaConParametros(procedureName, parametros);
             return dt;
         }

         public static DataTable GetEntregasPorRemito(string remnumero)
         {
             string procedureName = "sp_entrega_obtenerporremito";
             List<NpgsqlParameter> parametros = new List<NpgsqlParameter>();
             parametros.Add(Datos.DAL.crearParametro("remito", NpgsqlDbType.Text, remnumero));
             DataTable dt = Datos.DAL.EjecutarStoreConsultaConParametros(procedureName, parametros);
             return dt;
         }


        

         public static DataTable GetEntregaPorSucursalRemito(int sucid, string remnumero)
         {
             string procedureName = "sp_entrega_obtenerporidsucursalremito";
             List<NpgsqlParameter> parametros = new List<NpgsqlParameter>();
             parametros.Add(Datos.DAL.crearParametro("sucid", NpgsqlDbType.Integer, sucid));
             parametros.Add(Datos.DAL.crearParametro("remnum", NpgsqlDbType.Text, remnumero));
             DataTable dt = Datos.DAL.EjecutarStoreConsultaConParametros(procedureName, parametros);
             return dt;
         }


         public static int EntregaActualizarRecibido(int entid)
         {
             try
             {
                 string procedureName = "sp_entrega_actualizarrecibido";
                 List<NpgsqlParameter> parametros = new List<NpgsqlParameter>();
                 parametros.Add(Datos.DAL.crearParametro("id", NpgsqlDbType.Integer, entid));
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

         public static int EntregaAnular(int entid)
         {
             try
             {
                 string procedureName = "sp_entrega_anular";
                 List<NpgsqlParameter> parametros = new List<NpgsqlParameter>();
                 parametros.Add(Datos.DAL.crearParametro("id", NpgsqlDbType.Integer, entid));
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


         public static DataTable GetEntregasEstado(int entid)
         {
             string procedureName = "sp_entrega_obtenerestadoporid";
             List<NpgsqlParameter> parametros = new List<NpgsqlParameter>();
             parametros.Add(Datos.DAL.crearParametro("entid", NpgsqlDbType.Integer, entid));
             DataTable dt = Datos.DAL.EjecutarStoreConsultaConParametros(procedureName, parametros);
             return dt;
         }

         public static DataTable GetEntregasConCostoFechas(DateTime desde, DateTime hasta)
         {
             string procedureName = "sp_entrega_obtenerconcosto";
             List<NpgsqlParameter> parametros = new List<NpgsqlParameter>();
             parametros.Add(Datos.DAL.crearParametro("desde", NpgsqlDbType.Date, desde));
             parametros.Add(Datos.DAL.crearParametro("hasta", NpgsqlDbType.Date, hasta));
             DataTable dt = Datos.DAL.EjecutarStoreConsultaConParametros(procedureName, parametros);
             return dt;
         }


         public static List<Entrega> GetConCostoEntreFechas(DateTime desde, DateTime hasta)
         {
             List<Entrega> ents = new List<Entrega>();
             string procedureName = "sp_entrega_getconcosto";
             List<NpgsqlParameter> parametros = new List<NpgsqlParameter>();
             parametros.Add(Datos.DAL.crearParametro("desde", NpgsqlDbType.Date, desde));
             parametros.Add(Datos.DAL.crearParametro("hasta", NpgsqlDbType.Date, hasta));
             DataTable dt = Datos.DAL.EjecutarStoreConsultaConParametros(procedureName, parametros);
             if (dt.Rows.Count > 0)
             {
                 foreach (DataRow dr in dt.Rows)
                 {
                     Entrega ent = new Entrega();
                     ent.remnumero = dr["remnumero"].ToString();
                     ent.entfecha = Convert.ToDateTime(dr["entfecha"]);
                     ent.sucid = Convert.ToInt32(dr["sucid"]);
                     ent.barid = Convert.ToInt32(dr["barid"]);
                     ent.entcosto = Convert.ToDecimal(dr["entcosto"]);
                     ent.tpeid = Convert.ToInt32(dr["tpeid"]);
                     ent.eseid = Convert.ToInt32(dr["eseid"]);
                     ents.Add(ent);
                 }
             }

             return ents;
         }


         public static Entrega GetPorId(int entid)
         {
             Entrega ent = new Entrega();
             string procedureName = "sp_entrega_gettodoporid";
             DataTable dt = Datos.DAL.EjecutarStoreConParametro(procedureName, "ent_id", entid);
             if (dt.Rows.Count > 0)
             {                 
                 ent.barid = Convert.ToInt32(dt.Rows[0]["barid"]);
                 ent.entcalle = dt.Rows[0]["entcalle"].ToString();
                 ent.entcomentarios = dt.Rows[0]["entcomentarios"].ToString();
                 ent.entcosto = Convert.ToDecimal(dt.Rows[0]["entcosto"]);
                 ent.entdepto = dt.Rows[0]["entdepto"].ToString();
                 ent.entfecha = Convert.ToDateTime(dt.Rows[0]["entfecha"]);
                 ent.entid = Convert.ToInt32(dt.Rows[0]["entid"]);
                 ent.entnumero = dt.Rows[0]["entnumero"].ToString();
                 ent.entpiso = dt.Rows[0]["entpiso"].ToString();
                 ent.eseid = Convert.ToInt32(dt.Rows[0]["eseid"]);
                 ent.remnumero = dt.Rows[0]["remnumero"].ToString();
                 ent.sucid = Convert.ToInt32(dt.Rows[0]["sucid"]);
                 ent.tpeid = Convert.ToInt32(dt.Rows[0]["tpeid"]);
                 ent.tpsid = Convert.ToInt32(dt.Rows[0]["tpsid"]);               
             }

             return ent;
         }

         public static DataTable GetDetallePorDias(DateTime desde, DateTime hasta)
         {
             string procedureName = "sp_entrega_obtenerdetallepordias";
             List<NpgsqlParameter> parametros = new List<NpgsqlParameter>();
             parametros.Add(Datos.DAL.crearParametro("desde", NpgsqlDbType.Date, desde));
             parametros.Add(Datos.DAL.crearParametro("hasta", NpgsqlDbType.Date, hasta));
             DataTable dt = Datos.DAL.EjecutarStoreConsultaConParametros(procedureName, parametros);
             return dt;
         }

         public static DataTable GetPorFecha(DateTime fecha)
         {
             string procedureName = "sp_entrega_obtenerfecha";
             List<NpgsqlParameter> parametros = new List<NpgsqlParameter>();
             parametros.Add(Datos.DAL.crearParametro("fecha", NpgsqlDbType.Date, fecha));
             DataTable dt = Datos.DAL.EjecutarStoreConsultaConParametros(procedureName, parametros);
             return dt;
         }


         public static DataTable GetTotalesentreFechas(DateTime desde, DateTime hasta)
         {
             string procedureName = "sp_entrega_obtenertotalesporfechas";
             List<NpgsqlParameter> parametros = new List<NpgsqlParameter>();
             parametros.Add(Datos.DAL.crearParametro("desde", NpgsqlDbType.Date, desde));
             parametros.Add(Datos.DAL.crearParametro("hasta", NpgsqlDbType.Date, hasta));
             DataTable dt = Datos.DAL.EjecutarStoreConsultaConParametros(procedureName, parametros);
             return dt;
         }

         public static DataTable GetCantidad(DateTime fecha)
         {
             string procedureName = "sp_entrega_obtenercantidad";
             List<NpgsqlParameter> parametros = new List<NpgsqlParameter>();
             parametros.Add(Datos.DAL.crearParametro("fecha", NpgsqlDbType.Date, fecha));
             DataTable dt = Datos.DAL.EjecutarStoreConsultaConParametros(procedureName, parametros);
             return dt;
         }
    }
}
