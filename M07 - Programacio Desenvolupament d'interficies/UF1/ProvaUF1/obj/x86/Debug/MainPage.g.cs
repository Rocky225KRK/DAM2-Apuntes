﻿#pragma checksum "C:\Users\Usuario\source\repos\ProvaUF1\MainPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "4935D6F9EB7A939CB5DC7F394D6EBD9E0D7E2E9B6F92A6CBE1E138C4E002F797"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProvaUF1
{
    partial class MainPage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 0.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1: // MainPage.xaml line 1
                {
                    global::Windows.UI.Xaml.Controls.Page element1 = (global::Windows.UI.Xaml.Controls.Page)(target);
                    ((global::Windows.UI.Xaml.Controls.Page)element1).Loaded += this.Page_Loaded;
                }
                break;
            case 2: // MainPage.xaml line 13
                {
                    this.grid = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 3: // MainPage.xaml line 20
                {
                    this.gridSelProd = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 4: // MainPage.xaml line 68
                {
                    this.lsvComanda = (global::Windows.UI.Xaml.Controls.ListView)(target);
                    ((global::Windows.UI.Xaml.Controls.ListView)this.lsvComanda).SelectionChanged += this.lsvComanda_SelectionChanged;
                }
                break;
            case 5: // MainPage.xaml line 83
                {
                    this.txtTotalComanda = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 7: // MainPage.xaml line 57
                {
                    this.btnAdd = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnAdd).Click += this.btnAdd_Click;
                }
                break;
            case 8: // MainPage.xaml line 58
                {
                    this.btnSub = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnSub).Click += this.btnSub_Click;
                }
                break;
            case 9: // MainPage.xaml line 59
                {
                    this.btnDel = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnDel).Click += this.btnDel_Click;
                }
                break;
            case 10: // MainPage.xaml line 33
                {
                    this.cboProd = (global::Windows.UI.Xaml.Controls.ComboBox)(target);
                    ((global::Windows.UI.Xaml.Controls.ComboBox)this.cboProd).SelectionChanged += this.cboProd_SelectionChanged;
                }
                break;
            case 11: // MainPage.xaml line 42
                {
                    this.txbQuant = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                    ((global::Windows.UI.Xaml.Controls.TextBox)this.txbQuant).TextChanged += this.txbQuant_TextChanged;
                }
                break;
            case 12: // MainPage.xaml line 45
                {
                    this.spRb = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                }
                break;
            case 13: // MainPage.xaml line 47
                {
                    this.txbError = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 0.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

