using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.ComponentModel;
using Syncfusion.Windows.Controls.Grid;

namespace ColumnChooserDemo
{
    /// <summary>
    /// Interaction logic for ColumnChooserWindow.xaml
    /// </summary>
    public partial class ColumnChooserWindow : Window
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="ColumnChooserWindow"/> class.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        public ColumnChooserWindow(ColumnChooserViewModel viewModel)
        {
            InitializeComponent();
            this.DataContext = viewModel;
        }

        /// <summary>
        /// Handles the Click event of the OKButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }       
    }
    
}
