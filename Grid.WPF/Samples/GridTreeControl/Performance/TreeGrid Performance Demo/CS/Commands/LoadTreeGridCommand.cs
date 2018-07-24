using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Syncfusion.Windows.Controls.Grid;
using System.Windows;

namespace TreeGridInDepth
{
    public static class LoadTreeGridCommand
    {
        static ViewModel viewModel = null;

        static LoadTreeGridCommand()
        {
            CommandManager.RegisterClassCommandBinding(typeof(GridTreeControl), new CommandBinding(LoadTree, OnExecuteLoadTree, OnCanExecuteLoadTree));
        }

        public static RoutedCommand LoadTree = new RoutedCommand("LoadTree", typeof(GridTreeControl));

        /// <summary>
        /// Called when [execute serialize].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The <see cref="System.Windows.Input.ExecutedRoutedEventArgs"/> instance containing the event data.</param>
        private static void OnExecuteLoadTree(object sender, ExecutedRoutedEventArgs args)
        {
            var layout = args.Parameter as LayoutControl;
            GridTreeControl GTC = layout.GridView as GridTreeControl;
            viewModel = GTC.DataContext as ViewModel;
            DisplayEmployeeTree(GTC, layout);
        }

        /// <summary>
        /// Displays the employee tree.
        /// </summary>
        /// <param name="grid">The grid.</param>
        /// <param name="layout">The layout.</param>
        private static void DisplayEmployeeTree(GridTreeControl grid, LayoutControl layout)
        {
            DateTime start = DateTime.Now; 
            AssignLookUpType();
            int count;
            if (!int.TryParse(viewModel.EmployeeCount, out count))
            {
                count = 500;
            }
            viewModel.PopulateWithSampleData(count);
            InitEmployeeTreeGrid(grid);
            grid.SupportRowSizing = false;
            grid.RequestTreeItems += new GridTreeRequestTreeItemsHandler(grid_RequestTreeItems);
            grid.ModelLoaded += (s, e) =>
            {
                grid.InternalGrid.QueryCellInfo += new GridQueryCellInfoEventHandler(InternalGrid_QueryCellInfo);
                grid.InternalGrid.ExpandGlyphType = GridTreeExpandGlyph.PlusMinus;
                grid.VisualStyle = VisualStyle.Office14Blue;
            };
            grid.AllowAutoSizingNodeColumn = false;
            grid.Populate();
            viewModel.LoadingTime = string.Format("elapsed time: {0:0.0000} secs", DateTime.Now.Subtract(start).TotalSeconds);
            grid.SupportRowSizing = true;
            grid.EnableHotRowMarker = true;
            if (viewModel.UseColumnsIsChecked)
            {
                grid.Columns.Clear();
                SetUpColumnsCollection(grid);
            }
        }

        /// <summary>
        /// Handles the QueryCellInfo event of the InternalGrid control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Syncfusion.Windows.Controls.Grid.GridQueryCellInfoEventArgs"/> instance containing the event data.</param>
        static void InternalGrid_QueryCellInfo(object sender, GridQueryCellInfoEventArgs e)
        {
            if (e.Style.ColumnIndex == 6 && e.Style.RowIndex > 0)
            {
                e.Style.CellType = "CurrencyEdit";
                e.Style.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;
            }
        }

        /// <summary>
        /// Handles the RequestTreeItems event of the grid control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="args">The <see cref="Syncfusion.Windows.Controls.Grid.GridTreeRequestTreeItemsEventArgs"/> instance containing the event data.</param>
        static void grid_RequestTreeItems(object sender, GridTreeRequestTreeItemsEventArgs args)
        {
            GridTreeControl gridTree = sender as GridTreeControl;

            //code showing how to use LoadAllAtStartUp property....
            if (gridTree.InternalGrid.LoadAllAtStartUp && args.ParentItem == null)
            {
                //need to load all the GridNodes into g.Nodes....
                IEnumerable<EmployeeInfo> rootNodes = viewModel.GetReportees(-1);
                foreach (EmployeeInfo e in rootNodes)
                {
                    gridTree.InternalGrid.RootNodes.Add(Populate(gridTree, e, null, 0, null));
                }
                return;
            }

            if (args.ParentItem == null)
            {
                //get the root list - get all employees who have no boss 
                args.ChildList = viewModel.GetReportees(-1); //get all employees whose boss's id is -1 (no boss)
            }
            else
            {   //get the children of the parent object
                EmployeeInfo emp = args.ParentItem as EmployeeInfo;
                if (emp != null)
                {
                    //get all employees that report to the parent employee
                    args.ChildList = viewModel.GetReportees(emp.ID);
                }
            }
        }

