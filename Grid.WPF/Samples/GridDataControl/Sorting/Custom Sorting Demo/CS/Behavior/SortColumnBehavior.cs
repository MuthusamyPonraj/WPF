using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Syncfusion.Windows.Controls.Grid;
using System.Windows.Interactivity;

namespace CustomSortingDemo
{
    public class SortColumnBehavior : Behavior<GridDataControl>
    {
        /// <summary>
        /// Called when [attached].
        /// </summary>
        protected override void OnAttached()
        {
            this.AssociatedObject.Model.Table.SortColumnsChanging += new GridDataSortColumnsChangingEventHandler(Table_SortColumnsChanging);
        }

        /// <summary>
        /// Handles the SortColumnsChanging event of the Table control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="args">The <see cref="Syncfusion.Windows.Controls.Grid.GridDataSortColumnsChangingEventArgs"/> instance containing the event data.</param>
        void Table_SortColumnsChanging(object sender, GridDataSortColumnsChangingEventArgs args)
        {
            foreach (var item in args.AddedItems)
            {
                if (item != null)
                {
                    if (item.ColumnName.Equals("CompanyName"))
                    {
                        item.CustomComparer = new CustomerInfo();
                    }
                }
            }
        }

        /// <summary>
        /// Called when [detaching].
        /// </summary>
        protected override void OnDetaching()
        {
            this.AssociatedObject.Model.Table.SortColumnsChanging -= new GridDataSortColumnsChangingEventHandler(Table_SortColumnsChanging);
        }
    }
}
