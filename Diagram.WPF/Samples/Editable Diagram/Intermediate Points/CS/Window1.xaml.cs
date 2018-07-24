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
using System.Collections.ObjectModel;
using System.Reflection;
using IntermeditePointsDemo_2008;
using System.Globalization;


namespace IntermediatePointsDemo_2008
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        #region Public Variables

        //Declaring the Public variables
        SymbolPaletteGroup symbolgroup;

        #endregion

        #region Constructor

        public Window1()
        {
            InitializeComponent();
            diagramControl.IsSymbolPaletteEnabled = true;

            //Initalize the Symbolpalette
            LoadPalette();
            CustomizePalette();
            //Initializes the Combobox
            InitializeCombobox();
            //Loading a pre saved layout
            diagramControl.Load(@"..\..\Sample.xaml");
            diagramView.NodeDrop += new NodeDroppedEventHandler(diagramView_NodeDrop);
        }

        //Initializer with the Zoomfactor values
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

            //Remove the SymbolPaletteGroups
            diagramControl.SymbolPalette.SymbolGroups.Remove(diagramControl.SymbolPalette.SymbolGroups[4]);
            diagramControl.SymbolPalette.SymbolGroups.Remove(diagramControl.SymbolPalette.SymbolGroups[3]);
            diagramControl.SymbolPalette.SymbolGroups.Remove(diagramControl.SymbolPalette.SymbolGroups[2]);
            
            //Remove the SymbolPaletteFilters
            diagramControl.SymbolPalette.SymbolFilters.Remove(diagramControl.SymbolPalette.SymbolFilters[5]);
            diagramControl.SymbolPalette.SymbolFilters.Remove(diagramControl.SymbolPalette.SymbolFilters[4]);
            diagramControl.SymbolPalette.SymbolFilters.Remove(diagramControl.SymbolPalette.SymbolFilters[3]);
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
            symbolgroup = new SymbolPaletteGroup();
            symbolgroup.Label = "Layout Shapes";
            SymbolPalette.SetFilterIndexes(symbolgroup, new Int32Collection(new int[] { 0, 3 }));
            diagramControl.SymbolPalette.SymbolGroups.Add(symbolgroup);
            //Creating New SymbolPaletteItem
            SymbolPaletteItem symbolItem1 = addSymbolItem("Class", "Class", App.Current.Resources["RoundedRectangle1"] as Path);
            SymbolPaletteItem symbolItem2 = addSymbolItem("Interface", "Interface", App.Current.Resources["RoundedRectangle2"] as Path);
            SymbolPaletteItem symbolItem3 = addSymbolItem("Red", "Red", App.Current.Resources["RoundedRectangle3"] as Path);
            SymbolPaletteItem symbolItem4 = addSymbolItem("Blue", "Blue", App.Current.Resources["RoundedRectangle4"] as Path);
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

        //Check for EnableZoom
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
                            Palete.IsChecked = true;
                            Palete.IsEnabled = true;
                            Zoom.IsEnabled = true;
                            Zoom.IsChecked = true;
                            zoomfactor.IsEnabled = true;
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

        //Check for EnableZoom
        private void PageEditable_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox box = (sender as CheckBox);
            switch (box.Name)
            {
                case "PageEditable":
                    diagramView.IsPageEditable = false;
                    Palete.IsChecked = false;
                    Palete.IsEnabled = false;
                    Zoom.IsChecked = false;
                    Zoom.IsEnabled = false;
                    zoomfactor.IsEnabled = false;
                    zbut.IsEnabled = false;
                    zobut.IsEnabled = false;
                    reset.IsEnabled = false;
                    Pan.IsChecked = false;
                    Pan.IsEnabled = false;
                    break;
                case "Pan":
                    diagramView.IsPanEnabled = false;
                    break;               
            }

        }

        //Initialize the combobox values
        private void ComboBoxItem_SelectedCRadius(object sender, RoutedEventArgs e)
        {
            ComboBoxItem item = (ComboBoxItem)sender;
            if (diagramView != null)
                diagramView.ZoomFactor = Convert.ToDouble(item.Content);
        }

        #endregion

        #region PrivateFunctions

        //add newsymbolpaletteItem into SymbolPaletteGroup
        private SymbolPaletteItem addSymbolItem(String name, String tooltip, Path path)
        {
            SymbolPaletteItem item = new SymbolPaletteItem();
            item.Name = name;
            item.ToolTip = tooltip;
            item.Content = path;
            symbolgroup.Items.Add(item);
            return item;
        }
        #endregion
    }
}
