using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Interactivity;
using Syncfusion.Windows.Controls.Grid;

namespace CustomizedDataBoundTemplateDemo
{
    class GridCellStylesBehavior : Behavior<GridDataControl>
    {
        /// <summary>
        /// Called when [attached].
        /// </summary>
        protected override void OnAttached()
        {
            AssociatedObject.Loaded += new System.Windows.RoutedEventHandler(AssociatedObject_Loaded);
            AssociatedObject.Model.Table.GroupExpanded += new GroupExpandedEventHandler(Table_GroupExpanded);
        }

        /// <summary>
        /// Handles the Loaded event of the AssociatedObject control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        void AssociatedObject_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            setRowHeight();
        }

        /// <summary>
        /// Handles the GroupExpanded event of the Table control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="args">The <see cref="Syncfusion.Windows.Controls.Grid.GroupExpandedEventArgs"/> instance containing the event data.</param>
        void Table_GroupExpanded(object sender, GroupExpandedEventArgs args)
        {
            setRowHeight();       
        }

        /// <summary>
        /// Sets the height of the row.
        /// </summary>
        private void setRowHeight()
        {
            for (int i = 0; i < this.AssociatedObject.Model.RowCount; i++)
            {
                var style = this.AssociatedObject.Model[i, 1] as GridDataStyleInfo;
                if (style != null && style.CellIdentity.TableCellType == GridDataTableCellType.RecordCell)
                {
                    this.AssociatedObject.Model.RowHeights[i] = 100;
                }
                else if (style != null && style.CellIdentity.TableCellType == GridDataTableCellType.GroupCaptionCell)
                {
                    this.AssociatedObject.Model.RowHeights[i] = 30;
                }
            }
            this.AssociatedObject.Model.Grid.InvalidateVisual();
        }

        /// <summary>
        /// Called when [detaching].
        /// </summary>
        protected override void OnDetaching()
        {
            AssociatedObject.Loaded -= new System.Windows.RoutedEventHandler(AssociatedObject_Loaded);
            AssociatedObject.Model.Table.GroupExpanded -= new GroupExpandedEventHandler(Table_GroupExpanded);
        }
    }
}
