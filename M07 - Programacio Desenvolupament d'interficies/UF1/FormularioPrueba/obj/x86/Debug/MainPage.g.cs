﻿#pragma checksum "C:\Users\Usuario\source\repos\FormularioPrueba\MainPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "AF4E37C7B4E0DBEDF13779128C3270EBF39EF04B317949CA91E1A55085268CB5"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FormularioPrueba
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
                    ((global::Windows.UI.Xaml.Controls.Page)element1).Loading += this.Page_Loading;
                }
                break;
            case 2: // MainPage.xaml line 26
                {
                    this.txbAlcada = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                    ((global::Windows.UI.Xaml.Controls.TextBox)this.txbAlcada).TextChanged += this.txbAlcada_TextChanged;
                    ((global::Windows.UI.Xaml.Controls.TextBox)this.txbAlcada).PreviewKeyDown += this.txbAlcada_PreviewKeyDown;
                }
                break;
            case 3: // MainPage.xaml line 27
                {
                    this.txtAlcadaIcon = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 4: // MainPage.xaml line 28
                {
                    this.txtAlcadaErrMsg = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 5: // MainPage.xaml line 31
                {
                    this.txbDataNaix = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                    ((global::Windows.UI.Xaml.Controls.TextBox)this.txbDataNaix).LostFocus += this.txbDataNaix_LostFocus;
                    ((global::Windows.UI.Xaml.Controls.TextBox)this.txbDataNaix).PreviewKeyDown += this.txbDataNaix_PreviewKeyDown;
                }
                break;
            case 6: // MainPage.xaml line 32
                {
                    this.txtDataNaixIcon = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 7: // MainPage.xaml line 33
                {
                    this.txtDataNaixErrMsg = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 8: // MainPage.xaml line 41
                {
                    this.cboDia = (global::Windows.UI.Xaml.Controls.ComboBox)(target);
                }
                break;
            case 9: // MainPage.xaml line 42
                {
                    this.cboMes = (global::Windows.UI.Xaml.Controls.ComboBox)(target);
                }
                break;
            case 10: // MainPage.xaml line 43
                {
                    this.cboAny = (global::Windows.UI.Xaml.Controls.ComboBox)(target);
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

