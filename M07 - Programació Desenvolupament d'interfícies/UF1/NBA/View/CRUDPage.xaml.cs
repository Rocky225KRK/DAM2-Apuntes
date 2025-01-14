using GestioDequips.Model;
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

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace NBA.View
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class CRUDPage : Page
    {
        public CRUDPage()
        {
            this.InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            lsvTeams.ItemsSource=Equip.getLlistaEquips();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Equip equipSeleccionat = (Equip)lsvTeams.SelectedItem;

            if (equipSeleccionat!=null)
            {
                equipSeleccionat.Nom=txbTeamName.Text;
            }
            else
            {
                Equip equip = new Equip(12, txbTeamName.Text, "", "", Conferencia.WEST, DateTime.Now);
                Equip.getLlistaEquips().Add(equip);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Equip equipSeleccionat= (Equip)lsvTeams.SelectedItem;

            if (equipSeleccionat != null)
            {
                Equip.getLlistaEquips().Remove(equipSeleccionat);
            }
        }

        private void lsvTeams_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Equip equipSeleccionat=(Equip)lsvTeams.SelectedItem;
            if (equipSeleccionat != null)
            {
                txbTeamName.Text = equipSeleccionat.Nom;
            }
        }
    }
}
