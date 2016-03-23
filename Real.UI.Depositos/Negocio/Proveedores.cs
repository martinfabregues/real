using Real.UI.Depositos.Entidad;
using Real.UI.Depositos.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Real.UI.Depositos.Negocio
{
    public class Proveedores
    {
        public static IEnumerable<Proveedor> FindAll()
        {
            IProveedorRepository _repository = new ProveedorRepository();
            return _repository.FindAll();
        }

        public static int Add(Proveedor entity)
        {
            IProveedorRepository _repository = new ProveedorRepository();
            return _repository.Add(entity);
        }
    }
}
