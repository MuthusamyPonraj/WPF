using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using Syncfusion.Windows.Chart;

namespace StackingArea100
{
    public class Accidents
    {
        public DateTime Month { get; set; }
        public double Bus { get; set; }
        public double Car { get; set; }
        public double Truck { get; set; }
        public double TwoWheeler { get; set; }
    }
}
