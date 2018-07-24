using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Syncfusion.Windows.Controls.Grid;
using System.Data.SqlServerCe;

namespace DefaultTolltipDemo
{
    class ViewModel 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModel"/> class.
        /// </summary>
        public ViewModel()
        {
            this.ZipCodeCollection = GetZipCodeCollection();
        }

        private ObservableCollection<ZipCodes> _zipCodeCollection;

        /// <summary>
        /// Gets or sets the zip code info.
        /// </summary>
        /// <value>The zip code info.</value>
        public ObservableCollection<ZipCodes> ZipCodeCollection
        {
            get
            {
                return _zipCodeCollection;
            }
            set
            {
                _zipCodeCollection = value;
            }
        }
       

        /// <summary>
        /// Gets the zip code info.
        /// </summary>
        /// <returns></returns>
        private ObservableCollection<ZipCodes> GetZipCodeCollection()
        {
            if (!LayoutControl.IsInDesignMode)
            {
                string connectionString = string.Format(@"Data Source = {0}", LayoutControl.FindFile("ZipCodes.sdf"));
                ObservableCollection<ZipCodes> zipCodeCollection = new ObservableCollection<ZipCodes>();
                using (SqlCeConnection c = new SqlCeConnection(connectionString))
                {
                    c.Open();
                    using (SqlCeCommand com = new SqlCeCommand("SELECT ZipCodes.*, States.StateAbbereviation,States.StateName, Class.Description FROM( ZipCodes INNER JOIN States ON ZipCodes.StateCode = States.StateCode) INNER JOIN Class ON ZipCodes.Class = Class.Class", c))
                    {
                        SqlCeDataReader reader = com.ExecuteReader();
                        while (reader.Read())
                        {
                            zipCodeCollection.Add(new ZipCodes()
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
                return zipCodeCollection;
            }
            else
                return null;
        }
    }
}
