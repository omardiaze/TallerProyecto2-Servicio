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
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "QuejaService" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione QuejaService.svc o QuejaService.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class QuejaService : IQuejaService
    {
        public int InsertarQueja(Queja queja)
        {
            QuejaData data = new QuejaData();
            return data.InsertarQueja(queja);
        }

        public List<Queja> ListarQueja(string correo, string estado)
        {
            QuejaData data = new QuejaData();
            return data.ListarQueja( correo, estado);
        }

        public Queja ObtenerQueja(string id)
        {
            QuejaData data = new QuejaData();
            return data.ObtenerQueja(Int32.Parse(id));
        }
    }
}
