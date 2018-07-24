using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Syncfusion.Windows.Controls.Grid;
using System.Windows.Interactivity;

namespace CustomSummariesDemo
{
    public class InitialSetupBehavior : Behavior<MainWindow>
    {
        /// <summary>
        /// Called when [attached].
        /// </summary>
        protected override void OnAttached()
        {
            this.AssociatedObject.Loaded += new System.Windows.RoutedEventHandler(AssociatedObject_Loaded);
            
        }

        void AssociatedObject_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            this.AssociatedObject.ExpandAll.Click += new System.Windows.RoutedEventHandler(ExpandAll_Click);
            this.AssociatedObject.CollapseAll.Click += new System.Windows.RoutedEventHandler(CollapseAll_Click);
        }

        void CollapseAll_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.AssociatedObject.gridDataControl1.Model.Table.CollapseAllGroups();
        }

        void ExpandAll_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.AssociatedObject.gridDataControl1.Model.Table.ExpandAllGroups();
        }

         /// <summary>
        /// Handles the SortColumnsChanging event of the Table control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="args">The <see cref="Syncfusion.Windows.Controls.Grid.GridDataSortColumnsChangingEventArgs"/> instance containing the event data.</param>
        

        /// <summary>
        /// Called when [detaching].
        /// </summary>
        protected override void OnDetaching()
        {
            this.AssociatedObject.ExpandAll.Click -=new System.Windows.RoutedEventHandler(ExpandAll_Click);
            this.AssociatedObject.CollapseAll.Click -=new System.Windows.RoutedEventHandler(CollapseAll_Click);
        }
    }
}
