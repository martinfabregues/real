using DAL;
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
    public class Clientes
    {
        public static int ClienteInsertar(Cliente cli)
        {
            try
            {
                string procedureName = "sp_cliente_insertar";
                List<NpgsqlParameter> parametros = new List<NpgsqlParameter>();
                parametros.Add(Datos.DAL.crearParametro("clinombre", NpgsqlDbType.Text, cli.clinombre));
                parametros.Add(Datos.DAL.crearParametro("clidocumento", NpgsqlDbType.Text, cli.clidocumento));
                //parametros.Add(Datos.DAL.crearParametro("tpiid", NpgsqlDbType.Integer, cli.tpiid));
                //parametros.Add(Datos.DAL.crearParametro("barid", NpgsqlDbType.Integer, cli.barid));
                //parametros.Add(Datos.DAL.crearParametro("ciuid", NpgsqlDbType.Integer, cli.ciuid));
                parametros.Add(Datos.DAL.crearParametro("clicalle", NpgsqlDbType.Text, cli.clicalle));
                parametros.Add(Datos.DAL.crearParametro("clinumero", NpgsqlDbType.Text, cli.clinumero));
                parametros.Add(Datos.DAL.crearParametro("clipiso", NpgsqlDbType.Text, cli.clipiso));
                parametros.Add(Datos.DAL.crearParametro("clidepto", NpgsqlDbType.Text, cli.clidepto));
                parametros.Add(Datos.DAL.crearParametro("clitelefonofijo", NpgsqlDbType.Text, cli.clitelefonofijo));
                parametros.Add(Datos.DAL.crearParametro("clitelefonocelular", NpgsqlDbType.Text, cli.clitelefonocelular));
                parametros.Add(Datos.DAL.crearParametro("cliemail", NpgsqlDbType.Text, cli.cliemail));
                //parametros.Add(Datos.DAL.crearParametro("estid", NpgsqlDbType.Integer, cli.estid));
                parametros.Add(Datos.DAL.crearParametro("clifecha", NpgsqlDbType.Date, cli.clifecha));

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


        public static DataTable ClienteObtenerTodo()
        {
            DataTable dtCliente = new DataTable();
            string procedureName = "sp_cliente_obtenertodos";
            dtCliente = Datos.DAL.EjecutarStoreConsulta(procedureName);
            return dtCliente;
        }



        public static DataTable GetClienteDatosPodId(int cliid)
        {
            string procedureName = "sp_cliente_obtenerdatosporid";
            List<NpgsqlParameter> parametros = new List<NpgsqlParameter>();
            parametros.Add(Datos.DAL.crearParametro("id", NpgsqlDbType.Integer, cliid));
            DataTable dt = Datos.DAL.EjecutarStoreConsultaConParametros(procedureName, parametros);
            return dt;
        }


        public static DataTable GetClienteDatosLikeNombre(string clinombre)
        {
            string procedureName = "sp_cliente_obtenerlikenombre";
            List<NpgsqlParameter> parametros = new List<NpgsqlParameter>();
            parametros.Add(Datos.DAL.crearParametro("clinom", NpgsqlDbType.Text, clinombre));
            DataTable dt = Datos.DAL.EjecutarStoreConsultaConParametros(procedureName, parametros);
            return dt;
        }


        public static DataTable GetClienteDatosPorCodigo(string clicodigo)
        {
            string procedureName = "sp_cliente_obtenertodoporcodigo";
            List<NpgsqlParameter> parametros = new List<NpgsqlParameter>();
            parametros.Add(Datos.DAL.crearParametro("cli_cod", NpgsqlDbType.Text, clicodigo));
            DataTable dt = Datos.DAL.EjecutarStoreConsultaConParametros(procedureName, parametros);
            return dt;
        }

        public static Cliente Crear(Cliente cliente)
        {
            cliente = ClienteDAL.Crear(cliente);
            return cliente;
        }

        public static Cliente GetPorId(Cliente cliente)
        {
            cliente = ClienteDAL.GetPorId(cliente.cliid);
            return cliente;
        }

        public static List<Cliente> GetTodos()
        {
            List<Cliente> list = ClienteDAL.GetTodo();
            return list;
        }

        public static List<Cliente> GetTodosConsulta()
        {
            List<Cliente> list = ClienteDAL.GetTodoConsulta();
            return list;
        }


        public static Boolean Modificar(Cliente cliente)
        {
            bool resultado = ClienteDAL.Modificar(cliente);
            return resultado;
        }
    }
}
