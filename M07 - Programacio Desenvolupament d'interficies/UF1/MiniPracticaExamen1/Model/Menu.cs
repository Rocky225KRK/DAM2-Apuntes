using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniPracticaExamen1.Model
{
    public class Menu:INotifyCollectionChanged
    {
		private OC<LiniaMenu> lmenu;

        public event NotifyCollectionChangedEventHandler CollectionChanged;

        public Menu()
        {
            LMenu = new OC<LiniaMenu>();
        }

        public OC<LiniaMenu> LMenu
		{
			get { return lmenu; }
			set { lmenu = value; }
		}

    }
}
