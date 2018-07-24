using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using Syncfusion.Windows.Controls.Grid;
using System.Data.SqlServerCe;

namespace ObservableCollectionDemo.Model
{
   public class ZipCodeRepository
   {
       #region Properties
       
       string connectionString = string.Empty;
       ObservableCollection<ZipCodeInfo> _zipCodes = new ObservableCollection<ZipCodeInfo>();

       public ObservableCollection<ZipCodeInfo> ZipCodes
       {
           get { return _zipCodes; }
           set { _zipCodes = value; }
       }
       #endregion

       #region Constructor
       
       public ZipCodeRepository()
       {
           ZipCodes = new ObservableCollection<ZipCodeInfo>();
           this.PopulateZipCodes();
       }

       #endregion

       #region Methods

       /// <summary>
       /// Populates the zip codes.
       /// </summary>
       public void PopulateZipCodes()
       {
           if (!LayoutControl.IsInDesignMode)
           {
               connectionString = string.Format(@"Data Source = {0}", LayoutControl.FindFile("ZipCodes.sdf"));
               using (SqlCeConnection c = new SqlCeConnection(connectionString))
               {
                   c.Open();

                   using (SqlCeCommand com = new SqlCeCommand("SELECT ZipCodes.*, States.StateAbbereviation,States.StateName, Class.Description FROM(ZipCodes INNER JOIN States ON ZipCodes.StateCode = States.StateCode) INNER JOIN Class ON ZipCodes.Class = Class.Class", c))
                   {
                       SqlCeDataReader reader = com.ExecuteReader();
                       int i = 0;
                       while (reader.Read() && i < 50)
                       {
                           i++;
                           this._zipCodes.Add(new ZipCodeInfo()
                           {
                               ZipCode = reader["ZipCode"].ToString(),
                               Class = reader["Class"].ToString(),
                               StateCode = reader["StateCode"].ToString(),
                               Latitude = reader["Latitude"].ToString(),
                               Longitude = reader["Longitude"].ToString(),
                               City = reader["City"].ToString(),
                               StateName = reader["StateName"].ToString(),
                               StateAbbereviation = reader["StateAbbereviation"].ToString(),
                           });
                       }
                   }
                   c.Close();
               }
           }
       }
        #endregion
    }
}
 