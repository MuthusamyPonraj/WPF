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
using System.Globalization;

namespace SnapToGridSample
{

    /// <summary>
    /// The Snap to Grid feature enables dragging nodes and connectors in multiples of offset values, 
    /// which is specified by using DiagramView’s SnapOffsetX and SnapOffsetY properties
    /// TWO Properties
    /// 1.SnapToHorizontalGrid
    /// Enables or disables snap to horizontal grid.
    /// 2.SnapToVerticalGrid
    /// Enables or disables snap to vertical grid.
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        #region Constructor

        public MainWindow()
        {
            InitializeComponent();
            //Create the Node
            CreateNodes();

            //call to populate the Combobox
            InitializeCombobox();
           
        }

        #endregion

        #region PrivateFunctions

        //Create Nodes
        private void CreateNodes()
        {
            Node n1 = addNode(50, 100, 250, 100, (App.Current.Resources["Man"] as Path), Shapes.Default, 0);
            Node n2 = addNode(50, 50, 250, 50, "Professor", Shapes.Default, 0);
            Node n3 = addNode(50, 100, 250, 350, (App.Current.Resources["Man1"] as Path), Shapes.Default, 0);
            Node n4 = addNode(50, 50, 250, 451, "Student", Shapes.Default, 0);
            Node n5 = addNode(125, 50, 500, 50, "Teach Leasons", Shapes.FlowChart_Start, 1);
            Node n6 = addNode(125, 50, 500, 200, "Evaluate Exams", Shapes.FlowChart_Start, 1);
            Node n7 = addNode(125, 50, 500, 375, "Write Exams", Shapes.FlowChart_Start, 1);
            Node n8 = addNode(125, 50, 500, 500, "Learn Lessons", Shapes.FlowChart_Start, 1);

            //Create connections
            Connect(n1, n5, ConnectorType.Straight, "", DecoratorShape.None);
            Connect(n1, n6, ConnectorType.Straight, "", DecoratorShape.None);
            Connect(n3, n7, ConnectorType.Straight, "", DecoratorShape.None);
            Connect(n3, n8, ConnectorType.Straight, "", DecoratorShape.None);
            Connect(n3, n1, ConnectorType.Straight, "<< Extend >>", DecoratorShape.Arrow);
            Connect(n7, n6, ConnectorType.Straight, "<< Extend >>", DecoratorShape.Arrow);
        }

        //Add the Node to the DiggramModel
        private Node addNode(double width, double height, double offsetx, double offsety, object content, Shapes shape, int level)
        {
            Node node = new Node();
            node.Width = width;
            node.Height = height;
            node.OffsetX = offsetx;
            node.OffsetY = offsety;
            //content of the Node
            if (content is Path)
            {
                (content as Path).Stretch = Stretch.Fill;
                (content as Path).Stroke = Brushes.Black;
                (content as Path).StrokeThickness = 1;
                node.IntersectionMode = IntersectionMode.OnBorder;
                node.Content = content;
            }
            else
            {
                node.Content = content;
            }
            node.Shape = shape;
            node.Level = level;
            //adding into DiagramModel
            diagramModel.Nodes.Add(node);
            return node;
        }

        //Add the connection to DiagramModel
        private void Connect(Node headnode, Node tailnode, ConnectorType conntype, String label, DecoratorShape taildeco)
        {
            LineConnector line = new LineConnector();
            line.HeadNode = headnode;
            line.TailNode = tailnode;
            line.ConnectorType = conntype;
            line.Label = label;
            line.TailDecoratorShape = taildeco;
            diagramModel.Connections.Add(line);
        }

        //Initialize the Combobox with ZoomFactor values
        private void InitializeCombobox()
        {
            double x = 0.2;
            foreach (ComboBoxItem item in zoomfactor.Items)
            {
                string st = Convert.ToString(x, CultureInfo.CurrentCulture.NumberFormat);
                item.Content = st;
                x += 0.2;
            }

            zoomfactor.SelectedIndex = 0;
        }
        #endregion

        #region Application Events

        //ZoomIn command
        private void zoomIn_Click(object sender, RoutedEventArgs e)
        {
            ZoomCommands.ZoomIn.Execute(diagramView.Page, diagramView);
        }

        //ZoomOut command
        private void zoomOut_Click(object sender, RoutedEventArgs e)
        {
            ZoomCommands.ZoomOut.Execute(diagramView.Page, diagramView);
        }

