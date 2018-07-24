using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace IListDataBindingDemo
{
    public class DataModel:INotifyPropertyChanged
    {
        public double studentid;
        public double StudentID
        {
            get
            {
                return studentid;
            }
            set
            {
                studentid = value;
                OnPropertyChanged("StudentID");
            }
        }

        public string name;
        public string Name
        {

            get
            {
                return name;
            }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        public double probability;
        public double Probability
        {

            get
            {
                return probability;
            }
            set
            {
                probability = value;
                OnPropertyChanged("Probablity");
            }
        }

        public double systemsoftware;
        public double SystemSoftware
        {

            
            get
            {
                return systemsoftware;
            }
            set
            {
                systemsoftware = value;
                OnPropertyChanged("SystemSoftware");
            }
        }

        public double digitalsignal;
        public double DigitalSignal
        {

            get
            {
                return digitalsignal;
            }
            set
            {
                digitalsignal = value;
                OnPropertyChanged("DigitalSignal");
            }
        }

        public double mobileComputing;
        public double MobileComputing
        {

            get
            {
                return mobileComputing;
            }
            set
            {
                mobileComputing = value;
                OnPropertyChanged("MobileComputing");
            }
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
