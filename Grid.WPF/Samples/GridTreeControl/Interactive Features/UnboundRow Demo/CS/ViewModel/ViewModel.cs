using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Syncfusion.Windows.Shared;
using System.Data;
using Syncfusion.Windows.Controls.Grid;
using System.Data.SqlServerCe;

namespace UnBoundRowDemo
{
    public class ViewModel : NotificationObject
    {
        private DataView _employeeTable = null;

        public ViewModel()
        {
            
            _employeeTable = new DataView(GetEmployeeTable());
            
            _employeeTable.RowFilter = "[ManagerID] Is NULL";
        }

        private DataTable GetEmployeeTable()
        {
            if (!LayoutControl.IsInDesignMode)
            {
                DataSet ds = new DataSet();
                var connectionstring = string.Format(@"Data Source = {0}", LayoutControl.FindFile("AdventureWorksExt.sdf"));
                using (SqlCeConnection connection = new SqlCeConnection(connectionstring))
                {
                    connection.Open();
                    SqlCeDataAdapter sda = new SqlCeDataAdapter("Select * from HumanResources_Employee", connection);
                    sda.Fill(ds, "Employee");
                }
                ds.Relations.Add(new DataRelation("Employee_Relation", ds.Tables["Employee"].Columns["EmployeeID"], ds.Tables["Employee"].Columns["ManagerID"], false));
                if (ds.Tables.Count > 0)
                    return ds.Tables[0];
            }

            return null;
        }

        public DataView EmployeeTable
        {
            get { return _employeeTable; }
        }

        //private DataTable _employeeTable = null;

        //public ViewModel()
        //{
        //    var connectionstring = string.Format(@"Data Source = {0}", LayoutControl.FindFile("AdventureWorksExt.sdf"));
        //    _employeeTable = GetEmployeeTable(connectionstring);
        //}

        //private DataTable GetEmployeeTable(string connectionstring)
        //{
        //    DataSet ds = new DataSet();
        //    using (SqlCeConnection connection = new SqlCeConnection(connectionstring))
        //    {
        //        connection.Open();
        //        SqlCeDataAdapter sda = new SqlCeDataAdapter("Select * from HumanResources_Employee", connection);
        //        sda.Fill(ds);
        //        if (ds.Tables.Count > 0)
        //            return ds.Tables[0];
        //    }

        //    return null;
        //}

        //public DataTable EmployeeTable
        //{
        //    get { return _employeeTable; }
        //}
    }
}
