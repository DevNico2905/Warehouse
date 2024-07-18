using Bodegas.Logica;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bodegas.Logic
{
    internal class Warehouse
    {
        public int warehouseId { set; get; }
        public string warehouseName { set; get; }
        public List<Producto> inventory { set; get; } = new List<Producto>();
    }
}
