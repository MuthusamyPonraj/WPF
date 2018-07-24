using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Data;
using System.Collections.ObjectModel;
using Syncfusion.Windows.Controls.Grid;
using System.Windows;
using System.Data.SqlServerCe;

namespace PrintDemo
{
    class ViewModel
    {
        string connectionString = string.Empty;
        ObservableCollection<DataModel> _suppliers;
        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModel"/> class.
        /// </summary>
        public ViewModel()
        {
            if (!LayoutControl.IsInDesignMode)
            {
                connectionString = string.Format(@"Data Source = {0}", LayoutControl.FindFile("AdventureWorksExt.sdf"));
                SupplierDetails = this.Get_Suppliers().ToList<DataModel>().GetRange(0, 60);
            }
        }

        private List<DataModel> _SupplierDetails;
        /// <summary>
        /// Gets or sets the supplier details.
        /// </summary>
        /// <value>The supplier details.</value>
        public List<DataModel> SupplierDetails
        {
            get
            {
                return _SupplierDetails;
            }
            set
            {
                _SupplierDetails = value;
            }
        }

        /// <summary>
        /// Get_s the suppliers.
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<DataModel> Get_Suppliers()
        {
            _suppliers = new ObservableCollection<DataModel>();
            using (SqlCeConnection c = new SqlCeConnection(connectionString))
            {
                c.Open();
                using (SqlCeCommand com = new SqlCeCommand("SELECT *  FROM Sales_QuarterSalesProductView", c))
                {
                    SqlCeDataReader reader = com.ExecuteReader();
                    int i = 0;
                    while (reader.Read())
                    {
                        string s1, s2, s3, s4;
                        double v1, v2, v3, v4;
                        s1 = reader["QS1"].ToString();
                        if (s1 != "")
                            v1 = double.Parse(s1);
                        else
                            v1 = 0.0;

                        s2 = reader["QS2"].ToString();
                        if (s2 != "")
                            v2 = double.Parse(s2);
                        else
                            v2 = 0.0;
                        s3 = reader["QS3"].ToString();
                        if (s3 != "")
                            v3 = double.Parse(s3);
                        else
                            v3 = 0.0;
                        s4 = reader["QS4"].ToString();
                        if (s4 != "")
                            v4 = double.Parse(s4);
                        else
                            v4 = 0.0;
                        _suppliers.Add(new DataModel()
                        {
                            Name = reader["Name"].ToString(),
                            QS1 = v1,
                            QS2 = v2,
                            QS3 = v3,
                            QS4 = v4,
                            Total = double.Parse(reader["Total"].ToString()),
                            Year = Int32.Parse(reader["Year"].ToString())

                        });
                    }
                }
                c.Close();
            }
            return _suppliers;
        }
    }
}