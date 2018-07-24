namespace Olympics_Venues_Demo
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.ComponentModel;


    public class MapData : INotifyPropertyChanged
    {

        public MapData()
        {
        }

        #region Properties

        private bool m_EnableLabel = false;
        public bool EnableLabel
        {
            get { return this.m_EnableLabel; }
            set { this.m_EnableLabel = value; this.OnPropertyChanged("EnableLabel"); }
        }


        private bool m_AllowLabelIntersection = false;
        public bool AllowLabelIntersection
        {
            get { return this.m_AllowLabelIntersection; }
            set { this.m_AllowLabelIntersection = value; this.OnPropertyChanged("AllowLabelIntersection"); }
        }



        #endregion


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string property)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}
