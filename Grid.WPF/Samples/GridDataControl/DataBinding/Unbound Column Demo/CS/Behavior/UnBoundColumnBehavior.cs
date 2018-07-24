using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Syncfusion.Windows.Controls.Grid;
using System.Windows.Interactivity;

namespace UnboundColumnDemo
{
    class UnBoundColumnBehavior : Behavior<GridDataControl>
    {
        /// <summary>
        /// Called after the behavior is attached to an AssociatedObject.
        /// </summary>
        /// <remarks>Override this to hook up functionality to the AssociatedObject.</remarks>
        protected override void OnAttached()
        {
            this.AssociatedObject.Model.QueryCellInfo += new GridQueryCellInfoEventHandler(Model_QueryCellInfo);
            this.AssociatedObject.ModelLoaded += new EventHandler(AssociatedObject_ModelLoaded);
        }

        /// <summary>
        /// Handles the ModelLoaded event of the AssociatedObject control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void AssociatedObject_ModelLoaded(object sender, EventArgs e)
        {
            this.AssociatedObject.Model.RowHeights.DefaultLineSize = 50;
        }

        /// <summary>
        /// Handles the QueryCellInfo event of the Model control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Syncfusion.Windows.Controls.Grid.GridQueryCellInfoEventArgs"/> instance containing the event data.</param>
        void Model_QueryCellInfo(object sender, GridQueryCellInfoEventArgs e)
        {
            var style = e.Style as GridDataStyleInfo;

            if (style != null && !style.IsEmpty)
            {
                if (style.CellIdentity != null && style.CellIdentity.Column != null && style.CellIdentity.Column.MappingName == "PopulationDensity")
                {
                    var record = style.CellIdentity.Record as CountryDetails;
                    if (record != null)
                        style.CellValue = record.Population / record.Area;
                }

                if (style.CellIdentity != null && style.CellIdentity.Column != null && style.CellIdentity.Column.MappingName == "PopulationPercentage1")
                {
                    var record = style.CellIdentity.Record as CountryDetails;
                    if (record != null)
                        style.CellValue = record.PopulationPercentage + " % " + record.Population + " of 6965000000";
                }
            }
        }

        /// <summary>
        /// Called when the behavior is being detached from its AssociatedObject, but before it has actually occurred.
        /// </summary>
        /// <remarks>Override this to unhook functionality from the AssociatedObject.</remarks>
        protected override void OnDetaching()
        {
            this.AssociatedObject.Model.QueryCellInfo -= new GridQueryCellInfoEventHandler(Model_QueryCellInfo);
            this.AssociatedObject.ModelLoaded -= new EventHandler(AssociatedObject_ModelLoaded);
        }
    }
}
