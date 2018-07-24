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

namespace LayoutBoundsDemo_2010
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //Tree spacing properties.
            diagramModel.VerticalSpacing = 70;
            diagramModel.HorizontalSpacing = 30;
            diagramModel.SpaceBetweenSubTrees = 30;
            //Defines the nodes and adds to the model.
            createNodes();
            diagramModel.LayoutHorizontalAlignment = LayoutHorizontalAlignment.Center;
            diagramModel.LayoutVerticalAlignment = LayoutVerticalAlignment.Center;
           // diagramView.LayoutBounds = new Rect(0,0, 800, 700);
            diagramView.IsPageEditable = true;
        }

        #region Helper Methods

        //Defines the nodes 
        public void createNodes()
        {
            //Defining nodes.
            Node n1 = addNode("n1", 0);
            Node n2 = addNode("n2", 0);
            Node n3 = addNode("n3", 0);
            Node n4 = addNode("n4", 1);
            Node n5 = addNode("n5", 2);
            Node n6 = addNode("n6", 1);
            Node n7 = addNode("n7", 1);
            Node n8 = addNode("n8", 3);
            Node n9 = addNode("n9", 3);
            Node n10 = addNode("n10", 2);
            Node n11 = addNode("n11", 2);
            Node n12 = addNode("n12", 2);
            Node n13 = addNode("n13", 3);
            Node n14 = addNode("n14", 3);

            //Creating conections between nodes
            Connect(n1, n4);
            Connect(n6, n11);
            Connect(n2, n6);
            Connect(n6, n10);
            Connect(n3, n7);
            Connect(n5, n8);
            Connect(n5, n9);
            Connect(n4, n5);
            Connect(n7, n10);
            Connect(n4, n11);
            Connect(n7, n12);
            Connect(n12, n13);
            Connect(n12, n14);
        }

        //Add the Node to DiagramModel
        private Node addNode(String name, Int32 level)
        {
            Node node = new Node(Guid.NewGuid(), name);
            node.Level = level;
            diagramModel.Nodes.Add(node);
            return node;
        }

        //Creating connection and adding to the model
        void Connect(Node HeadNode, Node TailNode)
        {
            LineConnector connection = new LineConnector();
            connection.ConnectorType = ConnectorType.Straight;
            // Specify the TailNode node
            connection.TailNode = TailNode;
            //Specifying the Head Node
            connection.HeadNode = HeadNode;
            connection.TailDecoratorShape = DecoratorShape.Circle;
            //Adding to the Diagram Model
            diagramModel.Connections.Add(connection);
        }
        #endregion

        #region Event Handlers

        //Orientation changed
        ///<summary>
        ///TreeOrientation
        ///Description:
        ///The Layout Manager lets you orient the tree in many directions and create sophisticated arrangements. 
        ///The Orientation property of the Diagram model can be used to specify the tree orientation.
        /// </summary>
        //Top to Bottom Orientation
        private void ComboBoxItem_Selected_16(object sender, RoutedEventArgs e)
        {
            diagramView.LayoutBounds = new Rect(0, 0, 800, 700);
            refreshLayout(TreeOrientation.TopBottom);
        }

        // Bottom to Top Orientation
        private void ComboBoxItem_Selected17(object sender, RoutedEventArgs e)
        {
            diagramView.LayoutBounds = new Rect(0, 0, 900, 750);
            refreshLayout(TreeOrientation.BottomTop);
        }

        //Left to Right Orientation
        private void ComboBoxItem_Selected_18(object sender, RoutedEventArgs e)
        {
            diagramView.LayoutBounds = new Rect(0, 0, 600, 650);
            refreshLayout(TreeOrientation.LeftRight);
        }

        //Right to Left Orientation
        private void ComboBoxItem_Selected_19(object sender, RoutedEventArgs e)
        {
            diagramView.LayoutBounds = new Rect(0, 0, 1000, 650);
            refreshLayout(TreeOrientation.RightLeft);
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
        private void Hspace_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (this.IsLoaded)
            {
                TextBox box = (sender as TextBox);
                HierarchicalTreeLayout htreelayout = new HierarchicalTreeLayout(diagramModel, diagramView);
                if (diagramModel != null)
                {
                    if (box.Text != string.Empty)
                    {
                        try
                        {
                            switch (box.Name)
                            {
                                case "Hspace":
                                    diagramModel.HorizontalSpacing = double.Parse(box.Text);
                                    htreelayout.RefreshLayout();
                                    break;
                                case "Vspace":
                                    diagramModel.VerticalSpacing = double.Parse(box.Text);
                                    htreelayout.RefreshLayout();
                                    break;
                                case "Sspace":
                                    diagramModel.SpaceBetweenSubTrees = double.Parse(box.Text);
                                    htreelayout.RefreshLayout();
                                    break;
                                case "LeftBounds":
                                    diagramView.LayoutBounds = new Rect(double.Parse(box.Text), diagramView.LayoutBounds.Y, diagramView.LayoutBounds.Width, diagramView.LayoutBounds.Height);
                                    htreelayout.RefreshLayout();
                                    break;
                                case "TopBounds":
                                    diagramView.LayoutBounds = new Rect(diagramView.LayoutBounds.X, double.Parse(box.Text), diagramView.LayoutBounds.Width, diagramView.LayoutBounds.Height);
                                    htreelayout.RefreshLayout();
                                    break;
                                case "WidthBounds":
                                    diagramView.LayoutBounds = new Rect(diagramView.LayoutBounds.X, diagramView.LayoutBounds.Y, double.Parse(box.Text), diagramView.LayoutBounds.Height);
                                    htreelayout.RefreshLayout();
                                    break;
                                case "HeightBounds":
                                    diagramView.LayoutBounds = new Rect(diagramView.LayoutBounds.X, diagramView.LayoutBounds.Y, diagramView.LayoutBounds.Width, double.Parse(box.Text));
                                    htreelayout.RefreshLayout();
                                    break;
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Invalid Input. Enter digits (0-9) only", "Invalid input", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
            }

        }
        #endregion

        #region PrivateFunctions

        //Refresh Layout
        /// <summary>
        /// RefreshLayout
        /// Description:
        /// When there are changes in content of the page like  new nodes or connectors added, 
        /// the layout has to be refreshed to get the page’s content aligned again to give space for new contents
        /// </summary>
        /// ReturnType:Void
        /// <param name="Null"></param>
        /// <param name="e"></param>

        //Refreshing the Layout
        private void refreshLayout(TreeOrientation treeorientation)
        {
            HierarchicalTreeLayout tree = new HierarchicalTreeLayout(diagramModel, diagramView);
            diagramModel.Orientation = treeorientation;
            tree.RefreshLayout();
            (diagramView.Page as DiagramPage).InvalidateMeasure();
            (diagramView.Page as DiagramPage).InvalidateArrange();
        }
        #endregion

        private void HorizontalLayout_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((sender as ComboBox).SelectedIndex == 0)
            {
                diagramModel.LayoutHorizontalAlignment = LayoutHorizontalAlignment.Center;
            }
            else if ((sender as ComboBox).SelectedIndex == 1)
            {
                diagramModel.LayoutHorizontalAlignment = LayoutHorizontalAlignment.Left;
            }
            else
            {
                diagramModel.LayoutHorizontalAlignment = LayoutHorizontalAlignment.Right;
            }
            HierarchicalTreeLayout tree = new HierarchicalTreeLayout(diagramModel, diagramView);
            tree.RefreshLayout();
            (diagramView.Page as DiagramPage).InvalidateMeasure();
            (diagramView.Page as DiagramPage).InvalidateArrange();
        }
        private void VerticalLayout_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((sender as ComboBox).SelectedIndex == 0)
            {
                diagramModel.LayoutVerticalAlignment = LayoutVerticalAlignment.Center;
            }
            else if ((sender as ComboBox).SelectedIndex == 1)
            {
                diagramModel.LayoutVerticalAlignment = LayoutVerticalAlignment.Top;
            }
            else
            {
                diagramModel.LayoutVerticalAlignment = LayoutVerticalAlignment.Bottom;
            }
            HierarchicalTreeLayout tree = new HierarchicalTreeLayout(diagramModel, diagramView);
            tree.RefreshLayout();
            (diagramView.Page as DiagramPage).InvalidateMeasure();
            (diagramView.Page as DiagramPage).InvalidateArrange();
        }
    }
}
