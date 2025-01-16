using MVVM.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;

namespace MVVM.ViewModel
{
    public class PersonaViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Persona persona;

        public PersonaViewModel PersonaOriginal { get; set; }

        public PersonaViewModel(PersonaViewModel p)
        {
            PersonaOriginal = p;
            this.persona = p.persona;
            this.Id = p.Id;
            this.Nom = p.Nom;
            this.Sexe = p.Sexe;
            this.IsActiu = p.IsActiu;
            this.ImageURL = p.ImageURL;
            this.Edat = p.Edat;
        }

        public PersonaViewModel(Persona p)
        {
            this.persona = p;
            this.Id = p.Id;
            this.Nom=p.Nom;
            this.Sexe=p.Sexe;
            this.IsActiu=p.Actiu;
            this.ImageURL=p.ImageURL;
            this.Edat=p.Edat+"";
        }

        public PersonaViewModel()
        {
            this.Id = -1;
            this.Nom = "";
            this.Edat = "";
            this.Sexe = SexeEnum.NO_DEFINIT;
            this.ImageURL = "";
            this.IsActiu = false;
        }

        public int Id { get; set; } 
        public String Nom { get; set; }
        public SexeEnum Sexe { get; set; }
        public bool IsActiu { get; set; }
        public String ImageURL { get; set; }
        public String Edat { get; set; }

        public String EdatError
        {
            get
            {
                if (Persona.ValidaEdat(Edat))
                    return "";
                else return "Ruc, escriu l'edat.";

            }
        }

        public Brush EdatBackground
        {
            get
            {
                return createBooleanBrush(Persona.ValidaEdat(Edat));

            }
        }

        public Brush NomBackground
        {
            get
            {
                return createBooleanBrush(Persona.ValidaNom(Nom));

            }
        }

        private Brush createBooleanBrush(bool isOk)
        {
            if (isOk)
                return new SolidColorBrush(Colors.Green);
            else return new SolidColorBrush(Colors.Red);
        }

        public bool EsValida
        {
            get
            {
                return (CancelVisibility==Visibility.Visible && Persona.ValidaEdat(Edat) && Persona.ValidaNom(Nom));

            }
        }

        public Visibility CancelVisibility
        {
            get
            {
                return PersonaOriginal==null||!this.Nom.Equals(this.PersonaOriginal.Nom) ||
                    !this.Edat.Equals(this.PersonaOriginal.Edat + "") ||
                    this.IsActiu != this.PersonaOriginal.IsActiu ||
                    this.Sexe != PersonaOriginal.Sexe ? Visibility.Visible : Visibility.Collapsed;
            }
        }

        public ArrayList ListSexe
        {
            get
            {
                return getSexes();
            }
        }

        public static ArrayList listSexes;
        public static ArrayList getSexes()
        {
            if(listSexes == null)
            {
                listSexes = new ArrayList(Enum.GetValues(typeof(SexeEnum)));
            }
            return listSexes;
        }

        /*
            private String nom;
            //private bool sexe;
            private SexeEnum sexe;
            private bool actiu;
            private string imageURL;
            private int edat;
         */

        public void Save()
        {
            PersonaOriginal.Nom = persona.Nom = this.Nom;
            if (int.TryParse(this.Edat, out int e))
            {
                persona.Edat = e;
                PersonaOriginal.Edat = this.Edat;
            }
            PersonaOriginal.IsActiu = persona.Actiu = this.IsActiu;
            PersonaOriginal.Sexe = persona.Sexe = this.Sexe;

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CancelVisibility"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("EsValida"));
        }

        public void Cancel()
        {
            this.Nom = PersonaOriginal.Nom;
            this.Edat = PersonaOriginal.Edat;
            this.IsActiu = PersonaOriginal.IsActiu;
            this.Sexe = PersonaOriginal.Sexe;
        }

        public Visibility FormVisibility
        {
            get
            {
                return this.PersonaOriginal!=null?Visibility.Visible:Visibility.Collapsed;
            }
        }
    }
}
