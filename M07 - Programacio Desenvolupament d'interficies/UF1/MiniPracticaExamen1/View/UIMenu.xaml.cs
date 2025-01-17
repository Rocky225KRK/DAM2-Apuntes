using MiniPracticaExamen1.Model;
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

namespace MiniPracticaExamen1.View
{
    public sealed partial class UIMenu : UserControl
    {
        public UIMenu()
        {
            this.InitializeComponent();
        }

        public LiniaMenu MyMenu
        {
            get { return (LiniaMenu)GetValue(MyMenuProperty); }
            set { SetValue(MyMenuProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyMenu.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MyMenuProperty =
            DependencyProperty.Register("MyMenu", typeof(LiniaMenu), typeof(UIMenu), new PropertyMetadata(null));


    }
}
