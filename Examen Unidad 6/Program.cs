using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Examen_Unidad_6
{
    class Amazon
    {
        //Atributos
        public string nombreProducto, descripcion;
        public float precio;
        public int cantidad;

        //Constructor
        public Amazon(string nombreProducto, string descripcion, float precio, int cantidad)
        {
            this.nombreProducto = nombreProducto;
            this.descripcion = descripcion;
            this.precio = precio;
            this.cantidad = cantidad;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //declaracion de variables auxiliares
            string nombreProducto, descripcion;
            float precio;
            int cantidad;
            int opc;

            StreamWriter sw = new StreamWriter("Productos.txt",true);

            //Menu de Opciones
            do
            {
                Console.Clear();
                Console.WriteLine("\n--- SISTEMA DE INVENTARIO---");
                Console.WriteLine("1.- Agregar un Producto.");
                Console.WriteLine("2.- Ver Productos.");
                Console.WriteLine("3.- Salida del Programa.");
                Console.Write("\n Que opcion desea: ");
                opc = int.Parse(Console.ReadLine());
                Console.Clear();

                switch (opc)
                {
                    case 1:
                        Console.Write("Nombre del producto: ");
                        nombreProducto = Console.ReadLine();
                        Console.Write("Descripcion del producto: ");
                        descripcion = Console.ReadLine();
                        Console.Write("Precio del Producto: ");
                        precio = float.Parse(Console.ReadLine());
                        Console.Write("Cantidad en stock: ");
                        cantidad = int.Parse(Console.ReadLine());
                        Amazon am = new Amazon(nombreProducto, descripcion, precio, cantidad);

                        sw.WriteLine("Nombre del producto      : " + nombreProducto);
                        sw.WriteLine("Descripcion del producto : " + descripcion);
                        sw.WriteLine("Precio del producto      : {0:C}", precio);
                        sw.WriteLine("Cantidad en stock        : " + cantidad);
                        sw.WriteLine("\n");
                        sw.Close();

                        Console.Write("\nPresione <Enter> para Continuar...");
                        Console.ReadKey();
                        break;

                    case 2:
                        try
                        {
                            StreamReader sr = new StreamReader("Productos.txt");
                            string line;
                            while ((line = sr.ReadLine()) != null)
                            {
                                Console.WriteLine(line);
                            }
                            sr.Close();
                        }
                        catch (FileNotFoundException)
                        {
                            Console.WriteLine("No se ha encontrado el archivo");
                        }
                        Console.Write("\nPresione <Enter> para Continuar...");
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.Write("\nPresione <Enter> para Salir del Programa");
                        Console.ReadKey();
                        break;

                    default:
                        Console.WriteLine("\nNo existe esa opcion, Presione <Enter> para Continuar...");
                        Console.ReadKey();
                        break;
                }
            } while (opc != 3);
        }
    }
}

