using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using Syncfusion.Windows.Controls.Grid;
using System.Collections.ObjectModel;

namespace ColumnChooserCustomization
{
    #region ColumnChooserCommand

    public class ColumnChooserBehavior : ColumnChooserCommandBehaviour<GridDataVisibleColumns>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ColumnChooserBehavior"/> class.
        /// </summary>
        public ColumnChooserBehavior()
            : base(Validate)
        { }

        private static GridDataVisibleColumns Validate(object s, RoutedEventArgs args)
        {
            GridDataControl gridData = Application.Current.MainWindow.FindName("grid") as GridDataControl;
            var visibleColumns = gridData.VisibleColumns;
            var totalVisibleColumns = gridData.Model.GetVisibleColumns();
            ObservableCollection<ColumnChooserItems> totalColumns = GetColumnsDetails(totalVisibleColumns, visibleColumns);
            ColumnChooserViewModel viewModel = new ColumnChooserViewModel(totalColumns);
            ColumnChooserWindow ColumnChooserView = new ColumnChooserWindow(viewModel);
            ColumnChooserView.Owner = Application.Current.MainWindow;

            if ((bool)ColumnChooserView.ShowDialog())
            {
                ClickOKButton(viewModel.ColumnCollection, gridData);
            }
            return null;
        }

        /// <summary>
        /// Clicks the OK button.
        /// </summary>
        /// <param name="ColumnCollection">The column collection.</param>
        /// <param name="dataGrid">The data grid.</param>
        public static void ClickOKButton(ObservableCollection<ColumnChooserItems> ColumnCollection,GridDataControl dataGrid)
        {
            foreach (var item in ColumnCollection)
            {
                var isFound = dataGrid.VisibleColumns.FirstOrDefault(v => v.MappingName == item.Name) != null;
                if (!isFound)
                {
                    if (item.IsChecked == true)
                    {
                        dataGrid.VisibleColumns.Add(new GridDataVisibleColumn() { MappingName = item.Name });
                    }
                }
                else
                {
                    if (item.IsChecked == false)
                    {
                        var column = dataGrid.VisibleColumns.Where(c => c.MappingName == item.Name).FirstOrDefault();
                        dataGrid.VisibleColumns.Remove(column);
                    }
                }
            }
        }

        /// <summary>
        /// Gets the columns details.
        /// </summary>
        /// <param name="totalVisibleColumns">The total visible columns.</param>
        /// <param name="visibleColumns">The visible columns.</param>
        /// <returns></returns>
        public static ObservableCollection<ColumnChooserItems> GetColumnsDetails(GridDataVisibleColumns totalVisibleColumns, GridDataVisibleColumns visibleColumns)
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

    public class ColumnChooserCommand : ColumnChooserCommand<GridDataVisibleColumns, ColumnChooserBehavior>
    { }

    #endregion
}
