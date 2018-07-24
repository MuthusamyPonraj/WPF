using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Syncfusion.Windows.Controls.Grid;
using System.Windows.Input;
using System.Windows;

namespace BasicGroupingDemo
{
    public static class GroupingColumnCommand
    {
        /// <summary>
        /// Initializes the <see cref="ColumnResizingCommand"/> class.
        /// </summary>
        static GroupingColumnCommand()
        {
            CommandManager.RegisterClassCommandBinding(typeof(GridDataControl), new CommandBinding(GroupingColumn, OnExecuteGroupingColumn, OnCanGroupingColumn));
        }

        public static RoutedCommand GroupingColumn = new RoutedCommand("GroupingColumn", typeof(GridDataControl));

        /// <summary>
        /// Called when [execute column resize].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The <see cref="System.Windows.Input.ExecutedRoutedEventArgs"/> instance containing the event data.</param>
        private static void OnExecuteGroupingColumn(object sender, ExecutedRoutedEventArgs args)
        {
            var Grid = sender as GridDataControl;
            bool Contains = false;
            if (Grid != null)
            {
                var vis = Grid.VisibleColumns.Where(o => o.MappingName == "Name").FirstOrDefault();
                if (vis.AllowGroup)
                {
                    foreach (GridDataGroupColumn column in Grid.GroupedColumns)
                    {
                        if (column.ColumnName == "Name")
                            Contains = true;
                    }
                    if (Contains)
                    {
                        var ungroup = Grid.GroupedColumns.Where(o => o.ColumnName == "Name").FirstOrDefault();
                        Grid.GroupedColumns.Remove(ungroup);
                    }
                    else
                    {
                        var group = new GridDataGroupColumn() { ColumnName = "Name" };
                        Grid.GroupedColumns.Add(group);
                    }
                }
            }
        }

        /// <summary>
        /// Called when [can column resize].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The <see cref="System.Windows.Input.CanExecuteRoutedEventArgs"/> instance containing the event data.</param>
        private static void OnCanGroupingColumn(object sender, CanExecuteRoutedEventArgs args)
        {
            args.CanExecute = true;
        }
       
    }
}
