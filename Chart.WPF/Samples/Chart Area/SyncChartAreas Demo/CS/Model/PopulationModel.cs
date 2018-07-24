using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MultipleAreasWithSingleXAxis
{
    public class Population
    {
        public DateTime Year { get; set; }

        public int IncreaseInPopulation { get; set; }

        public double LiteracyGrowth { get; set; }

        public int AbovePovertyLine { get; set; }

        public int BelowPovertyLine { get; set; }

        public double BirthRate { get; set; }
    }
}
