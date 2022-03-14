using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using capaEntidad;

namespace CapaDatos
{
    public class D_agenda
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString);

        SqlCommand comando;


        public List<E_agenda> buscarContacto(string buscar)
        {

            SqlDataReader leerFilas;
            comando = new SqlCommand("SP_buscarRegistro", con);
            comando.CommandType = CommandType.StoredProcedure;
            con.Open();

            comando.Parameters.AddWithValue("@buscar", buscar);
            leerFilas = comando.ExecuteReader();

            List<E_agenda> listar = new List<E_agenda>();
            while (leerFilas.Read())
            {
                listar.Add(new E_agenda
                {
                    Id = leerFilas.GetInt32(0),
                    Nombre = leerFilas.GetString(1),
                    Apellido = leerFilas.GetString(2),
                    Correo = leerFilas.GetString(3),
                    Telefono = leerFilas.GetInt32(4),
                    FechaDeNacimiento = leerFilas.GetString(5),
                    Dirección = leerFilas.GetString(6)

                });
            }
            con.Close();
            leerFilas.Close();
            return listar;

        }


        public void agregarContacto(E_agenda Contacto)
        {
            comando = new SqlCommand("SP_agregarRegistro", con);
            comando.CommandType = CommandType.StoredProcedure;
            con.Open();

            comando.Parameters.AddWithValue("@nombre", Contacto.Nombre);
            comando.Parameters.AddWithValue("@apellido", Contacto.Apellido);
            comando.Parameters.AddWithValue("@correo", Contacto.Correo);
            comando.Parameters.AddWithValue("@telefono", Contacto.Telefono);
            comando.Parameters.AddWithValue("@fechaNacimiento", Contacto.FechaDeNacimiento);
            comando.Parameters.AddWithValue("@direccion", Contacto.Dirección);

            comando.ExecuteNonQuery();
            con.Close();
        }


        public void editarContacto(E_agenda Contacto)
        {
            comando = new SqlCommand("SP_editarRegistro", con);
            comando.CommandType = CommandType.StoredProcedure;
            con.Open();

            comando.Parameters.AddWithValue("@id", Contacto.Id);
            comando.Parameters.AddWithValue("@nombre", Contacto.Nombre);
            comando.Parameters.AddWithValue("@apellido", Contacto.Apellido);
            comando.Parameters.AddWithValue("@correo", Contacto.Correo);
            comando.Parameters.AddWithValue("@telefono", Contacto.Telefono);
            comando.Parameters.AddWithValue("@fechaNacimiento", Contacto.FechaDeNacimiento);
            comando.Parameters.AddWithValue("@direccion", Contacto.Dirección);

            comando.ExecuteNonQuery();
            con.Close();
        }

        public void eliminarContacto(E_agenda Contacto)
        {
            comando = new SqlCommand("SP_eliminarRegistro", con);
            comando.CommandType = CommandType.StoredProcedure;
            con.Open();

            comando.Parameters.AddWithValue("@id", Contacto.Id);
            comando.ExecuteNonQuery();
            con.Close();
        }

    }
}
