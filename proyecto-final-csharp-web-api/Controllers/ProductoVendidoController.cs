using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using proyecto_final_csharp_web_api.Repositories;

namespace proyecto_final_csharp_web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoVendidoController : ControllerBase
    {
        [HttpGet ("{idUsuario}")]

        public List<Models.Producto> TraerProductosPorIdUsuario (long idUsuario)
        {
            return ProductoVendidoHandler.ObtenerProductosVendidosPorUsuario (idUsuario);
        }
    }
}
