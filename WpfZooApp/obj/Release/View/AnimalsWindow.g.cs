﻿#pragma checksum "..\..\..\View\AnimalsWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "44C00D47987A20C19429207ED718FE4A7FA0D68467C0DC5C476C2629F726274B"
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
using WpfZooApp.View;


namespace WpfZooApp.View {
    
    
    /// <summary>
    /// AnimalsWindow
    /// </summary>
    public partial class AnimalsWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\..\View\AnimalsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox AnimalNameTextBox;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\View\AnimalsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox SpeciesIdComboBox;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\View\AnimalsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox EnclosureIdComboBox;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\View\AnimalsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid AnimalsDataGrid;
        
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
            System.Uri resourceLocater = new System.Uri("/WpfZooApp;component/view/animalswindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\View\AnimalsWindow.xaml"
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
            this.AnimalNameTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.SpeciesIdComboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 3:
            this.EnclosureIdComboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            
            #line 20 "..\..\..\View\AnimalsWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AddAnimal_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 21 "..\..\..\View\AnimalsWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.UpdateAnimal_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 22 "..\..\..\View\AnimalsWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.DeleteAnimal_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.AnimalsDataGrid = ((System.Windows.Controls.DataGrid)(target));
            
            #line 24 "..\..\..\View\AnimalsWindow.xaml"
            this.AnimalsDataGrid.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.AnimalsDataGrid_SelectionChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

