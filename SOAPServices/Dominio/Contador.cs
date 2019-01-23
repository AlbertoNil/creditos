using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SOAPServices.Dominio
{
    public class Contador
    {
        [DataMember]
        public int IdContador { get; set; }
        [DataMember]
        public string CodAlumno { get; set; }
        [DataMember]
        public int Contar { get; set; }
    }
}