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
using System.Collections.ObjectModel;
using Syncfusion.Windows.Shared;


namespace OrganizationalChartDemo
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

            //Tree spacing properties
            diagramModel.VerticalSpacing = 100;
            diagramModel.HorizontalSpacing = 30;
            diagramModel.SpaceBetweenSubTrees = 50;
            diagramModel.LayoutHorizontalAlignment = LayoutHorizontalAlignment.Left;
            diagramModel.LayoutVerticalAlignment = LayoutVerticalAlignment.Top;
            //Defines the nodes and adds to the model.
            createNodes();
        }
        #endregion

        #region Helper Methods

        //Defines the nodes 
        public void createNodes()
        {
            Node CEO = addNode("CEO", new Uri("/Images/image1.png", UriKind.RelativeOrAbsolute), "CEO of the company", "Steve-CEO");
            Node SLS = addNode("SLS", new Uri("/Images/image2.png", UriKind.RelativeOrAbsolute), "Sales Manager of the company", "Tom-ManagerSLS");
            Node Marketing = addNode("Marketing", new Uri("/Images/image12.PNG", UriKind.RelativeOrAbsolute), "Marketing Manager of the company", "Mary-MKT Manager");
            Node PM = addNode("PM", new Uri("/Images/image11.PNG", UriKind.RelativeOrAbsolute), "Personnel Manager of the company", "Kenny-PM");
            Node DEV = addNode("DEV", new Uri("/Images/image4.png", UriKind.RelativeOrAbsolute), "Development Manager of the company", "Jim-Manager DEV");
            Node CSR1 = addNode("CSR1", new Uri("/Images/image10.PNG", UriKind.RelativeOrAbsolute), "CSR  of the company", "Kevin-CSR");
            Node CSR2 = addNode("CSR2", new Uri("/Images/image7.png", UriKind.RelativeOrAbsolute), "CSR  of the company", "Peter-CSR");
            Node Engineer1 = addNode("Engineer1", new Uri("/Images/image13.PNG", UriKind.RelativeOrAbsolute), "Engineer  of the company", "Rob-Engineer");
            Node Engineer2 = addNode("Engineer2", new Uri("/Images/image3.png", UriKind.RelativeOrAbsolute), "Engineer  of the company", "Clayton-Engineer");
            Node CSR1Junior1 = addNode("CSR1Junior1", new Uri("/Images/image6.png", UriKind.RelativeOrAbsolute), "CSR1Junior1  of the company", "Junior CSR");
            Node CSR1Junior3 = addNode("CSR1Junior3", new Uri("/Images/image5.png", UriKind.RelativeOrAbsolute), "CSR1Junior2  of the company", "Junior CSR");
            Node EngineerJunior1 = addNode("EngineerJunior1", new Uri("/Images/image9.PNG", UriKind.RelativeOrAbsolute), "EngineerJunior1 of the company", "Junior Engineer");
            Node EngineerJunior3 = addNode("EngineerJunior3", new Uri("/Images/image8.png", UriKind.RelativeOrAbsolute), "EngineerJunior3 of the company", "Junior Engineer");

            //The layout happens with respect to the layout root.
            diagramModel.LayoutRoot = CEO;

            //Creating the Connections between the nodes.
            Connect(CEO, Marketing);
            Connect(CEO, SLS);
            Connect(CEO, DEV);
            Connect(Marketing, PM);
            Connect(SLS, CSR1);
            Connect(SLS, CSR2);
            Connect(DEV, Engineer1);
            Connect(DEV, Engineer2);
            Connect(CSR2, CSR1Junior1);
            Connect(CSR2, CSR1Junior3);
            Connect(Engineer1, EngineerJunior1);
            Connect(Engineer1, EngineerJunior3);
        }

        //Creating connection and adding to the model
        void Connect(Node HeadNode, Node TailNode)
        {
            LineConnector connection = new LineConnector();
            connection.ConnectorType = ConnectorType.Orthogonal;
            // Specify the TailNode node
            connection.TailNode = TailNode;
            //Specifying the Head Node
            connection.HeadNode = HeadNode;
            connection.TailDecoratorShape = DecoratorShape.Arrow;
            //Adding to the Diagram Model
            diagramModel.Connections.Add(connection);
        }
        #endregion

        #region Event Handlers

        ///<summary>
        ///TreeOrientation
        ///Description:
        ///The Layout Manager lets you orient the tree in many directions and create sophisticated arrangements. 
        ///The Orientation property of the Diagram model can be used to specify the tree orientation.
        /// </summary>
        //Top to Bottom Orientation
        private void ComboBoxItem_Selected_16(object sender, RoutedEventArgs e)
        {
            diagramView.Bounds = new Thickness(0, 0, 1000, 200);
            refershLayout(TreeOrientation.TopBottom);
        }
        // Bottom to Top Orientation
        private void ComboBoxItem_Selected17(object sender, RoutedEventArgs e)
        {
            diagramView.Bounds = new Thickness(0, 0, 900, 1200);
            refershLayout(TreeOrientation.BottomTop);
        }

        //Left to Right Orientation
        private void ComboBoxItem_Selected_18(object sender, RoutedEventArgs e)
        {
            diagramView.Bounds = new Thickness(0, 0, 250, 650);
            refershLayout(TreeOrientation.LeftRight);
        }

        //Right to Left Orientation
        private void ComboBoxItem_Selected_19(object sender, RoutedEventArgs e)
        {
            diagramView.Bounds = new Thickness(0, 0, 1500, 650);
            refershLayout(TreeOrientation.RightLeft);
        }

        //To change the Spacing properties
        /// <summary>
        /// HorizontalSpacing ,VerticalSpacing and SpaceBetweenSubTrees
        /// Description:
        /// Provide the spaces between the edges of the adjacent nodes (Siblings)[HorizontalSpacing].
        /// Provide  spaces between the nodes that lie at the next levels of the layout[VerticalSpacing].
        /// Provide the sthe spaces between adjacent Subtrees[SpaceBetweenSubTrees].
        /// Property of DiagramModel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox box = (sender as TextBox);
            DirectedTreeLayout dtlayout = new DirectedTreeLayout(diagramModel, diagramView);
            if (diagramModel != null)
            {
                if (box.Text != string.Empty)
                {
                    switch (box.Name)
                    {
                        case "Hspace":
                            diagramModel.HorizontalSpacing = double.Parse(box.Text);
                            dtlayout.RefreshLayout();
                            break;
                        case "Vspace":
                            diagramModel.VerticalSpacing = double.Parse(box.Text);
                            dtlayout.RefreshLayout();
                            break;
                        case "Sspace":
                            diagramModel.SpaceBetweenSubTrees = double.Parse(box.Text);
                            dtlayout.RefreshLayout();
                            break;
                    }
                }
            }

        }
        #endregion

        #region PrivateFunctions

        //Add node to DiagramModel
        private Node addNode(String name, Uri uri, String tooltip, String nodelbl)
        {
            Node node = new Node(Guid.NewGuid(), name);
            NodeContent cont = new NodeContent();
            cont.NodeImage = uri;
            cont.NodeLabel = nodelbl;
            cont.NodeToolTip = tooltip;
            node.Content = cont;
            diagramModel.Nodes.Add(node);
            return node;
        }

        //Refreshing the Layout
        private void refershLayout(TreeOrientation treeorientation)
        {
            DirectedTreeLayout tree = new DirectedTreeLayout(diagramModel, diagramView);
            diagramModel.Orientation = treeorientation;
            tree.RefreshLayout();
            (diagramView.Page as DiagramPage).InvalidateMeasure();
            (diagramView.Page as DiagramPage).InvalidateArrange();
        }
        #endregion
    }

    //Class for content
    public class NodeContent
    {
        public Uri NodeImage { get; set; }
        public String NodeLabel { get; set; }
        public String NodeToolTip { get; set; }
    }

}
