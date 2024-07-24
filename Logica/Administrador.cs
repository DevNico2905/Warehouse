using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/* Falta corregir cuando el ID de las bodegas no es válido. Hacer la validación dentro del método "ConsultarBodega()"
Y luego seguir con la validacion cuando se van agregar más cantidades de un mismo producto */

namespace Bodegas.Logica
{
    internal class Administrador
    {
        List<Producto> ListaProductos = new List<Producto>();
        List<Bodega> listaBodegas = new List<Bodega>();

        public void Orquestador()
        {
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("\tMenú");
                Console.WriteLine("\n1. Crear Bodega.");
                Console.WriteLine("2. Ingresar a Bodega.");
                Console.WriteLine("3. Salir del programa.");
                Console.Write("\nSeleccione una opción: ");

                int UserInput = Convert.ToInt32(Console.ReadLine());
                Console.Clear();

                switch (UserInput)
                {
                    case 1:
                        CrearBodega();
                        break;
                    case 2:
                        ConsultarBodega();
                        break;
                    case 3:
                        Console.WriteLine("¡Hasta Luego!");
                        flag = false;
                        break;
                    default:
                        Console.WriteLine("¡Opción no válida!");
                        Console.Write("\nPresione Enter para continuar...");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                }
            }
        }

        private void CrearBodega()
        {
            Console.WriteLine("\tCrea tu bodega");
            //Asigna nombre a la bodega
            Console.Write("\n- Ingrese el nombre de la bodega: ");
            string nombreBodega = Console.ReadLine();

            //Crea la bodega de la clase Bodega
            Bodega bodega = new Bodega();

            //Asigna el nombre y el Id al objeto.
            bodega.nombreBodega = nombreBodega;
            bodega.idBodega = idBodega();
            listaBodegas.Add(bodega);

            Console.Write($"\n¡La Bodega '{nombreBodega}' ha sido creada exitosamente!");
            Console.ReadLine();
            Console.Clear();
 

        }

        private void ConsultarBodega()
        {
            bool bandera = true;
            while (bandera)
            {
                Console.WriteLine("\tBodegas existentes\n");

                Console.WriteLine(" ID --- Nombre de la bodega");

                foreach (var bodega in listaBodegas)
                {
                    Console.WriteLine($" {bodega.idBodega}  --- {bodega.nombreBodega}");
                }

                Console.Write("\nEscriba el ID de la bodega a la quiere ingresar: ");
                int idBodega = Convert.ToInt32( Console.ReadLine());
                Console.Clear();

                Bodega bodegaSelec = listaBodegas.FirstOrDefault(x => x.idBodega == idBodega);

                if (bodegaSelec != null)
                {
                    bandera = false;
                    // Creo Productos y/o muestro inventario
                    AdministrarBodegas(bodegaSelec);
                }
                else
                {
                    Console.WriteLine("¡El ID ingresado no es válido!");
                    Console.Write("\nPresione Enter para continuar...");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
        }

        private void AdministrarBodegas(Bodega bodegaSelec)
        {
            //Bodega bodegaSelec = listaBodegas.FirstOrDefault(x => x.idBodega == idBodega);
 
            bool flag = true;
            
            while (flag)
            {
                Console.WriteLine($"Menú bodega: {bodegaSelec.nombreBodega}");
                Console.WriteLine("\n1. Crear producto.");
                Console.WriteLine("2. Mostrar inventario.");
                Console.WriteLine("3. Volver al menú principal.");
                Console.Write("\nSeleccione una opción: ");
                int seleccioneMenu = Convert.ToInt32(Console.ReadLine());
                Console.Clear();

                switch (seleccioneMenu)
                {
                    case 1:
                        CrearProducto(bodegaSelec);
                        break;
                    case 2:
                        Console.WriteLine($"\tInventario Bodega: {bodegaSelec.nombreBodega}\n");
                        Console.WriteLine("Cantidad     Nombre");
                        Console.WriteLine("------------------------");
                        foreach (var producto in bodegaSelec.inventario)
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
                        Console.WriteLine("¡Opción no válida!");
                        break;
                }
                    Console.Clear();
            }
        }

        private void CrearProducto(Bodega bodega)
        {
            //El usuario ingresa el nombre del producto
            Console.Write("Ingrese el nombre del producto: ");
            string nombreProducto = Console.ReadLine();

            Producto productoSelec = bodega.inventario.FirstOrDefault(x => x.nombreProducto.ToLower() == nombreProducto.ToLower());

            // Vamos a evaluar si el producto ya existe.

            if (productoSelec != null)
            {
                // Si esto se ejecuta es decir que el producto ya existe.
                // Pedimos al usuario la cantidada de elementos a añadir y los agregamos a cant. existente.
                Console.Write("Ingrese la cantidad del producto: ");
                int cantidadProducto = Convert.ToInt32(Console.ReadLine());
                productoSelec.cantidadProducto = productoSelec.cantidadProducto + cantidadProducto;

                Console.WriteLine("\nEste producto ya existe en el inventario, así que hemos actualizado el stock.");
                Console.Write("Presione Enter para continuar...");
                Console.ReadLine();
            }
            else
            {
                //El usuario ingresa la cantidad del producto.
                Console.Write("Ingrese la cantidad del producto: ");
                int cantidadProducto = Convert.ToInt32(Console.ReadLine());

                //Creamos el producto y asiganamos nombre, cantidad y ID
                Producto producto = new Producto();
                producto.nombreProducto = nombreProducto;
                producto.cantidadProducto = cantidadProducto;
                producto.idProducto = idProducto();

                //Agrega el producto a las listas.
                //ListaProductos.Add(producto);
                bodega.inventario.Add(producto);

                Console.Write("\n¡Su producto se ha creado con exito!");
                Console.ReadLine();
                Console.Clear();
            }
        }

        private int idProducto()
        {
            try
            {
                int id = ListaProductos.Max(x => x.idProducto) + 1;
                return id;
            }
            catch (Exception)
            {
                return 1;
            }
        }

        private int idBodega()
        {
            try
            {
                int id = listaBodegas.Max(x => x.idBodega) + 1;
                return id;
            }
            catch (Exception)
            {
                return 1;
            }
        }

    }
}
