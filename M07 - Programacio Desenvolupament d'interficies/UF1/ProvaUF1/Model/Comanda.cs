using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comandos.Model
{
    public class Comanda:INotifyCollectionChanged
    {
        private ObservableCollection<LiniaComanda> linies;

        public event NotifyCollectionChangedEventHandler CollectionChanged;

        public Comanda()
        {
            Linies = new ObservableCollection<LiniaComanda>();
        }

        internal ObservableCollection<LiniaComanda> Linies { get => linies; set => linies = value; }

        public decimal Total
        {
            get
            {
                decimal total = 0;
                foreach (var liniaComanda in Linies)
                {
                    total += liniaComanda.Quantitat * liniaComanda.Producte.Preu;
                }
                return total;
            }
        }
    }
}
