using System;
using System.Collections.Generic;
using System.Text;

namespace Bodegas.Logica
{
    internal class Bodega
    {
        public int idBodega { set; get; }
        public string nombreBodega { set; get; }
        public List<Producto> inventario { set; get; } = new List<Producto>();

    }
}
