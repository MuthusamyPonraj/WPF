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

namespace DecoratorShapeDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
       
        #region Public Variables

        //Declaring the public variables
        bool headselect;
        bool CustomHeadDecoratorStyle;
        LineConnector selectedline;
        #endregion

        #region Constructor

        public MainWindow()
        {
            InitializeComponent();
            //Initialize the Node
            createnodes();

            //Regitser the Events for Updating the ProeprtyGrid Values
            diagramView.ConnectorSelected += new ConnectorSelectedEventHandler(diagramView_ConnectorSelected);
            diagramView.ConnectorUnSelected += new ConnectorUnSelectedEventHandler(diagramView_ConnectorUnSelected);
            diagramView.NodeUnSelected += new NodeEventHandler(diagramView_NodeUnSelected);
            diagramView.NodeSelected += new NodeEventHandler(diagramView_NodeSelected);
        }
        #endregion

        #region ApplicationEvents

        //Nodeunselected event
        void diagramView_NodeUnSelected(object sender, NodeRoutedEventArgs evtArgs)
        {
            decoratorgrid.IsEnabled = true;
            Shapegrid.IsEnabled = true;
        }

        //Nodeselected event
        void diagramView_NodeSelected(object sender, NodeRoutedEventArgs evtArgs)
        {
           
            decoratorgrid.IsEnabled = false;
            Decorator.ToolTip = "Please select the Connector for customizing";
            Shapegrid.IsEnabled = false;
            
        }

        //LineConnectorunselected event
        void diagramView_ConnectorUnSelected(object sender, ConnectorRoutedEventArgs evtArgs)
        {
             selectedline = (evtArgs.Connector as LineConnector);
            Head.IsChecked = false;
            Tail.IsChecked = false;
            WidthValue.Text = string.Empty;
            HeightValue.Text = string.Empty;
            ThicknessValue.Text = string.Empty;
            fill.Color = Colors.Black;
            stroke.Color = Colors.Black;
            decoratorgrid.IsEnabled = false;
            Shapegrid.IsEnabled = false;
            fill.Opacity = 0.1;
            stroke.Opacity = 0.1;
        }

        //LineConnectorselected event
        void diagramView_ConnectorSelected(object sender, ConnectorRoutedEventArgs evtArgs)
        {

            decoratorgrid.IsEnabled = true;
            Shapegrid.IsEnabled = true;
            Customdename.IsEnabled = false;
            CustomHead.IsEnabled = false;
            HeadShape.IsEnabled = false;
            decoratorshape.IsEnabled = false;
            stroke.IsEnabled = false;
            Stroke.IsEnabled = false;
            fill.IsEnabled = false;
            Fill.IsEnabled = false;
            fill.Opacity = 0.1;
            stroke.Opacity = 0.1;
            Sthickness.IsEnabled = false;
            ThicknessValue.IsEnabled = false;
            WidthValue.IsEnabled = false;
            HeightValue.IsEnabled = false;
            width.IsEnabled = false;
            height.IsEnabled = false;
            //LineConnector selectedline = (evtArgs.Connector as LineConnector);
            //fill.Color = (selectedline.HeadDecoratorStyle.Fill as SolidColorBrush).Color;
            //stroke.Color = (selectedline.HeadDecoratorStyle.Stroke as SolidColorBrush).Color;
        }
        #endregion

        #region PrivateFunctions

        //Creating the Nodes
        private void createnodes()
        {
            //Node Creation
            Node n = addnode(400, 100, 50, 50, new SolidColorBrush(Colors.DarkCyan));
            Node n1 = addnode(400, 200, 50, 50, new SolidColorBrush(Colors.DarkCyan));
            Node n2 = addnode(400, 300, 50, 50, new SolidColorBrush(Colors.DarkCyan));
            Node n3 = addnode(400, 400, 50, 50, new SolidColorBrush(Colors.DarkCyan));
            Node n4 = addnode(250, 150, 50, 50, new SolidColorBrush(Colors.ForestGreen));
            Node n5 = addnode(250, 350, 50, 50, new SolidColorBrush(Colors.ForestGreen));
            Node n6 = addnode(550, 250, 50, 50, new SolidColorBrush(Colors.DarkViolet));

            
            //Connections
            Connect(n4, n, new SolidColorBrush(Colors.SkyBlue), new SolidColorBrush(Colors.Brown), DecoratorShape.Circle, DecoratorShape.Diamond, ConnectorType.Straight);
            Connect(n4, n1, new SolidColorBrush(Colors.SkyBlue), new SolidColorBrush(Colors.Brown), DecoratorShape.Arrow, DecoratorShape.Arrow, ConnectorType.Straight);
            Connect(n4, n2, new SolidColorBrush(Colors.SkyBlue), new SolidColorBrush(Colors.Brown), DecoratorShape.Circle, DecoratorShape.Circle, ConnectorType.Straight);
            Connect(n5, n1, new SolidColorBrush(Colors.SkyBlue), new SolidColorBrush(Colors.Brown), DecoratorShape.Diamond, DecoratorShape.Diamond, ConnectorType.Straight);
            Connect(n5, n2, new SolidColorBrush(Colors.SkyBlue), new SolidColorBrush(Colors.Brown), DecoratorShape.Circle, DecoratorShape.Diamond, ConnectorType.Straight);
            Connect(n5, n3, new SolidColorBrush(Colors.SkyBlue), new SolidColorBrush(Colors.Brown), DecoratorShape.Arrow, DecoratorShape.Diamond, ConnectorType.Straight);
            Connect(n, n6, new SolidColorBrush(Colors.SkyBlue), new SolidColorBrush(Colors.Brown), DecoratorShape.Circle, DecoratorShape.Circle, ConnectorType.Straight);
            Connect(n1, n6, new SolidColorBrush(Colors.SkyBlue), new SolidColorBrush(Colors.Brown), DecoratorShape.Diamond, DecoratorShape.Diamond, ConnectorType.Straight);
            Connect(n2, n6, new SolidColorBrush(Colors.SkyBlue), new SolidColorBrush(Colors.Brown), DecoratorShape.Arrow, DecoratorShape.Arrow, ConnectorType.Straight);
            Connect(n3, n6, new SolidColorBrush(Colors.SkyBlue), new SolidColorBrush(Colors.Brown), DecoratorShape.Custom, DecoratorShape.Custom, ConnectorType.Straight);


        }



        //Creating the Connections and Add into DiagramModel
        private void Connect(Node head, Node tail, SolidColorBrush solidColorBrush, SolidColorBrush solidstorkebursh, DecoratorShape taildecoratorShape, DecoratorShape headdecoratorShape, ConnectorType connectorType)
        {
            LineConnector lc = new LineConnector();
            lc.HeadNode = head;
            lc.TailNode = tail;
            lc.LineStyle.Fill = new SolidColorBrush(Colors.Black);
            lc.LineStyle.StrokeThickness = 2;
            lc.ConnectorType = ConnectorType.Straight;
            //For Applyibf Custom Decorator Shape
            if (headdecoratorShape == DecoratorShape.Custom)
            {
                lc.CustomHeadDecoratorStyle = this.Resources["Shape6"] as Style;
            }
            else
            {
                lc.HeadDecoratorShape = headdecoratorShape;
            }
            if (taildecoratorShape == DecoratorShape.Custom)
            {
                lc.CustomTailDecoratorStyle = this.Resources["Shape4"] as Style;
            }
            else
            {
                lc.TailDecoratorShape = taildecoratorShape;
            }
            lc.HeadDecoratorShape = DecoratorShape.Diamond;
            //Apply style to Decorator Shape
            lc.HeadDecoratorStyle.Fill = solidColorBrush;
            lc.HeadDecoratorStyle.Stroke = solidstorkebursh;
            lc.TailDecoratorStyle.Fill = solidColorBrush;
            lc.TailDecoratorStyle.Stroke = solidstorkebursh;
            diagramModel.Connections.Add(lc);
            
        }

        //add the Nodes into DiagramModel
        private Node addnode(double offsetx, double offsety, double width, double height, SolidColorBrush solidColorBrush)
        {
            Node node = new Node();
            node.OffsetX = offsetx;
            node.OffsetY = offsety;
            node.Width = width;
            node.Height = height;
            node.Shape = Shapes.Ellipse;
            node.CustomPathStyle = Getstyle(node, solidColorBrush);
            diagramModel.Nodes.Add(node);
            return node;

        }

        //Craeting the stylr to the Node
        private System.Windows.Style Getstyle(Node node, SolidColorBrush solidColorBrush)
        {
            Style style = new Style();
            style.BasedOn = node.CustomPathStyle;
            style.TargetType = typeof(Path);
            style.Setters.Add(new Setter(Path.FillProperty, solidColorBrush));
            style.Setters.Add(new Setter(Path.StrokeProperty, null));
            style.Setters.Add(new Setter(Path.StretchProperty, Stretch.Fill));
            return style;

        }
        #endregion

        #region EventHandlers

        /// <summary>
        /// For differntiating the Head and TailDecoratorShapes using the RadioButton.it is aplicable for only the Selected lineConnectors
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        
        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton button = (sender as RadioButton);
            if (diagramView.SelectionList.Count > 0)
            {
                foreach (object o in diagramView.SelectionList)
                {
                    if (o is LineConnector)
                    {
                        LineConnector selectedline = (o as LineConnector);
                        if (button.Name == "Head")
                        {
                            headselect = true;
                            
                            if (diagramView.SelectionList.Count > 0)
                            {
                                width.IsEnabled = true;
                                height.IsEnabled = true;
                                Customdename.IsEnabled = true;
                                CustomHead.IsEnabled = true;
                                HeadShape.IsEnabled = true;
                                decoratorshape.IsEnabled = true;
                                stroke.IsEnabled = true;
                                Stroke.IsEnabled = true;
                                fill.IsEnabled = true;
                                Fill.IsEnabled = true;
                                Sthickness.IsEnabled = true;
                                ThicknessValue.IsEnabled = true;
                                WidthValue.IsEnabled = true;
                                HeightValue.IsEnabled = true;
                                fill.Opacity = 1;
                                stroke.Opacity = 1;

                                WidthValue.Text = selectedline.HeadDecoratorStyle.Width.ToString();
                                HeightValue.Text = selectedline.HeadDecoratorStyle.Height.ToString();
                                ThicknessValue.Text = selectedline.HeadDecoratorStyle.StrokeThickness.ToString();
                                SolidColorBrush scb = selectedline.HeadDecoratorStyle.Fill as SolidColorBrush;
                                fill.Color = scb.Color;

                                SolidColorBrush scb1 = selectedline.HeadDecoratorStyle.Stroke as SolidColorBrush;
                                stroke.Color = scb1.Color;

                                string s = selectedline.HeadDecoratorShape.ToString();                                
                                CustomHead.IsEnabled = false;
                               
                                switch (s)
                                {
                                    case "Arrow":
                                        {
                                            HeadShape.SelectedIndex = 0;
                                        }
                                        break;

                                    case "Circle":
                                        {
                                            HeadShape.SelectedIndex = 1;
                                        }
                                        break;

                                    case "Custom":
                                        {
                                            HeadShape.SelectedIndex = 2;
                                            CustomHead.IsEnabled = true;
                                        }
                                        break;

                                    case "Diamond":
                                        {
                                            HeadShape.SelectedIndex = 3;
                                        }
                                        break;                                    
                                }
                            }
                        }
                        else
                        {
                            headselect = false;
                            width.IsEnabled = true;
                            height.IsEnabled = true;
                            Customdename.IsEnabled = true;
                            CustomHead.IsEnabled = true;
                            HeadShape.IsEnabled = true;
                            decoratorshape.IsEnabled = true;
                            stroke.IsEnabled = true;
                            Stroke.IsEnabled = true;
                            fill.IsEnabled = true;
                            Fill.IsEnabled = true;
                            Sthickness.IsEnabled = true;
                            ThicknessValue.IsEnabled = true;
                            WidthValue.IsEnabled = true;
                            HeightValue.IsEnabled = true;
                            fill.Opacity = 1;
                            stroke.Opacity = 1;

                            WidthValue.Text = selectedline.TailDecoratorStyle.Width.ToString();
                            HeightValue.Text = selectedline.TailDecoratorStyle.Height.ToString();
                            ThicknessValue.Text = selectedline.TailDecoratorStyle.StrokeThickness.ToString();
                            SolidColorBrush scb = selectedline.TailDecoratorStyle.Fill as SolidColorBrush;
                            fill.Color = scb.Color;

                            SolidColorBrush scb1 = selectedline.TailDecoratorStyle.Stroke as SolidColorBrush;
                            stroke.Color = scb1.Color;

                            string s = selectedline.TailDecoratorShape.ToString();                            
                            CustomHead.IsEnabled = false;                            
                            
                            switch (s)
                            {
                                case "Arrow":
                                    {
                                        HeadShape.SelectedIndex = 0;
                                    }
                                    break;

                                case "Circle":
                                    {
                                        HeadShape.SelectedIndex = 1;
                                    }
                                    break;

                                case "Custom":
                                    {
                                        HeadShape.SelectedIndex = 2;
                                        CustomHead.IsEnabled = true;
                                    }
                                    break;

                                case "Diamond":
                                    {
                                        HeadShape.SelectedIndex = 3;
                                    }
                                    break;
                            }
                            
                        }

                    }
                }
            }
        }

        /// <summary>
        /// HeadDecoratorStyle and TailDecoratorStyle properties are used for customzing the appoerance of the DecoratorShpae of the LineConnector
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        /// For Changin the Fill and Stroke of the LienCOnnector
        private void fill_ColorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Syncfusion.Windows.Tools.Controls.ColorPickerPalette cpp = d as Syncfusion.Windows.Tools.Controls.ColorPickerPalette;
            if (diagramView.SelectionList.Count > 0)
            {
                foreach (object o in diagramView.SelectionList)
                {
                    if (o is LineConnector)
                    {
                        LineConnector selectedline = (o as LineConnector);
                        if (headselect)
                        {
                            if (cpp.Name == "fill")
                            {
                                selectedline.HeadDecoratorStyle.Fill = new SolidColorBrush(fill.Color);
                            }
                            else
                            {
                                selectedline.HeadDecoratorStyle.Stroke = new SolidColorBrush(stroke.Color);
                            }
                        }
                        else
                        {
                            if (cpp.Name == "fill")
                            {
                                selectedline.TailDecoratorStyle.Fill = new SolidColorBrush(fill.Color);
                            }
                            else
                            {
                                selectedline.TailDecoratorStyle.Stroke = new SolidColorBrush(stroke.Color);
                            }
                        }
                    }
                }
            }
        }

        /// For Chaning a Width, Height and Strokethickness properties of the LineConnector ,it is apllicable when the LineConnector is selected
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox box = (sender as TextBox);
            if (diagramView != null)
            {
                if (diagramView.SelectionList.Count > 0)
                {
                    foreach (object o in diagramView.SelectionList)
                    {
                        if (o is LineConnector)
                        {
                            LineConnector selectedline = (o as LineConnector);
                            if (box.Text != string.Empty)
                            {
                                switch (box.Name)
                                {

                                    case "WidthValue":
                                        if (Head.IsChecked == true)
                                        {
                                            selectedline.HeadDecoratorStyle.Width = double.Parse(box.Text);
                                        }
                                        else if (Tail.IsChecked == true)
                                        {
                                            selectedline.TailDecoratorStyle.Width = double.Parse(box.Text);

                                        }
                                        break;
                                    case "HeightValue":
                                        if (Head.IsChecked == true)
                                        {
                                            selectedline.HeadDecoratorStyle.Height = double.Parse(box.Text);
                                        }
                                        else if (Tail.IsChecked == true)
                                        {
                                            selectedline.TailDecoratorStyle.Height = double.Parse(box.Text);
                                        }
                                        break;
                                    case "ThicknessValue":
                                        if (Head.IsChecked == true)
                                        {

                                            selectedline.HeadDecoratorStyle.StrokeThickness = double.Parse(box.Text);
                                        }
                                        else if (Tail.IsChecked == true)
                                        {

                                            selectedline.TailDecoratorStyle.StrokeThickness = double.Parse(box.Text);
                                        }
                                        break;

                                }
                            }
                            selectedline.UpdateConnectorPathGeometry();
                        }
                    }
                }

            }
        }

        //For Changing the Decorator Shapes
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox box = (sender as ComboBox);
            if (diagramView.SelectionList.Count > 0)
            {
                foreach (object o in diagramView.SelectionList)
                {
                    if (o is LineConnector)
                    {
                        LineConnector selectedline = (o as LineConnector);
                        if (box.SelectedIndex != 2)
                        {
                            CustomHead.SelectedIndex = -1;
                            CustomHead.IsEnabled = false;
                        }
                        switch (box.SelectedIndex)
                        {
                            case 0:
                                if (Head.IsChecked == true)
                                {
                                    selectedline.HeadDecoratorShape = DecoratorShape.Arrow;
                                }
                                else if (Tail.IsChecked == true)
                                {
                                    selectedline.TailDecoratorShape = DecoratorShape.Arrow;

                                }
                                break;
                            case 1:
                                if (Head.IsChecked == true)
                                {
                                    selectedline.HeadDecoratorShape = DecoratorShape.Circle;
                                }
                                else if (Tail.IsChecked == true)
                                {
                                    selectedline.TailDecoratorShape = DecoratorShape.Circle;
                                }
                                break;
                            case 2:
                                Customdename.IsEnabled = true;
                                CustomHead.IsEnabled = true;
                                break;
                            case 3:
                                if (Head.IsChecked == true)
                                {
                                    selectedline.HeadDecoratorShape = DecoratorShape.Diamond;
                                }
                                else if (Tail.IsChecked == true)
                                {
                                    selectedline.TailDecoratorShape = DecoratorShape.Diamond;
                                }
                                break;
                            case 4:
                                if (Head.IsChecked == true)
                                {
                                    selectedline.HeadDecoratorShape = DecoratorShape.None;
                                }
                                else if (Tail.IsChecked == true)
                                {
                                    selectedline.TailDecoratorShape = DecoratorShape.None;
                                }
                                break;
                        }
                    }
                }
            }

        }

        //For aplling custom Decorator Shpaes
        private void CustomHead_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox box = (sender as ComboBox);
            if (diagramView.SelectionList.Count > 0)
            {
                foreach (object o in diagramView.SelectionList)
                {
                    if (o is LineConnector)
                    {
                        LineConnector seletedline = (o as LineConnector);

                        if (Head.IsChecked == true)
                        {
                            //seletedline.HeadDecoratorShape=
                            switch (box.SelectedIndex)
                            {
                                case 0:
                                    seletedline.HeadDecoratorShape = DecoratorShape.Custom;
                                    seletedline.CustomHeadDecoratorStyle = this.Resources["Shape1"] as Style;

                                    break;
                                case 1:
                                    seletedline.HeadDecoratorShape = DecoratorShape.Custom;
                                    seletedline.CustomHeadDecoratorStyle = this.Resources["Shape2"] as Style;
                                    break;
                                case 2:
                                    seletedline.HeadDecoratorShape = DecoratorShape.Custom;
                                    seletedline.CustomHeadDecoratorStyle = this.Resources["Shape3"] as Style;
                                    break;
                                case 3:
                                    seletedline.HeadDecoratorShape = DecoratorShape.Custom;
                                    seletedline.CustomHeadDecoratorStyle = this.Resources["Shape4"] as Style;
                                    break;
                                case 4:
                                    seletedline.HeadDecoratorShape = DecoratorShape.Custom;
                                    seletedline.CustomHeadDecoratorStyle = this.Resources["Shape5"] as Style;
                                    break;
                                case 5:
                                    seletedline.HeadDecoratorShape = DecoratorShape.Custom;
                                    seletedline.CustomHeadDecoratorStyle = this.Resources["Shape6"] as Style;
                                    break;
                            }
                        }
                        else if (Tail.IsChecked == true)
                        {
                            switch (box.SelectedIndex)
                            {
                                case 0:
                                    seletedline.TailDecoratorShape = DecoratorShape.Custom;
                                    seletedline.CustomTailDecoratorStyle = this.Resources["Shape1"] as Style;
                                    break;
                                case 1:
                                    seletedline.TailDecoratorShape = DecoratorShape.Custom;
                                    seletedline.CustomTailDecoratorStyle = this.Resources["Shape2"] as Style;
                                    break;
                                case 2:
                                    seletedline.TailDecoratorShape = DecoratorShape.Custom;
                                    seletedline.CustomTailDecoratorStyle = this.Resources["Shape3"] as Style;
                                    break;
                                case 3:
                                    seletedline.TailDecoratorShape = DecoratorShape.Custom;
                                    seletedline.CustomTailDecoratorStyle = this.Resources["Shape4"] as Style;
                                    break;
                                case 4:
                                    seletedline.TailDecoratorShape = DecoratorShape.Custom;
                                    seletedline.CustomTailDecoratorStyle = this.Resources["Shape5"] as Style;
                                    break;
                                case 5:
                                    seletedline.TailDecoratorShape = DecoratorShape.Custom;
                                    seletedline.CustomTailDecoratorStyle = this.Resources["Shape6"] as Style;
                                    break;
                            }
                        }
                    }
                }
            }
        }
        #endregion
    }
}
