using DAL.Repositories;
using Entidad;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace Negocio
{
    public class RemitosProveedor
    {

        public static IList<RemitoProveedor> FindAll()
        {
            IRemitoProveedorRepository _repository = new RemitoProveedorRepository();
            return _repository.FindAll();
        }

        public static int AddRemito(RemitoProveedor newEntity)
        {
            IRemitoProveedorRepository _repository = new RemitoProveedorRepository();
            int remito_id = 0;
            bool resultado_detalle = true;

             NpgsqlConnection _cnn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RWORLD"].ToString());
            _cnn.Open();

            using (NpgsqlTransaction trans = _cnn.BeginTransaction())
            {
                remito_id = _repository.Add(newEntity, _cnn, trans);
                if(remito_id > 0)
                {
                    foreach(RemitoProveedorDetalle fila in newEntity.detalle)
                    {
                        fila.remitoproveedor_id = remito_id;

                        int detalle = _repository.AddDetalle(fila, _cnn, trans);
                        if(detalle > 0)
                        {
                            int pendiente = _repository.ActualizarPendiente(newEntity.proveedor_id, newEntity.sucursal_id,
                                fila.cantidad, fila.producto_id, fila.orden_id, _cnn, trans);
                            if(pendiente == 0 )
                            {
                                resultado_detalle = false;
                                remito_id = 0;
                                trans.Rollback();
                                break;
                            }
                        }
                        else
                        {
                            remito_id = 0;
                            resultado_detalle = false;
                            trans.Rollback();
                            break;

                        }
                    }
                    if(resultado_detalle == true)
                    {
                        trans.Commit();
                    }
                }
                else
                {
                    trans.Rollback();
                    remito_id = 0;                  
                }

            }

            return remito_id;
        }


        public static IList<RemitoProveedor> FindAllWithSucursal()
        {
            IRemitoProveedorRepository _repository = new RemitoProveedorRepository();
            return _repository.FindAllWithSucursal();
        }

        public static IList<RemitoProveedor> FindAllLikeNumero(string numero)
        {
            IRemitoProveedorRepository _repository = new RemitoProveedorRepository();
            return _repository.FindAllLikeNumero(numero);
        }


        public static IList<RemitoProveedorDetalle> FindIngresos()
        {
            IRemitoProveedorRepository _repository = new RemitoProveedorRepository();
            return _repository.FindIngresos();
        }

        public static IList<RemitoProveedorDetalle> FindIngresosCondicional(string remito_numero, string prod, int? proveedor_id, int? sucursal_id, DateTime? desde, DateTime? hasta)
        {
            IRemitoProveedorRepository _repository = new RemitoProveedorRepository();
            return _repository.FindIngresosCondicional(remito_numero, prod, proveedor_id, sucursal_id, desde, hasta);
        }

        public static IList<RemitoProveedor> FindAllByIdFactura(int factura_id)
        {
            IRemitoProveedorRepository _repository = new RemitoProveedorRepository();
            return _repository.FindAllByIdFactura(factura_id);
        }
    }
}
