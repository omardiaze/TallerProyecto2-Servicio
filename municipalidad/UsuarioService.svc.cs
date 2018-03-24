using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using municipalidad.Modelo;
using municipalidad.Data;

namespace municipalidad
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "UsuarioService" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione UsuarioService.svc o UsuarioService.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class UsuarioService : IUsuarioService
    {
        public int InsertarUsuario(Usuario usu)
        {
            UsuarioData data = new UsuarioData();
            return data.InsertarUsuario(usu);
        }

        public Usuario ObtenerUsuario(string correo)
        {
            UsuarioData data = new UsuarioData();
            return data.ObtenerUsuario(correo);
        }
    }
}
