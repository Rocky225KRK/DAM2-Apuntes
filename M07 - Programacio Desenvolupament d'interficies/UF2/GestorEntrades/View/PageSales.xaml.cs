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

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace GestorEntrades
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class PageSales : Page
    {
        List<Sala> sales = new List<Sala>();
        public PageSales()
        {
            this.InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Sales = Sala.GetSales();
        }

        public List<Sala> Sales
        {
            get { return (List<Sala>)GetValue(SalesProperty); }
            set { SetValue(SalesProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Sales.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SalesProperty =
            DependencyProperty.Register("Sales", typeof(List<Sala>), typeof(PageSales), new PropertyMetadata(null));

        private void btnFiltrar_Click(object sender, RoutedEventArgs e)
        {
            sales = Sala.GetSales().FindAll(sala => sala.Nom.Contains(txbFiltre.Text));
            dgrSales.ItemsSource = sales;
        }

        private void btnAfegir_Click(object sender, RoutedEventArgs e)
        {
            //Frame fr = Frame.Content as Frame;
            Frame fr=this.Parent as Frame;
            fr.Navigate(typeof(PageEdicioSales));
        }

        private void btnEsborrar_Click(object sender, RoutedEventArgs e)
        {
            if(dgrSales.SelectedItem is Sala selected)
            {
                Sala.GetSales().Remove(selected);
                dgrSales.ItemsSource = null;
                dgrSales.ItemsSource = Sala.GetSales();
                txbFiltre.Text = "";
            }
        }
    }
}
