using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Syncfusion.Windows.Controls.Grid;
using System.Windows.Input;
using System.Windows;

namespace ColumnAutoSizingDemo
{
    public static class ColumnResizingCommand
    {
        /// <summary>
        /// Initializes the <see cref="ColumnResizingCommand"/> class.
        /// </summary>
        static ColumnResizingCommand()
        {
            CommandManager.RegisterClassCommandBinding(typeof(GridDataControl), new CommandBinding(ColumnResize, OnExecuteColumnResize, OnCanColumnResize));
        }

        public static RoutedCommand ColumnResize = new RoutedCommand("ColumnResize", typeof(GridDataControl));

        /// <summary>
        /// Called when [execute column resize].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The <see cref="System.Windows.Input.ExecutedRoutedEventArgs"/> instance containing the event data.</param>
        private static void OnExecuteColumnResize(object sender, ExecutedRoutedEventArgs args)
        {
            GridDataControl grid = args.Source as GridDataControl;
            var parameter = args.Parameter as MultiBindingStructure;
            if (grid != null && args.Parameter != null)
            {
                if (parameter.SelectedSizer == GridControlLengthUnitType.Star || parameter.SelectedSizer == GridControlLengthUnitType.Auto || parameter.SelectedSizer == GridControlLengthUnitType.None)
                {
                    Int32 rowValue = 0;
                    if (Int32.TryParse(parameter.width.ToString(), out rowValue))
                        grid.VisibleColumns[parameter.SelectedColumn].Width = new GridDataControlLength( parameter.width, parameter.SelectedSizer);
                    else
                        MessageBox.Show("Please Enter valid number in the TextBox");
                }
            }
        }

        /// <summary>
        /// Called when [can column resize].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The <see cref="System.Windows.Input.CanExecuteRoutedEventArgs"/> instance containing the event data.</param>
        private static void OnCanColumnResize(object sender, CanExecuteRoutedEventArgs args)
        {
            args.CanExecute = true;
        }
       
    }
}
