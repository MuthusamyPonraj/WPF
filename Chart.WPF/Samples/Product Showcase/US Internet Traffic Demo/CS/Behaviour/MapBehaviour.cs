using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Interactivity;
using Syncfusion.Windows.Controls.Map;
using System.Text;
using System.Windows;

namespace USInternetTrafficDemo
{
    class MapBehaviour:Behavior<ShapeFileLayer>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            this.AssociatedObject.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(AssociatedObject_SelectionChanged);            
        }

        void AssociatedObject_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            double lat = (sender as ShapeFileLayer).LatLonPoint.X;
            double lon = (sender as ShapeFileLayer).LatLonPoint.Y;
            Point point;
            Random rand = new Random();
            point = (sender as ShapeFileLayer).LatitudeLongitudeToPoint(new Point(lat, lon));

            FrameworkElement element = (sender as ShapeFileLayer).PointToElement(point);
            if (element == null)
                return;
            (sender as ShapeFileLayer).Tag = element.Tag as StateWiseWebPageUsageModel;           
        }      
    }
}
