using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
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

namespace FormularioPrueba
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Page_Loading(FrameworkElement sender, object args)
        {
            List<int> dies = new List<int>();
            for(int dia = 1; dia < 32; dia++)
            {
                dies.Add(dia);
            }
            cboDia.ItemsSource = dies;

            //*****************************************

            List<String> mesos = new List<String>();
            DateTime dateTime = new DateTime(1900,01,01);
            for (int i = 0; i < 12; i++)
            {
                mesos.Add(dateTime.ToString("MMMM"));
                dateTime=dateTime.AddMonths(1);
            }
            cboMes.ItemsSource = mesos;

            //*****************************************

            List<int> anys = new List<int>();
            for (int i = 0;i<=124;i++)
            {
                anys.Add(dateTime.Year);
                dateTime = dateTime.AddYears(1);
            }
            cboAny.ItemsSource = anys;
        }

        private const string ICON_OK = "";
        private const string ICON_ERR = "";
        private void txbAlcada_TextChanged(object sender, TextChangedEventArgs e)
        { 
            float alcada;
            bool ok = float.TryParse(txbAlcada.Text, out alcada);
            txtAlcadaIcon.Text=ok? ICON_OK:ICON_ERR;
            txtAlcadaIcon.Foreground = new SolidColorBrush(ok?Colors.Green:Colors.Red);
            txtAlcadaErrMsg.Visibility = ok ? Visibility.Collapsed : Visibility.Visible;
        }

        [DllImport("user32.dll", SetLastError = true)]
        static extern int MapVirtualKey(int uCode, uint uMapType);
        private void txbAlcada_PreviewKeyDown(object sender, KeyRoutedEventArgs e)
        {
            bool shiftApretat=Window.Current.CoreWindow.GetKeyState(Windows.System.VirtualKey.Shift).HasFlag(Windows.UI.Core.CoreVirtualKeyStates.Down);

            char c = (char)MapVirtualKey((int)e.Key, (uint)2);
            Debug.WriteLine(">"+c);
            e.Handled=!(
                (c==','&&!txbAlcada.Text.Contains(','))||
                e.Key==Windows.System.VirtualKey.Back||
                e.Key==Windows.System.VirtualKey.Tab||
                (Char.IsNumber(c)&&!shiftApretat)
                );
        }

        private void txbDataNaix_PreviewKeyDown(object sender, KeyRoutedEventArgs e)
        {
            bool shiftApretat = e.Key != Windows.System.VirtualKey.Number7 && Window.Current.CoreWindow.GetKeyState(Windows.System.VirtualKey.Shift).HasFlag(Windows.UI.Core.CoreVirtualKeyStates.Down);

            int count= txbDataNaix.Text.Count(a=>a=='/');

            char c = (char)MapVirtualKey((int)e.Key, (uint)2);
            Debug.WriteLine(">" + c);
            e.Handled = !(
                (c == '/' && count<2) ||
                e.Key == Windows.System.VirtualKey.Back ||
                e.Key == Windows.System.VirtualKey.Tab ||
                (Char.IsNumber(c) && !shiftApretat)
                );
        }

        private void txbDataNaix_LostFocus(object sender, RoutedEventArgs e)
        {
            DateTime dataNaix;
            CultureInfo culture= CultureInfo.GetCultureInfo("es-ES");
            bool ok = DateTime.TryParseExact(txbDataNaix.Text,"dd/MM/yyyy",culture,DateTimeStyles.None,out dataNaix);
            txtDataNaixIcon.Text = ok ? ICON_OK : ICON_ERR;
            txtDataNaixIcon.Foreground = new SolidColorBrush(ok ? Colors.Green : Colors.Red);
            txtDataNaixErrMsg.Visibility = ok? Visibility.Collapsed:Visibility.Visible;

            if (ok)
            {
                cboDia.SelectedValue = dataNaix.Day;
                cboMes.SelectedValue = dataNaix.ToString("MMMM");
                cboAny.SelectedValue = dataNaix.Year;
            }
        }
    }
}
