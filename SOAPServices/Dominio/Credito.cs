using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SOAPServices.Dominio
{
    public class Credito
    {
        [DataMember]
        public int CodCredito { get; set; }
        [DataMember]
        public string CodAlumno { get; set; }
        [DataMember]
        public string CodCurso { get; set; }
        [DataMember]
        public string CodDescripcion { get; set; }
        [DataMember]
        public string Tipo { get; set; }
        [DataMember]
        public DateTime FechaIng { get; set; }
    }
}