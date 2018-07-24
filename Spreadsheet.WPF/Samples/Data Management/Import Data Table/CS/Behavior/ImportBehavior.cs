using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Interactivity;
using Syncfusion.Windows.Controls.Spreadsheet;
using System.IO;
using System.Data;
using ImportDataTable.Model;

namespace ImportDataTable.Behavior
{
    class ImportBehavior : Behavior<SpreadsheetControl>
    {
        protected override void OnAttached()
        {
            this.AssociatedObject.Loaded += new System.Windows.RoutedEventHandler(AssociatedObject_Loaded);
        }

        void AssociatedObject_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
             try
            {
                DataTable datatable = Data.GetDataTable("Customers");
                this.AssociatedObject.ImportFromDataTable(datatable);
            }
            catch (Exception ex)
            { }
        }

        protected override void OnDetaching()
        {
            this.AssociatedObject.Loaded -= new System.Windows.RoutedEventHandler(AssociatedObject_Loaded);
        }
    }
}
