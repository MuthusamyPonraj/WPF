using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Syncfusion.Windows.Controls.Spreadsheet;
using Syncfusion.XlsIO.Implementation;
using Syncfusion.XlsIO;
using Syncfusion.ExcelToPdfConverter;
using Syncfusion.Pdf;

namespace SpreadsheetToPDF.Commands
{
    public static class ExportCommand
    {
        static ExportCommand()
        {
            CommandManager.RegisterClassCommandBinding(typeof(SpreadsheetControl), new CommandBinding(ExportToPDF, OnExecuteExportToPDF, OnCanExecuteExportToPDF));
        }

        #region ExportToPDF
        public static RoutedCommand ExportToPDF = new RoutedCommand("ExportToPDF", typeof(SpreadsheetControl));

        private static void OnExecuteExportToPDF(object sender, ExecutedRoutedEventArgs args)
        {
            SpreadsheetControl spreadsheetControl = args.Source as SpreadsheetControl;
            ExcelToPdfConverter converter = new ExcelToPdfConverter(spreadsheetControl.ExcelProperties.WorkBook);
            //Intialize the PdfDocument
            PdfDocument pdfDoc = new PdfDocument();

            //Intialize the ExcelToPdfConverter Settings
            ExcelToPdfConverterSettings settings = new ExcelToPdfConverterSettings();
            if (args.Parameter != null)
            {
                string layoutOption = args.Parameter.ToString();
                if (layoutOption == "NoScaling")
                    settings.LayoutOptions = LayoutOptions.NoScaling;
                else if (layoutOption == "FitAllRowsOnOnePage")
                    settings.LayoutOptions = LayoutOptions.FitAllRowsOnOnePage;
                else if (layoutOption == "FitAllColumnsOnOnePage")
                    settings.LayoutOptions = LayoutOptions.FitAllColumnsOnOnePage;
                else
                    settings.LayoutOptions = LayoutOptions.FitSheetOnOnePage;
            }
            //Assign the PdfDocument to the templateDocument property of ExcelToPdfConverterSettings
            settings.TemplateDocument = pdfDoc;
            settings.DisplayGridLines = GridLinesDisplayStyle.Invisible;

            //Convert Excel Document into PDF document
            pdfDoc = converter.Convert(settings);

            //Save the PDF file
            pdfDoc.Save("Sample.pdf");

            System.Diagnostics.Process.Start("Sample.pdf");
        }

        private static void OnCanExecuteExportToPDF(object sender, CanExecuteRoutedEventArgs args)
        {
            args.CanExecute = true;
        }
        #endregion
    }
}
