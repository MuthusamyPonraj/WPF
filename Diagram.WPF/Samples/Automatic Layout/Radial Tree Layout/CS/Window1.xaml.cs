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

namespace RadialTreeLayout_2008
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        //Declaring the Public Variables
        bool toggle = true;

        #region Constructor

        //Window1 Constructor
        public Window1()
        {
            InitializeComponent();
          
            //Define Spacings
            diagramModel.HorizontalSpacing = 10;
            diagramModel.VerticalSpacing = 30;
            //Defines the nodes and adds to the model.
            Node head = addNode(toggle, 0);
            diagramModel.LayoutRoot = head;
           
            ConnectNode(head, Flower(5));
            diagramModel.LayoutVerticalAlignment = LayoutVerticalAlignment.Top;
        }
        #endregion

        #region Event Handlers

        //To change the Spcing properties
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
        private void hspace_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox tb = (sender as TextBox);
            RadialTreeLayout rtreelayout = new RadialTreeLayout(diagramModel, diagramView);
            if (diagramModel != null)
            {
                if (tb.Text != string.Empty)
                {
                    if (tb.Name == "hspace")
                    {
                        ///Provide the Space between the edges of the adjacent nodes (Siblings)
                        diagramModel.HorizontalSpacing = Convert.ToDouble((sender as TextBox).Text);
                        rtreelayout.RefreshLayout();
                    }

                    else if (tb.Name == "vspace")
                    {
                        ///Provide the spaces between the nodes that lie at the next levels of the tree layout.
                        diagramModel.VerticalSpacing = Convert.ToDouble((sender as TextBox).Text);
                        rtreelayout.RefreshLayout();
                    }

                }
            }

        }
        #endregion

        #region Helper Methods

        //Create a tree of nodes
        private List<Node> Flower(int p)
        {
            List<Node> nodes = new List<Node>();
            for (int i = 0; i < p; i++)
            {
                Node n = addNode(toggle, p);
                nodes.Add(n);
                toggle = !toggle;
                ConnectNode(n, Flower(p - 2));
                toggle = !toggle;
            }
            if (p <= 0)
            {
                nodes.Add(addNode(toggle, -1));
                nodes.Add(addNode(toggle, -1));
            }
            return nodes;
        }

        //Connect a node with a collection of nodes
        private void ConnectNode(Node head, List<Node> tail)
        {
            foreach (Node t in tail)
            {
                LineConnector lc = new LineConnector();
                lc.ConnectorType = ConnectorType.Straight;
                lc.HeadNode = head;
                lc.TailNode = t;
                diagramModel.Connections.Add(lc);

                //Applying style to the LineConnector
                lc.LineStyle.Stroke = Brushes.Black;
                lc.LineStyle.StrokeThickness = 1;

                //Applying Style to the DecoratorShape
                lc.TailDecoratorStyle.Stroke = Brushes.Black;
                lc.TailDecoratorStyle.Fill = Brushes.Black;
            }
        }

        //Create a Node
        private Node addNode(bool toggle, int lev)
        {
            Node n = new Node();
            n.Level = lev + 1;
            n.Shape = Shapes.Ellipse;
            n.Width = 30;
            n.Height = n.Width;
            diagramModel.Nodes.Add(n);
            return n;
        }

        #endregion
    }
}
