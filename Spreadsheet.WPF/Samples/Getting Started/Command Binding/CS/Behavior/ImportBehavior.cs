using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Interactivity;
using Syncfusion.Windows.Controls.Spreadsheet;
using System.IO;

namespace CommandBindingDemo.Behavior
{
    class ImportBehavior : Behavior<SpreadsheetControl>
    {
        protected override void OnAttached()
        {
            this.AssociatedObject.Loaded += new System.Windows.RoutedEventHandler(AssociatedObject_Loaded);
           this.AssociatedObject.Unloaded += AssociatedObject_Unloaded;
        }

        void AssociatedObject_Unloaded(object sender, System.Windows.RoutedEventArgs e)
        {
            this.AssociatedObject.ExcelProperties.WorkBook.Close();
            this.AssociatedObject.New(1);
        }

        void AssociatedObject_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
             try
            {
                using (FileStream fileStream = new FileStream(@"..\..\Data\DefaultSheet.xlsx", FileMode.Open))
                {
                    this.AssociatedObject.ImportFromExcel(fileStream);
                }
            }
            catch (Exception ex)
            { }
        }

        protected override void OnDetaching()
        {
            this.AssociatedObject.Loaded -= new System.Windows.RoutedEventHandler(AssociatedObject_Loaded);
           this.AssociatedObject.Unloaded -= AssociatedObject_Unloaded;
        }
    }
}
