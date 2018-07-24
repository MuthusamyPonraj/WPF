using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Syncfusion.Windows.Controls.Grid.Converter;
using Syncfusion.Windows.Controls.Grid;

namespace NestedChildExcelExportDemo
{
    /// <summary>
    /// Code for Collapse All NestedTable
    /// </summary>
    public class CollapseAllCommand
    {
        /// <summary>
        /// Initializes the <see cref="CollapseAllCommand"/> class.
        /// </summary>
        static CollapseAllCommand()
        {
            //Registering the Collapse All Command
            CommandManager.RegisterClassCommandBinding(typeof(GridDataControl), new CommandBinding(CollapseAll, OnExecuteCollapseAll, OnCanExecuteCollapseAll));
        }

        public static RoutedCommand CollapseAll = new RoutedCommand("CollapseAll", typeof(GridDataControl));

        /// <summary>
        /// Called when [execute collapse all].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The <see cref="System.Windows.Input.ExecutedRoutedEventArgs"/> instance containing the event data.</param>
        private static void OnExecuteCollapseAll(object sender, ExecutedRoutedEventArgs args)
        {
            GridDataControl grid = args.Source as GridDataControl;
            if (grid.Model.Table.HasNestedTables)
            {
                grid.Model.Table.CollapseAll();
            }
        }

        /// <summary>
        /// Called when [can execute collapse all].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The <see cref="System.Windows.Input.CanExecuteRoutedEventArgs"/> instance containing the event data.</param>
        private static void OnCanExecuteCollapseAll(object sender, CanExecuteRoutedEventArgs args)
        {
            args.CanExecute = true;
        }
    }
}
