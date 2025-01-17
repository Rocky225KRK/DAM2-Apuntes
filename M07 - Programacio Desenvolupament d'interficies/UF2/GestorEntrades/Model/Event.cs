using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestorEntrades
{
    public class Event
    {
        private TipusEvent tipus;
        private long id;
        private String nom;
        private String protagonista;
        private String imatgePath;
        private String desc;
        private DateTime data;
        private List<Tarifa> tarifes;
        private Sala sala;
        private Estat estat;

        public Event(TipusEvent tipus, long id, string nom, string protagonista, string imatgePath, string desc, DateTime data, List<Tarifa> tarifes, Sala sala, Estat estat)
        {
            Tipus = tipus;
            Id = id;
            Nom = nom;
            Protagonista = protagonista;
            ImatgePath = imatgePath;
            Desc = desc;
            Data = data;
            Tarifes = tarifes;
            Sala = sala;
            Estat = estat;
        }

        public TipusEvent Tipus { get => tipus; set => tipus = value; }
        public long Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Protagonista { get => protagonista; set => protagonista = value; }
        public string ImatgePath { get => imatgePath; set => imatgePath = value; }
        public string Desc { get => desc; set => desc = value; }
        public DateTime Data { get => data; set => data = value; }
        public List<Tarifa> Tarifes { get => tarifes; set => tarifes = value; }
        public Sala Sala { get => sala; set => sala = value; }
        public Estat Estat { get => estat; set => estat = value; }

        private static List<Event> events;
        public static List<Event> GetEvents()
        {
            if(events == null)
            {
                events = new List<Event>();
                events.Add(new Event(TipusEvent.MUSICA, 1, "IM World Tour", "Iron Maiden", "ms-appx:///Assets/photos/placeholder.png", "IM World Tour", DateTime.Parse("12/12/2020"), new List<Tarifa>(), Sala.GetSales()[1], Estat.NOU));
                events.Add(new Event(TipusEvent.MUSICA, 2, "SImpathy tour 23", "Iron Maiden", "ms-appx:///Assets/photos/placeholder.png", "IM World Tour", DateTime.Parse("12/12/2023"), new List<Tarifa>(), Sala.GetSales()[0], Estat.NOU));
            }

            return events;
        }
    }
}