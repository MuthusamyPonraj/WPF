using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Syncfusion.Windows.Controls.Grid;
using System.Windows.Interactivity;

namespace TouchStylingDemo
{
    class InitialSetupBehavior : Behavior<GridDataControl>
    {
        /// <summary>
        /// Called when [attached].
        /// </summary>
        protected override void OnAttached()
        {
            AssociatedObject.Loaded += new System.Windows.RoutedEventHandler(AssociatedObject_Loaded);
            AssociatedObject.ModelLoaded += new EventHandler(AssociatedObject_ModelLoaded);
            AssociatedObject.Model.Table.RecordExpanded += new EventHandler<GridDataValueEventArgs<GridDataRecord>>(Table_RecordExpanded);
        }

        void Table_RecordExpanded(object sender, GridDataValueEventArgs<GridDataRecord> e)
        {
            e.Value.ChildModels[0].RowHeights.DefaultLineSize = 40;
        }

        void AssociatedObject_ModelLoaded(object sender, EventArgs e)
        {
            this.AssociatedObject.Model.RowHeights.DefaultLineSize = 40;
        }

        /// <summary>
        /// Handles the Loaded event of the GridDatacontrol.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        void AssociatedObject_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            this.AssociatedObject.Model.RowHeights.DefaultLineSize = 44;
        }

        /// <summary>
        /// Called when [detaching].
        /// </summary>
        protected override void OnDetaching()
        {
            AssociatedObject.Loaded -= new System.Windows.RoutedEventHandler(AssociatedObject_Loaded);
            AssociatedObject.ModelLoaded -= new EventHandler(AssociatedObject_ModelLoaded);
            AssociatedObject.Model.Table.RecordExpanded -= new EventHandler<GridDataValueEventArgs<GridDataRecord>>(Table_RecordExpanded);
        }
    }
}
