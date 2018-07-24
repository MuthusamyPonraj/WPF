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

namespace VirtualizationDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        #region Public Variables

        //Declaring the Public variables
        double startoffsetx = -200;
        double startoffsety = -150;
        int nodecount = 0;
        Point newNodePosition = new Point(20, 50);
        int j = 1; 
        #endregion

        #region Constructor

        public MainWindow()
        {
            InitializeComponent();
            // EnableVirtualization property is set to true.
            diagramView.EnableVirtualization = true;
            //EnableCaching property is set to true.
            diagramView.EnableCaching = true;
            // CreatingNode and Adding into DiagramModel
            CreateNode();
            // Creating LineConnector and Adding into DiagramModel
            CreateConnection();
            startoffsetx = 0;
        }
        #endregion

        #region Helping Methods

        // Creating Nodes
        private void CreateNode()
        {
            //Upadte the Node's position
            for (int j = 0; j < 200; j++)
            {
                for (int i = 0; i <200; i++)
                {
                    Node node = new Node();
                    node.Width = 75;
                    node.Height = 75;
                    startoffsetx=node.OffsetX = startoffsetx ;
                    startoffsety=node.OffsetY = startoffsety + 200;
                    node.Background = new SolidColorBrush(Colors.Orange);
                    diagramModel.Nodes.Add(node);
                }
                if (j == 0)
                    startoffsetx =  200;
                else
                    startoffsetx = j * 400+200;
                startoffsety=-150;
            }
        }

        // Creating Connections
        private void CreateConnection()
        {
            //Upadte the LineConnectors position
            for (int j = 0; j < 100; j++)
            {
                for (int i = 0; i < 100; i++)
                {
                    if (i != 99)
                    {
                        LineConnector line = new LineConnector();
                        line.ConnectorType = ConnectorType.Straight;
                        line.LineStyle.Stroke = new SolidColorBrush(Colors.SteelBlue);
                        line.HeadDecoratorStyle.Stroke = new SolidColorBrush(Colors.SteelBlue);
                        line.TailDecoratorStyle.Stroke = new SolidColorBrush(Colors.SteelBlue);
                        line.HeadNode = diagramModel.Nodes[i + j * 100] as Node;
                        line.TailNode = diagramModel.Nodes[i + (j * 100) + 1] as Node;
                        diagramModel.Connections.Add(line);
                    }
                }
            }
        }
      
        #endregion

        #region Event Handlers

        // Adding Nodes to the DiagramModel
        private void AddNode_Click(object sender, RoutedEventArgs e)
        {
            if (nodecount > 0)
            {
                for (int i = 0; i < nodecount; i++)
                {
                    Node node = new Node();
                    node.Width = 75;
                    node.Height = 75;
                    node.OffsetX = newNodePosition.X;
                    node.OffsetY = newNodePosition.Y;

                    node.Background = new SolidColorBrush(Colors.SteelBlue);
                    diagramModel.Nodes.Add(node);
                    newNodePosition = new Point(newNodePosition.X, newNodePosition.Y + 200);
                    if (newNodePosition.Y > 100 * 200)
                    {
                        newNodePosition.X += 390;
                        newNodePosition.Y = 50;
                    }
                }
            }
            //Upadte the DiagramPage
            diagramView.Page.InvalidateMeasure();
            diagramView.Page.InvalidateArrange();

            string msg = ("No Of Nodes Added                : " + nodecount.ToString() + "\n" + "Total No Of Nodes and LineConnectors : " + (diagramModel.Nodes.Count + diagramModel.Connections.Count).ToString());
            MessageBox.Show(msg, "Diagram Details", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        // Node Count Value
        private void addnodecount_LostFocus(object sender, RoutedEventArgs e)
        {
            int count;
            if (int.TryParse(addnodecount.Text.ToString(), out count))
            {
                if (addnodecount.Text == string.Empty)
                {
                    MessageBox.Show("Please Check the Given Node Count");
                }
                else if (count > 0)
                {
                    nodecount = count;
                }
                else
                {
                    MessageBox.Show("Please Check the Given Node Count");
                }
            }
            nodecount = count;
        }

        // EnableCaching Property true
        private void EnableCaching_Checked(object sender, RoutedEventArgs e)
        {
            if (diagramView != null)
            {
                diagramView.EnableCaching = true;
                diagramView.Page.InvalidateMeasure();
                diagramView.Page.InvalidateArrange();
            }
        }

        //EnableConnection Property False
        private void EnableCaching_Unchecked(object sender, RoutedEventArgs e)
        {
            if (diagramView != null)
            {
                diagramView.EnableCaching = false;
                diagramView.Page.InvalidateMeasure();
                diagramView.Page.InvalidateArrange();
            }
        } 
        #endregion

    }

}
