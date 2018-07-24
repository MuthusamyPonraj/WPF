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
    public class RequestItemsBehavior : Behavior<GridTreeControl>
    {
        ViewModel viewModel = null;
        /// <summary>
        /// Called after the behavior is attached to an AssociatedObject.
        /// </summary>
        /// <remarks>Override this to hook up functionality to the AssociatedObject.</remarks>
        protected override void OnAttached()
        {
            base.OnAttached();
            viewModel = this.AssociatedObject.DataContext as ViewModel;
            this.AssociatedObject.RequestTreeItems += new GridTreeRequestTreeItemsHandler(AssociatedObject_RequestTreeItems);
        }

        /// <summary>
        /// Handles the RequestTreeItems event of the AssociatedObject control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="args">The <see cref="Syncfusion.Windows.Controls.Grid.GridTreeRequestTreeItemsEventArgs"/> instance containing the event data.</param>
        void AssociatedObject_RequestTreeItems(object sender, GridTreeRequestTreeItemsEventArgs args)
        {
            //when ParentItem is null, you need to set args.ChildList to be the root items...
            if (args.ParentItem == null)
            {
                //get the root list - get all employees who have no boss 
                args.ChildList = viewModel.EmployeeInfo.Where(x => x.ReportsTo == -1); //get all employees whose boss's id is -1 (no boss)
            }
            else //if ParentItem not null, then set args.ChildList to the child items for the given ParentItem.
            {   //get the children of the parent object
                EmployeeInfo emp = args.ParentItem as EmployeeInfo;
                if (emp != null)
                {
                    //get all employees that report to the parent employee
                    args.ChildList = viewModel.EmployeeInfo.Where(x => x.ReportsTo == emp.ID);
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
            this.AssociatedObject.RequestTreeItems -= new GridTreeRequestTreeItemsHandler(AssociatedObject_RequestTreeItems);
        }
    }
}
