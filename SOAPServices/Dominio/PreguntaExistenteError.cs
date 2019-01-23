using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SOAPServices.Dominio
{
    [DataContract]
    public class PreguntaExistenteError
    {
        [DataMember]
        public string CodigoError { get; set; }
        [DataMember]
        public string MensajeError { get; set; }
    }
}