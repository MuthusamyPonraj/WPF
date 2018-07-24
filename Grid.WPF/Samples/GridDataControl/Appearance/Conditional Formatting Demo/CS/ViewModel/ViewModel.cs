using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Syncfusion.Windows.Shared;
using System.Data.SqlServerCe;
using Syncfusion.Windows.Controls.Grid;

namespace ConditionalFormattingDemo
{
    class ViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModel"/> class.
        /// </summary>
        public ViewModel()
        {           
            SalesDetails = this.GetSalesDetails();
        }


        /// <summary>
        /// Gets the sales details.
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<Sales> GetSalesDetails()
        {
            if (!LayoutControl.IsInDesignMode)
            {
                string connectionString = string.Format(@"Data Source = {0}", LayoutControl.FindFile("AdventureWorksExt.sdf"));
                ObservableCollection<Sales> sales = new ObservableCollection<Sales>();
                using (SqlCeConnection c = new SqlCeConnection(connectionString))
                {
                    c.Open();
                    using (SqlCeCommand com = new SqlCeCommand("SELECT *  FROM Sales_QuarterSalesProductView", c))
                    {
                        SqlCeDataReader reader = com.ExecuteReader();
                        int i = 0;
                        while (reader.Read() && i < 30)
                        {
                            sales.Add(new Sales()
                            {
                                Name = reader["Name"].ToString(),
                                QS1 = reader["QS1"].ToString() != "" ? double.Parse(reader["QS1"].ToString()) : 0.0,
                                QS2 = reader["QS2"].ToString() != "" ? double.Parse(reader["QS2"].ToString()) : 0.0,
                                QS3 = reader["QS3"].ToString() != "" ? double.Parse(reader["QS3"].ToString()) : 0.0,
                                QS4 = reader["QS4"].ToString() != "" ? double.Parse(reader["QS4"].ToString()) : 0.0,
                                Total = double.Parse(reader["Total"].ToString()),
                                Year = Int32.Parse(reader["Year"].ToString())

                            });
                            i++;
                        }
                    }
                    c.Close();
                }
                return sales;
            }
            else
                return null;
        }

        private ObservableCollection<Sales> _salesDetails;

        /// <summary>
        /// Gets or sets the sales details.
        /// </summary>
        /// <value>The sales details.</value>
        public ObservableCollection<Sales> SalesDetails
        {
            get{ return _salesDetails; }
            set{ _salesDetails = value;}
        }     
    }
}
