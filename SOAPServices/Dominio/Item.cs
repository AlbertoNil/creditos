using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SOAPServices.Dominio
{
    [DataContract]

    public class Item
    {
        [DataMember]
        public int CodigoAlumno { get; set; }
        [DataMember]
        public decimal Cantidad { get; set; }
    }
}