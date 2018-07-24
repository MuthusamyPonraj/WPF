using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Syncfusion.Windows.Controls.Spreadsheet;
using Syncfusion.XlsIO.Implementation;
using Syncfusion.XlsIO;

namespace SpreadsheetToHTML.Commands
{
    public static class ExportCommand
    {
        static ExportCommand()
        {
            CommandManager.RegisterClassCommandBinding(typeof(SpreadsheetControl), new CommandBinding(ExportWorkBookToHTML, OnExecuteExportWorkBookToHTML, OnCanExecuteExportWorkBookToHTML));
            CommandManager.RegisterClassCommandBinding(typeof(SpreadsheetControl), new CommandBinding(ExportWorksheetToHTML, OnExecuteExportWorksheetToHTML, OnCanExecuteExportWorksheetToHTML));
        }

        #region ExportWorkBookToHTML
        public static RoutedCommand ExportWorkBookToHTML = new RoutedCommand("ExportWorkBookToHTML", typeof(SpreadsheetControl));

        private static void OnExecuteExportWorkBookToHTML(object sender, ExecutedRoutedEventArgs args)
        {
            SpreadsheetControl spreadsheetControl = args.Source as SpreadsheetControl;
            spreadsheetControl.ExcelProperties.WorkBook.SaveAsHtml("Sample.html", HtmlSaveOptions.Default);
            System.Diagnostics.Process.Start("Sample.html");

        }

        private static void OnCanExecuteExportWorkBookToHTML(object sender, CanExecuteRoutedEventArgs args)
        {
            args.CanExecute = true;
        }
        #endregion

        #region ExportWorksheetToHTML
        public static RoutedCommand ExportWorksheetToHTML = new RoutedCommand("ExportWorksheetToHTML", typeof(SpreadsheetControl));

        private static void OnExecuteExportWorksheetToHTML(object sender, ExecutedRoutedEventArgs args)
        {
            SpreadsheetControl spreadsheetControl = args.Source as SpreadsheetControl;
            string SelectedItem = (string)args.Parameter;
            if (SelectedItem.Contains("Orders"))
                spreadsheetControl.ExcelProperties.WorkBook.Worksheets["Orders"].SaveAsHtml("Sample.html");
            else if (SelectedItem.Contains("Customers"))
                spreadsheetControl.ExcelProperties.WorkBook.Worksheets["Customers"].SaveAsHtml("Sample.html");
            else if (SelectedItem.Contains("Products"))
                spreadsheetControl.ExcelProperties.WorkBook.Worksheets["Products"].SaveAsHtml("Sample.html");
            System.Diagnostics.Process.Start("Sample.html");
        }

        private static void OnCanExecuteExportWorksheetToHTML(object sender, CanExecuteRoutedEventArgs args)
        {
            args.CanExecute = true;
        }
        #endregion
    }
}
