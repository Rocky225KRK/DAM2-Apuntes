using System.ComponentModel;

namespace GestioDequips.Model
{
    public class Jugador : Persona,INotifyPropertyChanged
    {
        private int dorsal;



        public Jugador(long id, string nom, string congnoms, string nacionalitat, string urlFoto,int dorsal) : base(id, nom, congnoms, nacionalitat, urlFoto)
        {
            Dorsal = dorsal;
        }

        public int Dorsal { get => dorsal; set => dorsal = value; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}