using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using Syncfusion.Windows.Diagram;
using System.ComponentModel;

namespace BusinessObjectBindingDemo_2008
{
   
        public class CountrySalesList : ObservableCollection<CountrySale>
        {
            //default constructor for initailze the values
            public CountrySalesList()
            {
                this.Add(new CountrySale() { Name = "US", Revenue = 500000, Expense = 100000 });
                this.Add(new CountrySale() { Name = "Canada", Revenue =400000 , Expense = 43523 });
                this[0].RegionSales.Add(new RegionSale() { Name = "New York", Revenue = 200000, Expenditure = 2353 });
                this[0].RegionSales.Add(new RegionSale() { Name = "Los Angeles", Revenue = 300000, Expenditure = 3453 });
                this[1].RegionSales.Add(new RegionSale() { Name = "Manitoba", Revenue = 200000, Expenditure = 2353 });
                this[1].RegionSales.Add(new RegionSale() { Name = "Alberta", Revenue = 200000, Expenditure = 3453 });
                this[0].RegionSales[0].Earnings.Add(new Sale() { Name = "IT ", Revenue = 200000, Fund = 2353 });
                this[0].RegionSales[1].Earnings.Add(new Sale() { Name = "Automobile", Revenue = 200000, Fund = 2353 });
                this[0].RegionSales[1].Earnings.Add(new Sale() { Name = "Banking", Revenue = 100000, Fund = 2353 });
                this[1].RegionSales[0].Earnings.Add(new Sale() { Name = "Tourism", Revenue = 200000, Fund = 7045 });
                this[1].RegionSales[1].Earnings.Add(new Sale() { Name = "Agriculture", Revenue = 100000, Fund = 4352 });
                this[1].RegionSales[1].Earnings.Add(new Sale() { Name = "Natural Gas", Revenue = 100000, Fund = 7045 });
            }
        }

        #region CountrySale

        public class CountrySale : INotifyPropertyChanged
        {
            //Declaring the values
            public string Name { get; set; }
            private double _sales = 0;
            private double _expense = 0;

            #region Properties

            public double Revenue
            {
                get { return _sales; }
                set
                {
                    if (_sales != value)
                    {
                        _sales = value;
                        this.OnPropertyChanged(new PropertyChangedEventArgs("Sales"));
                    }
                }
            }

            public double Expense
            {
                get { return _expense; }
                set
                {
                    if (_expense != value)
                    {
                        _expense = value;
                        this.OnPropertyChanged(new PropertyChangedEventArgs("Expense"));
                    }
                }
            } 
            #endregion

            public ObservableCollection<RegionSale> RegionSales { get; set; }

            public CountrySale()
            {
                this.RegionSales = new ObservableCollection<RegionSale>();
            }

            #region INotifyPropertyChanged Members

            public event PropertyChangedEventHandler PropertyChanged;

            protected void OnPropertyChanged(PropertyChangedEventArgs e)
            {
                if (this.PropertyChanged != null)
                    this.PropertyChanged.Invoke(this, e);
            }
            #endregion
        } 
        #endregion

        #region RegionSale

        public class RegionSale : INotifyPropertyChanged
        {
            //Public variables
            public string Name { get; set; }
            private double _sales = 0;

            //Property
            public double Revenue
            {
                get { return _sales; }
                set
                {
                    if (_sales != value)
                    {
                        _sales = value;

                        //Call when proeprty value is changed
                        this.OnPropertyChanged(new PropertyChangedEventArgs("Sales"));
                    }
                }
            }
            public ObservableCollection<Sale> Earnings { get; set; }

            public RegionSale()
            {
                this.Earnings = new ObservableCollection<Sale>();
            }

            public double Expenditure { get; set; }

            #region INotifyPropertyChanged Members

            //Register the event handler for PropertyChanged 
            public event PropertyChangedEventHandler PropertyChanged;

            //Function to handle the property value changes
            protected void OnPropertyChanged(PropertyChangedEventArgs e)
            {
                if (this.PropertyChanged != null)
                    this.PropertyChanged.Invoke(this, e);
            }
            #endregion
        } 
        #endregion

        #region Sale

        public class Sale : INotifyPropertyChanged
        {
            //Declaring variables
            public string Name { get; set; }
            private double _profit = 0;

            //Property
            public double Revenue
            {
                get { return _profit; }
                set
                {
                    if (_profit != value)
                    {
                        _profit = value;

                        //Call when proeprty value is changed
                        this.OnPropertyChanged(new PropertyChangedEventArgs("Sales"));
                    }
                }
            }

            public Sale()
            {
            }

            public double Fund { get; set; }

            #region INotifyPropertyChanged Members

            //Register the event handler for PropertyChanged 
            public event PropertyChangedEventHandler PropertyChanged;

            //Function to handle the property value changes
            protected void OnPropertyChanged(PropertyChangedEventArgs e)
            {
                if (this.PropertyChanged != null)
                    this.PropertyChanged.Invoke(this, e);
            }
            #endregion
        } 
        #endregion
}
