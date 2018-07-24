using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Syncfusion.Windows.Controls.Grid.Converter;
using Syncfusion.Windows.Controls.Grid;

namespace GroupingExcelExportDemo
{
    /// <summary>
    /// Code for Expand All groups
    /// </summary>
    public class ExpandAllCommand
    {
        /// <summary>
        /// Initializes the <see cref="ExpandAllCommand"/> class.
        /// </summary>
        static ExpandAllCommand()
        {
            //Registering Expand All Command
            CommandManager.RegisterClassCommandBinding(typeof(GridDataControl), new CommandBinding(ExpandAll, OnExecuteExpandAll, OnCanExecuteExpandAll));
        }

        public static RoutedCommand ExpandAll = new RoutedCommand("ExpandAll", typeof(GridDataControl));

        /// <summary>
        /// Called when [execute expand all].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The <see cref="System.Windows.Input.ExecutedRoutedEventArgs"/> instance containing the event data.</param>
        private static void OnExecuteExpandAll(object sender, ExecutedRoutedEventArgs args)
        {
            GridDataControl grid = args.Source as GridDataControl;
            if (grid.Model.Table.HasGroups)
            {
                grid.Model.Table.ExpandAllGroups();
            }
        }

        /// <summary>
        /// Called when [can execute expand all].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The <see cref="System.Windows.Input.CanExecuteRoutedEventArgs"/> instance containing the event data.</param>
        private static void OnCanExecuteExpandAll(object sender, CanExecuteRoutedEventArgs args)
        {
            args.CanExecute = true;
        }
    }
}
