using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using Syncfusion.Windows.Controls.Grid;
using System.Collections.ObjectModel;

namespace ColumnChooserDemo
{
    #region ColumnChooserCommand

    public class ColumnChooserBehavior : ColumnChooserCommandBehaviour<object>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ColumnChooserBehavior"/> class.
        /// </summary>
        public ColumnChooserBehavior()
            : base((s, e) =>
            {
                GridTreeControl treeGrid = Application.Current.MainWindow.FindName("treeGrid") as GridTreeControl;
                var visibleColumns = treeGrid.Columns;
                var totalVisibleColumns = new ObservableCollection<GridTreeColumn>(treeGrid.InternalGrid.GetVisibleColumns());
                ObservableCollection<ColumnChooserItems> totalColumns = GetColumnsDetails(totalVisibleColumns, visibleColumns);
                ColumnChooserViewModel viewModel = new ColumnChooserViewModel(totalColumns);
                ColumnChooserWindow ColumnChooserView = new ColumnChooserWindow(viewModel);
                ColumnChooserView.Owner = Application.Current.MainWindow;

                if ((bool)ColumnChooserView.ShowDialog())
                {
                    ClickOKButton(viewModel.ColumnCollection, treeGrid);
                }
                return null;
            })
        { }

        /// <summary>
        /// Clicks the OK button.
        /// </summary>
        /// <param name="ColumnCollection">The column collection.</param>
        /// <param name="treeGrid">The tree grid.</param>
        public static void ClickOKButton(ObservableCollection<ColumnChooserItems> ColumnCollection, GridTreeControl treeGrid)
        {
            foreach (var item in ColumnCollection)
            {
                var isFound = treeGrid.Columns.FirstOrDefault(v => v.MappingName == item.Name) != null;
                if (!isFound)
                {
                    if (item.IsChecked == true)
                    {
                        treeGrid.Columns.Add(new GridTreeColumn() { MappingName = item.Name, StyleInfo = new GridStyleInfo() });
                    }
                }
                else
                {
                    if (item.IsChecked == false)
                    {
                        var column = treeGrid.Columns.Where(c => c.MappingName == item.Name).FirstOrDefault();
                        treeGrid.Columns.Remove(column);
                    }
                }
            }
            treeGrid.InternalGrid.PopulateGridNodes(false, true);
            treeGrid.InternalGrid.InvalidateCells();
        }

        /// <summary>
        /// Gets the columns details.
        /// </summary>
        /// <param name="totalVisibleColumns">The total visible columns.</param>
        /// <param name="visibleColumns">The visible columns.</param>
        /// <returns></returns>
        public static ObservableCollection<ColumnChooserItems> GetColumnsDetails(ObservableCollection<GridTreeColumn> totalVisibleColumns, ObservableCollection<GridTreeColumn> visibleColumns)
        {
            ObservableCollection<ColumnChooserItems> totalColumns = new ObservableCollection<ColumnChooserItems>();
            foreach (var actualColumn in totalVisibleColumns)
            {
                ColumnChooserItems item = new ColumnChooserItems();
                var isFound = visibleColumns.FirstOrDefault(v => v.MappingName == actualColumn.MappingName) != null;
                if (!isFound)
                {
                    item.IsChecked = false;
                    item.Name = actualColumn.MappingName;
                }
                else
                {
                    item.IsChecked = true;
                    item.Name = actualColumn.MappingName;
                }
                totalColumns.Add(item);
            }
            return totalColumns;
        }
    }

    public class ColumnChooserCommand : ColumnChooserCommand<object, ColumnChooserBehavior>
    { }

    #endregion
}
