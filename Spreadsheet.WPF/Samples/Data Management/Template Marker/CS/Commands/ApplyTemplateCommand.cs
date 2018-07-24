using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Syncfusion.Windows.Controls.Spreadsheet;
using Syncfusion.XlsIO.Implementation;
using Syncfusion.XlsIO;
using System.Data;
using TemplateMarker.Model;
using Syncfusion.Windows.Controls.Grid;

namespace TemplateMarker.Commands
{
    public static class ApplyTemplateCommand
    {
        static ApplyTemplateCommand()
        {
            CommandManager.RegisterClassCommandBinding(typeof(SpreadsheetControl), new CommandBinding(ApplyTemplate, OnExecuteApplyTemplateCommand, OnCanExecuteApplyTemplateCommand));
        }

        #region ApplyTemplateCommand
        public static RoutedCommand ApplyTemplate = new RoutedCommand("ApplyTemplate", typeof(SpreadsheetControl));

        private static void OnExecuteApplyTemplateCommand(object sender, ExecutedRoutedEventArgs args)
        {
            SpreadsheetControl spreadsheetControl = args.Source as SpreadsheetControl;
            if (spreadsheetControl != null && args.Parameter != null)
            {
                IWorkbook workbook = spreadsheetControl.ExcelProperties.WorkBook;
                string tablename = args.Parameter.ToString();
                IRange range = workbook.Worksheets[0].Range["A1:E3"];
                if (tablename.Contains("Orders"))
                {
                    tablename = "Orders";
                }
                else if (tablename.Contains("Products"))
                {
                    tablename = "Products";
                }
                else if (tablename.Contains("Customers"))
                {
                    tablename = "Customers";
                }
                FillTemplate(workbook, tablename);
                DataTable DataTable = Data.GetDataTable(tablename);
                //Apply Template
                ITemplateMarkersProcessor marker = workbook.Worksheets[0].CreateTemplateMarkersProcessor();
                marker.AddVariable(tablename, DataTable, VariableTypeAction.DetectNumberFormat);
                marker.ApplyMarkers();
                if (spreadsheetControl.GridProperties.CurrentExcelGridModel != null)
                {
                    spreadsheetControl.GridProperties.CurrentExcelGridModel.InvalidateCell(GridRangeInfo.Row(1));
                }
                spreadsheetControl.GridProperties.ActiveSpreadsheetGrid.InvalidateCells();
            }
        }

        /// <summary>
        /// Based on the table name template was copied to the workbook range
        /// template is in following format.
        /// %DataTableName.ColumnName
        /// </summary>
        /// <param name="range">Workbook Range</param>
        /// <param name="tablename">Data Table name</param>
        private static void FillTemplate(IWorkbook workbook, string tablename)
        {
            IWorksheet SourceSheet = workbook.Worksheets[1];
            IWorksheet MainSheet = workbook.Worksheets[0];
            IRange SourceRange;
            IRange TargetRange;
            if (SourceSheet != null && MainSheet != null)
            {
                TargetRange = MainSheet.Range["A1:E3"];
                if (tablename.Equals("Products"))
                    SourceRange = SourceSheet.Range["A6:E8"];
                else if (tablename.Equals("Customers"))
                    SourceRange = SourceSheet.Range["A11:E13"];
                else
                    SourceRange = SourceSheet.Range["A1:E3"];
                SourceRange.CopyTo(TargetRange);
            }
        }


        private static void OnCanExecuteApplyTemplateCommand(object sender, CanExecuteRoutedEventArgs args)
        {
            args.CanExecute = true;
        }
        #endregion

    }
}
