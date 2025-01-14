using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LlistesBasiques.model
{
    public class Persona
    {
        private int id;
        private string name;
        private int age;

        public Persona(int id, string name, int age)
        {
            Id = id;
            Name = name;
            Age = age;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public int Age { get => age; set => age = value; }

        public string FullData { get => ">" + Name + " " + Id; }
    }
}
