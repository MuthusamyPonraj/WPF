using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Syncfusion.Windows.Controls.Grid.Converter;
using Syncfusion.Windows.Controls.Grid;
using Syncfusion.XlsIO;
using System.Windows;

namespace GroupingExcelExportDemo
{
    /// <summary>
    /// Code for Exporting All to Excel
    /// </summary>
    public class ExportAllCommand
    {
        /// <summary>
        /// Initializes the <see cref="ExportAllCommand"/> class.
        /// </summary>
        static ExportAllCommand()
        {
            //Registering ExportAllToExcel Command
            CommandManager.RegisterClassCommandBinding(typeof(GridDataControl), new CommandBinding(ExportAllToExcel, OnExecuteExportAllToExcel, OnCanExecuteExportAllToExcel));
        }

        public static RoutedCommand ExportAllToExcel = new RoutedCommand("ExportAllToExcel", typeof(GridDataControl));

        /// <summary>
        /// Called when [execute export all to excel].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The <see cref="System.Windows.Input.ExecutedRoutedEventArgs"/> instance containing the event data.</param>
        private static void OnExecuteExportAllToExcel(object sender, ExecutedRoutedEventArgs args)
        {
            GridDataControl grid = args.Source as GridDataControl;
            try
            {
                grid.ExportToExcel("Sample.xls", ExcelVersion.Excel97to2003);
                System.Diagnostics.Process.Start("Sample.xls");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        /// <summary>
        /// Called when [can execute export all to excel].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The <see cref="System.Windows.Input.CanExecuteRoutedEventArgs"/> instance containing the event data.</param>
        private static void OnCanExecuteExportAllToExcel(object sender, CanExecuteRoutedEventArgs args)
        {
            args.CanExecute = true;
        }
    }
}
