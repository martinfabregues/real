using DAL.Repositories;
using Entidad;
using System;
using System.Collections.Generic;
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

        public static int add(RemitoProveedor newEntity)
        {
            IRemitoProveedorRepository _repository = new RemitoProveedorRepository();
            return _repository.add(newEntity);
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

    }
}
