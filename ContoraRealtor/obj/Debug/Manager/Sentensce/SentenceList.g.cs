﻿#pragma checksum "..\..\..\..\Manager\Sentensce\SentenceList.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "52B5F8A25BE6EEDD456C0EBF5A2094C69FF249DB"
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
    /// SentenceList
    /// </summary>
    public partial class SentenceList : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\..\..\Manager\Sentensce\SentenceList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid SentenceLi;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\..\Manager\Sentensce\SentenceList.xaml"
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
            System.Uri resourceLocater = new System.Uri("/ContoraRealtor;component/manager/sentensce/sentencelist.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Manager\Sentensce\SentenceList.xaml"
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
            
            #line 11 "..\..\..\..\Manager\Sentensce\SentenceList.xaml"
            ((ContoraRealtor.SentenceList)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.Window_Closing);
            
            #line default
            #line hidden
            return;
            case 2:
            this.SentenceLi = ((System.Windows.Controls.DataGrid)(target));
            
            #line 13 "..\..\..\..\Manager\Sentensce\SentenceList.xaml"
            this.SentenceLi.Loaded += new System.Windows.RoutedEventHandler(this.SentenceLi_Loaded);
            
            #line default
            #line hidden
            
            #line 13 "..\..\..\..\Manager\Sentensce\SentenceList.xaml"
            this.SentenceLi.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.SentenceLi_SelectionChanged);
            
            #line default
            #line hidden
            
            #line 13 "..\..\..\..\Manager\Sentensce\SentenceList.xaml"
            this.SentenceLi.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.SentenceLi_MouseDoubleClick);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 14 "..\..\..\..\Manager\Sentensce\SentenceList.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 15 "..\..\..\..\Manager\Sentensce\SentenceList.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_1);
            
            #line default
            #line hidden
            return;
            case 5:
            this.ExcelFails = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\..\..\Manager\Sentensce\SentenceList.xaml"
            this.ExcelFails.Click += new System.Windows.RoutedEventHandler(this.ExcelFails_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

