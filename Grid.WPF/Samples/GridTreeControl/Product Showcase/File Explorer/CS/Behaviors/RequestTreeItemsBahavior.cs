using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Interactivity;
using Syncfusion.Windows.Controls.Grid;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Collections;

namespace FileExplorer
{
    public class RequestTreeItemsBehavior : Behavior<GridTreeControl>
    {
        ViewModel viewModel;
        /// <summary>
        /// Called when [attached].
        /// </summary>
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
                args.ChildList = (IEnumerable)viewModel.DriveDetails;
            }
            else  //if ParentItem not null, then set args.ChildList to the child items for the given ParentItem.
            {
                FileInfoModel item = args.ParentItem as FileInfoModel;
                args.ChildList = viewModel.GetChildFolderContent(item);
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
