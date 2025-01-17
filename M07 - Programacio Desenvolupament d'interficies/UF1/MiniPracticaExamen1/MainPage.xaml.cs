using MiniPracticaExamen1.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace MiniPracticaExamen1
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private Menu menu = new Menu();

        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            lsvMenu.ItemsSource = menu.LMenu;
            cboComida.ItemsSource = Comida.GetComidas();

            btnAdd.IsEnabled = false;
            btnDel.IsEnabled = false;
        }

        private void txbQty_TextChanged(object sender, TextChangedEventArgs e)
        {
            int qty;
            bool ok = int.TryParse(txbQty.Text, out qty);

            btnAdd.IsEnabled = ok;
            txbQty.Background = new SolidColorBrush(ok ? Colors.Transparent : Colors.Red);
        }

        private void lsvMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(lsvMenu.SelectedItem is LiniaMenu)
            {
                btnDel.IsEnabled = true;
            }
            else
            {
                btnDel.IsEnabled = false;
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if(cboComida.SelectedItem is Comida selected)
            {
                int index = -1;
                foreach(LiniaMenu liniaMenu in menu.LMenu)
                {
                    if (liniaMenu.Comida.Equals(selected))
                    {
                        index = menu.LMenu.IndexOf(liniaMenu);
                        Debug.WriteLine("Estoy aqui");
                        break;
                    }
                }

                int qty = int.Parse(txbQty.Text);

                if (index == -1)
                {
                    Debug.WriteLine("BB");
                    menu.LMenu.Add(new LiniaMenu(selected, qty));
                }
                else
                {
                    Debug.WriteLine("AA");
                    menu.LMenu[index].Qty += qty;
                    if (menu.LMenu[index].Qty < 0)
                    {
                        menu.LMenu[index].Qty = int.MaxValue;
                    }
                }
            }
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            if(lsvMenu.SelectedItem is LiniaMenu selected)
            {
                menu.LMenu.Remove(selected);
            }
        }
    }
}
