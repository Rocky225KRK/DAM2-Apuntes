using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Navegació
{
    internal class Persona
    {
        public Persona(string nom, string cognom)
        {
            Nom = nom;
            Cognom = cognom;
        }

        public string Nom {  get; set; }
        public string Cognom {  get; set; }
    }
}
