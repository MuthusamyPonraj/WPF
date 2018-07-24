using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Windows.Threading;
using System.Windows;
using System.ComponentModel;

namespace LiveDataDemo
{
    class ViewModel
    {
        DispatcherTimer timer = new DispatcherTimer();

        ChartDataSource _source = new ChartDataSource();

        public ChartDataSource Source
        {
            get
            {
                return _source;
            }
            set
            {
                _source = value;
                OnPropertyChanged("Source");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(object Property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(Property.ToString()));
            }
        }


        public ViewModel()
        {
            for (int i = 0; i < 100; i++)
            {
                _source.Add(new Measure());
            }
            timer.Start();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += new EventHandler(timer_Tick);
        }

        void timer_Tick(object sender, EventArgs e)
        {
            _source.Add(new Measure());
        }
    
    }
    public class ChartDataSource : ObservableCollection<Measure>
    {
        public ChartDataSource()
        {
        }
    }
}
