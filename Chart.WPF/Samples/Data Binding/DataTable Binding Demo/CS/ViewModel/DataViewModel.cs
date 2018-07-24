
using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows.Data;
using System.Data.OleDb;
using System.Data;
using Syncfusion.Windows.Chart;

namespace DataTableBindingDemo
{
    public class DataViewModel : INotifyPropertyChanged
    {
        DataSet dataset = new DataSet();
        public DataViewModel()
        {
            AddData();
        }

        public void AddData()
        {
            //Sets Database connection
            string ConnectionString = string.Format("Provider=Microsoft.Jet.OLEDB.4.0; Data Source={0}", @"..\..\Model\DataBase_File.mdb");
            OleDbConnection Connection = new OleDbConnection(ConnectionString);
            OleDbCommand Command = new OleDbCommand("Select Top 10 * from [Products]", Connection);
            OleDbDataAdapter DataAdapter = new OleDbDataAdapter(Command);
            DataAdapter.Fill(dataset, "Product");
            this.Data = dataset.Tables["Product"];
        }

        public Array PaletteCollection
        {
            get
            {
                return new ChartColorPalette[] { ChartColorPalette.Nature, 
                                          ChartColorPalette.Metro, 
                                          ChartColorPalette.Default, 
                                          ChartColorPalette.DefaultDark,
                                        };
            }
        }
        public object data;
        public object Data
        {
            get
            {
                return data;
            }
            set
            {
                data = value;
                OnPropertyChanged("Data");
            }
        }

        

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(String property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property.ToString()));
            }
        }
        #endregion
    }
}
