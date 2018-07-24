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

namespace EdgeToEdgeDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Node cp1 = addNodes("MyComputerIcon", "CP1", new Point(250, 150), new Size(75, 75));
            Node cp2 = addNodes("MyComputerIcon", "CP2", new Point(525, 500), new Size(75, 75));
            Node cp3 = addNodes("MyComputerIcon", "CP3", new Point(750, 150), new Size(75, 75));
            
            Node hub1 = addNodes("HUB", "Hub1", new Point(541, 0), new Size(50, 50));
            Node hub2 = addNodes("HUB", "Hub2", new Point(977, 600), new Size(50, 50));
            Node ser = addNodes("Server", "Server", new Point(160,300), new Size(70, 120));
            Node pri = addNodes("Printer", "Printer", new Point(1081, 100), new Size(90, 100));
            Node mod = addNodes("ModemIcon", "Modem", new Point(1150, 300), new Size(50, 120));

            LineConnector line = createLineConnector(ser, mod, "LAN Connection");
            
           
            ConnectionPort p1 = AddPort(line, 0);
            ConnectionPort p2 = AddPort(line, 1);            
            ConnectionPort p3 = AddPort(line, 0.3);
            ConnectionPort p4 = AddPort(line, 0.6);
            ConnectionPort p5 = AddPort(line, 0.8);

            LineConnector line1 = AddLineConnectorToPort(hub1, p3);          
            ConnectionPort lp1 = AddPort(line1, 0.4);
            ConnectionPort lp2 = AddPort(line1, 0.6);

            LineConnector line2 = AddLineConnectorToPort(cp1, lp1);
            LineConnector line3 = AddLineConnectorToPort(cp3, lp2);
            LineConnector line4 = AddLineConnectorToPort(hub2, p4);
            ConnectionPort lp3 = AddPort(line4, 0.6);

            LineConnector line5 = AddLineConnectorToPort(cp2, lp3);
            LineConnector line6 = AddLineConnectorToPort(pri, p5);

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
            n.LabelHorizontalTextAlignment = HorizontalAlignment.Center;
            n.LabelVerticalTextAlignment = VerticalAlignment.Bottom;            
            Image temp = this.Resources[p] as Image;
            Image image = new Image();
            image.Source = this.Resources[p] as DrawingImage;
            if (image.Source == null)
            {
                image.Source = temp.Source;
            }
            n.Content = image;

            if (p == "Server" || p == "ModemIcon")
            {
                n.AllowMove = false;
            }
            diagramModel.Nodes.Add(n);
            return n;
        }

        LineConnector createLineConnector(Node headNode, Node tailNode,string label)
        {
            LineConnector line = new LineConnector();
            line.LineStyle.Stroke = new SolidColorBrush(Colors.Blue);
            line.HeadNode = headNode;
            line.TailNode = tailNode;
            line.Label = label;
            line.ConnectorType = ConnectorType.Straight;           
            diagramModel.Connections.Add(line);
            return line;
        }

        LineConnector AddLineConnectorToPort(Node headNode, ConnectionPort tailPort)
        {
            LineConnector line = new LineConnector();
            line.LineStyle.Stroke = new SolidColorBrush(Colors.Brown);
            line.TailDecoratorStyle.Stroke = new SolidColorBrush(Colors.Brown);
            line.TailDecoratorStyle.Fill = new SolidColorBrush(Colors.Brown);
            line.TailDecoratorShape = Syncfusion.Windows.Diagram.DecoratorShape.None;
            line.HeadNode = headNode;
            line.ConnectionTailPort = tailPort;
            diagramModel.Connections.Add(line);
            return line;
        }

        ConnectionPort AddPort(LineConnector l, double offset)
        {
            ConnectionPort port = new ConnectionPort();
            port.PortStyle.Stroke = new SolidColorBrush(Colors.OrangeRed);
            port.PortStyle.Fill = new SolidColorBrush(Colors.OrangeRed);
            port.Width = 10;
            port.Height = 10;
            port.PortOffset = offset;
            port.PortVisibility = PortVisibility.AlwaysVisible;
            l.Ports.Add(port);
            port.Edge = l;            
            return port;
            
        }


    }
}
