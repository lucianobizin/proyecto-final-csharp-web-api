using proyecto_final_csharp_web_api.Models;
using System.Data.SqlClient;
using System.Data;

namespace proyecto_final_csharp_web_api.Repositories
{
    public static class VentaHandler
    {
        public static int IngresarVenta(Venta nuevaVenta)
        {
            using (SqlConnection conn = ConnectionHandler.ConnectToDb())
            {
                SqlCommand command = new SqlCommand("INSERT INTO Venta (Comentarios, IdUsuario) VALUES (@comentarios, @idUsuario)", conn);

                SqlParameter idParameterComentarios = new SqlParameter();
                idParameterComentarios.ParameterName = "comentarios";
                idParameterComentarios.SqlDbType = SqlDbType.VarChar;
                idParameterComentarios.Value = nuevaVenta.Comentarios;

                SqlParameter idParameterIdUsuario = new SqlParameter();
                idParameterIdUsuario.ParameterName = "idUsuario";
                idParameterIdUsuario.SqlDbType = SqlDbType.BigInt;
                idParameterIdUsuario.Value = nuevaVenta.IdUsuario;

                command.Parameters.Add(idParameterComentarios);
                command.Parameters.Add(idParameterIdUsuario);

                conn.Open();

                return command.ExecuteNonQuery();
            }
        }

        public static int RevisarStockProductos(List<Producto> listaProductos)
        {
            //Validación de que haya productos en stock antes de ingresar venta
            foreach (Producto productoAValidar in listaProductos)
            {
                Producto productoDeposito = new Producto();
                productoDeposito = ProductoHandler.ObtenerProductoPorId(productoAValidar.Id);

                if (productoDeposito.Stock < productoAValidar.Stock)
                {
                    return -1;
                }
            }

            return 1;
        }

        public static long DevolverUltimoId(long idUsuario)
        {
            using (SqlConnection conn = ConnectionHandler.ConnectToDb())
            {
                Venta venta = new Venta();
                SqlCommand command = new SqlCommand("SELECT TOP (1) [Id],[Comentarios],[IdUsuario] FROM [SistemaGestion].[dbo].[Venta] WHERE Id=@idUsuario ORDER BY Id DESC", conn);
                SqlParameter idParameter = new SqlParameter();
                idParameter.ParameterName = "idUsuario";
                idParameter.SqlDbType = SqlDbType.BigInt;
                idParameter.Value = idUsuario;

                command.Parameters.Add(idParameter);

                conn.Open();

                SqlDataReader reader = command.ExecuteReader();


                if (reader.HasRows)
                {

                    while (reader.Read())
                    {
                        venta.Id = reader.GetInt64(0);
                        venta.Comentarios = reader.GetString(1);
                        venta.IdUsuario = reader.GetInt64(2);
                    }
                }

                return venta.Id;
            }
        }


        public static int ProcesarVenta(List<Producto> listaProductos, long idUsuario)
        {
            //Validación de que haya productos en stock antes de ingresar venta
            if (RevisarStockProductos(listaProductos) >= 1)
            {
                // Se crear un objeto de clase Venta a fin predeterminar el valor de los atributos comentarios e idUsuario
                Venta nuevaVenta = new Venta();

                nuevaVenta.Comentarios = "";
                nuevaVenta.IdUsuario = idUsuario;

                //List<Producto> nuevaListaProductos = new List<Producto>();
                //nuevaListaProductos = listaProductos;

                if (IngresarVenta(nuevaVenta) >= 1)
                {
                    // Función que devuelva el último Id de Venta (ya que ha sido ingresado arriba)
                    foreach (Producto producto in listaProductos)
                    {
                        ProductoVendido productoVendidoTempo = new ProductoVendido();
                        productoVendidoTempo.Stock = producto.Stock;
                        productoVendidoTempo.IdProducto = producto.Id;
                        productoVendidoTempo.IdVenta = DevolverUltimoId(idUsuario);

                        if (ProductoVendidoHandler.IngresarProductoVendido(productoVendidoTempo) >= 1)
                        {
                            Producto productoTemporal = new Producto();
                            productoTemporal.Id = producto.Id;
                            productoTemporal.Descripciones = producto.Descripciones;
                            productoTemporal.Costo = producto.Costo;
                            productoTemporal.PrecioVenta = producto.PrecioVenta;
                            productoTemporal.Stock = ProductoHandler.ObtenerProductoPorId(producto.Id).Stock - productoVendidoTempo.Stock;
                            productoTemporal.IdUsuario = ProductoHandler.ObtenerProductoPorId(producto.Id).IdUsuario;

                            ProductoHandler.ModificarProducto(productoTemporal);
                        }

                        else
                        {
                            return -1;
                        }
                    }

                    return 1;
                }

                else
                {
                    return -1;
                }
            }

            return 1;
        }
    }
}
