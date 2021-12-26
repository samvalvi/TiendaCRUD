using Microsoft.EntityFrameworkCore;
using System.Linq;
using Tienda;

namespace TiendaSystem
{
    public class TiendaProducto
    {
        static void Main(string[] args)
        {


            DbContextOptionsBuilder<TiendaContext> optionsBuilder = new DbContextOptionsBuilder<TiendaContext>();
            optionsBuilder.UseSqlServer("Server=DESKTOP-8AC42VI\\SQLEXPRESS; Database=Tienda; Trusted_Connection=True;");

            bool again = true;
            int op = 0;

            do
            {
                Console.WriteLine("Seleccione una opción:");
                Console.WriteLine("1- Mostrar productos \n2-Insertar producto \n3-Editar producto \n4-Eliminar producto \n5-Salir");
                op = int.Parse(Console.ReadLine());

                switch (op)
                {
                    case 1:
                        Show(optionsBuilder);
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Debe seleccionar una opción válida.");
                        break;
                }

            } while (again);
        }

        public static void Show(DbContextOptionsBuilder<TiendaContext>optionsBuilder)
        {
            Console.Clear();
            Console.WriteLine("Stock de productos");
            using (var context = new TiendaContext(optionsBuilder.Options))
            {
                List<Producto> productos = context.Productos.ToList();
                foreach (Producto producto in productos)
                {
                    Console.WriteLine($"Id: {producto.ProductoId} \nNombre: {producto.Nombre} " +
                        $"\nMarca: {producto.Marca} \nPrecio: {producto.PrecioPublico}" + Environment.NewLine);
                }
            }
        }
    }
}