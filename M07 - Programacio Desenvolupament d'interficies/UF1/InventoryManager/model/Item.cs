using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.model
{
    public class Item
    {
		private long id;
        private String name;
        private String desc;
        private String url;
        List<Recipe> recipes;

        public Item(String name, String url, String desc)
        {
            Name = name;
			Url = url;
			Desc = desc;
        }

		public long Id { get => id; set => id = value; }
		public String Name { get => name; set => name = value; }
		public String Desc { get => desc; set => desc = value; }
		public String Url { get => url; set => url = value; }
	}
}
