using Classes.model;
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

namespace Classes
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
            Persona paco = new Persona("Paco", 23, "Jones");
            Debug.WriteLine(paco);

            List<Persona> list = new List<Persona>();
            list.Add(paco);
            list.Add(paco);
            list.Add(paco);
            list.Add(paco);

            int index=list.IndexOf(paco);   //Saldrá 0 porque encuentra el 1o
            Debug.WriteLine(index);

            int index2 = list.IndexOf(new Persona("Paco", 23, "Jones")); 
            Debug.WriteLine(index2);

            //-----------------------------------
            Dictionary<String, Persona> mapa = new Dictionary<String, Persona>();
            mapa["Paco"] = paco;
            Persona p = mapa["Paco"];
            if (mapa.ContainsKey("Enriqueta"))
            {
                Persona p2 = mapa["Enriqueta"];
            }
        }
    }
}
