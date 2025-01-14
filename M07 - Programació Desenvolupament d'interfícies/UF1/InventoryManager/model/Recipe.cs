using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.model
{
    public class Recipe
    {
		public Recipe(String name,Item result)
		{
			Name = name;
			Result = result;
		}

		Dictionary<Item,int> ingredients;

		private Item result;

		public Item Result
		{
			get { return result; }
			set { result = value; }
		}

		private String name;

		public String Name
		{
			get { return name; }
			set { name = value; }
		}

	}
}
