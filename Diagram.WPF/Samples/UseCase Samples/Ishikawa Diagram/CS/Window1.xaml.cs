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
using System.Collections.ObjectModel;
using System.Reflection;

namespace IshikawaDiagram_2008
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {

        #region Public Variables

        //Declaring the Public variables
        SymbolPaletteGroup symbolGroup;
        #endregion

        #region Constructor
        public Window1()
        {
            InitializeComponent();
            diagramControl.IsSymbolPaletteEnabled = true;
            //Initalize the SymbolPalette
            LoadPalette();
            CustomizePalette();

            //Loading a pre saved layout
            diagramControl.Load(@"..\..\fishbone.xaml");
            foreach (Node node in diagramModel.Nodes)
            {
                node.PortVisibility = PortVisibility.AlwaysHidden;
            }
            //Regsiter the NodeDrop event
            diagramView.NodeDrop += new NodeDroppedEventHandler(diagramView_NodeDrop);

        }


        //In Node drop event, setting width and height of the dropped node
        void diagramView_NodeDrop(object sender, NodeDroppedRoutedEventArgs evtArgs)
        {
            Node droppednode = evtArgs.DroppedNode as Node;

            if (evtArgs.SymbolPaletteItemName == "NodeId")
            {
                droppednode.Label = "Id";
                droppednode.Height = 25;
                droppednode.Width = 40;
            }
            else if (evtArgs.SymbolPaletteItemName == "Ellipse")
            {
                droppednode.Height = 70;
                droppednode.Width = 175;
                droppednode.LabelWidth = 75;
            }
            else if (evtArgs.SymbolPaletteItemName == "Arrow")
            {
                droppednode.Height = 15;
                droppednode.Width = 200;
            }
        }

        #endregion

        #region Helper Methods

        void CustomizePalette()
        {
            diagramControl.SymbolPalette.ItemWidth = 70;
            diagramControl.SymbolPalette.Width = 100;
            //Remove the SymbolGroups
            diagramControl.SymbolPalette.SymbolGroups.Remove(diagramControl.SymbolPalette.SymbolGroups[4]);
            diagramControl.SymbolPalette.SymbolGroups.Remove(diagramControl.SymbolPalette.SymbolGroups[3]);
            diagramControl.SymbolPalette.SymbolGroups.Remove(diagramControl.SymbolPalette.SymbolGroups[2]);
            diagramControl.SymbolPalette.SymbolGroups.Remove(diagramControl.SymbolPalette.SymbolGroups[0]);
            //Remove the SymbolFilters
            diagramControl.SymbolPalette.SymbolFilters.Remove(diagramControl.SymbolPalette.SymbolFilters[5]);
            diagramControl.SymbolPalette.SymbolFilters.Remove(diagramControl.SymbolPalette.SymbolFilters[4]);
            diagramControl.SymbolPalette.SymbolFilters.Remove(diagramControl.SymbolPalette.SymbolFilters[3]);
            diagramControl.SymbolPalette.SymbolFilters.Remove(diagramControl.SymbolPalette.SymbolFilters[1]);
            diagramControl.SymbolPalette.ItemPadding = new Thickness(5);
        }

        //Adding custom items to the palette
        void LoadPalette()
        {
            //SymbolPaletteFilter creates a filter for the palette groups.
            SymbolPaletteFilter sfilter = new SymbolPaletteFilter();
            sfilter.Label = "Layout Shapes";
            diagramControl.SymbolPalette.SymbolFilters.Add(sfilter);

            //SymbolPaletteGroup creates a group and assigns a specific filter index.
            symbolGroup = new SymbolPaletteGroup();
            symbolGroup.Label = "Layout Shapes";
            SymbolPalette.SetFilterIndexes(symbolGroup, new Int32Collection(new int[] { 0, 6 }));
            diagramControl.SymbolPalette.SymbolGroups.Add(symbolGroup);

            //SymbolPaletteItem specifies the item which can be added to the group.
            SymbolPaletteItem symbolItem1 = addSymbolItem(App.Current.Resources["ellipse"] as Ellipse, "Ellipse", "Ellipse");
            SymbolPaletteItem symbolItem2 = addSymbolItem(App.Current.Resources["roundedrect"] as Path, "Rect", "RoundedRect");
            SymbolPaletteItem symbolItem3 = addSymbolItem(App.Current.Resources["id"] as Path, "NodeId", "NodeId");
            SymbolPaletteItem symbolItem4 = addSymbolItem(App.Current.Resources["Arrow"] as Border, "Arrow", "Arrow");
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

        //Save the Diagram
        private void S_Click(object sender, RoutedEventArgs e)
        {
            diagramControl.Save();
        }

        //Load the Diagram
        private void L_Click(object sender, RoutedEventArgs e)
        {
            diagramControl.Load();
        }

        //Checking for ZoomEnabled Proeprty
        private void Symbol_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox box = (sender as CheckBox);
            if (box != null)
            {
                switch (box.Name)
                {

                    case "PageEditable":
                        diagramView.IsPageEditable = true;
                        if (Zoom != null)
                        {
                            Symbol.IsEnabled = true;
                            Symbol.IsChecked = true;
                            Zoom.IsEnabled = true;
                            Zoom.IsChecked = true;
                            zbut.IsEnabled = true;
                            zobut.IsEnabled = true;
                            reset.IsEnabled = true;
                            Pan.IsEnabled = true;
                        }
                        break;
                    case "Pan":
                        diagramView.IsPanEnabled = true;
                        break;

                }
            }
        }

        //Checking for ZoomEnabled Proeprty
        private void PageEditable_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox box = (sender as CheckBox);
            switch (box.Name)
            {
                case "PageEditable":
                    diagramView.IsPageEditable = false;
                    Symbol.IsChecked = false;
                    Symbol.IsEnabled = false;
                    Zoom.IsChecked = false;
                    Zoom.IsEnabled = false;
                    zbut.IsEnabled = false;
                    zobut.IsEnabled = false;
                    reset.IsEnabled = false;
                    Pan.IsEnabled = false;
                    Pan.IsChecked = false;
                    break;
                case "Pan":
                    diagramView.IsPanEnabled = false;
                    break;
            }

        }
        #endregion

        #region PrivateFunctions

        //Add the new symbolpaletteitem to symbolgroups
        private SymbolPaletteItem addSymbolItem(object content, String name, String tooltip)
        {
            SymbolPaletteItem item = new SymbolPaletteItem();
            item.Background = Brushes.Beige;
            item.Content = content;
            item.Name = name;
            item.ToolTip = tooltip;
            symbolGroup.Items.Add(item);
            return item;
        }
        #endregion

    }
}