        /// <summary>
        /// Assigns the type of the look up.
        /// </summary>
        private static void AssignLookUpType()
        {
            switch (viewModel.AccessTypeComboBoxIndex)
            {
                case 0:
                    viewModel.LookUpType = AccessType.Optimized;
                    break;
                case 1:
                    viewModel.LookUpType = AccessType.LINQ;
                    break;
                case 2:
                    viewModel.LookUpType = AccessType.Linear;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Inits the employee tree grid.
        /// </summary>
        /// <param name="grid">The grid.</param>
        private static void InitEmployeeTreeGrid(GridTreeControl grid)
        {
            //specify other miscellaneous properties
            grid.SupportRowSizing = true;
            grid.ShowRowHeader = false;
            grid.ColumnHeaderStyle.HorizontalAlignment = HorizontalAlignment.Center;
            grid.ShowExpandColumnBorders = true;
            grid.AllowSort = true;// false;
            grid.AllowDragColumns = true;
            Byte k = 150;
            Byte k1 = 250;
            int i = -1;
            GridStyleInfo style;
            while (i < 6)
            {
                style = new GridStyleInfo();
                grid.LevelStyles.Add(style);
                k += 15;
                k1 -= 15;
                i++;
            }
        }

        /// <summary>
        /// Sets up columns collection.
        /// </summary>
        /// <param name="grid">The grid.</param>
        private static void SetUpColumnsCollection(GridTreeControl grid)
        {
            //need to specify the columns you want to see in the grid as well as their order
            GridTreeColumn tc = new GridTreeColumn("FirstName", "First Name", 100);
            grid.Columns.Add(tc); //0           
            tc = new GridTreeColumn("LastName", "Last Name", 100);
            tc.PercentWidth = 1;
            grid.Columns.Add(tc);
            tc = new GridTreeColumn("Department", "Department", 100);
            tc.PercentWidth = 1;
            grid.Columns.Add(tc); //3
            tc = new GridTreeColumn("Salary", "Salary", 80);
            tc.StyleInfo.HorizontalAlignment = HorizontalAlignment.Right;
            tc.PercentWidth = 1;
            tc.StyleInfo.CellValueType = typeof(double);
            tc.StyleInfo.Format = "0,000";
            grid.Columns.Add(tc); //4
        }

        /// <summary>
        /// Populates the specified g.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="e">The e.</param>
        /// <param name="parent">The parent.</param>
        /// <param name="level">The level.</param>
        /// <param name="parentNode">The parent node.</param>
        /// <returns></returns>
        private static GridTreeNode Populate(GridTreeControl g, EmployeeInfo e, EmployeeInfo parent, int level, GridTreeNode parentNode)
        {
            GridTreeNode node = new GridTreeNode(level, e, true, parentNode);
            g.InternalGrid.Nodes.Add(node);
            node.ParentItem = parent;
            IEnumerable<EmployeeInfo> childNodes = viewModel.GetReportees(e.ID);
            bool hasChildren = false;
            foreach (EmployeeInfo e1 in childNodes)
            {
                Populate(g, e1, e, level + 1, node);
                hasChildren = true;
            }
            node.HasChildNodes = hasChildren;
            return null;
        }
        /// <summary>
        /// Called when [can execute serialize].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The <see cref="System.Windows.Input.CanExecuteRoutedEventArgs"/> instance containing the event data.</param>
        private static void OnCanExecuteLoadTree(object sender, CanExecuteRoutedEventArgs args)
        {
            args.CanExecute = true;
        }
    }
}
