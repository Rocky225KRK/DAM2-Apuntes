using Comandos.Model;
using ProvaUF1.View;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography;
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

namespace ProvaUF1.View
{
    public sealed partial class UICboProd : UserControl
    {
        public UICboProd()
        {
            this.InitializeComponent();
        }

        public Producte MyProducte
        {
            get { return (Producte)GetValue(MyProducteProperty); }
            set { SetValue(MyProducteProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProducte.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MyProducteProperty =
            DependencyProperty.Register("MyProducte", typeof(Producte), typeof(UICboProd), new PropertyMetadata(null));


    }
}
