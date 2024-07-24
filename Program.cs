using System;
using Bodegas.Logica;
using System.Collections.Generic;
using Bodegas.Logic;

namespace Bodegas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*A transportation company wants to implement software that:
            1. Can create warehouses.
            2. Indicate the quantity in each warehouse.
            3. Be able to list the warehouses, and when selecting one, have the option to view the inventory (step 2),
            or create a new product for that warehouse.
            If the product name already exists in inventory, what you need to do is update the stock (quantity)
            with the new quantity entered.*/

            while (true)
            {

                Console.WriteLine("\t¡Warehouse management / Gestión de bodegas!\n");

                Console.WriteLine("Interface language:\n");
                Console.WriteLine(" 1.English.");
                Console.WriteLine(" 2.Spanish.");
                Console.Write("\nSelect your language (1 or 2): ");
                int Language;

                while (!int.TryParse(Console.ReadLine(), out Language) || (Language != 1 && Language != 2))
                {
                    Console.Write("Select your language (1 or 2): ");
                }

                switch (Language)
                {
                    case 1:
                        Console.Clear();
                        Manager manager = new Manager();
                        manager.Orchestrator();
                        return;
                    case 2:
                        Console.Clear();
                        Administrador objAdministrador = new Administrador();
                        objAdministrador.Orquestador();
                        return;
                    default:
                        break;
                }
            }
        }
    }
}