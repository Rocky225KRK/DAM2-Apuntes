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

namespace InventoryManager.View
{
    public sealed partial class UIItem : UserControl
    {
        public UIItem()
        {
            this.InitializeComponent();
        }


        public Item MyItem
        {
            get { return (Item)GetValue(MyItemProperty); }
            set { SetValue(MyItemProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyItem.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MyItemProperty =
            DependencyProperty.Register("MyItem", typeof(Item), typeof(UIItem), new PropertyMetadata(null));
    }
}
