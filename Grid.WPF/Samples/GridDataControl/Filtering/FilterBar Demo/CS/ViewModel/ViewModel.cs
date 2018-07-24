using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Syncfusion.Windows.Controls.Grid;
using System.Collections.ObjectModel;
using System.Data.SqlServerCe;
using Syncfusion.Windows.Shared;

namespace FilterBarDemo
{
    class ViewModel
    {        

        public ViewModel()
        {
            ZipCodeInfo = this.GetZipCodeInfo();
            filterMode = new string[] { "Immediate", "OnEnter" };
        }

        string[] filterMode;

        /// <summary>
        /// Gets or sets the filter mode.
        /// </summary>
        /// <value>The filter mode.</value>
        public string[] FilterMode
        {
            get
            { 
                return filterMode; 
            }
            set
            {
                filterMode = value; 
            }
        }

        private ObservableCollection<ZipCodes> _zipCodeInfo;

        /// <summary>
        /// Gets or sets the zip code info.
        /// </summary>
        /// <value>The zip code info.</value>
        public ObservableCollection<ZipCodes> ZipCodeInfo
        {
            get
            {
                return _zipCodeInfo;
            }
            set
            {
                _zipCodeInfo = value;
            }
        }

        /// <summary>
        /// Gets the zip code info.
        /// </summary>
        /// <returns></returns>
        private ObservableCollection<ZipCodes> GetZipCodeInfo()
        {
            if (!LayoutControl.IsInDesignMode)
            {
                string connectionString = string.Format(@"Data Source = {0}", LayoutControl.FindFile("ZipCodes.sdf"));
                ObservableCollection<ZipCodes> zipCodeInfo = new ObservableCollection<ZipCodes>();
                using (SqlCeConnection c = new SqlCeConnection(connectionString))
                {
                    c.Open();
                    using (SqlCeCommand com = new SqlCeCommand("SELECT ZipCodes.*, States.StateAbbereviation,States.StateName, Class.Description FROM( ZipCodes INNER JOIN States ON ZipCodes.StateCode = States.StateCode) INNER JOIN Class ON ZipCodes.Class = Class.Class", c))
                    {
                        SqlCeDataReader reader = com.ExecuteReader();
                        while (reader.Read())
                        {
                            zipCodeInfo.Add(new ZipCodes()
                            {
                                ZipCode = reader["ZipCode"].ToString(),
                                Class = reader["Class"].ToString(),
                                StateCode = Convert.ToInt32(reader["StateCode"]),
                                Latitude = reader["Latitude"].ToString(),
                                Longitude = reader["Longitude"].ToString(),
                                City = reader["City"].ToString(),
                                StateName = reader["StateName"].ToString(),
                                StateAbbereviation = reader["StateAbbereviation"].ToString(),
                                Description = reader["Description"].ToString()

                            });
                        }
                    }
                    c.Close();
                }
                return zipCodeInfo;
            }
            else
                return null;
        }
    } 
   
}
