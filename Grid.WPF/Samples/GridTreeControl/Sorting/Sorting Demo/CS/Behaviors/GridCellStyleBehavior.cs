#region Copyright Syncfusion Inc. 2001 - 2012
// Copyright Syncfusion Inc. 2001 - 2012. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Interactivity;
using Syncfusion.Windows.Controls.Grid;
using System.Windows;
using System.Windows.Media;
using Syncfusion.Windows.Controls.Cells;

namespace GridTreeSorting
{
    class GridCellStyleBehavior:Behavior<GridTreeControl>
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
            this.AssociatedObject.InternalGrid.QueryCoveredRange += new GridQueryCoveredRangeEventHandler(QueryCoveredRange);
            this.AssociatedObject.InternalGrid.QueryCellInfo += new GridQueryCellInfoEventHandler(InternalGrid_QueryCellInfo);
            this.AssociatedObject.Model.TableStyle.VerticalAlignment = VerticalAlignment.Center;
        }

        /// <summary>
        /// Handles the QueryCellInfo event of the InternalGrid control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Syncfusion.Windows.Controls.Grid.GridQueryCellInfoEventArgs"/> instance containing the event data.</param>
        void InternalGrid_QueryCellInfo(object sender, GridQueryCellInfoEventArgs e)
        {
            var currentNode = this.AssociatedObject.InternalGrid.GetNodeAtRowIndex(e.Cell.RowIndex);
            if (currentNode != null && currentNode.HasChildNodes)
            {
                e.Style.Font = new GridFontInfo { FontWeight = FontWeights.Bold };
                e.Style.ReadOnly = true;
                if (e.Style.ColumnIndex == 1)
                    e.Style.Foreground = Brushes.Black;
            }
        }

        /// <summary>
        /// Handles the QueryCoveredRange event of the Model control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Syncfusion.Windows.Controls.Grid.GridQueryCoveredRangeEventArgs"/> instance containing the event data.</param>
        void QueryCoveredRange(object sender, GridQueryCoveredRangeEventArgs e)
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
        /// Called when the behavior is being detached from its AssociatedObject, but before it has actually occurred.
        /// </summary>
        /// <remarks>Override this to unhook functionality from the AssociatedObject.</remarks>
        protected override void OnDetaching()
        {
            base.OnDetaching();
            this.AssociatedObject.ModelLoaded -= new EventHandler(AssociatedObject_ModelLoaded);
            this.AssociatedObject.InternalGrid.QueryCoveredRange -= new GridQueryCoveredRangeEventHandler(QueryCoveredRange);
            this.AssociatedObject.InternalGrid.QueryCellInfo -= new GridQueryCellInfoEventHandler(InternalGrid_QueryCellInfo);
        }
    }
}
