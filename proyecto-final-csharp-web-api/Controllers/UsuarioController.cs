using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using proyecto_final_csharp_web_api.Repositories;

namespace proyecto_final_csharp_web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        [HttpGet ("{usuario}/{contrasena}")]
        public Models.Usuario InicioSesion (string usuario, string contrasena)
        {
            return UsuarioHandler.Login(usuario, contrasena);
        }

        [HttpGet ("{usuario}")]
        public Models.Usuario TraerUsuario(string usuario)
        {
            return UsuarioHandler.ObtenerUsuarioPorNombreUsuario(usuario);
        }

        [HttpPost]
        public string IngresarUsuario(Models.Usuario usuario)
        {
            return UsuarioHandler.CrearUsuario(usuario) == 1 ? "Usuario creado con éxito" : "No se pudo crear el usuario";
        }

        [HttpPut]
        public string ModificarUsuario (Models.Usuario usuario)
        {
            return UsuarioHandler.ModificarUsuario(usuario) == 1 ? $"Usuario {usuario.NombreUsuario} modificado" : "No se pudo modificar el usuario";
        }

        // No se realiza el delete usuario porque está atado a la tabla Productos, y eso implica borrar productos que podrían haber sido vendidos por otro usuario (la concatenación entre las tablas no es la más adecuada para la representación de un caso real)
        
        //[HttpDelete ("{id}")]
        //public string EliminarUsuario(long id)
        //{
        //    return UsuarioHandler.BorrarUsuario(id) == 1 ? $"Usuario {id} ha sido borrado con éxito " : $"No se pudo borrar el usuario {id}";
        //}
    }
}
