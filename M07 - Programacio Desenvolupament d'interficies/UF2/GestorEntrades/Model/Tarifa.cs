using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestorEntrades
{
    public class Tarifa
    {
        private String nom;
        private Zona zona;
        private Decimal preu;
        private String desc;

        public Tarifa(string nom, Zona zona, decimal preu, string desc)
        {
            Nom = nom;
            Zona = zona;
            Preu = preu;
            Desc = desc;
        }

        public string Nom { get => nom; set => nom = value; }
        public Zona Zona { get => zona; set => zona = value; }
        public decimal Preu { get => preu; set => preu = value; }
        public string Desc { get => desc; set => desc = value; }
    }
}