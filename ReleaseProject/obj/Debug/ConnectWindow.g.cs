﻿#pragma checksum "..\..\ConnectWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "BA9976D3B7535D12B1DC894E0688FCF3"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

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


namespace ReleaseProject {
    
    
    /// <summary>
    /// ConnectWindow
    /// </summary>
    public partial class ConnectWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 5 "..\..\ConnectWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal ReleaseProject.ConnectWindow ConnectingWindow;
        
        #line default
        #line hidden
        
        
        #line 10 "..\..\ConnectWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox serverName;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\ConnectWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton windAut;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\ConnectWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton sqlAut;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\ConnectWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox userName;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\ConnectWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox password;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\ConnectWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox dataBaseName;
        
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
            System.Uri resourceLocater = new System.Uri("/ReleaseProject;component/connectwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ConnectWindow.xaml"
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
            this.ConnectingWindow = ((ReleaseProject.ConnectWindow)(target));
            return;
            case 2:
            this.serverName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.windAut = ((System.Windows.Controls.RadioButton)(target));
            
            #line 11 "..\..\ConnectWindow.xaml"
            this.windAut.Checked += new System.Windows.RoutedEventHandler(this.windAut_Checked);
            
            #line default
            #line hidden
            return;
            case 4:
            this.sqlAut = ((System.Windows.Controls.RadioButton)(target));
            
            #line 12 "..\..\ConnectWindow.xaml"
            this.sqlAut.Checked += new System.Windows.RoutedEventHandler(this.sqlAut_Checked);
            
            #line default
            #line hidden
            return;
            case 5:
            this.userName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.password = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 7:
            this.dataBaseName = ((System.Windows.Controls.ComboBox)(target));
            
            #line 18 "..\..\ConnectWindow.xaml"
            this.dataBaseName.DropDownOpened += new System.EventHandler(this.dataBaseName_DropDownOpened);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 19 "..\..\ConnectWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.button1_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 20 "..\..\ConnectWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.button2_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 21 "..\..\ConnectWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.button3_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

