using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Syncfusion.Windows.Controls.Grid;
using Syncfusion.Windows.Controls.Grid.Converter;
using Syncfusion.Pdf;
using Microsoft.Win32;
using System.IO;
using System.Diagnostics;

namespace ExportToPdfDemo_2010.Commands
{
    public static class ExportCommands
    {
        /// <summary>
        /// Initializes the <see cref="ExportCommands"/> class.
        /// </summary>
        static ExportCommands()
        {
            CommandManager.RegisterClassCommandBinding(typeof(GridDataControl), new CommandBinding(ExportToPdf, OnExported, CanExport));
        }
        public static RoutedCommand ExportToPdf = new RoutedCommand("ExportToPdf", typeof(GridDataControl));

        /// <summary>
        /// Called when [exported].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The <see cref="System.Windows.Input.ExecutedRoutedEventArgs"/> instance containing the event data.</param>
        public static void OnExported(object sender, ExecutedRoutedEventArgs args)
        {
            SaveFileDialog sfd = new SaveFileDialog
                   {
                       DefaultExt = ".pdf",
                       Filter = "Adobe PDF Files(*.pdf)|*.pdf",
                       FilterIndex = 1
                   };

            PdfDocument document = new PdfDocument();
            if (sfd.ShowDialog() == true)
            {
                using (Stream stream = sfd.OpenFile())
                {
                    GridDataControl grid = args.Source as GridDataControl;
                    document = grid.Model.ExportToPdfGridDocument(GridRangeInfo.Table());
                    document.Save(stream);
                    Process.Start(sfd.FileName);
                }
            }
        }

        /// <summary>
        /// Determines whether this instance can export the specified sender.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The <see cref="System.Windows.Input.CanExecuteRoutedEventArgs"/> instance containing the event data.</param>
        public static void CanExport(object sender, CanExecuteRoutedEventArgs args)
        {
            args.CanExecute = true;
        }
    }
}
