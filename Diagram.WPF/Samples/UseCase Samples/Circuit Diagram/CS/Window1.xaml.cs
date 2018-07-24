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

namespace CircuitDiagram_2008
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>

    public partial class Window1 : Window
    {

        #region Public Variables

        //declaring the Public variables
        SymbolPaletteGroup symbolGroup;
        SymbolPaletteItem symbolItem;
        #endregion

        #region Constructor

        //Window1 Constructor 
        public Window1()
        {
            InitializeComponent();
            diagramControl.IsSymbolPaletteEnabled = true;
            //Loads the custom electrical shapes to the palette
            LoadPalette();
            //Load the Circuit from Xaml
            diagramControl.Load(@"..\..\Circuit.xaml");
            //Register the Event Handlers
            diagramView.AfterConnectionCreate += new ConnDragEndChangedEventHandler(diagramView_AfterConnectionCreate);

            diagramView.NodeDrop += new NodeDroppedEventHandler(diagramView_NodeDrop);
            diagramView.ConnectorDragEnd += new ConnDragEndChangedEventHandler(diagramView_ConnectorDragEnd);
        }

        void diagramView_NodeDrop(object sender, NodeDroppedRoutedEventArgs evtArgs)
        {
            (evtArgs.DroppedNode as Node).LabelHorizontalAlignment = HorizontalAlignment.Center;
            (evtArgs.DroppedNode as Node).LabelVerticalAlignment = VerticalAlignment.Center;
        }

        void diagramView_ConnectorDragEnd(object sender, ConnDragEndRoutedEventArgs evtArgs)
        {
            foreach (Node n in diagramModel.Nodes)
            {
                n.IsDragConnectionOver = false;
            }
        }

        //Event for changing the LineStyle of the Lien/connector
        void diagramView_AfterConnectionCreate(object sender, ConnDragEndRoutedEventArgs evtArgs)
        {
            LineConnector line = evtArgs.Connector;
            line.LineStyle.Stroke = Brushes.Black;
            line.LineStyle.StrokeThickness = 2;
            line.TailDecoratorShape = DecoratorShape.None;
        }

        //Event for changing the LineStyle of the Lien/connector
        void diagramView_BeforeConnectionCreate(object sender, BeforeCreateConnectionRoutedEventArgs evtArgs)
        {
            LineConnector line = evtArgs.Connector;
            line.LineStyle.Stroke = Brushes.Black;
            line.LineStyle.StrokeThickness = 2;
            line.TailDecoratorShape = DecoratorShape.None;
        }

        #endregion

        #region Helper Methods

        /// <summary>
        /// Loads the palette with custom shapes
        /// </summary>
        void LoadPalette()
        {
            //Clear the SymbolPaletteGroups
            diagramControl.SymbolPalette.SymbolGroups.Clear();

            //Clear out the defualt symbolpalettegroups and symbolpalettefilters
            diagramControl.SymbolPalette.SymbolFilters.Remove(diagramControl.SymbolPalette.SymbolFilters[5]);
            diagramControl.SymbolPalette.SymbolFilters.Remove(diagramControl.SymbolPalette.SymbolFilters[4]);
            diagramControl.SymbolPalette.SymbolFilters.Remove(diagramControl.SymbolPalette.SymbolFilters[3]);
            diagramControl.SymbolPalette.SymbolFilters.Remove(diagramControl.SymbolPalette.SymbolFilters[2]);
            diagramControl.SymbolPalette.SymbolFilters.Remove(diagramControl.SymbolPalette.SymbolFilters[1]);
            diagramControl.SymbolPalette.SymbolFilters.Remove(diagramControl.SymbolPalette.SymbolFilters[0]);
            diagramControl.SymbolPalette.ItemPadding = new Thickness(1);

            //SymbolPaletteFilter creates a filter for the palette groups.
            SymbolPaletteFilter sfilter = new SymbolPaletteFilter();
            sfilter.Label = "Electrical Components";
            diagramControl.SymbolPalette.SymbolFilters.Add(sfilter);

            //SymbolPaletteGroup creates a group and assigns a specific filter index.
            symbolGroup = new SymbolPaletteGroup();
            symbolGroup.Label = "Electrical Components";
            SymbolPalette.SetFilterIndexes(symbolGroup, new Int32Collection(new int[] { 0, 6 }));
            diagramControl.SymbolPalette.SymbolGroups.Add(symbolGroup);

            //SymbolPaletteItem specifies the item which can be added to the group.
            SymbolPaletteItem symbolItem1 = addSymbolItem(this.Resources["i1"] as DrawingImage);
            SymbolPaletteItem symbolItem2 = addSymbolItem(this.Resources["Diode"] as DrawingImage);
            SymbolPaletteItem symbolItem3 = addSymbolItem(this.Resources["VerResistor"] as DrawingImage);
            SymbolPaletteItem symbolItem4 = addSymbolItem(this.Resources["HorResistor"] as DrawingImage);
            SymbolPaletteItem symbolItem5 = addSymbolItem(this.Resources["VerCapacitor"] as DrawingImage);
            SymbolPaletteItem symbolItem6 = addSymbolItem(this.Resources["HorCapacitor"] as DrawingImage);
            SymbolPaletteItem symbolItem7 = addSymbolItem(this.Resources["Junction"] as DrawingImage);
            SymbolPaletteItem symbolItem8 = addSymbolItem(this.Resources["Image1"] as DrawingImage);
            SymbolPaletteItem symbolItem9 = addSymbolItem(this.Resources["Battery"] as DrawingImage);
            SymbolPaletteItem symbolItem10 = addSymbolItem(this.Resources["Switch"] as DrawingImage);
            SymbolPaletteItem symbolItem11 = addSymbolItem(this.Resources["Coil"] as DrawingImage);
            SymbolPaletteItem symbolItem12 = addSymbolItem(this.Resources["Image2"] as DrawingImage);
            SymbolPaletteItem symbolItem13 = addSymbolItem(this.Resources["Image3"] as DrawingImage);
            SymbolPaletteItem symbolItem14 = addSymbolItem(this.Resources["Image4"] as DrawingImage);
            SymbolPaletteItem symbolItem15 = addSymbolItem(this.Resources["Image5"] as DrawingImage);
            SymbolPaletteItem symbolItem16 = addSymbolItem(this.Resources["Image6"] as DrawingImage);
            SymbolPaletteItem symbolItem17 = addSymbolItem(this.Resources["Image7"] as DrawingImage);
            SymbolPaletteItem symbolItem18 = addSymbolItem(this.Resources["Image12"] as DrawingImage);
            SymbolPaletteItem symbolItem19 = addSymbolItem(this.Resources["Image9"] as DrawingImage);
            SymbolPaletteItem symbolItem20 = addSymbolItem(this.Resources["Image10"] as DrawingImage);
            SymbolPaletteItem symbolItem21 = addSymbolItem(this.Resources["Image11"] as DrawingImage);
            SymbolPaletteItem symbolItem22 = addSymbolItem(this.Resources["Image13"] as DrawingImage);
            SymbolPaletteItem symbolItem23 = addSymbolItem(this.Resources["Image8"] as DrawingImage);
        }

        // Function set content of the SymbolPalette Item
        private SymbolPaletteItem addSymbolItem(ImageSource imgSource)
        {
            SymbolPaletteItem item = new SymbolPaletteItem();
            Image i = new Image();
            i.Source = imgSource;
            // Setting Content of the SymbolPalette Item
            item.Content = i;
            i.Stretch = Stretch.Fill;
            symbolGroup.Items.Add(item);
            return item;
        }

        #endregion

        #region Event Handlers

        //Saves the Diagrampage
        private void Save_click(object sender, RoutedEventArgs e)
        {
            diagramControl.Save();
        }

        //Loads the Diagrampage
        private void Load_click(object sender, RoutedEventArgs e)
        {
            diagramControl.Load();
        }

        ///<summary>
        ///EnableConnection,IsPageEditable,IsSymbolPaletteEnabled
        ///Description:
        ///Gets or sets a value indicating whether  connection is enabled or not[EnableConnection].
        ///Gets or sets a value indicating whether page is enabled or not.Default value is True[IsPageEditable].
        ///The SymbolPalette can be displayed by setting the IsSymbolPaletteEnabled property to True. 
        ///By default, this property is disabled.
        /// </summary>
        //For Enable/Disable the Proeprties
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox box = (sender as CheckBox);
            if (diagramView != null)
            {
                switch (box.Name)
                {
                    case "EnableConnection":
                        diagramView.EnableConnection = true;
                        EnableConnection.ToolTip = "Disable Connection";
                        Connector.IsEnabled = true;
                        //Connector.SelectedIndex = 2;
                        break;
                    case "SymbolPalette1":
                        diagramControl.IsSymbolPaletteEnabled = true;
                        SymbolPalette1.ToolTip = "HideSymbolPalette";
                        break;
                    case "PageEditable":
                        diagramView.IsPageEditable = true;
                        SymbolPalette1.IsEnabled = true;
                        SymbolPalette1.IsChecked = true;
                        EnableConnection.IsChecked = true;
                        EnableConnection.IsEnabled = true;
                        diagramControl.IsSymbolPaletteEnabled = true;
                        PageEditable.ToolTip = "Disable Editing";
                        break;
                }

            }
        }

        //For Enable/Disable the Proeprties
        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox box = (sender as CheckBox);
            switch (box.Name)
            {
                case "EnableConnection":
                    diagramView.EnableConnection = false;
                    EnableConnection.ToolTip = "Enable Connection";
                    Connector.IsEnabled = false;
                    
                    break;
                case "SymbolPalette1":
                   
                    diagramControl.IsSymbolPaletteEnabled = false;
                    SymbolPalette1.ToolTip = "ShowSymbolPalette";
                    break;
                case "PageEditable":
                    diagramView.IsPageEditable = false;
                    SymbolPalette1.IsEnabled = false;
                    SymbolPalette1.IsChecked = false;
                    EnableConnection.IsChecked = false;
                    EnableConnection.IsEnabled = false;
                    diagramControl.IsSymbolPaletteEnabled = false;
                    PageEditable.ToolTip = "Enabel Editing";
                    break;
            }

        }

        /// <summary>
        /// Connector Type
        /// Descriprtion:
        /// Gets or sets the connector type to be used. 
        /// There are four values namely Orthogonal, Straight, Bezier and Arc can be specified. 
        /// Default Value is Orthogonal.
        /// </summary>
        // For Changing the Connector Types
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox box = (sender as ComboBox);
            if ((bool)EnableConnection.IsChecked)
            {
                diagramView.EnableConnection = true;
                switch (box.SelectedIndex)
                {
                    case 0:
                        //Creates a Arc connection.
                        diagramView.DrawingTool = DrawingTools.Arc;
                        (diagramView.Page as DiagramPage).ConnectorType = ConnectorType.Arc;
                        break;
                    case 1:
                        //Creates a Bezier connection.
                        diagramView.DrawingTool = DrawingTools.BezierLine;
                        (diagramView.Page as DiagramPage).ConnectorType = ConnectorType.Bezier;
                        break;
                    case 2:
                        //Creates a Orthogonal connection.
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
        }
        #endregion

    }
}