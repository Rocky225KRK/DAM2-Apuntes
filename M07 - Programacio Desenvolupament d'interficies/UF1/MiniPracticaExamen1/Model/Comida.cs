using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniPracticaExamen1.Model
{
    public class Comida
    {
        private String name;
        private Decimal price;

        public Comida(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get => name; set => name = value; }
        public decimal Price { get => price; set => price = value; }

        private static List<Comida> comidas;

        public static List<Comida> GetComidas()
        {
            if (comidas == null)
            {
                comidas = new List<Comida>();

                comidas.Add(new Comida("Patatas",4.45m));
                comidas.Add(new Comida("Hamburguesa",11.99m));
                comidas.Add(new Comida("Ensalada",2.15m));
                comidas.Add(new Comida("Esternocleidomastoideo",987654.321m));
            }

            return comidas;
        }

    }
}
