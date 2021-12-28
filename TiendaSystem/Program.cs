﻿using Microsoft.EntityFrameworkCore;
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
                    case 2:
                        Add(optionsBuilder);
                        break;
                    case 3:
                        Update(optionsBuilder);
                        break;
                    case 4:
                        Delete(optionsBuilder);
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

        public static void Add(DbContextOptionsBuilder<TiendaContext>optionsBuilder)
        {
            Console.Clear();
            Console.WriteLine("Agregar producto");
            Console.Write("Nombre: ");
#pragma warning disable CS8600 // Se va a convertir un literal nulo o un posible valor nulo en un tipo que no acepta valores NULL
            string name = Console.ReadLine();
#pragma warning restore CS8600 // Se va a convertir un literal nulo o un posible valor nulo en un tipo que no acepta valores NULL
            Console.Write("Precio especial: ");
            decimal specialPrice = decimal.Parse(Console.ReadLine());
            Console.Write("Precio público: ");
            decimal publicPrice = decimal.Parse(Console.ReadLine());
            Console.Write("Marca: ");
#pragma warning disable CS8600 // Se va a convertir un literal nulo o un posible valor nulo en un tipo que no acepta valores NULL
            string brand = Console.ReadLine();
#pragma warning restore CS8600 // Se va a convertir un literal nulo o un posible valor nulo en un tipo que no acepta valores NULL
            Console.Write("Stock: ");
            int stock = int.Parse(Console.ReadLine());

            using var db = new TiendaContext(optionsBuilder.Options);
            Producto producto = new Producto(name, specialPrice, publicPrice, brand, stock);
            db.Add(producto);
            db.SaveChanges();
            Console.WriteLine();
        }

        public static void Update(DbContextOptionsBuilder<TiendaContext>optionsBuilder)
        {
            Console.Clear();
            Show(optionsBuilder);
            Console.WriteLine("Actualizar producto");
            Console.Write("Producto id: ");
            int productoId = int.Parse(Console.ReadLine());
            Console.Write("Nombre: ");
            string name = Console.ReadLine();
            Console.Write("Precio especial: ");
            decimal specialPrice = decimal.Parse(Console.ReadLine());
            Console.Write("Precio público: ");
            decimal publicPrice = decimal.Parse(Console.ReadLine());
            Console.Write("Marca: ");
            string brand = Console.ReadLine();
            Console.Write("Stock: ");
            int stock = int.Parse(Console.ReadLine());

            using var db = new TiendaContext(optionsBuilder.Options);
            Producto producto = new Producto(productoId, name, publicPrice, specialPrice, brand, stock);
            db.Productos.Update(producto);
            db.SaveChanges();
            Console.WriteLine();
        }

        public static void Delete(DbContextOptionsBuilder<TiendaContext> optionsBuilder)
        {
            Console.Clear();
            Show(optionsBuilder);
            Console.WriteLine("Eliminar producto");
            Console.Write("Ingrese el id del producto: ");
            int productoId = int.Parse(Console.ReadLine());

            using var db = new TiendaContext(optionsBuilder.Options);
#pragma warning disable CS8600 // Se va a convertir un literal nulo o un posible valor nulo en un tipo que no acepta valores NULL
            Producto productToDelete = db.Productos.Find(productoId);
#pragma warning restore CS8600 // Se va a convertir un literal nulo o un posible valor nulo en un tipo que no acepta valores NULL
            if (productToDelete != null)
            {
                db.Productos.Remove(productToDelete);
                db.SaveChanges();
                Console.WriteLine(Environment.NewLine);
            }
            else
            {
                Console.WriteLine();
            }
        }
    }
}