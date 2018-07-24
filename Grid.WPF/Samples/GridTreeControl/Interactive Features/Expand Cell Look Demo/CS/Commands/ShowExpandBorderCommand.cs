using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Syncfusion.Windows.Controls.Grid;
using System.Windows.Controls;

namespace ExpandCellLook
{
   public static class ShowExpandBorderCommand
    {
        /// <summary>
        /// Initializes the <see cref="ShowExpandBorderCommand"/> class.
        /// </summary>
        static ShowExpandBorderCommand()
        {
            CommandManager.RegisterClassCommandBinding(typeof(GridTreeControl), new CommandBinding(ShowExpandColumnBordersCommand, OnExecuteShowExpandColumnBordersCommand, OnCanExecuteShowExpandColumnBordersCommand));
        }

        public static RoutedCommand ShowExpandColumnBordersCommand = new RoutedCommand("ShowExpandColumnBordersCommand", typeof(GridTreeControl));

        /// <summary>
        /// Called when [execute show expand column borders command].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The <see cref="System.Windows.Input.ExecutedRoutedEventArgs"/> instance containing the event data.</param>
        private static void OnExecuteShowExpandColumnBordersCommand(object sender, ExecutedRoutedEventArgs args)
        {
            CheckBox comboBox = args.Parameter as CheckBox;
            var treeGrid = sender as GridTreeControl;
            if (comboBox != null)
            {
                treeGrid.InternalGrid.ShowExpandColumnBorders = comboBox.IsChecked.Value;
            }
        }

        /// <summary>
        /// Called when [can execute show expand column borders command].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The <see cref="System.Windows.Input.CanExecuteRoutedEventArgs"/> instance containing the event data.</param>
        private static void OnCanExecuteShowExpandColumnBordersCommand(object sender, CanExecuteRoutedEventArgs args)
        {
            args.CanExecute = true;
        }
    }
}
