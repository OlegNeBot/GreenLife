﻿#pragma checksum "..\..\..\..\Windows\MainWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "947228140ABDC1A49FB801F3A32BA12C7F7AD1C6"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using GreenLife;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace GreenLife {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 29 "..\..\..\..\Windows\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CheckListBtn;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\..\Windows\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AccountBtn;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\..\Windows\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button MainBtn;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\..\Windows\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button MemoBtn;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\..\Windows\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SettingsBtn;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\..\Windows\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Frame PagesShow;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.6.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/GreenLife;V1.0.0.0;component/windows/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Windows\MainWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.6.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.CheckListBtn = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\..\..\Windows\MainWindow.xaml"
            this.CheckListBtn.Click += new System.Windows.RoutedEventHandler(this.CheckListBtn_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.AccountBtn = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\..\..\Windows\MainWindow.xaml"
            this.AccountBtn.Click += new System.Windows.RoutedEventHandler(this.AccountBtn_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.MainBtn = ((System.Windows.Controls.Button)(target));
            
            #line 35 "..\..\..\..\Windows\MainWindow.xaml"
            this.MainBtn.Click += new System.Windows.RoutedEventHandler(this.MainBtn_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.MemoBtn = ((System.Windows.Controls.Button)(target));
            
            #line 38 "..\..\..\..\Windows\MainWindow.xaml"
            this.MemoBtn.Click += new System.Windows.RoutedEventHandler(this.MemoBtn_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.SettingsBtn = ((System.Windows.Controls.Button)(target));
            
            #line 41 "..\..\..\..\Windows\MainWindow.xaml"
            this.SettingsBtn.Click += new System.Windows.RoutedEventHandler(this.SettingsBtn_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.PagesShow = ((System.Windows.Controls.Frame)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

