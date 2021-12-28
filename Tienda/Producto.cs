using System;
using System.Collections.Generic;

namespace Tienda
{
    public partial class Producto
    {
        public int ProductoId { get; set; }
        public string Nombre { get; set; }
        public decimal PrecioEspecial { get; set; }
        public decimal PrecioPublico { get; set; }
        public string Marca { get; set; }
        public int Stock { get; set; }

        public Producto(string nombre, decimal precioEspecial, decimal precioPublico, string marca, int stock)
        {
            Nombre = nombre;
            PrecioEspecial = precioEspecial;
            PrecioPublico = precioPublico;
            Marca = marca;
            Stock = stock;
        }

        public Producto(int productoId, string nombre, decimal precioEspecial, decimal precioPublico, string marca, int stock)
        {
            ProductoId = productoId;
            Nombre = nombre;
            PrecioEspecial = precioEspecial;
            PrecioPublico = precioPublico;
            Marca = marca;
            Stock = stock;
        }
    }
}
