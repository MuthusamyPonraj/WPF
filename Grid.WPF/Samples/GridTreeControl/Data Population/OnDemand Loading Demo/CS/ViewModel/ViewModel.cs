using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using Syncfusion.Windows.Controls.Grid;
using System.Windows;
using OnDemandLoadingDemo.DataModel.EmployeesDataSetTableAdapters;

namespace OnDemandLoadingDemo
{
    class ViewModel
    {
        public EmployeesTableAdapter dataAdapter;

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModel"/> class.
        /// </summary>
        public ViewModel()
        {
            this.dataAdapter = new EmployeesTableAdapter();
            this.dataAdapter.Connection = Connection;
        }

        private OleDbConnection connection = null;
        /// <summary>
        /// Get the Employee database connection.
        /// </summary>
        /// <value>The connection.</value>
        OleDbConnection Connection
        {
            get
            {
                if (connection == null)
                    if (!LayoutControl.IsInDesignMode)
                        connection = new OleDbConnection(string.Format(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source = {0}", LayoutControl.FindFile("Employees.mdb")));

                if (connection.State != System.Data.ConnectionState.Open)
                {
                    try
                    {
                        connection.Open();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Connection Problem: " + ex.Message);
                    }
                }
                return connection;
            }
        }
    }
}
