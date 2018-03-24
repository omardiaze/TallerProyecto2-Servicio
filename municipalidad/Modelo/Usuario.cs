using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace municipalidad.Modelo
{
    [DataContract]
    public class Usuario
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public string ApePat { get; set; }
        [DataMember]
        public string ApeMat { get; set; }
        [DataMember]
        public string Dni { get; set; }
        [DataMember]
        public string Direccion { get; set; }
        [DataMember]
        public string Latitud { get; set; }
        [DataMember]
        public string Longitud { get; set; }
        [DataMember]
        public string FecNac { get; set; }
        [DataMember]
        public string Sexo { get; set; }
        [DataMember]
        public string Correo { get; set; }
        [DataMember]
        public string Imagen { get; set; }
        
    }
}