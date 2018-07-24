using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Interactivity;
using Syncfusion.Windows.Controls.Spreadsheet;
using System.Windows.Controls;
using Syncfusion.Windows.Controls.Grid;

namespace ChartDemo.Behavior
{
    public class SelectionTrigger: TargetedTriggerAction<SpreadsheetControl>
    {
        private bool isChecked = false;
        private GridControlBase grid;
        protected override void Invoke(object parameter)
        {
            var selectionchkbox = this.AssociatedObject as CheckBox;
            selectionchkbox.Checked += new System.Windows.RoutedEventHandler(selectionchkbox_Checked);
            selectionchkbox.Unchecked += new System.Windows.RoutedEventHandler(selectionchkbox_Unchecked);
            this.grid = ((this.AssociatedObject as CheckBox).DataContext as SpreadsheetControl).GridProperties.ActiveSpreadsheetGrid;
            this.grid.Model.GraphicModel.GraphicQueryCellInfo += new GraphicQueryCellInfoEventHandler(GraphicModel_GraphicQueryCellInfo);
        }

        void GraphicModel_GraphicQueryCellInfo(object sender, GraphicQueryCellInfoEventArgs e)
        {
            e.Style.Enabled = isChecked;
            if (!e.Style.Enabled)
            {
                if (e.Style.GraphicCellControl != null && e.Style.GraphicCellControl.IsSelected)
                {
                    e.Style.GraphicCellControl.IsSelected = false;
                    var spanInfo = GraphicCellHelper.GetCellSpanInfo(e.Style.GraphicCellControl);
                    grid.Model.GraphicModel.SelectedGraphicCells.Remove(spanInfo);
                    e.Style.GraphicCellControl.InvalidateVisual();
                }
            }
        }

        void selectionchkbox_Unchecked(object sender, System.Windows.RoutedEventArgs e)
        {
            isChecked = false;
            grid.Model.GraphicModel.InvalidateGraphicCells();
            
        }

        void selectionchkbox_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            isChecked = true;
            grid.Model.GraphicModel.InvalidateGraphicCells();
        }
    }
}
