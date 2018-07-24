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

namespace LineRoutingDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            createNodes();
            //diagramView.LineRoutingEnabled = true;
        }

        private void createNodes()
        {
            //Defines the nodes and adds them to the model.
            Node Start1 = addNode("Start1", 73, 34, Shapes.FlowChart_Terminator, "Begin", 100, 50);
            Node Start2 = addNode("Start2", 234, 34, Shapes.FlowChart_Terminator, "Begin", 100, 50);
            Node Start3 = addNode("Start3", 398, 34, Shapes.FlowChart_Terminator, "Begin", 100, 50);
            Node End1 = addNode("End1", 64, 508, Shapes.FlowChart_Terminator, "End", 100, 50);
            Node End2 = addNode("End2", 217, 528, Shapes.FlowChart_Terminator, "End", 100, 50);
            Node End3 = addNode("End3", 385, 508, Shapes.FlowChart_Terminator, "End", 100, 50);
            Node n1 = addNode("n1", 156, 96, Shapes.FlowChart_SequentialData, "", 50, 50);
            Node n2 = addNode("n2", 253, 135, Shapes.RoundedSquare, "", 50, 50);
            Node n3 = addNode("n3", 97, 171, Shapes.Plus, "", 78, 75);
            Node n4 = addNode("n4", 401, 184, Shapes.Star, "", 50, 50);
            Node n5 = addNode("n5", 175, 326, Shapes.Octagon, "", 50, 50);
            Node n6 = addNode("n6", 279, 252, Shapes.Star, "", 96, 113);
            Node n7 = addNode("n7", 87, 370, Shapes.FlowChart_Process, "", 50, 50);
            Node n8 = addNode("n8", 322, 394, Shapes.Triangle, "", 50, 50);
            Node n9 = addNode("n9", 342, 450, Shapes.FlowChart_PaperTape, "", 50, 50);

            //Creates the connections for the nodes.
            Connect(Start1, End2);
            Connect(Start2, End3);
            Connect(Start3, End1);
        }

        private Node addNode(String name, double offsetx, double offsety, Shapes shape, String label, double width, double height)
        {
            Node node = new Node(Guid.NewGuid(), name);
            node.OffsetX = offsetx;
            node.OffsetY = offsety;            
            node.Shape = shape;
            node.Label = label;            
            node.Width = width;
            node.Height = height;
            node.LabelVerticalAlignment = System.Windows.VerticalAlignment.Center;
            diagramModel.Nodes.Add(node);
            return node;
        }

        private void Connect(Node headnode, Node tailnode)
        {
            LineConnector conn = new LineConnector();
            conn.HeadNode = headnode;
            conn.TailNode = tailnode;
            diagramModel.Connections.Add(conn);
        }

        private void S_Click(object sender, RoutedEventArgs e)
        {
            diagramControl.Save();
        }

        private void L_Click(object sender, RoutedEventArgs e)
        {           
            diagramControl.Load();
        }

        private void lineRouting1_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)lineRouting1.IsChecked)
            {
                foreach (object o in diagramView.SelectionList)
                {
                    if (o is LineConnector)
                    {
                        (o as LineConnector).LineRoutingEnabled = true;
                    }
                }
            }
            else
            {
                foreach (object o in diagramView.SelectionList)
                {
                    if (o is LineConnector)
                    {
                        (o as LineConnector).LineRoutingEnabled = false;
                    }
                }
            }
        }

        private void treatObstacle_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)treatObstacle.IsChecked)
            {
                foreach (object o in diagramView.SelectionList)
                {
                    if (o is Node)
                    {
                        (o as Node).TreatAsObstacle = true;
                    }
                }
            }
            else
            {
                foreach (object o in diagramView.SelectionList)
                {
                    if (o is Node)
                    {
                        (o as Node).TreatAsObstacle = false;
                    }
                }
            }
        }
    }
}
