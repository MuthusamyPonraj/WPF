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
using Syncfusion.Windows.Shared;
using System.Globalization;

namespace RulersAndUnits
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
            diagramView.UndoRedoEnabled = false;
            //Initialize the Combobox 
            InitializeCombobox();
            //Defines the nodes and adds to the model.
            Createnodes();

        }

        //Populate the Combobox with values
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

        //Defining the nodes.
        void Createnodes()
        {
            Node n = addNodes("n", "Start", 0, 3.5, 0.5, 1, 0.6, Shapes.FlowChart_Terminator);
            Node n1 = addNodes("n1", "Design", 1, 3.5, 1.5, 1, 0.6, Shapes.RoundedRectangle);
            Node n2 = addNodes("n2", "Coding", 2, 3.5, 2.5, 1, 0.6, Shapes.RoundedRectangle);
            Node n3 = addNodes("n3", "Testing", 3, 3.5, 3.5, 1, 0.6, Shapes.RoundedRectangle);
            Node n4 = addNodes("n4", "Errors?", 4, 3.5, 4.5, 1, 0.6, Shapes.FlowChart_Decision);
            Node n5 = addNodes("n5", "End", 5, 3.5, 5.5, 1, 0.6, Shapes.FlowChart_Terminator);
            //Node n6 = addNodes("n6", "DesignError?", 6, 1.5, 4.5, 1, 0.6, Shapes.FlowChart_Decision);
            Node n7 = addNodes("n7", "Design/Coding", 6, 1.5, 2.5, 1, 0.6, Shapes.FlowChart_Decision);
            //Node n8 = addNodes("n8", "Goto Design", 6, 1.5, 3.5, 1, 0.6, Shapes.RoundedRectangle);



            connection(n, n1, "", ConnectorType.Straight);
            connection(n1, n2, "", ConnectorType.Straight);
            connection(n2, n3, "", ConnectorType.Straight);
            connection(n3, n4, "", ConnectorType.Straight);
            connection(n4, n5, "No", ConnectorType.Straight);
            //connection(n4, n6, "Yes", ConnectorType.Straight);
            //connection(n6, n7, "Yes", ConnectorType.Straight);
            connection(n7, n4, "Yes", ConnectorType.Orthogonal);
            connection(n7, n1, "Yes", ConnectorType.Orthogonal);
            connection(n7, n2, "No", ConnectorType.Straight);

        }

        //Add the Connections to the DiagramModel
        private LineConnector connection(Node head, Node tail, string label, ConnectorType ct)
        {
            LineConnector flow = new LineConnector();
            flow.AutoAdjustPoints = true;
            flow.HeadNode = head;
            flow.TailNode = tail;
            flow.ConnectorType = ct;
            flow.TailDecoratorStyle.Fill = new SolidColorBrush(Colors.Black);
            flow.TailDecoratorStyle.Stroke = new SolidColorBrush(Colors.Black);
            flow.HeadDecoratorShape = DecoratorShape.Circle;
            flow.LineStyle.Stroke = new SolidColorBrush(Colors.Black);
            flow.HeadDecoratorStyle.Fill = new SolidColorBrush(Colors.Green);
            flow.HeadDecoratorStyle.Stroke = new SolidColorBrush(Colors.Green);
            flow.Label = label;
            flow.LabelHorizontalAlignment = HorizontalAlignment.Center;
            flow.LabelVerticalAlignment = VerticalAlignment.Center;
            flow.EnableMultilineLabel = true;
            flow.LabelTextWrapping = TextWrapping.Wrap;
            if (label == "Yes" && ct == ConnectorType.Orthogonal)
            {
                flow.IntermediatePoints.RemoveAt(0);
                flow.IntermediatePoints.RemoveAt(0);
                flow.IntermediatePoints.Add(new Point(1, 5.7));
                if (head.Name == "n7" && tail.Name == "n4")
                {
                    flow.HeadDecoratorStyle.Fill = new SolidColorBrush(Colors.Black);
                    flow.HeadDecoratorStyle.Stroke = new SolidColorBrush(Colors.Black);
                    flow.HeadDecoratorShape = DecoratorShape.Arrow;
                    flow.TailDecoratorShape = DecoratorShape.Circle;
                    flow.LineStyle.Stroke = new SolidColorBrush(Colors.Black);
                    flow.TailDecoratorStyle.Fill = new SolidColorBrush(Colors.Green);
                    flow.TailDecoratorStyle.Stroke = new SolidColorBrush(Colors.Green);
                }
            }
            if (label == "No" && ct == ConnectorType.Straight && head.Name == "n7" && tail.Name == "n2")
            {
                flow.LineStyle.Stroke = new SolidColorBrush(Colors.Red);
            }
            //if (label == "Yes" && ct == ConnectorType.Orthogonal)
            //{
            //    //ConnectionPort cp = new ConnectionPort(head, new Point(2, 0.3));
            //    //head.Ports.Add(cp);
            //    //cp.Node = head;

            //    //ConnectionPort cp1 = new ConnectionPort(tail, new Point(3, 0.3));
            //    //tail.Ports.Add(cp1);
            //    //cp1.Node = tail;
            //    //flow.ConnectionHeadPort = cp;
            //    //flow.ConnectionTailPort = cp1;
            //}
            diagramModel.Connections.Add(flow);
            return flow;

        }
        #endregion

        #region Event Handlers

        //Loads the selected page.
        private void P_Click(object sender, RoutedEventArgs e)
        {
            diagramControl.Load();
        }

        //Saves the page in the specified FormatConvertedBitmap.
        private void S_Click(object sender, RoutedEventArgs e)
        {
            diagramControl.Save();
        }

        // ZoomIn command
        private void Z_Click(object sender, RoutedEventArgs e)
        {
            ZoomCommands.ZoomIn.Execute(diagramView.Page, diagramView);
        }

        // ZoomOut command
        private void Zo_Click(object sender, RoutedEventArgs e)
        {
            ZoomCommands.ZoomOut.Execute(diagramView.Page, diagramView);
        }

        //Resets the page to default position.
        private void R_Click(object sender, RoutedEventArgs e)
        {
            ZoomCommands.Reset.Execute(diagramView.Page, diagramView);
        }

        //Zoom Factor specification.
        private void ComboBoxItem_SelectedCRadius(object sender, RoutedEventArgs e)
        {
            ComboBoxItem item = (ComboBoxItem)sender;
            if (diagramView != null)
                diagramView.ZoomFactor = Convert.ToDouble(item.Content);
        }

        //Change the Measurement and units
        private void c_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (diagramView != null)
            {
                switch (c.SelectedIndex)
                {

                    case 0:
                        (diagramView.Page as DiagramPage).MeasurementUnits = MeasureUnits.Pixel;

                        break;
                    case 1:
                        (diagramView.Page as DiagramPage).MeasurementUnits = MeasureUnits.Point;

                        break;
                    case 2:
                        (diagramView.Page as DiagramPage).MeasurementUnits = MeasureUnits.Centimeter;

                        break;
                    case 3:
                        (diagramView.Page as DiagramPage).MeasurementUnits = MeasureUnits.Display;

                        break;
                    case 4:
                        (diagramView.Page as DiagramPage).MeasurementUnits = MeasureUnits.Document;

                        break;
                    case 5:
                        (diagramView.Page as DiagramPage).MeasurementUnits = MeasureUnits.Inch;

                        break;
                    case 6:
                        (diagramView.Page as DiagramPage).MeasurementUnits = MeasureUnits.Kilometer;

                        break;
                    case 7:
                        (diagramView.Page as DiagramPage).MeasurementUnits = MeasureUnits.Meter;

                        break;
                    case 8:
                        (diagramView.Page as DiagramPage).MeasurementUnits = MeasureUnits.Millimeter;

                        break;
                    case 9:
                        (diagramView.Page as DiagramPage).MeasurementUnits = MeasureUnits.HalfInch;

                        break;
                    case 10:
                        (diagramView.Page as DiagramPage).MeasurementUnits = MeasureUnits.SixteenthInch;

                        break;
                    case 11:
                        (diagramView.Page as DiagramPage).MeasurementUnits = MeasureUnits.EighthInch;

                        break;
                    case 12:
                        (diagramView.Page as DiagramPage).MeasurementUnits = MeasureUnits.QuarterInch;

                        break;
                    case 13:
                        (diagramView.Page as DiagramPage).MeasurementUnits = MeasureUnits.Mile;

                        break;
                    case 14:
                        (diagramView.Page as DiagramPage).MeasurementUnits = MeasureUnits.Yard;

                        break;
                    case 15:
                        (diagramView.Page as DiagramPage).MeasurementUnits = MeasureUnits.Foot;

                        break;
                }

            }
        }

        //Enable Connection proeprties
        private void Connector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            diagramView.EnableConnection = true;
            ComboBox cb = (sender as ComboBox);
            switch (cb.SelectedIndex)
            {
                //Creates a Arc connection.
                case 0:
                    diagramView.DrawingTool = DrawingTools.Arc;
                    (diagramView.Page as DiagramPage).ConnectorType = ConnectorType.Arc;

                    break;
                //Creates a Bezier connection.
                case 1:
                    diagramView.DrawingTool = DrawingTools.BezierLine;
                    (diagramView.Page as DiagramPage).ConnectorType = ConnectorType.Bezier;

                    break;
                //Creates a Orthogonal connection.
                case 2:
                    diagramView.DrawingTool = DrawingTools.OrthogonalLine;
                    (diagramView.Page as DiagramPage).ConnectorType = ConnectorType.Orthogonal;

                    break;
                case 3:
                    //Creates a Straight connection.
                    diagramView.DrawingTool = DrawingTools.StraightLine;
                    (diagramView.Page as DiagramPage).ConnectorType = ConnectorType.Straight;

                    break;
            }
        }

        //Enable the proeprties
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox cb = (sender as CheckBox);
            if (diagramView != null)
            {

                if (cb.Name == "EConnection")
                {
                    diagramView.EnableConnection = true;
                    EConnector.IsEnabled = true;
                }
                else if (cb.Name == "PageEditable")
                {
                    diagramView.IsPageEditable = true;
                    if (Zoom != null)
                    {
                        Zoom.IsChecked = true;
                        zoomfactor.IsEnabled = true;
                        zbut.IsEnabled = true;
                        zobut.IsEnabled = true;
                        reset.IsEnabled = true;
                    }
                }
                else if (cb.Name == "Zoom")
                {
                    if (zoomfactor != null)
                    {
                        zoomfactor.IsEnabled = true;
                        zbut.IsEnabled = true;
                        zobut.IsEnabled = true;
                        reset.IsEnabled = true;
                    }
                }
                else if (cb.Name == "Pan")
                {
                    diagramView.IsPanEnabled = true;
                }

            }
        }

        //Disable the properties
        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox cb = (sender as CheckBox);
            if (diagramView != null)
            {

                if (cb.Name == "EConnection")
                {
                    diagramView.EnableConnection = false;
                    EConnector.IsEnabled = false;

                }
                else if (cb.Name == "PageEditable")
                {
                    diagramView.IsPageEditable = false;
                    if (Zoom != null)
                    {
                        Zoom.IsChecked = false;
                        zoomfactor.IsEnabled = false;
                        zbut.IsEnabled = false;
                        zobut.IsEnabled = false;
                        reset.IsEnabled = false;
                    }
                }
                else if (cb.Name == "Zoom")
                {
                    zoomfactor.IsEnabled = false;
                    zbut.IsEnabled = false;
                    zobut.IsEnabled = false;
                    reset.IsEnabled = false;
                }
                else if (cb.Name == "Pan")
                {
                    diagramView.IsPanEnabled = false;
                }


            }
        }

        //Vertical ruler and Horizontal ruler customization properties
        private void ColorPickerPalette_ColorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Syncfusion.Windows.Tools.Controls.ColorPickerPalette cpp = d as Syncfusion.Windows.Tools.Controls.ColorPickerPalette;
            switch (cpp.Name)
            {
                case "BGround":
                    horizontalRuler.Background = new SolidColorBrush(BGround.Color);
                    break;
                case "MajorLineStroke":
                    horizontalRuler.MajorLinesStroke = new SolidColorBrush(MajorLineStroke.Color);
                    break;
                case "MinorLineStroke":
                    horizontalRuler.MinorLinesStroke = new SolidColorBrush(MinorLineStroke.Color);
                    break;
                case "LabelFontColor":
                    horizontalRuler.LabelFontColor = new SolidColorBrush(LabelFontColor.Color);
                    break;
                case "MarkerBrush":
                    horizontalRuler.MarkerBrush = new SolidColorBrush(MarkerBrush.Color);
                    break;

                case "VBGround":
                    verticalRuler.Background = new SolidColorBrush(VBGround.Color);
                    break;
                case "VMajorLineStroke":
                    verticalRuler.MajorLinesStroke = new SolidColorBrush(VMajorLineStroke.Color);
                    break;
                case "VMinorLineStroke":
                    verticalRuler.MinorLinesStroke = new SolidColorBrush(VMinorLineStroke.Color);
                    break;
                case "VLabelFontColor":
                    verticalRuler.LabelFontColor = new SolidColorBrush(VLabelFontColor.Color);
                    break;
                case "VMarkerBrush":
                    verticalRuler.MarkerBrush = new SolidColorBrush(VMarkerBrush.Color);
                    break;

            }
        }
        #endregion

        #region Private Functions

        //Add the Node to the DiagramModel
        private Node addNodes(String name, String label, Int32 level, double offsetx, double offsety, double width, double height, Shapes shape)
        {
            Node node = new Node(Guid.NewGuid(), name);
            node.Label = label;
            node.Level = level;
            node.OffsetX = offsetx;
            node.OffsetY = offsety;
            node.Width = width;
            node.Height = height;
            node.LabelForeground = Brushes.White;
            node.LabelVerticalAlignment = VerticalAlignment.Center;
            node.EnableMultilineLabel = true;
            node.LabelTextWrapping = TextWrapping.Wrap;
            node.Shape = shape;
            node.IsLabelEditable = true;
            Style s = new System.Windows.Style();
            s.TargetType = typeof(Path);
            s.BasedOn = node.CustomPathStyle;
            s.Setters.Add(new Setter(Path.FillProperty, new SolidColorBrush(Colors.SteelBlue)));
            s.Setters.Add(new Setter(Path.StretchProperty, Stretch.Fill));
            node.CustomPathStyle = s;
            diagramModel.Nodes.Add(node);
            return node;
        }
        #endregion
    }
}
