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
                        Console.WriteLine("¡See you soon...!");
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
            warehouse.warehouseId = WarehouseId();
            warehouseList.Add(warehouse);

            Console.WriteLine($"\n¡The warehouse '{warehouseName}' has been successfully created!");
            Console.Write("\nPress Enter to return");
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

            while (keyInfo.Key != ConsoleKey.Enter)
            {
                Console.Write("\nPress Enter to return");
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
                Console.WriteLine($"\tWarehouse menu: {SelectedWarehouse.warehouseName}");
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
                        CreateProduct(SelectedWarehouse);
                        break;
                    case 2:
                        // Warehouse Empty
                        Console.WriteLine($"\tWarehouse Inventory: {SelectedWarehouse.warehouseName}\n");
                        Console.WriteLine("  Amount       Name");
                        Console.WriteLine("------------------------");

                        foreach (var producto in SelectedWarehouse.inventory)
                        {
                            if (producto.productStock < 10)
                            {
                                Console.WriteLine($"    0{producto.productStock}         {producto.productName}");
                            }
                            else
                            {
                                Console.WriteLine($"    {producto.productStock}         {producto.productName}");
                            }
                        }
                        Console.Write("\nPress Enter to return...");
                        ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                        while (keyInfo.Key != ConsoleKey.Enter)
                        {
                            Console.Write("\nPress Enter to return...");
                            keyInfo = Console.ReadKey(true);
                        }
                        Console.Clear();
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
        private void CreateProduct(Warehouse SelectedWarehouse)
        {
            Console.WriteLine("\t...creating product...\n");
            //El usuario ingresa el nombre del producto
            Console.Write("Enter the product name: ");
            string ProductName = Console.ReadLine();

            Product selectedProduct = SelectedWarehouse.inventory.FirstOrDefault(x => x.productName.ToLower() == ProductName.ToLower());

            // Vamos a evaluar si el producto ya existe.

            if (selectedProduct != null)
            {
                // Si esto se ejecuta es decir que el producto ya existe.
                // Pedimos al usuario la cantidada de elementos a añadir y los agregamos a cant. existente.
                Console.Write("Enter the amount of the product: ");
                int productAmount;

                while (!int.TryParse(Console.ReadLine(), out productAmount) || (productAmount <= 0))
                {
                    Console.Write("Enter the amount of the product: ");
                }

                selectedProduct.productStock = selectedProduct.productStock + productAmount;

                Console.WriteLine("\nThis product already exists in inventory, so we have updated the stock.");
                Console.Write("\nPress Enter to continue...");
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                while (keyInfo.Key != ConsoleKey.Enter)
                {
                    Console.Write("\nPress Enter to continue...");
                    keyInfo = Console.ReadKey(true);
                }
                Console.Clear();
            }
            else
            {
                //El usuario ingresa la cantidad del producto.
                Console.Write("Enter the amount of the product: ");
                int productAmount;

                while (!int.TryParse(Console.ReadLine(), out productAmount) || (productAmount <= 0))
                {
                    Console.Write("Enter the amount of the product: ");
                }

                //Creamos el producto y asiganamos nombre, cantidad y ID
                Product product = new Product();
                product.productName = ProductName;
                product.productStock = productAmount;
                product.productId = ProductId();

                //Agrega el producto a las listas.
                //ProductList.Add(product);
                SelectedWarehouse.inventory.Add(product);

                Console.WriteLine("\n¡Your product has been created successfully!");
                Console.Write("\nPress Enter to continue...");
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                while (keyInfo.Key != ConsoleKey.Enter)
                {
                    Console.Write("\nPress Enter to continue...");
                    keyInfo = Console.ReadKey(true);
                }
                Console.Clear();
            }
        }
        private int ProductId()
        {
            try
            {
                int id = ProductList.Max(x => x.productId) + 1;
                return id;
            }
            catch (Exception)
            {
                return 1;
            }
        }
        private int WarehouseId()
        {
            try
            {
                int id = warehouseList.Max(x => x.warehouseId) + 1;
                return id;
            }
            catch (Exception)
            {
                return 1;
            }
        }
    }
}
