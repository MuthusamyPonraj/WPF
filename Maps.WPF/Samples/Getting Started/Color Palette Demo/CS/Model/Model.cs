namespace ColorPaletteDemo
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
    using System.Collections.ObjectModel;

    public class ColorPaletteModel : INotifyPropertyChanged
    {

        #region Properties

        #region ColorPalette
        private ObservableCollection<MapColorPallette> m_ColorPalette = new ObservableCollection<MapColorPallette>();

        public ObservableCollection<MapColorPallette> ColorPalette
        {
            get { return m_ColorPalette; }
            set { this.m_ColorPalette = value; this.OnPropertyChanged("ColorPalette"); }
        }
        #endregion

        #endregion

        #region Property Changed Handler

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

    #region Commands

    public class PaletteCommand : ICommand
    {
        private Action _action;

        public PaletteCommand(Action act)
        {
            this._action = act;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            this._action();
        }
    }

    #endregion
}
