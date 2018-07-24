using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Syncfusion.Windows.Controls.Grid;
using System.Windows.Interactivity;
using DetailsViewDemo.DataModel;
using System.Windows;

namespace DetailsViewDemo
{
    class DetailsViewBehavior : Behavior<GridDataControl>
    {
        /// <summary>
        /// Called after the behavior is attached to an AssociatedObject.
        /// </summary>
        /// <remarks>Override this to hook up functionality to the AssociatedObject.</remarks>
        protected override void OnAttached()
        {
            this.AssociatedObject.Model.Table.DetailsViewExpanding += Table_DetailsViewExpanding;

            base.OnAttached();
        }

        /// <summary>
        /// Handles the DetailsViewExpanding event of the Table control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="args">The <see cref="Syncfusion.Windows.Controls.Grid.GridDataDetailsViewExpandingEventArgs"/> instance containing the event data.</param>
        void Table_DetailsViewExpanding(object sender, GridDataDetailsViewExpandingEventArgs args)
        {
            if ((args.Record.Data as Products).Discontinued)
            {
                args.DetailsViewTemplate = (DataTemplate)Application.Current.MainWindow.Resources["ReadOnlyView"];
                args.Handled = true;
            }
        }

        /// <summary>
        /// Called when the behavior is being detached from its AssociatedObject, but before it has actually occurred.
        /// </summary>
        /// <remarks>Override this to unhook functionality from the AssociatedObject.</remarks>
        protected override void OnDetaching()
        {
            this.AssociatedObject.Model.Table.DetailsViewExpanding -= Table_DetailsViewExpanding;

            base.OnDetaching();
        }
    }
}
