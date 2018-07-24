using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Interactivity;
using Syncfusion.Windows.Controls.Grid;
using System.Windows.Media;
using Syncfusion.Windows.GridCommon;
using System.Data;
using System.Windows.Media.Imaging;

namespace UnBoundRowDemo
{
    class UnboundRowSummaryBehavior : Behavior<GridTreeControl>
    {
        protected override void OnAttached()
        {
            //Subscribed to calculate the summary
            this.AssociatedObject.ItemsSourceChanged += AssociatedObject_ItemsSourceChanged;
            //Subscribed to subscribe to InternalGrid events
            this.AssociatedObject.ModelLoaded += AssociatedObject_ModelLoaded;
            //Subscribed to load Node image in expander cell
            this.AssociatedObject.RequestNodeImage += AssociatedObject_RequestNodeImage;
        }

        void AssociatedObject_ModelLoaded(object sender, EventArgs e)
        {
            this.AssociatedObject.Model.TableStyle.VerticalAlignment = System.Windows.VerticalAlignment.Center;
            //Subscribed to apply summary values to Unbound Rows
            this.AssociatedObject.InternalGrid.QueryCellInfo += InternalGrid_QueryCellInfo;
            //Subscriped to make the Unbound Rows as Covered Range
            this.AssociatedObject.InternalGrid.QueryCoveredRange += InternalGrid_QueryCoveredRange;
        }

        protected override void OnDetaching()
        {
            this.AssociatedObject.ItemsSourceChanged -= AssociatedObject_ItemsSourceChanged;
            this.AssociatedObject.ModelLoaded -= AssociatedObject_ModelLoaded;
            this.AssociatedObject.RequestNodeImage -= AssociatedObject_RequestNodeImage;
            this.AssociatedObject.InternalGrid.QueryCellInfo -= InternalGrid_QueryCellInfo;
            this.AssociatedObject.InternalGrid.QueryCoveredRange -= InternalGrid_QueryCoveredRange;
        }

        #region Unbound Rows

        int TOTAL_EMPLOYEES = 0;
        long TOTAL_SICKLEAVEHOURS = 0;
        void AssociatedObject_ItemsSourceChanged(object sender, Syncfusion.Windows.ComponentModel.SyncfusionRoutedEventArgs args)
        {
            var table = (this.AssociatedObject.ItemsSource as DataView).Table;
            TOTAL_EMPLOYEES = (int)table.Compute("COUNT(EmployeeID)", "");
            TOTAL_SICKLEAVEHOURS = (long)table.Compute("SUM(SickLeaveHours)", "");
        }

        void InternalGrid_QueryCoveredRange(object sender, GridQueryCoveredRangeEventArgs e)
        {
            var rowcolIndex = e.CellRowColumnIndex;
            if (rowcolIndex.ColumnIndex >= 1)
            {
                var unboundPos = this.AssociatedObject.InternalGrid.ResolveIndexToUnboundRowPosition(rowcolIndex.RowIndex);
                if (unboundPos >= 0 && unboundPos < this.AssociatedObject.UnboundRowsCount)
                {
                    e.Range = new Syncfusion.Windows.Controls.Cells.CoveredCellInfo(rowcolIndex.RowIndex, 1, rowcolIndex.RowIndex, AssociatedObject.Model.ColumnCount - 1);
                    e.Handled = true;
                }
            }
        }

        void InternalGrid_QueryCellInfo(object sender, GridQueryCellInfoEventArgs e)
        {
            if (e.Style.Tag != null && e.Style.Tag.Equals("UnboundRow") && e.Style.ColumnIndex == 1)
            {
                var unboundPos = this.AssociatedObject.InternalGrid.ResolveIndexToUnboundRowPosition(e.Style.RowIndex);
                if (unboundPos == 0)
                    e.Style.CellValue = "Total : " + TOTAL_EMPLOYEES + " Employess";
                else if (unboundPos == 1)
                    e.Style.CellValue = "Total Sick leave hours : " + TOTAL_SICKLEAVEHOURS + " hours";

                e.Style.Background = new SolidColorBrush(GridUtil.GetXamlConvertedValue<Color>("#FFA9C1DE"));
                e.Style.Foreground = new SolidColorBrush(GridUtil.GetXamlConvertedValue<Color>("#FF1E395B"));
				e.Style.ReadOnly = true;
            }
        }

        #endregion

        #region NodeImage
        void AssociatedObject_RequestNodeImage(object sender, GridTreeRequestNodeImageEventArgs args)
        {
            DataRowView row = args.Item as DataRowView;
            if (row["Gender"].Equals("M"))
            {
                args.NodeImage = new BitmapImage(new Uri("pack://application:,,/images/male.png"));
            }
            else
                args.NodeImage = new BitmapImage(new Uri("pack://application:,,/images/female.png"));
        }
        #endregion

    }
}
