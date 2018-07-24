using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Syncfusion.Windows.Controls.Spreadsheet;
using System.Data;
using ImportDataTable.Model;

namespace ImportDataTable.Commands
{
    public static class ImportCommand
    {
        static ImportCommand()
        {
            CommandManager.RegisterClassCommandBinding(typeof(SpreadsheetControl), new CommandBinding(ImportFromDataTable, OnExecuteImportFromDataTable, OnCanExecuteImportFromDataTable));
        }

        public static RoutedCommand ImportFromDataTable = new RoutedCommand("ImportFromDataTable", typeof(SpreadsheetControl));

        private static void OnExecuteImportFromDataTable(object sender, ExecutedRoutedEventArgs args)
        {
            SpreadsheetControl spreadsheetControl = args.Source as SpreadsheetControl;
            if (spreadsheetControl != null && args.Parameter != null)
            {
                spreadsheetControl.New(3);
                string SelectedItem = args.Parameter.ToString();
                DataTable datatable;
                if (SelectedItem.Contains("Products"))
                    datatable = Data.GetDataTable("Products");
                else if (SelectedItem.Contains("Orders"))
                    datatable = Data.GetDataTable("Orders");
                else
                    datatable = Data.GetDataTable("Customers");
                spreadsheetControl.ImportFromDataTable(datatable);
            }
        }

        private static void OnCanExecuteImportFromDataTable(object sender, CanExecuteRoutedEventArgs args)
        {
            args.CanExecute = true;
        }
    }
}
