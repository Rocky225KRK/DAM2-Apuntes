using InventoryManagerV2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace InventoryManager.model
{
    public class Item
    {
		private long id;
        private String name;
        private String desc;
        private String url;
        private OC<Recipe> recipes;

        public Item(String name, String url, String desc)
        {
            Name = name;
			Url = url;
			Desc = desc;
            recipes = new OC<Recipe>();
        }

		public long Id { get => id; set => id = value; }
		public String Name { get => name; set => name = value; }
		public String Desc { get => desc; set => desc = value; }
		public String Url { get => url; set => url = value; }
        public OC<Recipe> Recipes { get => recipes; set => recipes = value; }

        private static OC<Item> items = new OC<Item>();
        public static OC<Item> Items { get => items; set => items = value; }

        public static OC<Item> getItemList()
        {
            // ms-appx://InventoryManager/Assets/photos/
            Item i1 = new Item("Blaze Rod", "ms-appx://InventoryManager/Assets/photos/blaze_rod.png", "Infernal drop from a Blaze");
            Item i2 = new Item("Blaze Powder", "ms-appx://InventoryManager/Assets/photos/blaze_powder.png", "Crafted using a Blaze Rod");
            Item i3 = new Item("Glowstone", "ms-appx://InventoryManager/Assets/photos/glowstone.png", "Luminescent block from Hell itself");
            Item i4 = new Item("Glowstone Dust", "ms-appx://InventoryManager/Assets/photos/glowstone_dust.png", "Luminescent material from Hell itself");
            Item i5 = new Item("Infernal Powder", "ms-appx://InventoryManager/Assets/photos/infernal_powder.png", "Infernal material that contains the essence of Hell");
            Item i6 = new Item("Diamond", "ms-appx://InventoryManager/Assets/photos/diamond.png", "Durable gem from the mines");
            Item i7 = new Item("Diamond Block", "ms-appx://InventoryManager/Assets/photos/diamond_block.png", "Block made from a precious gem");
            Item i8 = new Item("Chorus Flower", "ms-appx://InventoryManager/Assets/photos/chorus_flower.png", "Exotic flower from the End of the World");
            Item i9 = new Item("Echo Shard", "ms-appx://InventoryManager/Assets/photos/echo_shard.png", "Material that absorbs vibrations from its surroundings");
            Item i10 = new Item("Enderian Shard", "ms-appx://InventoryManager/Assets/photos/enderian_shard.png", "Material that absorbs vibrations from its surroundings");
            Item i11 = new Item("Potato", "ms-appx://InventoryManager/Assets/photos/potato.png", "Food taken from fertile land");
            Item i12 = new Item("Baked Potato", "ms-appx://InventoryManager/Assets/photos/baked_potato.png", "Food at its best");
            Item i13 = new Item("Hot Potato", "ms-appx://InventoryManager/Assets/photos/hot_potato.png", "Potato so hot it could lead to spontaneous combustion");



            Recipe r1 = new Recipe("Normal", i2);
            r1.Ingredients.Add(i1,1);

            Recipe r2 = new Recipe("Normal", i3);
            r2.Ingredients.Add(i4, 4);

            Recipe r3 = new Recipe("With Block", i5);
            r3.Ingredients.Add(i2,8);
            r3.Ingredients.Add(i3,1);

            Recipe r4 = new Recipe("With Powder", i5);
            r4.Ingredients.Add(i2, 8);
            r4.Ingredients.Add(i4, 4);

            Recipe r5 = new Recipe("Normal", i7);
            r5.Ingredients.Add(i6, 9);

            Recipe r6 = new Recipe("Normal", i10);
            r6.Ingredients.Add(i7, 4);
            r6.Ingredients.Add(i8, 4);
            r6.Ingredients.Add(i9, 1);

            Recipe r7 = new Recipe("Normal", i12);
            r7.Ingredients.Add(i2, 2);
            r7.Ingredients.Add(i11, 1);

            Recipe r8 = new Recipe("Normal", i13);
            r8.Ingredients.Add(i5, 4);
            r8.Ingredients.Add(i10, 4);
            r8.Ingredients.Add(i12, 1);

            i2.Recipes.Add(r1);
            i3.Recipes.Add(r2);
            i5.Recipes.Add(r3);
            i5.Recipes.Add(r4);
            i7.Recipes.Add(r5);
            i10.Recipes.Add(r6);
            i12.Recipes.Add(r7);
            i13.Recipes.Add(r8);

            items.Add(i1);
            items.Add(i2);
            items.Add(i3);
            items.Add(i4);
            items.Add(i5);
            items.Add(i6);
            items.Add(i7);
            items.Add(i8);
            items.Add(i9);
            items.Add(i10);
            items.Add(i11);
            items.Add(i12);
            items.Add(i13);

            return items;
        }
    }
}
