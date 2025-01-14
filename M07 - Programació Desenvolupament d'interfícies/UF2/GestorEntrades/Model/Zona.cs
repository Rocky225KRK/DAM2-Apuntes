using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestorEntrades
{
    public class Zona
    {
        private long numero;
        private String nom;
        private String desc;
        private List<Cadira> cadires;

        public Zona(long numero, string nom, string desc, List<Cadira> cadires)
        {
            Numero = numero;
            Nom = nom;
            Desc = desc;
            Cadires = cadires;
        }

        public long Numero { get => numero; set => numero = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Desc { get => desc; set => desc = value; }
        public List<Cadira> Cadires { get => cadires; set => cadires = value; }
    }
}