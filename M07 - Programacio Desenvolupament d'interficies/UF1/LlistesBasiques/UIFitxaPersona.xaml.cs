using LlistesBasiques.model;
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

namespace LlistesBasiques
{
    public sealed partial class UIFitxaPersona : UserControl
    {
        public UIFitxaPersona()
        {
            this.InitializeComponent();
        }

        public Persona LaPersona
        {
            get { return (Persona)GetValue(LaPersonaProperty); }
            set { SetValue(LaPersonaProperty,value); }
        }

        public static readonly DependencyProperty LaPersonaProperty =
            DependencyProperty.Register("LaPersona",typeof(Persona),typeof(UIFitxaPersona),new PropertyMetadata(null));
    }
}
