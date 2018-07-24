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
    public class LabelCollection : ObservableCollection<MapsLabel>
    {
        public LabelCollection()
        {
            this.Add(new MapsLabel { Latitude = 47.6, Longitude = -120, Text = "Washington", FontFamily = new FontFamily("Calibri"),FontSize=15 });
            this.Add(new MapsLabel { Latitude = 26.5, Longitude = -113, Text = "Alaska", FontFamily = new FontFamily("Calibri"), FontSize = 15 });
            this.Add(new MapsLabel { Latitude = 30, Longitude = -99, Text = "Texas", FontFamily = new FontFamily("Calibri"), FontSize = 15 });
            this.Add(new MapsLabel { Latitude = 41, Longitude = -77, Text = "Pennsylvania", FontFamily = new FontFamily("Calibri"), FontSize = 15 });
            this.Add(new MapsLabel { Latitude = 39, Longitude = -99, Text = "Kansas", FontFamily = new FontFamily("Calibri"), FontSize=15 });
        }
    }
    public class SymbolCollection : ObservableCollection<MapsSymbol>
    {
        Path path;
        MapsSymbol symbol;
        public SymbolCollection()
        {

            Geometry geo = Geometry.Parse("M24.002,20.7279L7.75067,30.0195L7.75067,33.8085L24.1192,28.608L24.0989,37.3815L24.5736,39.72L19.1172,43.0533L19.1491,45.8464L26.5436,43.6602L34.1217,45.7812L34.1283,43.1523L28.7019,39.6927L29.2981,37.3607L29.2721,28.6107L45.4968,33.5065L45.5052,29.7904L29.2995,20.7448L29.2721,10.1653C29.2721,10.1653 29.4753,7.56375 26.5957,7.41147C24.1712,7.78122 24.0377,9.26309 23.9421,10.1315C24.0937,10.2839 24.002,20.7279 24.002,20.7279z");

            symbol = new MapsSymbol();
            path = new Path();
            path.Data = geo;
            BrushConverter brush = new BrushConverter();

            path.Fill = brush.ConvertFromString("#333333") as SolidColorBrush;
            path.RenderTransform = new RotateTransform { Angle = -17 };
            symbol.Latitude = 37.083844731702214;
            symbol.Longitude = -117.6;
            symbol.Symbol = path;
            this.Add(symbol);


            symbol = new MapsSymbol();
            path = new Path();
            path.Data = geo;
            path.Fill = brush.ConvertFromString("#333333") as SolidColorBrush;
            path.RenderTransform = new RotateTransform { Angle = 49 };
            symbol.Latitude = 30.996600469969105;
            symbol.Longitude = -109.98740498946205;
            symbol.Symbol = path;
            this.Add(symbol);

            symbol = new MapsSymbol();
            path = new Path();
            path.Data = geo;
            path.Fill = brush.ConvertFromString("#333333") as SolidColorBrush;
            path.RenderTransform = new RotateTransform { Angle = 135 };
            symbol.Latitude = 38.6486927040489;
            symbol.Longitude = -107.3636417127119;
            symbol.Symbol = path;
            this.Add(symbol);


            symbol = new MapsSymbol();
            path = new Path();
            path.Data = geo;
            path.Fill = brush.ConvertFromString("#333333") as SolidColorBrush;
            path.RenderTransform = new RotateTransform { Angle = 100 };
            symbol.Latitude = 43.990093435827715;
            symbol.Longitude = -97.719415384714551;
            symbol.Symbol = path;
            this.Add(symbol);



            symbol = new MapsSymbol();
            path = new Path();
            path.Data = geo;
            path.Fill = brush.ConvertFromString("#333333") as SolidColorBrush;
            path.RenderTransform = new RotateTransform { Angle = 250 };
            symbol.Latitude = 30.12259264526526;
            symbol.Longitude = -95.569613723594529;
            symbol.Symbol = path;
            this.Add(symbol);
        }

    }
    public class PathCollection : ObservableCollection<MapsPath>
    {
        Path path;
        MapsPath mpath;

        public PathCollection()
        {
            BrushConverter brush = new BrushConverter();
            mpath = new MapsPath();
            mpath.Points = new ObservableCollection<Point>();
            mpath.Points.Add(new Point(-119, 47));
            mpath.Points.Add(new Point(-115, 27));
            mpath.LabelPoint = mpath.Points[0];


            mpath.Label = string.Empty;


            this.Add(mpath);

            mpath = new MapsPath();
            mpath.Points = new ObservableCollection<Point>();
            mpath.Points.Add(new Point(-119, 47));
            mpath.Points.Add(new Point(-80, 41));
            mpath.LabelPoint = mpath.Points[0];
            mpath.Label = string.Empty;

            this.Add(mpath);

            mpath = new MapsPath();
            mpath.Points = new ObservableCollection<Point>();
            mpath.Points.Add(new Point(-115, 27));
            mpath.Points.Add(new Point(-80, 41));
            mpath.LabelPoint = mpath.Points[0];
            mpath.Label = string.Empty;
            this.Add(mpath);

            mpath = new MapsPath();
            mpath.Points = new ObservableCollection<Point>();
            mpath.Points.Add(new Point(-101, 39));
            mpath.Points.Add(new Point(-115, 27));
            mpath.LabelPoint = mpath.Points[0];
            mpath.Label = string.Empty;
            this.Add(mpath);

            mpath = new MapsPath();
            mpath.Points = new ObservableCollection<Point>();
            mpath.Points.Add(new Point(-119, 47));
            mpath.Points.Add(new Point(-100, 31));
            mpath.LabelPoint = mpath.Points[0];
            mpath.Label = string.Empty;
            this.Add(mpath);

            mpath = new MapsPath();
            mpath.Points = new ObservableCollection<Point>();
            mpath.Points.Add(new Point(0, 0));
            mpath.Points.Add(new Point(0, 0));
            mpath.LabelPoint = mpath.Points[0];
            mpath.Label = string.Empty;
            this.Add(mpath);

            mpath = new MapsPath();
            mpath.Points = new ObservableCollection<Point>();
            mpath.Points.Add(new Point(0, 0));
            mpath.Points.Add(new Point(0, 0));
            mpath.LabelPoint = mpath.Points[0];
            mpath.Label = string.Empty;
            this.Add(mpath);

            mpath = new MapsPath();
            mpath.Points = new ObservableCollection<Point>();
            mpath.Points.Add(new Point(0, 0));
            mpath.Points.Add(new Point(0, 0));
            mpath.LabelPoint = mpath.Points[0];
            mpath.Label = string.Empty;
            this.Add(mpath);
        }
    }
    public class MapsLabel
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Text { get; set; }
        public FontFamily FontFamily { get; set; }
        public double FontSize { get; set; }

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



    }

}
