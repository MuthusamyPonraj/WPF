using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Interactivity;
using Syncfusion.Windows.Controls.Grid;

namespace CustomizingCaptionSummaryRow_Demo
{
    class QueryCellInfoBehavior: Behavior<GridDataControl>
    {
        /// <summary>
        /// Called after the behavior is attached to an AssociatedObject.
        /// </summary>
        /// <remarks>Override this to hook up functionality to the AssociatedObject.</remarks>
        protected override void OnAttached()
        {
            this.AssociatedObject.Model.QueryCellInfo += Model_QueryCellInfo;
        }

        /// <summary>
        /// Handles the QueryCellInfo event of the Model control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="args">The <see cref="Syncfusion.Windows.Controls.Grid.GridQueryCellInfoEventArgs"/> instance containing the event data.</param>
        void Model_QueryCellInfo(object sender, GridQueryCellInfoEventArgs args)
        {
            var viewModel = this.AssociatedObject.DataContext as ViewModel;
            if (args.Cell.RowIndex != 0)
            {
                GridDataStyleInfo style = args.Style as GridDataStyleInfo;

                if (style.CellIdentity.TableCellType == GridDataTableCellType.GroupCaptionCell)
                {
                    if (args.Style.CellValue != null)
                    {
                        string country = style.CellIdentity.Group.Key.ToString();
                        var pathLoc = viewModel.ProductsDetails.Where(o => o.Suppliers.Country == country);
                        if (pathLoc.Count() > 0)
                        {
                            var countryPath = pathLoc.ElementAt(0).Suppliers.Country;
                            args.Style.CellValue2 =  "Images/"+countryPath+".png";
                            args.Style.CellType = "DataBoundTemplate";
                            args.Style.CellItemTemplateKey = "sampleTemplate";
                        }

                    }
                }
            }
        }

        /// <summary>
        /// Called when the behavior is being detached from its AssociatedObject, but before it has actually occurred.
        /// </summary>
        /// <remarks>Override this to unhook functionality from the AssociatedObject.</remarks>
        protected override void OnDetaching()
        {
            this.AssociatedObject.Model.QueryCellInfo -= Model_QueryCellInfo;
        }
    }
}
