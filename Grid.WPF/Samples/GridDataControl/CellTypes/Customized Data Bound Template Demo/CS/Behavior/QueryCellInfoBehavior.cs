using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Interactivity;
using Syncfusion.Windows.Controls.Grid;

namespace CustomizedDataBoundTemplateDemo
{
    class QueryCellInfoBehavior:Behavior<GridDataControl>
    {
        /// <summary>
        /// Called when [attached].
        /// </summary>
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.Model.QueryCellInfo += new GridQueryCellInfoEventHandler(Model_QueryCellInfo);
        }

        /// <summary>
        /// Handles the QueryCellInfo event of the Model control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Syncfusion.Windows.Controls.Grid.GridQueryCellInfoEventArgs"/> instance containing the event data.</param>
        void Model_QueryCellInfo(object sender, GridQueryCellInfoEventArgs e)
        {
            var style = e.Style as GridDataStyleInfo;
            if (style != null)
            {
                if (style.CellIdentity != null && style.CellIdentity.TableCellType == GridDataTableCellType.GroupCaptionCell)
                {
                    var newstyle = e.Style.GridModel[e.Cell.RowIndex + 1, e.Cell.ColumnIndex] as GridDataStyleInfo;
                    if (newstyle != null && newstyle.CellIdentity != null)
                    {
                        var record = newstyle.CellIdentity.Record as MovieInfo;
                        if (record != null)
                            style.CellValue = "MovieName : " + record.MovieName;
                    }

                }
            }
        }

        /// <summary>
        /// Called when [detaching].
        /// </summary>
        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.Model.QueryCellInfo -= new GridQueryCellInfoEventHandler(Model_QueryCellInfo);
        }
    }
}
