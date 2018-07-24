using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Syncfusion.Windows.Controls.Grid;
using System.Windows.Interactivity;
using System.Windows;
using Syncfusion.Windows.Controls.Cells;

namespace CustomToolTipDemo
{
   public class GridCellStylesBehavior : Behavior<GridTreeControl>
    {
        /// <summary>
        /// Called when [attached].
        /// </summary>
        protected override void OnAttached()
        {
            base.OnAttached();
            this.AssociatedObject.ModelLoaded += new EventHandler(AssociatedObject_ModelLoaded);
        }

        /// <summary>
        /// Handles the ModelLoaded event of the AssociatedObject control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void AssociatedObject_ModelLoaded(object sender, EventArgs e)
        {
            GridTooltipService.SetShowTooltips(this.AssociatedObject.InternalGrid, true);
            GridTooltipService.SetTooltipDelay(this.AssociatedObject.InternalGrid, 200);

            this.AssociatedObject.Model.Options.ActivateCurrentCellBehavior = GridCellActivateAction.DblClickOnCell;
            this.AssociatedObject.Model.RowHeights.DefaultLineSize = 30;

            this.AssociatedObject.InternalGrid.QueryCellInfo += new GridQueryCellInfoEventHandler(InternalGrid_QueryCellInfo);
            this.AssociatedObject.Model.QueryCoveredRange += new GridQueryCoveredRangeEventHandler(Model_QueryCoveredRange);
        }

        /// <summary>
        /// Handles the QueryCoveredRange event of the Model control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Syncfusion.Windows.Controls.Grid.GridQueryCoveredRangeEventArgs"/> instance containing the event data.</param>
        void Model_QueryCoveredRange(object sender, GridQueryCoveredRangeEventArgs e)
        {
            var treeNode = this.AssociatedObject.InternalGrid.GetNodeAtRowIndex(e.CellRowColumnIndex.RowIndex);
            if (treeNode != null && treeNode.HasChildNodes)
            {
                if (e.CellRowColumnIndex.ColumnIndex >= 1 && e.CellRowColumnIndex.ColumnIndex <= this.AssociatedObject.InternalGrid.Columns.Count)
                {
                    e.Range = new CoveredCellInfo(e.CellRowColumnIndex.RowIndex, 1, e.CellRowColumnIndex.RowIndex, this.AssociatedObject.InternalGrid.Columns.Count);
                    e.Handled = true;
                }
            }
        }

        /// <summary>
        /// Handles the QueryCellInfo event of the InternalGrid control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Syncfusion.Windows.Controls.Grid.GridQueryCellInfoEventArgs"/> instance containing the event data.</param>
        void InternalGrid_QueryCellInfo(object sender, GridQueryCellInfoEventArgs e)
        {
            if ((e.Style.ColumnIndex == 3 || e.Style.ColumnIndex == 5) && e.Style.CellType != "SortHeader")
            {
                e.Style.HorizontalAlignment = HorizontalAlignment.Right;
                e.Style.VerticalAlignment = VerticalAlignment.Center;
            }
            var currentNode = this.AssociatedObject.InternalGrid.GetNodeAtRowIndex(e.Cell.RowIndex);
            if (currentNode != null)
            {
                if (!currentNode.HasChildNodes)
                {
                    e.Style.ShowTooltip = true;
                    e.Style.TooltipTemplateKey = "myTooltipTemplate";
                }
            }
            if (currentNode != null)
                e.Style.CellValue2 = currentNode.Item;

            if (currentNode != null && currentNode.HasChildNodes)
            {
                e.Style.Font = new GridFontInfo { FontWeight = FontWeights.Bold };
                e.Style.ReadOnly = true;
            }
        }

        /// <summary>
        /// Called when [detaching].
        /// </summary>
        protected override void OnDetaching()
        {
            base.OnDetaching();
            this.AssociatedObject.ModelLoaded -= new EventHandler(AssociatedObject_ModelLoaded);
            this.AssociatedObject.InternalGrid.QueryCellInfo -= new GridQueryCellInfoEventHandler(InternalGrid_QueryCellInfo);
            this.AssociatedObject.Model.QueryCoveredRange -= new GridQueryCoveredRangeEventHandler(Model_QueryCoveredRange);
        }
    }
}
