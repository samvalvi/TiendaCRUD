using Tienda;
using System.Linq;

namespace EntitySystem
{
    public class SystemDB
    {
        static void Main(string[] args)
        {
            TiendaContext tiendaDbContext = new TiendaContext();

            var productos = tiendaDbContext.Productos.ToList();

            foreach(Producto producto in productos)
            {
                Console.WriteLine($"Id: {producto.ProductoId}");
                Console.WriteLine($"Marca: {producto.Marca}");
                Console.WriteLine($"Nombre: {producto.Nombre}");
            }
        }
    }

}