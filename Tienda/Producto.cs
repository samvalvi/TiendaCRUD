using System;
using System.Collections.Generic;

namespace Tienda
{
    public partial class Producto
    {
        public int ProductoId { get; set; }
        public string Nombre { get; set; } = null!;
        public decimal PrecioEspecial { get; set; }
        public decimal PrecioPublico { get; set; }
        public string Marca { get; set; } = null!;
        public int Stock { get; set; }
    }
}
