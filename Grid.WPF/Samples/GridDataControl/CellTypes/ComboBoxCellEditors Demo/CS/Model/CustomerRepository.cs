using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Syncfusion.Windows.Controls.Grid;
using System.Collections.ObjectModel;
using ComboBoxDropdownCellDemo.Model;

namespace ComboBoxCellEditorsDemo
{
    public class CustomerRepository : ObservableCollection<object>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerRepository"/> class.
        /// </summary>
        public CustomerRepository()
        {
            Northwind northWind;
            if (!LayoutControl.IsInDesignMode)
            {
                string connectionString = string.Format(@"Data Source = {0}", LayoutControl.FindFile("Northwind.sdf"));
                northWind = new Northwind(connectionString);
                var order = northWind.Orders.Skip(0).Take(100).ToList();
                foreach (var o in order)
                {
                    if (!this.Contains(o.CustomerID))
                        this.Add(o.CustomerID);
                }
            }
        }
    }
}
