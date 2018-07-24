#region Copyright Syncfusion Inc. 2001 - 2013
// Copyright Syncfusion Inc. 2001 - 2013. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Syncfusion.Windows.Shared;
using System.ComponentModel;
using Syncfusion.Windows.Controls.Grid;
using System.IO;
using Syncfusion.Windows.GridCommon;
using Syncfusion.Windows.Controls.Cells;
using System.Data;
using System.Data.SqlServerCe;
using System.Reflection;
using Syncfusion.Windows.Data;

namespace MetroCustomizationDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ChromelessWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        #region Events

        private void MetroBrush_OnColorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            SkinStorage.SetMetroBrush(this, new SolidColorBrush((Color)e.NewValue));
        }

        private void HighlightBrush_OnColorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            SkinStorage.SetMetroHighlightedForegroundBrush(this, new SolidColorBrush((Color)e.NewValue));
        }

        private void MetroBackground_OnColorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            SkinStorage.SetMetroPanelBackgroundBrush(this, new SolidColorBrush((Color)e.NewValue));
        }

        private void MetroForeground_OnColorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            SkinStorage.SetMetroForegroundBrush(this, new SolidColorBrush((Color)e.NewValue));
        }

        private void MtFont_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (MtFont.SelectedItem != null)
            {
                var fontFamily = new FontFamily(MtFont.SelectedItem.ToString());
                SkinStorage.SetMetroFontFamily(this, fontFamily);
            }
        }

        #endregion

    }
    
}
