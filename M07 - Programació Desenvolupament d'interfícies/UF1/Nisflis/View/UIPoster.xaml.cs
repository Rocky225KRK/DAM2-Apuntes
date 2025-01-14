using MovieRental.Model;
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

namespace Nisflis.View
{
    public sealed partial class UIPoster : UserControl
    {
        public UIPoster()
        {
            this.InitializeComponent();
        }



        public Movie MyMovie
        {
            get { return (Movie)GetValue(MyMovieProperty); }
            set { SetValue(MyMovieProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyMovie.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MyMovieProperty =
            DependencyProperty.Register("MyMovie", typeof(Movie), typeof(UIPoster), new PropertyMetadata(null));


    }
}
