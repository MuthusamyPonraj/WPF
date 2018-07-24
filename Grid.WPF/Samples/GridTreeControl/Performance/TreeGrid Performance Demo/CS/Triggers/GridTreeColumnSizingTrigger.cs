using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Interactivity;
using Syncfusion.Windows.Controls.Grid;
using System.Windows;
using System.Windows.Controls;

namespace TreeGridInDepth
{
   public class GridTreeColumnSizingTrigger : TargetedTriggerAction<GridTreeControl>
    {
        /// <summary>
        /// Gets or sets the target object.
        /// </summary>
        /// <value>The target object.</value>
        public object TargetObject
        {
            get { return (object)GetValue(TargetObjectProperty); }
            set { SetValue(TargetObjectProperty, value); }
        }

        public static readonly DependencyProperty TargetObjectProperty =
            DependencyProperty.Register("TargetObject", typeof(object), typeof(GridTreeColumnSizingTrigger), new PropertyMetadata());

        /// <summary>
        /// Invokes the specified parameter.
        /// </summary>
        /// <param name="parameter">The parameter.</param>
        protected override void Invoke(object parameter)
        {
            var treeGrid = this.TargetObject as GridTreeControl;
            var viewModel = treeGrid.DataContext as ViewModel;
            var Args = parameter as RoutedEventArgs;
            CheckBox checkBox = Args.Source as CheckBox;
            if (checkBox.IsChecked.Value)
            {
                viewModel.PercentWidthComboIsEnabled = true;
                viewModel.TextBlockFontWeight = FontWeights.Bold;
            }
            else
            {
                viewModel.PercentWidthComboIsEnabled = false;
                viewModel.TextBlockFontWeight = FontWeights.Normal;
            }
            if (treeGrid == null)
                return;

            //clear out the columns incase user clicks button several times...
            treeGrid.Columns.Clear();
            treeGrid.SelectedNodes.Clear();
            if (checkBox.IsChecked.Value)
            {
              SetUpColumnsCollection(treeGrid);
            }
            else
            {
                treeGrid.PercentSizingBehavior = GridPercentColumnSizingBehavior.None;
                treeGrid.AutoPopulateColumnInfo();
            }
            treeGrid.InternalGrid.ResetGrid();
            treeGrid.InternalGrid.InvalidateCells();
        }

        /// <summary>
        /// Sets up columns collection.
        /// </summary>
        /// <param name="grid">The grid.</param>
        private static void SetUpColumnsCollection(GridTreeControl grid)
        {
            //need to specify the columns you want to see in the grid as well as their order
            GridTreeColumn tc = new GridTreeColumn("FirstName", "First Name", 100);
            grid.Columns.Add(tc); //0           
            tc = new GridTreeColumn("LastName", "Last Name", 100);
            tc.PercentWidth = 1;
            grid.Columns.Add(tc);
            tc = new GridTreeColumn("Department", "Department", 100);
            tc.PercentWidth = 1;
            grid.Columns.Add(tc); //3
            tc = new GridTreeColumn("Salary", "Salary", 80);
            tc.StyleInfo.HorizontalAlignment = HorizontalAlignment.Right;
            tc.PercentWidth = 1;
            tc.StyleInfo.CellValueType = typeof(double);
            tc.StyleInfo.Format = "0,000";
            grid.Columns.Add(tc); //4
            //(grid.DataContext as ViewModel).TreeSizingBehavior = (GridPercentColumnSizingBehavior)(grid.DataContext as ViewModel).PercentWidthComboSelecIndex;
        }
    }
}
