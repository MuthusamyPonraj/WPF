using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Syncfusion.Windows.Controls.Grid;
using Syncfusion.Windows.Controls.Grid.Converter;
using Syncfusion.XlsIO;
using System.Windows;
using System.Diagnostics;

namespace GridTree_ExcelExporting.Command
{
    public static class ExportCommand
    {
        static ExportCommand()
        {
            CommandManager.RegisterClassCommandBinding(typeof(GridTreeControl), new CommandBinding(ExportAllNodes, OnExport, CanExport));
        }
        public static RoutedCommand ExportAllNodes = new RoutedCommand("ExportAllNodes", typeof(GridTreeControl));

        private static void OnExport(object sender, ExecutedRoutedEventArgs args)
        {
            GridTreeControl treeGrid = args.Source as GridTreeControl;
            treeGrid.ExportToExcel("GridTreeContent.xls", Syncfusion.XlsIO.ExcelVersion.Excel97to2003);
            Process.Start("GridTreeContent.xls");
        }

        private static void CanExport(object sender, CanExecuteRoutedEventArgs args)
        {
            args.CanExecute = true;
        }
    }
}
