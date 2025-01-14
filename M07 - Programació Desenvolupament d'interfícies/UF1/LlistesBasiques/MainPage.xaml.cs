using LlistesBasiques.model;
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

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace LlistesBasiques
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            List<String> list = new List<String>();
            list.Add("Paco");
            list.Add("Pepe");
            list.Add("MARIA");
            list.Add("Cristina");

            List<Persona> personas = new List<Persona>();
            personas.Add(new Persona(12, "Paco", 23));
            personas.Add(new Persona(4, "Joan", 3));
            personas.Add(new Persona(5, "Maria", 4));
            personas.Add(new Persona(21, "Marta", 52));



            lsvNoms.ItemsSource = personas;
            lsvNomsHoritzontal.ItemsSource = personas;
            grdNoms.ItemsSource = personas;
            //lsvNoms.DisplayMemberPath = "FullData";
        }
    }
}
