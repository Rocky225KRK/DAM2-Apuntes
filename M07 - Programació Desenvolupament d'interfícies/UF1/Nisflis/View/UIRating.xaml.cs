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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Control de usuario está documentada en https://go.microsoft.com/fwlink/?LinkId=234236

namespace Nisflis.View
{
    public sealed partial class UIRating : UserControl
    {
        public UIRating()
        {
            this.InitializeComponent();
            
            for (int i = 0; i < grid.ColumnDefinitions.Count; i++)
            {
                if (i < Value)
                {
                    TextBlock star = new TextBlock();

                    star.Text = "&#xE735;";
                    star.FontSize = 40;
                    star.FontFamily = new FontFamily("Segoe MDL2 Assets");

                    Grid.SetColumn(star, i);
                    grid.Children.Add(star);
                }
            }
        }

        public int Value
        {
            get { return (int)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Value.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(int), typeof(UIRating), new PropertyMetadata(0));
    }
}
