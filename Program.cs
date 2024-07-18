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
            while (true)
            {

                Console.WriteLine("\t¡Warehouse management / Gestión de bodegas!\n");

                Console.WriteLine("Interface language:");
                Console.WriteLine(" 1.English.");
                Console.WriteLine(" 2.Spanish.");
                Console.Write("\nSelect your language (1 or 2): ");
                int Language = Convert.ToInt32(Console.ReadLine());

                // make correction of user input validation

                switch (Language)
                {
                    case 1:
                        Console.WriteLine("Answer was 1.");
                        return;
                    case 2:
                        Console.WriteLine("Answer was 2.");
                        return;
                    default:
                        Console.Write("\n¡Error!");
                        Console.Write("\nPress Enter to restart / Presione Enter para reiniciar");
                        ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                        while (keyInfo.Key != ConsoleKey.Enter)
                        {
                            Console.Write("\nPress Enter to restart / Presione Enter para reiniciar");
                            keyInfo = Console.ReadKey(true);
                        }
                        Console.Clear();
                        break;
                }
            }
            

            /*Administrador objAdministrador = new Administrador();
            objAdministrador.Orquestador();*/



        }
    }
}
