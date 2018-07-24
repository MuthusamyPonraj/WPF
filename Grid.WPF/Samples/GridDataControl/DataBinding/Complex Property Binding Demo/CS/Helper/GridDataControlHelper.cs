using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using Syncfusion.Windows.Controls.Grid;

namespace ComplexPropertyBindingDemo
{
    public class GridDataControlHelper
    {
        /// <summary>
        /// Gets the visible columns.
        /// </summary>
        /// <param name="obj">The obj.</param>
        /// <returns></returns>
        public static List<string> GetVisibleColumns(DependencyObject obj)
        {
            return (List<string>)obj.GetValue(VisibleColumnsProperty);
        }

        /// <summary>
        /// Sets the visible columns.
        /// </summary>
        /// <param name="obj">The obj.</param>
        /// <param name="value">The value.</param>
        public static void SetVisibleColumns(DependencyObject obj, List<string> value)
        {
            obj.SetValue(VisibleColumnsProperty, value);
        }

        // Using a DependencyProperty as the backing store for VisibleColumns.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty VisibleColumnsProperty =
            DependencyProperty.RegisterAttached("VisibleColumns", typeof(List<string>), typeof(GridDataControlHelper), new PropertyMetadata(OnVisibleColumnChanged));

        /// <summary>
        /// Called when [visible column changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void OnVisibleColumnChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
        {
            GridDataControl DataGrid = sender as GridDataControl;
            if (DataGrid != null && args.NewValue != null)
            {
                List<string> ListofColumn = args.NewValue as List<string>;
                DataGrid.VisibleColumns.Clear();
                foreach (string ColumnName in ListofColumn)
                {
                    GridDataVisibleColumn gridVisiblecolumn = new GridDataVisibleColumn();
                    gridVisiblecolumn.AllowDrag = true;
                    gridVisiblecolumn.AllowFilter = true;
                    gridVisiblecolumn.AllowGroup = true;
                    gridVisiblecolumn.AllowSort = true;
                    gridVisiblecolumn.MappingName = ColumnName;
                    gridVisiblecolumn.HeaderText = ColumnName;
                    gridVisiblecolumn.HeaderStyle = new GridDataColumnStyle() { HorizontalAlignment = HorizontalAlignment.Center };
                    DataGrid.VisibleColumns.Add(gridVisiblecolumn);
                }
            }
        }
    }
}
