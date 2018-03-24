using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using municipalidad.Modelo;
using System.ServiceModel.Web;

namespace municipalidad
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IQuejaService" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IQuejaService
    {
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Queja/{correo}/{estado}", ResponseFormat = WebMessageFormat.Json)]
        List<Queja> ListarQueja(string correo, string estado);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Queja/{id}", ResponseFormat = WebMessageFormat.Json)]
        Queja ObtenerQueja(string id);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "Queja", ResponseFormat = WebMessageFormat.Json)]
        int InsertarQueja(Queja queja);

           
    }
}
