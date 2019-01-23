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
      /*
        [OperationContract]
        Credito ObtenerCredito(int codcredito);
        [OperationContract]
        Credito ObtenerPregunta(string coddescripcion);
        */
        [OperationContract]
        void EliminarCredito(int dni);
        [OperationContract]
        List<Credito> ListarCreditos();




        /*
        [OperationContract]
        [FaultContract(typeof(PreguntaExistenteError))]

        Credito CrearCredito(Credito creditoACrear);
        
         [OperationContract]
        ICollection<Credito> ListarCreditos();
         */

        /*
        [OperationContract]
        void EliminarCredito(int codcredito);
        [OperationContract]
        List<Credito> ListarCreditos();
        */


    }
}
