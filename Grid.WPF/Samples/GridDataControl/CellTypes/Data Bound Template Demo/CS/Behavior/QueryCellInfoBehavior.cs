using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Interactivity;
using Syncfusion.Windows.Controls.Grid;

namespace DataBoundTemplateDemo
{
    class QueryCellInfoBehavior : Behavior<GridDataControl>
    {
        /// <summary>
        /// Called when [attached].
        /// </summary>
        protected override void OnAttached()
        {
            this.AssociatedObject.Model.RowHeights.DefaultLineSize = 30;
            this.AssociatedObject.Model.QueryCellInfo += new GridQueryCellInfoEventHandler(Model_QueryCellInfo);
        }

        /// <summary>
        /// Handles the QueryCellInfo event of the Model control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Syncfusion.Windows.Controls.Grid.GridQueryCellInfoEventArgs"/> instance containing the event data.</param>
        void Model_QueryCellInfo(object sender, GridQueryCellInfoEventArgs e)
        {
            var tableStyleIdentity = ((GridDataStyleInfo)e.Style).CellIdentity;
            if (tableStyleIdentity != null && tableStyleIdentity.Column != null)
            {
                if (tableStyleIdentity.Column.MappingName == "CustomerID")
                {
                    e.Style.ItemsSource = ViewModel.Customers;
                }
            }               
        }

        /// <summary>
        /// Called when [detaching].
        /// </summary>
        protected override void OnDetaching()
        {
            this.AssociatedObject.Model.QueryCellInfo -= new GridQueryCellInfoEventHandler(Model_QueryCellInfo);
        }
    }
}
