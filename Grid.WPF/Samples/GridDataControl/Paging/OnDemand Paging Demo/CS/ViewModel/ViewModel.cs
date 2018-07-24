#region Copyright Syncfusion Inc. 2001 - 2011
// Copyright Syncfusion Inc. 2001 - 2011. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Syncfusion.Windows.Controls.Grid;
using System.Collections.ObjectModel;
using Syncfusion.Windows.Data;
using System.ComponentModel;
using Syncfusion.Windows.Shared;
using System.Data.SqlServerCe;

namespace OnDemandPagingDemo
{
    class ViewModel:NotificationObject
    {
        string connectionString = string.Empty;
        ObservableCollection<SalesOrderDetail> Orders;
        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModel"/> class.
        /// </summary>
        public ViewModel()
        {
            Orders = GetSalesOrderDetails();
            this.OrderDetails = Orders;
        }

        private ObservableCollection<SalesOrderDetail> _OrderDetails;
        /// <summary>
        /// Gets or sets the order details.
        /// </summary>
        /// <value>The order details.</value>
        public ObservableCollection<SalesOrderDetail> OrderDetails
        {
            get
            {
                return _OrderDetails;
            }
            set
            {
                _OrderDetails = value;
                RaisePropertyChanged("OrderDetails");
            }
        }

        /// <summary>
        /// Called when [demand data source load].
        /// </summary>
        /// <param name="param">The param.</param>
        public void OnDemandDataSourceLoad(PageInfo param)
        {
            OrderDetails = this.GetData(param.StartIndex, param.EndIndex);
        }

        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <param name="StartIndex">The start index.</param>
        /// <param name="EndIndex">The end index.</param>
        /// <returns></returns>
        public ObservableCollection<SalesOrderDetail> GetData(int StartIndex, int EndIndex)
        {
            ObservableCollection<SalesOrderDetail> list = new ObservableCollection<SalesOrderDetail>();
            for (int i = StartIndex; i < EndIndex; i++)
            {
                try
                {
                    list.Add(Orders.ElementAt(i));
                }
                catch
                {

                }
            }
            return list;
        }

        /// <summary>
        /// Gets the sales order details.
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<SalesOrderDetail> GetSalesOrderDetails()
        {
            if (!LayoutControl.IsInDesignMode)
            {
                connectionString = string.Format(@"Data Source = {0}", LayoutControl.FindFile("AdventureWorksExt.sdf"));
                ObservableCollection<SalesOrderDetail> sales = new ObservableCollection<SalesOrderDetail>();
                using (SqlCeConnection c = new SqlCeConnection(connectionString))
                {
                    c.Open();
                    using (SqlCeCommand com = new SqlCeCommand("SELECT * from Sales_SalesOrderDetail", c))
                    {
                        SqlCeDataReader reader = com.ExecuteReader();

                        while (reader.Read())
                        {
                            sales.Add(new SalesOrderDetail()
                            {
                                SalesOrderID = reader["SalesOrderID"].ToString(),
                                SalesOrderDetailID = reader["SalesOrderDetailID"].ToString(),
                                CarrierTrackingNumber = (reader["CarrierTrackingNumber"].ToString()),
                                OrderQty = Int32.Parse(reader["OrderQty"].ToString()),
                                ProductID = reader["ProductID"].ToString(),
                                SpecialOfferID = reader["SpecialOfferID"].ToString(),
                                UnitPrice = double.Parse(reader["UnitPrice"].ToString()),
                                UnitPriceDiscount = double.Parse(reader["UnitPriceDiscount"].ToString()),
                                LineTotal = double.Parse(reader["LineTotal"].ToString()),
                                Rowguid = reader["rowguid"].ToString()
                            });
                        }
                    }
                    c.Close();
                }
                return sales;
            }
            else
                return null;
        }
    }
}