using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Interactivity;
using Syncfusion.Windows.Controls.Spreadsheet;
using System.IO;
using Syncfusion.Windows.Controls.Grid;
using System.Windows;

namespace DataValidationDemo.Behavior
{
    class ImportBehavior : Behavior<SpreadsheetControl>
    {
        protected override void OnAttached()
        {
            this.AssociatedObject.Loaded += new System.Windows.RoutedEventHandler(AssociatedObject_Loaded);
            this.AssociatedObject.CurrentCellValidating += new CurrentCellValidatingEventHandler(AssociatedObject_CurrentCellValidating);
        }

        void AssociatedObject_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
             try
            {
                FileStream fileStream = new FileStream(@"..\..\Data\DataValidationDemo.xlsx", FileMode.Open);
                this.AssociatedObject.ImportFromExcel(fileStream);
            }
            catch (Exception ex)
            { }
        }

        void AssociatedObject_CurrentCellValidating(object sender, CurrentCellValidatingEventArgs e)
        {
            if ((e.Style.CellRowColumnIndex.ColumnIndex == 2 && e.Style.CellRowColumnIndex.RowIndex == 6) || (e.Style.CellRowColumnIndex.ColumnIndex == 2 && e.Style.CellRowColumnIndex.RowIndex == 8))
            {
                if (e.Style.HasIntegerEdit)
                    e.Cancel = OnValidateIntegerEdit(e);
                else if (e.Style.HasDoubleEdit)
                    e.Cancel = OnValidateDoubleEdit(e);
                e.Handled = true;
            }
        }

        //By handling the current CurrentCellValidating Event, you can display your own validation error message

        private bool OnValidateDoubleEdit(CurrentCellValidatingEventArgs e)
        {
            var doubleEdit = e.Style.DoubleEdit;
            if (doubleEdit.HasMinValue)
            {
                if (doubleEdit.MinValue > Convert.ToDouble(e.NewValue.ToString()))
                {
                    e.Handled = true;
                    MessageBoxResult result = MessageBox.Show("The value you entered is not valid.", "Sample side Validation", MessageBoxButton.OKCancel);
                    if (result == MessageBoxResult.OK)
                        return true;
                    e.NewValue = e.OldValue;
                    return false;
                }
            }
            if (doubleEdit.HasMaxValue)
            {
                if (doubleEdit.MaxValue < Convert.ToDouble(e.NewValue.ToString()))
                {
                    e.Handled = true;
                    MessageBoxResult result = MessageBox.Show("The value you entered is not valid.", "Sample side Validation", MessageBoxButton.OKCancel);
                    if (result == MessageBoxResult.OK)
                        return true;
                    e.NewValue = e.OldValue;
                    return false;
                }
            }
            return false;
        }

        private bool OnValidateIntegerEdit(CurrentCellValidatingEventArgs e)
        {
            var integeredit = e.Style.IntegerEdit;
            if (integeredit.HasMinValue)
            {
                if (integeredit.MinValue > Convert.ToInt64(e.NewValue.ToString()))
                {
                    e.Handled = true;
                    MessageBoxResult result = MessageBox.Show("The value you entered is not valid.", "Sample side Validation", MessageBoxButton.OKCancel);
                    if (result == MessageBoxResult.OK)
                        return true;
                    e.NewValue = e.OldValue;
                    return false;
                }
            }
            if (integeredit.HasMaxValue)
            {
                if (integeredit.MaxValue < Convert.ToInt64(e.NewValue.ToString()))
                {
                    e.Handled = true;
                    MessageBoxResult result = MessageBox.Show("The value you entered is not valid.", "Sample side Validation", MessageBoxButton.OKCancel);
                    if (result == MessageBoxResult.OK)
                        return true;
                    e.NewValue = e.OldValue;
                    return false;
                }
            }
            return false;
        }


        protected override void OnDetaching()
        {
            this.AssociatedObject.Loaded -= new System.Windows.RoutedEventHandler(AssociatedObject_Loaded);
			this.AssociatedObject.CurrentCellValidating -= new CurrentCellValidatingEventHandler(AssociatedObject_CurrentCellValidating);
        }
    }
}
