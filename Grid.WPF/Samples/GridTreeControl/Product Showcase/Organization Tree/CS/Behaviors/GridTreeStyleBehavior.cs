using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Interactivity;
using Syncfusion.Windows.Controls.Grid;
using Syncfusion.Windows.Controls.Cells;
using System.Windows;
using System.Windows.Media;

namespace OrganizationTree
{
    public class QueryCoveredRangeBehavior : Behavior<GridTreeControl>
    {
        /// <summary>
        /// Called after the behavior is attached to an AssociatedObject.
        /// </summary>
        /// <remarks>Override this to hook up functionality to the AssociatedObject.</remarks>
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
            this.AssociatedObject.Model.RowHeights.DefaultLineSize = 55;
            this.AssociatedObject.Model.Options.ActivateCurrentCellBehavior = GridCellActivateAction.DblClickOnCell;
            this.AssociatedObject.Model.QueryCoveredRange += new GridQueryCoveredRangeEventHandler(Model_QueryCoveredRange);
            this.AssociatedObject.Model.QueryCellInfo += new GridQueryCellInfoEventHandler(InternalGrid_QueryCellInfo);
        }

        /// <summary>
        /// Handles the QueryCellInfo event of the InternalGrid control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Syncfusion.Windows.Controls.Grid.GridQueryCellInfoEventArgs"/> instance containing the event data.</param>
        void InternalGrid_QueryCellInfo(object sender, GridQueryCellInfoEventArgs e)
        {
            e.Style.HorizontalAlignment = HorizontalAlignment.Left;
            if ((e.Style.ColumnIndex >= 5 && e.Style.ColumnIndex <= 9) && e.Style.CellType != "SortHeader")
            {
                e.Style.HorizontalAlignment = HorizontalAlignment.Right;
            }
            var currentNode = this.AssociatedObject.InternalGrid.GetNodeAtRowIndex(e.Cell.RowIndex);
            if (currentNode != null && currentNode.HasChildNodes)
            {
                e.Style.ImageContentStretch = ImageContentStretch.Uniform;
                e.Style.Font = new GridFontInfo { FontWeight = FontWeights.Bold };
                e.Style.ReadOnly = true;
                if (e.Style.ColumnIndex == 1)
                {
                    e.Style.Font.FontSize = 14;
                    e.Style.Foreground = Brushes.Black;
                }
                else if (e.Style.ColumnIndex > 1)
                    e.Style.Foreground = Brushes.Gray;
            }
            else
                e.Style.VerticalAlignment = VerticalAlignment.Center;
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
                    this.AssociatedObject.Model.RowStyles[e.CellRowColumnIndex.RowIndex].VerticalAlignment = VerticalAlignment.Stretch;
                    this.AssociatedObject.Model.RowStyles[e.CellRowColumnIndex.RowIndex].BorderMargins = new CellMarginsInfo(new Thickness() { Bottom = -5, Left = 0, Right = 0, Top = 5 });
                }
            }
        }
        /// <summary>
        /// Called when the behavior is being detached from its AssociatedObject, but before it has actually occurred.
        /// </summary>
        /// <remarks>Override this to unhook functionality from the AssociatedObject.</remarks>
        protected override void OnDetaching()
        {
            base.OnDetaching();
            this.AssociatedObject.ModelLoaded -= new EventHandler(AssociatedObject_ModelLoaded);
            this.AssociatedObject.Model.QueryCoveredRange -= new GridQueryCoveredRangeEventHandler(Model_QueryCoveredRange);
            this.AssociatedObject.Model.QueryCellInfo -= new GridQueryCellInfoEventHandler(InternalGrid_QueryCellInfo);
        }
    }
}
