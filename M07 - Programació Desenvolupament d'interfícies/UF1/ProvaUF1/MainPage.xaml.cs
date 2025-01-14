using Comandos.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
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

namespace ProvaUF1
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private Comanda com = new Comanda();
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            lsvComanda.ItemsSource = com.Linies;

            List<Producte> listCboProd = new List<Producte>();
            foreach(Producte producte in Producte.getProductes())
            {
                listCboProd.Add(producte);
            }
            cboProd.ItemsSource = listCboProd;

            foreach(String unitat in Enum.GetNames(typeof(Unitat)))
            {
                RadioButton radioButton = new RadioButton();
                radioButton.Foreground = new SolidColorBrush(Colors.Black);
                radioButton.Content = unitat.ToUpper();
                radioButton.GroupName = "Unitat";
                radioButton.IsEnabled = false;
                spRb.Children.Add(radioButton);
            }

            btnAdd.IsEnabled = false;
            btnSub.IsEnabled = false;
            btnDel.IsEnabled = false;
        }

        private void txbQuant_TextChanged(object sender, TextChangedEventArgs e)
        {
            int qty;
            bool ok = int.TryParse(txbQuant.Text,out qty);
            txbQuant.Background = new SolidColorBrush(ok ? Colors.Transparent : Colors.Red);
            txbError.Visibility = ok ? Visibility.Collapsed : Visibility.Visible;
            btnAdd.IsEnabled = ok;
            btnSub.IsEnabled = ok;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (cboProd.SelectedItem is Producte selected)
            {
                int qty=int.Parse(txbQuant.Text);

                int index = -1;
                foreach(LiniaComanda liniaComanda in com.Linies)
                {
                    if (liniaComanda.Producte.Equals(selected))
                    {
                        index = com.Linies.IndexOf(liniaComanda);
                        break;
                    }
                }

                if (index == -1)
                {
                    com.Linies.Add(new LiniaComanda(com.Linies.Count, qty, selected));
                }
                else
                {
                    if (com.Linies[index].Quantitat + qty > 0) 
                    {
                        com.Linies[index].Quantitat += qty;
                    }
                    else
                    {
                        com.Linies[index].Quantitat = int.MaxValue;
                    }
                }
                txtTotalComanda.Text = com.Total.ToString();
            }
        }

        private void btnSub_Click(object sender, RoutedEventArgs e)
        {
            if (cboProd.SelectedItem is Producte selected)
            {
                int qty = int.Parse(txbQuant.Text);

                int index = -1;
                foreach (LiniaComanda liniaComanda in com.Linies)
                {
                    if (liniaComanda.Producte.Equals(selected))
                    {
                        index = com.Linies.IndexOf(liniaComanda);
                        break;
                    }
                }

                if (index != -1)
                {
                    com.Linies[index].Quantitat -= qty;
                    if (com.Linies[index].Quantitat <= 0)
                    {
                        com.Linies.RemoveAt(index);
                    }
                }
                txtTotalComanda.Text = com.Total.ToString();
            }
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            if(lsvComanda.SelectedItem is LiniaComanda selected)
            {
                com.Linies.Remove(selected);
                txtTotalComanda.Text = com.Total.ToString();
            }
        }

        private void cboProd_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(cboProd.SelectedItem is Producte selected)
            {
                foreach (RadioButton rb in spRb.Children)
                {
                    if (rb.Content.Equals(Enum.GetName(typeof(Unitat), selected.Unitat)))
                    {
                        rb.IsEnabled = true;
                        rb.IsChecked = true;
                    }
                    else
                    {
                        rb.IsEnabled = false;
                        rb.IsChecked = false;
                    }
                }
            }
            else
            {
                foreach (RadioButton rb in spRb.Children)
                {
                    rb.IsEnabled = false;
                    rb.IsChecked = false;
                }
            }
        }

        private void lsvComanda_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(lsvComanda.SelectedItem is LiniaComanda)
            {
                btnDel.IsEnabled = true;
            }
            else
            {
                btnDel.IsEnabled = false;
            }
        }
    }
}
