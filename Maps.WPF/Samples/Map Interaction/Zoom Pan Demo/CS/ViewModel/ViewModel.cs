namespace ZoomPanDemo
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
    using System.Text.RegularExpressions;


    public class PanZoomViewModel : INotifyPropertyChanged
    {
        private double tempZoom;

        #region Constructor

        public PanZoomViewModel()
        {
            this.tempZoom = this.ZoomFactor;
            this.MinSliderValue = this.MinZoom / tempZoom;
            this.MaxSliderValue = this.MaxZoom / tempZoom;
            this.m_MinZoomTextChangeCommand = new MinZoomTextChangeCommand(MinZoomTextChanged);
            this.m_MaxZoomTextChangeCommand = new MaxZoomTextChangeCommand(MaxZoomTextChanged);
        }


        #endregion

        #region Properties

        #region ZoomFactor

        private double m_ZoomFactor=1;
        public double ZoomFactor
        {
            get { return m_ZoomFactor; }
            set { this.m_ZoomFactor = value; this.OnPropertyChanged("ZoomFactor"); }
        }

        #endregion

        #region MinZoom

        private double m_MinZoom=0.3;
        public double MinZoom
        {
            get { return m_MinZoom; }
            set { this.m_MinZoom = value; this.OnPropertyChanged("MinZoom"); }
        }

        #endregion

        #region MaxZoom

        private double m_MaxZoom=10;
        public double MaxZoom
        {
            get { return m_MaxZoom; }
            set { this.m_MaxZoom = value; this.OnPropertyChanged("MaxZoom"); }
        }

        #endregion

        #region MinSliderValue

        private double m_MinSliderValue = 0;
        public double MinSliderValue
        {
            get { return m_MinSliderValue; }
            set { this.m_MinSliderValue = value; this.OnPropertyChanged("MinSliderValue"); }
        }

        #endregion

        #region MaxSliderValue

        private double m_MaxSliderValue = 0.3;
        public double MaxSliderValue
        {
            get { return m_MaxSliderValue; }
            set { this.m_MaxSliderValue = value; this.OnPropertyChanged("MaxSliderValue"); }
        }

        #endregion

        #endregion

        #region Commands

        private MaxZoomTextChangeCommand m_MaxZoomTextChangeCommand;
        public MaxZoomTextChangeCommand MaxZoomTextChangeCommand
        {
            get { return m_MaxZoomTextChangeCommand; }
            set { this.m_MaxZoomTextChangeCommand = value; this.OnPropertyChanged("MaxZoomTextChangeCommand"); }
        }

        private MinZoomTextChangeCommand m_MinZoomTextChangeCommand;
        public MinZoomTextChangeCommand MinZoomTextChangeCommand
        {
            get { return m_MinZoomTextChangeCommand; }
            set { this.m_MinZoomTextChangeCommand = value; this.OnPropertyChanged("MinZoomTextChangeCommand"); }
        }


        #endregion

        #region Command Handling Function

        private void MinZoomTextChanged()
        {
            if (Regex.IsMatch(MinZoom.ToString(), "^[0-9]*$"))
            {
                this.MinSliderValue = MinZoom / tempZoom;
            }
        }

        private void MaxZoomTextChanged()
        {
            if (Regex.IsMatch(MaxZoom.ToString(), "^[0-9]*$"))
            {
                this.MaxSliderValue = MaxZoom / tempZoom;
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
