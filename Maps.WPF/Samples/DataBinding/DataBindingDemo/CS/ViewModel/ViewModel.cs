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

    public class ViewModel
    {
        #region ViewModel Properties

        #region Labels

        private LabelCollection m_Labels = new LabelCollection();
        public LabelCollection Labels
        {
            get { return m_Labels; }
            set { m_Labels = value; }
        }

        #endregion

        #region Paths

        private PathCollection m_Paths = new PathCollection();
        public PathCollection Paths
        {
            get { return m_Paths; }
            set { m_Paths = value; }
        }

        #endregion

        #region Symbols

        private SymbolCollection m_Symbols = new SymbolCollection();
        public SymbolCollection Symbols
        {
            get { return m_Symbols; }
            set { m_Symbols = value; }
        }

        #endregion

        #endregion

        #region Constructor

        public ViewModel()
        {
            string hexaColor = "#FFFFFF00";
            Brush pathcolor = new SolidColorBrush(Color.FromArgb(Convert.ToByte(hexaColor.Substring(1, 2), 16), Convert.ToByte(hexaColor.Substring(3, 2), 16), Convert.ToByte(hexaColor.Substring(5, 2), 16), Convert.ToByte(hexaColor.Substring(7, 2), 16)));

            #region Labels

            // Adding Labels
            this.m_Labels.Add(new MapsLabel { Latitude = 48, Longitude = -121, Text = "Washington", FontFamily = new FontFamily("Fonts/SEGOEWP-SEMIBOLD.TTF#Segoe WP SemiBold") });
            this.m_Labels.Add(new MapsLabel { Latitude = 26.336, Longitude = -113.049, Text = "Alaska", FontFamily = new FontFamily("Fonts/SEGOEWP-SEMIBOLD.TTF#Segoe WP SemiBold") });
            this.m_Labels.Add(new MapsLabel { Latitude = 31, Longitude = -100, Text = "Texas", FontFamily = new FontFamily("Fonts/SEGOEWP-SEMIBOLD.TTF#Segoe WP SemiBold") });
            this.m_Labels.Add(new MapsLabel { Latitude = 41.019, Longitude = -76.908, Text = "Pennsylvania", FontFamily = new FontFamily("Fonts/SEGOEWP-SEMIBOLD.TTF#Segoe WP SemiBold") });
            this.m_Labels.Add(new MapsLabel { Latitude = 38.751, Longitude = -97.948, Text = "Kansas", FontFamily = new FontFamily("Fonts/SEGOEWP-SEMIBOLD.TTF#Segoe WP SemiBold") });

            #endregion

            #region Symbols

            //Adding Symbols
            Path path;
            MapsSymbol symbol;

            Geometry geo = Geometry.Parse("M24.002,20.7279L7.75067,30.0195L7.75067,33.8085L24.1192,28.608L24.0989,37.3815L24.5736,39.72L19.1172,43.0533L19.1491,45.8464L26.5436,43.6602L34.1217,45.7812L34.1283,43.1523L28.7019,39.6927L29.2981,37.3607L29.2721,28.6107L45.4968,33.5065L45.5052,29.7904L29.2995,20.7448L29.2721,10.1653C29.2721,10.1653 29.4753,7.56375 26.5957,7.41147C24.1712,7.78122 24.0377,9.26309 23.9421,10.1315C24.0937,10.2839 24.002,20.7279 24.002,20.7279z");
            string strokeColor="#FFEC3200";
            Brush symbolstroke= new SolidColorBrush(Color.FromArgb(Convert.ToByte(strokeColor.Substring(1, 2), 16), Convert.ToByte(strokeColor.Substring(3, 2), 16), Convert.ToByte(strokeColor.Substring(5, 2), 16), Convert.ToByte(strokeColor.Substring(7, 2), 16)));

  

            symbol = new MapsSymbol();
            path = new Path();
            path.IsHitTestVisible = false;
            path.Data = geo;
            path.Stroke = symbolstroke;
            path.Fill = pathcolor;
            path.RenderTransform = new RotateTransform { Angle = -17 };
            symbol.Latitude = 37.083844731702214;
            symbol.Longitude = -117.6;
            symbol.Symbol = path;
            this.m_Symbols.Add(symbol);


            symbol = new MapsSymbol();
            path = new Path();
            path.IsHitTestVisible = false;
            path.Data = geo;
            path.Stroke = symbolstroke;
            path.Fill = pathcolor;
            path.RenderTransform = new RotateTransform { Angle = 42 };
            symbol.Latitude = 30.996600469969105;
            symbol.Longitude = -109.98740498946205;
            symbol.Symbol = path;
            this.m_Symbols.Add(symbol);

            symbol = new MapsSymbol();
            path = new Path();
            path.IsHitTestVisible = false;
            path.Data = geo;
            path.Stroke = symbolstroke;
            path.Fill = pathcolor;
            path.RenderTransform = new RotateTransform { Angle = 135 };
            symbol.Latitude = 38.6486927040489;
            symbol.Longitude = -107.3636417127119;
            symbol.Symbol = path;
            this.m_Symbols.Add(symbol);


            symbol = new MapsSymbol();
            path = new Path();
            path.IsHitTestVisible = false;
            path.Stroke = symbolstroke;
            path.Data = geo;
            path.Fill = pathcolor;
            path.RenderTransform = new RotateTransform { Angle = 100 };
            symbol.Latitude = 43.990093435827715;
            symbol.Longitude = -97.719415384714551;
            symbol.Symbol = path;
            this.m_Symbols.Add(symbol);



            symbol = new MapsSymbol();
            path = new Path();
            path.IsHitTestVisible = false;
            path.Data = geo;
            path.Stroke = symbolstroke;
            path.Fill = pathcolor;
            path.RenderTransform = new RotateTransform { Angle = 250 };
            symbol.Latitude = 31.35;
            symbol.Longitude = -95.083;
            symbol.Symbol = path;
            this.m_Symbols.Add(symbol);

            #endregion

            #region Paths



            MapsPath mpath;
            string hexaColor1 = "#FF8A5100";
            Brush mappathcolor = new SolidColorBrush(Color.FromArgb(Convert.ToByte(hexaColor1.Substring(1, 2), 16), Convert.ToByte(hexaColor1.Substring(3, 2), 16), Convert.ToByte(hexaColor1.Substring(5, 2), 16), Convert.ToByte(hexaColor1.Substring(7, 2), 16)));


            mpath = new MapsPath();
            mpath.Points = new ObservableCollection<Point>();
            mpath.Points.Add(new Point(-119, 47));
            mpath.Points.Add(new Point(-115, 27));
            mpath.LabelPoint = mpath.Points[0];
            mpath.Color = mappathcolor;
            mpath.Label = string.Empty;
            this.m_Paths.Add(mpath);

            mpath = new MapsPath();
            mpath.Points = new ObservableCollection<Point>();
            mpath.Points.Add(new Point(-119, 47));
            mpath.Points.Add(new Point(-80, 41));
            mpath.LabelPoint = mpath.Points[0];
            mpath.Color = mappathcolor;
            mpath.Label = string.Empty;
            this.m_Paths.Add(mpath);

            mpath = new MapsPath();
            mpath.Points = new ObservableCollection<Point>();
            mpath.Points.Add(new Point(-115, 27));
            mpath.Points.Add(new Point(-80, 41));
            mpath.LabelPoint = mpath.Points[0];
            mpath.Label = string.Empty;
            mpath.Color = mappathcolor;
            this.m_Paths.Add(mpath);

            mpath = new MapsPath();
            mpath.Points = new ObservableCollection<Point>();
            mpath.Points.Add(new Point(-101, 39));
            mpath.Points.Add(new Point(-115, 27));
            mpath.LabelPoint = mpath.Points[0];
            mpath.Label = string.Empty;
            mpath.Color = mappathcolor;
            this.m_Paths.Add(mpath);

            mpath = new MapsPath();
            mpath.Points = new ObservableCollection<Point>();
            mpath.Points.Add(new Point(-119, 47));
            mpath.Points.Add(new Point(-100, 31));
            mpath.LabelPoint = mpath.Points[0];
            mpath.Color = mappathcolor;
            mpath.Label = string.Empty;
            this.m_Paths.Add(mpath);

            mpath = new MapsPath();
            mpath.Points = new ObservableCollection<Point>();
            mpath.Points.Add(new Point(0, 0));
            mpath.Points.Add(new Point(0, 0));
            mpath.LabelPoint = mpath.Points[0];
            mpath.Label = string.Empty;
            mpath.Color = mappathcolor;
            this.m_Paths.Add(mpath);

            mpath = new MapsPath();
            mpath.Points = new ObservableCollection<Point>();
            mpath.Points.Add(new Point(0, 0));
            mpath.Points.Add(new Point(0, 0));
            mpath.LabelPoint = mpath.Points[0];
            mpath.Label = string.Empty;
            mpath.Color = mappathcolor;
            this.m_Paths.Add(mpath);

            mpath = new MapsPath();
            mpath.Points = new ObservableCollection<Point>();
            mpath.Points.Add(new Point(0, 0));
            mpath.Points.Add(new Point(0, 0));
            mpath.LabelPoint = mpath.Points[0];
            mpath.Label = string.Empty;
            mpath.Color = mappathcolor;
            this.m_Paths.Add(mpath);

            #endregion

        }

        #endregion
    }


    public class LabelCollection : ObservableCollection<MapsLabel>
    {
        public LabelCollection()
        {

        }
    }
    public class SymbolCollection : ObservableCollection<MapsSymbol>
    {

        public SymbolCollection()
        {

        }

    }
    public class PathCollection : ObservableCollection<MapsPath>
    {

        public PathCollection()
        {

        }

    }


}
