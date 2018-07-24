using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace CollectionViewSourceDemo
{
    public class DataModel : INotifyPropertyChanged
    {

        private double shopcode;
        public double ShopCode
        {
            get
            {
                return shopcode;
            }
            set
            {
                shopcode = value;
                OnPropertyChanged("ShopCode");
            }
        }

        public string locationName;
        public string LocationName
        {
            get
            {
                return locationName;
            }
            set
            {
                locationName = value;
                OnPropertyChanged("LocationName");
            }
        }

        public double salesamount;
        public double SalesAmount
        {
            get
            {
                return salesamount;
            }
            set
            {
                salesamount = value;
                OnPropertyChanged("SalesAmount");
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
