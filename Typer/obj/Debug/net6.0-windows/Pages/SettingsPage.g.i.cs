﻿#pragma checksum "..\..\..\..\Pages\SettingsPage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1A797275D9846A3A2D82D0FE8C6D67DD480D9725"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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
using Typer.Pages;


namespace Typer.Pages {
    
    
    /// <summary>
    /// SettingsPage
    /// </summary>
    public partial class SettingsPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 31 "..\..\..\..\Pages\SettingsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock SelectTimeLabel;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\..\Pages\SettingsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TimeSelectField;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\..\Pages\SettingsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DoneButton;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\..\Pages\SettingsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox LanguageSelectBox;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\..\Pages\SettingsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button UploadWordFiles;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\..\Pages\SettingsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DeleteWordFiles;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.5.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Typer;component/pages/settingspage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\SettingsPage.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.5.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.SelectTimeLabel = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.TimeSelectField = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.DoneButton = ((System.Windows.Controls.Button)(target));
            
            #line 33 "..\..\..\..\Pages\SettingsPage.xaml"
            this.DoneButton.Click += new System.Windows.RoutedEventHandler(this.DoneButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.LanguageSelectBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 35 "..\..\..\..\Pages\SettingsPage.xaml"
            this.LanguageSelectBox.DropDownOpened += new System.EventHandler(this.LanguageSelect_Open);
            
            #line default
            #line hidden
            return;
            case 5:
            this.UploadWordFiles = ((System.Windows.Controls.Button)(target));
            
            #line 36 "..\..\..\..\Pages\SettingsPage.xaml"
            this.UploadWordFiles.Click += new System.Windows.RoutedEventHandler(this.UploadWordFiles_Click_1);
            
            #line default
            #line hidden
            return;
            case 6:
            this.DeleteWordFiles = ((System.Windows.Controls.Button)(target));
            
            #line 37 "..\..\..\..\Pages\SettingsPage.xaml"
            this.DeleteWordFiles.Click += new System.Windows.RoutedEventHandler(this.DeleteWordFiles_Click_1);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

