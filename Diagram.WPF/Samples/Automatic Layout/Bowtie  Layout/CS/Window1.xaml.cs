#region Copyright Syncfusion Inc. 2001 - 2011
// Copyright Syncfusion Inc. 2001 - 2011. All rights reserved.
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
using Syncfusion.Windows.Shared;
using Syncfusion.Windows.Diagram;

namespace BowTieLayout_2010
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    /// 
    public partial class Window1 : Window
    {
        #region Constructor
        //Window1 Constructor
        public Window1()
        {
            InitializeComponent();

            //Tree spacing properties.
            diagramModel.VerticalSpacing = 60;
            diagramModel.HorizontalSpacing = 15;
            diagramModel.SpaceBetweenSubTrees = 50;
            diagramModel.Orientation = TreeOrientation.LeftRight;
            //Defines the nodes and adds to the model.
            Node Root = AddNode("Feelings","#ED0006", Brushes.Black, Shapes.Rectangle,70,25,10);
            this.diagramModel.LayoutRoot = Root;
            diagramModel.LayoutType = LayoutType.BowtieLayout;

            //creating the Left Side Tree
            createLeftNodes(Root, BowtieSubTreePlacement.Left);

            //creating the Right Side Tree
            createRightNodes(Root, BowtieSubTreePlacement.Right);

            //setting the Root Node
            this.diagramModel.LayoutRoot = Root;
        }

        #endregion

        #region Helper Methods

        //Defines the nodes 
        public void createLeftNodes(Node Root, BowtieSubTreePlacement place)
        {

            double width = 70;
            double height = 25;
            int fontSize = 10;

            //Defining nodes.
            Node n0 = AddNode("Good Feelings", "#ED0006", Brushes.Black,Shapes.Rectangle, 80, height, fontSize);

            Node n02 = AddNode("Positive", "#E02B5F", Brushes.Black,Shapes.Rectangle, width, height, fontSize);
            Node n03 = AddNode("Thankful", "#E02B5F", Brushes.Black, Shapes.Rectangle, width, height, fontSize);
            Node n04 = AddNode("Happy", "#E02B5F", Brushes.Black,Shapes.Rectangle, width, height, fontSize);
            Node n05 = AddNode("Comfortable", "#E02B5F", Brushes.Black, Shapes.Rectangle, width, height, fontSize);

            //Level two nodes
            Node n021 = AddNode("Enthusiastic", "#25A0DA", Brushes.Black,Shapes.Rectangle, width, height, fontSize);
            Node n022 = AddNode("Excited", "#25A0DA", Brushes.Black, Shapes.Rectangle, width, height, fontSize);

            Node n031 = AddNode("Grateful", "#25A0DA", Brushes.Black,Shapes.Rectangle, width, height, fontSize);
            Node n032 = AddNode("Lucky", "#25A0DA", Brushes.Black,Shapes.Rectangle, width, height, fontSize);

            Node n041 = AddNode("Cheerful", "#25A0DA", Brushes.Black,Shapes.Rectangle, width, height, fontSize);
            Node n042 = AddNode("Wonderful", "#25A0DA", Brushes.Black,Shapes.Rectangle, width, height, fontSize);
            Node n043 = AddNode("Joyful", "#25A0DA", Brushes.Black, Shapes.Rectangle, width, height, fontSize);
            Node n044 = AddNode("Great", "#25A0DA", Brushes.Black, Shapes.Rectangle, width, height, fontSize);

            Node n051 = AddNode("Relaxed", "#25A0DA", Brushes.Black,Shapes.Rectangle, width, height, fontSize);
            Node n052 = AddNode("Peaceful", "#25A0DA", Brushes.Black, Shapes.Rectangle, width, height, fontSize);
            Node n053 = AddNode("Calm", "#25A0DA", Brushes.Black, Shapes.Rectangle, width, height, fontSize);

            DiagramControl.SetBowtieSubTreePlacement(n0, place);

            //Creating conections between nodes
            Connect(Root, n0);

            Connect(n0, n02);
            Connect(n0, n03);
            Connect(n0, n04);
            Connect(n0, n05);

            Connect(n02, n021);
            Connect(n02, n022);

            Connect(n03, n031);
            Connect(n03, n032);

            Connect(n04, n041);
            Connect(n04, n042);
            Connect(n04, n043);
            Connect(n04, n044);

            Connect(n05, n051);
            Connect(n05, n052);
            Connect(n05, n053);
        }

        //Defines the nodes 
        public void createRightNodes(Node Root, BowtieSubTreePlacement place)
        {
            double width = 70;
            double height = 25;
            int fontSize = 10;

            Node n0 = AddNode("Bad Feelings", "#ED0006", Brushes.Black,Shapes.Rectangle, 80, height, fontSize);

            Node n01 = AddNode("Angry", "#E02B5F", Brushes.Black, Shapes.Rectangle, width, height, fontSize);
            Node n02 = AddNode("Alone", "#E02B5F", Brushes.Black,Shapes.Rectangle, width, height, fontSize);
            Node n03 = AddNode("Sad", "#E02B5F", Brushes.Black, Shapes.Rectangle, width, height, fontSize);
            Node n04 = AddNode( "Confused", "#E02B5F", Brushes.Black, Shapes.Rectangle, width, height, fontSize);

            Node n011 = AddNode("Annoyed", "#25A0DA", Brushes.Black,Shapes.Rectangle, width, height, fontSize);
            Node n012 = AddNode("Furious", "#25A0DA", Brushes.Black,Shapes.Rectangle, width, height, fontSize);

            Node n021 = AddNode("Lonely", "#25A0DA", Brushes.Black,Shapes.Rectangle, width, height, fontSize);
            Node n022 = AddNode("Lost", "#25A0DA", Brushes.Black,Shapes.Rectangle, width, height, fontSize);

            Node n031 = AddNode("Upset", "#25A0DA", Brushes.Black,Shapes.Rectangle, width, height, fontSize);
            Node n032 = AddNode("Disappointed", "#25A0DA", Brushes.Black,Shapes.Rectangle, width, height, fontSize);

            Node n041 = AddNode("Tensed", "#25A0DA", Brushes.Black, Shapes.Rectangle, width, height, fontSize);
            Node n042 = AddNode("Embarrassed", "#25A0DA", Brushes.Black, Shapes.Rectangle, width, height, fontSize);
            Node n043 = AddNode("Ashamed", "#25A0DA", Brushes.Black, Shapes.Rectangle, width, height, fontSize);
            Node n044 = AddNode("Frustrated", "#25A0DA", Brushes.Black,Shapes.Rectangle, width, height, fontSize);
            Node n045 = AddNode("Guilty", "#25A0DA", Brushes.Black,Shapes.Rectangle, width, height, fontSize);

            DiagramControl.SetBowtieSubTreePlacement(n0, place);

            //Creating conections between nodes
            Connect(Root, n0);

            Connect(n0, n01);
            Connect(n0, n04);
            Connect(n0, n02);
            
            Connect(n0, n03);
            
            Connect(n01, n011);
            Connect(n01, n012);

            Connect(n02, n021);
            Connect(n02, n022);

            Connect(n03, n031);
            Connect(n03, n032);

            Connect(n04, n041);
            Connect(n04, n042);
            Connect(n04, n043);
            Connect(n04, n044);
            Connect(n04, n045);

        }
        
        //Add the Node to DiagramModel
        Node AddNode(string label, string pathfill, Brush pathstroke, Shapes nodeshape, double width, double height, int fontSize)
        {
            Node n = new Node(Guid.NewGuid());
            n.Width = width;
            n.Height = height;
            n.Shape = nodeshape;
            n.FontSize = fontSize;
            var bc = new BrushConverter();
            Style style = new Style();
            Setter s = new Setter(System.Windows.Shapes.Path.FillProperty, (Brush)bc.ConvertFrom(pathfill));
            Setter s1 = new Setter(System.Windows.Shapes.Path.StretchProperty, Stretch.Fill);
            style.Setters.Add(s);
            style.Setters.Add(s1);
            n.CustomPathStyle = style;        
            n.Label = label;
            n.LabelHorizontalAlignment = System.Windows.HorizontalAlignment.Center;
            n.LabelVerticalAlignment = System.Windows.VerticalAlignment.Center;
            n.LabelFontFamily = new FontFamily("Lucida");
            n.LabelTextWrapping = TextWrapping.Wrap;
            //if (label.Equals("Feelings") || label.Equals("Good Feelings") || label.Equals("Bad Feelings"))
            {
                n.LabelForeground = new SolidColorBrush(Colors.White);
            }

            diagramModel.Nodes.Add(n);
            return n;
        }

        //Creating connection and adding to the model
        void Connect(Node HeadNode, Node TailNode)
        {
            LineConnector connection = new LineConnector();
            connection.ConnectorType = ConnectorType.Orthogonal;

            //LineStyle
            connection.LineStyle.StrokeThickness = 1;
            connection.TailDecoratorShape=DecoratorShape.None;

            // Specify the TailNode node
            connection.TailNode = TailNode;

            //Specifying the Head Node
            connection.HeadNode = HeadNode;

            //Adding to the Diagram Model
            diagramModel.Connections.Add(connection);
        }
        #endregion  
    }
}
