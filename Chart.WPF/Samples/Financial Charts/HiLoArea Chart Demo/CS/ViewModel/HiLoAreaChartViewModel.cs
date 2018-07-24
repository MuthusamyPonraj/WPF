using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HiLoAreaChart
{
    public class HiLoAreaChartViewModel
    {
        public HiLoAreaChartViewModel()
        {
            DateTime dt = new DateTime(2000, 1, 5);
            productList = new List<product>();
            productList.Add(new product(dt, 4, 6));
            productList.Add(new product(dt.AddYears(1), 4, 2));
            productList.Add(new product(dt.AddYears(2), 4, 3));
            productList.Add(new product(dt.AddYears(3), 3, 5));
            productList.Add(new product(dt.AddYears(4), 5, 3));
            productList.Add(new product(dt.AddYears(5), 3, 4));
            productList.Add(new product(dt.AddYears(6), 3, 5));
            productList.Add(new product(dt.AddYears(7), 5, 3));
            productList.Add(new product(dt.AddYears(8), 3, 4));
        }

        public List<product> productList
        {
            get;
            set;
        }
    }
}
