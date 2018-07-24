using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Syncfusion.Windows.Controls.Grid;
using System.Windows.Media;

namespace ExportToPdfDemo_2010.Commands
{
   public static class BordersCommands
    {
        public static bool HasBorder = true;
        /// <summary>
        /// Initializes the <see cref="BordersCommands"/> class.
        /// </summary>
        static BordersCommands()
        {
            CommandManager.RegisterClassCommandBinding(typeof(GridDataControl), new CommandBinding(BordersCommand, OnBordersApplied, CanApplyBorder));
        }
        public static RoutedCommand BordersCommand = new RoutedCommand("BordersCommand", typeof(GridDataControl));

        /// <summary>
        /// Called when [exported].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The <see cref="System.Windows.Input.ExecutedRoutedEventArgs"/> instance containing the event data.</param>
        public static void OnBordersApplied(object sender, ExecutedRoutedEventArgs args)
        {
            GridDataControl gridDataControl = args.Source as GridDataControl;
            if (HasBorder)
            {
                gridDataControl.Model.TableStyle.Borders.All = new Pen(Brushes.Transparent, 0);
                HasBorder = false;
            }
            else
            {
                gridDataControl.Model.TableStyle.Borders.Right = new Pen(Brushes.LightGray, 0.7);
                gridDataControl.Model.TableStyle.Borders.Bottom = new Pen(Brushes.LightGray, 0.7);
                HasBorder = true;
            }
            gridDataControl.Model.Grid.InvalidateCells();
        }

        /// <summary>
        /// Determines whether this instance can export the specified sender.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The <see cref="System.Windows.Input.CanExecuteRoutedEventArgs"/> instance containing the event data.</param>
        public static void CanApplyBorder(object sender, CanExecuteRoutedEventArgs args)
        {
            args.CanExecute = true;
        }
    }
}
