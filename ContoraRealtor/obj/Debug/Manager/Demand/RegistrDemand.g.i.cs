﻿#pragma checksum "..\..\..\..\Manager\Demand\RegistrDemand.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "88A13B62A54231F276F00AE7AC5A6DE741F8269E"
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
    /// RegistrDemand
    /// </summary>
    public partial class RegistrDemand : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\..\..\Manager\Demand\RegistrDemand.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid ClientLi;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\..\Manager\Demand\RegistrDemand.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid RealtorLi;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\..\Manager\Demand\RegistrDemand.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid Type;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\..\Manager\Demand\RegistrDemand.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox MaxPr;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\..\Manager\Demand\RegistrDemand.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox MinPri;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\..\Manager\Demand\RegistrDemand.xaml"
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
            System.Uri resourceLocater = new System.Uri("/ContoraRealtor;component/manager/demand/registrdemand.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Manager\Demand\RegistrDemand.xaml"
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
            
            #line 11 "..\..\..\..\Manager\Demand\RegistrDemand.xaml"
            ((ContoraRealtor.RegistrDemand)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.Window_Closing);
            
            #line default
            #line hidden
            return;
            case 2:
            this.ClientLi = ((System.Windows.Controls.DataGrid)(target));
            
            #line 13 "..\..\..\..\Manager\Demand\RegistrDemand.xaml"
            this.ClientLi.Loaded += new System.Windows.RoutedEventHandler(this.Clients_Loaded);
            
            #line default
            #line hidden
            return;
            case 3:
            this.RealtorLi = ((System.Windows.Controls.DataGrid)(target));
            
            #line 14 "..\..\..\..\Manager\Demand\RegistrDemand.xaml"
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
            
            #line 18 "..\..\..\..\Manager\Demand\RegistrDemand.xaml"
            this.TypeCombo.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ComboBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 23 "..\..\..\..\Manager\Demand\RegistrDemand.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 24 "..\..\..\..\Manager\Demand\RegistrDemand.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_1);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

