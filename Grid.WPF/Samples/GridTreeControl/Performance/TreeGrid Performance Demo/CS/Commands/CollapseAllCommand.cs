using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Syncfusion.Windows.Controls.Grid;

namespace TreeGridInDepth
{
    public static class CollapseCommand
    {
        /// <summary>
        /// Initializes the <see cref="CollapseCommand"/> class.
        /// </summary>
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
            DateTime start = DateTime.Now;
            GridTreeControl GTC = args.Source as GridTreeControl;
            GTC.CollapseAllNodes();
            (GTC.DataContext as ViewModel).CollapseTime = string.Format("Collapsed time: {0:0.0000} secs", DateTime.Now.Subtract(start).TotalSeconds);
            (GTC.DataContext as ViewModel).ExpandTime = string.Empty;
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
