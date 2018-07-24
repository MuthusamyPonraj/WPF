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

namespace TableLayout_2008
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        #region Public Variables

        //declaring the public variables
        Node EssentialWPF;

        #endregion

        #region Contructor

        public Window1()
        {
            InitializeComponent();
            //Adds the nodes to the page.
            createNodes();
        }
        #endregion

        #region HelperMethods

        //Defining the nodes.
        private void createNodes()
        {
            Node n1 = addNode("n1", Shapes.FlowChart_Card);
            Node n2 = addNode("n2", Shapes.FlowChart_Data);
            Node n3 = addNode("n3", Shapes.FlowChart_Delay);
            Node n4 = addNode("n4", Shapes.FlowChart_Display);
            Node n5 = addNode("n5", Shapes.FlowChart_ManualInput);
            Node n6 = addNode("n6", Shapes.Star);
            Node n7 = addNode("n7", Shapes.FlowChart_Decision);
            Node n8 = addNode("n8", Shapes.FlowChart_OffPageReference);
            Node n9 = addNode("n9", Shapes.FlowChart_PaperTape);
            Node n10 = addNode("n10", Shapes.Hexagon);
            Node n11 = addNode("n11", Shapes.FlowChart_Preparation);
            Node n12 = addNode("n12", Shapes.FlowChart_StoredData);
           
        }

        #endregion

        #region Event Handlers

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
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TableLayout table = new TableLayout(diagramModel, diagramView);
            table.RefreshLayout();
        }

        //invoked when Orientation is changed
        ///<summary>
        ///TableExpandMode
        /// Description:
        /// an enumeration which takes two values, Horizontal and Vertical. 
        /// Default value is Horizontal. It specifies how the table gets expanded when more items are added to the model.
        /// </summary>
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox combobox = (sender as ComboBox);
            if (diagramModel != null)
            {
                switch ((combobox.SelectedItem as ComboBoxItem).Name)
                {
                    case "Horizontal":

                        diagramModel.TableExpandMode = ExpandMode.Horizontal;
                        if (rt != null && ct != null)
                        {
                            rt.IsEnabled = false;
                            ct.IsEnabled = true;
                        }
                        TableLayout table = new TableLayout(diagramModel, diagramView);
                        table.RefreshLayout();
                        break;
                    case "Vertical":
                        diagramModel.TableExpandMode = ExpandMode.Vertical;
                        if (rt != null && ct != null)
                        {
                            rt.IsEnabled = true;
                            ct.IsEnabled = false;
                        }
                        TableLayout table1 = new TableLayout(diagramModel, diagramView);
                        table1.RefreshLayout();
                        break;
                }
            }
        }

        //invoked when the RowCount is Changed
        /// <summary>
        ///  RowCount
        ///  Description:
        ///  used to specify the maximum number of rowsallowed in the table.
        /// </summary>
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (diagramModel != null)
                    diagramModel.RowCount = Convert.ToInt32((sender as IntegerTextBox).Value);
            }
            catch
            {
               MessageBox.Show("Invalid Input. Enter digits (0-9) only", "Invalid input", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            TableLayout table = new TableLayout(diagramModel, diagramView);
            table.RefreshLayout();
        }

        //Invoked when the Colum count is changed
        ///<summary>
        ///ColumnCount
        ///Description:
        ///specify the maximum columns allowed in the table
        ///</summary>
        private void TextBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (diagramModel != null)
                    diagramModel.ColumnCount = Convert.ToInt32((sender as IntegerTextBox).Value);
            }
            catch
            {
                MessageBox.Show("Invalid Input. Enter digits (0-9) only", "Invalid input", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            TableLayout table = new TableLayout(diagramModel, diagramView);
            table.RefreshLayout();
        }

        //To Change the value of the EnableLayoutWithVariedSizes
        ///<summary>
        ///EnableLayoutWithVariedSizes
        ///nodes are of different sizes (width and height). 
        ///</summary>
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            diagramModel.EnableLayoutWithVariedSizes = true;
            TableLayout table = new TableLayout(diagramModel, diagramView);
            VarySize.ToolTip = "Disable the VariedSize";
            table.RefreshLayout();
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            diagramModel.EnableLayoutWithVariedSizes = false;
            TableLayout table = new TableLayout(diagramModel, diagramView);
            VarySize.ToolTip = "Enable the VariedSize";
            table.RefreshLayout();
        }

        //To change the Spcing properties
        /// <summary>
        /// HorizontalSpacing and VerticalSpacing
        /// Description:
        /// Provide the spaces between the edges of the adjacent nodes (Siblings)[HorizontalSpacing].
        /// Provide  spaces between the nodes that lie at the next levels of the layout[VerticalSpacing].
        /// Property of DiagramModel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox2_TextChanged(object sender, TextChangedEventArgs e)
        {
            TableLayout tlayout = new TableLayout(diagramModel, diagramView);
            TextBox tb = (sender as TextBox);
            if (diagramModel != null)
            {
                if (tb.Text != string.Empty)
                {
                    if (tb.Name == "hspace")
                    {
                        //Provide the spaces between the edges of the adjacent nodes (Siblings) 
                        diagramModel.HorizontalSpacing = double.Parse(tb.Text);
                        tlayout.RefreshLayout();
                    }
                    else if (tb.Name == "vspace")
                    {
                        //Provide  spaces between the nodes that lie at the next levels of the layout.
                        diagramModel.VerticalSpacing = double.Parse(tb.Text);
                        tlayout.RefreshLayout();
                    }
                }
            }

        }

        //Add  the Node upto the mentioned count
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int count = 0;
            try
            {
                if (diagramModel != null)
                    count = Convert.ToInt32(nodes.Text);
            }
            catch
            {
                MessageBox.Show("Invalid Input. Enter digits (0-9) only", "Invalid input", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            for (int i = 0; i < count; i++)
            {
                Node n = addNode("n" + (i + 20), Shapes.Ellipse);
            }

            TableLayout table = new TableLayout(diagramModel, diagramView);
            table.RefreshLayout();
        }

        //add the Node to DiagramModel
        private Node addNode(String name, Shapes shape)
        {
            Node node = new Node(Guid.NewGuid(), name);
            node.Shape = shape;
            diagramModel.Nodes.Add(node);
            return node;
        }

        #endregion

        private void SelectionBaseLayout_Checked(object sender, RoutedEventArgs e)
        {
            // assigning selected node to Ordered nodes.
            diagramModel.OrderedNodes = diagramView.SelectionList.OfType<IShape>().ToList();
            TableLayout table = new TableLayout(diagramModel, diagramView);
            table.RefreshLayout();
        }

        private void SelectionBaseLayout_Unchecked(object sender, RoutedEventArgs e)
        {
            // setting null to Ordered nodes.
            diagramModel.OrderedNodes = null;// diagramView.SelectionList.OfType<IShape>().ToList();
            TableLayout table = new TableLayout(diagramModel, diagramView);
            table.RefreshLayout();
        }

        #region PrivateFunctions



        #endregion
    }
}
