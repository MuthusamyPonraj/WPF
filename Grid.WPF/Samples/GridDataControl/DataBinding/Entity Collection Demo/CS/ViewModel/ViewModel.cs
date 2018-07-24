using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Syncfusion.Windows.Controls.Grid;
using System.Data.EntityClient;

namespace EntityCollectionDemo
{
    public class ViewModel 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModel"/> class.
        /// </summary>
        public ViewModel()
        {
            OrderCollection = GetData();
        }

        private IQueryable<Orders> _orderCollection;

        /// <summary>
        /// Gets or sets the order collection.
        /// </summary>
        /// <value>The order collection.</value>
        public IQueryable<Orders> OrderCollection
        {
            get
            {
                return _orderCollection;
            }
            set
            {
                _orderCollection = value;
            }
        }

        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <returns></returns>
        public IQueryable<Orders> GetData()
        {
            if (!LayoutControl.IsInDesignMode)
            {
                string connectionString = string.Format(@"Data Source = {0}", LayoutControl.FindFile("NorthwindGrid.sdf"));
                EntityConnectionStringBuilder entityBuilder = new EntityConnectionStringBuilder();
                entityBuilder.Metadata = "res://*/Model.NorthWind.csdl|res://*/Model.NorthWind.ssdl|res://*/Model.NorthWind.msl";
                entityBuilder.Provider = "System.Data.SqlServerCe.3.5";
                entityBuilder.ProviderConnectionString = connectionString;
                NorthwindGridEntities northwind = new NorthwindGridEntities(entityBuilder.ToString());
                return northwind.Orders;
            }
            return null;
        }
    }
}