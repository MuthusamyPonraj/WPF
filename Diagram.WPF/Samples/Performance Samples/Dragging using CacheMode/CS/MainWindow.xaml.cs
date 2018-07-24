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
using Syncfusion.Windows.Diagram;

namespace CacheModeDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //Call Creating Node
            CreateNode();
        }

        //Craeting the Node
        private void CreateNode()
        {
            double x = 50;
            double y = 50;
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    Node n = new Node() { OffsetX = x, OffsetY = y, Width = 150, Height = 300 };
                    diagramModel.Nodes.Add(n);
                    if (j == 19)
                    {
                        x = 50;
                    }
                    else
                    {
                        x += 20;
                    }
                }
                y += 20;
            }
        }

        #region Button EventHandlers

        //Enable the CacheMode
        private void onEnablecacheMode(object sender, RoutedEventArgs e)
        {
            foreach (Node node in diagramModel.Nodes)
            {
                node.CacheMode = new BitmapCache() { EnableClearType = false, RenderAtScale = 1, SnapsToDevicePixels = false };
                
                if(enable.IsChecked == true)
                {
                    disable.IsChecked = false;
                }
            }
        }

        //Disable the CacheMode
        private void ondisablecacheMode(object sender, RoutedEventArgs e)
        {
            foreach (Node node in diagramModel.Nodes)
            {
                node.CacheMode = null;// new BitmapCache() { EnableClearType = true, RenderAtScale = 1, SnapsToDevicePixels = true };       
                if(disable.IsChecked == true)
                {
                    enable.IsChecked = false;
                }
                
            }
        }
        #endregion
    }
}
