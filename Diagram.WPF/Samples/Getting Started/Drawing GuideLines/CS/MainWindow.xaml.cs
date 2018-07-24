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

namespace DrawingGuideLinesDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            diagramView.SnapToHorizontalGrid = true;
            diagramView.SnapToVerticalGrid = true;
            diagramModel.Connections.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(Connections_CollectionChanged);
            diagramView.SnapOffsetX = 1;
            diagramView.SnapOffsetY = 1;
            Node n1 = AddNode(90, 110, 100, 100, "NodeA", Shapes.RoundedRectangle);
            Node n2 = AddNode(150, 100, 100, 300, "NodeB", Shapes.Ellipse);
            Node n3 = AddNode(150, 90, 250, 100, "NodeC", Shapes.FlowChart_DirectData);
            Node n4 = AddNode(75, 80, 325, 300, "NodeD", Shapes.FlowChart_ManualOperation);
            Node n5 = AddNode(220, 70, 500, 100, "NodeE", Shapes.FlowChart_Terminator);
            Node n6 = AddNode(120, 100, 500, 300, "NodeF", Shapes.FlowChart_PaperTape);

            ConnectionPort n1c1 = port(20, 20, n1);
            ConnectionPort n1c2 = port(90, 70, n1);
            ConnectionPort n2c1 = port(20, 20, n2);
            ConnectionPort n2c2 = port(70, 130, n2);
            ConnectionPort n3c3 = port(20, 20, n3);
            ConnectionPort n3c5 = port(70, 120, n3);
            ConnectionPort n4c1 = port(10, 10, n4);
            ConnectionPort n4c2 = port(65, 55, n4);
            ConnectionPort n5c1 = port(20, 20, n5);
            ConnectionPort n5c2 = port(50, 200, n5);
            ConnectionPort n6c1 = port(20, 20, n6);
            ConnectionPort n6c2 = port(70, 90, n6);

            SnapNodeOnMovingNode.IsChecked = true;
        }

        void Connections_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (enableConnection.IsChecked == true)
            {
                enableConnection.IsChecked = false;
            }
        }

        Node AddNode(double width, double height, double offsetX, double offsetY, string label,Shapes shape)
        {
            Node node = new Node();
            node.Width = width;
            node.Height = height;
            node.OffsetX = offsetX;
            node.OffsetY = offsetY;
            node.Label = label;
            node.LabelFontWeight = FontWeights.Bold;
            node.Shape = shape;
            node.CustomPathStyle = CreateStyle(node, new SolidColorBrush(Colors.CadetBlue));
            diagramModel.Nodes.Add(node);
            return node;
        }

        Style CreateStyle(Node n, SolidColorBrush brush)
        {
            Style mystyle = new Style();
            mystyle.BasedOn = n.CustomPathStyle;
            mystyle.TargetType = typeof(Path);
            mystyle.Setters.Add(new Setter(Path.FillProperty, brush));
            mystyle.Setters.Add(new Setter(Path.StrokeProperty, null));
            mystyle.Setters.Add(new Setter(Path.StretchProperty, Stretch.Fill));
            return mystyle;
        }
            

        ConnectionPort port(double top, double left, Node node)
        {
            ConnectionPort c = new ConnectionPort();
            c.Width = 10;
            c.Height = 10;
            c.Top = top;
            c.Left = left;
            c.Node = node;
            node.Ports.Add(c);
            return c;

        }

        private void snapToObject_Click(object sender, RoutedEventArgs e)
        {
            if (diagramView.SnapSettings != null&&diagramView.SnapSettings.EnableSnapNode)
            {
                diagramView.SnapSettings.EnableSnapNode = false;
                leftSnap.IsChecked = false;
                rightSnap.IsChecked = false;
                topSnap.IsChecked = false;
                bottomSnap.IsChecked = false;
                centerXSanp.IsChecked = false;
                centerYSnap.IsChecked = false;
            }
            else
            {
                diagramView.SnapSettings = new SnapSettings() { EnableSnapNode=true};

                leftSnap.IsChecked = true;
                rightSnap.IsChecked = true;
                topSnap.IsChecked = true;
                bottomSnap.IsChecked = true;
                centerXSanp.IsChecked = true;
                centerYSnap.IsChecked = true;
            }
        }

        private void leftSnap_Click(object sender, RoutedEventArgs e)
        {
            if (diagramView.SnapSettings.Left)
            {
                diagramView.SnapSettings.Left = false;
            }
            else
            {
                diagramView.SnapSettings.Left = true;
            }
        }

        private void rightSnap_Click(object sender, RoutedEventArgs e)
        {
            if (diagramView.SnapSettings.Right)
            {
                diagramView.SnapSettings.Right = false;
            }
            else
            {
                diagramView.SnapSettings.Right = true;
            }
        }

        private void topSnap_Click(object sender, RoutedEventArgs e)
        {
            if (diagramView.SnapSettings.Top)
            {
                diagramView.SnapSettings.Top = false;
            }
            else
            {
                diagramView.SnapSettings.Top = true;
            }
        }

        private void bottomSnap_Click(object sender, RoutedEventArgs e)
        {
            if (diagramView.SnapSettings.Bottom)
            {
                diagramView.SnapSettings.Bottom = false;
            }
            else
            {
                diagramView.SnapSettings.Bottom = true;
            }
        }

        private void centerXSanp_Click(object sender, RoutedEventArgs e)
        {
            if (diagramView.SnapSettings.CenterX)
            {
                diagramView.SnapSettings.CenterX = false;
            }
            else
            {
                diagramView.SnapSettings.CenterX = true;
            }
        }

        private void centerYSnap_Click(object sender, RoutedEventArgs e)
        {
            if (diagramView.SnapSettings.CenterY)
            {
                diagramView.SnapSettings.CenterY = false;
            }
            else
            {
                diagramView.SnapSettings.CenterY = true;
            }
        }

        private void snapToPort_Click(object sender, RoutedEventArgs e)
        {
            if (diagramView.SnapSettings != null && diagramView.SnapSettings.EnableSnapPort)
            {
             

                foreach (Node node in diagramModel.Nodes)
                {
                    foreach (ConnectionPort port in node.Ports)
                    {
                        port.PortVisibility = PortVisibility.MouseOverNode;
                    }
                }
                diagramView.SnapSettings.EnableSnapPort = false;
            }
            else
            {
                diagramView.SnapSettings.EnableSnapPort = true;

                foreach (Node node in diagramModel.Nodes)
                {
                    foreach (ConnectionPort port in node.Ports)
                    {
                        port.PortVisibility = PortVisibility.AlwaysVisible;
                    }
                }
            }
        }

        private void enableConnection_Click(object sender, RoutedEventArgs e)
        {
           
            if (enableConnection.IsChecked==true)
            {
                diagramView.EnableConnection = true;
            }
            else
            {
                diagramView.EnableConnection = false;
            }
        }

        private void SnapNodeOnMovingNode_Checked_1(object sender, RoutedEventArgs e)
        {
            SnapToNodeOptions.Visibility = Visibility.Visible;
            diagramView.SnapSettings = null;
            diagramView.SnapSettings = new SnapSettings() { EnableSnapNode = true };
        }

        private void SnapPortOnMovingNode_Checked_1(object sender, RoutedEventArgs e)
        {
            diagramView.SnapSettings = null;
            SnapToNodeOptions.Visibility = Visibility.Hidden;
            diagramView.SnapSettings = new SnapSettings() { EnableSnapNode = true, NodeSnapMode = NodeSnapMode.Port };
        }

        private void SnapPortOnMovingPort_Checked_1(object sender, RoutedEventArgs e)
        {
            diagramView.SnapSettings = null;
            SnapToNodeOptions.Visibility = Visibility.Hidden;
            diagramView.SnapSettings = new SnapSettings() { EnableSnapPort = true };
        }


    }
}
