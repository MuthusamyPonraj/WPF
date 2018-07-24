using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Interactivity;
using Syncfusion.Windows.Controls.Grid;

namespace PrintingDemo
{
    class RequestTreeItemsBehavior : Behavior<GridTreeControl>
    {
        ViewModel viewModel = null;
        /// <summary>
        /// Called when [attached].
        /// </summary>
        protected override void OnAttached()
        {
            base.OnAttached();
            viewModel = this.AssociatedObject.DataContext as ViewModel;
            this.AssociatedObject.RequestTreeItems += new GridTreeRequestTreeItemsHandler(AssociatedObject_RequestTreeItems);
            this.AssociatedObject.RequestNodeImage += new GridTreeRequestNodeImageHandler(treeGrid_RequestNodeImage);
        }

        /// <summary>
        /// Handles the RequestTreeItems event of the AssociatedObject control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="args">The <see cref="Syncfusion.Windows.Controls.Grid.GridTreeRequestTreeItemsEventArgs"/> instance containing the event data.</param>
        void AssociatedObject_RequestTreeItems(object sender, GridTreeRequestTreeItemsEventArgs args)
        {
            //if (viewModel != null)
            //{
                //when ParentItem is null, you need to set args.ChildList to be the root items...
                if (args.ParentItem == null)
                {
                    //get the root list - get all employees who have no boss 
                    args.ChildList = (this.AssociatedObject.DataContext as ViewModel).GetReportees(-1); //get all employees whose boss's id is -1 (no boss)
                }
                else //if ParentItem not null, then set args.ChildList to the child items for the given ParentItem.
                {   //get the children of the parent object
                    EmployeeInfo emp = args.ParentItem as EmployeeInfo;
                    if (emp != null)
                    {
                        //get all employees that report to the parent employee
                        args.ChildList = (this.AssociatedObject.DataContext as ViewModel).GetReportees(emp.ID);
                    }
                }
            //}
        }
        private void treeGrid_RequestNodeImage(object sender, GridTreeRequestNodeImageEventArgs args)
        {
            args.NodeImage = (this.AssociatedObject.DataContext as ViewModel).GetItemBitmap(args.Item as EmployeeInfo);
        }
        /// <summary>
        /// Called when [detaching].
        /// </summary>
        protected override void OnDetaching()
        {
            base.OnDetaching();
            this.AssociatedObject.RequestTreeItems -= new GridTreeRequestTreeItemsHandler(AssociatedObject_RequestTreeItems);
            this.AssociatedObject.RequestNodeImage -= new GridTreeRequestNodeImageHandler(treeGrid_RequestNodeImage);
        }
    }
}
