﻿#pragma checksum "..\..\CurrentDemand.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "D3489508B39AA5D90FCA4788B1629FA93573D00925CB10DC4874C81ACBB4AEA6"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using ContoraRealtor;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace ContoraRealtor {
    
    
    /// <summary>
    /// CurrentDemand
    /// </summary>
    public partial class CurrentDemand : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\CurrentDemand.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid ClientLi;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\CurrentDemand.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid RealtorLi;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\CurrentDemand.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid Type;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\CurrentDemand.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox MaxPr;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\CurrentDemand.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox MinPri;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\CurrentDemand.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox TypeCombo;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/ContoraRealtor;component/currentdemand.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\CurrentDemand.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 10 "..\..\CurrentDemand.xaml"
            ((System.Windows.Controls.Grid)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Grid_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.ClientLi = ((System.Windows.Controls.DataGrid)(target));
            
            #line 11 "..\..\CurrentDemand.xaml"
            this.ClientLi.Loaded += new System.Windows.RoutedEventHandler(this.Clients_Loaded);
            
            #line default
            #line hidden
            
            #line 11 "..\..\CurrentDemand.xaml"
            this.ClientLi.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ClientLi_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.RealtorLi = ((System.Windows.Controls.DataGrid)(target));
            
            #line 12 "..\..\CurrentDemand.xaml"
            this.RealtorLi.Loaded += new System.Windows.RoutedEventHandler(this.Realtors_Loaded);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Type = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 5:
            this.MaxPr = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.MinPri = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.TypeCombo = ((System.Windows.Controls.ComboBox)(target));
            
            #line 16 "..\..\CurrentDemand.xaml"
            this.TypeCombo.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ComboBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 26 "..\..\CurrentDemand.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 27 "..\..\CurrentDemand.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_1);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 28 "..\..\CurrentDemand.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_2);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
