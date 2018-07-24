using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.IO;
using System.Globalization;

namespace GoogleFinanceDemo
{
    public class GoogleData
    {
        public DateTime TimeStamp
        {
            get;
            set;
        }
        public double High
        {
            get;
            set;
        }
        public double Low
        {
            get;
            set;
        }
        public double Last
        {
            get;
            set;
        }
        public double Open
        {
            get;
            set;
        }
        public double Volume
        {
            get;
            set;
        }
    }
  
}
