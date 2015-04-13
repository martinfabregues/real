using DAL.Repositories;
using Datos;
using Entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Services
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static IList<Service> FindAll()
        {
            ServiceRepository servicerepository = new ServiceRepository();
            IList<Service> datos = servicerepository.FindAll();
            return datos;
        }

        public static int Add(Service newEntity)
        {
            ServiceRepository servicerepository = new ServiceRepository();
            return servicerepository.add(newEntity);
        }
    
    }
}
