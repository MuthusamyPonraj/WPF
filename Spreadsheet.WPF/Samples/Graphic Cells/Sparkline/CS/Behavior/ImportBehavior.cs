using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Interactivity;
using System.IO;
using SpreadsheetDemo.CustomCellRenderer;
using Syncfusion.Windows.Controls.Spreadsheet;

namespace SpreadsheetDemo.Behavior
{
    class ImportBehavior : Behavior<Syncfusion.Windows.Controls.Spreadsheet.SpreadsheetControl>
    {
        protected override void OnAttached()
        {
            this.AssociatedObject.Loaded += new System.Windows.RoutedEventHandler(AssociatedObject_Loaded);
            this.AssociatedObject.WorkBookLoaded += new Syncfusion.Windows.Controls.Spreadsheet.WorkbookLoadedEventHandler(AssociatedObject_WorkBookLoaded);
        }

        void AssociatedObject_WorkBookLoaded(object sender, Syncfusion.Windows.Controls.Spreadsheet.WorkbookLoadedEventArgs args)
        {
            foreach (SpreadsheetGrid grid in args.GridCollection)
            {
                grid.Model.CellModels.Add("SparkLineCell", new SparklineCellModel());
            }
        }

        void AssociatedObject_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
             try
            {
                FileStream fileStream = new FileStream(@"..\..\Data\SparklineChart.xlsx", FileMode.Open);
                this.AssociatedObject.ImportFromExcel(fileStream);
            }
            catch (Exception ex)
            { }
        }

        protected override void OnDetaching()
        {
            this.AssociatedObject.Loaded -= new System.Windows.RoutedEventHandler(AssociatedObject_Loaded);
        }

    }
}
