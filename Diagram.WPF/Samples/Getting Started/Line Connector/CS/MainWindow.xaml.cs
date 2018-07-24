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
using System.ComponentModel;
using System.Reflection;
using Syncfusion.Windows.Tools.Controls;

namespace LineConnectorDemo_2010
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Constructor

        public MainWindow()
        {
            InitializeComponent();
            //Initialize the connector
            LoadConnectors();
            //Initialize the connector proprties
            InitializetheValues();
            //Initialize the Event Handlers
            InitializeEvents();
            
        }

        //Register the event handlers
        private void InitializeEvents()
        {
            diagramView1.ConnectorStartLabelEdit += new LabelEditConnChangedEventHandler(diagramView1_ConnectorStartLabelEdit);
            diagramView1.ConnectorDoubleClick += new ConnChangedEventHandler(diagramView1_ConnectorDoubleClick);
            diagramView1.ConnectorLabelChanged += new LabelConnChangedEventHandler(diagramView1_ConnectorLabelChanged);
            diagramView1.ConnectorDragStart += new ConnDragChangedEventHandler(diagramView1_ConnectorDragStart);
            diagramView1.ConnectorDragEnd += new ConnDragEndChangedEventHandler(diagramView1_ConnectorDragEnd);
            diagramView1.HeadNodeChanged += new NodeChangedEventHandler(diagramView1_HeadNodeChanged);
            diagramView1.TailNodeChanged += new NodeChangedEventHandler(diagramView1_TailNodeChanged);
            diagramView1.ConnectorDrop += new ConnectorDroppedEventHandler(diagramView1_ConnectorDrop);
            diagramView1.ConnectorDeleting += new ConnectionDeleteEventHandler(diagramView1_ConnectorDeleting);
            diagramView1.ConnectorDeleted += new ConnectionDeleteEventHandler(diagramView1_ConnectorDeleted);
            diagramView1.Grouped += new GroupEventHandler(diagramView1_Grouped);
            diagramView1.Grouping += new GroupEventHandler(diagramView1_Grouping);
            diagramView1.Ungrouping += new UnGroupEventHandler(diagramView1_Ungrouping);
            diagramView1.Ungrouped += new UnGroupEventHandler(diagramView1_Ungrouped);
            diagramView1.LineMoved += new LineNudgeEventHandler(diagramView1_LineMoved);
            diagramView1.ConnectorSelected += new ConnectorSelectedEventHandler(diagramView1_ConnectorSelected);
            diagramView1.ConnectorUnSelected += new ConnectorUnSelectedEventHandler(diagramView1_ConnectorUnSelected);
            diagramView1.PreviewConnectorDrop += new PreviewConnectorDropEventHandler(diagramView1_PreviewConnectorDrop);
            diagramView1.ConnectorClick += new ConnectorRoutedEventHandler(diagramView1_ConnectorClick);
            diagramView1.BeforeConnectionCreate += new BeforeCreateConnectionEventHandler(diagramView1_BeforeConnectionCreate);
            diagramView1.AfterConnectionCreate += new ConnDragEndChangedEventHandler(diagramView1_AfterConnectionCreate);
        }

        //Initailzes the Vlaues of the Coneector properties
        private void InitializetheValues()
        {
            Type ctype = typeof(Syncfusion.Windows.Diagram.ConnectorType);
            List<string> cprop = getEumerations(ctype);
            foreach (string c in cprop)
            {
                this.ctcombo.Items.Add(c);
            }

            Type adirection = typeof(System.Windows.Media.SweepDirection);
            List<string> cprop1 = getEumerations(adirection);
            foreach (string c in cprop1)
            {
                this.arcdirection.Items.Add(c);
            }

            Type decshape = typeof(Syncfusion.Windows.Diagram.DecoratorShape);
            List<string> decshapepropInfoList = getEumerations(decshape);
            foreach (string c in decshapepropInfoList)
            {
                this.HeadDecoratorshape.Items.Add(c);
                this.TailDecoratorshape.Items.Add(c);
            }

            Type halign = typeof(System.Windows.HorizontalAlignment);
            List<string> halignprop = getEumerations(halign);
            foreach (string c in halignprop)
            {
                this.lclblhoralign.Items.Add(c);
                this.lctlblhoralign.Items.Add(c);
            }

            Type twrap = typeof(System.Windows.TextWrapping);
            List<string> twrapprop = getEumerations(twrap);
            foreach (string c in twrapprop)
            {
                this.lclbltextwrap.Items.Add(c);
            }

            Type fweight = typeof(System.Windows.FontWeights);
            PropertyInfo[] fweightprop = fweight.GetProperties();
            foreach (PropertyInfo c in fweightprop)
            {
                this.lcfontweight.Items.Add(c.Name);
            }

            Type fstyle = typeof(System.Windows.FontStyles);
            PropertyInfo[] fontpropInfoList2 = fstyle.GetProperties();
            foreach (PropertyInfo c in fontpropInfoList2)
            {
                this.lcfontStyle.Items.Add(c.Name);
            }

            Type ttrim = typeof(System.Windows.TextTrimming);
            List<string> ttrimprop = getEumerations(ttrim);
            foreach (string c in ttrimprop)
            {
                this.lctriming.Items.Add(c);
            }

            Type talign = typeof(System.Windows.TextAlignment);
            List<string> talignprop = getEumerations(talign);
            foreach (string c in talignprop)
            {
                this.lclabeltextalignment.Items.Add(c);
            }

            Type tdecor = typeof(System.Windows.TextDecorations);
            PropertyInfo[] tdecorprop = tdecor.GetProperties();
            this.lclabeltextdecorations.Items.Add("None");
            foreach (PropertyInfo c in tdecorprop)
            {
                this.lclabeltextdecorations.Items.Add(c.Name);
            }

        }
        #endregion

        #region Diagram View EventHandlers

        //Add to log when the LineConnector is moved

        void diagramView1_LineMoved(object sender, LineNudgeEventArgs evtArgs)
        {
            AddToLog("LineConnector", " is moved");
        }

        //Add to log when the LineConnector is UnGrouped
        void diagramView1_Ungrouped(object sender, UnGroupEventArgs evtArgs)
        {
            AddToLog(evtArgs.Group.NodeChildren.Count.ToString(), "Items are UnGrouped");
        }

        //Add to log when the LineConnector is UnGrouping
        void diagramView1_Ungrouping(object sender, UnGroupEventArgs evtArgs)
        {
            if (evtArgs.GroupNode != null)
            {
                AddToLog(evtArgs.GroupNode.Name.ToString(), " is UnGrouping");
            }
            else if (evtArgs.GroupLineConnector != null)
            {
                AddToLog(evtArgs.GroupLineConnector.Name.ToString(), "LineConnectord  is UnGrouping");
            }
        }

        //Add to log when the LineConnector is Grouping
        void diagramView1_Grouping(object sender, GroupEventArgs evtArgs)
        {
            if (evtArgs.GroupNode != null)
            {
                AddToLog(evtArgs.GroupNode.Name.ToString(), " is Grouping");
            }
            else if (evtArgs.GroupLineConnector != null)
            {
                AddToLog(evtArgs.GroupLineConnector.Name.ToString(), "LineConnector  is Grouping");
            }
        }

        //Add to log when the LineConnector is Grouped
        void diagramView1_Grouped(object sender, GroupEventArgs evtArgs)
        {
            AddToLog(evtArgs.Group.NodeChildren.Count.ToString(), "Items are Grouped");
        }

        //Add to log when the LineConnector is Deleted
        void diagramView1_ConnectorDeleted(object sender, ConnectionDeleteRoutedEventArgs evtArgs)
        {
            if (evtArgs.DeletedLineConnector != null)
            {
                AddToLog(evtArgs.DeletedLineConnector.Name.ToString(), " ConnectorDeleted event was fired.");
                AddToLog("Number of LineConnectors in the Page", diagramModel1.Connections.Count.ToString());
            }
            else
            {
                AddToLog("", " ConnectorDeleted event was fired.");
                AddToLog("Number of LineConnectors in the Page", diagramModel1.Connections.Count.ToString());
            }
        }

        //Add to log when the LineConnector is Deleting and the Count of teh Lieconnector
        void diagramView1_ConnectorDeleting(object sender, ConnectionDeleteRoutedEventArgs evtArgs)
        {
            if (evtArgs.DeletedLineConnector != null)
            {
                AddToLog(evtArgs.DeletedLineConnector.Name.ToString(), " ConnectorDeleting event was fired.");
                AddToLog("Number of LineConnectors in the Page", diagramModel1.Connections.Count.ToString());
            }
            else
            {
                AddToLog("", " ConnectorDeleteing event was fired.");
                AddToLog("Number of LineConnectors in the Page", diagramModel1.Connections.Count.ToString());
            }
        }

        //Add to log when the LineConnector is Dropped
        void diagramView1_ConnectorDrop(object sender, ConnectorDroppedRoutedEventArgs evtArgs)
        {
            Label tt = new Label();
            tt.FontSize = 12;
            tt.Content = "ConnectorDrop event was fired";
            disArea.Children.Add(tt);
            Scroll.ScrollToBottom();
            UpdateProperties(evtArgs.DroppedConnector as LineConnector);
        }

        //Add to log when the LineConnector is PreviewDropped
        void diagramView1_PreviewConnectorDrop(object sender, PreviewConnectorDropEventRoutedEventArgs evtArgs)
        {
            AddToLog("Connctor", " Preview Drop");
        }

        //Add to log when the TailNode of the  LineConnector is Changed
        void diagramView1_TailNodeChanged(object sender, NodeChangedRoutedEventArgs evtArgs)
        {
            if (evtArgs.PreviousNode != null && evtArgs.CurrentNode != null)
                AddToLog(evtArgs.Connector.Name.ToString(), "TailNode Changed event was fired.", " [CurrentNode: ", evtArgs.CurrentNode.Name.ToString(), ", PreviousNode: ", evtArgs.PreviousNode.Name.ToString());
            else if (evtArgs.PreviousNode == null && evtArgs.CurrentNode != null)
                AddToLog(evtArgs.Connector.Name.ToString(), "TailNode Changed event was fired. [CurrentNode: ", evtArgs.CurrentNode.Name.ToString());
            else if (evtArgs.PreviousNode != null && evtArgs.CurrentNode == null)
                AddToLog(evtArgs.Connector.Name.ToString(), "TailNode Changed event was fired. [PreviousNode: ", evtArgs.PreviousNode.Name.ToString());
            else if (evtArgs.PreviousNode == null && evtArgs.CurrentNode == null)
                AddToLog(evtArgs.Connector.Name.ToString(), "TailNode Changed event was fired.");
        }

        //Add to log when the HeadNode of the  LineConnector is Changed
        void diagramView1_HeadNodeChanged(object sender, NodeChangedRoutedEventArgs evtArgs)
        {
            if (evtArgs.PreviousNode != null && evtArgs.CurrentNode != null)
                AddToLog(evtArgs.Connector.Name.ToString(), "HeadNode Changed event was fired.", " [CurrentNode: ", evtArgs.CurrentNode.Name.ToString(), ", PreviousNode: ", evtArgs.PreviousNode.Name.ToString());
            else if (evtArgs.PreviousNode == null && evtArgs.CurrentNode != null)
                AddToLog(evtArgs.Connector.Name.ToString(), "HeadNode Changed event was fired. [CurrentNode: ", evtArgs.CurrentNode.Name.ToString());
            else if (evtArgs.PreviousNode != null && evtArgs.CurrentNode == null)
                AddToLog(evtArgs.Connector.Name.ToString(), "HeadNode Changed event was fired. [PreviousNode: ", evtArgs.PreviousNode.Name.ToString());
            else if (evtArgs.PreviousNode == null && evtArgs.CurrentNode == null)
                AddToLog(evtArgs.Connector.Name.ToString(), "HeadNode Changed event was fired.");
        }

        //Add to log when the ConnectorDragEnd event of LineConnector is fired
        void diagramView1_ConnectorDragEnd(object sender, ConnDragEndRoutedEventArgs evtArgs)
        {
            if (evtArgs.FixedNodeEnd != null && evtArgs.HitNodeEnd != null)
                AddToLog(evtArgs.Connector.Name.ToString(), " DragEnd event was fired." + " [FixedNodeEnd: ", evtArgs.FixedNodeEnd.Name.ToString(), ", HitNodeEnd: ", evtArgs.HitNodeEnd.Name.ToString());
            else if (evtArgs.FixedNodeEnd == null && evtArgs.HitNodeEnd != null)
                AddToLog(evtArgs.Connector.Name.ToString(), " DragEnd event was fired." + ", HitNodeEnd: ", evtArgs.HitNodeEnd.Name.ToString());
            else if (evtArgs.FixedNodeEnd != null && evtArgs.HitNodeEnd == null)
                AddToLog(evtArgs.Connector.Name.ToString(), " DragEnd event was fired." + " [FixedNodeEnd: ", evtArgs.FixedNodeEnd.Name.ToString());
            else if (evtArgs.FixedNodeEnd == null && evtArgs.HitNodeEnd == null)
                AddToLog(evtArgs.Connector.Name.ToString(), " DragEnd event was fired.");
        }

        //Add to log when the ConnectorDragStart event of LineConnector is fired
        void diagramView1_ConnectorDragStart(object sender, ConnDragRoutedEventArgs evtArgs)
        {
            if (evtArgs.FixedNodeEnd != null && evtArgs.MovableNodeEnd != null)
                AddToLog(evtArgs.Connector.Name.ToString(), " DragStart event was fired." + " [FixedNodeEnd: ", evtArgs.FixedNodeEnd.Name.ToString(), ", MovableNodeEnd: ", evtArgs.MovableNodeEnd.Name.ToString());
            else if (evtArgs.FixedNodeEnd == null && evtArgs.MovableNodeEnd != null)
                AddToLog(evtArgs.Connector.Name.ToString(), " DragStart event was fired." + ", MovableNodeEnd: ", evtArgs.MovableNodeEnd.Name.ToString());
            else if (evtArgs.FixedNodeEnd != null && evtArgs.MovableNodeEnd == null)
                AddToLog(evtArgs.Connector.Name.ToString(), " DragStart event was fired." + " [FixedNodeEnd: ", evtArgs.FixedNodeEnd.Name.ToString());
            else if (evtArgs.FixedNodeEnd == null && evtArgs.MovableNodeEnd == null)
                AddToLog(evtArgs.Connector.Name.ToString(), " DragStart event was fired.");
        }

        //Add to log when the ConnectorLabelChanged event of LineConnector is fired
        void diagramView1_ConnectorLabelChanged(object sender, LabelConnRoutedEventArgs evtArgs)
        {
            if (evtArgs.HeadNode != null && evtArgs.TailNode != null)
                AddToLog(evtArgs.Connector.Name.ToString(), " Label Changed event  was fired. [OldLabelValue: ", evtArgs.OldLabelValue.ToString(), ", NewLabelValue: ", evtArgs.NewLabelValue.ToString(), ", HeadNode: ", evtArgs.HeadNode.Name.ToString(), ", TailNode: ", evtArgs.TailNode.Name.ToString());
            else if (evtArgs.HeadNode == null && evtArgs.TailNode != null)
                AddToLog(evtArgs.Connector.Name.ToString(), " Label Changed event  was fired. [OldLabelValue: ", evtArgs.OldLabelValue.ToString(), ", NewLabelValue: ", evtArgs.NewLabelValue.ToString(), ", TailNode: ", evtArgs.TailNode.Name.ToString());
            else if (evtArgs.HeadNode != null && evtArgs.TailNode == null)
                AddToLog(evtArgs.Connector.Name.ToString(), " Label Changed event  was fired. [OldLabelValue: ", evtArgs.OldLabelValue.ToString(), ", NewLabelValue: ", evtArgs.NewLabelValue.ToString(), ", HeadNode: ", evtArgs.HeadNode.Name.ToString());
            else if (evtArgs.HeadNode == null && evtArgs.TailNode == null)
                AddToLog(evtArgs.Connector.Name.ToString(), " Label Changed event  was fired. [OldLabelValue: ", evtArgs.OldLabelValue.ToString(), ", NewLabelValue: ", evtArgs.NewLabelValue.ToString());
        }

        //Add to log when the ConnectorDoubleClick event of LineConnector is fired
        void diagramView1_ConnectorDoubleClick(object sender, ConnRoutedEventArgs evtArgs)
        {
            if (evtArgs.HeadNode != null && evtArgs.TailNode != null)
                AddToLog(evtArgs.Connector.Name.ToString(), " was Double Clicked." + " [HeadNode: ", evtArgs.HeadNode.Name.ToString(), ", TailNode: ", evtArgs.TailNode.Name.ToString());
            else if (evtArgs.HeadNode == null && evtArgs.TailNode != null)
                AddToLog(evtArgs.Connector.Name.ToString(), " was Double Clicked." + ", TailNode: ", evtArgs.TailNode.Name.ToString());
            else if (evtArgs.HeadNode != null && evtArgs.TailNode == null)
                AddToLog(evtArgs.Connector.Name.ToString(), " was Double Clicked." + " [HeadNode: ", evtArgs.HeadNode.Name.ToString());
            else if (evtArgs.HeadNode == null && evtArgs.TailNode == null)
                AddToLog(evtArgs.Connector.Name.ToString(), " was Double Clicked.");
        }

        //Add to log when the ConnectorStartLabelEdit event of LineConnector is fired
        void diagramView1_ConnectorStartLabelEdit(object sender, LabelEditConnRoutedEventArgs evtArgs)
        {
            if (evtArgs.HeadNode != null && evtArgs.TailNode != null)
                AddToLog(evtArgs.Connector.Name.ToString(), " StartLabelEdit event  was fired. [OldLabelValue: ", evtArgs.OldLabelValue.ToString(), ", HeadNode: ", evtArgs.HeadNode.Name.ToString(), ", TailNode: ", evtArgs.TailNode.Name.ToString());
            else if (evtArgs.HeadNode == null && evtArgs.TailNode != null)
                AddToLog(evtArgs.Connector.Name.ToString(), " StartLabelEdit event  was fired. [OldLabelValue: ", evtArgs.OldLabelValue.ToString(), ", TailNode: ", evtArgs.TailNode.Name.ToString());
            else if (evtArgs.HeadNode != null && evtArgs.TailNode == null)
                AddToLog(evtArgs.Connector.Name.ToString(), " StartLabelEdit event  was fired. [OldLabelValue: ", evtArgs.OldLabelValue.ToString(), ", HeadNode: ", evtArgs.HeadNode.Name.ToString());
            else if (evtArgs.HeadNode == null && evtArgs.TailNode == null)
                AddToLog(evtArgs.Connector.Name.ToString(), " StartLabelEdit event  was fired. [OldLabelValue: ", evtArgs.OldLabelValue.ToString());
        }

        //Add to log when the ConnectorClick event of LineConnector is fired
        void diagramView1_ConnectorClick(object sender, ConnectorRoutedEventArgs evtArgs)
        {
            AddToLog("", "Connector Clicked");
        }

        //Add to log when the AfterConnectionCreate event of LineConnector is fired
        void diagramView1_AfterConnectionCreate(object sender, ConnDragEndRoutedEventArgs evtArgs)
        {
            AddToLog(evtArgs.Connector.Name.ToString(), "After Connection Create");
        }

        //Add to log when the BeforeConnectionCreate event of LineConnector is fired
        void diagramView1_BeforeConnectionCreate(object sender, BeforeCreateConnectionRoutedEventArgs evtArgs)
        {
            AddToLog(evtArgs.Connector.Name.ToString(), "Before Connection Create");
        }

        //Add to log when the ConnectorUnSelected event of LineConnector is fired
        void diagramView1_ConnectorUnSelected(object sender, ConnectorRoutedEventArgs evtArgs)
        {
            this.lcselected.IsChecked = false;
            Arc_Height.IsEnabled = false;
            Arc_Direction.IsEnabled = false;
            AddToLog(evtArgs.Connector.Name.ToString(), "Connector Is UnSelected");
            AddToLog("Number Of Items in Selection List:", diagramView1.SelectionList.Count.ToString());

            LineStyleExpander.ToolTip = "Select a LineConnector";
            LabelExpander.ToolTip = "Select a LineConnector";
            OthersExpander.ToolTip = "Select a LineConnector";
        }


        public bool IsLineLoaded;


        //Add to log when the BConnectorSelected event of LineConnector is fired
        void diagramView1_ConnectorSelected(object sender, ConnectorRoutedEventArgs evtArgs)
        {
            LineConnector l = new LineConnector();
            if(evtArgs.Connector.IsLoaded)
            {
                if (diagramView1.SelectionList.Count > 1)
                {
                    foreach (object o in diagramView1.SelectionList)
                    {
                        if (o is LineConnector)
                        {
                            l = o as LineConnector;
                            UpdateProperties(l);
                            break;
                        }
                    }
                }
                else
                {
                    foreach (LineConnector line in diagramModel1.Connections)
                        if (line.IsSelected)
                        {
                            UpdateProperties(line);
                            break;
                        }
                }
                this.lcselected.IsChecked = true;
                if(l.ConnectorType == ConnectorType.Arc)
                {
                    Arc_Height.IsEnabled = false;
                    Arc_Direction.IsEnabled = false;
                }

                AddToLog(evtArgs.Connector.Name.ToString(), "Connector Is Selected");
                AddToLog("Number Of Items in Selection List:", diagramView1.SelectionList.Count.ToString());

                LineStyleExpander.ToolTip = new ToolTip() { Visibility = Visibility.Collapsed };
                LabelExpander.ToolTip = new ToolTip() { Visibility = Visibility.Collapsed };
                OthersExpander.ToolTip = new ToolTip() { Visibility = Visibility.Collapsed };
            }
        }

        public void AddToLog(string prop, string oldvalue, string newvalue)
        {
            Label tt = new Label();
            tt.FontSize = 12;
            tt.Content = prop + oldvalue + newvalue + "]";
            disArea.Children.Add(tt);
            Scroll.ScrollToBottom();
        }
        public void AddToLog(string prop, string str, string oldvalue, string str2, string str3)
        {
            Label tt = new Label();
            tt.FontSize = 12;
            tt.Content = prop + str + oldvalue + str2 + str3 + "]";
            disArea.Children.Add(tt);
            Scroll.ScrollToBottom();
        }
        public void AddToLog(string prop, string str, string oldvalue, string str2, string str3, string str4)
        {
            Label tt = new Label();
            tt.FontSize = 12;
            tt.Content = prop + str + oldvalue + str2 + str3 + str4 + "]";
            disArea.Children.Add(tt);
            Scroll.ScrollToBottom();
        }
        public void AddToLog(string prop, string str, string oldvalue, string str2, string str3, string str4, string str5)
        {
            Label tt = new Label();
            tt.FontSize = 12;
            tt.Content = prop + str + oldvalue + str2 + str3 + str4 + str5 + "]";
            disArea.Children.Add(tt);
            Scroll.ScrollToBottom();
        }
        public void AddToLog(string prop, string str, string oldvalue, string str2, string str3, string str4, string str5, string str6, string str7)
        {
            Label tt = new Label();
            tt.FontSize = 12;
            tt.Content = prop + str + oldvalue + str2 + str3 + str4 + str5 + str6 + str7 + "]";
            disArea.Children.Add(tt);
            Scroll.ScrollToBottom();
        }
        public void AddToLog(string prop, string str)
        {
            Label tt = new Label();
            tt.FontSize = 12;
            tt.Content = prop + str;
            disArea.Children.Add(tt);
            Scroll.ScrollToBottom();
        }
        #endregion

        #region Helper methods

        //Craeting and applying Style to the LineConector
        private void LoadConnectors()
        {   
            LineConnector l1 = new LineConnector();
            l1.Label = "Orthogonal";
            l1.ConnectorType = ConnectorType.Orthogonal;
            l1.StartPointPosition = new Point(150, 200);
            l1.EndPointPosition = new Point(200, 300);
            l1.LabelFontStyle = FontStyles.Italic;
            diagramModel1.Connections.Add(l1);
            LineConnector l2 = new LineConnector();
            l2.Label = "Straight";
            l2.ConnectorType = ConnectorType.Straight;
            l2.StartPointPosition = new Point(350, 200);
            l2.EndPointPosition = new Point(400, 300);
            l2.LabelFontStyle = FontStyles.Oblique;
            diagramModel1.Connections.Add(l2);
            LineConnector l3 = new LineConnector();
            l3.Label = "Bezier";
            l3.ConnectorType = ConnectorType.Bezier;
            l3.StartPointPosition = new Point(500, 200);
            l3.EndPointPosition = new Point(550, 300);
            l3.LabelFontStyle = FontStyles.Oblique;
            diagramModel1.Connections.Add(l3);
            LineConnector l4 = new LineConnector();
            l4.Label = "Arc";
            l4.ConnectorType = ConnectorType.Arc;
            l4.StartPointPosition = new Point(650, 200);
            l4.EndPointPosition = new Point(700, 300);
            l4.LabelFontSize = 20;
            diagramModel1.Connections.Add(l4);
            l1.LineStyle.StrokeDashArray = DoubleCollection.Parse("2,2");
            l1.LineStyle.StrokeThickness = 3;
            l2.LineStyle.StrokeDashArray = DoubleCollection.Parse("3,5");
            l2.LineStyle.StrokeThickness = 4;
            l3.LineStyle.StrokeDashArray = DoubleCollection.Parse("1,0");
            l3.LineStyle.StrokeThickness = 2;
            l4.LineStyle.StrokeDashArray = DoubleCollection.Parse("2.5,1");
            l4.LineStyle.StrokeThickness = 5;
            l4.HeadDecoratorShape = DecoratorShape.Custom;
            System.Windows.Shapes.Path pa2 = new System.Windows.Shapes.Path();
            pa2.Data = Geometry.Parse("M 9,2 11,7 17,7 12,10 14,15 9,12 4,15 6,10 1,7 7,7 Z");
            l4.HeadDecoratorStyle = new DecoratorStyle() { Fill = Brushes.Gray, Data = pa2.Data, Stroke = Brushes.Gray, Height = 15, Width = 15 };
            l4.TailDecoratorShape = DecoratorShape.Custom;
            System.Windows.Shapes.Path pa3 = new System.Windows.Shapes.Path();
            pa3.Data = Geometry.Parse("M160.329212944922,-3.01862318403769L-2.5,130.5 -5.00506481618589,311.336343115124 163.335290725089,448.012415349887 436.888368720338,448.012420654297 593,309 591.5,133.5 429.5,-1.5z");
            l4.TailDecoratorStyle = new DecoratorStyle() { Fill = Brushes.Gray, Data = pa3.Data, Stroke = Brushes.Gray, Height = 15, Width = 15 };
            l5.LineStyle.StrokeDashArray = DoubleCollection.Parse("2,1");
            l5.LineStyle.StrokeThickness = 3;
            l5.LabelTemplate = (DataTemplate)LineConnectorDemo_2010.App.Current.Resources["labelTemplate1"];
        }

        //Upadte the Connector Properties
        private void UpdateProperties(LineConnector l)
        {
            this.lcStrokeThickness.Text = l.LineStyle.StrokeThickness.ToString();
            if (l.LineStyle.StrokeDashArray != null)
            {
                this.lcStrokeDashArray.Text = l.LineStyle.StrokeDashArray.ToString();
            }
            else
            {
                this.lcStrokeDashArray.Text = "1, 0";
            }

            this.lclabel.Text = l.Label;
            this.lclabeledit.IsChecked = l.IsLabelEditable;
            this.lcenablemultilinelabel.IsChecked = l.EnableMultilineLabel;
            this.lclblhoralign.SelectedItem = l.LabelHorizontalAlignment.ToString();
            if (l.LabelVisibility == System.Windows.Visibility.Visible)
            {
                this.lcLabelVisibility.IsChecked = true;
            }
            else
            {
                this.lcLabelVisibility.IsChecked = false;
            }
            this.lclbltextwrap.SelectedItem = l.LabelTextWrapping.ToString();
            this.lclblwidth.Text = l.LabelWidth.ToString();
            this.lcfontsize.Text = l.LabelFontSize.ToString();
            this.lcfontweight.SelectedItem = l.LabelFontWeight.ToString();
            //this.ShapeStrokeColor1.Color = l.LabelForeground;
            this.lcfontStyle.SelectedItem = l.LabelFontStyle.ToString();
            this.lcfontfamily.SelectedItem = l.LabelFontFamily;
            this.lctriming.SelectedItem = l.LabelTextTrimming.ToString();
            this.lclabeltextalignment.SelectedItem = l.LabelTextAlignment.ToString();
            this.lctlblhoralign.SelectedItem = l.LabelTemplateHorizontalAlignment.ToString();

            this.ctcombo.SelectedItem = l.ConnectorType.ToString();
            this.HeadDecoratorshape.SelectedItem = l.HeadDecoratorShape.ToString();
            this.TailDecoratorshape.SelectedItem = l.TailDecoratorShape.ToString();
            this.lcstartpoint.Text = l.StartPointPosition.ToString();
            this.lcendpoint.Text = l.EndPointPosition.ToString();
            this.LineBridgeenabled.IsChecked = l.LineBridgingEnabled;
            this.IsDecoratorVisible.IsChecked = l.IsDecoratorVisible;
            this.IsDecoratorMovable.IsChecked = l.IsDecoratorMovable;
            this.lclinecornerradius.Text = l.LineCornerRadius.ToString();
            this.lcconnectionendspace.Text = l.ConnectionEndSpace.ToString();
            this.archeight.Text = l.ArcHeight.ToString();
            this.arcdirection.SelectedItem = l.ArcDirection.ToString();
        }

        //Enumertaor for itrating the values
        public List<string> getEumerations(Type obj)
        {
            Array enumValArray = Enum.GetValues(obj);
            List<string> typepropInfoList = new List<string>(enumValArray.Length);
            foreach (int val in enumValArray)
            {
                typepropInfoList.Add(Enum.Parse(obj, val.ToString()).ToString());
            }
            return typepropInfoList;
        }

        //save the Diagram
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            diagramControl1.Save();
        }

        //Load the Diagram
        private void Load_Click(object sender, RoutedEventArgs e)
        {
            diagramControl1.Load();
        }
        #endregion

        #region Customization of LineConnector

        #region Customization of DecortorShapeProperty

        //Enable /Disable the TailDecoratorstyle property of the LineCOnnector
        private void HeadDecoratorshape_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TypeConverter tc = TypeDescriptor.GetConverter(typeof(DecoratorShape));

            foreach (object obj in diagramView1.SelectionList)
            {
                if (obj is LineConnector)
                {
                    (obj as LineConnector).HeadDecoratorShape = (DecoratorShape)tc.ConvertFromString(HeadDecoratorshape.SelectedValue.ToString());
                    if (HeadDecoratorshape.SelectedValue.ToString().Equals("Custom"))
                    {
                        this.HeadDecoratorstyle.IsEnabled = true;
                    }
                    else
                    {
                        this.HeadDecoratorstyle.IsEnabled = false;
                    }
                }
            }
        }

        //Enable /Disable the TailDecoratorstyle property of the LineCOnnector
        private void TailDecoratorshape_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TypeConverter tc = TypeDescriptor.GetConverter(typeof(DecoratorShape));

            foreach (object obj in diagramView1.SelectionList)
            {
                if (obj is LineConnector)
                {
                    (obj as LineConnector).TailDecoratorShape = (DecoratorShape)tc.ConvertFromString(TailDecoratorshape.SelectedValue.ToString());
                    if (TailDecoratorshape.SelectedValue.ToString().Equals("Custom"))
                    {
                        this.TailDecoratorstyle.IsEnabled = true;
                    }
                    else
                    {
                        this.TailDecoratorstyle.IsEnabled = false;
                    }
                }
            }
        }

        /// <summary>
        /// Change the DecoratorShape of the LineConnector,it will affects the Decoratorshape in Tail position using TailDecoratorShape propety
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TailDecoratorstyle_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (TailDecoratorstyle.SelectedIndex)
            {
                case 0:
                    foreach (object obj in diagramView1.SelectionList)
                    {
                        if (obj is LineConnector)
                        {
                            (obj as LineConnector).TailDecoratorShape = DecoratorShape.Custom;
                            (obj as LineConnector).CustomTailDecoratorStyle = App.Current.Resources["TDeco1"] as Style;
                        }
                    }
                    break;
                case 1:
                    foreach (object obj in diagramView1.SelectionList)
                    {
                        if (obj is LineConnector)
                        {
                            (obj as LineConnector).TailDecoratorShape = DecoratorShape.Custom;
                            (obj as LineConnector).CustomTailDecoratorStyle = App.Current.Resources["TDeco2"] as Style;
                        }
                    }
                    break;
                case 2:
                    foreach (object obj in diagramView1.SelectionList)
                    {
                        if (obj is LineConnector)
                        {
                            (obj as LineConnector).TailDecoratorShape = DecoratorShape.Custom;
                            (obj as LineConnector).CustomTailDecoratorStyle = App.Current.Resources["TDeco3"] as Style;
                        }
                    }
                    break;
                case 3:
                    if (diagramView1 != null)
                    {
                        foreach (object obj in diagramView1.SelectionList)
                        {
                            if (obj is LineConnector)
                            {
                                (obj as LineConnector).TailDecoratorShape = DecoratorShape.Arrow;
                                (obj as LineConnector).CustomTailDecoratorStyle = App.Current.Resources["TDeco4"] as Style;
                            }
                        }
                    }
                    break;
            }
        }

        /// <summary>
        /// Change the DecoratorShape of the LineConnector,it will affects the Decoratorshape in Head position using HeadDecoratorShape property
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HeadDecoratorstyle_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (HeadDecoratorstyle.SelectedIndex)
            {
                case 0:
                    foreach (object obj in diagramView1.SelectionList)
                    {
                        if (obj is LineConnector)
                        {
                            (obj as LineConnector).HeadDecoratorShape = DecoratorShape.Custom;
                            (obj as LineConnector).CustomHeadDecoratorStyle = App.Current.Resources["Deco1"] as Style;
                        }
                    }
                    break;
                case 1:
                    foreach (object obj in diagramView1.SelectionList)
                    {
                        if (obj is LineConnector)
                        {
                            (obj as LineConnector).HeadDecoratorShape = DecoratorShape.Custom;
                            (obj as LineConnector).CustomHeadDecoratorStyle = App.Current.Resources["Deco2"] as Style;
                        }
                    }
                    break;
                case 2:
                    foreach (object obj in diagramView1.SelectionList)
                    {
                        if (obj is LineConnector)
                        {
                            (obj as LineConnector).HeadDecoratorShape = DecoratorShape.Custom;
                            (obj as LineConnector).CustomHeadDecoratorStyle = App.Current.Resources["Deco3"] as Style;
                        }
                    }
                    break;
                case 3:
                    if (diagramView1 != null)
                    {
                        foreach (object obj in diagramView1.SelectionList)
                        {
                            if (obj is LineConnector)
                            {
                                (obj as LineConnector).HeadDecoratorShape = DecoratorShape.None;
                                (obj as LineConnector).CustomHeadDecoratorStyle = App.Current.Resources["Deco4"] as Style;
                            }
                        }
                    }
                    break;
            }
        }

        /// <summary>
        /// Change the DecoratorAdornerStyle of the LineCOnnector
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void decratoradorner_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (decratoradorner.SelectedIndex)
            {
                case 0:
                    foreach (object obj in diagramView1.SelectionList)
                    {
                        if (obj is LineConnector)
                        {
                            (obj as LineConnector).DecoratorAdornerStyle = App.Current.Resources["decrator1"] as Style;
                        }
                    }
                    break;
                case 1:
                    foreach (object obj in diagramView1.SelectionList)
                    {
                        if (obj is LineConnector)
                        {
                            (obj as LineConnector).DecoratorAdornerStyle = App.Current.Resources["decrator2"] as Style;
                        }
                    }
                    break;
                case 2:
                    foreach (object obj in diagramView1.SelectionList)
                    {
                        if (obj is LineConnector)
                        {
                            (obj as LineConnector).DecoratorAdornerStyle = App.Current.Resources["decrator3"] as Style;
                        }
                    }
                    break;
                case 3:
                    if (diagramView1 != null)
                    {
                        foreach (object obj in diagramView1.SelectionList)
                        {
                            if (obj is LineConnector)
                            {
                                (obj as LineConnector).DecoratorAdornerStyle = App.Current.Resources["decrator4"] as Style;
                            }
                        }
                    }
                    break;
            }
        }

        //Enable/Disable the IsDecoratorVisible property of the LineConnector
        private void IsDecoratorVisible_Click(object sender, RoutedEventArgs e)
        {
            if (IsDecoratorVisible.IsChecked == true)
            {
                foreach (Object n in diagramView1.SelectionList)
                {
                    if (n is LineConnector)
                    {
                        (n as LineConnector).IsDecoratorVisible = true;
                        IsDecoratorVisible.ToolTip = "Disable DecoratorVisiblity";
                    }
                }
            }

            else
            {
                foreach (Object n in diagramView1.SelectionList)
                {
                    if (n is LineConnector)
                    {
                        (n as LineConnector).IsDecoratorVisible = false;
                        IsDecoratorVisible.ToolTip = "Enable DecoratorVisiblity";
                    }
                }
            }
        }

        //Enable/Disable the IsDecoratorMovable property of the LineConnector
        private void IsDecoratorMovable_Click(object sender, RoutedEventArgs e)
        {
            if (IsDecoratorMovable.IsChecked == true)
            {
                foreach (Object n in diagramView1.SelectionList)
                {
                    if (n is LineConnector)
                    {
                        (n as LineConnector).IsDecoratorMovable = true;
                        IsDecoratorMovable.ToolTip = "Disable DecoratorMove";
                    }
                }
            }

            else
            {
                foreach (Object n in diagramView1.SelectionList)
                {
                    if (n is LineConnector)
                    {
                        (n as LineConnector).IsDecoratorMovable = false;
                        IsDecoratorMovable.ToolTip = "Enable DecoratorMove";
                    }
                }
            }
        }
        #endregion

        #region LineBridging Property

        //Enable/Disable the LineBridgingEnabled of the lineconnector
        private void LineBridgeenabled_Click(object sender, RoutedEventArgs e)
        {
            if (LineBridgeenabled.IsChecked == true)
            {
                foreach (Object n in diagramView1.SelectionList)
                {
                    if (n is LineConnector)
                    {
                        (n as LineConnector).LineBridgingEnabled = true;
                        LineBridgeenabled.ToolTip = "Disable LineBridging";
                    }
                }
            }

            else
            {
                foreach (Object n in diagramView1.SelectionList)
                {
                    if (n is LineConnector)
                    {
                        (n as LineConnector).LineBridgingEnabled = false;
                        LineBridgeenabled.ToolTip = "Enable LineBridging";
                    }
                }
            }
        }
        #endregion

        #region Customization of Label Proeprty

        //Enable/Disable the LineBridging
        private void LineBridgeenabled1_Click(object sender, RoutedEventArgs e)
        {
            if (LineBridgeenabled1.IsChecked == true)
            {
                diagramView1.LineBridgingEnabled = true;
                LineBridgeenabled1.ToolTip = "Disable LineBridging";
            }

            else
            {
                diagramView1.LineBridgingEnabled = false;
                LineBridgeenabled1.ToolTip = "Enable LineBridging";
            }
        }

        //HorizontalAlignment property  of the Label of teh lineconnetor
        private void lclblhoralign_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TypeConverter tc = TypeDescriptor.GetConverter(typeof(HorizontalAlignment));
            foreach (object o in diagramView1.SelectionList)
            {
                if (o is LineConnector)
                {
                    (o as LineConnector).LabelHorizontalAlignment = (HorizontalAlignment)tc.ConvertFromString(lclblhoralign.SelectedValue.ToString());
                }
            }
        }

        //TextWrapping property  of the Label of teh lineconnetor
        private void lclbltextwrap_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TypeConverter tc = TypeDescriptor.GetConverter(typeof(TextWrapping));
            foreach (object o in diagramView1.SelectionList)
            {
                if (o is LineConnector)
                {
                    (o as LineConnector).LabelTextWrapping = (TextWrapping)tc.ConvertFromString(lclbltextwrap.SelectedValue.ToString());
                }
            }
        }

        //LabelWidth property  of teh lineconnetor
        private void lclblwidth_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                foreach (object o in diagramView1.SelectionList)
                {
                    if (o is LineConnector)
                    {
                        (o as LineConnector).LabelWidth = Double.Parse(lclblwidth.Text);
                    }
                }
            }
            catch
            {
            }
        }

        //FontSize property  of the Label of teh lineconnetor
        private void lcfontsize_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                foreach (object o in diagramView1.SelectionList)
                {
                    if (o is LineConnector)
                    {
                        (o as LineConnector).LabelFontSize = Double.Parse(lcfontsize.Text);
                    }
                }
            }
            catch
            {
            }
        }

        //FontStyle property  of the Label of teh lineconnetor
        private void lcfontStyle_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TypeConverter tc = TypeDescriptor.GetConverter(typeof(FontStyle));
            foreach (object o in diagramView1.SelectionList)
            {
                if (o is LineConnector)
                {
                    (o as LineConnector).LabelFontStyle = (FontStyle)tc.ConvertFromString(lcfontStyle.SelectedValue.ToString());
                }
            }
        }

        //TextTrimming property  of the Label of teh lineconnetor
        private void lctriming_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TypeConverter tc = TypeDescriptor.GetConverter(typeof(TextTrimming));
            foreach (object o in diagramView1.SelectionList)
            {
                if (o is LineConnector)
                {
                    (o as LineConnector).LabelTextTrimming = (TextTrimming)tc.ConvertFromString(lctriming.SelectedValue.ToString());
                }
            }
        }

        //Change the Template of teh Label 
        private void lbltemplate_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (lbltemplate.SelectedIndex)
            {
                case 0:
                    foreach (object obj in diagramView1.SelectionList)
                    {
                        if (obj is LineConnector)
                        {
                            (obj as LineConnector).LabelTemplate = (DataTemplate)LineConnectorDemo_2010.App.Current.Resources["labelTemplate1"];
                        }
                    }
                    break;
                case 1:
                    foreach (object obj in diagramView1.SelectionList)
                    {
                        if (obj is LineConnector)
                        {
                            (obj as LineConnector).LabelTemplate = (DataTemplate)LineConnectorDemo_2010.App.Current.Resources["labelTemplate2"];
                        }
                    }
                    break;
                case 2:
                    foreach (object obj in diagramView1.SelectionList)
                    {
                        if (obj is LineConnector)
                        {
                            (obj as LineConnector).LabelTemplate = (DataTemplate)LineConnectorDemo_2010.App.Current.Resources["labelTemplate3"];
                        }
                    }
                    break;
                case 3:
                    if (diagramView1 != null)
                    {
                        foreach (object obj in diagramView1.SelectionList)
                        {
                            if (obj is LineConnector)
                            {
                                (obj as LineConnector).LabelTemplate = null;
                            }
                        }
                    }
                    break;
            }
        }

        //Change the Alignemnt of the LabelTemplate
        private void lctlblhoralign_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TypeConverter tc = TypeDescriptor.GetConverter(typeof(HorizontalAlignment));
            foreach (object o in diagramView1.SelectionList)
            {
                if (o is LineConnector)
                {
                    (o as LineConnector).LabelTemplateHorizontalAlignment = (HorizontalAlignment)tc.ConvertFromString(lctlblhoralign.SelectedValue.ToString());
                    (o as LineConnector).UpdateConnectorPathGeometry();
                }
            }
        }

        //Change the TextDecorations of the Label
        private void lclabeltextdecorations_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TypeConverter tc = TypeDescriptor.GetConverter(typeof(TextDecorationCollection));
            foreach (object o in diagramView1.SelectionList)
            {
                if (o is LineConnector)
                {
                    (o as LineConnector).LabelTextDecorations = (TextDecorationCollection)tc.ConvertFromString(lclabeltextdecorations.SelectedValue.ToString());
                }
            }
        }
        //Change the Textalignment of the Label
        private void lclabeltextalignment_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TypeConverter tc = TypeDescriptor.GetConverter(typeof(TextAlignment));
            foreach (object o in diagramView1.SelectionList)
            {
                if (o is LineConnector)
                {
                    (o as LineConnector).LabelTextAlignment = (TextAlignment)tc.ConvertFromString(lclabeltextalignment.SelectedValue.ToString());
                }
            }
        }

        //Change the LabelVisibility property of the LineConnector
        private void lcvisibilitychanged(object sender, RoutedEventArgs e)
        {
            if (lcLabelVisibility.IsChecked == true)
            {
                foreach (object o in diagramView1.SelectionList)
                {
                    if (o is LineConnector)
                    {
                        (o as LineConnector).LabelVisibility = System.Windows.Visibility.Visible;
                        lcLabelVisibility.ToolTip = "Collapsed";
                    }
                }
            }

            else
            {
                foreach (object o in diagramView1.SelectionList)
                {
                    if (o is LineConnector)
                    {
                        (o as LineConnector).LabelVisibility = System.Windows.Visibility.Collapsed;
                        lcLabelVisibility.ToolTip = "Visible";
                    }
                }
            }
        }

        //Editing the Label of the LineCOnnector
        private void lclabelchnaged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (lclabeledit.IsChecked == true)
                {
                    if (lclabel != null)
                    {
                        if (lclabel.Text != "")
                        {
                            foreach (LineConnector n in diagramView1.SelectionList)
                            {
                                n.Label = lclabel.Text;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        //Enable/Disable the IsLabelEditable property of the LineConnector
        private void lclabeleditclick(object sender, RoutedEventArgs e)
        {
            if (lclabeledit.IsChecked == true)
            {
                foreach (object o in diagramView1.SelectionList)
                {
                    if (o is LineConnector)
                    {
                        (o as LineConnector).IsLabelEditable = true;
                        lclabel.IsEnabled = true;
                        lclabeledit.ToolTip = "Disable LabelEditing";
                    }
                }
            }

            else
            {
                foreach (object o in diagramView1.SelectionList)
                {
                    if (o is LineConnector)
                    {
                        (o as LineConnector).IsLabelEditable = false;
                        lclabel.IsEnabled = false;
                        lclabeledit.ToolTip = "Enable LabelEditing";
                    }
                }
            }
        }

        //Enable/Disable the EnableMultilineLabel property of the LineConnector
        private void lcenablemultiline_click(object sender, RoutedEventArgs e)
        {
            if (lcenablemultilinelabel.IsChecked == true)
            {
                foreach (object o in diagramView1.SelectionList)
                {
                    if (o is LineConnector)
                    {
                        (o as LineConnector).EnableMultilineLabel = true;
                        lcenablemultilinelabel.ToolTip = "Disable MultiLineLable";
                    }
                }
            }

            else
            {
                foreach (object o in diagramView1.SelectionList)
                {
                    if (o is LineConnector)
                    {
                        (o as LineConnector).EnableMultilineLabel = false;
                        lcenablemultilinelabel.ToolTip = "Enable MultiLineLable";
                    }
                }
            }
        }

        //Chaging the FontWeight of the Label
        private void lcfontweight_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TypeConverter tc = TypeDescriptor.GetConverter(typeof(FontWeight));
            foreach (object o in diagramView1.SelectionList)
            {
                if (o is LineConnector)
                {
                    (o as LineConnector).LabelFontWeight = (FontWeight)tc.ConvertFromString(lcfontweight.SelectedValue.ToString());
                }
            }
        }

        //Chaging the Font of the Label
        private void lcfontfamily_FontsSourceChanged(object sender, SelectionChangedEventArgs e)
        {
            if (diagramView1 != null)
            {
                TypeConverter tc = TypeDescriptor.GetConverter(typeof(FontFamily));
                foreach (object o in diagramView1.SelectionList)
                {
                    if (o is LineConnector)
                    {
                        (o as LineConnector).LabelFontFamily = (FontFamily)tc.ConvertFromString(lcfontfamily.SelectedValue.ToString());
                    }
                }
            }
        }
        //Chaging the Color of the Label
        private void ShapeStrokeColor1_ColorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                BrushConverter brushConverter = new BrushConverter();
                foreach (Object o in diagramView1.SelectionList)
                {
                    if (o is LineConnector)
                    {
                        (o as LineConnector).LabelForeground = brushConverter.ConvertFromString(e.NewValue.ToString()) as SolidColorBrush;
                    }
                }
            }
            catch
            {
            }
        }

        #endregion

        #region BasicProperty of LineConnector

        //Selecting the Connector type
        private void ctcombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TypeConverter tc1 = TypeDescriptor.GetConverter(typeof(ConnectorType));
            ConnectorType t = (ConnectorType)tc1.ConvertFromString(ctcombo.SelectedValue.ToString());
            if (diagramView1.SelectionList.Count < 1 && IsLineLoaded==false)
            {
                ((this.diagramView1.Page) as DiagramPage).ConnectorType = (ConnectorType)tc1.ConvertFromString(ctcombo.SelectedValue.ToString());
                this.diagramView1.EnableConnection = true;
            }
            else
            {
                foreach (object o in diagramView1.SelectionList)
                {
                    if (o is LineConnector)
                    {
                        (o as LineConnector).ConnectorType = (ConnectorType)tc1.ConvertFromString(ctcombo.SelectedValue.ToString());
                        (o as LineConnector).UpdateConnectorPathGeometry();
                    }
                }
            }

            if (t == ConnectorType.Arc)
            {
                Arc_Height.IsEnabled = true;
                Arc_Direction.IsEnabled = true;
            }
            else
            {
                Arc_Height.IsEnabled = false;
                Arc_Direction.IsEnabled = false;
            }
            IsLineLoaded = false;
        }
        /// <summary>
        /// Change the ArcHeight property of the LineConnector
        /// </summary>
        /// <param name="sender"></param>
        private void archeight_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (archeight != null)
                {
                    if (archeight.Text != "")
                    {
                        foreach (LineConnector n in diagramView1.SelectionList)
                        {
                            n.ArcHeight = Double.Parse(archeight.Text);
                            n.UpdateConnectorPathGeometry();
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// Change the ArcDirection property of the LineConnector
        /// </summary>
        /// <param name="sender"></param>
        private void arcdirection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TypeConverter tc2 = TypeDescriptor.GetConverter(typeof(SweepDirection));
            foreach (object o in diagramView1.SelectionList)
            {
                if (o is LineConnector)
                {
                    (o as LineConnector).ArcDirection = (SweepDirection)tc2.ConvertFromString(arcdirection.SelectedValue.ToString());
                    (o as LineConnector).UpdateConnectorPathGeometry();
                }
            }
        }


        /// <summary>
        /// Change the StartPointPosition property of the LineConnector,it change the poistion of thr lineconnector
        /// </summary>
        /// <param name="sender"></param>
        private void lcstartpoint_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (lcstartpoint != null)
                {
                    if (lcstartpoint.Text != "")
                    {
                        foreach (LineConnector n in diagramView1.SelectionList)
                        {
                            n.StartPointPosition = Point.Parse(lcstartpoint.Text);
                            n.UpdateConnectorPathGeometry();
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// Change the EndPointPosition property of the LineConnector,it change the poistion of thr lineconnector
        /// </summary>
        /// <param name="sender"></param>

        private void lcendpoint_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (lcendpoint != null)
                {
                    if (lcendpoint.Text != "")
                    {
                        foreach (LineConnector n in diagramView1.SelectionList)
                        {
                            n.EndPointPosition = Point.Parse(lcendpoint.Text);
                            n.UpdateConnectorPathGeometry();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        /// <summary>
        /// Change the LineCornerRadius property of the LineConnector,it change the each corner of the LineConnector as Arc shaped
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lclinecornerradius_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (lclinecornerradius != null)
                {
                    if (lclinecornerradius.Text != "")
                    {
                        foreach (LineConnector n in diagramView1.SelectionList)
                        {
                            n.LineCornerRadius = Double.Parse(lclinecornerradius.Text);
                            n.UpdateConnectorPathGeometry();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        /// <summary>
        /// Change the ConnectionEndSpace property of the LineConnector,it chages the distance between teh Node and the LineConnector(connected)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lcconnectionendspace_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (lcconnectionendspace != null)
                {
                    if (lcconnectionendspace.Text != "")
                    {
                        foreach (LineConnector n in diagramView1.SelectionList)
                        {
                            n.ConnectionEndSpace = Double.Parse(lcconnectionendspace.Text);
                            n.UpdateConnectorPathGeometry();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        //Enable/Disable the IsSelected property of the LineConnector
        private void lcselectedchanged(object sender, RoutedEventArgs e)
        {
            if (lcselected.IsChecked == true)
            {
                for (int i = 0; i < diagramView1.SelectionList.Count; ++i)
                {
                    if (diagramView1.SelectionList[i] is LineConnector)
                    {
                        (diagramView1.SelectionList[i] as LineConnector).IsSelected = true;
                        lcselected.ToolTip = "Un Selected";
                    }
                }
            }

            else
            {
                for (int i = 0; i < diagramView1.SelectionList.Count; ++i)
                {
                    if (diagramView1.SelectionList[i] is LineConnector)
                    {
                        (diagramView1.SelectionList[i] as LineConnector).IsSelected = false;
                        lcselected.ToolTip = "Selected";
                    }
                }
            }
        }

        //Change the Stroke property  of the LineCOnnector using LineStyle
        private void ShapeStrokeColor_ColorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                BrushConverter brushConverter = new BrushConverter();
                foreach (Object o in diagramView1.SelectionList)
                {
                    if (o is LineConnector)
                    {
                        (o as LineConnector).LineStyle.Stroke = brushConverter.ConvertFromString(e.NewValue.ToString()) as SolidColorBrush;
                    }
                }
            }
            catch
            {
            }
        }

        //Change the StrokeThickness property  of the LineCOnnector using LineStyle
        private void lcStrokeThickness_changed(object sender, TextChangedEventArgs e)
        {
            try
            {
                foreach (object o in diagramView1.SelectionList)
                {
                    if (o is LineConnector)
                    {
                        (o as LineConnector).LineStyle.StrokeThickness = Double.Parse(lcStrokeThickness.Text);
                    }
                }
            }
            catch
            {
            }
        }

        //Change the StrokeDashArray property  of the LineCOnnector using LineStyle
        private void lcStrokeDashArray_changed(object sender, TextChangedEventArgs e)
        {
            try
            {
                foreach (object o in diagramView1.SelectionList)
                {
                    if (o is LineConnector)
                    {
                        (o as LineConnector).LineStyle.StrokeDashArray = DoubleCollection.Parse(lcStrokeDashArray.Text);
                    }
                }
            }
            catch
            {
            }
        }
        #endregion
        #endregion

    }
}