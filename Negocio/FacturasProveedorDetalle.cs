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
    public class FacturasProveedorDetalle
    {

        public static int FacturaProveedorDetalleInsertar(FacturaProveedorDetalle fpd)
        {

            string procedureName = "sp_facturaproveedordetalle_insertar";

            List<NpgsqlParameter> parametros = new List<NpgsqlParameter>();
            parametros.Add(Datos.DAL.crearParametro("fap_id", NpgsqlDbType.Integer, fpd.fapid));
            parametros.Add(Datos.DAL.crearParametro("prd_id", NpgsqlDbType.Integer, fpd.prdid));
            parametros.Add(Datos.DAL.crearParametro("fpd_importeunit", NpgsqlDbType.Numeric, fpd.fpdimporteunit));
            parametros.Add(Datos.DAL.crearParametro("fpdcantidad", NpgsqlDbType.Integer, fpd.fpdcantidad));
            parametros.Add(Datos.DAL.crearParametro("odc_id", NpgsqlDbType.Integer, fpd.odcid));

            int resultado = Datos.DAL.EjecutarStoreInsert(procedureName, parametros);
            return resultado;

        }


        public static DataTable GetFacturaProveedorTodo()
        {
            string procedureName = "sp_facturaproveedor_obtenertodo";
            DataTable dt = Datos.DAL.EjecutarStoreConsulta(procedureName);
            return dt;
        }


        public static DataTable GetFacturaProveedorTodoPorNombreProducto(string prddenominacion)
        {
            string procedureName = "sp_facturaproveedor_obtenertodolikeproducto";
            List<NpgsqlParameter> parametros = new List<NpgsqlParameter>();
            parametros.Add(Datos.DAL.crearParametro("prd_denominacion", NpgsqlDbType.Text, prddenominacion));
            DataTable dt = Datos.DAL.EjecutarStoreConsultaConParametros(procedureName, parametros);
            return dt;
        }

        public static DataTable GetFacturaProveedorTodoPorNumeroFactura(string fapnumero)
        {
            string procedureName = "sp_facturaproveedor_obtenertodolikefactura";
            List<NpgsqlParameter> parametros = new List<NpgsqlParameter>();
            parametros.Add(Datos.DAL.crearParametro("fap_fapnumero", NpgsqlDbType.Text, fapnumero));
            DataTable dt = Datos.DAL.EjecutarStoreConsultaConParametros(procedureName, parametros);
            return dt;
        }

        public static DataTable GetFacturaProveedorTodoPorNumeroRemito(string fapremito)
        {
            string procedureName = "sp_facturaproveedor_obtenertodolikeremito";
            List<NpgsqlParameter> parametros = new List<NpgsqlParameter>();
            parametros.Add(Datos.DAL.crearParametro("fap_fapremito", NpgsqlDbType.Text, fapremito));
            DataTable dt = Datos.DAL.EjecutarStoreConsultaConParametros(procedureName, parametros);
            return dt;
        }

        public static DataTable GetFacturaProveedorTodoEntreFechas(DateTime desde, DateTime hasta)
        {
            string procedureName = "sp_facturaproveedor_obtenertodoentrefechas";
            List<NpgsqlParameter> parametros = new List<NpgsqlParameter>();
            parametros.Add(Datos.DAL.crearParametro("desde", NpgsqlDbType.Date, desde));
            parametros.Add(Datos.DAL.crearParametro("hasta", NpgsqlDbType.Date, hasta));
            DataTable dt = Datos.DAL.EjecutarStoreConsultaConParametros(procedureName, parametros);
            return dt;
        }


        public static DataTable GetFacturaProveedorTodoPorIdProveedor(int proid)
        {
            string procedureName = "sp_facturaproveedor_obtenertodoporidproveedor";
            List<NpgsqlParameter> parametros = new List<NpgsqlParameter>();
            parametros.Add(Datos.DAL.crearParametro("pro_id", NpgsqlDbType.Integer, proid));
            DataTable dt = Datos.DAL.EjecutarStoreConsultaConParametros(procedureName, parametros);
            return dt;
        }



        public static DataTable GetFacturaProveedorTodoPorIdSucursal(int sucid)
        {
            string procedureName = "sp_facturaproveedor_obtenertodoporidsucursal";
            List<NpgsqlParameter> parametros = new List<NpgsqlParameter>();
            parametros.Add(Datos.DAL.crearParametro("pro_id", NpgsqlDbType.Integer, sucid));
            DataTable dt = Datos.DAL.EjecutarStoreConsultaConParametros(procedureName, parametros);
            return dt;
        }

        public static List<FacturaProveedorDetalle> GetPorIdFactura(int fapid)
        {
            List<FacturaProveedorDetalle> fpds = new List<FacturaProveedorDetalle>();
            string procedureName = "sp_facturaproveedordetalle_gettodoporidfactura";
            DataTable dt = Datos.DAL.EjecutarStoreConParametro(procedureName, "fap_id", fapid);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    FacturaProveedorDetalle fpd = new FacturaProveedorDetalle();
                    fpd.fapid = Convert.ToInt32(dr["fapid"]);
                    fpd.fpdcantidad = Convert.ToInt32(dr["fpdcantidad"]);
                    fpd.fpdid = Convert.ToInt32(dr["fpdid"]);
                    fpd.fpdimporteunit = Convert.ToDecimal(dr["fpdimporteunit"]);
                    fpd.prdid = Convert.ToInt32(dr["prdid"]);
                    fpd.odcid = Convert.ToInt32(dr["odcid"]);
                    fpds.Add(fpd);
                }
            }
            return fpds;
        }


        public static int FacturaProveedorDetalleEliminarFila(int fpdid)
        {

            string procedureName = "sp_facturaproveedordetalle_elimnar";

            List<NpgsqlParameter> parametros = new List<NpgsqlParameter>();
            parametros.Add(Datos.DAL.crearParametro("fpd_id", NpgsqlDbType.Integer, fpdid));
            int resultado = Datos.DAL.EjecutarStoreInsert(procedureName, parametros);
            return resultado;

        }

    }
}
