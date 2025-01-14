using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Activation;
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

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace GestorEntrades
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class PageEdicioSales : Page
    {
        private const int FILES = 20;
        private const int COLUMNES = 50;
        private const int CELL_SIZE = 20;

        private Dictionary<Color, Zona> zones = new Dictionary<Color, Zona>();

        public PageEdicioSales()
        {
            this.InitializeComponent();
            zones = new Dictionary<Color, Zona>();
            zones.Add(Colors.Gray, new Zona(0, "Stage", "Where all starts", new List<Cadira>()));
            lsvZones.ItemsSource = zones;
        }

        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            Frame fr = this.Parent as Frame;
            fr.Navigate(typeof(PageSales));
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            gridInit(FILES,COLUMNES);
            loadCbo();
        }

        private void loadCbo()
        {
            List<String> fila = new List<String>();
            List<String> col = new List<String>();
            fila.Add("Files");
            col.Add("Columnes");
            for (int i = 1; i <= 64; i++)
            {
                fila.Add(i + "");
                col.Add(i + "");
            }
            cboFila.ItemsSource = fila;
            cboCol.ItemsSource = col;
            cboFila.SelectedIndex = 0;
            cboCol.SelectedIndex = 0;
        }

        private void gridInit(int files,int columnes)
        {
            for (int i = 0; i < files; i++)
            {
                RowDefinition rowDef = new RowDefinition();
                rowDef.Height = new GridLength(CELL_SIZE);
                grdZonesSala.RowDefinitions.Add(rowDef);
            }
            for (int i = 0; i < columnes; i++)
            {
                ColumnDefinition colDef = new ColumnDefinition();
                colDef.Width = new GridLength(CELL_SIZE);
                grdZonesSala.ColumnDefinitions.Add(colDef);
            }

            for(int i = 0;i < files; i++)
            {
                for(int j = 0; j < columnes; j++)
                {
                    StackPanel sp = new StackPanel();
                    sp.Background = new SolidColorBrush(Colors.Gray);
                    sp.Tapped += Sp_Tapped;
                    Grid.SetRow(sp, i);
                    Grid.SetColumn(sp, j);
                    grdZonesSala.Children.Add(sp);
                }
            }
        }

        private void Sp_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if(sender is StackPanel selected)
            {
                int x = Grid.GetRow(selected);
                int y = Grid.GetColumn(selected);

                SolidColorBrush scb = selected.Background as SolidColorBrush;

                //Rectificar lo de aqui abajo pa k no se añada a si mismo siempre
                zones[scb.Color].Cadires.Add(new Cadira(zones[scb.Color].Nom, zones[scb.Color].Cadires.Count, x, y));
            }
        }

        private void cboFilaColSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cboFila.SelectedIndex <= 0 && cboCol.SelectedIndex <= 0)
            {
                int files = cboFila.SelectedIndex;
                int columnes = cboCol.SelectedIndex;
                grdZonesSala.Children.Clear();
                gridInit(files, columnes);
            }
        }
    }
}
