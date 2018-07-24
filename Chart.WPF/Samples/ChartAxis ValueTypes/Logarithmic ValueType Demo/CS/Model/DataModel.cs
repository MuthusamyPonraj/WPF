using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace LogarithmicValueRangeDemo
{
    public class DataModel : INotifyPropertyChanged
    {

        private string carbrand;
        public string CarBrand
        {
            get
            {
                return carbrand;
            }
            set
            {
                carbrand = value;
                OnPropertyChanged("CarBrand");
            }
        }

        public double horsepower;
        public double HorsePower
        {
            get
            {
                return horsepower;
            }
            set
            {
                horsepower = value;
                OnPropertyChanged("HorsePower");
            }
        }

        public double fuelconsumption;
        public double FuelConsumption
        {
            get
            {
                return fuelconsumption;
            }
            set
            {
                fuelconsumption = value;
                OnPropertyChanged("FuelConsumption");
            }
        }

        public double averagespeed;
        public double AverageSpeed
        {
            get
            {
                return averagespeed;
            }
            set
            {
                averagespeed = value;
                OnPropertyChanged("AverageSpeed");
            }
        }

        public double rotationsperminute;
        public double RotationsPerMinute
        {
            get
            {
                return rotationsperminute;
            }
            set
            {
                rotationsperminute = value;
                OnPropertyChanged("RotationsPerMinute");
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
