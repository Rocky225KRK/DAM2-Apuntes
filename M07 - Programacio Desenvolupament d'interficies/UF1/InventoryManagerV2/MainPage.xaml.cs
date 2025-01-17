using InventoryManager.model;
using InventoryManagerV2.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace InventoryManagerV2
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        

        public MainPage()
        {
            this.InitializeComponent();
            this.lsvItems.ItemsSource = Item.getItemList();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            addCboItemList(cboRecipeItem);
            addCboItemList(cboInventoryItem);
            List<int> num = new List<int>();
            for (int i = 1; i < 100; i++)
            {
                num.Add(i);
            }
            cboRecipeQty.ItemsSource = num;
            cboInventoryItemQty.ItemsSource = num;

            btnDeleteItem.IsEnabled = false;
            btnDeleteRecipe.IsEnabled = false;
            btnDeleteIngredient.IsEnabled = false;
            btnAddItem.IsEnabled = true;
            btnAddRecipe.IsEnabled = false;
            btnAddIngredients.IsEnabled = false;
            btnSaveItem.IsEnabled = false;
            btnDeleteInventoryItem.IsEnabled = false;
            btnCombinarInventory.IsEnabled = false;

            loadInventoryItems();
        }

        private void addCboItemList(ComboBox cbo)
        {
            List<String> names = new List<String>();
            foreach (Item item in (OC<Item>)lsvItems.ItemsSource)
            {
                names.Add(item.Name);
            }
            cbo.ItemsSource = names;
        }

        private void lsvItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(lsvItems.SelectedItem is Item selected && selected != null)
            {
                txbItemName.Text=selected.Name;
                txbItemURL.Text= selected.Url;
                txbItemDesc.Text= selected.Desc;

                lsvRecipes.ItemsSource = selected.Recipes;

                btnDeleteItem.IsEnabled = true;
                btnSaveItem.IsEnabled = true;
                btnAddItem.IsEnabled = false;
                btnAddRecipe.IsEnabled = true;
            }
            else
            {
                txbItemName.Text = "";
                txbItemURL.Text = "";
                txbItemDesc.Text = "";

                lsvRecipes.ItemsSource = null;

                btnDeleteItem.IsEnabled = false;
                btnSaveItem.IsEnabled = false;
                btnAddItem.IsEnabled = true;
                btnAddRecipe.IsEnabled = false;
            }
        }

        private void lsvRecipes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(lsvRecipes.SelectedItem is Recipe selected && selected != null)
            {
                lsvIngredients.ItemsSource = selected.Ingredients;

                btnDeleteRecipe.IsEnabled = true;
                btnAddIngredients.IsEnabled = true;
            }
            else
            {
                lsvIngredients.ItemsSource = null;

                btnDeleteRecipe.IsEnabled = false;
                btnAddIngredients.IsEnabled = false;
            }
        }

        private void lsvIngredients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(lsvIngredients.SelectedItem is KeyValuePair<Item,int> selected)
            {
                btnDeleteIngredient.IsEnabled = true;
            }
            else
            {
                btnDeleteIngredient.IsEnabled = false;
            }
        }

        private void btnAddItem_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(txbItemName.Text) && !String.IsNullOrWhiteSpace(txbItemURL.Text) && !String.IsNullOrWhiteSpace(txbItemDesc.Text))
            {
                String name = txbItemName.Text;
                String url = txbItemURL.Text;
                String desc = txbItemDesc.Text;

                bool exists = false;
                foreach (Item item in Item.Items)
                {
                    if (item.Name.Equals(name)) {
                        exists = true;
                        break;
                    }
                }

                if (!exists)
                {
                    Item.Items.Add(new Item(name, url, desc));

                    lsvItems.ItemsSource = null;
                    lsvItems.ItemsSource = Item.Items;

                    addCboItemList(cboRecipeItem);
                    addCboItemList(cboInventoryItem);
                }
            }
        }

        private void btnAddRecipe_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(txbRecipeName.Text) && lsvItems.SelectedItem is Item selected)
            {
                String name = txbRecipeName.Text;

                selected.Recipes.Add(new Recipe(name, selected));

                lsvRecipes.ItemsSource = null;
                lsvRecipes.ItemsSource = selected.Recipes;
            }
        }

        private void btnAddIngredients_Click(object sender, RoutedEventArgs e)
        {
            if (cboRecipeItem.SelectedItem is String itemName && cboRecipeQty.SelectedItem is int itemQty && lsvRecipes.SelectedItem is Recipe selected)
            {
                Item ingredient = null;
                foreach (Item item in Item.Items)
                {
                    if (item.Name.Equals(itemName))
                    {
                        ingredient = item;
                        break;
                    }
                }

                if(!selected.Ingredients.ContainsKey(ingredient))
                    selected.Ingredients.Add(ingredient,itemQty);

                lsvIngredients.ItemsSource = null;
                lsvIngredients.ItemsSource = selected.Ingredients;
            }
        }

        private void btnSaveItem_Click(object sender, RoutedEventArgs e)
        {
            if (lsvItems.SelectedItem is Item selected && !String.IsNullOrWhiteSpace(txbItemName.Text) && !String.IsNullOrWhiteSpace(txbItemURL.Text) && !String.IsNullOrWhiteSpace(txbItemDesc.Text))
            {
                int index = Item.Items.IndexOf(selected);

                Item.Items[index].Name = txbItemName.Text;
                Item.Items[index].Url = txbItemURL.Text;
                Item.Items[index].Desc = txbItemDesc.Text;

                lsvItems.ItemsSource = null;
                lsvRecipes.ItemsSource = null;
                lsvIngredients.ItemsSource = null;

                lsvItems.ItemsSource = Item.Items;
                addCboItemList(cboRecipeItem);
                addCboItemList(cboInventoryItem);
            }
        }

        private void btnDeleteItem_Click(object sender, RoutedEventArgs e)
        {
            if(lsvItems.SelectedItem is Item selected)
            {
                Item.Items.Remove(selected);

                addCboItemList(cboRecipeItem);

                lsvItems.ItemsSource = null;
                lsvItems.ItemsSource = Item.Items;
            }
        }

        private void btnDeleteRecipe_Click(object sender, RoutedEventArgs e)
        {
            if(lsvRecipes.SelectedItem is Recipe selected)
            {
                Item item = (Item)lsvItems.SelectedItem;
                item.Recipes.Remove(selected);

                lsvRecipes.ItemsSource = null;
                lsvRecipes.ItemsSource = item.Recipes;
            }
        }

        private void btnDeleteIngredient_Click(object sender, RoutedEventArgs e)
        {
            if(lsvIngredients.SelectedItem is KeyValuePair<Item,int> selected)
            {
                Recipe recipe = (Recipe)lsvRecipes.SelectedItem;
                recipe.Ingredients.Remove(selected.Key);

                lsvIngredients.ItemsSource = null;
                lsvIngredients.ItemsSource = recipe.Ingredients;
            }
        }

        private void btnAddInventoryItem_Click(object sender, RoutedEventArgs e)
        {
            if(cboInventoryItem.SelectedItem is String itemName && cboInventoryItemQty.SelectedItem is int itemQty)
            {
                bool exists = false;
                foreach(InventoryItem invItem in inventoryItems)
                {
                    if (invItem.Item.Name.Equals(itemName))
                    {
                        exists = true;
                        invItem.Quantity += itemQty;
                        break;
                    }
                }

                if (!exists)
                {
                    Item tmpItem = null;
                    foreach (Item item in Item.Items)
                    {
                        if (item.Name.Equals(itemName))
                        {
                            tmpItem = item;
                            break;
                        }
                    }

                    InventoryItem inventoryItem = new InventoryItem(tmpItem, itemQty);
                    inventoryItems.Add(inventoryItem);
                }

                selectedCells.Clear();
                detectarSelectedCellsButtons();
                loadInventoryItems();
            }
        }

        private List<InventoryItem> inventoryItems = new List<InventoryItem>();

        private const int ROWS = 2;
        private const int COLUMNS = 8;
        private const int CELL_SIZE = 77;

        private void btnDeleteInventoryItem_Click(object sender, RoutedEventArgs e)
        {
            if (selectedCells.Count!=0)
            {
                var sortedCells = selectedCells.OrderByDescending(pos => (8 * pos.row + pos.column)).ToList();

                foreach (var pos in sortedCells)
                {
                    int index = 8 * pos.row + pos.column;
                    
                    inventoryItems.RemoveAt(index);
                }

                selectedCells.Clear();
                detectarSelectedCellsButtons();
                loadInventoryItems();
            }
        }

        private void btnCombinarInventory_Click(object sender, RoutedEventArgs e)
        {
            if(cboRecipeSelect.SelectedItem is String)
            {
                int index = cboRecipeSelect.SelectedIndex;

                var itemRecipe = availableRecipes[index];

                foreach(KeyValuePair<Item,int> ingredient in itemRecipe.recipe.Ingredients)
                {
                    foreach (var pos in selectedCells)
                    {
                        int xy = 8 * pos.row + pos.column;
                        if (inventoryItems[xy].Item.Equals(ingredient.Key))
                        {
                            inventoryItems[xy].Quantity -= ingredient.Value;
                        }
                    }
                }

                int count = 0;
                for (int i = 0; i < inventoryItems.Count - count; i++)
                {
                    inventoryItems.RemoveAll(invItem => invItem.Quantity==0);
                }

                bool exists = false;
                foreach(InventoryItem invItem in inventoryItems)
                {
                    if (invItem.Item.Equals(itemRecipe.item))
                    {
                        invItem.Quantity++;
                        exists = true;
                    }
                }

                if (!exists)
                {
                    inventoryItems.Add(new InventoryItem(itemRecipe.item, 1));
                }

                selectedCells.Clear();
                addCboRecipeSelect();
                detectarSelectedCellsButtons();
                loadInventoryItems();
            }
        }

        private void gridInit()
        {
            for (int f = 0; f < ROWS; f++)
            {
                for (int c = 0; c < COLUMNS; c++)
                {
                    Image im = new Image();
                    BitmapImage i = new BitmapImage();
                    i.UriSource = new Uri("ms-appx:///Assets/item_border.png");
                    im.Source = i;
                    Grid.SetColumn(im, c);
                    Grid.SetRow(im, f);
                    gridInventory.Children.Add(im);
                }
            }
        }

        private void loadInventoryItems()
        {
            gridInventory.Children.Clear();
            gridInit();
            foreach (InventoryItem invItem in inventoryItems)
            {
                int index = inventoryItems.IndexOf(invItem);
                int row = index / COLUMNS;
                int column = index % COLUMNS;

                Grid gr = new Grid();
                gr.Tapped += grid_Tapped;
                gr.Height = CELL_SIZE;
                gr.Width = CELL_SIZE;
                Grid.SetRow(gr, row);
                Grid.SetColumn(gr, column);

                Image im = new Image();
                BitmapImage i = new BitmapImage();
                i.UriSource = new Uri(invItem.Item.Url);
                im.Source = i;
                im.Margin = new Thickness(10);

                TextBlock qty = new TextBlock();
                qty.Text = invItem.Quantity.ToString();
                qty.HorizontalAlignment = HorizontalAlignment.Right;
                qty.VerticalAlignment = VerticalAlignment.Bottom;
                qty.Margin = new Thickness(10);

                gr.Children.Add(im);
                gr.Children.Add(qty);

                gridInventory.Children.Add(gr);
            }
        }

        private List<(int row, int column)> selectedCells = new List<(int row, int column)>();

        private void grid_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (sender is Grid grid)
            {
                int row = Grid.GetRow(grid);
                int column = Grid.GetColumn(grid);
                var cellPosition = (row, column);

                if (selectedCells.Contains(cellPosition))
                {
                    selectedCells.Remove(cellPosition);
                    grid.Background = new SolidColorBrush(Colors.Transparent);
                    grid.Opacity = 1;
                }
                else
                {
                    selectedCells.Add(cellPosition);
                    grid.Background = new SolidColorBrush(Colors.LightGray);
                    grid.Opacity = 0.3;
                }

                detectarSelectedCellsButtons();
            }
        }

        public void detectarSelectedCellsButtons()
        {
            if (selectedCells.Count == 0)
            {
                btnDeleteInventoryItem.IsEnabled = false;
            }
            else
            {
                addCboRecipeSelect();
                btnDeleteInventoryItem.IsEnabled = true;
            }
        }

        List<(Item item, Recipe recipe)> availableRecipes;
        private void addCboRecipeSelect()
        {
            cboRecipeSelect.ItemsSource = null;
            availableRecipes = new List<(Item item, Recipe recipe)>();

            foreach (Item item in Item.Items)
            {
                foreach (Recipe recipe in item.Recipes)
                {
                    int ingQty = recipe.Ingredients.Count;
                    int count = 0;

                    foreach (KeyValuePair<Item, int> ingredient in recipe.Ingredients)
                    {
                        foreach (var pos in selectedCells)
                        {
                            int xy = 8 * pos.row + pos.column;
                            InventoryItem inventoryItem = inventoryItems[xy];

                            if (inventoryItem.Item.Equals(ingredient.Key) && inventoryItem.Quantity >= ingredient.Value)
                            {
                                count++;
                            }
                        }
                    }

                    if (count == ingQty)
                    {
                        availableRecipes.Add((item, recipe));
                    }
                }
            }

            List<String> strRecipes = new List<String>();
            foreach (var recipe in availableRecipes)
            {
                strRecipes.Add(recipe.item.Name + " - " + recipe.recipe.Name);
            }
            
            cboRecipeSelect.ItemsSource = strRecipes;
        }

        private void cboRecipeSelect_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(cboRecipeSelect.SelectedItem is String)
            {
                btnCombinarInventory.IsEnabled = true;
            }
            else
            {
                btnCombinarInventory.IsEnabled = false;
            }
        }

        private void lsv_ItemClick(object sender, ItemClickEventArgs e)
        {
            ListView list = sender as ListView;
            ListViewItem listItem = list.ContainerFromItem(e.ClickedItem) as ListViewItem;

            if (listItem.IsSelected)
            {
                listItem.IsSelected = false;
                list.SelectionMode = ListViewSelectionMode.None;
            }
            else
            {
                list.SelectionMode= ListViewSelectionMode.Single;
                listItem.IsSelected = true;
            }
        }
    }
}
