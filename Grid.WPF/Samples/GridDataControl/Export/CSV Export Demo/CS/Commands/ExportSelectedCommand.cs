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
    /// Code for exporting selected ranges to CSV.
    /// </summary>
    public class ExportSelectedCommand
    {
        static ExportSelectedCommand()
        {
            //Registering ExportSelectedToCSV command
            CommandManager.RegisterClassCommandBinding(typeof(GridDataControl), new CommandBinding(ExportSelectedToCSV, OnExecuteExportSelectedToCSV, OnCanExecuteExportSelectedToCSV));
        }

        public static RoutedCommand ExportSelectedToCSV = new RoutedCommand("ExportSelectedToCSV", typeof(GridDataControl));

        /// <summary>
        /// Called when [execute export selected to CSV].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The <see cref="System.Windows.Input.ExecutedRoutedEventArgs"/> instance containing the event data.</param>
        private static void OnExecuteExportSelectedToCSV(object sender, ExecutedRoutedEventArgs args)
        {
            GridDataControl gdc = args.Source as GridDataControl;
            if (gdc != null && !gdc.Model.SelectedRanges.ActiveRange.IsEmpty)
            {
                try
                {
                    gdc.Model.ExportToCSV(gdc.Model.SelectedRanges.ActiveRange, "Sample.csv");
                    System.Diagnostics.Process.Start("Sample.csv");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        /// <summary>
        /// Called when [can execute export selected to CSV].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The <see cref="System.Windows.Input.CanExecuteRoutedEventArgs"/> instance containing the event data.</param>
        private static void OnCanExecuteExportSelectedToCSV(object sender, CanExecuteRoutedEventArgs args)
        {
            var gdc = args.Source as GridDataControl;

            //Export Selected Ranges button is only enabled when the selected range is not empty.
            if (gdc.Model.SelectedRanges.ActiveRange.IsEmpty)
                args.CanExecute = false;
            else
                args.CanExecute = true;
        }
    }
}
