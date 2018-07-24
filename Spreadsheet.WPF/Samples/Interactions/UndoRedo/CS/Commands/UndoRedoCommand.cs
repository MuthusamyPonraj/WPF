using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Syncfusion.Windows.Controls.Spreadsheet;

namespace UndoRedoDemo.Commands
{
   public static class UndoRedoCommand
    {
       static UndoRedoCommand()
       {
           CommandManager.RegisterClassCommandBinding(typeof(SpreadsheetControl),new CommandBinding(UndoCommand,OnExecuteUndo,OnCanExecuteUndo));
           CommandManager.RegisterClassCommandBinding(typeof(SpreadsheetControl), new CommandBinding(RedoCommand, OnExecuteRedo, OnCanExecuteRedo));
           CommandManager.RegisterClassCommandBinding(typeof(SpreadsheetControl), new CommandBinding(BeginTransCommand, OnExecuteBeginTrans, OnCanExecuteBeginTrans));
           CommandManager.RegisterClassCommandBinding(typeof(SpreadsheetControl), new CommandBinding(CommitTransCommand, OnExecuteCommitTrans, OnCanExecuteCommitTrans));
           CommandManager.RegisterClassCommandBinding(typeof(SpreadsheetControl), new CommandBinding(ClearCommand, OnExecuteClear, OnCanExecuteClear));
       }

       public static RoutedCommand UndoCommand = new RoutedCommand("UndoCommand", typeof(SpreadsheetControl));
       public static RoutedCommand RedoCommand = new RoutedCommand("RedoCommand", typeof(SpreadsheetControl));
       public static RoutedCommand BeginTransCommand = new RoutedCommand("BeginTransCommand", typeof(SpreadsheetControl));
       public static RoutedCommand CommitTransCommand = new RoutedCommand("CommitTransCommand", typeof(SpreadsheetControl));
       public static RoutedCommand ClearCommand = new RoutedCommand("ClearCommand", typeof(SpreadsheetControl));

       private static void OnExecuteUndo(object sender, ExecutedRoutedEventArgs args)
       {
           if (!(sender as SpreadsheetControl).GridProperties.CurrentExcelGridModel.CommandStack.InTransaction)
               (sender as SpreadsheetControl).GridProperties.CurrentExcelGridModel.CommandStack.Undo();
       }

       private static void OnCanExecuteUndo(object sender, CanExecuteRoutedEventArgs args)
       {
           args.CanExecute = true;
       }


       private static void OnExecuteRedo(object sender, ExecutedRoutedEventArgs args)
       {
           if (!(sender as SpreadsheetControl).GridProperties.CurrentExcelGridModel.CommandStack.InTransaction)
               (sender as SpreadsheetControl).GridProperties.CurrentExcelGridModel.CommandStack.Redo();
       }

       private static void OnCanExecuteRedo(object sender, CanExecuteRoutedEventArgs args)
       {
           args.CanExecute = true;
       }

       private static void OnExecuteBeginTrans(object sender, ExecutedRoutedEventArgs args)
       {
           (sender as SpreadsheetControl).GridProperties.CurrentExcelGridModel.CommandStack.BeginTrans("Transaction-Begin");
       }

       private static void OnCanExecuteBeginTrans(object sender, CanExecuteRoutedEventArgs args)
       {
           args.CanExecute = true;
       }


       private static void OnExecuteCommitTrans(object sender, ExecutedRoutedEventArgs args)
       {
           if ((sender as SpreadsheetControl).GridProperties.CurrentExcelGridModel.CommandStack.InTransaction)
               (sender as SpreadsheetControl).GridProperties.CurrentExcelGridModel.CommandStack.CommitTrans();
       }

       private static void OnCanExecuteCommitTrans(object sender, CanExecuteRoutedEventArgs args)
       {
           args.CanExecute = true;
       }

       private static void OnExecuteClear(object sender, ExecutedRoutedEventArgs args)
       {
           if (!(sender as SpreadsheetControl).GridProperties.CurrentExcelGridModel.CommandStack.InTransaction)
           {
               (sender as SpreadsheetControl).GridProperties.CurrentExcelGridModel.CommandStack.UndoStack.Clear();
               (sender as SpreadsheetControl).GridProperties.CurrentExcelGridModel.CommandStack.RedoStack.Clear();

           }
       }

       private static void OnCanExecuteClear(object sender, CanExecuteRoutedEventArgs args)
       {
           args.CanExecute = true;
       }
    }
}
