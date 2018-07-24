using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Syncfusion.Windows.Controls.Map;
using Syncfusion.Windows.SampleLayout;
namespace EventsDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : SampleLayoutWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            this.shapeControl.SizeChanged += new SizeChangedEventHandler(shapeControl_SizeChanged);
        }
        
       
        #region Map Event Handlers
        private void shapeControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            addToLog("Selected Items:" + e.AddedItems.Count.ToString() + ",Removed Items:" + e.RemovedItems.Count.ToString());
        }

        private void Map_ZoomedIn(object sender, Syncfusion.Windows.Controls.Map.ZoomEventArgs args)
        {
            addToLog("ZoomedIn:Longtitude" + args.Longitude.ToString() + "  Latitude:" + args.Latitude.ToString() + " ZoomFactor:" + args.ZoomFactor.ToString());
            if (args.ZoomFactor <= 1)
            {
                this.Map.EnablePan = false;
            }
            else
            {
                this.Map.EnablePan = true;
            }
        }

        private void Map_ZoomedOut(object sender, Syncfusion.Windows.Controls.Map.ZoomEventArgs args)
        {
            addToLog("ZoomedOut:Longtitude" + args.Longitude.ToString() + "  Latitude:" + args.Latitude.ToString() + " ZoomFactor:" + args.ZoomFactor.ToString());
            if (args.ZoomFactor <= 1)
            {
                this.Map.EnablePan = false;
            }
            else
            {
                this.Map.EnablePan = true;
            }
        }

        private void Map_PreviewZoomIn(object sender, Syncfusion.Windows.Controls.Map.ZoomEventArgs args)
        {
            addToLog("PreviewZoomIn:Longtitude" + args.Longitude.ToString() + "  Latitude:" + args.Latitude.ToString() + " ZoomFactor:" + args.ZoomFactor.ToString());

        }

        private void Map_PreviewZoomOut(object sender, Syncfusion.Windows.Controls.Map.ZoomEventArgs args)
        {
            addToLog("PreviewZoomOut:Longtitude" + args.Longitude.ToString() + "  Latitude:" + args.Latitude.ToString() + " ZoomFactor:" + args.ZoomFactor.ToString());

        }

        private void Map_Panned(object sender, Syncfusion.Windows.Controls.Map.PanEventArgs args)
        {
            addToLog("Panned:Longtitude" + args.Longitude.ToString() + "  Latitude:" + args.Latitude.ToString() + " Pan Direction:" + args.PanningDirection.ToString());

        }

        private void Map_Panning(object sender, Syncfusion.Windows.Controls.Map.PanEventArgs args)
        {
            addToLog("Panning:Longtitude" + args.Longitude.ToString() + "  Latitude:" + args.Latitude.ToString() + " Pan Direction:" + args.PanningDirection.ToString());

        }

        #endregion

        #region Internal Methods

        internal void addToLog(String str)
        {
            TextBlock lbl = new TextBlock();
            lbl.Text = str;
            lbl.Margin = new Thickness(0, 0, 0, 5);
            lbl.TextWrapping = TextWrapping.NoWrap;
            lbl.HorizontalAlignment = HorizontalAlignment.Left;
            disArea.Children.Add(lbl);
            Scroll.UpdateLayout();
            Scroll.ScrollToVerticalOffset(Scroll.ScrollableHeight);
        }

        #endregion

        #region Application EventHandlers
        void shapeControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (this.shapeControl.IsLoaded)
            {
                this.shapeControl.Refresh();
            }
        }
        #endregion

    }
}
