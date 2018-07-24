using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Interactivity;
using Syncfusion.Windows.Controls.Spreadsheet;
using System.IO;
using Syncfusion.Windows.Controls.Grid;
using System.Windows;
using System.ComponentModel;

namespace Zooming.Behavior
{
    class ImportBehavior : Behavior<SpreadsheetControl>
    {
        protected override void OnAttached()
        {
            this.AssociatedObject.Loaded += new System.Windows.RoutedEventHandler(AssociatedObject_Loaded);
            this.AssociatedObject.WorkBookLoaded += new WorkbookLoadedEventHandler(AssociatedObject_WorkBookLoaded);
        }

        void AssociatedObject_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
             try
            {
                FileStream fileStream = new FileStream(@"..\..\Data\DefaultSheet.xlsx", FileMode.Open);
                this.AssociatedObject.ImportFromExcel(fileStream);
            }
            catch (Exception ex)
            { }
        }

        void AssociatedObject_WorkBookLoaded(object sender, WorkbookLoadedEventArgs args)
        {
            for (int i = 0; i < args.GridCollection.Count; i++)
            {
                args.GridCollection[i].ZoomScale = this.AssociatedObject.ExcelProperties.WorkBook.Worksheets[i].Zoom / 100.00;
            }
        }

        protected override void OnDetaching()
        {
            this.AssociatedObject.Loaded -= new System.Windows.RoutedEventHandler(AssociatedObject_Loaded);
            this.AssociatedObject.WorkBookLoaded -= new WorkbookLoadedEventHandler(AssociatedObject_WorkBookLoaded);
        }
    }
}
