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

// La plantilla de elemento Control de usuario está documentada en https://go.microsoft.com/fwlink/?LinkId=234236

namespace NBA.View
{
    public sealed partial class UITeam : UserControl
    {
        public UITeam()
        {
            this.InitializeComponent();
        }
        
        //propdp
        public Equip MyTeam
        {
            get { return (Equip)GetValue(MyTeamProperty); }
            set { SetValue(MyTeamProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyTeam.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MyTeamProperty =
            DependencyProperty.Register("MyTeam", typeof(Equip), typeof(UITeam), new PropertyMetadata(null));


    }
}
