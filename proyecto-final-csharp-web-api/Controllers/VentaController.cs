using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using proyecto_final_csharp_web_api.Repositories;

namespace proyecto_final_csharp_web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        [HttpPost ("{idUsuario}")]
        public void CargarVenta(List<Models.Producto> listaProductoVendidos, long idUsuario)
        {
            VentaHandler.ProcesarVenta(listaProductoVendidos, idUsuario);
        }
    }
}
