using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Syncfusion.Windows.Controls.Grid;
using System.Windows.Input;

namespace TreeGridInDepth
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
            DateTime start = DateTime.Now;
            GridTreeControl GTC = args.Source as GridTreeControl;
            GTC.ExpandAllNodes();
            (GTC.DataContext as ViewModel).ExpandTime = string.Format("Expanded time: {0:0.0000} secs", DateTime.Now.Subtract(start).TotalSeconds);
            (GTC.DataContext as ViewModel).CollapseTime = string.Empty;
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
