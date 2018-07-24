using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Syncfusion.Windows.Controls.Grid;
using System.Windows.Controls;
using System.Windows.Media;

namespace LevelStylesDemo
{
    public static class ApplyStyleCommand
    {
        /// <summary>
        /// Initializes the <see cref="ApplyStyleCommand"/> class.
        /// </summary>
        static ApplyStyleCommand()
        {
            CommandManager.RegisterClassCommandBinding(typeof(GridTreeControl), new CommandBinding(ApplyStyle, OnExecuteApplyStyle, OnCanExecuteApplyStyle));
        }

        public static RoutedCommand ApplyStyle = new RoutedCommand("ApplyStyle", typeof(GridTreeControl));

        /// <summary>
        /// Called when [execute apply style].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The <see cref="System.Windows.Input.ExecutedRoutedEventArgs"/> instance containing the event data.</param>
        private static void OnExecuteApplyStyle(object sender, ExecutedRoutedEventArgs args)
        {
            CheckBox checkbox = args.Parameter as CheckBox;
            GridTreeControl treeGrid = sender as GridTreeControl;
            if (checkbox.IsChecked.Value)
            {
                //set some miscellaneous level colors so they are easily seen (just set up to 6 levels...
                byte k = 150;// 100;// 250;
                byte k1 = 250;// 125;
                for (int i = -1; i < 7; ++i)
                {
                    GridStyleInfo style = new GridStyleInfo();
                    style.Background = new SolidColorBrush(Color.FromArgb(255, 239, k1, k));
                    treeGrid.LevelStyles.Add(style);
                    k += 15;
                    k1 -= 15;
                }
            }
            else
            {
                treeGrid.LevelStyles.Clear();
            }
            treeGrid.InternalGrid.InvalidateCells();
        }

        /// <summary>
        /// Called when [can execute apply style].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The <see cref="System.Windows.Input.CanExecuteRoutedEventArgs"/> instance containing the event data.</param>
        private static void OnCanExecuteApplyStyle(object sender, CanExecuteRoutedEventArgs args)
        {
            args.CanExecute = true;
        }
    }
}
