using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using proyecto_final_csharp_web_api.Repositories;

namespace proyecto_final_csharp_web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        [HttpPost]
        public void CrearProducto(Models.Producto producto)
        {
            ProductoHandler.InsertarProducto(producto);
        }

        [HttpPut]
        public void ModificarProducto(Models.Producto producto)
        {
            ProductoHandler.ModificarProducto(producto);
        }

        [HttpDelete("{id}")]
        public void BorrarProducto(long id)
        {
            ProductoHandler.EliminarProducto(id);
        }
    }
}
