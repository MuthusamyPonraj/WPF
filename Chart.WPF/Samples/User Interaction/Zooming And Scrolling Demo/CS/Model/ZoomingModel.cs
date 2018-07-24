using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZoomingAndScrolling
{
    public class Population
    {
        public int Year { get; set; }

        public int IncreaseInPopulation { get; set; }

        public double LiteracyGrowth { get; set; }

        public int AbovePovertyLine { get; set; }

        public int BelowPovertyLine { get; set; }

        public double BirthRate { get; set; }
    }

    public class Product
    {
        public string Id { get; set; }

        public double XValue { get; set; }

        public double YValue { get; set; }

        public double ZValue { get; set; }

    }
}
