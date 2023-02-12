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

        public static Usuario ObtenerUsuarioPorNombreUsuario(string nombreUsuario)
        {
            Usuario usuario = new Usuario();
            using (SqlConnection conn = ConnectionHandler.ConnectToDb())
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Usuario WHERE NombreUsuario=@nombreUsuario", conn);
                SqlParameter idParameter = new SqlParameter();
                idParameter.ParameterName = "nombreUsuario";
                idParameter.SqlDbType = SqlDbType.VarChar;
                idParameter.Value = nombreUsuario;

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
                SqlCommand command = new SqlCommand("UPDATE Usuario SET Nombre=@nombre, Apellido=@apellido, NombreUsuario=@nombreUsuario, Contraseña=@contraseña, Mail=@mail WHERE Id=@id", conn);

                SqlParameter idParameterId = new SqlParameter();
                idParameterId.ParameterName = "id";
                idParameterId.SqlDbType = SqlDbType.BigInt;
                idParameterId.Value = usuarioModificado.Id;

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

                command.Parameters.Add(idParameterId);
                command.Parameters.Add(idParameterNombre);
                command.Parameters.Add(idParameterApellido);
                command.Parameters.Add(idParameterNombreUsuario);
                command.Parameters.Add(idParameterContraseña);
                command.Parameters.Add(idParameterMail);


                conn.Open();

                return command.ExecuteNonQuery();
            }
        }

        public static int CrearUsuario(Usuario usuarioCreado)
        {
            using (SqlConnection conn = ConnectionHandler.ConnectToDb())
            {
                SqlCommand command = new SqlCommand("INSERT INTO Usuario (Nombre, Apellido, NombreUsuario, Contraseña, Mail) VALUES (@nombre, @apellido, @nombreUsuario, @contraseña, @mail)", conn);

                SqlParameter idParameterNombre = new SqlParameter();
                idParameterNombre.ParameterName = "nombre";
                idParameterNombre.SqlDbType = SqlDbType.VarChar;
                idParameterNombre.Value = usuarioCreado.Nombre;

                SqlParameter idParameterApellido = new SqlParameter();
                idParameterApellido.ParameterName = "apellido";
                idParameterApellido.SqlDbType = SqlDbType.VarChar;
                idParameterApellido.Value = usuarioCreado.Apellido;

                SqlParameter idParameterNombreUsuario = new SqlParameter();
                idParameterNombreUsuario.ParameterName = "nombreUsuario";
                idParameterNombreUsuario.SqlDbType = SqlDbType.VarChar;
                idParameterNombreUsuario.Value = usuarioCreado.NombreUsuario;

                SqlParameter idParameterContraseña = new SqlParameter();
                idParameterContraseña.ParameterName = "contraseña";
                idParameterContraseña.SqlDbType = SqlDbType.VarChar;
                idParameterContraseña.Value = usuarioCreado.Contraseña;

                SqlParameter idParameterMail = new SqlParameter();
                idParameterMail.ParameterName = "mail";
                idParameterMail.SqlDbType = SqlDbType.VarChar;
                idParameterMail.Value = usuarioCreado.Mail;

                command.Parameters.Add(idParameterNombre);
                command.Parameters.Add(idParameterApellido);
                command.Parameters.Add(idParameterNombreUsuario);
                command.Parameters.Add(idParameterContraseña);
                command.Parameters.Add(idParameterMail);

                conn.Open();

                return command.ExecuteNonQuery();
            }
        }

        // El método de abajo solo sirve directamente para los usuarios creados nuevos (en UsuarioController se explica porqué se decidió no ejecutarlo)
        public static int BorrarUsuario (long id)
        {
            using (SqlConnection conn = ConnectionHandler.ConnectToDb())
            {
                SqlCommand command = new SqlCommand("DELETE FROM Usuario WHERe Id=@id", conn);

                SqlParameter idParameterId = new SqlParameter();
                idParameterId.ParameterName = "id";
                idParameterId.SqlDbType = SqlDbType.BigInt;
                idParameterId.Value = id;

                command.Parameters.Add(idParameterId);

                conn.Open();

                return command.ExecuteNonQuery();
            }
        }
    }
}
