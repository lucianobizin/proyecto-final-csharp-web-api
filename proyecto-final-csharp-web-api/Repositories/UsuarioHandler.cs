using proyecto_final_csharp_web_api.Models;
using System.Data.SqlClient;
using System.Data;

namespace proyecto_final_csharp_web_api.Repositories
{
    public static class UsuarioHandler
    {
        public static Usuario ObtenerUsuario(long id)
        {
            Usuario usuario = new Usuario();
            using (SqlConnection conn = ConnectionHandler.ConnectToDb())
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Usuario WHERE Id=@id", conn);
                SqlParameter idParameter = new SqlParameter();
                idParameter.ParameterName = "id";
                idParameter.SqlDbType = SqlDbType.BigInt;
                idParameter.Value = id;

                command.Parameters.Add(idParameter);

                conn.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        usuario.Id = reader.GetInt64(0);
                        usuario.Nombre = reader.GetString(1);
                        usuario.Apellido = reader.GetString(2);
                        usuario.NombreUsuario = reader.GetString(3);
                        usuario.Contraseña = reader.GetString(4);
                        usuario.Mail = reader.GetString(5);
                    }
                }
                return usuario;
            }
        }

        public static Usuario Login(string usuario, string password)
        {
            Usuario user = new Usuario();
            using (SqlConnection conn = ConnectionHandler.ConnectToDb())
            {

                SqlCommand command = new SqlCommand("SELECT * FROM Usuario WHERE NombreUsuario=@NombreUsuario AND Contraseña=@Contraseña", conn);
                SqlParameter idParameterUsuario = new SqlParameter();
                idParameterUsuario.ParameterName = "NombreUsuario";
                idParameterUsuario.SqlDbType = SqlDbType.VarChar;
                idParameterUsuario.Value = usuario;

                command.Parameters.Add(idParameterUsuario);

                SqlParameter idParameterContraseña = new SqlParameter();
                idParameterContraseña.ParameterName = "Contraseña";
                idParameterContraseña.SqlDbType = SqlDbType.VarChar;
                idParameterContraseña.Value = password;

                command.Parameters.Add(idParameterContraseña);

                conn.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        user.Id = reader.GetInt64(0);
                        user.Nombre = reader.GetString(1);
                        user.Apellido = reader.GetString(2);
                        user.NombreUsuario = reader.GetString(3);
                        user.Contraseña = reader.GetString(4);
                        user.Mail = reader.GetString(5);
                    }

                    return user;
                }
            }

            return null;
        }

        public static int ModificarUsuario(Usuario usuarioModificado)
        {
            using (SqlConnection conn = ConnectionHandler.ConnectToDb())
            {
                SqlCommand command = new SqlCommand("UPDATE Usuario SET Nombre=@nombre,Apellido=@apellido, NombreUsuario=@nombreUsuario, Contraseña=@contraseña, Mail=@mail WHERE Id=@id", conn);

                SqlParameter idParameterNombre = new SqlParameter();
                idParameterNombre.ParameterName = "nombre";
                idParameterNombre.SqlDbType = SqlDbType.VarChar;
                idParameterNombre.Value = usuarioModificado.Nombre;

                SqlParameter idParameterApellido = new SqlParameter();
                idParameterApellido.ParameterName = "apellido";
                idParameterApellido.SqlDbType = SqlDbType.VarChar;
                idParameterApellido.Value = usuarioModificado.Apellido;

                SqlParameter idParameterNombreUsuario = new SqlParameter();
                idParameterNombreUsuario.ParameterName = "nombreUsuario";
                idParameterNombreUsuario.SqlDbType = SqlDbType.VarChar;
                idParameterNombreUsuario.Value = usuarioModificado.NombreUsuario;

                SqlParameter idParameterContraseña = new SqlParameter();
                idParameterContraseña.ParameterName = "contraseña";
                idParameterContraseña.SqlDbType = SqlDbType.VarChar;
                idParameterContraseña.Value = usuarioModificado.Contraseña;

                SqlParameter idParameterMail = new SqlParameter();
                idParameterMail.ParameterName = "mail";
                idParameterMail.SqlDbType = SqlDbType.VarChar;
                idParameterMail.Value = usuarioModificado.Mail;

                SqlParameter idParameterId = new SqlParameter();
                idParameterId.ParameterName = "id";
                idParameterId.SqlDbType = SqlDbType.Int;
                idParameterId.Value = usuarioModificado.Id;

                command.Parameters.Add(idParameterNombre);
                command.Parameters.Add(idParameterApellido);
                command.Parameters.Add(idParameterNombreUsuario);
                command.Parameters.Add(idParameterContraseña);
                command.Parameters.Add(idParameterMail);
                command.Parameters.Add(idParameterId);

                conn.Open();

                return command.ExecuteNonQuery();
            }
        }
    }
}