        //Reset Command
        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            ZoomCommands.Reset.Execute(diagramView.Page, diagramView);
        }

        //Save the diagram in Xaml file
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            diagramControl.Save();
        }

        //Load the Diagram from the Xaml file
        private void Load_Click(object sender, RoutedEventArgs e)
        {
            diagramControl.Load();
        }

        #endregion

        #region EventHandlers

        //invoked when the offsetx is changed
        private void OffsetXCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (diagramView != null)
            {
                object o = ((sender as ComboBox).SelectedItem as ComboBoxItem).Content;
                diagramView.SnapOffsetX = MeasureUnitsConverter.FromPixels(Double.Parse(o.ToString()), diagramPage.MeasurementUnits);
            }
        }

        //invoked when the offsety is changed
        private void OffsetYCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (diagramView != null)
            {
                object o = ((sender as ComboBox).SelectedItem as ComboBoxItem).Content;
                diagramView.SnapOffsetY = MeasureUnitsConverter.FromPixels(Double.Parse(o.ToString()), diagramPage.MeasurementUnits);
            }

        }

        //Zoom Factor specification.
        private void ComboBoxItem_SelectedCRadius(object sender, RoutedEventArgs e)
        {
            ComboBoxItem item = (ComboBoxItem)sender;
            if (diagramView != null)
                diagramView.ZoomFactor = Convert.ToDouble(item.Content);
        }

        //Enable the proeprties
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox cb = (sender as CheckBox);

            if (diagramView != null)
            {

                if (cb.Name == "PageEditable")
                {
                    diagramView.IsPageEditable = true;                   
                    Palette.IsEnabled = true;
                    Palette.IsChecked = true;
                    Zoom.IsEnabled = true;
                    Zoom.IsChecked = true;
                    zoomfactor.IsEnabled = true;
                    zoomin.IsEnabled = true;
                    zoomout.IsEnabled = true;
                    reset.IsEnabled = true;
                    Pan.IsEnabled = true;
                    SnapX.IsEnabled = true;
                    SnapX.IsChecked = true;
                    SnapY.IsEnabled = true;
                    SnapY.IsChecked = true;
                    OffsetXCombo.IsEnabled = true;
                    OffsetYCombo.IsEnabled = true;
                    HLine.IsEnabled = true;
                    HLine.IsChecked = true;
                    VLine.IsEnabled = true;
                    VLine.IsChecked = true;
                    PageEditable.ToolTip = "Disable Editing";
                }
                else if (cb.Name == "Zoom")
                {
                    diagramView.IsZoomEnabled = true;
                    Zoom.ToolTip = "Disable Zoom";
                }
                else if (cb.Name == "SnapY")
                {
                    diagramView.SnapToVerticalGrid = true;
                }
                else if (cb.Name == "SnapX")
                {
                    diagramView.SnapToHorizontalGrid = true;
                }
                else if (cb.Name == "HRuler")
                {
                    diagramView.ShowHorizontalRulers = true;
                }
                else if (cb.Name == "VRuler")
                {
                    diagramView.ShowVerticalRulers = true;
                }
               
            }
        }

        //Disable the properties
        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox cb = (sender as CheckBox);
            if (diagramView != null)
            {
                if (cb.Name == "PageEditable")
                {
                    diagramView.IsPageEditable = false;
                    Palette.IsEnabled = false;
                    Palette.IsChecked = false;
                    Zoom.IsEnabled = false;
                    zoomfactor.IsEnabled = false;
                    Zoom.IsChecked = false;
                    zoomout.IsEnabled = false;
                    zoomin.IsEnabled = false;
                    reset.IsEnabled = false;
                    Pan.IsChecked = false;
                    Pan.IsEnabled = false;
                    SnapX.IsChecked = false;
                    SnapX.IsEnabled = false;
                    SnapY.IsEnabled = false;
                    SnapY.IsChecked = false;
                    OffsetXCombo.IsEnabled = false;
                    OffsetYCombo.IsEnabled = false;
                    HLine.IsChecked = false;
                    VLine.IsChecked = false;
                    HLine.IsEnabled = false;
                    VLine.IsEnabled = false;
                    PageEditable.ToolTip = "Enable Editing";
                    
                }
                else if (cb.Name == "Zoom")
                {
                    diagramView.IsZoomEnabled = false;
                    Zoom.ToolTip = "Enable Zoom";
                }
                else if (cb.Name == "SnapY")
                {
                    diagramView.SnapToVerticalGrid = false;
                }
                else if (cb.Name == "SnapX")
                {
                    diagramView.SnapToHorizontalGrid = false;
                }
                else if (cb.Name == "HRuler")
                {
                    diagramView.ShowHorizontalRulers = false;
                }
                else if (cb.Name == "VRuler")
                {
                    diagramView.ShowVerticalRulers = false;
                }
               
            }
        }
        #endregion
    }
}
