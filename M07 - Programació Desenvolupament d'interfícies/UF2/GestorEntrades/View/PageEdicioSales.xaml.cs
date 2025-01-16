using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Networking.BackgroundTransfer;
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
        private const int COLUMNES = 30;
        private const int CELL_SIZE = 18;

        private SolidColorBrush CELLBRUSH = new SolidColorBrush(Colors.LightGray);

        private bool painting=true;

        private Dictionary<SolidColorBrush, Zona> zones = new Dictionary<SolidColorBrush, Zona>();

        public PageEdicioSales()
        {
            this.InitializeComponent();
            zones.Add(new SolidColorBrush(Colors.Gray), new Zona(0, "Stage", "Where the fun begins", new List<Cadira>()));
            lsvZones.ItemsSource = zones;
        }

        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            Frame fr = this.Parent as Frame;
            fr.Navigate(typeof(PageSales));
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            gridInit();
        }

        private void gridInit()
        {
            grdZonesSala.Children.Clear();
            grdZonesSala.RowDefinitions.Clear();
            grdZonesSala.ColumnDefinitions.Clear();
            for (int i = 0; i < FILES; i++)
            {
                RowDefinition rowDef = new RowDefinition();
                rowDef.Height = new GridLength(CELL_SIZE);
                grdZonesSala.RowDefinitions.Add(rowDef);
            }
            for (int i = 0; i < COLUMNES; i++)
            {
                ColumnDefinition colDef = new ColumnDefinition();
                colDef.Width = new GridLength(CELL_SIZE);
                grdZonesSala.ColumnDefinitions.Add(colDef);
            }

            for(int i = 0;i < FILES; i++)
            {
                for(int j = 0; j < COLUMNES; j++)
                {
                    StackPanel sp = new StackPanel();
                    sp.Background = CELLBRUSH;
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
                if (painting)
                {
                    if(lsvZones.SelectedItem is KeyValuePair<SolidColorBrush,Zona> item)
                    {
                        SolidColorBrush scb = selected.Background as SolidColorBrush;

                        if(scb.Color.Equals(CELLBRUSH.Color))
                        {
                            selected.Background = item.Key;

                            Cadira cadira = new Cadira("", item.Value.Cadires.Count + 1, x, y);
                            zones[item.Key].Cadires.Add(cadira);
                        }
                    }
                }
                else
                {
                    selected.Background = CELLBRUSH;
                    foreach(Zona zona in zones.Values)
                    {
                        zona.Cadires.Remove(zona.Cadires.Find(cadira => cadira.X == x && cadira.Y == y));
                    }
                }
            }
        }

        private void CloseFlyout_Click(object sender, RoutedEventArgs e)
        {
            if (btnColorSelector.Flyout is Flyout flyout)
            {
                flyout.Hide();
            }
        }

        private void btnPaint_Click(object sender, RoutedEventArgs e)
        {
            painting = true;
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            painting = false;
        }

        private void clpZona_ColorChanged(ColorPicker sender, ColorChangedEventArgs args)
        {
            Color color = clpZona.Color;
            double luminance = 0.299 * color.R + 0.587 * color.G + 0.114 * color.B;
            btnColorSelector.Foreground = new SolidColorBrush(luminance > 128 ? Colors.Black : Colors.White);
            btnColorSelector.Background = new SolidColorBrush(color);
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if(txbZona.Text is String str && str.Length!=0 && clpZona.Color is Color color)
            {
                Zona zona = new Zona(zones.Count(), str, "", new List<Cadira>());
                zones.Add(new SolidColorBrush(color), zona);
                lsvZones.ItemsSource = null;
                lsvZones.ItemsSource = zones;
            }
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            if (lsvZones.SelectedItem is KeyValuePair<SolidColorBrush, Zona> selected && selected.Value.Numero != 0)
            {
                SolidColorBrush zonaColor = selected.Key;

                foreach (var child in grdZonesSala.Children)
                {
                    if (child is StackPanel sp && sp.Background is SolidColorBrush cellBrush)
                    {
                        if (cellBrush.Color == zonaColor.Color)
                        {
                            sp.Background = CELLBRUSH;
                            int x = Grid.GetRow(sp);
                            int y = Grid.GetColumn(sp);

                            selected.Value.Cadires.RemoveAll(cadira => cadira.X == x && cadira.Y == y);
                        }
                    }
                }

                zones.Remove(zonaColor);
                lsvZones.ItemsSource = null;
                lsvZones.ItemsSource = zones;
            }
        }
    }
}
