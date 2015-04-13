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
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IEntregasService" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IEntregasService
    {
        [OperationContract]
        string DoWork();

        [OperationContract]
        DataTable FindAll();
    }
}
