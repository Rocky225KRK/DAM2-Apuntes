﻿#pragma checksum "C:\Users\Usuario\Desktop\Clase\Projectes DAM2\M07 - Programació Desenvolupament d'interfícies\UF2\GestorEntrades\View\PageEdicioSales.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "34F9B123D0057762D5E4857CACA62CDE97BB8BCD55061BBA477A8B0D0C2DE3B3"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GestorEntrades
{
    partial class PageEdicioSales : 
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
            case 1: // View\PageEdicioSales.xaml line 1
                {
                    global::Windows.UI.Xaml.Controls.Page element1 = (global::Windows.UI.Xaml.Controls.Page)(target);
                    ((global::Windows.UI.Xaml.Controls.Page)element1).Loaded += this.Page_Loaded;
                }
                break;
            case 2: // View\PageEdicioSales.xaml line 103
                {
                    this.lsvZones = (global::Windows.UI.Xaml.Controls.ListView)(target);
                }
                break;
            case 3: // View\PageEdicioSales.xaml line 117
                {
                    this.btnAdd = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnAdd).Click += this.btnAdd_Click;
                }
                break;
            case 4: // View\PageEdicioSales.xaml line 118
                {
                    this.btnDel = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnDel).Click += this.btnDel_Click;
                }
                break;
            case 6: // View\PageEdicioSales.xaml line 72
                {
                    this.txbZona = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 7: // View\PageEdicioSales.xaml line 73
                {
                    this.btnColorSelector = (global::Windows.UI.Xaml.Controls.Button)(target);
                }
                break;
            case 8: // View\PageEdicioSales.xaml line 85
                {
                    this.clpZona = (global::Windows.UI.Xaml.Controls.ColorPicker)(target);
                    ((global::Windows.UI.Xaml.Controls.ColorPicker)this.clpZona).ColorChanged += this.clpZona_ColorChanged;
                }
                break;
            case 9: // View\PageEdicioSales.xaml line 87
                {
                    global::Windows.UI.Xaml.Controls.Button element9 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element9).Click += this.CloseFlyout_Click;
                }
                break;
            case 10: // View\PageEdicioSales.xaml line 54
                {
                    this.grdZonesSala = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 11: // View\PageEdicioSales.xaml line 61
                {
                    this.btnPaint = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnPaint).Click += this.btnPaint_Click;
                }
                break;
            case 12: // View\PageEdicioSales.xaml line 62
                {
                    this.btnRemove = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnRemove).Click += this.btnRemove_Click;
                }
                break;
            case 13: // View\PageEdicioSales.xaml line 45
                {
                    this.txbNomSala = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 14: // View\PageEdicioSales.xaml line 48
                {
                    this.txbMunicipiSala = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 15: // View\PageEdicioSales.xaml line 51
                {
                    this.txbAdrecaSala = (global::Windows.UI.Xaml.Controls.TextBox)(target);
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

