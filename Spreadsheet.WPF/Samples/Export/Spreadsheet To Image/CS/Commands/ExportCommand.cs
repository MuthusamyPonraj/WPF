using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Syncfusion.Windows.Controls.Spreadsheet;
using Syncfusion.XlsIO.Implementation;
using Syncfusion.XlsIO;
using System.Drawing.Imaging;

namespace SpreadsheetToImage.Commands
{
    public static class ExportCommand
    {
        static ExportCommand()
        {
            CommandManager.RegisterClassCommandBinding(typeof(SpreadsheetControl), new CommandBinding(ExportToImage, OnExecuteExportToImage, OnCanExecuteExportToImage));
            CommandManager.RegisterClassCommandBinding(typeof(SpreadsheetControl), new CommandBinding(ExportToMetafile, OnExecuteExportToMetafile, OnCanExecuteExportToMetafile));
        }

        #region ExportToImage
        public static RoutedCommand ExportToImage = new RoutedCommand("ExportToImage", typeof(SpreadsheetControl));

        private static void OnExecuteExportToImage(object sender, ExecutedRoutedEventArgs args)
        {
            SpreadsheetControl spreadsheetControl = args.Source as SpreadsheetControl;
            IWorksheet sheet = spreadsheetControl.ExcelProperties.WorkBook.Worksheets[0];
            sheet.UsedRangeIncludesFormatting = false;
            int lastRow = sheet.UsedRange.LastRow + 1;
            int lastColumn = sheet.UsedRange.LastColumn + 1;
            System.Drawing.Image img = sheet.ConvertToImage(1, 1, lastRow, lastColumn, ImageType.Bitmap, null);
            img.Save("Sample.png", ImageFormat.Png);
            System.Diagnostics.Process.Start("Sample.png");
        }

        private static void OnCanExecuteExportToImage(object sender, CanExecuteRoutedEventArgs args)
        {
            args.CanExecute = true;
        }
        #endregion

        #region ExportToMetafile
        public static RoutedCommand ExportToMetafile = new RoutedCommand("ExportToMetafile", typeof(SpreadsheetControl));

        private static void OnExecuteExportToMetafile(object sender, ExecutedRoutedEventArgs args)
        {
            SpreadsheetControl spreadsheetControl = args.Source as SpreadsheetControl;
            IWorksheet sheet = spreadsheetControl.ExcelProperties.WorkBook.Worksheets[0];
            sheet.UsedRangeIncludesFormatting = false;
            int lastRow = sheet.UsedRange.LastRow + 1;
            int lastColumn = sheet.UsedRange.LastColumn + 1;
            System.Drawing.Image img = sheet.ConvertToImage(1, 1, lastRow, lastColumn, ImageType.Metafile, null);
            img.Save("Sample1.emf", ImageFormat.Emf);
            System.Diagnostics.Process.Start("Sample1.emf");
        }

        private static void OnCanExecuteExportToMetafile(object sender, CanExecuteRoutedEventArgs args)
        {
            args.CanExecute = true;
        }
        #endregion
    }
}
