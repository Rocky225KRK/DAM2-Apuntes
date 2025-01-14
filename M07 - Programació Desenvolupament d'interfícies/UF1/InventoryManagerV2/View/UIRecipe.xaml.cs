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
    public sealed partial class UIRecipe : UserControl
    {
        public UIRecipe()
        {
            this.InitializeComponent();
        }

        public Recipe MyRecipe
        {
            get { return (Recipe)GetValue(MyRecipeProperty); }
            set { SetValue(MyRecipeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyRecipe.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MyRecipeProperty =
            DependencyProperty.Register("MyRecipe", typeof(Recipe), typeof(UIRecipe), new PropertyMetadata(null));


    }
}
