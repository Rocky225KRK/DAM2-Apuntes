using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace GestorEntrades
{
    public class Sala
    {
        private long id;
        private String nom;
        private String municipi;
        private String adreca;
        private List<Zona> zones;
        private bool teMapa;
        private int numFiles;
        private int numColumnes;

        public Sala(long id, string nom, string municipi, string adreca, List<Zona> zones, bool teMapa, int numFiles, int numColumnes)
        {
            this.Id = id;
            this.Nom = nom;
            this.Municipi = municipi;
            this.Adreca = adreca;
            this.Zones = zones;
            this.TeMapa = teMapa;
            this.NumFiles = numFiles;
            this.NumColumnes = numColumnes;
        }

        public long Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Municipi { get => municipi; set => municipi = value; }
        public string Adreca { get => adreca; set => adreca = value; }
        public List<Zona> Zones { get => zones; set => zones = value; }
        public bool TeMapa { get => teMapa; set => teMapa = value; }
        public int NumFiles { get => numFiles; set => numFiles = value; }
        public int NumColumnes { get => numColumnes; set => numColumnes = value; }

        private static List<Sala> sales;

        public static List<Sala> GetSales()
        {
            if (sales == null)
            {
                sales = new List<Sala>();



                sales.Add(new Sala(1, "Razzmatazz", "Barcelona", "C/ Tallers 23", new List<Zona>
                {
                    new Zona(1,"Zona1","",new List<Cadira>()),
                    new Zona(2,"Zona2","",new List<Cadira>()),
                    new Zona(3,"Zona3","",new List<Cadira>()),
                    new Zona(4,"Zona4","",new List<Cadira>())
                }, false, 10, 10));

                sales.Add(new Sala(2, "Palau Sant Jordi", "Barcelona", "Av del estadi S/N", new List<Zona>
                {
                    new Zona(1,"Zona1","",new List<Cadira>()),
                    new Zona(2,"Zona2","",new List<Cadira>()),
                    new Zona(3,"Zona3","",new List<Cadira>()),
                    new Zona(4,"Zona4","",new List<Cadira>())
                }, true, 10, 10));

                sales.Add(new Sala(3, "La Sala", "Igualada", "Plaça de Cal Font", new List<Zona>
                {
                    new Zona(1,"Zona1","",new List<Cadira>()),
                    new Zona(2,"Zona2","",new List<Cadira>()),
                    new Zona(3,"Zona3","",new List<Cadira>()),
                    new Zona(4,"Zona4","",new List<Cadira>())
                }, false, 10, 10));
            }

            return sales;
        }
    }
}