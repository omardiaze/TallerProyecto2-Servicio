using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace municipalidad.Modelo
{
    [DataContract]
    public class Queja
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Descripcion { get; set; }
        [DataMember]
        public string Fecha { get; set; }
        [DataMember]
        public string Correo { get; set; }
        [DataMember]
        public string Tipo { get; set; }
        [DataMember]
        public string Estado { get; set; }
        [DataMember]
        public string Direccion { get; set; }
        [DataMember]
        public string Latitud { get; set; }
        [DataMember]
        public string Longitud { get; set; }
        [DataMember]
        public string Imagen { get; set; }

    }
}