﻿#pragma checksum "..\..\..\..\Manager\DeaL\Deal_Deal.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "7EEE61FC4D8277C2C31D271DB7167B10A37C50B9585637CAF671C48F82C16226"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using ContoraRealtor.Manager.DeaL;
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


namespace ContoraRealtor.Manager.DeaL {
    
    
    /// <summary>
    /// Deal_Deal
    /// </summary>
    public partial class Deal_Deal : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\..\..\Manager\DeaL\Deal_Deal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid DemandLi;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\..\..\Manager\DeaL\Deal_Deal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid SentencLi;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\..\Manager\DeaL\Deal_Deal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Update;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\..\Manager\DeaL\Deal_Deal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Delete;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\..\Manager\DeaL\Deal_Deal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Back;
        
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
            System.Uri resourceLocater = new System.Uri("/ContoraRealtor;component/manager/deal/deal_deal.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Manager\DeaL\Deal_Deal.xaml"
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
            this.DemandLi = ((System.Windows.Controls.DataGrid)(target));
            
            #line 10 "..\..\..\..\Manager\DeaL\Deal_Deal.xaml"
            this.DemandLi.Loaded += new System.Windows.RoutedEventHandler(this.DemandLi_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.SentencLi = ((System.Windows.Controls.DataGrid)(target));
            
            #line 11 "..\..\..\..\Manager\DeaL\Deal_Deal.xaml"
            this.SentencLi.Loaded += new System.Windows.RoutedEventHandler(this.SentencLi_Loaded);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Update = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\..\..\Manager\DeaL\Deal_Deal.xaml"
            this.Update.Click += new System.Windows.RoutedEventHandler(this.Update_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Delete = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\..\..\Manager\DeaL\Deal_Deal.xaml"
            this.Delete.Click += new System.Windows.RoutedEventHandler(this.Delete_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Back = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\..\..\Manager\DeaL\Deal_Deal.xaml"
            this.Back.Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

