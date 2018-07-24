using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Syncfusion.Windows.Controls.Grid;
using System.Windows.Media;
using System.Data.SqlServerCe;
using Syncfusion.Windows.Shared;

namespace RowStylesDemo
{
    class ViewModel:NotificationObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModel"/> class.
        /// </summary>
        public ViewModel()
        {
            SupplierDetatils = GetSupplierDetatils();
        }

        /// <summary>
        /// Gets the suppliers.
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<Suppliers> GetSupplierDetatils()
        {
            if (!LayoutControl.IsInDesignMode)
            {
                string connectionString = string.Format(@"Data Source = {0}", LayoutControl.FindFile("NorthwindIO.sdf"));
                ObservableCollection<Suppliers> _suppliers = new ObservableCollection<Suppliers>();
                using (SqlCeConnection c = new SqlCeConnection(connectionString))
                {
                    c.Open();
                    using (SqlCeCommand com = new SqlCeCommand("SELECT *  FROM Suppliers", c))
                    {
                        SqlCeDataReader reader = com.ExecuteReader();

                        while (reader.Read())
                        {
                            _suppliers.Add(new Suppliers()
                            {
                                SupplierID = Int32.Parse(reader["SupplierID"].ToString()),
                                CompanyName = reader["CompanyName"].ToString(),
                                ContactName = reader["ContactName"].ToString(),
                                ContactTitle = reader["ContactTitle"].ToString(),
                                Address = reader["Address"].ToString(),
                                City = reader["City"].ToString(),
                                Region = reader["Region"].ToString(),
                                PostalCode = reader["PostalCode"].ToString(),
                                Country = reader["Country"].ToString(),
                                Phone = reader["Phone"].ToString(),
                                Fax = reader["Fax"].ToString()

                            });

                        }
                    }
                    c.Close();
                }
                return _suppliers;
            }
            else
                return null;
        }

        private ObservableCollection<Suppliers> _supplierDetails;

        /// <summary>
        /// Gets or sets the GDC source.
        /// </summary>
        /// <value>The GDC source.</value>
        public ObservableCollection<Suppliers> SupplierDetatils
        {
            get
            {
                return _supplierDetails;
            }
            set
            {
                _supplierDetails = value;
                RaisePropertyChanged("SuppliersDetatils");
            }
        }   
        
    }
}
