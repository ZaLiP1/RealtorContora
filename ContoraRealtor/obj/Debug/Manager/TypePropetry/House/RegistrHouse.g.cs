﻿#pragma checksum "..\..\..\..\..\Manager\TypePropetry\House\RegistrHouse.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3D34AA4236A6DA28328286465B044BFA51B73F14"
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
    /// RegistrHouse
    /// </summary>
    public partial class RegistrHouse : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\..\..\..\Manager\TypePropetry\House\RegistrHouse.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Storeys;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\..\..\Manager\TypePropetry\House\RegistrHouse.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Rooms;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\..\..\Manager\TypePropetry\House\RegistrHouse.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox square;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\..\..\Manager\TypePropetry\House\RegistrHouse.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button add;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\..\..\Manager\TypePropetry\House\RegistrHouse.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button back;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\..\..\Manager\TypePropetry\House\RegistrHouse.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid ClientLi;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\..\..\Manager\TypePropetry\House\RegistrHouse.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Cli;
        
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
            System.Uri resourceLocater = new System.Uri("/ContoraRealtor;component/manager/typepropetry/house/registrhouse.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Manager\TypePropetry\House\RegistrHouse.xaml"
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
            
            #line 10 "..\..\..\..\..\Manager\TypePropetry\House\RegistrHouse.xaml"
            ((ContoraRealtor.RegistrHouse)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.Window_Closing);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 11 "..\..\..\..\..\Manager\TypePropetry\House\RegistrHouse.xaml"
            ((System.Windows.Controls.Grid)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Grid_Loaded);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Storeys = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.Rooms = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.square = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.add = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\..\..\..\Manager\TypePropetry\House\RegistrHouse.xaml"
            this.add.Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.back = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\..\..\..\Manager\TypePropetry\House\RegistrHouse.xaml"
            this.back.Click += new System.Windows.RoutedEventHandler(this.Button_Click_1);
            
            #line default
            #line hidden
            return;
            case 8:
            this.ClientLi = ((System.Windows.Controls.DataGrid)(target));
            
            #line 20 "..\..\..\..\..\Manager\TypePropetry\House\RegistrHouse.xaml"
            this.ClientLi.Loaded += new System.Windows.RoutedEventHandler(this.ClientLi_Loaded);
            
            #line default
            #line hidden
            return;
            case 9:
            this.Cli = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
