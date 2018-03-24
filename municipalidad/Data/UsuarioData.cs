using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using municipalidad.Modelo;


namespace municipalidad.Data
{
    public class UsuarioData
    {
        string sqlconx = "Data Source=sql5030.site4now.net;Persist Security Info=True;User ID=DB_A35055_Municipalidad_admin;Password=Municipalidad123";
        SqlConnection cnx;

        public UsuarioData()
        {
            cnx = new SqlConnection(sqlconx);
        }



        public Usuario ObtenerUsuario(string correo)
        {
            Usuario item = new Usuario();

            SqlCommand cmd = cnx.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "tsp_obtener_usuario";
            cmd.CommandTimeout = 1000;

            cmd.Parameters.AddWithValue("@correo", correo);

            if (cmd.Connection.State != ConnectionState.Open)
                cmd.Connection.Open();

            SqlDataReader rd = cmd.ExecuteReader();

            if (rd.Read())
            {
                item = new Usuario();

                item.Id = rd.IsDBNull(rd.GetOrdinal("Id")) ? 0 : rd.GetInt32(rd.GetOrdinal("Id"));
                item.Nombre = rd.IsDBNull(rd.GetOrdinal("Nombre")) ? "" : rd.GetString(rd.GetOrdinal("Nombre"));
                item.ApePat = rd.IsDBNull(rd.GetOrdinal("ApePat")) ? "" : rd.GetString(rd.GetOrdinal("ApePat"));
                item.ApeMat = rd.IsDBNull(rd.GetOrdinal("ApeMat")) ? "" : rd.GetString(rd.GetOrdinal("ApeMat"));
                item.Dni = rd.IsDBNull(rd.GetOrdinal("dni")) ? "" : rd.GetString(rd.GetOrdinal("dni"));
                item.Direccion = rd.IsDBNull(rd.GetOrdinal("direccion")) ? "" : rd.GetString(rd.GetOrdinal("direccion"));
                item.Latitud = rd.IsDBNull(rd.GetOrdinal("latitud")) ? "" : rd.GetString(rd.GetOrdinal("latitud"));
                item.Longitud = rd.IsDBNull(rd.GetOrdinal("longitud")) ? "" : rd.GetString(rd.GetOrdinal("longitud"));
                item.FecNac = rd.IsDBNull(rd.GetOrdinal("fecNac")) ? "" : rd.GetString(rd.GetOrdinal("fecNac"));
                item.Sexo = rd.IsDBNull(rd.GetOrdinal("sexo")) ? "" : rd.GetString(rd.GetOrdinal("sexo"));
                item.Correo = rd.IsDBNull(rd.GetOrdinal("correo")) ? "" : rd.GetString(rd.GetOrdinal("correo"));
                item.Imagen = rd.IsDBNull(rd.GetOrdinal("imagen")) ? "" : rd.GetString(rd.GetOrdinal("imagen"));

            }

            if (cmd.Connection.State != ConnectionState.Closed)
                cmd.Connection.Close();

            return item;
        }

        public int InsertarUsuario(Usuario usu)
        {
            int id = 0;
            SqlCommand cmd = cnx.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "tsp_insertar_usuario";
            cmd.CommandTimeout = 1000;

            cmd.Parameters.AddWithValue("@Nombre", usu.Nombre);
            cmd.Parameters.AddWithValue("@ApePat", usu.ApePat);
            cmd.Parameters.AddWithValue("@ApeMat", usu.ApeMat);
            cmd.Parameters.AddWithValue("@dni", usu.Dni);
            cmd.Parameters.AddWithValue("@direccion", usu.Direccion);
            cmd.Parameters.AddWithValue("@latitud", usu.Latitud);
            cmd.Parameters.AddWithValue("@longitud", usu.Longitud);
            cmd.Parameters.AddWithValue("@fecNac", usu.FecNac);
            cmd.Parameters.AddWithValue("@sexo", usu.Sexo);
            cmd.Parameters.AddWithValue("@correo", usu.Correo);
            cmd.Parameters.AddWithValue("@imagen", usu.Imagen);

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