using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Interactivity;
using Syncfusion.Windows.Controls.Spreadsheet;
using System.IO;
using Syncfusion.XlsIO;
using System.Data;
using Syncfusion.Windows.Controls.Grid;
using TemplateMarker.Model;

namespace TemplateMarker.Behavior
{
    class ImportBehavior : Behavior<SpreadsheetControl>
    {
        protected override void OnAttached()
        {
            this.AssociatedObject.Loaded += new System.Windows.RoutedEventHandler(AssociatedObject_Loaded);
        }

        void AssociatedObject_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
             try
            {
                FileStream fileStream = new FileStream(@"..\..\Data\Template.xlsx", FileMode.Open);
                this.AssociatedObject.ImportFromExcel(fileStream);
            }
            catch (Exception ex)
            { }
             ApplyTemplate(this.AssociatedObject.ExcelProperties.WorkBook, "Orders");
        }

        /// <summary>
        /// Data table imported to the workbook by using the template marker support
        /// </summary>
        /// <param name="workbook">Workbook</param>
        /// <param name="tablename">Data Table name</param>
        private void ApplyTemplate(IWorkbook workbook, string tablename)
        {
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
            if (this.AssociatedObject.GridProperties.CurrentExcelGridModel != null)
            {
                this.AssociatedObject.GridProperties.CurrentExcelGridModel.InvalidateCell(GridRangeInfo.Row(1));
            }
        }

        /// <summary>
        /// Based on the table name template was copied to the workbook range
        /// template is in following format.
        /// %DataTableName.ColumnName
        /// </summary>
        /// <param name="range">Workbook Range</param>
        /// <param name="tablename">Data Table name</param>
        private void FillTemplate(IWorkbook workbook, string tablename)
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



        protected override void OnDetaching()
        {
            this.AssociatedObject.Loaded -= new System.Windows.RoutedEventHandler(AssociatedObject_Loaded);
        }
    }
}
