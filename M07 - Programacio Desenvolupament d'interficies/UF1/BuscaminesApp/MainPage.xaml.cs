using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace BuscaminesApp
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private readonly int CELL_SIZE = 32;
        private int FILES = 16;
        private int COLUMNES = 16;

        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            for (int f = 0; f < FILES; f++)
            {
                RowDefinition rowDef = new RowDefinition();
                rowDef.Height = GridLength.Auto;
                grid.RowDefinitions.Add(rowDef);
            }
            for (int c = 0; c < COLUMNES; c++)
            {
                ColumnDefinition colDef = new ColumnDefinition();
                colDef.Width = new GridLength(CELL_SIZE);
                grid.ColumnDefinitions.Add(colDef);
            }

            int mineNumber = 0;

            for (int f = 0; f < FILES; f++)
            {
                for (int c = 0; c < COLUMNES; c++)
                {
                    TextBlock b = new TextBlock();
                    Grid.SetColumn(b, c);
                    Grid.SetRow(b, f);
                    b.FontFamily = new FontFamily("mine-sweeper");
                    grid.Children.Add(b);
                    mineNumber = (mineNumber + 1)%10;
                    b.Text = getTextFromNumber(mineNumber);
                    b.Foreground = getColorFromNumber(mineNumber);
                    b.FontSize = 15;
                    b.VerticalAlignment = VerticalAlignment.Center;
                    b.HorizontalAlignment = HorizontalAlignment.Center;
                    b.Padding = new Thickness(0);
                }
            }
        }

        private string getTextFromNumber(int mineNumber)
        {
            switch (mineNumber)
            {
                case 0: return "";
                case 9:return "*";
                default:return mineNumber + "";

            }
        }

        private Brush getColorFromNumber(int mineNumber)
        {
            Color c;
            switch (mineNumber)
            {
                case 1: c = Colors.Blue; break;
                case 2: c = Colors.Green; break;
                case 9: c = Colors.White; break;
                default: c = Colors.Red; break;
            }
            return new SolidColorBrush(c);
        }
    }
}
