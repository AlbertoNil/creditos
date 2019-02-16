using SOAPServices.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SOAPServices
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "ICreditoService" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface ICreditoService
    {

        [OperationContract]
        Credito CrearCredito(Credito creditoACrear);
   
        [OperationContract]
        void EliminarCredito(int CodCredito);

        [OperationContract]
        List<Credito> ListarCreditos();
    }
}
