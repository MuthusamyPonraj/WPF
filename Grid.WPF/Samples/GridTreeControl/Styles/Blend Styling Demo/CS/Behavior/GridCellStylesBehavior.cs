using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Interactivity;
using Syncfusion.Windows.Controls.Grid;
using Syncfusion.Windows.Controls.Cells;

namespace BlendStylingDemo
{
    public class GridCellStylesBehavior: Behavior<GridTreeControl>
    {
        /// <summary>
        /// Called when [attached].
        /// </summary>
        protected override void OnAttached()
        {
            this.AssociatedObject.ModelLoaded += AssociatedObject_ModelLoaded;
        }

        /// <summary>
        /// Handles the ModelLoaded event of the AssociatedObject control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void AssociatedObject_ModelLoaded(object sender, EventArgs e)
        {
            this.AssociatedObject.ExpandGlyphType = GridTreeExpandGlyph.Themed;
            this.AssociatedObject.InternalGrid.QueryCoveredRange += InternalGrid_QueryCoveredRange;
        }

        /// <summary>
        /// Handles the QueryCoveredRange event of the InternalGrid control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Syncfusion.Windows.Controls.Grid.GridQueryCoveredRangeEventArgs"/> instance containing the event data.</param>
        void InternalGrid_QueryCoveredRange(object sender, GridQueryCoveredRangeEventArgs e)
        {
            var treeNode = this.AssociatedObject.InternalGrid.GetNodeAtRowIndex(e.CellRowColumnIndex.RowIndex);
            if (treeNode != null && treeNode.HasChildNodes)
            {
                if (e.CellRowColumnIndex.ColumnIndex >= 1 &&
                    e.CellRowColumnIndex.ColumnIndex <= this.AssociatedObject.InternalGrid.Columns.Count)
                {
                    e.Range = new CoveredCellInfo(e.CellRowColumnIndex.RowIndex, 1,
                        e.CellRowColumnIndex.RowIndex, this.AssociatedObject.InternalGrid.Columns.Count);
                    e.Handled = true;
                }
            }
        }

        /// <summary>
        /// Called when [detaching].
        /// </summary>
        protected override void OnDetaching()
        {
            this.AssociatedObject.ModelLoaded -= AssociatedObject_ModelLoaded;
            this.AssociatedObject.InternalGrid.QueryCoveredRange -= InternalGrid_QueryCoveredRange;   
        }
    }
}
