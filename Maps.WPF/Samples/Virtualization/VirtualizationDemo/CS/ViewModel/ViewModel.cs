
namespace VirtualizationDemo
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
    using Syncfusion.Windows.Controls.Map;

    public class VirtualizationViewModel : INotifyPropertyChanged
    {
        ShapeFilePanel shapeCanvas;

        #region Constructor

        public VirtualizationViewModel()
        {
            this.m_GetShapeCountCommand = new GetShapeCountCommand(GetCount);
        }


        #endregion

        #region Properties

        private Int32 m_ShapeCount = 0;

        public Int32 ShapeCount
        {
            get { return m_ShapeCount; }
            set { this.m_ShapeCount = value; this.OnPropertyChanged("ShapeCount"); }
        }

        #endregion

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string property)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(property));
            }
        }

        #endregion 

        #region Commands

        private GetShapeCountCommand m_GetShapeCountCommand;
        public GetShapeCountCommand GetShapeCountCommand
        {
            get { return this.m_GetShapeCountCommand; }
            set { this.m_GetShapeCountCommand = value; this.OnPropertyChanged("GetShapeCountCommand"); }
        }

        void GetCount(object obj)
        {           
            if (obj is Panel)
            {
                this.ShapeCount = (obj as Panel).Children.Count;
            }
        }

        #endregion

        #region HelperMethods

        internal static T FindParent<T>(UIElement control) where T : UIElement
        {
            UIElement p = VisualTreeHelper.GetParent(control) as UIElement;
            if (p != null)
            {
                if (p is T)
                    return p as T;
                else
                    return VirtualizationViewModel.FindParent<T>(p);
            }
            return null;
        }

        internal static T FindChild<T>(UIElement control) where T : UIElement
        {
            UIElement p = VisualTreeHelper.GetChild(control,0) as UIElement;
            if (p != null)
            {
                if (p is T)
                    return p as T;
                else
                    return VirtualizationViewModel.FindChild<T>(p);
            }
            return null;
        }

        #endregion
    }
   
}
