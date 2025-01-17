using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Tilinder.Model;
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

namespace Examen.View
{
    public sealed partial class UIPerson : UserControl
    {
        public UIPerson()
        {
            this.InitializeComponent();
        }

        public Person MyPerson
        {
            get { return (Person)GetValue(MyPersonProperty); }
            set { SetValue(MyPersonProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyPerson.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MyPersonProperty =
            DependencyProperty.Register("MyPerson", typeof(Person), typeof(UIPerson), new PropertyMetadata(null));

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            Person.GetPeople().Remove(MyPerson);
        }

        private void uc_Loaded(object sender, RoutedEventArgs e)
        {
            if (MyPerson != null)
            {
                lsvOldCouples.ItemsSource = MyPerson.OldCouples;
            }
            
        }
    }
}
