using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Syncfusion.Windows.Controls.Grid;

namespace LocalizationDemo
{
        public static class LocalizationCommand
        {
            /// <summary>
            /// Initializes the <see cref="LocalizationCommand"/> class.
            /// </summary>
            static LocalizationCommand()
            {
                CommandManager.RegisterClassCommandBinding(typeof(GridDataControl), new CommandBinding(PrintPreview, OnExecuteprint, OnCanExecuteprint));
            }

            public static RoutedCommand PrintPreview = new RoutedCommand("PrintPreview", typeof(GridDataControl));

            /// <summary>
            /// Called when [executeprint].
            /// </summary>
            /// <param name="sender">The sender.</param>
            /// <param name="args">The <see cref="System.Windows.Input.ExecutedRoutedEventArgs"/> instance containing the event data.</param>
            private static void OnExecuteprint(object sender, ExecutedRoutedEventArgs args)
            {
                GridDataControl gridDatacontrol = args.Source as GridDataControl;
                var window = gridDatacontrol.FindParentElementOfType<MainWindow>();
                gridDatacontrol.ShowPrintDialog((o) =>
                {
                    o.Owner = window;
                    o.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner;
                });
            }

            /// <summary>
            /// Called when [can executeprint].
            /// </summary>
            /// <param name="sender">The sender.</param>
            /// <param name="args">The <see cref="System.Windows.Input.CanExecuteRoutedEventArgs"/> instance containing the event data.</param>
            private static void OnCanExecuteprint(object sender, CanExecuteRoutedEventArgs args)
            {
                args.CanExecute = true;
            }
        }
    }
