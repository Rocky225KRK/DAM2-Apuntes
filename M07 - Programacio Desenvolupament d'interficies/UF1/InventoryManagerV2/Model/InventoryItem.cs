using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.model
{
    public class InventoryItem
    {
		public InventoryItem(Item item,int quantity)
		{
			Item = item;
			Quantity = quantity;
		}

		private Item item;

		public Item Item
		{
			get { return item; }
			set { item = value; }
		}
		private int quantity;

		public int Quantity
		{
			get { return quantity; }
			set { quantity = value; }
		}

	}
}
