using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Syncfusion.Windows.Controls.Grid.Converter;
using Syncfusion.Windows.Controls.Grid;
using Syncfusion.XlsIO;
using System.Windows;

namespace NestedChildExcelExportDemo
{
    /// <summary>
    /// Code for Exporting selected ranges to Excel
    /// </summary>
    public class ExportSelectedCommand
    {
        /// <summary>
        /// Initializes the <see cref="ExportSelectedCommand"/> class.
        /// </summary>
        static ExportSelectedCommand()
        { 
            //Registering ExportSelectedToExcel Command
            CommandManager.RegisterClassCommandBinding(typeof(GridDataControl), new CommandBinding(ExportSelectedToExcel, OnExecuteExportSelectedToExcel, OnCanExecuteExportSelectedToExcel));
        }

        public static RoutedCommand ExportSelectedToExcel = new RoutedCommand("ExportSelectedToExcel", typeof(GridDataControl));

        /// <summary>
        /// Called when [execute export selected to excel].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The <see cref="System.Windows.Input.ExecutedRoutedEventArgs"/> instance containing the event data.</param>
        private static void OnExecuteExportSelectedToExcel(object sender, ExecutedRoutedEventArgs args)
        {
            GridDataControl grid = args.Source as GridDataControl;
            if (grid != null && !grid.Model.SelectedRanges.ActiveRange.IsEmpty)
            {
                try
                {
                    grid.ExportToExcel(grid.Model.SelectedRanges.ActiveRange, "Sample.xls", ExcelVersion.Excel97to2003);
                    System.Diagnostics.Process.Start("Sample.xls");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        /// <summary>
        /// Called when [can execute export selected to excel].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The <see cref="System.Windows.Input.CanExecuteRoutedEventArgs"/> instance containing the event data.</param>
        private static void OnCanExecuteExportSelectedToExcel(object sender, CanExecuteRoutedEventArgs args)
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
