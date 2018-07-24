using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Interactivity;
using Syncfusion.Windows.Controls.Grid;
using System.Windows.Media.Imaging;

namespace FileExplorer
{
   public class RequestNodeImageBehavior:Behavior<GridTreeControl>
    {
        /// <summary>
        /// Called after the behavior is attached to an AssociatedObject.
        /// </summary>
        /// <remarks>Override this to hook up functionality to the AssociatedObject.</remarks>
        protected override void OnAttached()
        {
            base.OnAttached();
            this.AssociatedObject.RequestNodeImage += new GridTreeRequestNodeImageHandler(AssociatedObject_RequestNodeImage);
        }

        /// <summary>
        /// Handles the RequestNodeImage event of the AssociatedObject control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="args">The <see cref="Syncfusion.Windows.Controls.Grid.GridTreeRequestNodeImageEventArgs"/> instance containing the event data.</param>
        void AssociatedObject_RequestNodeImage(object sender, GridTreeRequestNodeImageEventArgs args)
        {
            var item = args.Item as FileInfoModel;
            if (item.FileType == "Drive")
            {
                BitmapImage bitImage = new BitmapImage(new Uri("pack://application:,,/Images/DriveNode.png"));
                args.NodeImage = bitImage;
            }
            else if (item.FileType == "Directory")
            {
                args.NodeImage = new BitmapImage(new Uri("pack://application:,,/Images/folder.png"));
            }
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
