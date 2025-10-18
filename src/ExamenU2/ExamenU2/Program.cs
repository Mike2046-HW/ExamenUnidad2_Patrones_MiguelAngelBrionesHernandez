using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenU2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int opc = 0;
            int opc2 = 0;

            var parque = GestorParque.instance;
            var comp = GestorParque.instance;

            parque.Reporte();
            Console.WriteLine("");
            parque.EstadoParque();

            do
            {

                Console.WriteLine("\nIndique que opción realizar: \r\n" +
                    "1. Ocupar atracción del parque\n" +
                    "2. Liberar atracción del parque\n" +
                    "3. Mostrar reporte del parque\n" +
                    "4. Mostrar ingresos generados\n");

                Console.Write("Selecciona una opción (1-4): ");
                opc = int.Parse(Console.ReadLine());
                Console.WriteLine("");

                switch (opc)
                {
                    case 1:
                        Console.Clear();
                        var atraccion = parque.UsarAtraccion();
                        parque.Reporte();
                        Console.WriteLine("");
                        parque.EstadoParque();
                        break;


                    case 2:
                        Console.Clear();
                        parque.LiberarAtraccion();
                        parque.Reporte();
                        Console.WriteLine("");
                        parque.EstadoParque();
                        break;

                    case 3:
                        Console.Clear();
                        parque.Reporte();
                        break;

                    case 4:
                        Console.Clear();
                        parque.EstadoParque();
                        break;

                }

                Console.WriteLine("");
                Console.Write("¿Desea realizar otra acción? (1 = Si / 0 = No): ");
                opc2 = int.Parse(Console.ReadLine());
                Console.Clear();

            } while (opc2 == 1);
        }
    }
}
