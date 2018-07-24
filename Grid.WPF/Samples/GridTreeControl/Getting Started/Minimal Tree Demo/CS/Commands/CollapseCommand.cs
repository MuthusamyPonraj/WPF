using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Syncfusion.Windows.Controls.Grid;

namespace TreeGridMinimalSample
{
    public static class CollapseCommand
    {
        static CollapseCommand()
        {
            CommandManager.RegisterClassCommandBinding(typeof(GridTreeControl), new CommandBinding(CollapseAll, OnExecuteCollapseAll, OnCanExecuteCollapseAll));
        }

        public static RoutedCommand CollapseAll = new RoutedCommand("CollapseAll", typeof(GridTreeControl));

        /// <summary>
        /// Called when [execute collapse all].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The <see cref="System.Windows.Input.ExecutedRoutedEventArgs"/> instance containing the event data.</param>
        private static void OnExecuteCollapseAll(object sender, ExecutedRoutedEventArgs args)
        {
            GridTreeControl GTC = args.Source as GridTreeControl;
            GTC.CollapseAllNodes();
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
