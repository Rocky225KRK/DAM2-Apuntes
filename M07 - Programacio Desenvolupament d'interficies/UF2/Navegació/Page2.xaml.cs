using System;
using System.Collections.Generic;
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

namespace Navegació
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class Page2 : Page
    {
        //private Dictionary<string, string> valors;
        private Persona p;

        public Page2()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(this.Frame.CanGoBack)
                this.Frame.GoBack();
            
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //valors = e.Parameter as Dictionary<string, string>;
            //txbNom.Text = valors["nom"];
            //txbCognom.Text = valors["cognom"];
            if (e.Parameter != null)
            {
                p = e.Parameter as Persona;
                txbNom.Text = p.Nom;
                txbCognom.Text = p.Cognom;
            }
        }

        private void txbNom_TextChanged(object sender, TextChangedEventArgs e)
        {
            //valors["nom"] = txbNom.Text;
            p.Nom = txbNom.Text;
        }

        private void txbCognom_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
