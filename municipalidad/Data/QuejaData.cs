using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using municipalidad.Modelo;


namespace municipalidad.Data
{
    public class QuejaData
    {
        string sqlconx = "Data Source=sql5030.site4now.net;Persist Security Info=True;User ID=DB_A35055_Municipalidad_admin;Password=Municipalidad123";
        SqlConnection cnx;

        public QuejaData() {
            cnx = new SqlConnection(sqlconx);
        }

        public List<Queja> ListarQueja(string correo, string estado) {

            List<Queja> list = new List<Queja>();
            Queja item;

            SqlCommand cmd = cnx.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "tsp_listar_queja";
            cmd.CommandTimeout = 1000;

            cmd.Parameters.AddWithValue("@correo", correo);
            cmd.Parameters.AddWithValue("@estado", estado);
            
            if (cmd.Connection.State != ConnectionState.Open)
                cmd.Connection.Open();

            SqlDataReader rd = cmd.ExecuteReader();

            while (rd.Read()){
                item = new Queja();

                item.Id = rd.IsDBNull(rd.GetOrdinal("id")) ? 0 : rd.GetInt32(rd.GetOrdinal("id"));
                item.Tipo = rd.IsDBNull(rd.GetOrdinal("tipo")) ? "" : rd.GetString(rd.GetOrdinal("tipo"));
                item.Descripcion = rd.IsDBNull(rd.GetOrdinal("descripcion")) ? "" : rd.GetString(rd.GetOrdinal("descripcion"));
                item.Imagen = rd.IsDBNull(rd.GetOrdinal("imagen")) ? "" : rd.GetString(rd.GetOrdinal("imagen"));
                item.Correo = rd.IsDBNull(rd.GetOrdinal("correo")) ? "" : rd.GetString(rd.GetOrdinal("correo"));
                item.Fecha = rd.IsDBNull(rd.GetOrdinal("fecreg")) ? "" : rd.GetString(rd.GetOrdinal("fecreg"));
                item.Direccion = rd.IsDBNull(rd.GetOrdinal("direccion")) ? "" : rd.GetString(rd.GetOrdinal("direccion"));
                item.Latitud = rd.IsDBNull(rd.GetOrdinal("latitud")) ? "" : rd.GetString(rd.GetOrdinal("latitud"));
                item.Longitud = rd.IsDBNull(rd.GetOrdinal("longitud")) ? "" : rd.GetString(rd.GetOrdinal("longitud"));
                item.Estado = rd.IsDBNull(rd.GetOrdinal("estado")) ? "" : rd.GetString(rd.GetOrdinal("estado"));

                list.Add(item);
            }

            if (cmd.Connection.State != ConnectionState.Closed)
                cmd.Connection.Close();

            return list;

        }

        public Queja ObtenerQueja(int id) {
            Queja item = new Queja();

            SqlCommand cmd = cnx.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "tsp_obtener_queja";
            cmd.CommandTimeout = 1000;

            cmd.Parameters.AddWithValue("@id", id);
            
            if (cmd.Connection.State != ConnectionState.Open)
                cmd.Connection.Open();

            SqlDataReader rd = cmd.ExecuteReader();

            if (rd.Read())
            {
                item = new Queja();

                item.Id = rd.IsDBNull(rd.GetOrdinal("id")) ? 0 : rd.GetInt32(rd.GetOrdinal("id"));
                item.Tipo = rd.IsDBNull(rd.GetOrdinal("tipo")) ? "" : rd.GetString(rd.GetOrdinal("tipo"));
                item.Descripcion = rd.IsDBNull(rd.GetOrdinal("descripcion")) ? "" : rd.GetString(rd.GetOrdinal("descripcion"));
                item.Imagen = rd.IsDBNull(rd.GetOrdinal("imagen")) ? "" : rd.GetString(rd.GetOrdinal("imagen"));
                item.Correo = rd.IsDBNull(rd.GetOrdinal("correo")) ? "" : rd.GetString(rd.GetOrdinal("correo"));
                item.Fecha = rd.IsDBNull(rd.GetOrdinal("fecreg")) ? "" : rd.GetString(rd.GetOrdinal("fecreg"));
                item.Estado = rd.IsDBNull(rd.GetOrdinal("estado")) ? "" : rd.GetString(rd.GetOrdinal("estado"));

            }

            if (cmd.Connection.State != ConnectionState.Closed)
                cmd.Connection.Close();

            return item;
        }

        public int InsertarQueja(Queja queja)
        {
            int id = 0;
            SqlCommand cmd = cnx.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "tsp_insertar_queja";
            cmd.CommandTimeout = 1000;

            cmd.Parameters.AddWithValue("@tipo", queja.Tipo);
            cmd.Parameters.AddWithValue("@descripcion", queja.Descripcion);
            cmd.Parameters.AddWithValue("@imagen", queja.Imagen);
            cmd.Parameters.AddWithValue("@correo", queja.Correo);
            cmd.Parameters.AddWithValue("@direccion", queja.Direccion);
            cmd.Parameters.AddWithValue("@latitud", queja.Latitud);
            cmd.Parameters.AddWithValue("@longitud", queja.Longitud);
            cmd.Parameters.AddWithValue("@estado", queja.Estado);

            if (cmd.Connection.State != ConnectionState.Open)
                cmd.Connection.Open();

            SqlDataReader rd = cmd.ExecuteReader();

            if (rd.Read())
                id = rd.IsDBNull(rd.GetOrdinal("id")) ? 0 : rd.GetInt32(rd.GetOrdinal("id"));

            if (cmd.Connection.State != ConnectionState.Closed)
                cmd.Connection.Close();

            return id;
        }

    }
}