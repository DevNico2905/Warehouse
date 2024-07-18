using Bodegas.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bodegas.Logic
{
    internal class Manager
    {
        List<Product> ProductList = new List<Product>();
        List<Warehouse> warehouseList = new List<Warehouse>();

        public void Orchestrator()
        {
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("\tMenu");
                Console.WriteLine("\n1. Create a warehouse.");
                Console.WriteLine("2. Enter a warehouse.");
                Console.WriteLine("3. Exit the program.");
                Console.Write("\nSelect an option: ");

                int UserInput;

                while (!int.TryParse(Console.ReadLine(), out UserInput) || (UserInput != 1 && UserInput != 2 && UserInput != 3))
                {
                    Console.Write("Select an option: ");
                }

                Console.Clear();

                switch (UserInput)
                {
                    case 1:
                        CreateWarehouse();
                        break;
                    case 2:
                        EnterWarehouse();
                        break;
                    case 3:
                        Console.WriteLine("¡Hasta Luego!");
                        flag = false;
                        break;
                    default:
                        break;
                }
            }
        }
        private void CreateWarehouse()
        {
            Console.WriteLine("\tCreate your warehouse");

            //Assign a name to the warehouse
            Console.Write("\n- Enter the name of the warehouse: ");
            string warehouseName = Console.ReadLine();

            //Create the warehouse of the warehouse class
            Warehouse warehouse = new Warehouse();

            //Assigns the name and Id to the object.
            warehouse.warehouseName = warehouseName;
            warehouse.warehouseId = 0/*idBodega()*/;
            warehouseList.Add(warehouse);

            Console.WriteLine($"\n¡The warehouse '{warehouseName}' has been successfully created!");
            Console.Write("\nPress Enter to restart");
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

            while (keyInfo.Key != ConsoleKey.Enter)
            {
                Console.Write("\nPress Enter to restart");
                keyInfo = Console.ReadKey(true);
            }
            Console.Clear();
        }
        private void EnterWarehouse()
        {
            bool bandera = true;
            while (bandera)
            {
                Console.WriteLine("\tExisting warehouses\n");

                Console.WriteLine(" Id --- Warehouse's name");

                foreach (var warehouse in warehouseList)
                {
                    Console.WriteLine($" {warehouse.warehouseId}  --- {warehouse.warehouseName}");
                }

                Console.Write("\nWrite the Id of the warehouse you want to enter: ");
                int idBodega;
                while (!int.TryParse(Console.ReadLine(), out idBodega))
                {
                    Console.Write("Write the Id of the warehouse you want to enter: ");
                }
                Console.Clear();

                Warehouse SelectedWarehouse = warehouseList.FirstOrDefault(x => x.warehouseId == idBodega);

                if (SelectedWarehouse != null)
                {
                    bandera = false;
                    // Creo Productos y/o muestro inventario
                    ManageWarehouses(SelectedWarehouse);
                }
                else
                {
                    Console.WriteLine("¡The Id entered is not valid!");
                    Console.Write("\nPress Enter to restart");
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                    while (keyInfo.Key != ConsoleKey.Enter)
                    {
                        Console.Write("\nPress Enter to restart");
                        keyInfo = Console.ReadKey(true);
                    }
                    Console.Clear();
                }
            }
        }
        private void ManageWarehouses(Warehouse SelectedWarehouse)
        {
            //Bodega bodegaSelec = listaBodegas.FirstOrDefault(x => x.idBodega == idBodega);

            bool flag = true;

            while (flag)
            {
                Console.WriteLine($"Warehouse menu: {SelectedWarehouse.warehouseName}");
                Console.WriteLine("\n1. Create a product.");
                Console.WriteLine("2. Show inventory.");
                Console.WriteLine("3. Back to Main Menu.");
                Console.Write("\nSelect an option: ");
                int selectMenu;

                while (!int.TryParse(Console.ReadLine(), out selectMenu) || (selectMenu != 1 && selectMenu != 2 && selectMenu != 3))
                {
                    Console.Write("Select an option: ");
                }

                Console.Clear();

                switch (selectMenu)
                {
                    case 1:
                        /*CrearProducto(SelectedWarehouse);*/
                        break;
                    case 2:
                        Console.WriteLine($"\tInventario Bodega: {SelectedWarehouse.warehouseName}\n");
                        Console.WriteLine("Cantidad     Nombre");
                        Console.WriteLine("------------------------");
                        foreach (var producto in SelectedWarehouse.inventory)
                        {
                            Console.WriteLine($"   {producto.cantidadProducto}          {producto.nombreProducto}");
                        }
                        Console.Write("\nPresione Enter para continuar...");
                        Console.ReadLine();
                        break;
                    case 3:
                        flag = false;
                        break;
                    default:
                        break;
                }
                Console.Clear();
            }
        }
    }
}
