#region Copyright Syncfusion Inc. 2001 - 2010
// Copyright Syncfusion Inc. 2001 - 2010. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
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

namespace InPort_OutPortDemo
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        #region Public Variables

        Node oldNode;
        ConnectionPort oldPort;
        bool isHead;
        bool newConnDropped;
        #endregion

        #region Constructor

        //Window1 Constructor 
        public Window1()
        {
            InitializeComponent();

            //Register the Events for connectors
            diagramControl.View.ConnectorDragStart += new ConnDragChangedEventHandler(diagramView_ConnectorDragStart);
            diagramControl.View.ConnectorDragEnd += new ConnDragEndChangedEventHandler(diagramView_ConnectorDragEnd);
            diagramView.ConnectorCanRemoveSegments += new ConnectorCanRemoveSegmentsEventHandler(diagramView_ConnectorCanRemoveSegments);
            //Collection changed Events
            diagramControl.Model.Connections.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(Connections_CollectionChanged);
            this.diagramControl.Model.Nodes.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(Nodes_CollectionChanged);
            //diagramView.SizeToContent = false;
            //diagramView.PageBackground = new SolidColorBrush(Colors.SteelBlue);
            //diagramView.BoundaryConstraintsArea = new Rect(100, 100, 00, 700);
            //Creating  Node
            CreateNodes();
        }

        void diagramView_ConnectorCanRemoveSegments(object sender, ConnectorCanRemoveSegmentsEvtArgs evtArgs)
        {
            evtArgs.Remove = true;
        }

        //Collection changed events for getting the newitem refernce
        void Nodes_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null && e.NewItems.Count > 0)
            {
                (e.NewItems[0] as Node).Loaded += new RoutedEventHandler(Window1_Loaded);
            }
        }

        //ForEnabling the port visibility
        void Window1_Loaded(object sender, RoutedEventArgs e)
        {
            //((sender as Node).Ports[1] as ConnectionPort).Visibility = Visibility.Hidden;
        }

        #endregion

        #region Helper Methods

        //Defining the nodes.
        public void CreateNodes()
        {
            //Node n = addNode("", 100, 100, 60, 100);
            Node node1 = addNode("", 200, 200, 100, 60);
            ConnectionPort NewIdeaOut = addPort(node1, Brushes.Blue, Brushes.Blue, "In", 0, 10);
            ConnectionPort MeetingIn = addPort(node1, Brushes.Blue, Brushes.Blue, "In", 0, 50);
            ConnectionPort MeetingOut = addPort(node1, Brushes.Red, Brushes.Red, "Out", 100, 30);
            Node node2 = addNode("", 400, 300, 100, 60);
            ConnectionPort BoardDecisionIn = addPort(node2, Brushes.Blue, Brushes.Blue, "In", 0, 10);
            ConnectionPort BoardDecisionOut = addPort(node2, Brushes.Blue, Brushes.Blue, "In", 0, 50);
            ConnectionPort BoardDecisionOut2 = addPort(node2, Brushes.Red, Brushes.Red, "Out", 100, 30);
            Node node3 = addNode("", 600, 400, 100, 60);
            ConnectionPort projectIn = addPort(node3, Brushes.Blue, Brushes.Blue, "In", 0, 10);
            ConnectionPort projectOut = addPort(node3, Brushes.Blue, Brushes.Blue, "In", 0, 50);
            ConnectionPort projectOut2 = addPort(node3, Brushes.Red, Brushes.Red, "Out", 100, 30);
            Node node4 = addNode("A.B.C.D", 800, 400, 100, 60);
            Node node5 = addNode("A ", 100, 195, 30, 30);
            Node node6 = addNode("B ", 100, 235, 30, 30);
            Node node7 = addNode("C ", 100, 335, 30, 30);
            Node node8 = addNode("D ", 100, 435, 30, 30);

            //Creates the connections for the nodes.
            Connect(ConnectorType.Orthogonal, node1, node2, MeetingOut, BoardDecisionIn, "A.B");
            Connect(ConnectorType.Orthogonal, node2, node3, BoardDecisionOut2, projectIn, "A.B.C");
            Connect(ConnectorType.Straight, node3, node4, projectOut2, null, "A.B.C.D");
            Connect(ConnectorType.Straight, node1, node5, NewIdeaOut, null, null);
            Connect(ConnectorType.Straight, node1, node6, MeetingIn, null, null);
            Connect(ConnectorType.Straight, node2, node7, BoardDecisionOut, null, null);
            Connect(ConnectorType.Straight, node3, node8, projectOut, null, null);


            //setting the alignment and connection Port size
            foreach (Node node in diagramModel.Nodes)
            {
                node.LabelHorizontalAlignment = HorizontalAlignment.Center;
                node.LabelVerticalAlignment = VerticalAlignment.Center;
                node.HorizontalContentAlignment = HorizontalAlignment.Center;
                node.VerticalContentAlignment = VerticalAlignment.Center;
                foreach (ConnectionPort port in node.Ports)
                {
                    port.Width = 10;
                    port.Height = 10;
                }
            }
            newConnDropped = false;
        }


        //Revert chages if it is an invalid connection
        void diagramView_ConnectorDragEnd(object sender, ConnDragEndRoutedEventArgs evtArgs)
        {
            if (!newConnDropped)
            {
                //If HeadNode or HeadPort is changed
                if (isHead)
                {
                    //Revert changes if it is an invalid connection
                    if (evtArgs.Connector.HeadNode != null && evtArgs.Connector.ConnectionHeadPort != null)
                    {
                        if (!(evtArgs.Connector.ConnectionHeadPort.Tag as string).Contains("In"))
                        {
                            evtArgs.Connector.HeadNode = oldNode;
                            evtArgs.Connector.ConnectionHeadPort = oldPort;
                        }
                    }
                    else
                    {
                        evtArgs.Connector.HeadNode = oldNode;
                        evtArgs.Connector.ConnectionHeadPort = oldPort;
                    }
                }
                //If TailNode or TailPort is Changed
                if (!isHead)
                {
                    //Revert changes if it is an invalid connection
                    if (evtArgs.Connector.TailNode != null && evtArgs.Connector.ConnectionTailPort != null)
                    {
                        if (!(evtArgs.Connector.ConnectionTailPort.Tag as string).Contains("Out"))
                        {
                            evtArgs.Connector.TailNode = oldNode;
                            evtArgs.Connector.ConnectionTailPort = oldPort;
                        }
                    }
                    else
                    {
                        evtArgs.Connector.TailNode = oldNode;
                        evtArgs.Connector.ConnectionTailPort = oldPort;
                    }
                }
            }
            //If new connection  is created
            else
            {
                //If it is an invalid connection delete it.
                LineConnector DroppedConnector = evtArgs.Connector;
                if (DroppedConnector.HeadNode != null && DroppedConnector.ConnectionHeadPort != null)
                {
                    if (!(DroppedConnector.ConnectionHeadPort.Tag as string).Contains("Out"))
                    {
                        diagramControl.Model.Connections.Remove(DroppedConnector);
                    }
                }
                else
                {
                    diagramControl.Model.Connections.Remove(DroppedConnector);
                }

                if (DroppedConnector.TailNode != null && DroppedConnector.ConnectionTailPort != null)
                {
                    if (!(DroppedConnector.ConnectionTailPort.Tag as string).Contains("In"))
                    {
                        diagramControl.Model.Connections.Remove(DroppedConnector);
                    }
                }
                else
                {
                    diagramControl.Model.Connections.Remove(DroppedConnector);
                }
            }
            newConnDropped = false;
        }

        //Backup the reference, to revert the chages if it is invalid connection
        void diagramView_ConnectorDragStart(object sender, ConnDragRoutedEventArgs evtArgs)
        {
            LineConnector line = evtArgs.Connector;
            if (evtArgs.FixedNodeEnd == line.TailNode)
            {
                oldNode = line.HeadNode as Node;
                oldPort = line.ConnectionHeadPort;
                isHead = true;
            }
            else
            {
                oldNode = line.TailNode as Node;
                oldPort = line.ConnectionTailPort;
                isHead = false;
            }
        }

        //New connection is created.
        void Connections_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            newConnDropped = true;
        }

        #endregion

        #region Event Handlers

        //For Creating Orthogonal Line Connection
        private void Ortho_click(object sender, RoutedEventArgs e)
        {
            //Creates a Orthogonal connection.
            (diagramView.Page as DiagramPage).ConnectorType = ConnectorType.Orthogonal;
            diagramView.EnableConnection = true;
        }

        //For Creating Straight Line Connection
        private void Straight_Click(object sender, RoutedEventArgs e)
        {
            //Creates a Straight connection.
            (diagramView.Page as DiagramPage).ConnectorType = ConnectorType.Straight;
            diagramView.EnableConnection = true;
        }

        //For Creating Bezier Line Connection
        private void Bezier_click(object sender, RoutedEventArgs e)
        {
            //Creates a Bezier connection.
            (diagramView.Page as DiagramPage).ConnectorType = ConnectorType.Bezier;
            diagramView.EnableConnection = true;
        }

        //For Creating Arc Line Connection
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Creates a Arc connection.
            (diagramView.Page as DiagramPage).ConnectorType = ConnectorType.Arc;
            diagramView.EnableConnection = true;
        }
        #endregion

        #region PrivateFunctions

        //Add the Node to DiagramModel
        private Node addNode(String name, double offsetx, double offsety, double width, double height)
        {
            Node node = new Node(Guid.NewGuid());
            node.OffsetX = offsetx;
            node.OffsetY = offsety;
            node.Width = width;
            node.Height = height;

            if (name != "")
            {
                node.Shape = Shapes.Rectangle;
                Style s = new System.Windows.Style();
                s.BasedOn = node.CustomPathStyle;
                s.TargetType = typeof(Path);
                s.Setters.Add(new Setter(Path.FillProperty, new SolidColorBrush(Colors.Transparent)));
                s.Setters.Add(new Setter(Path.StrokeProperty, new SolidColorBrush(Colors.Transparent)));
                s.Setters.Add(new Setter(Path.StretchProperty, Stretch.Fill));
                node.CustomPathStyle = s;
                node.AllowSelect = false;
                node.Loaded += new RoutedEventHandler(node_Loaded);
                node.Label = name;
            }
            else
            {

                node.Shape = Shapes.CustomPath;
               
            }
            diagramModel.Nodes.Add(node);
           
            return node;

        }

        void node_Loaded(object sender, RoutedEventArgs e)
        {
            ((sender as Node).Ports[0] as ConnectionPort).Visibility = Visibility.Hidden;
        }

        //Add the ConnectionPort to the Node
        private ConnectionPort addPort(Node node, Brush fill, Brush stroke, String tag, Int32 p1, Int32 p2)
        {
            ConnectionPort port = new ConnectionPort(node, new Point(p1, p2));
            port.PortStyle.Fill = fill;
            port.PortStyle.Stroke = stroke;
            port.Tag = tag;
            node.Ports.Add(port);
            port.Node = node;
            return port;
        }

        //Creating the connection
        private LineConnector Connect(ConnectorType connType, Node headnode, Node tailnode, ConnectionPort headport, ConnectionPort tailport, string label)
        {
            LineConnector conn = new LineConnector();
            conn.ConnectorType = connType;
            conn.HeadNode = headnode;
            conn.TailNode = tailnode;
            conn.ConnectionHeadPort = headport;
            conn.ConnectionTailPort = tailport;
            conn.HeadDecoratorShape = DecoratorShape.None;
            conn.TailDecoratorShape = DecoratorShape.None;
            conn.LineStyle.Stroke = new SolidColorBrush(Colors.Brown);
            conn.Label = label;
            conn.FirstSegmentLength = 20;
            conn.LastSegmentLength = 20;
            conn.LabelHorizontalAlignment = HorizontalAlignment.Right;
            conn.LabelVerticalAlignment = VerticalAlignment.Center;
            diagramModel.Connections.Add(conn);
            if (conn.ConnectorType == ConnectorType.Orthogonal)
            {
                //conn.IntermediatePoints.RemoveAt(1);
                conn.AutoAdjustPoints = true;
            }
            return conn;
        }
        #endregion

    }

    #region NodeContent

    //Class for NodeContent
    public class NodeContent
    {
        public String NodeText { get; set; }
    }
    #endregion

}