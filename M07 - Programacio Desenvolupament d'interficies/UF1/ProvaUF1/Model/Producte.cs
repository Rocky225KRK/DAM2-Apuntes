using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comandos.Model
{
    public class Producte
    {

        private static List<Producte> _productes;
        public static List<Producte> getProductes()
        {
            if( _productes == null)
            {
                _productes = new List<Producte>();
                // Add sample grocery products to the productList with real image URLs
                _productes.Add(new Producte(1, "Poma", 1.99m, "https://www.collinsdictionary.com/images/thumb/apple_158989157_250.jpg?version=5.0.26", Unitat.KILOS));
                _productes.Add(new Producte(2, "Platan", 0.99m, "https://sklep.onix.pl/wp-content/uploads/2021/03/banan-600x400.jpg", Unitat.KILOS));
                _productes.Add(new Producte(3, "Llet", 2.49m, "https://static.vecteezy.com/system/resources/previews/017/340/365/original/transparent-glass-of-fresh-milk-png.png", Unitat.LITRES));
                _productes.Add(new Producte(4, "Pa", 1.79m, "https://upload.wikimedia.org/wikipedia/commons/thumb/c/c7/Korb_mit_Br%C3%B6tchen.JPG/375px-Korb_mit_Br%C3%B6tchen.JPG", Unitat.UNITATS));

            }
            return _productes;
        }


        private int codi;
        private string nom;
        private decimal preu;
        private string url_imatge;
        private Unitat unitat;
        public Producte(int codi, string nom, decimal preu, string url_imatge, Unitat unitat)
        {
            Codi = codi;
            Nom = nom;
            Preu = preu;
            Url_imatge = url_imatge;
            Unitat = unitat;
        }

        public int Codi { get => codi; set => codi = value; }
        public string Nom { get => nom; set => nom = value; }
        public decimal Preu { get => preu; set => preu = value; }
        public string Url_imatge { get => url_imatge; set => url_imatge = value; }

        public Unitat Unitat { get => unitat; set => unitat = value; }


    }
}
