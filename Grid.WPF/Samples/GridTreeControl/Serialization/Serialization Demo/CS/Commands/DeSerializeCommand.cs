using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Syncfusion.Windows.Controls.Grid;

namespace SerializationDemo
{
    public static class DeSerializeCommand
    {
        /// <summary>
        /// Initializes the <see cref="SerilizeCommand"/> class.
        /// </summary>
        static DeSerializeCommand()
        {
            CommandManager.RegisterClassCommandBinding(typeof(GridTreeControl), new CommandBinding(DeSerialize, OnExecuteDeSerialize, OnCanExecuteDeSerialize));
        }

        public static RoutedCommand DeSerialize = new RoutedCommand("Serialize", typeof(GridTreeControl));

        /// <summary>
        /// Called when [execute de serialize].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The <see cref="System.Windows.Input.ExecutedRoutedEventArgs"/> instance containing the event data.</param>
        private static void OnExecuteDeSerialize(object sender, ExecutedRoutedEventArgs args)
        {
            GridTreeControl GTC = args.Source as GridTreeControl;
            GTC.InternalGrid.CurrentCell.Deactivate();
            GTC.InternalGrid.Deserialize(LayoutControl.FindFile("Default.xml"));
            GTC.ExpandAllNodes();
        }

        /// <summary>
        /// Called when [can execute de serialize].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The <see cref="System.Windows.Input.CanExecuteRoutedEventArgs"/> instance containing the event data.</param>
        private static void OnCanExecuteDeSerialize(object sender, CanExecuteRoutedEventArgs args)
        {
            args.CanExecute = true;
        }
    }
}
