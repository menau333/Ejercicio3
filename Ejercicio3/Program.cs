namespace Ejercicio3
{
    using System;

    class Program
    {
        static string[] nombres = new string[100];
        static string[] localidades = new string[100];
        static int[] cantidades = new int[100];
        static int count = 0;

        static void Main(string[] args)
        {
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("1. Agregar proveedor");
                Console.WriteLine("2. Modificar datos del proveedor");
                Console.WriteLine("3. Eliminar proveedor");
                Console.WriteLine("4. Buscar por nombre del proveedor");
                Console.WriteLine("5. Mostrar todos proveedores alfabéticamente");
                Console.WriteLine("6. Salir");
                Console.Write("Ingrese su elección: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AgregarProveedor();
                        break;
                    case "2":
                        ModificarProveedor();
                        break;
                    case "3":
                        EliminarProveedor();
                        break;
                    case "4":
                        BuscarPorProveedor();
                        break;
                    case "5":
                        MostrarProveedoresOrdenados();
                        break;
                    case "6":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Elección inválida. Por favor, intente nuevamente.");
                        break;
                }

                Console.WriteLine();
            }
        }

        static void AgregarProveedor()
        {
            Console.Write("Ingrese el nombre: ");
            string nombre = Console.ReadLine();

            Console.Write("Ingrese la localidad: ");
            string localidad = Console.ReadLine();

            Console.Write("Ingrese la cantidad: ");
            int cantidad = Convert.ToInt32(Console.ReadLine());

            nombres[count] = nombre;
            localidades[count] = localidad;
            cantidades[count] = cantidad;
            count++;

            Console.WriteLine("Datos agregados exitosamente.");
        }

        static void ModificarProveedor()
        {
            Console.Write("Ingrese el nombre a modificar: ");
            string nombre = Console.ReadLine();

            int index = BuscarIndicePorNombre(nombre);

            if (index != -1)
            {
                Console.WriteLine("Ingrese la nueva localidad: ");
                string newLocalidad = Console.ReadLine();

                Console.WriteLine("Ingrese la nueva cantidad: ");
                int newCantidad = Convert.ToInt32(Console.ReadLine());

                localidades[index] = newLocalidad;
                cantidades[index] = newCantidad;

                Console.WriteLine("Datos modificados exitosamente.");
            }
            else
            {
                Console.WriteLine("Datos no encontrados.");
            }
        }

        static void EliminarProveedor()
        {
            Console.Write("Ingrese el nombre a eliminar: ");
            string nombre = Console.ReadLine();

            int index = BuscarIndicePorNombre(nombre);

            if (index != -1)
            {
                for (int i = index; i < count - 1; i++)
                {
                    nombres[i] = nombres[i + 1];
                    localidades[i] = localidades[i + 1];
                    cantidades[i] = cantidades[i + 1];
                }

                count--;

                Console.WriteLine("Datos eliminados exitosamente.");
            }
            else
            {
                Console.WriteLine("Datos no encontrados.");
            }
        }

        static void BuscarPorProveedor()
        {
            Console.Write("Ingrese el nombre a buscar: ");
            string nombre = Console.ReadLine();

            int index = BuscarIndicePorNombre(nombre);

            if (index != -1)
            {
                Console.WriteLine("Nombre: " + nombres[index]);
                Console.WriteLine("Localidad: " + localidades[index]);
                Console.WriteLine("Cantidad: " + cantidades[index]);
            }
            else
            {
                Console.WriteLine("Datos no encontrados.");
            }
        }

        static void MostrarProveedoresOrdenados()
        {
            // Copiar los arreglos actuales en nuevos arreglos temporales
            string[] tempNombres = new string[count];
            string[] tempLocalidades = new string[count];
            int[] tempCantidades = new int[count];

            Array.Copy(nombres, tempNombres, count);
            Array.Copy(localidades, tempLocalidades, count);
            Array.Copy(cantidades, tempCantidades, count);

            // Ordenar los arreglos temporales según la inicial del nombre
            Array.Sort(tempNombres);

            // Mostrar los datos ordenados
            Console.WriteLine("Datos ordenados alfabéticamente por inicial del nombre:");

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("Nombre: " + tempNombres[i]);
                Console.WriteLine("Localidad: " + tempLocalidades[i]);
                Console.WriteLine("Cantidad: " + tempCantidades[i]);
                Console.WriteLine();
            }
        }

        static int BuscarIndicePorNombre(string nombre)
        {
            for (int i = 0; i < count; i++)
            {
                if (nombres[i].Equals(nombre, StringComparison.OrdinalIgnoreCase))
                {
                    return i;
                }
            }

            return -1;
        }
    }
}