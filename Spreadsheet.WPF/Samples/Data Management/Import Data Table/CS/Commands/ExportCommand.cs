using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Syncfusion.Windows.Controls.Spreadsheet;
using Syncfusion.XlsIO.Implementation;
using Syncfusion.XlsIO;
using System.Data;
using ImportDataTable.View;
using System.Windows;

namespace ImportDataTable.Commands
{
    public static class ExportCommand
    {
        static ExportCommand()
        {
            CommandManager.RegisterClassCommandBinding(typeof(SpreadsheetControl), new CommandBinding(ExportToDataTable, OnExecuteExportToDataTable, OnCanExecuteExportToDataTable));
        }

        public static RoutedCommand ExportToDataTable = new RoutedCommand("ExportToDataTable", typeof(SpreadsheetControl));

        private static void OnExecuteExportToDataTable(object sender, ExecutedRoutedEventArgs args)
        {
            SpreadsheetControl spreadsheetControl = args.Source as SpreadsheetControl;
            if (spreadsheetControl != null)
            {
                IWorksheet sheet = spreadsheetControl.ExcelProperties.WorkBook.Worksheets[0];
                IRange range = sheet.Range["A1:K50"];
                DataTable Dt = sheet.ExportDataTable(range, ExcelExportDataTableOptions.ColumnNames);
                DataGridView dgv = new DataGridView();
                dgv.DataContext = Dt;
                dgv.ShowDialog();
            }
        }

        private static void OnCanExecuteExportToDataTable(object sender, CanExecuteRoutedEventArgs args)
        {
            args.CanExecute = true;
        }
    }
}
