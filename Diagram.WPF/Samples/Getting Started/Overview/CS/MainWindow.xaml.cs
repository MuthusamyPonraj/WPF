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
using Syncfusion.Windows.Shared;

namespace OverviewDiagramSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Public Variables

        //Declaring the Public variables
        double startoffsetx = 0;
        double startoffsety = 0;
        int nodecount = 0;
        Point newNodePosition = new Point(20, 200);
        int j = 1;
        Window win = new Window();
        #endregion

        public MainWindow()
        {
            InitializeComponent();
            //CreateNode();
            Node node = new Node();
            node.ContentTemplate = this.Resources["nodecontent"] as DataTemplate;
            diagramModel.Nodes.Add(node);
                  
            this.Loaded += MainWindow_Loaded;
            this.Closed += new EventHandler(MainWindow_Closed);
        }

        public void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {     
            win.Height = 300;
            win.Width = 250;
            win.WindowStartupLocation = WindowStartupLocation.CenterOwner;            
            Overview over = new Overview();
            win.Title = "Overview Control";
            over.OverviewSourceAncestor = this;
            win.Content = over;
            win.Show();
        }

        void MainWindow_Closed(object sender, EventArgs e)
        {
            win.Close();
        }
    }
}
