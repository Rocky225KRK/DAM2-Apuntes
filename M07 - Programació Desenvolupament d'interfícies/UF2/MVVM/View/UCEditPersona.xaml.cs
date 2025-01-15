using MVVM.Model;
using MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

// La plantilla de elemento Control de usuario está documentada en https://go.microsoft.com/fwlink/?LinkId=234236

namespace MVVM.View
{
    public sealed partial class UCEditPersona : UserControl,INotifyPropertyChanged
    {
        public PersonaViewModel PersonaEnEdicio { get; private set; }

        public UCEditPersona()
        {
            this.InitializeComponent();
        }

        public PersonaViewModel MyPersona
        {
            get { return (PersonaViewModel)GetValue(MyPersonaProperty); }
            set { SetValue(MyPersonaProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MyPersonaProperty =
            DependencyProperty.Register("MyPersona", typeof(PersonaViewModel), typeof(UCEditPersona), new PropertyMetadata(null,OnPersonaChangedCallbackStatic));

        public event PropertyChangedEventHandler PropertyChanged;

        private static void OnPersonaChangedCallbackStatic(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UCEditPersona u = (UCEditPersona)d;
            u.OnPersonaChangedCallback(d, e);
        }

        private void OnPersonaChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if(PersonaEnEdicio== null||MyPersona.Id!=PersonaEnEdicio.Id)
            {
                PersonaEnEdicio=new PersonaViewModel(MyPersona);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MyPersona.Nom = PersonaEnEdicio.Nom;
            MyPersona.Edat = PersonaEnEdicio.Edat;
            MyPersona.IsActiu = PersonaEnEdicio.IsActiu;
            MyPersona.Sexe = PersonaEnEdicio.Sexe;
        }
    }
}
