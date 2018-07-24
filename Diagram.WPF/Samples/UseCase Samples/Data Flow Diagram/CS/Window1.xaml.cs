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
using System.Diagnostics;

namespace DataFlowDiagram_2008
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {

        public Window1()
        {
            InitializeComponent();

            //Creating Nodes
            InitializeNode();
        }

        #region HelperMethods

        //Creating Node and LineConnector
        private void InitializeNode()
        {
            Node Trans = CreateNode(2.84, 2.75, "(Temprary Data)", "Trans", 110, 180, Brushes.Black);
            Node Direct = CreateNode(4, 1, "(Possible Direct Editing)", "Trans", 140, 40, Brushes.Black);
            Direct.ContentTemplate = null;
            Node Trans2 = CreateNode(4.8, 3.7, "(Core Archive)", "Trans2", 110, 100, Brushes.Black);
            Trans2.LabelVerticalAlignment = VerticalAlignment.Top;
            Node Literature = CreateNode(1, 1, "Literature", "Green", 70, 40, Brushes.White);
            Node Experts = CreateNode(1, 2, "Experts", "Blue", 70, 40, Brushes.White);
            Node ListProducer = CreateNode(2, 3, "List Producer", "Blue", 70, 40, Brushes.White);
            Node TransferFormat = CreateNode(3, 3, "Transfer Format", "Yellow", 70, 40, Brushes.White);
            Node ListProducer2 = CreateNode(2, 4, "List Producer", "Blue", 70, 40, Brushes.White);
            Node TransferFormat2 = CreateNode(3, 4, "Transfer Format", "Yellow", 70, 40, Brushes.White);
            Node HoldingFormat = CreateNode(4, 4, "Holding Format", "Orange", 70, 40, Brushes.White);
            Node WebSite = CreateNode(5, 4, "WebSite", "Red", 70, 40, Brushes.White);
            Node Database = CreateNode(2, 5, "Database", "Orange", 70, 40, Brushes.White);
            Node TransferFormat3 = CreateNode(3, 5, "Transfer Format", "Yellow", 70, 40, Brushes.White);
            Node Database2 = CreateNode(2, 6, "Database", "Orange", 70, 40, Brushes.White);
            Node TransferFormat4 = CreateNode(3, 6, "Transfer Format", "Yellow", 70, 40, Brushes.White);
            Node CDRom = CreateNode(4, 6, "CDRom", "Red", 70, 40, Brushes.White);
            Node Reports = CreateNode(5, 6, "Reports", "Red", 70, 40, Brushes.White);

            //Intializing the connctions
            Connect(TransferFormat3, HoldingFormat, ConnectorType.Straight, 0);
            Connect(TransferFormat4, HoldingFormat, ConnectorType.Straight, 0);
            Connect(TransferFormat, HoldingFormat, ConnectorType.Straight, 0);
            Connect(Experts, ListProducer, ConnectorType.Straight, 1);
            Connect(Experts, ListProducer2, ConnectorType.Straight, 1);
            Connect(Literature, Experts, ConnectorType.Straight, 3);
            Connect(ListProducer, TransferFormat, ConnectorType.Straight, 3);
            Connect(ListProducer2, TransferFormat2, ConnectorType.Straight, 3);
            Connect(HoldingFormat, WebSite, ConnectorType.Straight, 3);
            Connect(Database, TransferFormat3, ConnectorType.Straight, 3);
            Connect(Database2, TransferFormat4, ConnectorType.Straight, 3);
            Connect(TransferFormat2, HoldingFormat, ConnectorType.Orthogonal, 3);
            Connect(HoldingFormat, CDRom, ConnectorType.Orthogonal, 3);
            Connect(HoldingFormat, Reports, ConnectorType.Orthogonal, 3);
            Connect(HoldingFormat, WebSite, ConnectorType.Straight, 3);
            Connect(ListProducer, WebSite, ConnectorType.Straight, 2);
        }

        //Add the connections to DiagramModel
        private void Connect(Node Head, Node Tail, ConnectorType CT, Int32 flag)
        {
            LineConnector line = new LineConnector();
            line.ConnectorType = CT;
            line.HeadNode = Head;
            line.TailNode = Tail;

            //Applying Style to the  DecoratorShape of LienConnector
            line.TailDecoratorStyle.Stroke = Brushes.Black;
            line.TailDecoratorStyle.Fill = Brushes.Black;
            line.TailDecoratorStyle.StrokeThickness = 1;

            //Applying Style to the LineConnector
            line.LineStyle.StrokeThickness = 1;
            line.LineStyle.Stroke = Brushes.Black;

            //Add the IntermediatePoints
            #region Modifing IntermediatePoints

            if (flag == 0)
            {
                line.IntermediatePoints.Add(new Point(Head.OffsetX + Head.Width + 32, Head.OffsetY + Head.Height / 2));
                line.IntermediatePoints.Add(new Point(Head.OffsetX + Head.Width + 32, Tail.OffsetY + Tail.Height / 2));
            }
            else if (flag == 1)
            {
                line.IntermediatePoints.Add(new Point(Head.OffsetX + Head.Width / 2, Tail.OffsetY + Tail.Height / 2));

            }
            else if (flag == 2)
            {
                line.IntermediatePoints.Add(new Point(Head.OffsetX + Head.Width / 2, 100));
                line.IntermediatePoints.Add(new Point(Tail.OffsetX + Tail.Width / 2, 100));
            }

            #endregion

            diagramModel.Connections.Add(line);
        }

        //Creating the Node
        private Node CreateNode(double x, double y, string Label, string Template, double width, double height, Brush foreground)
        {
            Node n = new Node();
            //Custom Label property to the Node
            n.LabelTextWrapping = TextWrapping.Wrap;
            n.LabelFontWeight = FontWeights.Light;
            n.LabelVerticalAlignment = VerticalAlignment.Center;
            n.Label = Label;
            n.LabelForeground = Brushes.AntiqueWhite;
            n.LabelForeground = foreground;
            n.Shape = Shapes.Default;
            //Upadting the Node's Position and Size
            UpadteNodeoffset(n, x, y);
            n.Width = width;
            n.Height = height;

            //template for the Node
            n.ContentTemplate = App.Current.FindResource(Template) as DataTemplate;
            diagramModel.Nodes.Add(n);
            return n;
        }

        //Function fro upateing the 
        private void UpadteNodeoffset(Node n, double x, double y)
        {
            n.OffsetX = x * 100;
            n.OffsetY = y * 100;
            //Update Node offsetx
            if (y == 4)
            {
                if (x == 4)
                {
                    n.OffsetX += 100;
                }
                else if (x == 5)
                {
                    n.OffsetX += 150;
                }
            }
            //Update Node offsetx
            if (y == 6)
            {
                if (x == 4 || x == 5)
                {
                    n.OffsetX += 50;
                    n.OffsetY -= 50;
                }
            }
        }
        #endregion
    }
}
