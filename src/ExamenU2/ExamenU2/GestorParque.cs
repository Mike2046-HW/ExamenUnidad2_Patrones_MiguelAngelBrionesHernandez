using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenU2
{
    public class GestorParque
    {
        private static GestorParque _instance;
        private static readonly object _lock = new object();

        public string Nombre { get; private set; }
        public double Ingresos { get; private set; }

        private readonly Stack<Atracciones> disponlibles = new Stack<Atracciones>();
        private readonly List<Atracciones> ocupadas = new List<Atracciones>();
        private readonly int MaximoAtracciones = 5;

        private GestorParque()
        {
            Nombre = "PARQUE EXAMEN UNIDAD 2";
            string[] nombres = { "Montaña  Rusa", "Arcade", "Sillas voladoras", "Barco", "Rueda de la fortuna" };

            for (int i = 0; i < MaximoAtracciones; i++)
            {
                var atrac = new Atracciones(i + 1, nombres[i]);
                disponlibles.Push(atrac);
            }

            Console.WriteLine($"{Nombre} TIENE {MaximoAtracciones} ATRACCIONES\n");

        }

        public static GestorParque instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new GestorParque();
                        }
                    }
                }
                return _instance;
            }
        }

        public void AgregarIngreso(double cantidad)
        {
            Ingresos += cantidad;
        }

        public void EstadoParque()
        {
            Console.WriteLine($"El parque ha generado {Ingresos}$ en ingresos");
        }

        public Atracciones UsarAtraccion()
        {
            if (disponlibles.Count == 0)
            {
                Console.WriteLine("Atracciones Ocupadas");
                return null;
            }

            var atr = disponlibles.Pop();
            atr.OcuparAtraccion();
            ocupadas.Add(atr);

            AgregarIngreso(50);

            return atr;
        }

        public void LiberarAtraccion()
        {
            if (ocupadas.Count == 0)
            {
                Console.WriteLine("Todas las atracciones fueron liberadas");
                Console.ReadKey();
                Console.Clear();
                return;
            }

            var atr = ocupadas.Last(); // Libera la última ocupada
            atr.DesocuparAtraccion();
            ocupadas.Remove(atr);
            disponlibles.Push(atr);

        }

        public void Reporte()
        {
            Console.WriteLine("ESTADO DEL PARQUE\n");
            Console.WriteLine($"Hay {disponlibles.Count} atracciones disponibles y {ocupadas.Count} atracciones ocupadas:\n");

            foreach (var atr in disponlibles.Concat(ocupadas).OrderBy(a => a.Numero))
                Console.WriteLine($"#{atr.Numero}. {atr.Nombre} - Ocupada: {atr.Estado}");
        }
    }
}
