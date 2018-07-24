using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Interactivity;
using Syncfusion.Windows.Controls.Grid;

namespace OrganizationTree
{
    public class RequestTreeNodeImage:Behavior<GridTreeControl>
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
            this.AssociatedObject.RequestNodeImage += new GridTreeRequestNodeImageHandler(AssociatedObject_RequestNodeImage);
        }

        /// <summary>
        /// Handles the RequestNodeImage event of the AssociatedObject control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="args">The <see cref="Syncfusion.Windows.Controls.Grid.GridTreeRequestNodeImageEventArgs"/> instance containing the event data.</param>
        void AssociatedObject_RequestNodeImage(object sender, GridTreeRequestNodeImageEventArgs args)
        {
            args.NodeImage = viewModel.GetItemBitmap(args.Item as EmployeeInfo);
        }

        /// <summary>
        /// Called when the behavior is being detached from its AssociatedObject, but before it has actually occurred.
        /// </summary>
        /// <remarks>Override this to unhook functionality from the AssociatedObject.</remarks>
        protected override void OnDetaching()
        {
            base.OnDetaching();
            this.AssociatedObject.RequestNodeImage -= new GridTreeRequestNodeImageHandler(AssociatedObject_RequestNodeImage);
        }
    }
}
