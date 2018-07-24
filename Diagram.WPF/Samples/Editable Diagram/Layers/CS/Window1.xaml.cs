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

namespace LayersDemo_2008
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {

        #region PublicVariables

        Layer Lan1;
        Layer Lan2;
        Layer Connections; 
        #endregion

        #region Constructor

        public Window1()
        {
            InitializeComponent();

            //Function to creates Nodes and Connections.
            CreateNodes();
        }
        #endregion

        #region Helper Methods
        
        //Creating the Node and LineConnnector
        private void CreateNodes()
        {
            List<Node> nodes;
            List<LineConnector> conns;

            //Nodes
            Node ws1 = addNodes("MyComputerIcon", "", new Point(216, 89), new Size(105, 75));
            Node ws2 = addNodes("MyComputerIcon", "", new Point(371, 312), new Size(105, 75));
            Node ws3 = addNodes("MyComputerIcon", "", new Point(216, 312), new Size(105, 75));
            Node ws4 = addNodes("MyComputerIcon", "", new Point(371, 89), new Size(105, 75));
            Node hub1 = addNodes("HUB", "Hub1", new Point(519, 221), new Size(80, 40));
            Node hub2 = addNodes("HUB", "Hub2", new Point(519, 460), new Size(80, 40));
            Node ser = addNodes("Server", "Server", new Point(734, 78), new Size(100, 110));
            Node pri = addNodes("Printer", "Printer", new Point(1022, 48), new Size(100, 100));
            Node mod = addNodes("ModemIcon", "Modem", new Point(1022, 206), new Size(80, 120));

            //LineConnectors
            LineConnector l1 = connect(hub1, ws1, "lan");
            LineConnector l2 = connect(hub1, ws4, "lan");
            LineConnector l3 = connect(hub2, ws2, "lan");
            LineConnector l4 = connect(hub2, ws3, "lan");
            LineConnector ser1 = connect(ser, hub1, "ser");
            LineConnector ser2 = connect(ser, hub2, "ser");
            LineConnector ser3 = connect(ser, pri, "ser");
            LineConnector ser4 = connect(ser, mod, "ser");

            #region AddintoLayers

            nodes = new List<Node>();
            nodes.Add(ws1);
            nodes.Add(ws4);
            nodes.Add(hub1);
            conns = new List<LineConnector>();
            conns.Add(l1);
            conns.Add(l2);
            conns.Add(ser1);
            Lan1 = addLayer("L1", nodes, conns);

            nodes = new List<Node>();
            nodes.Add(ws2);
            nodes.Add(ws3);
            nodes.Add(hub2);
            conns = new List<LineConnector>();
            conns.Add(l3);
            conns.Add(l4);
            conns.Add(ser2);
            Lan2 = addLayer("L2", nodes, conns); 
            #endregion

            //Connections
            conns = new List<LineConnector>();
            conns.Add(l1);
            conns.Add(l2);
            conns.Add(l2);
            conns.Add(ser2);
            conns.Add(l1);
            conns.Add(l2);
            conns.Add(l3);
            conns.Add(l4);
            conns.Add(ser1);
            conns.Add(ser2);
            conns.Add(ser3);
            conns.Add(ser4);
          
            Connections = addLayer("C1", null, conns);
        }

        //Creating the connection
        private LineConnector connect(Node hub1, Node ws1, string type)
        {
            LineConnector line = new LineConnector();
            line.ConnectorType = ConnectorType.Orthogonal;
            line.TailNode = hub1;
            line.HeadNode = ws1;
            line.TailDecoratorShape = DecoratorShape.None;
            line.HeadDecoratorShape = DecoratorShape.None;
            if (type == "lan")
            {
                line.LineStyle.Stroke = Brushes.Blue;
            }
            else if (type == "ser")
            {
                line.LineStyle.Stroke = Brushes.Brown;
            }
            diagramModel.Connections.Add(line);
            return line;
        }

        //add the Node to DiagramModel
        private Node addNodes(string p, string na, Point point, Size size)
        {
            Node n = new Node(Guid.NewGuid(), "EssentialWPF");
            n.Name = na;
            n.OffsetX = point.X;
            n.OffsetY = point.Y;
            n.Width = size.Width;
            n.Height = size.Height;
            n.Label = na;
            n.LabelHorizontalAlignment = HorizontalAlignment.Center;
            if (na.StartsWith("Hub"))
            {
                n.LabelVerticalTextAlignment = VerticalAlignment.Bottom;
            }
            else
            {
                n.LabelVerticalTextAlignment = VerticalAlignment.Top;
            }
            n.AllowResize = false;
            Image temp = this.Resources[p] as Image;
            Image image = new Image();
            image.Source = this.Resources[p] as DrawingImage;
            if (image.Source == null)
            {
                image.Source = temp.Source;
            }
            n.Content = image;
            diagramModel.Nodes.Add(n);
            return n;
        }

        #endregion

        #region Event Handler

        //Interaction for Lan1
        private void L1_Click(object sender, RoutedEventArgs e)
        {
            if (Lan1.Visible)
            {
                Lan1.Visible = false;
            }
            else
            {
                Lan1.Visible = true;
            }
        }

        //Interaction for Cables
        private void C_Click(object sender, RoutedEventArgs e)
        {

            if (Connections.Visible)
            {
                Connections.Visible = false;
            }
            else
            {
                Connections.Visible = true;
            }
        }

        //Interaction for lan2
        private void L2_Click(object sender, RoutedEventArgs e)
        {
            if (Lan2.Visible)
            {
                Lan2.Visible = false;
            }
            else
            {
                Lan2.Visible = true;
            }
        }

        #endregion

        #region PrivateFunctions

        //Add the Nodes into Layer
        private Layer addLayer(String name, List<Node> node, List<LineConnector> conn)
        {
            Layer lyr = new Layer();
            if (node != null)
            {
                foreach (Node n in node)
                {
                    lyr.Nodes.Add(n);
                }
            }
            if (conn != null)
            {
                foreach (LineConnector lc in conn)
                {
                    lyr.Lines.Add(lc);
                }
            }
            lyr.Background = Brushes.Transparent;
            diagramModel.Layers.Add(lyr);

            return lyr;
        }

        #endregion
    }
}
