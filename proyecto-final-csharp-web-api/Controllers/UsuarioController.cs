using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using proyecto_final_csharp_web_api.Repositories;

namespace proyecto_final_csharp_web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        [HttpPut]
        public void ModificarUsuario (Models.Usuario usuario)
        {
            UsuarioHandler.ModificarUsuario(usuario);
        }
    }
}
