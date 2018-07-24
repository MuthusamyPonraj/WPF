using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Syncfusion.Windows.Controls.Grid;
using System.Windows.Input;
using System.IO;

namespace SerializationDemo
{
    public static class LoadNewChangesCommand
    {
        /// <summary>
        /// Initializes the <see cref="LoadNewChangesCommand"/> class.
        /// </summary>
        static LoadNewChangesCommand()
        {
            CommandManager.RegisterClassCommandBinding(typeof(GridTreeControl), new CommandBinding(LoadNewChanges, OnExecuteLoadNewChanges, OnCanExecuteLoadNewChanges));
        }

        public static RoutedCommand LoadNewChanges = new RoutedCommand("LoadNewChanges", typeof(GridTreeControl));

        /// <summary>
        /// <summary>
        /// Called when [execute load new changes].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The <see cref="System.Windows.Input.ExecutedRoutedEventArgs"/> instance containing the event data.</param>
        private static void OnExecuteLoadNewChanges(object sender, ExecutedRoutedEventArgs args)
        {
            GridTreeControl GTC = args.Source as GridTreeControl;
            GTC.InternalGrid.CurrentCell.Deactivate();
            GTC.InternalGrid.Deserialize("newChanges.xml");
            GTC.ExpandAllNodes();
        }

        /// <summary>
        /// Called when [can execute load new changes].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The <see cref="System.Windows.Input.CanExecuteRoutedEventArgs"/> instance containing the event data.</param>
        private static void OnCanExecuteLoadNewChanges(object sender, CanExecuteRoutedEventArgs args)
        {
            if (File.Exists("newChanges.xml"))
                args.CanExecute = true;
            else
                args.CanExecute = false;
        }
    }
}

