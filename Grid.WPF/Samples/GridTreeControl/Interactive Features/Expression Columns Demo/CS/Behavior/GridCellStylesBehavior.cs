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
using Syncfusion.Windows.Controls.Grid;
using System.Windows.Interactivity;
using System.Windows;
using Syncfusion.Windows.Controls.Cells;

namespace UnboundColumns
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
            this.AssociatedObject.Model.Options.ActivateCurrentCellBehavior = GridCellActivateAction.DblClickOnCell;
            
            this.AssociatedObject.InternalGrid.ExpandGlyphType = GridTreeExpandGlyph.PlusMinusLines;
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
        /// Called when [detaching].
        /// </summary>
        protected override void OnDetaching()
        {
            base.OnDetaching();
            this.AssociatedObject.ModelLoaded -= new EventHandler(AssociatedObject_ModelLoaded);
            this.AssociatedObject.Model.QueryCoveredRange -= new GridQueryCoveredRangeEventHandler(Model_QueryCoveredRange);
        }
    }
}
