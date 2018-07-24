
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
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using Syncfusion.Windows.Controls.Map;

    public class ColorPaletteViewModel : INotifyPropertyChanged
    {
        #region Constructor

        private ColorPaletteModel colorModel;

        public ColorPaletteViewModel()
        {
            this.colorModel = new ColorPaletteModel();
            this.colorModel.ColorPalette.Add(new Syncfusion.Windows.Controls.Map.MapColorPallette { ShapeFill = new SolidColorBrush(new Color() { A = 255, B = 36, G = 28, R = 237 }) });
            this.colorModel.ColorPalette.Add(new Syncfusion.Windows.Controls.Map.MapColorPallette { ShapeFill = new SolidColorBrush(new Color() { A = 255, B = 40, G = 220, R = 255 }) });
            this.colorModel.ColorPalette.Add(new Syncfusion.Windows.Controls.Map.MapColorPallette { ShapeFill = new SolidColorBrush(new Color() { A = 255, B = 67, G = 197, R = 138 }) });
            this.colorModel.ColorPalette.Add(new Syncfusion.Windows.Controls.Map.MapColorPallette { ShapeFill = new SolidColorBrush(new Color() { A = 255, B = 157, G = 167, R = 19 }) });
            this.colorModel.ColorPalette.Add(new Syncfusion.Windows.Controls.Map.MapColorPallette { ShapeFill = new SolidColorBrush(new Color() { A = 255, B = 19, G = 56, R = 95 }) });
            this.colorModel.ColorPalette.Add(new Syncfusion.Windows.Controls.Map.MapColorPallette { ShapeFill = new SolidColorBrush(new Color() { A = 255, B = 90, G = 29, R = 217 }) });
            this.colorModel.ColorPalette.Add(new Syncfusion.Windows.Controls.Map.MapColorPallette { ShapeFill = new SolidColorBrush(new Color() { A = 255, B = 142, G = 40, R = 145 }) });
            this.colorModel.ColorPalette.Add(new Syncfusion.Windows.Controls.Map.MapColorPallette { ShapeFill = new SolidColorBrush(new Color() { A = 255, B = 152, G = 63, R = 34 }) });
            this.colorModel.ColorPalette.Add(new Syncfusion.Windows.Controls.Map.MapColorPallette { ShapeFill = new SolidColorBrush(new Color() { A = 255, B = 34, G = 147, R = 246 }) });
        }


        #endregion

        #region Properties

        #region ColorPalette
        private ObservableCollection<MapColorPallette> m_ColorPalette = new ObservableCollection<MapColorPallette>();

        public ObservableCollection<MapColorPallette> ColorPalette
        {
            get { return this.colorModel.ColorPalette; }
            set { this.colorModel.ColorPalette = value; this.OnPropertyChanged("ColorPalette"); }
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
}
