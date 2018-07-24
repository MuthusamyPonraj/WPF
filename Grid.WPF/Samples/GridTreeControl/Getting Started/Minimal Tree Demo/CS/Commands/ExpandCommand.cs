using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Syncfusion.Windows.Controls.Grid;

namespace TreeGridMinimalSample
{
    public static class ExpandCommand
    {
        /// <summary>
        /// Initializes the <see cref="ExpandCommand"/> class.
        /// </summary>
        static ExpandCommand()
        {
            CommandManager.RegisterClassCommandBinding(typeof(GridTreeControl), new CommandBinding(ExpandAll, OnExecuteExpandAll, OnCanExecuteExpandAll));
        }

        public static RoutedCommand ExpandAll = new RoutedCommand("ExpandAll", typeof(GridTreeControl));

        /// <summary>
        /// Called when [execute expand all].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The <see cref="System.Windows.Input.ExecutedRoutedEventArgs"/> instance containing the event data.</param>
        private static void OnExecuteExpandAll(object sender, ExecutedRoutedEventArgs args)
        {
            GridTreeControl GTC = args.Source as GridTreeControl;
            GTC.ExpandAllNodes();
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