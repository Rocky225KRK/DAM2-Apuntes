using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestorEntrades
{
    public class Cadira
    {
        private String desc;
        private long id;
        private int x;
        private int y;

        public Cadira(string desc, long id, int x, int y)
        {
            Desc = desc;
            Id = id;
            X = x;
            Y = y;
        }

        public string Desc { get => desc; set => desc = value; }
        public long Id { get => id; set => id = value; }
        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
    }
}