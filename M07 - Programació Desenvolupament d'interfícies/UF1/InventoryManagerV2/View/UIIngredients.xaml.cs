using InventoryManager.model;
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

namespace InventoryManagerV2.View
{
    public sealed partial class UIIngredients : UserControl
    {
        public UIIngredients()
        {
            this.InitializeComponent();
        }


        public KeyValuePair<Item,int> MyIngredient
        {
            get { return (KeyValuePair<Item,int>)GetValue(MyIngredientProperty); }
            set { SetValue(MyIngredientProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyIngredient.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MyIngredientProperty =
            DependencyProperty.Register("MyIngredient", typeof(KeyValuePair<Item,int>), typeof(UIIngredients), new PropertyMetadata(null));


    }
}
