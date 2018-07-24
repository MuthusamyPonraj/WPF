using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Interactivity;
using Syncfusion.Windows.Controls.Grid;
using System.Windows.Controls;
using System.Windows;

namespace FileExplorer
{
  public  class ContextMenuBehavior : Behavior<GridTreeControl>
    {
        List<MenuItem> menuItems = new List<MenuItem>();

        /// <summary>
        /// Called after the behavior is attached to an AssociatedObject.
        /// </summary>
        /// <remarks>Override this to hook up functionality to the AssociatedObject.</remarks>
        protected override void OnAttached()
        {
            base.OnAttached();
            this.AssociatedObject.Loaded += new RoutedEventHandler(AssociatedObject_Loaded);
        }

        void AssociatedObject_Loaded(object sender, RoutedEventArgs e)
        {
            this.AssociatedObject.InternalGrid.Model.EnableContextMenu = true;
            this.LoadContextMenu();
            this.AssociatedObject.Model.QueryContextMenuInfo += new GridQueryContextMenuInfoEventHandler(Model_QueryContextMenuInfo);
        }

        /// <summary>
        /// Loads the context menu.
        /// </summary>
        void LoadContextMenu()
        {
            var columns = this.AssociatedObject.InternalGrid.GetVisibleColumns();// This method used to get the TotalVisible colums in the collection
            var currentColumns = this.AssociatedObject.Columns;// This property used to get Columns in the Current Grid
            var mappingNames = currentColumns.Select(x => x.MappingName);

            foreach (var column in columns)
            {
                MenuItem menuItem = new MenuItem();
                menuItem.Click += new RoutedEventHandler(menuItem_Click);

                menuItem.IsCheckable = true;

                menuItem.IsChecked = mappingNames.Contains(column.MappingName) ? true : false;
                menuItem.Name = column.MappingName;
                menuItem.Header = column.HeaderText;
                if (menuItem.Header.ToString() == "ShortName")
                {
                    menuItem.Header = "Name";
                    menuItem.IsChecked = true;
                    menuItem.IsEnabled = false;
                }
                else if (menuItem.Header.ToString() == "FileType")
                    menuItem.Header = "Type";
                else if (menuItem.Header.ToString() == "DateModified")
                    menuItem.Header = "Date Modified";
                else if (menuItem.Header.ToString() == "TotalSize")
                    menuItem.Header = "Total Size";
                else if (menuItem.Header.ToString() == "TotalFreeSpace")
                    menuItem.Header = "Total Free Space";
                else if (menuItem.Header.ToString() == "PercentofFreeSpace")
                    menuItem.Header = "Percent Of Free Space";
                else if (menuItem.Header.ToString() == "FullName")
                    menuItem.Header = "Full Name";
                else if (menuItem.Header.ToString() == "DateCreated")
                    menuItem.Header = "Date Created";
                else if (menuItem.Header.ToString() == "DateAccessed")
                    menuItem.Header = "Date Accessed";
                menuItems.Add(menuItem);
            }
        }

        /// <summary>
        /// Handles the QueryContextMenuInfo event of the Model control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Syncfusion.Windows.Controls.Grid.GridQueryContextMenuInfoEventArgs"/> instance containing the event data.</param>
        void Model_QueryContextMenuInfo(object sender, GridQueryContextMenuInfoEventArgs e)
        {
            if (e.Style.RowIndex == 0)
                e.Style.ContextMenuItems = menuItems;
        }

        /// <summary>
        /// Handles the Click event of the menuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        void menuItem_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = sender as MenuItem;

            var isFound = this.AssociatedObject.InternalGrid.Columns.FirstOrDefault(v => v.MappingName == selectedItem.Name) != null;
            if (!isFound)
            {
                if (selectedItem.IsChecked == true)
                {
                    this.AssociatedObject.InternalGrid.Columns.Add(new GridTreeColumn()
                    {
                        MappingName = selectedItem.Name,
                        HeaderText = selectedItem.Header.ToString(),
                        StyleInfo = new GridStyleInfo()
                    });
                }
            }
            else
            {
                if (selectedItem.IsChecked == false)
                {
                    var column = this.AssociatedObject.InternalGrid.Columns.Where(c => c.MappingName == selectedItem.Name).FirstOrDefault();
                    this.AssociatedObject.InternalGrid.Columns.Remove(column);
                }
            }
            // use to populate the GridNodes after column added.
            this.AssociatedObject.InternalGrid.PopulateGridNodes(false, true);
            //Refresh the grid after populate the grid
            this.AssociatedObject.InternalGrid.InvalidateCells();
        }

        /// <summary>
        /// Called when the behavior is being detached from its AssociatedObject, but before it has actually occurred.
        /// </summary>
        /// <remarks>Override this to unhook functionality from the AssociatedObject.</remarks>
        protected override void OnDetaching()
        {
            base.OnDetaching();
            this.AssociatedObject.Loaded -= new RoutedEventHandler(AssociatedObject_Loaded);
            this.AssociatedObject.InternalGrid.Model.QueryContextMenuInfo -= new GridQueryContextMenuInfoEventHandler(Model_QueryContextMenuInfo);
            foreach (var Menuitem in menuItems)
            {
                Menuitem.Click -= new RoutedEventHandler(menuItem_Click);
            }
        }
    }
}
