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

namespace FloorPlanSample_2008
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
            diagramControl.IsSymbolPaletteEnabled = true;
            //LoadPalette();
            CustomizePalette();

            //Loading a pre saved layout
            diagramControl.Load(@"..\..\Floorplan.xaml");
        }

        #endregion

        #region Helper Methods

        void CustomizePalette()
        {
            diagramControl.SymbolPalette.Width = 180;
            //Call to clear out the symbolpalette
            RemovetheSymBolPaletteGroup();

            //Create new stmbolpalettegroup
            SymbolPaletteGroup symbolGroup = App.Current.FindResource("RoomGroup") as SymbolPaletteGroup;
            symbolGroup.Label = "Room Symbol";
            diagramControl.SymbolPalette.SymbolGroups.Add(symbolGroup);
        }

        private void RemovetheSymBolPaletteGroup()
        {
            //Remove the SymbolPaletteGroups
            diagramControl.SymbolPalette.SymbolGroups.Remove(diagramControl.SymbolPalette.SymbolGroups[4]);
            diagramControl.SymbolPalette.SymbolGroups.Remove(diagramControl.SymbolPalette.SymbolGroups[3]);
            diagramControl.SymbolPalette.SymbolGroups.Remove(diagramControl.SymbolPalette.SymbolGroups[2]);
            diagramControl.SymbolPalette.SymbolGroups.Remove(diagramControl.SymbolPalette.SymbolGroups[1]);
            diagramControl.SymbolPalette.SymbolGroups.Remove(diagramControl.SymbolPalette.SymbolGroups[0]);
            //Remove the SymbolPaletteItems
            diagramControl.SymbolPalette.SymbolFilters.Remove(diagramControl.SymbolPalette.SymbolFilters[5]);
            diagramControl.SymbolPalette.SymbolFilters.Remove(diagramControl.SymbolPalette.SymbolFilters[4]);
            diagramControl.SymbolPalette.SymbolFilters.Remove(diagramControl.SymbolPalette.SymbolFilters[3]);
            diagramControl.SymbolPalette.SymbolFilters.Remove(diagramControl.SymbolPalette.SymbolFilters[2]);
            diagramControl.SymbolPalette.SymbolFilters.Remove(diagramControl.SymbolPalette.SymbolFilters[1]);
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
                    Symbol.IsEnabled = false;
                    Symbol.IsChecked = false;
                    Zoom.IsChecked = false;
                    Zoom.IsEnabled = false;
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
        #endregion
    }
}
