using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tilinder.Model
{
    public class Pair
    {
        public Pair(Person personA, Person personB)
        {
            PersonA = personA;
            PersonB = personB;
        }

        public Person PersonA { get; set; }
        public Person PersonB { get; set; }
    }
}
