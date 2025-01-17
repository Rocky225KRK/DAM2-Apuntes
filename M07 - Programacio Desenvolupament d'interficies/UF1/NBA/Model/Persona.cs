using System;

namespace GestioDequips.Model
{
    public class Persona
    {
        private long id;
        private string nom;
        private string congnoms;
        private string nacionalitat;
        private string urlFoto;

        public Persona(long id, string nom, string congnoms, string nacionalitat, string urlFoto)
        {
            Id = id;
            Nom = nom;
            Cognoms = congnoms;
            Nacionalitat = nacionalitat;
            UrlFoto = urlFoto;
        }

        public long Id
        {
            get => id; 
            set
            {
                if (value < 0) throw new Exception("ID negatiu ");
                id = value;
            }
        }
        public string Nom { get => nom; set => nom = value; }
        public string Cognoms { get => congnoms; set => congnoms = value; }
        public string Nacionalitat { get => nacionalitat; set => nacionalitat = value; }
        public string UrlFoto { get => urlFoto; set => urlFoto = value; }

        public override bool Equals(object obj)
        {
            return obj is Persona persona &&
                   id == persona.id;
        }
    }
}