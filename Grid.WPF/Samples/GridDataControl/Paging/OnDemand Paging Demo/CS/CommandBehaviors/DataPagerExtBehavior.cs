using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Interactivity;
using Syncfusion.Windows.Controls.Grid;

namespace OnDemandPagingDemo
{
   public class SummaryCalculationBehavior : Behavior<MainWindow>
    {
     
        /// <summary>
        /// Called after the behavior is attached to an AssociatedObject.
        /// </summary>
        /// <remarks>Override this to hook up functionality to the AssociatedObject.</remarks>
        protected override void OnAttached()
        {
          
            this.AssociatedObject.dataPager.OnDemandDataSourceLoad += new GridDataOnDemandPageLoadingEventHandler(dataPager_OnDemandDataSourceLoad);     
           
        }

        /// <summary>
        /// Handles the OnDemandDataSourceLoad event of the dataPager control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Syncfusion.Windows.Controls.Grid.GridDataOnDemandPageLoadingEventArgs"/> instance containing the event data.</param>
        void dataPager_OnDemandDataSourceLoad(object sender, GridDataOnDemandPageLoadingEventArgs e)
        {
            ViewModel dataContext = this.AssociatedObject.DataContext as ViewModel;
            dataContext.OnDemandDataSourceLoad(new PageInfo(e.PagedRows, e.MaximumRows)); 
        }      

        /// <summary>
        /// Called when [detaching].
        /// </summary>
        protected override void OnDetaching()
        {
            this.AssociatedObject.dataPager.OnDemandDataSourceLoad -= new GridDataOnDemandPageLoadingEventHandler(dataPager_OnDemandDataSourceLoad);   
        }
    }
}
