using MVVM.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.ViewModel
{
    public class PersonaViewModel : BaseViewModel
    {
        private Persona persona;

        public PersonaViewModel(PersonaViewModel p)
        {
            this.persona = p.persona;
            this.Nom = p.Nom;
            this.Sexe = p.Sexe;
            this.IsActiu = p.IsActiu;
            this.ImageURL = p.ImageURL;
            this.Edat = p.Edat;
        }

        public PersonaViewModel(Persona p)
        {
            this.persona = p;
            this.Nom=p.Nom;
            this.Sexe=p.Sexe;
            this.IsActiu=p.Actiu;
            this.ImageURL=p.ImageURL;
            this.Edat=p.Edat;
        }

        public String Nom { get; set; }
        public SexeEnum Sexe { get; set; }
        public bool IsActiu { get; set; }
        public String ImageURL { get; set; }
        public int Edat { get; set; }

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
    }
}
