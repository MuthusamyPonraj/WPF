using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Interactivity;
using Syncfusion.Windows.Controls.Spreadsheet;
using System.IO;
using Syncfusion.Windows.Controls.Grid;
using System.Windows;
using ChartDemo.CustomRenderer;

namespace ChartDemo.Behavior
{
    class ImportBehavior : Behavior<SpreadsheetControl>
    {
        protected override void OnAttached()
        {
            this.AssociatedObject.Loaded += new System.Windows.RoutedEventHandler(AssociatedObject_Loaded);
            this.AssociatedObject.WorkBookLoaded += new WorkbookLoadedEventHandler(AssociatedObject_WorkBookLoaded);
        }

        void AssociatedObject_WorkBookLoaded(object sender, WorkbookLoadedEventArgs args)
        {
            foreach (GridControlBase grid in args.GridCollection)
            {
                grid.Model.GraphicModel.CellModels.Add("Chart", new GraphicChartCellModel());
            }
        }

        void AssociatedObject_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {
                FileStream fileStream = new FileStream(@"..\..\Data\Chart.xlsx", FileMode.Open);
                this.AssociatedObject.ImportFromExcel(fileStream);
            }
            catch (Exception ex)
            { }
        }

        protected override void OnDetaching()
        {
            this.AssociatedObject.Loaded -= new System.Windows.RoutedEventHandler(AssociatedObject_Loaded);
            this.AssociatedObject.WorkBookLoaded -= new WorkbookLoadedEventHandler(AssociatedObject_WorkBookLoaded);
        }
    }
}
