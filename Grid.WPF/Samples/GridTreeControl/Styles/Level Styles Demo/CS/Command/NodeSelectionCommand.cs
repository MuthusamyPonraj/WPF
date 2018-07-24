using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Syncfusion.Windows.Controls.Grid;
using System.Windows.Input;
using System.Windows.Controls;

namespace LevelStylesDemo
{
    public static class NodeSelectionCommand
    {
        /// <summary>
        /// Initializes the <see cref="NodeSelectionCommand"/> class.
        /// </summary>
        static NodeSelectionCommand()
        {
            CommandManager.RegisterClassCommandBinding(typeof(GridTreeControl), new CommandBinding(CheckBoxSelection, OnExecuteCheckBoxSelection, OnCanExecuteCheckBoxSelection));
        }

        public static RoutedCommand CheckBoxSelection = new RoutedCommand("CheckBoxSelection", typeof(GridTreeControl));

        /// <summary>
        /// Called when [execute check box selection].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The <see cref="System.Windows.Input.ExecutedRoutedEventArgs"/> instance containing the event data.</param>
        private static void OnExecuteCheckBoxSelection(object sender, ExecutedRoutedEventArgs args)
        {
            GridTreeControl GTC = sender as GridTreeControl;
            CheckBox checkbox = args.Parameter as CheckBox;
            if (GTC == null)
                return;
            GTC.SelectedNodes.Clear();
            GTC.EnableNodeSelection = checkbox.IsChecked.Value;
            if (!(bool)checkbox.IsChecked)
            {   //reset standard selection support as desired.
                GTC.Model.Options.AllowSelection = GridSelectionFlags.Any;
                GTC.Model.Options.ListBoxSelectionMode = GridSelectionMode.None;
            }
            else
            {   //clear any standard selections...
                GTC.Model.SelectedRanges.Clear();

            }
            GTC.InternalGrid.UnloadArrangedCells();
        }

        /// <summary>
        /// Called when [can execute check box selection].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The <see cref="System.Windows.Input.CanExecuteRoutedEventArgs"/> instance containing the event data.</param>
        private static void OnCanExecuteCheckBoxSelection(object sender, CanExecuteRoutedEventArgs args)
        {
            args.CanExecute = true;
        }
    }
}