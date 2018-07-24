using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace ChartAutoScrollingDemo
{
    public class ProductDetails : ObservableCollection<Product>
    {
        public ProductDetails()
        {
            Random rand = new Random();
            DateTime dt = DateTime.Now;
            for (int i = 11; i < 60; i++)
            {
                this.Add(new Product { Rate = rand.Next(110, 240), Speed = dt });
                dt = dt.AddMinutes(i);
            }
        }
    }
}
