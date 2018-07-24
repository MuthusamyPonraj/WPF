using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Interactivity;
using Syncfusion.Windows.Controls.Spreadsheet;
using Syncfusion.Windows.Controls.Grid;

namespace UndoRedoDemo.Behavior
{
    class UndoRedoBehavior:Behavior<SpreadsheetControl>
    {
        protected override void OnAttached()
        {
            this.AssociatedObject.WorkBookLoaded += new WorkbookLoadedEventHandler(AssociatedObject_WorkBookLoaded);
            this.AssociatedObject.WorkSheetAdded += new WorkSheetAddedEventHandler(AssociatedObject_WorkSheetAdded);
        }

        void AssociatedObject_WorkSheetAdded(object sender, WorkSheetAddedEventArgs args)
        {
            (sender as SpreadsheetControl).GridProperties.CurrentExcelGridModel.CommandStack.Enabled = true;
        }

        
        void AssociatedObject_WorkBookLoaded(object sender, WorkbookLoadedEventArgs args)
        {
            foreach (var gridModel in args.GridCollection)
            {
                gridModel.Model.CommandStack.Enabled = true;                                
            }
        }

        protected override void OnDetaching()
        {
            this.AssociatedObject.WorkBookLoaded -= new WorkbookLoadedEventHandler(AssociatedObject_WorkBookLoaded);
            this.AssociatedObject.WorkSheetAdded -= new WorkSheetAddedEventHandler(AssociatedObject_WorkSheetAdded);
        }
    }
}
