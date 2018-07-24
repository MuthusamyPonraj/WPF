using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Syncfusion.Windows.Controls.Grid;
using System.Windows.Media;

namespace ExportToPdfDemo_2010.Commands
{
    public static class GroupingCommand
    {
        /// <summary>
        /// Initializes the <see cref="GroupingCommand"/> class.
        /// </summary>
        static GroupingCommand()
        {
            CommandManager.RegisterClassCommandBinding(typeof(GridDataControl), new CommandBinding(GroupColumns, OnGrouped, Cangroup));
        }
        public static RoutedCommand GroupColumns = new RoutedCommand("GroupColumns", typeof(GridDataControl));

        /// <summary>
        /// Called when [exported].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The <see cref="System.Windows.Input.ExecutedRoutedEventArgs"/> instance containing the event data.</param>
        public static void OnGrouped(object sender, ExecutedRoutedEventArgs args)
        {
            GridDataControl gridDataControl = args.Source as GridDataControl;
            gridDataControl.Model.TableStyle.Borders.All = new System.Windows.Media.Pen(Brushes.Blue, 0);
            if (gridDataControl.GroupedColumns.Count > 0)
                gridDataControl.GroupedColumns.Clear();
            else
            {
                gridDataControl.GroupedColumns.Add(new GridDataGroupColumn() { ColumnName = "CustomerID" });
                gridDataControl.Model.Table.ExpandAllGroups();
            }
        }

        /// <summary>
        /// Determines whether this instance can export the specified sender.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The <see cref="System.Windows.Input.CanExecuteRoutedEventArgs"/> instance containing the event data.</param>
        public static void Cangroup(object sender, CanExecuteRoutedEventArgs args)
        {
            args.CanExecute = true;
        }
    }
}
