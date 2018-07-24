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
using Syncfusion.Windows.Tools;

namespace ConnectionPortsDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        #region Constructor

        public MainWindow()
        {
            InitializeComponent();

            //Create the Nodes
            CreateNodesforAgentCommunication();

            //Register the Event Handlers for Updating the Values
            diagramView.ConnectorSelected += new ConnectorSelectedEventHandler(diagramView_ConnectorSelected);
            diagramView.NodeSelected += new NodeEventHandler(diagramView_NodeSelected);
            diagramView.ConnectorUnSelected += new ConnectorUnSelectedEventHandler(diagramView_ConnectorUnSelected);
            diagramView.NodeUnSelected += new NodeEventHandler(diagramView_NodeUnSelected);
            nodevis.IsEnabled = false;
            //diagramView.ItemSelectionMode = ItemSelectionMode.Single;
            diagramView.Loaded += new RoutedEventHandler(diagramView_Loaded);
        }

        void diagramView_Loaded(object sender, RoutedEventArgs e)
        {
            nodevis.IsEnabled = false;
            Linegrid.IsEnabled = false;
            NodeExp.IsEnabled = false;
            lineexpander.IsEnabled = false;
        }
        #endregion

        #region Update Values

        //Enable/Disable the Node Portvisiblity
        void diagramView_NodeUnSelected(object sender, NodeRoutedEventArgs evtArgs)
        {
            nodevis.IsEnabled = false;
            NodeExp.IsEnabled = false;
            NodeExp.IsExpanded = false;
        }

        //Update the Values 
        void diagramView_ConnectorUnSelected(object sender, ConnectorRoutedEventArgs evtArgs)
        {
            Linegrid.IsEnabled = true;
            lineexpander.IsEnabled = false;
            lineexpander.IsExpanded = false;
            TopValue.Text = String.Empty;
            LeftValue.Text = String.Empty;
            WidthValue.Text = String.Empty;
            HeightValue.Text = String.Empty;
            head.ToolTip = "Select a LineConnector";
            tail.ToolTip = "Select a LineConnector";
            Linegrid.ToolTip = "Select a LineConnector";
            head.IsChecked = false;
            tail.IsChecked = false;
            fill.Color = Colors.Black;
            stroke.Color = Colors.Black;
           
        }

        //Enable/Disable the Node Portvisiblity
        void diagramView_NodeSelected(object sender, NodeRoutedEventArgs evtArgs)
        {
            nodevis.IsEnabled = true;
            NodeExp.IsEnabled = true;
            NodeExp.IsExpanded = true;
            lineexpander.ToolTip = "Please select a LineConnector for customizing";
        }

        //Update the Values 
        void diagramView_ConnectorSelected(object sender, ConnectorRoutedEventArgs evtArgs)
        {
            Linegrid.IsEnabled = true;
            lineexpander.IsEnabled = true;
            lineexpander.IsExpanded = true;
            LineConnector selectedline = (evtArgs.Connector as LineConnector);
            CustomPortShape.ToolTip = "Select Custom PortShape";
            Linegrid.ToolTip = "Provide the Custom Values";
            WidthValue.IsEnabled = false;
            HeightValue.IsEnabled = false;
            TopValue.IsEnabled = false;
            LeftValue.IsEnabled = false;
            top.IsEnabled = false;
            left.IsEnabled = false;
            width.IsEnabled = false;
            height.IsEnabled = false;
            fill.IsEnabled = false;
            Fill.IsEnabled = false;
            fill.Opacity = 0.1;
            stroke.Opacity =0.1;
            stroke.IsEnabled = false;
            Stroke.IsEnabled = false;
            portshape.IsEnabled = false;
            customshape.IsEnabled = false;
            DefualtShape.IsEnabled = false;
        }

        void Nodes_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                if (e.NewItems[0] != null)
                {
                    if (e.NewItems[e.NewItems.Count - 1] is Node)
                    {
                        if ((e.NewItems[e.NewItems.Count - 1] as Node).Ports.Count > 0)
                        {
                            (e.NewItems[e.NewItems.Count - 1] as Node).Ports.RemoveAt(0);
                        }
                    }
                }
            }
        }
        #endregion

        #region PrivateFunctions

        //Creating the Nodes
        private void CreateNodesforAgentCommunication()
        {
            Node n = addNode("Download trial", 200, 100, Shapes.FlowChart_Terminator, new SolidColorBrush(Colors.YellowGreen));
            Node n1 = addNode("Select product to buy", 200, 200, Shapes.Rectangle, new SolidColorBrush(Colors.SteelBlue));
            Node n2 = addNode("Payment mode", 200, 300, Shapes.FlowChart_Decision, new SolidColorBrush(Colors.SpringGreen));
            Node n3 = addNode("Click order button", 200, 400, Shapes.Rectangle, new SolidColorBrush(Colors.SteelBlue));
            Node n4 = addNode("Enter order details", 350, 400, Shapes.Rectangle, new SolidColorBrush(Colors.SteelBlue));
            Node n5 = addNode("Get conformation", 500, 400, Shapes.FlowChart_Document, new SolidColorBrush(Colors.SlateBlue));
            Node n6 = addNode("Register product", 500, 500, Shapes.Rectangle, new SolidColorBrush(Colors.SteelBlue));
            Node n7 = addNode("Done", 500, 600, Shapes.FlowChart_Terminator, new SolidColorBrush(Colors.YellowGreen));
            Node n8 = addNode("Submit payment", 350, 300, Shapes.Rectangle, new SolidColorBrush(Colors.SteelBlue));
            Node n9 = addNode("Receive invoice", 500, 300, Shapes.Rectangle, new SolidColorBrush(Colors.SteelBlue));
            //Ports for DownLoad Trial
            ConnectionPort cp = Addcport(n, n.Height, n.Width / 2, new SolidColorBrush(Colors.Red), PortShapes.Diamond);
            //Port for Supervisory Agent
            ConnectionPort cp1 = Addcport(n1, 0, n1.Width / 2, new SolidColorBrush(Colors.Green), PortShapes.Circle);
            ConnectionPort cp2 = Addcport(n1, n1.Height, n1.Width / 2, new SolidColorBrush(Colors.Green), PortShapes.Diamond);
            //Port for Simulator Agent
            ConnectionPort cp3 = Addcport(n2, 0, n2.Width / 2, new SolidColorBrush(Colors.YellowGreen), PortShapes.Arrow);
            ConnectionPort cp4 = Addcport(n2, n2.Height, n2.Width / 2, new SolidColorBrush(Colors.YellowGreen), PortShapes.Arrow);
            ConnectionPort cp16 = Addcport(n2, n2.Height / 2, n2.Width, new SolidColorBrush(Colors.YellowGreen), PortShapes.Arrow);

            //Port for Mobile Robot Agent
            ConnectionPort cp5 = Addcport(n3, 0, n3.Width / 2, new SolidColorBrush(Colors.Red), PortShapes.Circle);
            ConnectionPort cp6 = Addcport(n3, n3.Height / 2, n3.Width, new SolidColorBrush(Colors.Green), PortShapes.Circle);
            //Port for Manipulator Robot Agent
            ConnectionPort cp7 = Addcport(n4, n4.Height / 2, 0, new SolidColorBrush(Colors.Red), PortShapes.Circle);
            ConnectionPort cp8 = Addcport(n4, n4.Height / 2, n4.Width, new SolidColorBrush(Colors.Green), PortShapes.Circle);
            //Port for Recive Mail
            ConnectionPort cp9 = Addcport(n5, n5.Height / 2, 0, new SolidColorBrush(Colors.Red), PortShapes.Circle);
            ConnectionPort cp10 = Addcport(n5, n5.Height, n5.Width / 2, new SolidColorBrush(Colors.Green), PortShapes.Circle);
            ConnectionPort cp19 = Addcport(n5, 0, n5.Width / 2, new SolidColorBrush(Colors.Green), PortShapes.Circle);
            //Port for regiter product
            ConnectionPort cp11 = Addcport(n6, 0, n6.Width / 2, new SolidColorBrush(Colors.Red), PortShapes.Circle);
            ConnectionPort cp12 = Addcport(n6, n6.Height, n6.Width / 2, new SolidColorBrush(Colors.Green), PortShapes.Circle);
            //Port for regiter product
            ConnectionPort cp13 = Addcport(n7, 0, n7.Width / 2, new SolidColorBrush(Colors.Red), PortShapes.Diamond);
            //Port for regiter product
            ConnectionPort cp14 = Addcport(n8, n8.Height / 2, 0, new SolidColorBrush(Colors.Red), PortShapes.Circle);
            ConnectionPort cp15 = Addcport(n8, n8.Height / 2, n8.Width, new SolidColorBrush(Colors.Red), PortShapes.Circle);

            //Port for regiter product
            ConnectionPort cp17 = Addcport(n9, n9.Height / 2, 0, new SolidColorBrush(Colors.Red), PortShapes.Circle);
            ConnectionPort cp18 = Addcport(n9, n9.Height, n9.Width / 2, new SolidColorBrush(Colors.Red), PortShapes.Circle);

            connection(n, n1, cp, cp1, "");
            connection(n1, n2, cp2, cp3, "");
            connection(n2, n3, cp4, cp5, "CC");
            connection(n3, n4, cp6, cp7, "");
            connection(n4, n5, cp8, cp9, "");
            connection(n5, n6, cp10, cp11, "");
            connection(n6, n7, cp12, cp13, "");
            connection(n2, n8, cp16, cp14, "Check");
            connection(n8, n9, cp15, cp17, "");
            connection(n9, n5, cp18, cp19, "");
            diagramModel.Nodes.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(Nodes_CollectionChanged);

        }

        //Add connection port to Nodes
        private ConnectionPort Addcport(Node n, double top, double left, SolidColorBrush solidColorBrush, PortShapes ps)
        {
            ConnectionPort cp = new ConnectionPort(n, new Point(left, top));
            cp.PortShape = ps;
            cp.Width = 12;
            cp.Height = 12;
            cp.PortStyle.Fill = solidColorBrush;
            cp.Node = n;
            n.Ports.Add(cp);
            return cp;
        }

        //Add the Node to the DiagramModel
        private Node addNode(string name, double offsetx, double offsety, Shapes sp, SolidColorBrush solidcolorbrush)
        {
            Node Agent = new Node();

            if (sp == Shapes.FlowChart_Terminator)
            {
                Agent.Height = 50;
            }
            else
            {
                Agent.Height = 60;
            }

            Agent.Width = 100;
            Agent.Shape = sp;
            Agent.OffsetX = offsetx;
            Agent.OffsetY = offsety;
            Agent.Label = name;
            Agent.LabelHorizontalAlignment = HorizontalAlignment.Center;
            Agent.LabelVerticalAlignment = VerticalAlignment.Center;
            Agent.EnableMultilineLabel = true;
            Agent.LabelTextWrapping = TextWrapping.Wrap;
            Style s = new System.Windows.Style();
            s.BasedOn = Agent.CustomPathStyle;
            s.TargetType = typeof(Path);
            s.Setters.Add(new Setter(Path.FillProperty, solidcolorbrush));
            //s.Setters.Add(new Setter(Path.StrokeProperty, new SolidColorBrush(Colors.Black)));
            //s.Setters.Add(new Setter(Path.StrokeThicknessProperty, 2d));
            s.Setters.Add(new Setter(Path.StretchProperty, Stretch.Fill));
            Agent.CustomPathStyle = s;
            Agent.Loaded += new RoutedEventHandler(Agent_Loaded);
            //Agent.PortVisibility = Syncfusion.Windows.Diagram.PortVisibility.MouseOverNode;
                //System.Windows.Visibility.Collapsed;
            diagramModel.Nodes.Add(Agent);
            return Agent;
        }

        void Agent_Loaded(object sender, RoutedEventArgs e)
        {
          (e.Source as Node).Ports[0].Visibility = Visibility.Collapsed;
        }

        //Creating the LineConnector
        private LineConnector connection(Node head, Node tail, ConnectionPort headport, ConnectionPort tailport, string label)
        {
            LineConnector flow = new LineConnector();
            flow.HeadNode = head;
            flow.TailNode = tail;
            flow.ConnectionHeadPort = headport;
            flow.ConnectionTailPort = tailport;
            flow.ConnectorType = ConnectorType.Straight;
            flow.TailDecoratorShape = DecoratorShape.None;
            flow.LineStyle.Stroke = new SolidColorBrush(Colors.Brown);
            flow.Label = label;
            flow.LabelHorizontalAlignment = HorizontalAlignment.Center;
            flow.LabelVerticalAlignment = VerticalAlignment.Center;
            diagramModel.Connections.Add(flow);
            return flow;

        }

        //Add connectionport to the Node 
        private ConnectionPort addPort(Node node, string customstyle, bool head, LineConnector line)
        {
            ConnectionPort cp = null;
            if (head)
            {
                cp = new ConnectionPort();
                cp.Width = 20;
                cp.Height = 20;
                cp.PortShape = PortShapes.Custom;
                if (line.ConnectionHeadPort == null)
                {
                    cp.Top = 20;
                    cp.Left = 20;
                    cp.CustomPathStyle = this.Resources[customstyle] as Style;
                    line.ConnectionHeadPort = cp;
                }
                else
                {
                    ConnectionPort headport = (line.ConnectionHeadPort as ConnectionPort);
                    cp.Top = headport.Top;
                    cp.Left = headport.Left;
                    node.Ports.Remove(headport);
                    cp.CustomPathStyle = this.Resources[customstyle] as Style;
                    line.ConnectionHeadPort = cp;
                }
                node.Ports.Add(cp);
                cp.Node = node;
            }
            else if (!head)
            {
                cp = new ConnectionPort();
                cp.Width = 20;
                cp.Height = 20;
                cp.PortShape = PortShapes.Custom;
                if (line.ConnectionTailPort == null)
                {
                    cp.Top = 20;
                    cp.Left = 20;
                    cp.CustomPathStyle = this.Resources[customstyle] as Style;
                    line.ConnectionTailPort = cp;
                }
                else
                {
                    ConnectionPort tailport = (line.ConnectionTailPort as ConnectionPort);
                    cp.Top = tailport.Top;
                    cp.Left = tailport.Left;
                    node.Ports.Remove(tailport);
                    cp.CustomPathStyle = this.Resources[customstyle] as Style;
                    line.ConnectionTailPort = cp;
                }
                node.Ports.Add(cp);
                cp.Node = node;
            }
            return cp;
        }

        private ConnectionPort addcport(Node node, PortShapes sp, bool head, LineConnector line)
        {
            ConnectionPort cp = null;
            if (head)
            {
                cp = new ConnectionPort();
                cp.Width = 10;
                cp.Height = 10;
                if (line.ConnectionHeadPort == null)
                {
                    cp.Top = 20;
                    cp.Left = 20;
                    cp.PortShape = sp;
                    line.ConnectionHeadPort = cp;
                }
                else
                {
                    ConnectionPort headport = (line.ConnectionHeadPort as ConnectionPort);
                    cp.Top = headport.Top;
                    cp.Left = headport.Left;
                    node.Ports.Remove(headport);
                    cp.PortShape = sp;
                    line.ConnectionHeadPort = cp;
                }
                node.Ports.Add(cp);
                cp.Node = node;
            }
            else if (!head)
            {
                cp = new ConnectionPort();
                cp.Width = 10;
                cp.Height = 10;
                cp.PortShape = sp;
                if (line.ConnectionTailPort == null)
                {
                    cp.Top = 20;
                    cp.Left = 20;
                    cp.PortShape = sp;
                    line.ConnectionTailPort = cp;
                }
                else
                {
                    ConnectionPort tailport = (line.ConnectionTailPort as ConnectionPort);
                    cp.Top = tailport.Top;
                    cp.Left = tailport.Left;
                    node.Ports.Remove(tailport);
                    cp.PortShape = sp;
                    line.ConnectionTailPort = cp;
                }
                node.Ports.Add(cp);
                cp.Node = node;
            }
            return cp;
        }

        #endregion

        #region EventHandlers

        //Apply the PortShape to the connectionPorts
        private void PortStyle_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cb = (sender as ComboBox);

            if (diagramView.SelectionList.Count > 0)
            {
                foreach (object o in diagramView.SelectionList)
                {
                    if (o is LineConnector)
                    {
                        LineConnector line = (o as LineConnector);

                        //Head port is Selected
                        if (head.IsChecked == true)
                        {
                            ConnectionPort heasdport = (line.ConnectionHeadPort as ConnectionPort);
                            //for applying the custom port shape
                            if (cb.Name == "CustomPortShape")
                            {
                                string port = "port";
                                line.ConnectionHeadPort = addPort((line.HeadNode as Node), port + "" + cb.SelectedIndex, true, line);
                            }
                            else if (cb.Name == "DefualtShape")
                            {
                                Node node = (line.HeadNode as Node);

                                UpdatePortShape(node, cb.SelectedIndex, true, line);
                            }

                        }
                        //Tailport is selected
                        if (tail.IsChecked == true)
                        {
                            ConnectionPort tailport = (line.ConnectionTailPort as ConnectionPort);
                            if (cb.Name == "CustomPortShape")
                            {
                                string port = "port";
                                line.ConnectionTailPort = addPort(line.TailNode as Node, port + "" + cb.SelectedIndex, false, line);
                            }
                            else if (cb.Name == "DefualtShape")
                            {
                                Node node1 = (line.TailNode as Node);

                                UpdatePortShape(node1, cb.SelectedIndex, false, line);
                            }

                        }
                    }
                }
            }
        }


        private void UpdatePortShape(Node node, int index, bool head, LineConnector selectedline)
        {
            if (head)
            {
                switch (index)
                {
                    case 0:
                        ConnectionPort c = addcport(node, PortShapes.Arrow, true, selectedline);
                        CustomPortShape.IsEnabled = false;
                        break;
                    case 1:
                        ConnectionPort c1 = addcport(node, PortShapes.Circle, true, selectedline);
                        selectedline.ConnectionHeadPort = c1;
                        CustomPortShape.IsEnabled = false;
                        break;
                    case 2:
                        CustomPortShape.IsEnabled = true;

                        break;
                    case 3:
                        ConnectionPort c2 = addcport(node, PortShapes.Diamond, true, selectedline);
                        selectedline.ConnectionHeadPort = c2;
                        CustomPortShape.IsEnabled = false;
                        break;
                    case 4:
                        ConnectionPort c3 = addcport(node, PortShapes.None, true, selectedline);
                        selectedline.ConnectionHeadPort = c3;
                        CustomPortShape.IsEnabled = false;
                        break;
                }
            }
            else
            {
                switch (index)
                {
                    case 0:
                        ConnectionPort c = addcport(node, PortShapes.Arrow, false, selectedline);
                        selectedline.ConnectionTailPort = c;
                        CustomPortShape.IsEnabled = false;
                        break;
                    case 1:
                        ConnectionPort c1 = addcport(node, PortShapes.Circle, false, selectedline);
                        selectedline.ConnectionTailPort = c1;
                        CustomPortShape.IsEnabled = false;
                        break;
                    case 2:
                        CustomPortShape.IsEnabled = true;

                        break;
                    case 3:
                        ConnectionPort c2 = addcport(node, PortShapes.Diamond, false, selectedline);
                        selectedline.ConnectionTailPort = c2;
                        CustomPortShape.IsEnabled = false;
                        break;
                    case 4:
                        ConnectionPort c3 = addcport(node, PortShapes.None, false, selectedline);
                        selectedline.ConnectionTailPort = c3;
                        CustomPortShape.IsEnabled = false;
                        break;
                }
            }
        }

        //Apply the Top and Left value to the ConnectionPort
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox tb = (sender as TextBox);

            if (diagramView.SelectionList.Count > 0)
            {
                if (head.IsChecked == true)
                {
                    foreach (object o in diagramView.SelectionList)
                    {
                        if (o is LineConnector)
                        {
                            ConnectionPort cp = (o as LineConnector).ConnectionHeadPort;
                            if (tb.Name == "TopValue")
                            {
                                if (tb.Text != string.Empty)
                                {
                                    cp.Top = double.Parse(tb.Text);

                                }
                            }
                            else if (tb.Name == "LeftValue")
                            {
                                if (tb.Text != string.Empty)
                                {
                                    cp.Left = double.Parse(tb.Text);
                                }

                            }
                            else if (tb.Name == "WidthValue")
                            {
                                if (tb.Text != string.Empty)
                                {
                                    cp.Width = double.Parse(tb.Text);
                                }
                            }
                            else if (tb.Name == "HeightValue")
                            {
                                if (tb.Text != string.Empty)
                                {
                                    cp.Height = double.Parse(tb.Text);
                                }
                            }

                        }
                    }
                }
                else if (tail.IsChecked == true)
                {
                    foreach (object o in diagramView.SelectionList)
                    {
                        if (o is LineConnector)
                        {
                            ConnectionPort cp = (o as LineConnector).ConnectionTailPort;
                            if (tb.Name == "TopValue")
                            {
                                if (tb.Text != string.Empty)
                                {
                                    cp.Top = double.Parse(tb.Text);
                                }
                            }
                            else if (tb.Name == "LeftValue")
                            {
                                if (tb.Text != string.Empty)
                                {
                                    cp.Left = double.Parse(tb.Text);
                                }
                            }
                            else if (tb.Name == "WidthValue")
                            {
                                if (tb.Text != string.Empty)
                                {
                                    cp.Width = double.Parse(tb.Text);
                                }
                            }
                            else if (tb.Name == "HeightValue")
                            {
                                if (tb.Text != string.Empty)
                                {
                                    cp.Height = double.Parse(tb.Text);
                                }
                            }

                        }
                    }
                }
            }

        }

        //Fill and Stroke Color changed
        private void fill_ColorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Syncfusion.Windows.Tools.Controls.ColorPickerPalette cpp = d as Syncfusion.Windows.Tools.Controls.ColorPickerPalette;
            if (diagramView.SelectionList.Count > 0)
            {
                if (head.IsChecked == true)
                {
                    foreach (object o in diagramView.SelectionList)
                    {
                        if (o is LineConnector)
                        {
                            ConnectionPort cp = (o as LineConnector).ConnectionHeadPort;
                            if (cpp.Name == "fill")
                            {
                                UpdateAppearance(cp, new SolidColorBrush(fill.Color), true);
                            }
                            else if (cpp.Name == "stroke")
                            {
                                UpdateAppearance(cp, new SolidColorBrush(stroke.Color), false);
                            }
                        }
                    }

                }
                else if (tail.IsChecked == true)
                {
                    foreach (object o in diagramView.SelectionList)
                    {
                        if (o is LineConnector)
                        {
                            ConnectionPort cp = (o as LineConnector).ConnectionTailPort;
                            if (cpp.Name == "fill")
                            {
                                UpdateAppearance(cp, new SolidColorBrush(fill.Color), true);
                            }
                            else if (cpp.Name == "stroke")
                            {
                                UpdateAppearance(cp, new SolidColorBrush(stroke.Color), false);
                            }
                        }
                    }

                }
            }
        }

        //UpdateAppearance of  the ConnectionPorts
        private void UpdateAppearance(ConnectionPort cp, SolidColorBrush solidColorBrush, bool fill)
        {
            if (fill)
            {
                if (cp.PortStyle.Fill != null)
                {
                    cp.PortStyle.Fill = null;
                    //Ports can be customized using PortStyle property 
                    cp.PortStyle.Fill = solidColorBrush;
                }
            }
            else
            {
                cp.PortStyle.Stroke = solidColorBrush;
            }
        }

        //Change the Portvisiblity
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox box = (sender as ComboBox);
            if (box.Name == "DVisibility")
            {
                switch (box.SelectedIndex)
                {
                    case 0:
                        diagramView.PortVisibility = Syncfusion.Windows.Diagram.PortVisibility.MouseOverNode;
                            //System.Windows.Visibility.Collapsed;
                        break;
                    case 1:
                        diagramView.PortVisibility = Syncfusion.Windows.Diagram.PortVisibility.AlwaysHidden;
                        break;
                    case 2:
                        diagramView.PortVisibility = Syncfusion.Windows.Diagram.PortVisibility.AlwaysVisible;
                        break;
                }

            }
            else
            {
                if (diagramView.SelectionList.Count > 0)
                {
                    foreach (object o in diagramView.SelectionList)
                    {
                        if (o is Node)
                        {
                            Node selectedNode = (o as Node);
                            switch (box.SelectedIndex)
                            {

                                case 0:
                                    selectedNode.PortVisibility = Syncfusion.Windows.Diagram.PortVisibility.MouseOverNode;
                                    break;
                                case 1:
                                    selectedNode.PortVisibility = Syncfusion.Windows.Diagram.PortVisibility.AlwaysHidden;
                                    break;
                                case 2:
                                    selectedNode.PortVisibility = Syncfusion.Windows.Diagram.PortVisibility.AlwaysVisible;
                                    break;
                            }
                        }
                    }
                }
            }
        }

        //checking for the Radiobutton selection
        private void head_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton rb = (sender as RadioButton);
            switch (rb.Name)
            {
                case "head":
                    head.IsChecked = true;
                    WidthValue.IsEnabled = true;
                    HeightValue.IsEnabled = true;
                    TopValue.IsEnabled = true;
                    LeftValue.IsEnabled = true;
                    top.IsEnabled = true;
                    left.IsEnabled = true;
                    width.IsEnabled = true;
                    height.IsEnabled = true;
                    fill.IsEnabled = true;
                    Fill.IsEnabled = true;
                    fill.Opacity = 1;
                    stroke.Opacity = 1;
                    stroke.IsEnabled = true;
                    Stroke.IsEnabled = true;
                    portshape.IsEnabled = true;
                    customshape.IsEnabled = true;
                    DefualtShape.IsEnabled = true;
                    if (diagramView.SelectionList.Count > 0)
                    {
                        foreach (object o in diagramView.SelectionList)
                        {

                            LineConnector selectedline = (o as LineConnector);
                            ConnectionPort selectedport = selectedline.ConnectionHeadPort as ConnectionPort;
                            UpdateLine(selectedport);

                        }
                    }
                    break;
                case "tail":
                    tail.IsChecked = true;
                    WidthValue.IsEnabled = true;
                    HeightValue.IsEnabled = true;
                    TopValue.IsEnabled = true;
                    LeftValue.IsEnabled = true;
                    top.IsEnabled = true;
                    left.IsEnabled = true;
                    width.IsEnabled = true;
                    height.IsEnabled = true;
                    fill.IsEnabled = true;
                    Fill.IsEnabled = true;
                    fill.Opacity = 1;
                    stroke.Opacity = 1;
                    stroke.IsEnabled = true;
                    Stroke.IsEnabled = true;
                    portshape.IsEnabled = true;
                    customshape.IsEnabled = true;
                    DefualtShape.IsEnabled = true;
                    if (diagramView.SelectionList.Count > 0)
                    {
                        foreach (object o in diagramView.SelectionList)
                        {

                            LineConnector selectedline = (o as LineConnector);
                            ConnectionPort selectedport = selectedline.ConnectionTailPort as ConnectionPort;
                            UpdateLine(selectedport);

                        }
                    }
                    break;



            }
        }

        //Update the Lineconnector with values
        private void UpdateLine(ConnectionPort selectedport)
        {
            TopValue.Text = selectedport.Top.ToString();
            LeftValue.Text = selectedport.Left.ToString();
            WidthValue.Text = selectedport.Width.ToString();
            HeightValue.Text = selectedport.Height.ToString();

            lineexpander.ToolTip = "";

            SolidColorBrush scb = selectedport.PortStyle.Fill as SolidColorBrush;
            fill.Color = scb.Color;
            SolidColorBrush scb1 = selectedport.PortStyle.Stroke as SolidColorBrush;
            stroke.Color = scb1.Color;
        }
        #endregion

    }
}
