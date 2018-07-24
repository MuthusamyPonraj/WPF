using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Syncfusion.Windows.Controls.Grid.Converter;
using Syncfusion.Windows.Controls.Grid;
using System.Windows;

namespace CSVExportDemo
{
    /// <summary>
    /// Code for exporting the CSV 
    /// </summary>
    public class ExportAllCommand
    {
        /// <summary>
        /// Initializes the <see cref="ExportAllCommand"/> class.
        /// </summary>
        static ExportAllCommand()
        {
            //Registering the ExportAllToCSV  command
            CommandManager.RegisterClassCommandBinding(typeof(GridDataControl), new CommandBinding(ExportAllToCSV, OnExecuteExportAllToCSV, OnCanExecuteExportAllToCSV));
        }

        public static RoutedCommand ExportAllToCSV = new RoutedCommand("ExportAllToCSV", typeof(GridDataControl));

        /// <summary>
        /// Called when [execute export all to CSV].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The <see cref="System.Windows.Input.ExecutedRoutedEventArgs"/> instance containing the event data.</param>
        private static void OnExecuteExportAllToCSV(object sender, ExecutedRoutedEventArgs args)
        {
            GridDataControl gdc = args.Source as GridDataControl; 
            try
            {            
                gdc.Model.ExportToCSV(GridRangeInfo.Cells(0, 0, gdc.Model.RowCount - 1, gdc.Model.ColumnCount - 1), "Sample.csv");
                System.Diagnostics.Process.Start("Sample.csv");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        /// <summary>
        /// Called when [can execute export all to CSV].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The <see cref="System.Windows.Input.CanExecuteRoutedEventArgs"/> instance containing the event data.</param>
        private static void OnCanExecuteExportAllToCSV(object sender, CanExecuteRoutedEventArgs args)
        {
            args.CanExecute = true;
        }
    }
}
