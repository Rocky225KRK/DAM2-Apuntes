using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comandos.Model
{
    public class LiniaComanda:INotifyPropertyChanged
    {
        private int numero;
        private Producte producte;        
        private int quantitat;

        public event PropertyChangedEventHandler PropertyChanged;


        public LiniaComanda(int numero, int quantitat, Producte producte)
        {
            Numero = numero;
            Quantitat = quantitat;
            Producte = producte;
        }

        public int Numero { get => numero; set => numero = value; }
        public int Quantitat { get => quantitat; set => quantitat = value; }
        public Producte Producte { get => producte; set => producte = value; }

    }
}
