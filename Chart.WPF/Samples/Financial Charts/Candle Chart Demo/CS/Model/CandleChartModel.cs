using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CandleChart
{
    public class ForeignExchange
    {
        public string FXSymbol { get; set; }
        public DateTime _Date { get; set; }
        public double High { get; set; }
        public double Low { get; set; }
        public double Open { get; set; }
        public double Close { get; set; }
    }
}
