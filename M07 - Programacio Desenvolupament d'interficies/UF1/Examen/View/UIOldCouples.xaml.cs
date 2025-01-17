using System;
using System.Collections.Generic;
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
    public sealed partial class UIOldCouples : UserControl
    {
        public UIOldCouples()
        {
            this.InitializeComponent();
        }
        public Person MyOldCouple
        {
            get { return (Person)GetValue(MyOldCoupleProperty); }
            set { SetValue(MyOldCoupleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyOldCouple.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MyOldCoupleProperty =
            DependencyProperty.Register("MyOldCouple", typeof(Person), typeof(UIOldCouples), new PropertyMetadata(null));

    }
}
