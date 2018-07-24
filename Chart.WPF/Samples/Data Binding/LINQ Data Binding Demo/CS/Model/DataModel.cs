
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace LinqDataBindingDemo
{
    public class CarModelDetails:INotifyPropertyChanged
    {

        private string carname;
        public string CarName
        {
            get
            {
                return carname;
            }
            set
            {
                carname = value;
                OnPropertyChanged("CarName");
            }
        }

        private double price;
        public double Price
        {
            get
            {
                return price;
            }
            set
            {
                price = value;
                OnPropertyChanged("Price");
            }
        }

        private double maximumspeed;
        public double MaximumSpeed
        {
            get
            {
                return maximumspeed;
            }
            set
            {
                maximumspeed = value;
                OnPropertyChanged("MaximumSpeed");
            }
        }

        private double mileage;
        public double Mileage
        {
            get
            {
                return mileage;
            }
            set
            {
                mileage = value;
                OnPropertyChanged("Mileage");
            }
        }


        public CarModelDetails(string name, double price, double maxspeed, double mileage)
        {
            this.CarName = name;
            this.Price = price;
            this.MaximumSpeed = maxspeed;
            this.Mileage = mileage;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(String property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property.ToString()));
            }
        }

    }
}
