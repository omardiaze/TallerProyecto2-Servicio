using municipalidad.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace municipalidad
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IUsuarioService" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IUsuarioService
    {
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Usuario/{correo}", ResponseFormat = WebMessageFormat.Json)]
        Usuario ObtenerUsuario(string correo);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "Usuario", ResponseFormat = WebMessageFormat.Json)]
        int InsertarUsuario(Usuario usu);


    }
}
