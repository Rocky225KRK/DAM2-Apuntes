using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniPracticaExamen1.Model
{
    public class LiniaMenu:INotifyPropertyChanged
    {
        private Comida comida;
        private int qty;

        public event PropertyChangedEventHandler PropertyChanged;

        public LiniaMenu(Comida comida, int qty)
        {
            Comida = comida;
            Qty = qty;
        }
        public Comida Comida { get => comida; set => comida = value; }
        public int Qty { get => qty; set => qty = value; }

    }
}
