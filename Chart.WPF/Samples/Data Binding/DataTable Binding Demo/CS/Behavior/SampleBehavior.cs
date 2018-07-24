using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Windows.Interactivity;

namespace DataTableBindingDemo
{
    public class SampleBehavior:Behavior<Window1>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            DataViewModel datamodel = new DataViewModel();
            this.AssociatedObject.SyncUIChart.Areas[0].PrimaryAxis.LabelsSource = datamodel.Data;
            this.AssociatedObject.SyncUIChart.Areas[0].Series[0].DataSource = datamodel.Data;
            this.AssociatedObject.SyncUIChart.Areas[0].Series[1].DataSource = datamodel.Data;
        }
    }
}
