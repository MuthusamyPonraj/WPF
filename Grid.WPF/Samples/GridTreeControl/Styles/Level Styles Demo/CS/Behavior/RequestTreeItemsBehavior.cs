using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Interactivity;
using Syncfusion.Windows.Controls.Grid;
using System.Windows;
using System.Windows.Media;

namespace LevelStylesDemo
{
   public class GridTreeFunctionalBehavior:Behavior<GridTreeControl>
    {
        ViewModel viewModel;

        /// <summary>
        /// Called after the behavior is attached to an AssociatedObject.
        /// </summary>
        /// <remarks>Override this to hook up functionality to the AssociatedObject.</remarks>
        protected override void OnAttached()
        {
            base.OnAttached();
            viewModel = this.AssociatedObject.DataContext as ViewModel;
            InitEmployeeTreeGrid();
            this.AssociatedObject.RequestTreeItems += new GridTreeRequestTreeItemsHandler(AssociatedObject_RequestTreeItems);
        }

        /// <summary>
        /// Handles the RequestTreeItems event of the AssociatedObject control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="args">The <see cref="Syncfusion.Windows.Controls.Grid.GridTreeRequestTreeItemsEventArgs"/> instance containing the event data.</param>
        void AssociatedObject_RequestTreeItems(object sender, GridTreeRequestTreeItemsEventArgs args)
        {
            //code showing how to use LoadAllAtStartUp property....
            if (AssociatedObject.InternalGrid.LoadAllAtStartUp && args.ParentItem == null)
            {
                //need to load all the GridNodes into g.Nodes....
                IEnumerable<EmployeeInfo> rootNodes = viewModel.GetReportees(-1);
                foreach (EmployeeInfo e in rootNodes)
                {
                    AssociatedObject.InternalGrid.RootNodes.Add(Populate(AssociatedObject, e, null, 0, null));
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
        /// Populates the specified g.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="e">The e.</param>
        /// <param name="parent">The parent.</param>
        /// <param name="level">The level.</param>
        /// <param name="parentNode">The parent node.</param>
        /// <returns></returns>
        private GridTreeNode Populate(GridTreeControl g, EmployeeInfo e, EmployeeInfo parent, int level, GridTreeNode parentNode)
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
            return node;
        }

        /// <summary>
        /// Inits the employee tree grid.
        /// </summary>
        private void InitEmployeeTreeGrid()
        {
            //specify other miscellaneous properties
            this.AssociatedObject.SupportRowSizing = true;
            this.AssociatedObject.ShowRowHeader = false;
            this.AssociatedObject.ColumnHeaderStyle.HorizontalAlignment = HorizontalAlignment.Center;
            this.AssociatedObject.ShowExpandColumnBorders = true;
            this.AssociatedObject.AllowSort = true;// false;
            this.AssociatedObject.AllowDragColumns = true;
            Byte k = 150;
            Byte k1 = 250;
            int i = -1;
            GridStyleInfo style;
            while (i < 6)
            {
                style = new GridStyleInfo();
                style.Background = new SolidColorBrush(Color.FromArgb(255, 239, k1, k));
                this.AssociatedObject.LevelStyles.Add(style);
                k += 15;
                k1 -= 15;
                i++;
            }
        }
    }
}
