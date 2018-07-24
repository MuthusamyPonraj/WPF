using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Syncfusion.Windows.Controls.Grid;
using System.Data.SqlServerCe;
using System.Reflection;
using System.IO;

namespace TemplateMarker.Model
{
    public class Data
    {
        public static DataTable GetDataTable(string tablename)
        {
            if (!LayoutControl.IsInDesignMode)
            {
                using (SqlCeConnection con = new SqlCeConnection(string.Format(@"Data Source = {0}", LayoutControl.FindFile("Northwind.sdf"))))
                {
#if !Framework3_5
                    try
                    {
                        if (!Upgraded)
                        {
                            SqlCeEngine engine = new SqlCeEngine(string.Format(@"Data Source = {0}", LayoutControl.FindFile("Northwind.sdf")));
                            engine.Upgrade();
                            Upgraded = true;
                        }
                    }
                    catch (Exception)
                    {
                    }
#endif
                    con.Open();
                    SqlCeDataAdapter sda = new SqlCeDataAdapter(string.Format("SELECT * FROM {0}", tablename), con);
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    return ds.Tables[0];
                }
            }

            return new DataTable();
        }

        private static bool Upgraded =false;

      
    }
}
