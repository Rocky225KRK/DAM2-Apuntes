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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace Nisflis
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private Library library = new Library();
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            lsvPosters.ItemsSource = library.GetMovies;
        }

        private void lsvPosters_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(lsvPosters.SelectedItem is Movie selected)
            {
                ImageBrush ib = new ImageBrush();
                BitmapImage bi = new BitmapImage();
                bi.UriSource = new Uri(selected.Coverimg);
                ib.ImageSource = bi;

                spMovie.Background = ib;
                txbTitle.Text = selected.Title;
                rating(selected.Rating);
                txbDesc.Text = selected.Description;
            } 
        }

        private void rating(int value)
        {
            spRating.Children.Clear();
            for (int i = 0; i < 5; i++)
            {
                TextBlock star = new TextBlock();

                star.Text = i < value ? "\uE735" : "\uE734";
                star.FontSize = 40;
                star.FontFamily = new FontFamily("Segoe MDL2 Assets");

                spRating.Children.Add(star);
            }
        }
    }
}
