using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Syncfusion.Windows.Controls.Grid;
using System.Windows.Media;

namespace ExportToPdfDemo_2010.Commands
{
    public static class StyleCommand
    {
        /// <summary>
        /// Initializes the <see cref="StyleCommand"/> class.
        /// </summary>
        static StyleCommand()
        {
            CommandManager.RegisterClassCommandBinding(typeof(GridDataControl), new CommandBinding(ApplyStyle, OnStyleApplied, CanApplyStyle));
        }
        public static RoutedCommand ApplyStyle = new RoutedCommand("ApplyStyle", typeof(GridDataControl));

        static Brush DefaultAlternateRowbackground;
        static bool IsAppliedAlready = false;
        /// <summary>
        /// Called when [exported].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The <see cref="System.Windows.Input.ExecutedRoutedEventArgs"/> instance containing the event data.</param>
        public static void OnStyleApplied(object sender, ExecutedRoutedEventArgs args)
        {
            GridDataControl gridDataControl = args.Source as GridDataControl;
            if (!IsAppliedAlready)
            {
                DefaultAlternateRowbackground = gridDataControl.AlternatingRowBackground;
                gridDataControl.AlternatingRowBackground = Brushes.Gainsboro;
                IsAppliedAlready = true;
            }
            else
            {
                gridDataControl.AlternatingRowBackground = DefaultAlternateRowbackground;
                IsAppliedAlready = false;
            }
        }

        /// <summary>
        /// Determines whether this instance can export the specified sender.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The <see cref="System.Windows.Input.CanExecuteRoutedEventArgs"/> instance containing the event data.</param>
        public static void CanApplyStyle(object sender, CanExecuteRoutedEventArgs args)
        {
            args.CanExecute = true;
        }
    }
}
