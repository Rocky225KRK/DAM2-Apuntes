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

namespace GestorEntrades
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class PageEvents : Page
    {
        public PageEvents()
        {
            this.InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Events = Event.GetEvents();
        }



        public List<Event> Events
        {
            get { return (List<Event>)GetValue(EventsProperty); }
            set { SetValue(EventsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Events.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EventsProperty =
            DependencyProperty.Register("Events", typeof(List<Event>), typeof(PageEvents), new PropertyMetadata(new List<Event>()));

        private void btnAfegir_Click(object sender, RoutedEventArgs e)
        {
            Frame fr = this.Parent as Frame;
            fr.Navigate(typeof(PageEdicioEvents));
        }

        private void btnEsborrar_Click(object sender, RoutedEventArgs e)
        {
            if (dgrEvents.SelectedItem is Event selected)
            {
                Event.GetEvents().Remove(selected);
                Events = null;
                Events = Event.GetEvents();
            }
        }
    }
}
