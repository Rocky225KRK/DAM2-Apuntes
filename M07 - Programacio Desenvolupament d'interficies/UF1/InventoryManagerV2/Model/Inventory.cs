using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.model
{
    public class Inventory
    {
        private static List<InventoryItem> items = new List<InventoryItem>();
        public static List<InventoryItem> Items { get { return items; } }
    }
}
