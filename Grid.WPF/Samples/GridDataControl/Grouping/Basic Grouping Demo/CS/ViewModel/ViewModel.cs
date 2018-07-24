using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using Syncfusion.Windows.Controls.Grid;
using System.Data.SqlServerCe;

namespace BasicGroupingDemo
{
    public class ViewModel 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModel"/> class.
        /// </summary>
        public ViewModel()
        {
            SupplierInfo = this.GetSupplierInfo();
        }

        private ObservableCollection<Suppliers> _supplierInfo;

        /// <summary>
        /// Gets or sets the supplier info.
        /// </summary>
        /// <value>The supplier info.</value>
        public ObservableCollection<Suppliers> SupplierInfo
        {
            get 
            { 
                return _supplierInfo; 
            }
            set
            {
                _supplierInfo = value;
            }
        }

        /// <summary>
        /// Gets the supplier info.
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<Suppliers> GetSupplierInfo()
        {
            if (!LayoutControl.IsInDesignMode)
            {
                ObservableCollection<Suppliers> Supplier = new ObservableCollection<Suppliers>();
                string connectionString = string.Format(@"Data Source = {0}", LayoutControl.FindFile("AdventureWorksExt.sdf"));
                using (SqlCeConnection connection = new SqlCeConnection(connectionString))
                {
                    connection.Open();
                    using (System.Data.SqlServerCe.SqlCeCommand com = new System.Data.SqlServerCe.SqlCeCommand("SELECT *  FROM Production_Product", connection))
                    {
                        SqlCeDataReader reader = com.ExecuteReader();
                        while (reader.Read())
                        {
                            Supplier.Add(new Suppliers()
                            {
                                MakeFlag = bool.Parse(reader["MakeFlag"].ToString()),
                                Name = reader["Name"].ToString(),
                                FinishedGoodsFlag = bool.Parse(reader["FinishedGoodsFlag"].ToString()),
                                ProductNumber = (reader["ProductNumber"].ToString()),
                                SafetyStockLevel = Int32.Parse(reader["SafetyStockLevel"].ToString()),
                                ReorderPoint = Int32.Parse(reader["ReorderPoint"].ToString()),
                                StandardCost = double.Parse(reader["StandardCost"].ToString()),
                                ListPrice = double.Parse(reader["ListPrice"].ToString()),
                            });
                        }
                    }
                    connection.Close();
                }
                return Supplier;
            }
            else
                return null;
        }
    }
}
