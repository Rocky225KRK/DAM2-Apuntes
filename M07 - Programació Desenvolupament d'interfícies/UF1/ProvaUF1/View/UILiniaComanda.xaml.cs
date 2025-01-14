using Comandos.Model;
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

// La plantilla de elemento Control de usuario está documentada en https://go.microsoft.com/fwlink/?LinkId=234236

namespace ProvaUF1.View
{
    public sealed partial class UILiniaComanda : UserControl
    {
        public UILiniaComanda()
        {
            this.InitializeComponent();
        }

        public LiniaComanda MyLiniaComanda
        {
            get { return (LiniaComanda)GetValue(MyLiniaComandaProperty); }
            set { SetValue(MyLiniaComandaProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyLiniaComanda.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MyLiniaComandaProperty =
            DependencyProperty.Register("MyLiniaComanda", typeof(LiniaComanda), typeof(UILiniaComanda), new PropertyMetadata(null));


    }
}
