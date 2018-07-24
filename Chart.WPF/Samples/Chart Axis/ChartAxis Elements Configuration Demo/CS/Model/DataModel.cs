using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace ChartAxisElementsConfigurationDemo
{
        public class DataModel
        {

            private string carbrand;
            public string CarBrand
            {
                get;
                set;
            }

            public DateTime Date
            { get; set; }
           
            public double CarsSold
            {
                get;
                set;
            }

            public double salesamount;
            public double EstimatedCost
            {
                get;
                set;
            }

            public double profitpercentage;
            public double ProfitPercentage
            {
                get;
                set;
            }

            public double averageraise;
            public double AverageRaise
            {
                get;
                set;
            }

            public double investedamount;
            public double InvestedAmount
            {
                get;
                set;
            }
        }
    }
