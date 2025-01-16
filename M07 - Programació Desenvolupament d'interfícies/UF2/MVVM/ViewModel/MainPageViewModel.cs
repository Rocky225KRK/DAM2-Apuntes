using MVVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.ViewModel
{
    internal class MainPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public PersonaViewModel PersonaSeleccionada { get; set; }

        private ObservableCollection<PersonaViewModel> persones;

		public ObservableCollection<PersonaViewModel> Persones
		{
			get { return persones; }
			set { persones = value; }
		}

        public MainPageViewModel()
        {
            Persones = new ObservableCollection<PersonaViewModel>(
                Persona.GetPersones().Select(
                    p => new PersonaViewModel(p)
                ).ToList()
            );
        }

        public void NewPerson()
        {
            PersonaSeleccionada = new PersonaViewModel();
            PersonaSeleccionada.PersonaOriginal = new PersonaViewModel();
        }
    }
}
