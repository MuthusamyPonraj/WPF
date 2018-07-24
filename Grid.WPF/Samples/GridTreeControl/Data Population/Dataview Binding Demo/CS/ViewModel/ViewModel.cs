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
using System.ComponentModel;
using System.Data;
using Syncfusion.Windows.Controls.Grid;
using System.Data.SqlServerCe;

namespace DataviewBindingDemo
{
    class ViewModel
    {
        DataTable _dataTable;
        string connectionString = string.Empty;

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModel"/> class.
        /// </summary>
        public ViewModel()
        {
            _dataTable = this.GetDataTable();
        } 
       
        /// <summary>
        /// Gets the GTC source.
        /// </summary>
        /// <value>The GTC source.</value>
        public DataView EmployeeTable
        {
            get
            {               
                if (_dataTable == null)
                    return null;
                DataView dataView = new DataView(_dataTable);
                dataView.RowFilter = "[Reports To] Is NULL";
                return dataView;
            }            
        }

        /// <summary>
        /// Gets the data table.
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTable()
        {
            DataSet ds = new DataSet();
            if (!LayoutControl.IsInDesignMode)
            {
                using (SqlCeConnection con = new SqlCeConnection(string.Format(@"Data Source = {0}", LayoutControl.FindFile("Northwind.sdf"))))
                {
                    con.Open();
                    SqlCeDataAdapter sda = new SqlCeDataAdapter("SELECT * FROM Employees", con);
                    sda.Fill(ds, "Employee");
                }
                ds.Relations.Add(new DataRelation("Employee_Relation", ds.Tables["Employee"].Columns["Employee ID"], ds.Tables["Employee"].Columns["Reports To"], false));
            }
            if (ds.Tables.Count > 0)
                return ds.Tables[0];
            else
                return null;
        }
    }
}
