using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChartAnimations
{
    public class MonthlyNet
    {
        int _monthno;
        string _monthstr;
        double _net;

        public String Month
        {
            get
            {
                return _monthstr;
            }
            set
            {
                _monthstr = value;
            }
        }

        public int MonthNo
        {
            get
            {
                return _monthno;
            }
            set
            {
                _monthno = value;
            }

        }

        public double NetUp
        {
            get
            {
                return _net;
            }
            set
            {
                _net = value;
            }
        }

        public MonthlyNet(int month, string monthname, double net)
        {
            _monthno = month;
            _monthstr = monthname;
            _net = net;
        }
    }
}
