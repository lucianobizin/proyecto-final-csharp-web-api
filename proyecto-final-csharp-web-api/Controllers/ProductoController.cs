using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using proyecto_final_csharp_web_api.Repositories;

namespace proyecto_final_csharp_web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {

        [HttpGet("{idUsuario}")]

        public List<Models.Producto> TraerProductosPorIdUsuario(long idUsuario)
        {
            return ProductoHandler.ObtenerProductoPorIdUsuario(idUsuario);
        }


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
        public string BorrarProducto(long id)
        {
            return ProductoHandler.EliminarProducto(id) == 1 ? $"El producto {id} ha sido borrado" : "No se pudo borrar el producto";
        }
    }
}
