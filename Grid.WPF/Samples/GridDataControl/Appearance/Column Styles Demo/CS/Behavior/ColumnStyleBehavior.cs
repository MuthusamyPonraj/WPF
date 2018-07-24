using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Interactivity;
using Syncfusion.Windows.Controls.Grid;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ColumnStylesDemo
{
    class ColumnStyleBehavior : Behavior<Window>
    {
        CheckBox FirstColumn, LastColumn, BandedColumn;
        GridDataControl DataGrid;

        /// <summary>
        /// Called after the behavior is attached to an AssociatedObject.
        /// </summary>
        /// <remarks>Override this to hook up functionality to the AssociatedObject.</remarks>
        protected override void OnAttached()
        {
            var window = this.AssociatedObject;

            this.DataGrid = window.FindName("dataGrid") as GridDataControl;
            this.FirstColumn = window.FindName("FirstColumn") as CheckBox;
            this.LastColumn = window.FindName("LastColumn") as CheckBox;
            this.BandedColumn = window.FindName("BandedColumn") as CheckBox;

            FirstColumn.Click += OnFirstOrLastClicked;
            LastColumn.Click += OnFirstOrLastClicked;
            BandedColumn.Click += OnBandedColumnClicked;

            this.DataGrid.ModelLoaded += OnModelLoaded;
        }

        /// <summary>
        /// Called when [model loaded].
        /// </summary>e
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void OnModelLoaded(object sender, EventArgs e)
        {            
            if (FirstColumn.IsChecked.Value)
                ApplyColumnStyle(FirstColumn);

            if (LastColumn.IsChecked.Value)
                ApplyColumnStyle(LastColumn);
        }

        /// <summary>
        /// Called when [banded column clicked].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        void OnBandedColumnClicked(object sender, RoutedEventArgs e)
        {
            GridDataColumnStyle columnStyle = new GridDataColumnStyle();

            if ((sender as CheckBox).IsChecked.Value)
                columnStyle = (GridDataColumnStyle)this.AssociatedObject.FindResource("BandedColumnStyle");

            for (int i = 0; i < this.DataGrid.VisibleColumns.Count; i++)
            {
                if (i % 2 == 0)
                {
                    this.DataGrid.VisibleColumns[i].ColumnStyle = columnStyle;
                }
            }

            if (FirstColumn.IsChecked.Value)
                this.DataGrid.VisibleColumns[0].ColumnStyle = (GridDataColumnStyle)this.AssociatedObject.FindResource("ColumnStyle");

            if (LastColumn.IsChecked.Value)
                this.DataGrid.VisibleColumns[this.DataGrid.VisibleColumns.Count - 1].ColumnStyle = (GridDataColumnStyle)this.DataGrid.FindResource("ColumnStyle");
        }

        /// <summary>
        /// Called when [first or last clicked].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        void OnFirstOrLastClicked(object sender, RoutedEventArgs e)
        {
            ApplyColumnStyle(sender);
        }

        /// <summary>
        /// Applies the column style.
        /// </summary>
        /// <param name="sender">The sender.</param>
        void ApplyColumnStyle(object sender)
        {
            var window = this.AssociatedObject.FindParentElementOfType<Window>();
            GridDataColumnStyle columnStyle = new GridDataColumnStyle();

            if ((sender as CheckBox).IsChecked.Value)
                columnStyle = (GridDataColumnStyle)this.AssociatedObject.FindResource("ColumnStyle");
            else if (this.BandedColumn.IsChecked.Value)
                columnStyle = (GridDataColumnStyle)this.AssociatedObject.FindResource("BandedColumnStyle");

            if ((sender as CheckBox).Content.ToString() == "First Column")
                this.DataGrid.VisibleColumns[0].ColumnStyle = columnStyle;
            else
                this.DataGrid.VisibleColumns[this.DataGrid.VisibleColumns.Count - 1].ColumnStyle = columnStyle;
        }

        /// <summary>
        /// Called when the behavior is being detached from its AssociatedObject, but before it has actually occurred.
        /// </summary>
        /// <remarks>Override this to unhook functionality from the AssociatedObject.</remarks>
        protected override void OnDetaching()
        {
            FirstColumn.Click -= OnFirstOrLastClicked;
            LastColumn.Click -= OnFirstOrLastClicked;
            BandedColumn.Click -= OnBandedColumnClicked;

            this.DataGrid.ModelLoaded -= OnModelLoaded;  
        }
    }
}
