
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
    using Syncfusion.Windows.Controls.Map;
    using System.Collections.ObjectModel;

    #region EventHelper

    public class ShapeFileEventHelper
    {
        static ShapeFilePanel canvas;
        private static MainWindow mainWindow;
        static ShapeFileLayer shapeLayer;
        static MapControl mapControl;

        public static readonly DependencyProperty ShapeFileEventsProperty = DependencyProperty.RegisterAttached("ShapeFileEvents", typeof(ICommand), typeof(ShapeFileEventHelper), new PropertyMetadata(null, new PropertyChangedCallback(OnShapeFileEventsChanged)));

        private static void OnShapeFileEventsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            shapeLayer = d as ShapeFileLayer;         
            if (shapeLayer != null)
            {
                mainWindow = ShapeFileEventHelper.FindParent<MainWindow>(shapeLayer) as MainWindow;
                mainWindow.btnReset.Click += new RoutedEventHandler(btnReset_Click);
                mapControl = ShapeFileEventHelper.FindParent<MapControl>(shapeLayer) as MapControl;
                shapeLayer.ShapesLoaded += new ShapesLoadedEventHandler(shapeLayer_ShapesLoaded);
                shapeLayer.ZoomedIn += new ZoomEventHandler(shapeLayer_ZoomedIn);
                shapeLayer.ZoomedOut += new ZoomEventHandler(shapeLayer_ZoomedOut);
                shapeLayer.Panning += new PanEventHandler(shapeLayer_Panning);
                shapeLayer.Panned += new PanEventHandler(shapeLayer_Panned);      
                
            }
        }

        static void btnReset_Click(object sender, RoutedEventArgs e)
        {
            if (mapControl != null)
            {
                mapControl.ZoomResetCommand.Execute(null);
                mapControl.PanResetCommand.Execute(null);               
            }
        }

        static void shapeLayer_ShapesLoaded(object sender, ShapesLoadedEventArgs args)
        {
            
            if ((sender as ShapeFileLayer).ShapeCollection.Count > 0)
            {
                canvas = VirtualizationViewModel.FindParent<ShapeFilePanel>((sender as ShapeFileLayer).ShapeCollection[0] as UIElement);
                ShapeFileEventHelper.GetShapeFileEvents(sender as ShapeFileLayer).Execute(canvas);
                canvas.LayoutUpdated += new EventHandler(canvas_LayoutUpdated);

            }
        }

        static void canvas_LayoutUpdated(object sender, EventArgs e)
        {
            ShapeFileEventHelper.GetShapeFileEvents(shapeLayer).Execute(canvas);              
        }

        static void shapeLayer_Panned(object sender, PanEventArgs args)
        {
            ShapeFileEventHelper.GetShapeFileEvents(sender as ShapeFileLayer).Execute(canvas);
        }

        static void shapeLayer_Panning(object sender, PanEventArgs args)
        {
            ShapeFileEventHelper.GetShapeFileEvents(sender as ShapeFileLayer).Execute(canvas);
        }

        static void shapeLayer_ZoomedOut(object sender, ZoomEventArgs args)
        {
            ShapeFileEventHelper.GetShapeFileEvents(sender as ShapeFileLayer).Execute(canvas);
        }

        static void shapeLayer_ZoomedIn(object sender, ZoomEventArgs args)
        {
            ShapeFileEventHelper.GetShapeFileEvents(sender as ShapeFileLayer).Execute(canvas);
        }
        public static ICommand GetShapeFileEvents(DependencyObject d)
        {
            return (ICommand)d.GetValue(ShapeFileEventsProperty);
        }
        public static void SetShapeFileEvents(DependencyObject d, ICommand value)
        {
            d.SetValue(ShapeFileEventsProperty, value);
        }
        
        internal static T FindParent<T>(UIElement control) where T : UIElement
        {
            if (control != null)
            {
                UIElement p = VisualTreeHelper.GetParent(control) as UIElement;
                if (p != null)
                {
                    if (p is T)
                        return p as T;
                    else
                        return ShapeFileEventHelper.FindParent<T>(p);
                }
            }
            return null;
        }
    }   

    #endregion
    
}
