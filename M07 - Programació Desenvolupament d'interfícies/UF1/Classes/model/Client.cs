using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.model
{
    internal class Client : Persona
    {
        private int codiClient;

        public int CodiClient
        {
            get { return codiClient; }
            set { codiClient = value; }
        }

        public Client(int codiClient,string nom, int id, string cognoms) : base(nom, id, cognoms)
        {
            CodiClient = codiClient;
        }
    }
}
