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
using System.Windows.Threading;
//using Syncfusion.Windows.Shared;


namespace ExpandCollapseDemo_2008
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        #region Public Variables

        //Declaring public variables
        ContextMenu nodeContextMenu;
        Node selectedNode;
        Node InitialNode1;
        Node InitialNode2;
        bool Ismousedown;
        int ParentNo = 0; 
        #endregion

        #region Constructor

        //Window1 Constructor
        public Window1()
        {
            InitializeComponent();
            diagramControl.IsSymbolPaletteEnabled = true;
            //Tree spacing properties
            diagramModel.VerticalSpacing = 60;
            diagramModel.HorizontalSpacing = 0;
            diagramModel.SpaceBetweenSubTrees = 0;
            diagramControl.SymbolPalette.SymbolGroups.Clear();
            diagramControl.SymbolPalette.SymbolFilters.Clear();
            diagramModel.Nodes.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(Nodes_CollectionChanged);

            //Defines the nodes and adds to the model.
            CreateNodes();
            CreateSymbolPaletteGroup();
            diagramView.NodeDrop += new NodeDroppedEventHandler(diagramView_NodeDrop);
        }

        /// CreateSymbolPaletteGroup
        private void CreateSymbolPaletteGroup()
        {
            SymbolPaletteFilter sf = new SymbolPaletteFilter();
            sf.Label = "Symbols";
            //symbolpalette group
            SymbolPaletteGroup g = new SymbolPaletteGroup();
            g.Label = "Custom Symbols";
            diagramControl.SymbolPalette.SymbolFilters.Add(sf);
            SymbolPalette.SetFilterIndexes(g, new Int32Collection(new int[] { 0, 6 }));
            diagramControl.SymbolPalette.SymbolGroups.Add(g);

            CreateSymbolPaletteItem(g, "Man");
            CreateSymbolPaletteItem(g, "Employee");
            CreateSymbolPaletteItem(g, "Lady");

        }

        ///Add image to Symbolpalette item
        private void CreateSymbolPaletteItem(SymbolPaletteGroup g, string name)
        {
            SymbolPaletteItem item = new SymbolPaletteItem();
            item.Height = 60;
            item.Width = 60;
            DrawingImage di = App.Current.Resources[name] as DrawingImage;
            Image i = new Image();
            i.Source = di;
            item.Content = i;
            item.Name = name;
            g.Items.Add(item);
        }

        ///NodeCollection Event
        void Nodes_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                (e.NewItems[0] as Node).Loaded += new RoutedEventHandler(Nod_Loaded);
            }
        }

        ///Node Loaded Event
        void Nod_Loaded(object sender, RoutedEventArgs e)
        {
            if ((sender as Node) == InitialNode1 || (sender as Node) == InitialNode2)
            {
                InitialNode1.Name = "initial1";

            }
        }

        #endregion

        #region Applying Template to the Node

        //Nodedropp event fro Identifing the DroppedNode
        void diagramView_NodeDrop(object sender, NodeDroppedRoutedEventArgs evtArgs)
        {
            Node n1 = evtArgs.Source as Node;

            if (evtArgs.SymbolPaletteItemName == "Employee")
            {
                Node n2 = evtArgs.DroppedNode as Node;
                n2.Tag = "ceo";
                n2.Loaded += new RoutedEventHandler(node_Loaded);
            }

            if (evtArgs.SymbolPaletteItemName == "Man")
            {
                Node n3 = evtArgs.DroppedNode as Node;
                n3.Tag = "boy";
                n3.Loaded += new RoutedEventHandler(node_Loaded);
            }
            if (evtArgs.SymbolPaletteItemName == "Lady")
            {
                Node n4 = evtArgs.DroppedNode as Node;
                n4.Tag = "lady";
                n4.Loaded += new RoutedEventHandler(node_Loaded);
            }
        }

        //Loaded Event fro Checking that Node is Parent
        void node_Loaded(object sender, RoutedEventArgs e)
        {
            Node n1 = sender as Node;
            Node n2 = sender as Node;
            Node reff = Calc(n1, n1.OffsetX, n1.OffsetY, n1.Width, n1.Height);
            diagramModel.Nodes.Remove(n2);
            if (n1 != reff)
            {
                if (reff.Visibility != Visibility.Hidden)
                {
                    if ((this.FindNameFromContentTemplate(reff, "Expander") as Image).Name != "P")
                    {
                        NodeContent cnt = new NodeContent();
                        if (n1.Tag == "lady")
                        {
                            cnt.Person = App.Current.Resources["Lady"] as DrawingImage;
                            AddNodeasChild(cnt, n1, reff);
                        }
                        else if (n1.Tag == "boy")
                        {
                            cnt.Person = App.Current.Resources["Man"] as DrawingImage;
                            AddNodeasChild(cnt, n1, reff);
                        }
                        else if (n1.Tag == "ceo")
                        {
                            cnt.Person = App.Current.Resources["Employee"] as DrawingImage;
                            AddNodeasChild(cnt, n1, reff);
                        }
                    }
                }
            }
        }

        //Refreshing the Layout after adding the Node
        private void AddNodeasChild(NodeContent cnt, Node n1, Node head)
        {
            n1.Style = this.Resources["newtemp"] as Style;
            n1.Content = cnt;
            n1.Width = 75;
            n1.Height = 75;
            n1.HorizontalContentAlignment = HorizontalAlignment.Stretch;
            n1.VerticalContentAlignment = VerticalAlignment.Stretch;
            if (n1.ChildCount == 0)
            {
                cnt.Expander = null;
            }
            else
            {
                cnt.Expander = App.Current.Resources["Plus"] as DrawingImage;
            }
            if (head != null)
            {
                if (head.ChildCount == 0)
                {
                    if ((this.FindNameFromContentTemplate(head, "Expander") as Image) != null)
                    {
                        (this.FindNameFromContentTemplate(head, "Expander") as Image).Source = App.Current.Resources["Minus"] as DrawingImage;
                    }
                }
            }
            LineConnector lc = new LineConnector();
            lc.HeadNode = head;
            lc.TailNode = n1;
            lc.TailDecoratorShape = DecoratorShape.Arrow;

            if ((this.FindNameFromContentTemplate(head, "Expander") as Image).Name == "P")
            {
                n1.Visibility = Visibility.Hidden;
                lc.Visibility = Visibility.Hidden;
            }
            else
            {
                Show(n1);
            }

            diagramModel.Nodes.Add(n1);
            n1.AllowSelect = false;
            n1.IsSelected = false;
            n1.MouseRightButtonDown += new MouseButtonEventHandler(newNode_MouseRightButtonDown);
            diagramModel.Connections.Add(lc);
            HierarchicalTreeLayout layout = new HierarchicalTreeLayout(diagramModel, diagramView);
            layout.RefreshLayout();
        }

        #endregion

        #region Helper Methods

        //Defines the nodes 
        public void CreateNodes()
        {
            Node CEO = addNode("Employee", false, false);
            Node SLS = addNode("Boy", false, false);
            Node Marketing = addNode("Girl", false, true);
            Node PM = addNode("Lady", true, false);
            Node DEV = addNode("Employee", false, false);
            Node CSR1 = addNode("Man", true, false);
            Node CSR2 = addNode("Personx", false, false);
            Node Engineer1 = addNode("Personx", false, true);
            Node Engineer2 = addNode("Lady", true, false);
            Node CSR1Junior1 = addNode("Man", true, false);
            Node CSR1Junior3 = addNode("Employee", true, false);
            Node EngineerJunior1 = addNode("Girl", true, false);
            Node EngineerJunior3 = addNode("Boy", true, false);
            //The layout happens with respect to the layout root.
            diagramModel.LayoutRoot = CEO;
            //Creating the Connections between the nodes.
            Connect(CEO, Marketing, null);
            Connect(CEO, SLS, null);
            Connect(CEO, DEV, null);
            Connect(Marketing, PM, PM);
            Connect(SLS, CSR1, null);
            Connect(SLS, CSR2, null);
            Connect(DEV, Engineer1, null);
            Connect(DEV, Engineer2, null);
            Connect(CSR2, CSR1Junior1, null);
            Connect(CSR2, CSR1Junior3, null);
            Connect(Engineer1, EngineerJunior1, EngineerJunior1);
            Connect(Engineer1, EngineerJunior3, EngineerJunior3);
        }

        //Add a new Node and return it
        private Node addNode(string p, bool leaf, bool initial)
        {
            Node newNode = new Node();
            newNode.HorizontalContentAlignment = HorizontalAlignment.Stretch;
            newNode.VerticalContentAlignment = VerticalAlignment.Stretch;
            NodeContent cnt = new NodeContent();
            cnt.Person = App.Current.Resources[p] as DrawingImage;

            //Applying the Expander according to the Parent and Child
            if (!leaf)
            {
                cnt.Expander = App.Current.Resources["Minus"] as DrawingImage;
            }
            if (initial)
            {
                cnt.Expander = App.Current.Resources["Plus"] as DrawingImage;
            }
            newNode.Style = this.Resources["newtemp"] as Style;
            newNode.Content = cnt;
            diagramModel.Nodes.Add(newNode);
            newNode.AllowSelect = false;
            newNode.MouseRightButtonDown += new MouseButtonEventHandler(newNode_MouseRightButtonDown);
            return newNode;
        }

        //Menu For adding the Node
        void AddMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Node n = selectedNode;
            if (n != null)
            {
                Node n1 = addNode("Employee", true, false);
                Node n2 = addNode("Boy", true, false);
                Connect(n, n1, null);
                Connect(n, n2, null);
            }

            if ((this.FindNameFromContentTemplate(n, "Expander") as Image) != null)
            {
                (this.FindNameFromContentTemplate(n, "Expander") as Image).Source = App.Current.Resources["Minus"] as DrawingImage;
            }

            HierarchicalTreeLayout layout = new HierarchicalTreeLayout(diagramModel, diagramView);
            layout.RefreshLayout();
        }

        //Menu creation for adding the Node as children
        void newNode_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            selectedNode = sender as Node;
            Image expander = this.FindNameFromContentTemplate((sender as Node), "Expander") as Image;
            CreateContextMenu(selectedNode);
            if (expander != null && expander.Name == "P")
            {
                (nodeContextMenu.Items[0] as MenuItem).IsEnabled = false;
            }
            else
            {
                (nodeContextMenu.Items[0] as MenuItem).IsEnabled = true;
            }
        }

        //Creating connection and adding to the model
        void Connect(Node HeadNode, Node TailNode, Node hiddenNode)
        {
            LineConnector connection = new LineConnector();
            connection.ConnectorType = ConnectorType.Orthogonal;
            // Specify the TailNode node
            connection.TailNode = TailNode;
            //Specifying the Head Node
            connection.HeadNode = HeadNode;
            connection.TailDecoratorShape = DecoratorShape.Arrow;
            if (hiddenNode != null)
            {
                connection.Visibility = Visibility.Hidden;
                hiddenNode.Visibility = Visibility.Hidden;
            }
            //Adding to the Diagram Model
            diagramModel.Connections.Add(connection);
            // connection.IsEnabled = false;
        }

        //ContextMenu
        void CreateContextMenu(Node n)
        {
            nodeContextMenu = new ContextMenu();
            MenuItem addMenuItem = new MenuItem();
            addMenuItem.Header = "Add";
            addMenuItem.Click += new RoutedEventHandler(AddMenuItem_Click);
            nodeContextMenu.Items.Add(addMenuItem);
            n.ContextMenu = nodeContextMenu;
        }

        //Calculating the fucntion For adding the Node as children to the Specific Node
        private Node Calc(Node n1, double offx, double offy, double hei, double wid)
        {
            Node newnode1 = new Node();
            newnode1.OffsetX = offx;
            newnode1.OffsetY = offy;
            newnode1.Height = hei;
            newnode1.Width = wid;
            Node new1 = new Node();
            Rect org = new Rect(offx, offy, hei, wid);

            foreach (Node n in diagramModel.Nodes)
            {
                Rect old = new Rect(n.OffsetX, n.OffsetY, n.Height, n.Width);

                if (org.IntersectsWith(old))
                {
                    new1 = n as Node;
                    break;
                }
            }

            return new1;
        }


        #endregion

        #region ContentTemplateForImage

        //Expander Image loaded
        private void img_Loaded(object sender, RoutedEventArgs e)
        {
            Image Expander = (sender as Grid).FindName("Expander") as Image;
            if (ParentNo == 2 || ParentNo == 7)
            {
                Expander.Name = "P";
            }
            else
            {
                Expander.Name = "M";
            }
            ParentNo++;
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Node n = (((sender as Border).Child as Image).Tag as Node);
            Ismousedown = true;
            Image Expander = (sender as Border).Child as Image;
            if (n.Children != null)
            {
                //if plus is displayed show the children
                if (Expander.Name == "P")
                {
                    Expander.Name = "M";
                    Show(n);
                }
                //if minus is displayed hide the children
                else
                {
                    Expander.Name = "P";
                    Hide(n);
                }
            }
            //Update the image.
            if (Expander.Name == "P")
            {
                ((sender as Border).Child as Image).Source = App.Current.Resources["Plus"] as DrawingImage;
            }
            else
            {
                ((sender as Border).Child as Image).Source = App.Current.Resources["Minus"] as DrawingImage;
            }
        }

        private void Border_MouseEnter(object sender, MouseEventArgs e)
        {
            (sender as Border).BorderThickness = new Thickness(1);
        }

        private void Border_MouseLeave(object sender, MouseEventArgs e)
        {
            (sender as Border).BorderThickness = new Thickness(0);
        }

        //Get the instance of the Named object from the Node's template.
        private object FindNameFromContentTemplate(Node n, string name)
        {
            ContentPresenter cp = (((VisualTreeHelper.GetChild((VisualTreeHelper.GetChild(n, 0) as Canvas),0) as Border).Child as Grid).Children[3] as ContentPresenter);
            return cp.ContentTemplate.FindName(name, cp);
        }
        #endregion

        #region Expand and Collapse region

        //Expands the Child Nodes
        private void Show(Node n)
        {
            if (n.Children != null)
            {
                foreach (Node node in n.Children)
                {
                    //Showing the Engineers on clicking on the button on the Manager
                    foreach (LineConnector line in node.Edges)
                    {
                        if (line.HeadNode == n || line.TailNode == n)
                            line.Visibility = Visibility.Visible;
                    }
                    node.Visibility = Visibility.Visible;
                    if (node.IsLoaded)
                    {
                        try
                        {
                            if ((this.FindNameFromContentTemplate(node, "Expander") as Image).Name == "M")
                            {
                                Show(node);
                            }

                        }
                        catch (Exception e)
                        {
                        }
                    }
                }
            }
        }

        //Collapses the Child Nodes
        private void Hide(Node n)
        {
            if (n.Children != null)
            {
                foreach (Node node in n.Children)
                {
                    foreach (LineConnector line in node.Edges)
                    {
                        line.Visibility = Visibility.Hidden;
                    }

                    //Hiding the Engineers by removing them from the view.
                    if (diagramView.Page.Children.Contains(node))
                    {
                        node.Visibility = Visibility.Hidden;
                        Hide(node);
                    }
                }
            }
        }
        #endregion

        #region EventHandlers

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

        //Refresh the Layout
        private void refershLayout(TreeOrientation treeorientation)
        {
            DirectedTreeLayout tree = new DirectedTreeLayout(diagramModel, diagramView);
            diagramModel.Orientation = treeorientation;
            tree.RefreshLayout();
           
        } 
        #endregion
    }

    #region ContentClass

    //Content for the node
    public class NodeContent
    {
        //Image to represent the Person
        public ImageSource Person { get; set; }
        //Image to represent the Expander
        public ImageSource Expander { get; set; }
    } 
    #endregion

}
