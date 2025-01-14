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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Control de usuario está documentada en https://go.microsoft.com/fwlink/?LinkId=234236

namespace Rating.View
{
    public sealed partial class UIRating : UserControl
    {
        public UIRating()
        {
            this.InitializeComponent();
            getRate();
        }

        private void getRate()
        {
            grid.Children.Clear();
            for (int i = 0; i < grid.ColumnDefinitions.Count; i++)
            {
                Image image=new Image();
                BitmapImage bitmap=new BitmapImage();

                bitmap.UriSource = i < Value ? new Uri("ms-appx:///Assets/golden_star.png") : new Uri("ms-appx:///Assets/star.png");

                image.Source = bitmap;

                image.Tapped += Image_Tapped;

                Grid.SetColumn(image, i);
                grid.Children.Add(image);
            }
        }

        private void Image_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if(sender is Image image)
            {
                int column = Grid.GetColumn(image);

                Value = Value == column + 1 ? 0 : column + 1;

                getRate();
            }
        }

        public int Value
        {
            get { return (int)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Value.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(int), typeof(UIRating), new PropertyMetadata(3));
    }
}