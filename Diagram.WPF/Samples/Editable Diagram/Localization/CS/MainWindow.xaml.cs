using System;
using System.Collections.Generic;
using System.Globalization;
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
using System.Reflection;
using System.Resources;

namespace LocalizationDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Declaring the Public variables
        System.Resources.ResourceManager manager;

        #region Constructor

        public MainWindow()
        {


            //System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US"); //English

            //For other supported culture uncomment the respective lines
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("fr");//french
            //System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("nl"); //Dutch
            //System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("ja"); //Japanese
            //System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("zh"); //Chinese

            InitializeComponent();
            //Initialize ResourceManager
            Assembly assembly = Application.Current.GetType().Assembly;
            manager = new System.Resources.ResourceManager("LocalizationDemo.Resources.Syncfusion.Diagram.Wpf", assembly);
            //Call to create the Nodes
            createNodes();
        }



        #endregion

        #region Helper Methods


        //Defines the nodes and adds them to the model.
        public void createNodes()
        {
            Node NewIdea = addNode("NewIdea", 150, 60, 300, 30, Shapes.FlowChart_Start, "NewIdea", "#71AF17");
            Node Meeting = addNode("Meeting", 150, 60, 300, 145, Shapes.Rectangle, "Meeting", "#71AF17");
            Node BoardDecision = addNode("BoardDecision", 160, 100, 295, 265, Shapes.FlowChart_Decision, "BoardDecision", "#71AF17");
            Node project = addNode("project", 160, 100, 295, 420, Shapes.FlowChart_Decision, "project", "#71AF17");
            Node End = addNode("End", 120, 60, 315, 575, Shapes.FlowChart_Predefined, "End", "#71AF17");
            Node Decision = addNode("Decision", 200, 60, 550, 50, Shapes.FlowChart_Card, "Decision", "#822B86");
            Node Reject = addNode("Reject", 150, 60, 550, 285, Shapes.FlowChart_Predefined, "Reject", "#71AF17");
            Node Resources = addNode("Resources", 150, 60, 550, 440, Shapes.Rectangle, "Resources", "#71AF17");

            //Creates the connections for the nodes
            Connect(Meeting, NewIdea, "");
            Connect(BoardDecision, Meeting, "");
            Connect(Reject, BoardDecision, "No");
            Connect(project, BoardDecision, "Yes");
            Connect(Resources, project, "No");
            Connect(End, project, "Yes");
        }



        //Create the  Nodes and add into the DiagramModel
        private Node addNode(String name, double width, double height, double offsetx, double offsety, Shapes shape, String content, string fill)
        {
            Node node = new Node();
            node.Width = width;
            node.Height = height;
            node.OffsetX = offsetx;
            node.OffsetY = offsety;
            node.Shape = shape;
            node.Label = manager.GetString(content);

            node.LabelForeground = new SolidColorBrush(Colors.White);
            node.LabelTextWrapping = TextWrapping.Wrap;
            node.LabelWidth = 98;
            node.LabelTextAlignment = TextAlignment.Center;
            node.LabelVerticalTextAlignment = VerticalAlignment.Center;
            node.LabelHorizontalTextAlignment = HorizontalAlignment.Center;

            node.CustomPathStyle = Getstyle(fill);
            //Add the node into DiagramModel
            diagramModel.Nodes.Add(node);
            return node;
        }

        private System.Windows.Style Getstyle(string fill)
        {
            Style s = new Style(typeof (Path));
            s.Setters.Add(new Setter(Path.FillProperty,new SolidColorBrush((Color)ColorConverter.ConvertFromString(fill))));
            s.Setters.Add(new Setter(Path.StretchProperty, Stretch.Fill));
            return s;
        }

        //Create the LineConnector and add  into  DiagramModel
        private void Connect(Node headnode, Node tailnode, string label)
        {
            LineConnector conn = new LineConnector();
            conn.HeadNode = tailnode;
            conn.TailNode = headnode;
            conn.ConnectorType = ConnectorType.Orthogonal;

            if (label == "Yes")
            {

                conn.Label = manager.GetString(label);
                conn.LabelVerticalTextAlignment = VerticalAlignment.Center;
                conn.LabelHorizontalTextAlignment = HorizontalAlignment.Right;
                conn.LabelOrientation = LabelOrientation.Horizontal;
            }
            else if (label == "No")
            {
                conn.Label = manager.GetString(label);
                conn.LabelVerticalTextAlignment = VerticalAlignment.Center;
                conn.LabelHorizontalTextAlignment = HorizontalAlignment.Center;
            }

            diagramModel.Connections.Add(conn);
        }
        #endregion
    }

    #region ClassforContent

    class NodeContent
    {

        public string Description { get; set; }
    }
    #endregion

}
