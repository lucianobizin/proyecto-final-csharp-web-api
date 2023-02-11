namespace proyecto_final_csharp_web_api.Models
{
    public class Producto
    {
        public long Id { get; set; }
        public string Descripciones { get; set; } = string.Empty;
        public decimal Costo { get; set; }
        public decimal PrecioVenta { get; set; }
        public int Stock { get; set; }
        public long IdUsuario { get; set; }

    }
}
