namespace DataBindingDemo
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


   public class MapsLabel
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Text { get; set; }
        public FontFamily FontFamily { get; set; }
    }
    public class MapsSymbol
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Text { get; set; }
        public object Symbol { get; set; }
    }
    public class MapsPath
    {
        public ObservableCollection<Point> Points { get; set; }
        public Point LabelPoint { get; set; }
        public string Label { get; set; }
        public Brush Color { get; set; }
    }
}
