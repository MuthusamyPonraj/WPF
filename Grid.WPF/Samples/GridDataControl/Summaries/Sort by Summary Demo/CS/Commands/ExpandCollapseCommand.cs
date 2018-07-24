using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Syncfusion.Windows.Controls.Grid;
using System.Windows.Input;

namespace SortbySummaryDemo
{
    public static class ExpandCollapseCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExpandCommand"/> class.
        /// </summary>
        static ExpandCollapseCommand()
        {
            CommandManager.RegisterClassCommandBinding(typeof(GridDataControl), new CommandBinding(ExpandCollapse, OnExecuteExpand, OnCanExecuteExpand));
        }

        public static RoutedCommand ExpandCollapse = new RoutedCommand("Expand", typeof(GridDataControl));

        /// <summary>
        /// Called when [execute expand].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The <see cref="System.Windows.Input.ExecutedRoutedEventArgs"/> instance containing the event data.</param>
        public static void OnExecuteExpand(object sender, ExecutedRoutedEventArgs args)
        {
            GridDataControl GDC = args.Source as GridDataControl;
            if ((string)args.Parameter == "Expand")
            {
                GDC.Model.Table.ExpandAllGroups();
            }
            else if (((string)args.Parameter) == "Collapse")
            {
                GDC.Model.Table.CollapseAllGroups();
            }
        }

        /// <summary>
        /// Called when [can execute expand].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The <see cref="System.Windows.Input.CanExecuteRoutedEventArgs"/> instance containing the event data.</param>
        private static void OnCanExecuteExpand(object sender, CanExecuteRoutedEventArgs args)
        {
            args.CanExecute = true;
        }
    }
}
