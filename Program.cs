using System;
using Bodegas.Logica;
using System.Collections.Generic;

namespace Bodegas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*una compañía de transporte de alimentos carnicos, desea implementar un software que:

            1.Pueda crear bodegas de alimentos
            2.Indicar qué alimentos y cantidad hay en cada bodega.
            3.Poder listar las bodegas, y al seleccionar una, tener la opción de ver el inventario
            (paso 2), o crear un nuevo producto a esa bodega.
            si el nombre del producto ya existe en inventario, lo que debe hacer, es actualizar el
            stock(cantidad) con la nueva cantidad ingresada.*/

            Administrador objAdministrador = new Administrador();
            objAdministrador.Orquestador();

        }
    }
}
