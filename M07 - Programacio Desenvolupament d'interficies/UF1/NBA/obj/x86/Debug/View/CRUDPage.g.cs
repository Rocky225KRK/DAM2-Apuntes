﻿#pragma checksum "C:\Users\Usuario\source\repos\NBA\View\CRUDPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "8515DE3CAD5017E079B6177947857560FFAA96895AEC7B18E48FCE061F0F06A0"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NBA.View
{
    partial class CRUDPage : 
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
            case 1: // View\CRUDPage.xaml line 1
                {
                    global::Windows.UI.Xaml.Controls.Page element1 = (global::Windows.UI.Xaml.Controls.Page)(target);
                    ((global::Windows.UI.Xaml.Controls.Page)element1).Loaded += this.Page_Loaded;
                }
                break;
            case 2: // View\CRUDPage.xaml line 24
                {
                    this.lsvTeams = (global::Windows.UI.Xaml.Controls.ListView)(target);
                    ((global::Windows.UI.Xaml.Controls.ListView)this.lsvTeams).SelectionChanged += this.lsvTeams_SelectionChanged;
                }
                break;
            case 3: // View\CRUDPage.xaml line 25
                {
                    this.lsvPlayers = (global::Windows.UI.Xaml.Controls.ListView)(target);
                }
                break;
            case 4: // View\CRUDPage.xaml line 27
                {
                    this.txbTeamName = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 5: // View\CRUDPage.xaml line 29
                {
                    this.btnAdd = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnAdd).Click += this.btnAdd_Click;
                }
                break;
            case 6: // View\CRUDPage.xaml line 30
                {
                    this.btnDelete = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnDelete).Click += this.btnDelete_Click;
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
