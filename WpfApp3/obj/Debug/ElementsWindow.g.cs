﻿#pragma checksum "..\..\ElementsWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8327C97649CDBF560631626BF7EB6F69E99304F7"
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
using WpfApp3;


namespace WpfApp3 {
    
    
    /// <summary>
    /// ElementsWindow
    /// </summary>
    public partial class ElementsWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 9 "..\..\ElementsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid ElPlace;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\ElementsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel stackPanel;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\ElementsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton RBElement;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\ElementsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton RBList;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\ElementsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel ElementParameters;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\ElementsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid NewList;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\ElementsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas Background;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\ElementsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas SchemePlace;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\ElementsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox ElementList;
        
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
            System.Uri resourceLocater = new System.Uri("/WpfApp3;component/elementswindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ElementsWindow.xaml"
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
            this.ElPlace = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.stackPanel = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 3:
            this.RBElement = ((System.Windows.Controls.RadioButton)(target));
            
            #line 20 "..\..\ElementsWindow.xaml"
            this.RBElement.Checked += new System.Windows.RoutedEventHandler(this.ElementButtonChecked);
            
            #line default
            #line hidden
            return;
            case 4:
            this.RBList = ((System.Windows.Controls.RadioButton)(target));
            
            #line 21 "..\..\ElementsWindow.xaml"
            this.RBList.Checked += new System.Windows.RoutedEventHandler(this.ListButtonChecked);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 22 "..\..\ElementsWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonOkClick);
            
            #line default
            #line hidden
            return;
            case 6:
            this.ElementParameters = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 7:
            this.NewList = ((System.Windows.Controls.Grid)(target));
            return;
            case 8:
            this.Background = ((System.Windows.Controls.Canvas)(target));
            
            #line 29 "..\..\ElementsWindow.xaml"
            this.Background.SizeChanged += new System.Windows.SizeChangedEventHandler(this.UpdateBackPattern);
            
            #line default
            #line hidden
            return;
            case 9:
            this.SchemePlace = ((System.Windows.Controls.Canvas)(target));
            return;
            case 10:
            this.ElementList = ((System.Windows.Controls.ListBox)(target));
            return;
            case 11:
            
            #line 33 "..\..\ElementsWindow.xaml"
            ((System.Windows.Controls.ListBoxItem)(target)).Selected += new System.Windows.RoutedEventHandler(this.ElementClicked);
            
            #line default
            #line hidden
            return;
            case 12:
            
            #line 36 "..\..\ElementsWindow.xaml"
            ((System.Windows.Controls.ListBoxItem)(target)).Selected += new System.Windows.RoutedEventHandler(this.LoadedClicked);
            
            #line default
            #line hidden
            return;
            case 13:
            
            #line 39 "..\..\ElementsWindow.xaml"
            ((System.Windows.Controls.ListBoxItem)(target)).Selected += new System.Windows.RoutedEventHandler(this.UnLoadedClicked);
            
            #line default
            #line hidden
            return;
            case 14:
            
            #line 42 "..\..\ElementsWindow.xaml"
            ((System.Windows.Controls.ListBoxItem)(target)).Selected += new System.Windows.RoutedEventHandler(this.SlidingLoadedClicked);
            
            #line default
            #line hidden
            return;
            case 15:
            
            #line 45 "..\..\ElementsWindow.xaml"
            ((System.Windows.Controls.ListBoxItem)(target)).Selected += new System.Windows.RoutedEventHandler(this.SlidingUnLoadedClicked);
            
            #line default
            #line hidden
            return;
            case 16:
            
            #line 48 "..\..\ElementsWindow.xaml"
            ((System.Windows.Controls.ListBoxItem)(target)).Selected += new System.Windows.RoutedEventHandler(this.MajorConnectNFMClicked);
            
            #line default
            #line hidden
            return;
            case 17:
            
            #line 51 "..\..\ElementsWindow.xaml"
            ((System.Windows.Controls.ListBoxItem)(target)).Selected += new System.Windows.RoutedEventHandler(this.BridgeConnectClicked);
            
            #line default
            #line hidden
            return;
            case 18:
            
            #line 54 "..\..\ElementsWindow.xaml"
            ((System.Windows.Controls.ListBoxItem)(target)).Selected += new System.Windows.RoutedEventHandler(this.BackupDeviceControlGroupsLRClicked);
            
            #line default
            #line hidden
            return;
            case 19:
            
            #line 57 "..\..\ElementsWindow.xaml"
            ((System.Windows.Controls.ListBoxItem)(target)).Selected += new System.Windows.RoutedEventHandler(this.SerialConnectClicked);
            
            #line default
            #line hidden
            return;
            case 20:
            
            #line 60 "..\..\ElementsWindow.xaml"
            ((System.Windows.Controls.ListBoxItem)(target)).Selected += new System.Windows.RoutedEventHandler(this.BackupControlType2Clicked);
            
            #line default
            #line hidden
            return;
            case 21:
            
            #line 63 "..\..\ElementsWindow.xaml"
            ((System.Windows.Controls.ListBoxItem)(target)).Selected += new System.Windows.RoutedEventHandler(this.ReservManageReplacingClicked);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

