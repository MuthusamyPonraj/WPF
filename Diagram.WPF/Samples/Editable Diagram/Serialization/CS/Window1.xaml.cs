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
using System.IO;

namespace Serialization
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {

        #region Declaring Public Variables

        string selection;
        CheckBox cb;
        string selecteditemname;
        Rect savearea;
        SymbolPaletteGroup Selectedgroup;
        SymbolPaletteItem SelectedItem;
        #endregion

        #region Constructor

        public Window1()
        {
            InitializeComponent();
            //Function to creates Nodes and Connections.
            CreateNodes();
        }
        #endregion

        #region Helper Methods

        private void CreateNodes()
        {
            //Defining the nodes.
            Node EssentialWPF = addNodes("EssentialWPF", 300, 300, "Computer Applications", this.Resources["MyComputerIcon"] as DrawingImage, 0);
            Node EssentialTools = addNodes("EssentialTools", 312, 500, "Health Care", this.Resources["FloppyDisk"] as DrawingImage, 1);
            Node EssentialChart = addNodes("EssentialChart", 312, 100, "Defence", this.Resources["ModemIcon"] as DrawingImage, 3);
            Node EssentialDiagram = addNodes("EssentialDiagram", 100, 200, "Education", this.Resources["MyVideos"] as DrawingImage, 5);
            Node EssentialEdit = addNodes("EssentialEdit", 500, 200, "Entertainment", this.Resources["MyMusic"] as DrawingImage, 2);
            Node EssentialGrid = addNodes("EssentialGrid", 100, 400, "science", this.Resources["MouseIcon"] as DrawingImage, 4);
            Node BackOfficePdt = addNodes("ackOfficePdt", 500, 400, "Communications", this.Resources["KeyboardIcon"] as DrawingImage, 6);

            //Defining the line connectors.
            LineConnector Connectionone = addConnection(EssentialWPF, EssentialTools, ConnectorType.Bezier, DecoratorShape.None, DecoratorShape.Arrow);
            LineConnector ConnectionTwo = addConnection(EssentialChart, EssentialWPF, ConnectorType.Bezier, DecoratorShape.None, DecoratorShape.None);
            LineConnector ConnectionThree = addConnection(EssentialDiagram, EssentialWPF, ConnectorType.Bezier, DecoratorShape.Arrow, DecoratorShape.Arrow);
            LineConnector ConnectionFour = addConnection(EssentialEdit, EssentialWPF, ConnectorType.Bezier, DecoratorShape.None, DecoratorShape.Arrow);
            LineConnector connectionfive = addConnection(EssentialGrid, EssentialWPF, ConnectorType.Bezier, DecoratorShape.None, DecoratorShape.Arrow);
            LineConnector Connection6 = addConnection(BackOfficePdt, EssentialWPF, ConnectorType.Bezier, DecoratorShape.None, DecoratorShape.Arrow);
        }

        #endregion

        #region Event Handler

        //Loads the selected page.
        private void Load_Click(object sender, RoutedEventArgs e)
        {
            diagramControl.Load();
        }

        //Saves the page into specified format.
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            diagramControl.Save();
        }

        //if the SymbolPaletteGroup is Selected
        private void SymbolPaletteGroup_Checked(object sender, RoutedEventArgs e)
        {
            CurrentSelection(sender as RadioButton);
            LoadGroupLabel();
        }

        //if the SymbolPalette is Selected
        private void SymbolPalette_Checked(object sender, RoutedEventArgs e)
        {
            CurrentSelection(sender as RadioButton);
        }

        //If the Particluar SymbolGroup is Selected,while Selecting the SymbolPaletteItem the loaded new item comes under the Selected SymbolPaletteGroup
        private void SymbolPaletteItem_Checked(object sender, RoutedEventArgs e)
        {
            CurrentSelection(sender as RadioButton);
            foreach (SymbolPaletteGroup group in diagramControl.SymbolPalette.SymbolGroups)
            {
                if (group.Label == SymbolGroup.SelectionBoxItem)
                {
                    LoadSymbolPaletteItem(group);
                    break;
                }
            }
        }

        //For Populating the Combobox with SymbolPaletteItem  names
        private void LoadSymbolPaletteItem(SymbolPaletteGroup group)
        {
            SymbolItem.Items.Clear();
            foreach (SymbolPaletteItem item in group.Items)
            {
                ComboBoxItem combo = new ComboBoxItem();
                combo.Content = item.ItemName;
                SymbolItem.Items.Add(combo);
            }
        }

        //For Populating the Combobox with SymbolPaletteGroup names
        private void LoadGroupLabel()
        {
            SymbolGroup.Items.Clear();
            foreach (SymbolPaletteGroup group in diagramControl.SymbolPalette.SymbolGroups)
            {
                ComboBoxItem Comboitem = new ComboBoxItem();
                Comboitem.Content = group.Label;
                SymbolGroup.Items.Add(Comboitem);
            }
        }

        //For Identifying the Which is going to be Export/Import from the RadioButton
        private void CurrentSelection(RadioButton selected)
        {
            if (selected == symbolPalette)
            {
                symbolPaletteGroup.IsChecked = false;
                symbolPaletteItem.IsChecked = false;
                SymbolGroup.IsHitTestVisible = false;
                SymbolItem.IsHitTestVisible = false;
                SymbolGroup.IsEnabled = true;
                SymbolItem.IsEnabled = true;
                SaveSymbolPalette.IsEnabled = true;
                LoadSymbolPalette.IsEnabled = true;
            }
            else if (selected == symbolPaletteGroup)
            {
                symbolPalette.IsChecked = false;
                symbolPaletteItem.IsChecked = false;
                SymbolGroup.IsHitTestVisible = true;
                SymbolItem.IsHitTestVisible = false;
            }
            else if (selected == symbolPaletteItem)
            {
                symbolPalette.IsChecked = false;
                symbolPaletteGroup.IsChecked = false;
                SymbolItem.IsHitTestVisible = true;
                SymbolGroup.IsHitTestVisible = false;
            }
        }

        //For exporting the SymbolPalette(Whole)
        private void SaveSymbolPalette_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)symbolPalette.IsChecked)
            {
                diagramControl.SaveSymbolPalette();
            }
            else if ((bool)symbolPaletteItem.IsChecked)
            {
                if (SelectedItem != null)
                {
                    diagramControl.SaveSymbolPaletteItem(SelectedItem);
                }
            }
            else if ((bool)symbolPaletteGroup.IsChecked)
            {
                if (Selectedgroup != null)
                {
                    diagramControl.SaveSymbolPaletteGroup(Selectedgroup);
                }
            }
        }


        //For Loading the SymbolPalette
        private void LoadSymbolPalette_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)symbolPalette.IsChecked)
            {
                diagramControl.LoadSymbolPalette();
            }
            else if ((bool)symbolPaletteItem.IsChecked)
            {
                if (Selectedgroup != null)
                {
                    diagramControl.LoadSymbolPaletteItem(Selectedgroup);
                }
            }
            else if ((bool)symbolPaletteGroup.IsChecked)
            {
                if (Selectedgroup != null)
                {
                    diagramControl.LoadSymbolPaletteGroup();
                }
            }
        }

        //If the SymbolPaletteGroup selection changed
        private void SymbolGroup_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (SymbolPaletteGroup group in diagramControl.SymbolPalette.SymbolGroups)
            {
                if (SymbolGroup.SelectedItem != null && group.Label == (SymbolGroup.SelectedItem as ComboBoxItem).Content)
                {
                    Selectedgroup = group as SymbolPaletteGroup;
                    break;
                }
            }
        }

        //If the SymbolPaletteItem selection changed
        private void SymbolItem_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (SymbolPaletteItem items in Selectedgroup.Items)
            {
                if (SymbolItem.SelectedItem != null && items.ItemName == (SymbolItem.SelectedItem as ComboBoxItem).Content)
                {
                    SelectedItem = items;
                    break;
                }
            }
        }
        #endregion

        #region Private Functions

        //Add the Node to DiagramModel
        private Node addNodes(String name, double offsetx, double offsety, String tooltip, DrawingImage drawimage, Int32 level)
        {
            Node node = new Node(Guid.NewGuid(), name);
            Image image = new Image();
            image.Source = drawimage;
            node.OffsetX = offsetx;
            node.OffsetY = offsety;
            node.ToolTip = tooltip;
            node.Content = image;
            node.Level = level;
            diagramModel.Nodes.Add(node);
            return node;
        }

        //Add the Lineconnector
        private LineConnector addConnection(Node headnode, Node tailnode, ConnectorType connType, DecoratorShape headdecorator, DecoratorShape taildecorator)
        {
            LineConnector conn = new LineConnector();
            conn.HeadNode = headnode;
            conn.TailNode = tailnode;
            conn.ConnectorType = connType;
            diagramModel.Connections.Add(conn);
            return conn;
        }

        #endregion
    }
}
