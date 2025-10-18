using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenU2
{
    public class Atracciones : IAtraccion
    {
        public int Numero { get; set; }
        public string Nombre { get; set; }
        public bool Estado { get; set; }

        public Atracciones(int numero, string nombre)
        {
            Numero = numero;
            Nombre = nombre;
            Estado = false;
        }

        public void OcuparAtraccion()
        {
            Estado = true;
            Console.WriteLine($"Atracción {Nombre} OCUPADA");
        }

        public void DesocuparAtraccion()
        {
            Estado = false;
            Console.WriteLine($"Atracción {Nombre} LIBRE");
        }

        public void ReporteAtraccion()
        {
            Console.WriteLine($"Atracción {Numero}. {Nombre} está: {Estado}");
        }

    }
}
