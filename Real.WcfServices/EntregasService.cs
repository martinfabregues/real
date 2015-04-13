using DAL.Repositories;
using Entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Real.WcfServices
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "EntregasService" en el código y en el archivo de configuración a la vez.
    public class EntregasService : IEntregasService
    {
        public string DoWork()
        {
            return "OK";
        }

        public DataTable FindAll()
        {
            IEntregaRepository _repository = new EntregaRepository();
            return _repository.FindAllDT();
        }

    }
}
