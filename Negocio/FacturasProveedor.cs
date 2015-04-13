using DAL.Repositories;
using Datos;
using Entidad;
using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Negocio
{
    public class FacturasProveedor
    {

        public static int FacturaProveedorInsertar(FacturaProveedor fap)
        {

            string procedureName = "sp_facturaproveedor_insertar";

            List<NpgsqlParameter> parametros = new List<NpgsqlParameter>();
            parametros.Add(Datos.DAL.crearParametro("fap_numero", NpgsqlDbType.Text, fap.numero));
            parametros.Add(Datos.DAL.crearParametro("fap_fecha", NpgsqlDbType.Date, fap.fecha));
            parametros.Add(Datos.DAL.crearParametro("fap_fecharecepcion", NpgsqlDbType.Date, fap.fecharecepcion));
            parametros.Add(Datos.DAL.crearParametro("suc_id", NpgsqlDbType.Integer, fap.sucursal_id));
            parametros.Add(Datos.DAL.crearParametro("pro_id", NpgsqlDbType.Integer, fap.proveedor_id));
            parametros.Add(Datos.DAL.crearParametro("fap_remito", NpgsqlDbType.Text, fap.numeroremito));
            parametros.Add(Datos.DAL.crearParametro("est_id", NpgsqlDbType.Integer, fap.activo));
            parametros.Add(Datos.DAL.crearParametro("fap_importe", NpgsqlDbType.Numeric, fap.importe));
            int resultado = Datos.DAL.EjecutarStoreInsert(procedureName, parametros);
            return resultado;

        }

        public static int FacturaProveedorModificar(FacturaProveedor fap)
        {

            string procedureName = "sp_facturaproveedor_modificar";

            List<NpgsqlParameter> parametros = new List<NpgsqlParameter>();
            parametros.Add(Datos.DAL.crearParametro("fap_numero", NpgsqlDbType.Text, fap.numero));
            parametros.Add(Datos.DAL.crearParametro("fap_fecha", NpgsqlDbType.Date, fap.fecha));
            parametros.Add(Datos.DAL.crearParametro("fap_fecharecepcion", NpgsqlDbType.Date, fap.fecharecepcion));
            parametros.Add(Datos.DAL.crearParametro("suc_id", NpgsqlDbType.Integer, fap.sucursal_id));
            parametros.Add(Datos.DAL.crearParametro("pro_id", NpgsqlDbType.Integer, fap.proveedor_id));
            parametros.Add(Datos.DAL.crearParametro("fap_remito", NpgsqlDbType.Text, fap.numeroremito));
            parametros.Add(Datos.DAL.crearParametro("est_id", NpgsqlDbType.Integer, fap.activo));
            parametros.Add(Datos.DAL.crearParametro("fap_importe", NpgsqlDbType.Numeric, fap.importe));
            parametros.Add(Datos.DAL.crearParametro("fap_id", NpgsqlDbType.Integer, fap.id));
            int resultado = Datos.DAL.EjecutarStoreInsert(procedureName, parametros);
            return resultado;

        }


        public static List<FacturaProveedor> GetTodos()
        {
            List<FacturaProveedor> facs = new List<FacturaProveedor>(); 
            DataTable dt = new DataTable();
            string procedureName = "sp_facturaproveedor_gettodo";
            dt = Datos.DAL.EjecutarStoreConsulta(procedureName);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    FacturaProveedor facp = new FacturaProveedor();
                    facp.activo = Convert.ToInt32(dr["estid"]);
                    facp.fecha = Convert.ToDateTime(dr["fapfecha"]);
                    facp.fecharecepcion = Convert.ToDateTime(dr["fapfecharecepcion"]);
                    facp.id = Convert.ToInt32(dr["fapid"]);
                    facp.importe = Convert.ToDecimal(dr["fapimporte"]);
                    facp.numero = dr["fapnumero"].ToString();
                    facp.numeroremito = dr["fapremito"].ToString();
                    facp.proveedor_id = Convert.ToInt32(dr["proid"]);
                    facp.sucursal_id = Convert.ToInt32(dr["sucid"]);
                    facs.Add(facp);

                }
            }
            return facs;
        }

        public static FacturaProveedor GetPorId(int fapid)
        {
            FacturaProveedor fap = new FacturaProveedor();
            string procedureName = "sp_facturaproveedor_gettodoporid";
            DataTable dt = Datos.DAL.EjecutarStoreConParametro(procedureName, "fap_id", fapid);
            if (dt.Rows.Count > 0)
            {
                fap.sucursal_id = Convert.ToInt32(dt.Rows[0]["sucid"]);
                fap.proveedor_id = Convert.ToInt32(dt.Rows[0]["proid"]);
                fap.numeroremito = dt.Rows[0]["fapremito"].ToString();
                fap.numero = dt.Rows[0]["fapnumero"].ToString();
                fap.importe = Convert.ToDecimal(dt.Rows[0]["fapimporte"]);
                fap.id = Convert.ToInt32(dt.Rows[0]["fapid"]);
                fap.fecharecepcion = Convert.ToDateTime(dt.Rows[0]["fapfecharecepcion"]);
                fap.fecha = Convert.ToDateTime(dt.Rows[0]["fapfecha"]);
                fap.activo = Convert.ToInt32(dt.Rows[0]["estid"]);                
            }
            return fap;
        }


        public static FacturaProveedor GetPorNro(string fapnumero)
        {
            FacturaProveedor fac = new FacturaProveedor();
            string procedureName = "sp_facturaproveedor_gettodopornumero";
            DataTable dt = Datos.DAL.EjecutarStoreConParametro(procedureName, "fap_numero", fapnumero);
            if (dt.Rows.Count > 0)
            {
                fac.sucursal_id = Convert.ToInt32(dt.Rows[0]["sucid"]);
                fac.proveedor_id = Convert.ToInt32(dt.Rows[0]["proid"]);
                fac.numeroremito = dt.Rows[0]["fapremito"].ToString();
                fac.numero = dt.Rows[0]["fapnumero"].ToString();
                fac.importe = Convert.ToDecimal(dt.Rows[0]["fapimporte"]);
                fac.id = Convert.ToInt32(dt.Rows[0]["fapid"]);
                fac.fecharecepcion = Convert.ToDateTime(dt.Rows[0]["fapfecharecepcion"]);
                fac.fecha = Convert.ToDateTime(dt.Rows[0]["fapfecha"]);
                fac.activo = Convert.ToInt32(dt.Rows[0]["estid"]);       


            }


            return fac;

        }


        public static int add(FacturaProveedor newEntity)
        {
            IFacturaProveedorRepository _repository = new FacturaProveedorRepository();
            int factura_id = 0;
            bool resultado = true;
            bool resultado_remitos = true;

             NpgsqlConnection _cnn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString());
            _cnn.Open();

            using (var trans = _cnn.BeginTransaction())
            {
                factura_id = _repository.Add(newEntity, _cnn, trans);
                if(factura_id > 0)
                {
                    foreach(FacturaProveedorDetalle fila in newEntity.detalle)
                    {
                        fila.fapid = factura_id;
                        int detalle = _repository.AddDetalle(fila, _cnn, trans);
                        if(detalle == 0)
                        {
                            factura_id = 0;
                            resultado = false;
                            trans.Rollback();
                            break;
                        }
                    }

                    if(resultado == true)
                    {
                        foreach(RemitoProveedor fila in newEntity.remitos)
                        {
                            int vinculo = _repository.AddRelacionFacturaRemito(factura_id, fila.id, _cnn, trans);
                            if(vinculo == 0)
                            {
                                factura_id = 0;
                                resultado_remitos = false;
                                trans.Rollback();
                                break;
                            }
                        }
                        if(resultado_remitos == true)
                        {
                            trans.Commit();
                        }
                    }
                }
            }

            return factura_id;
        }


        public static int VerificarFactura(string numero)
        {
            IFacturaProveedorRepository _repository = new FacturaProveedorRepository();
            return _repository.VerificarFactura(numero);
        }




        public static int AddFacturaConRemito(FacturaProveedor factura, RemitoProveedor remito)
        {
            int factura_id = 0;
            bool resultado = true;
            bool resultado_remito = true;

            IFacturaProveedorRepository _repositoryFactura = new FacturaProveedorRepository();
            IRemitoProveedorRepository _repositoryRemito = new RemitoProveedorRepository();

            NpgsqlConnection _cnn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString());
            _cnn.Open();
            //NpgsqlTransaction trans = _cnn.BeginTransaction();

            using (NpgsqlTransaction trans = _cnn.BeginTransaction())
            {
                factura_id = _repositoryFactura.Add(factura, _cnn, trans);
                if (factura_id > 0)
                {
                    foreach (FacturaProveedorDetalle fila in factura.detalle)
                    {
                        fila.fapid = factura_id;
                        int factura_detalle = _repositoryFactura.AddDetalle(fila, _cnn, trans);
                        if (factura_detalle == 0)
                        {
                            resultado = false;
                            factura_id = 0;
                            trans.Rollback();
                            break;
                        }
                    }

                    if (resultado == true)
                    {
                        int remito_id = _repositoryRemito.add(remito);
                        if (remito_id > 0)
                        {
                            foreach (RemitoProveedorDetalle fila in remito.detalle)
                            {
                                fila.remitoproveedor_id = remito_id;
                                int remito_detalle = _repositoryRemito.AddDetalle(fila, _cnn, trans);
                                if (remito_detalle > 0)
                                {
                                    int pendiente = _repositoryRemito.ActualizarPendiente(remito.proveedor_id,
                                        remito.sucursal_id, fila.cantidad, fila.producto_id, fila.orden_id, _cnn, trans);

                                    if (pendiente == 0)
                                    {
                                        resultado_remito = false;
                                        factura_id = 0;
                                        trans.Rollback();
                                        break;
                                    }
                                }
                                else
                                {
                                    resultado_remito = false;
                                    factura_id = 0;
                                    trans.Rollback();
                                    break;
                                }
                            }

                            if (resultado_remito == true)
                            {
                                int relacion = _repositoryFactura.AddRelacionFacturaRemito(factura_id, remito_id, _cnn, trans);
                                if (relacion > 0)
                                {
                                    trans.Commit();
                                }
                                else
                                {
                                    factura_id = 0;
                                    trans.Rollback();
                                }
                            }
                        }
                    }                  
                }
            }

            return factura_id;
        }



    }
}
