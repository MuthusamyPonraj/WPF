using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Syncfusion.Windows.Controls.Grid;

namespace GridDataControlSerializationDemo
{
    public static class SerilizeCommand
    {
        /// <summary>
        /// Initializes the <see cref="SerilizeCommand"/> class.
        /// </summary>
        static SerilizeCommand()
        {
            CommandManager.RegisterClassCommandBinding(typeof(GridDataControl), new CommandBinding(Serialize, OnExecuteSerialize, OnCanExecuteSerialize));
        }

        public static RoutedCommand Serialize = new RoutedCommand("Serialize", typeof(GridDataControl));

        /// <summary>
        /// Called when [execute serialize].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The <see cref="System.Windows.Input.ExecutedRoutedEventArgs"/> instance containing the event data.</param>
        private static void OnExecuteSerialize(object sender, ExecutedRoutedEventArgs args)
        {
            GridDataControl GDC = args.Source as GridDataControl;
            GDC.Model.Serialize("newChanges.xml");
        }

        /// <summary>
        /// Called when [can execute serialize].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The <see cref="System.Windows.Input.CanExecuteRoutedEventArgs"/> instance containing the event data.</param>
        private static void OnCanExecuteSerialize(object sender, CanExecuteRoutedEventArgs args)
        {
            args.CanExecute = true;
        }
    }
}
