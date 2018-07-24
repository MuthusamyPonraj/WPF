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
using DiagramDemo;

namespace SwimLaneSampleDemo_2008
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        #region Constructor

        public Window1()
        {
            InitializeComponent();
            //Defines the nodes and adds them to the model.
            CreateNodes();
        }
        #endregion

        #region Helper Methods

        //Defines the nodes and adds them to the model.
        private void CreateNodes()
        {
            //Creating the Nodes
            TextBlock txtBlock;
            txtBlock = new TextBlock();
            txtBlock.Text = "Consultant";
            Node ConsultantLabel = addNode("ConsultantLabel", 40, 20, 100, 30, txtBlock, "", 0);

            Path path = App.Current.Resources["developer"] as Path;
            path.Stretch = Stretch.Fill;
            Node Consultant = addNode("Consultant", 60, 50, 50, 50, path, "Consultant", 0);

            Node SubReport = addNode("SubReport", 50, 125, 100, 50, "Submit Report", "Submit Report", 0);
            SubReport.Shape = Shapes.Rectangle;

            Node Lane1 = addNode("Lane1", 200, 0, 2, 700, "", "", 0);
            Lane1.Background = Brushes.DarkGreen;

            Node Lane2 = addNode("Lane2", 650, 0, 2, 700, "", "", 0);
            Lane2.Background = Brushes.DarkGreen;

            txtBlock = new TextBlock();
            txtBlock.Text = "Manager";
            Node ManagerLabel = addNode("ManagerLabel", 380, 20, 100, 30, txtBlock, "", 0);

            Path path1 = App.Current.Resources["manager"] as Path;
            path1.Stretch = Stretch.Fill;
            Node Manager = addNode("Manager", 400, 50, 50, 50, path1, "Manager", 0);

            Node Receive = addNode("Receive", 350, 125, 150, 50, "Receive Expense Report", "Receive Expense Report", 1);
            Receive.Shape = Shapes.FlowChart_Card;

            Node Review = addNode("Review", 350, 280, 150, 50, "Is Report Correct?", "Review Report", 2); ;
            Review.Shape = Shapes.FlowChart_Decision;

            Node Return = addNode("Return", 250, 440, 150, 50, "Return Report", "Return Report", 4);
            Return.Shape = Shapes.Rectangle;

            Node Forward = addNode("Forward", 480, 440, 150, 50, "Forward Report", "Forward Report", 1);
            Forward.Shape = Shapes.Rectangle;

            txtBlock = new TextBlock();
            txtBlock.Text = "Data Entry Clerk";
            Node ClerkLabel = addNode("ClerkLabel", 740, 20, 150, 30, txtBlock, "", 0);

            Path path2 = App.Current.Resources["clerk"] as Path;
            path2.Stretch = Stretch.Fill;
            Node Clerk = addNode("Clerk", 800, 50, 50, 50, path2, "Clerk", 0);

            Node Enter = addNode("Enter", 760, 440, 150, 50, "Enter Data into System", "Enter Data into System", 3);
            Enter.Shape = Shapes.Rectangle;

            Image image = new Image();
            image.Source = this.Resources["MyComputerIcon"] as DrawingImage;
            Node Comp = addNode("Comp", 800, 530, 75, 75, image, "Enter Data into System", 3);

            //Createing the Connection
            Connect(Receive, SubReport, ConnectorType.Orthogonal, "");
            Connect(Review, Receive, ConnectorType.Straight, "");
            Connect(Return, Review, ConnectorType.Bezier, "No");
            Connect(Forward, Review, ConnectorType.Bezier, "Yes");
            Connect(Enter, Forward, ConnectorType.Bezier, "");
            Connect(Comp, Enter, ConnectorType.Straight, "");
        }
        #endregion

        #region Functions Setting Properties

        //Add the Node to DiagramModel
        private Node addNode(String name, double offsetx, double offsety, double width, double height, Object content, String tooltip, Int32 level)
        {
            Node node = new Node(Guid.NewGuid(), name);
            node.OffsetX = offsetx;
            node.OffsetY = offsety;
            node.Width = width;
            node.Height = height;
            node.Content = content;
            node.ToolTip = tooltip;
            node.Level = level;

            //Adding the Node to the Model
            diagramModel.Nodes.Add(node);
            return node;
        }

        //Add Connection to DiagramModel
        private void Connect(Node tailnode, Node headnode, ConnectorType conntype, String label)
        {
            LineConnector conn = new LineConnector();
            conn.TailNode = tailnode;
            conn.HeadNode = headnode;
            conn.Label = label;
            conn.LabelWidth = 30;

            //Applying style to the DecoratorShape of the LineConnector
            conn.TailDecoratorShape = DecoratorShape.Arrow;
            conn.HeadDecoratorShape = DecoratorShape.None;
            diagramModel.Connections.Add(conn);
        }
        #endregion

    }
}
