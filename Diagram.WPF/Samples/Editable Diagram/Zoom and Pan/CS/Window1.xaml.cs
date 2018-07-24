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
using System.Globalization;

namespace ZoomandPan_2008
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {

        #region Constructor

        //Window1 Constructor
        public Window1()
        {
            InitializeComponent();
            //Initializes the Combobox
            InitializeCombobox();
            // Defines the nodes and adds to the model.
            createnodes();
        }

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

        #region Helper Methods

        // Defines the nodes and adds to the model.
        private void createnodes()
        {
            diagramView.SizeToContent = false;
            diagramView.PageBackground = Brushes.DarkSlateGray;
            diagramView.BoundaryConstraintsArea = new Rect(50, 50, 800, 500);
            double a = 150;
            double y = 100;
            double b = 60;

            Node n1 = addNode(50, 50, a, y, "01", App.Current.Resources["redseat"] as DataTemplate, Brushes.Transparent, null);
            Node n2 = addNode(50, 50, a + b, y, "02", App.Current.Resources["redseat"] as DataTemplate, Brushes.Transparent, null);
            Node n3 = addNode(50, 50, a + 2 * b, y, "03", App.Current.Resources["redseat"] as DataTemplate, Brushes.Transparent, null);
            Node n4 = addNode(50, 50, a + 3 * b, y, "04", App.Current.Resources["redseat"] as DataTemplate, Brushes.Transparent, null);
            Node n5 = addNode(50, 50, a + 6 * b, y, "05", App.Current.Resources["redseat"] as DataTemplate, Brushes.Transparent, null);
            Node n6 = addNode(50, 50, a + 7 * b, y, "06", App.Current.Resources["redseat"] as DataTemplate, Brushes.Transparent, null);
            Node n7 = addNode(50, 50, a + 8 * b, y, "07", App.Current.Resources["redseat"] as DataTemplate, Brushes.Transparent, null);
            Node n8 = addNode(50, 50, a + 9 * b, y, "08", App.Current.Resources["redseat"] as DataTemplate, Brushes.Transparent, null);

            double d = y + 60;

            Node n9 = addNode(50, 50, a, d, "09", App.Current.Resources["redseat"] as DataTemplate, Brushes.Transparent, null);
            Node n10 = addNode(50, 50, a + b, d, "10", App.Current.Resources["redseat"] as DataTemplate, Brushes.Transparent, null);
            Node n11 = addNode(50, 50, a + 2 * b, d, "11", App.Current.Resources["redseat"] as DataTemplate, Brushes.Transparent, null);
            Node n12 = addNode(50, 50, a + 3 * b, d, "12", App.Current.Resources["redseat"] as DataTemplate, Brushes.Transparent, null);
            Node n13 = addNode(50, 50, a + 6 * b, d, "13", App.Current.Resources["redseat"] as DataTemplate, Brushes.Transparent, null);
            Node n14 = addNode(50, 50, a + 7 * b, d, "14", App.Current.Resources["redseat"] as DataTemplate, Brushes.Transparent, null);
            Node n15 = addNode(50, 50, a + 8 * b, d, "15", App.Current.Resources["redseat"] as DataTemplate, Brushes.Transparent, null);
            Node n16 = addNode(50, 50, a + 9 * b, d, "16", App.Current.Resources["redseat"] as DataTemplate, Brushes.Transparent, null);

            double c = 300;

            Node bn1 = addNode(50, 50, a, c, "17", App.Current.Resources["redseat"] as DataTemplate, Brushes.Transparent, null);
            Node bn2 = addNode(50, 50, a + b, c, "18", App.Current.Resources["redseat"] as DataTemplate, Brushes.Transparent, null);
            Node bn3 = addNode(50, 50, a + 2 * b, c, "19", App.Current.Resources["redseat"] as DataTemplate, Brushes.Transparent, null);
            Node bn4 = addNode(50, 50, a + 3 * b, c, "20", App.Current.Resources["redseat"] as DataTemplate, Brushes.Transparent, null);
            Node bn5 = addNode(50, 50, a + 6 * b, c, "21", App.Current.Resources["redseat"] as DataTemplate, Brushes.Transparent, null);
            Node bn6 = addNode(50, 50, a + 7 * b, c, "22", App.Current.Resources["redseat"] as DataTemplate, Brushes.Transparent, null);
            Node bn7 = addNode(50, 50, a + 8 * b, c, "23", App.Current.Resources["redseat"] as DataTemplate, Brushes.Transparent, null);
            Node bn8 = addNode(50, 50, a + 9 * b, c, "24", App.Current.Resources["redseat"] as DataTemplate, Brushes.Transparent, null);

            d = c + 60;

            Node bn9 = addNode(50, 50, a, d, "25", App.Current.Resources["redseat"] as DataTemplate, Brushes.Transparent, null);
            Node bn10 = addNode(50, 50, a + b, d, "26", App.Current.Resources["redseat"] as DataTemplate, Brushes.Transparent, null);
            Node bn11 = addNode(50, 50, a + 2 * b, d, "27", App.Current.Resources["redseat"] as DataTemplate, Brushes.Transparent, null);
            Node bn12 = addNode(50, 50, a + 3 * b, d, "28", App.Current.Resources["redseat"] as DataTemplate, Brushes.Transparent, null);
            Node bn13 = addNode(50, 50, a + 6 * b, d, "29", App.Current.Resources["redseat"] as DataTemplate, Brushes.Transparent, null);
            Node bn14 = addNode(50, 50, a + 7 * b, d, "30", App.Current.Resources["redseat"] as DataTemplate, Brushes.Transparent, null);
            Node bn15 = addNode(50, 50, a + 8 * b, d, "31", App.Current.Resources["redseat"] as DataTemplate, Brushes.Transparent, null);
            Node bn16 = addNode(50, 50, a + 9 * b, d, "32", App.Current.Resources["redseat"] as DataTemplate, Brushes.Transparent, null);

            ////Style for the screen
            Style pathstyle = App.Current.Resources["screenstyle"] as Style;
            Node screen = addNode(600, 40, 150, 510, "", App.Current.Resources["Screentemplate"] as DataTemplate, Brushes.Transparent, pathstyle);

            //Style for the gates
            Style gates = App.Current.Resources["Gate"] as Style;
            Node gate = addNode(20, 80, 80, 220, "", null, Brushes.Transparent, gates);
            Style gate2s = App.Current.Resources["rightGate"] as Style;
            Node gate2 = addNode(20, 80, 800, 220, "", null, Brushes.Transparent, gate2s);
            Style exits = App.Current.Resources["exit"] as Style;
            Node exit = addNode(40, 20, 100, 190, "Exit", null, Brushes.Transparent, exits);
            Node exit2 = addNode(40, 20, 810, 190, "Exit", null, Brushes.Transparent, exits);
            Node exit3 = addNode(60, 20, 780, 450, "Screen", null, Brushes.Transparent, exits);
            Style paths = App.Current.Resources["path"] as Style;
            Node path1 = addNode(80, 310, 400, 100, "", null, Brushes.Gray, null);
            Node path2 = addNode(675, 70, 110, 220, "", null, Brushes.Gray, null);
        }
        #endregion

        #region EventHandlers

        //ZoomIn Coomand
        private void ZoomIn_click(object sender, RoutedEventArgs e)
        {
            ZoomCommands.ZoomIn.Execute(diagramView.Page, diagramView);
        }

        //ZoomOut command
        private void ZoomOut_click(object sender, RoutedEventArgs e)
        {
            ZoomCommands.ZoomOut.Execute(diagramView.Page, diagramView);
        }

        //Reset Command
        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            ZoomCommands.Reset.Execute(diagramView.Page, diagramView);
        }

        //Initialize the combobox values
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
                    Palette.IsChecked = true;
                    Palette.IsEnabled = true;
                    Zoom.IsChecked = true;
                    Zoom.IsEnabled = true;
                    zoomin.IsEnabled = true;
                    zoomout.IsEnabled = true;
                    zoomfactor.IsEnabled = true;
                    reset.IsEnabled = true;
                    Pan.IsEnabled = true;
                    PageEditable.ToolTip = "Disable Editing";
                }
                else if (cb.Name == "Zoom")
                {
                    diagramView.IsZoomEnabled = true;
                    Zoom.ToolTip = "Disable Zoom";
                }
                else if (cb.Name == "Pan")
                {
                    Pan.ToolTip = "Disable Panning";
                }
                else if(cb.Name=="Palette")
                {
                    Palette.IsEnabled = true;
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
                    Zoom.IsChecked = false;
                    Zoom.IsEnabled = false;
                    zoomin.IsEnabled = false;
                    zoomout.IsEnabled = false;
                    reset.IsEnabled = false;
                    zoomfactor.IsEnabled = false;
                    Pan.IsChecked = false;
                    Pan.IsEnabled = false;
                    PageEditable.ToolTip = "Enable Editing";
                }
                else if (cb.Name == "Zoom")
                {
                    diagramView.IsZoomEnabled = false;
                    Zoom.ToolTip = "Enable Zoom";
                }
                else if (cb.Name == "Pan")
                {
                    Pan.ToolTip = "Enable Panning";
                }
               

            }
        }
        #endregion

        #region PrivateFunctions

        //Add the Node to DiagramModel
        private Node addNode(double width, double height, double offsetx, double offsety, String label, DataTemplate datatemplate, Brush background, Style path)
        {
            Node node = new Node();
            node.Width = width;
            node.Height = height;
            node.OffsetX = offsetx;
            node.Background = background;
            node.CustomPathStyle = path;
            node.OffsetY = offsety;
            node.Label = label;
            if (datatemplate != null)
                node.ContentTemplate = datatemplate;
            diagramModel.Nodes.Add(node);
            return node;
        }
        #endregion

    }
}
