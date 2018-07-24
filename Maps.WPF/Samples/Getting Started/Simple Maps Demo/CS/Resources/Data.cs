namespace SimpleMapsDemo
{
    using System;
    using System.Net;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Documents;
    using System.Windows.Ink;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Animation;
    using System.Windows.Shapes;
    using System.ComponentModel;
    using System.Collections.ObjectModel;
    using System.Reflection;
    using Syncfusion.Windows.Controls.Map;


    public class SimpleMapViewData : INotifyPropertyChanged
    {

        #region Properties

        private ObservableCollection<string> m_BrusheCollection = new ObservableCollection<string>();
        public ObservableCollection<string> BrushCollection
        {
            get { return this.m_BrusheCollection; }
            set { this.m_BrusheCollection = value; this.OnPropertyChanged("BrushCollection"); }
        }

        #endregion

        #region Constructor
        public SimpleMapViewData()
        {
            Type brushType = typeof(System.Windows.Media.Colors);
            PropertyInfo[] propInfoList1 = brushType.GetProperties();
            foreach (PropertyInfo propInfo in propInfoList1)
            {
                this.m_BrusheCollection.Add(propInfo.Name);
            }           
        }
        #endregion

        #region Property Changed Members

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string property)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(property));
            }
        }

        #endregion
       
    }
}
