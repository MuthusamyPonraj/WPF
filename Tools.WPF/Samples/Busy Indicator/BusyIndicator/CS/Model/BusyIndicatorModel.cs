using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Syncfusion.Windows.Controls.Notification;

namespace SfBusyIndicator
{
    public class BusyIndicatorModel
    {
        private AnimationTypes animation;

        public AnimationTypes Animation
        {
            get { return animation; }
            set { animation = value; }
        }
    }
}
