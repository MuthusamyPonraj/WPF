using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Interactivity;
using Syncfusion.Windows.Controls.Grid;
using System.Data;
using System.Windows;
using OnDemandLoadingDemo.DataModel;

namespace OnDemandLoadingDemo
{
    public class GridTreeFunctionalBehavior : Behavior<GridTreeControl>
    {
        ViewModel viewModel;
        /// <summary>
        /// Called after the behavior is attached to an AssociatedObject.
        /// </summary>
        /// <remarks>Override this to hook up functionality to the AssociatedObject.</remarks>
        protected override void OnAttached()
        {
            viewModel = this.AssociatedObject.DataContext as ViewModel;
            this.AssociatedObject.RequestTreeItems += AssociatedObject_RequestTreeItems;
            this.AssociatedObject.Loaded += AssociatedObject_Loaded;
        }

        /// <summary>
        /// Handles the Loaded event to set the initial GridTreeControl properties
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        void AssociatedObject_Loaded(object sender, RoutedEventArgs e)
        {
        }

        /// <summary>
        /// Handles the RequestTreeItems event of the AssociatedObject control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="args">The <see cref="Syncfusion.Windows.Controls.Grid.GridTreeRequestTreeItemsEventArgs"/> instance containing the event data.</param>
        void AssociatedObject_RequestTreeItems(object sender, GridTreeRequestTreeItemsEventArgs args)
        {
            //when ParentItem is null, you need to set args.ChildList to be the root items...
            if (args.ParentItem == null) //requesting the root list...
            {
                //get all employees whose boss's id is -1 (no boss)
                EmployeesDataSet.EmployeesDataTable dt = viewModel.dataAdapter.GetReportees(-1);
                args.ChildList = dt.DefaultView;
            }
            else //if ParentItem not null, then set args.ChildList to the child items for the given ParentItem.
            {   //get the children of the parent object
                DataRowView drv = args.ParentItem as DataRowView;
                EmployeesDataSet.EmployeesDataTable dt = viewModel.dataAdapter.GetReportees((int)drv["ID"]);
                args.ChildList = dt.DefaultView; //get all employees whose boss's id is -1 (no boss)
            }
        }

        protected override void OnDetaching()
        {
            this.AssociatedObject.RequestTreeItems -= AssociatedObject_RequestTreeItems;
            this.AssociatedObject.Loaded -= AssociatedObject_Loaded;
        }
    }
}
