using InventoryManager.model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace InventoryManager
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private List<Item> allItems = new List<Item>();
        private List<Recipe> allRecipes=new List<Recipe>();
        private List<Recipe> itemRecipes = new List<Recipe>();
        private Dictionary<Item,int> recipeIngredients = new Dictionary<Item,int>();
        List<KeyValuePair<Item, int>> ingredients=new List<KeyValuePair<Item, int>>();

        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            allItems.Add(new Item("Test 0","Assets/test.png","Desc Test"));
            allItems.Add(new Item("Test 1","Assets/test.png","Desc Test"));
            allItems.Add(new Item("Test 2","Assets/test.png","Desc Test"));
            allItems.Add(new Item("Test 3","Assets/test.png","Desc Test"));

            allRecipes.Add(new Recipe("Test 0.0", allItems[0]));
            allRecipes.Add(new Recipe("Test 0.1", allItems[0]));
            allRecipes.Add(new Recipe("Test 1.0", allItems[1]));
            allRecipes.Add(new Recipe("Test 1.1", allItems[1]));

            //allRecipes[0].Ingredients.Add(allItems[0],5);
            //allRecipes[0].Ingredients.Add(allItems[1],2);
            //allRecipes[1].Ingredients.Add(allItems[2],3);
            //allRecipes[1].Ingredients.Add(allItems[3],7);

            lsvItems.ItemsSource = allItems;
        }

        private void lsvItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //int index=lsvItems.SelectedIndex;
            //itemRecipes = new List<Recipe>();
            //
            //foreach (Recipe recipe in allRecipes)
            //{
            //    if (recipe.Result == allItems[index])
            //    {
            //        itemRecipes.Add(recipe);
            //    }
            //}
            //
            //lsvRecipes.ItemsSource = itemRecipes;
            //lsvIngredients.ItemsSource = null;
        }

        private void lsvRecipes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //int index = lsvRecipes.SelectedIndex;
            //Debug.WriteLine("Index: "+index);
            //if (index >= 0 && index < allRecipes.Count)
            //{
            //    ingredients = allRecipes[index].Ingredients.ToList();
            //    lsvIngredients.ItemsSource = ingredients;
            //}
            //else
            //{
            //    ingredients.Clear();
            //}
        }

        private void itemButtonClick(object sender, RoutedEventArgs e)
        {
            int index = lsvItems.SelectedIndex;

        }

        private void recipeButtonClick(object sender, RoutedEventArgs e)
        {

        }

        private void ingredientsButtonClick(object sender, RoutedEventArgs e)
        {

        }
    }
}
