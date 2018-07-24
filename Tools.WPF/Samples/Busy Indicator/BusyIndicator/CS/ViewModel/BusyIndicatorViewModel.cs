using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Syncfusion.Windows.Controls.Notification;
using System.Collections.ObjectModel;

namespace SfBusyIndicator
{
    public class BusyIndicatorViewModel
    {
        public BusyIndicatorViewModel()
        {
            BusyIndicatorItems = new ObservableCollection<BusyIndicatorModel>();
            foreach (var item in Enum.GetValues(typeof(AnimationTypes)).Cast<AnimationTypes>())
            {
                BusyIndicatorItems.Add(new BusyIndicatorModel() { Animation = item });
            }
        }

        public ObservableCollection<BusyIndicatorModel> BusyIndicatorItems { get; set; }

    }
}
