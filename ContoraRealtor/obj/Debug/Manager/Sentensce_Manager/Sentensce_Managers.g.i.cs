﻿#pragma checksum "..\..\..\..\Manager\Sentensce_Manager\Sentensce_Managers.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "CC44A2DFAFECB96B6B6E7A00FA8F1E284FBCBBD0"
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
    /// Sentensce_Managers
    /// </summary>
    public partial class Sentensce_Managers : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\..\..\Manager\Sentensce_Manager\Sentensce_Managers.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid SentensceLi;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\..\Manager\Sentensce_Manager\Sentensce_Managers.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Back;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\..\Manager\Sentensce_Manager\Sentensce_Managers.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Add;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\..\Manager\Sentensce_Manager\Sentensce_Managers.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ExcelFails;
        
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
            System.Uri resourceLocater = new System.Uri("/ContoraRealtor;component/manager/sentensce_manager/sentensce_managers.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Manager\Sentensce_Manager\Sentensce_Managers.xaml"
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
            
            #line 10 "..\..\..\..\Manager\Sentensce_Manager\Sentensce_Managers.xaml"
            ((ContoraRealtor.Sentensce_Managers)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.Window_Closing);
            
            #line default
            #line hidden
            return;
            case 2:
            this.SentensceLi = ((System.Windows.Controls.DataGrid)(target));
            
            #line 12 "..\..\..\..\Manager\Sentensce_Manager\Sentensce_Managers.xaml"
            this.SentensceLi.Loaded += new System.Windows.RoutedEventHandler(this.SentensceLi_Loaded);
            
            #line default
            #line hidden
            
            #line 12 "..\..\..\..\Manager\Sentensce_Manager\Sentensce_Managers.xaml"
            this.SentensceLi.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.SentensceLi_MouseDoubleClick);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Back = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\..\..\Manager\Sentensce_Manager\Sentensce_Managers.xaml"
            this.Back.Click += new System.Windows.RoutedEventHandler(this.Back_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Add = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\..\..\Manager\Sentensce_Manager\Sentensce_Managers.xaml"
            this.Add.Click += new System.Windows.RoutedEventHandler(this.Add_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.ExcelFails = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\..\..\Manager\Sentensce_Manager\Sentensce_Managers.xaml"
            this.ExcelFails.Click += new System.Windows.RoutedEventHandler(this.ExcelFails_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

