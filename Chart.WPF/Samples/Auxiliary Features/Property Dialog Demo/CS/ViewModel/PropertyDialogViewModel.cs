using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace PropertyDialogDemo
{
    public class Products
    {
        public Products()
        {
            this.PropertyDialogModel = new ObservableCollection<product>();
            this.PropertyDialogModel.Add(new product() { ProdId = 1, Price = 10, Stock = 15, Projection = 50 });
            this.PropertyDialogModel.Add(new product() { ProdId = 2, Price = 20, Stock = 10, Projection = 45 });
            this.PropertyDialogModel.Add(new product() { ProdId = 3, Price = 50, Stock = 5, Projection = 30 });
            this.PropertyDialogModel.Add(new product() { ProdId = 4, Price = 15, Stock = 10, Projection = 25 });
            this.PropertyDialogModel.Add(new product() { ProdId = 5, Price = 35, Stock = 20, Projection = 10 });
            this.PropertyDialogModel.Add(new product() { ProdId = 6, Price = 25, Stock = 20, Projection = 30 });
            this.PropertyDialogModel.Add(new product() { ProdId = 7, Price = 45, Stock = 5, Projection = 35 });
        }

        public ObservableCollection<product> PropertyDialogModel { get; set; }
    }
}
