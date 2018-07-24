#region Copyright Syncfusion Inc. 2001 - 2011
// Copyright Syncfusion Inc. 2001 - 2011. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace CellEditorsDemo
{
    using System;
    using System.Net;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Documents;
    using System.Windows.Ink;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Animation;
    using System.Windows.Shapes;
    using System.Collections.Generic;
    using System.Linq;
    using System.ComponentModel;
    using System.Collections.ObjectModel;

    public class OrderInfoRepository 
    {
        /// <summary>
        /// Gets the model.
        /// </summary>
        /// <value>The model.</value>
        public static OrderInfoRepository Model
        {
            get
            {
                return new OrderInfoRepository(100);
            }
        }

        /// <summary>
        /// Gets the small model.
        /// </summary>
        /// <value>The small model.</value>
        public static OrderInfoRepository SmallModel
        {
            get
            {
                return new OrderInfoRepository(100);
            }
        }

        /// <summary>
        /// Gets the orders.
        /// </summary>
        /// <param name="count">The count.</param>
        /// <returns></returns>
        public static OrderInfoRepository GetOrders(int count)
        {
            return new OrderInfoRepository(count);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderInfoRepository"/> class.
        /// </summary>
        public OrderInfoRepository()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderInfoRepository"/> class.
        /// </summary>
        /// <param name="count">The count.</param>
        public OrderInfoRepository(int count)
        {
            SetShipCity();
            for (int i = 10000; i < count + 10000; i++)
            {
                this.OrderList.Add(GetOrder(i));
            }
        }

        ObservableCollection<OrderInfo> _orderList = new ObservableCollection<OrderInfo>();
        /// <summary>
        /// Gets or sets the order list.
        /// </summary>
        /// <value>The order list.</value>
        public ObservableCollection<OrderInfo> OrderList 
        { 
            get
            {
                return _orderList;
            }
            set
            {
                _orderList = value;
            }
        }

        /// <summary>
        /// Gets the customers.
        /// </summary>
        /// <value>The customers.</value>
        public List<string> Customers
        {
            get
            {
                return this.CustomerID.ToList();
            }
        }

        /// <summary>
        /// Gets the ship countries.
        /// </summary>
        /// <value>The ship countries.</value>
        public List<string> ShipCountries
        {
            get
            {
                return this.ShipCountry.ToList();
            }
        }

        Random r = new Random();
        /// <summary>
        /// Gets the order.
        /// </summary>
        /// <param name="i">The i.</param>
        /// <returns></returns>
        private OrderInfo GetOrder(int i)
        {
            var shipcountry = ShipCountry[r.Next(5)];
            var shipcitycoll = ShipCity[shipcountry];
            return new OrderInfo()
            {
                OrderID = i,
                CustomerID = CustomerID[r.Next(15)],
                Delivery = this.DeliveryDate[r.Next(10)],
                EmployeeID = r.Next(1,9),
                Freight = Math.Round(r.Next(1000) + r.NextDouble(), 2),
                ShipCountry = shipcountry,
                ShipCity = shipcitycoll[r.Next(shipcitycoll.Length - 1)],
                IsClosed = (i % 2) == 0,
                Phone = Phonenumber[r.Next(8)],
                Percent=r.Next(1,100),
                Doubleval= r.NextDouble()
            };
        }

        DateTime[] DeliveryDate = new DateTime[]
        {
            new DateTime(2011,2,8),
            new DateTime(2011,2,2),
            new DateTime(2011,1,1),
            new DateTime(2011,3,5),
            new DateTime(2011,7,4),
            new DateTime(2011,12,8),
            new DateTime(2011,4,2),
            new DateTime(2011,8,8),
            new DateTime(2011,12,9),
            new DateTime(2011,10,12),
        };

        string[] ShipCountry = new string[]
        {
            
            "Argentina",
            "Austria",
            "Belgium",
            "Brazil",            
            "Canada",
            "Denmark",
            "Finland",
            "France",
            "Germany",
            "Ireland",
            "Italy",
            "Mexico",
            "Norway",
            "Poland",
            "Portugal",
            "Spain",
            "Sweden",
            "Switzerland",
            "UK",
            "USA",
            "Venezuela"
        };

        string[] Phonenumber = new string[]
        {
            "(206) 555-9857",
            "(206) 555-9482",
            "(206) 555-3412",
            "(206) 555-8122",
            "(71) 555-4848",
            "(71) 555-7773",
            "(71) 555-5598",
            "(206) 555-1189",
            "(71) 555-4444"
        };

        Dictionary<string, string[]> ShipCity = new Dictionary<string, string[]>();

        /// <summary>
        /// Sets the ship city.
        /// </summary>
        private void SetShipCity()
        {
            string[] argentina = new string[] { "Buenos Aires" };

            string[] austria = new string[] { "Graz", "Salzburg" };

            string[] belgium = new string[] { "Bruxelles", "Charleroi" };

            string[] brazil = new string[] { "Campinas", "Resende", "Rio de Janeiro", "São Paulo" };

            string[] canada = new string[] { "Montréal", "Tsawassen", "Vancouver" };

            string[] denmark = new string[] { "Århus", "København" };

            string[] finland = new string[] { "Helsinki", "Oulu" };

            string[] france = new string[] { "Lille", "Lyon", "Marseille", "Nantes", "Paris", "Reims", "Strasbourg", "Toulouse", "Versailles" };

            string[] germany = new string[] { "Aachen", "Berlin", "Brandenburg", "Cunewalde", "Frankfurt a.M.", "Köln", "Leipzig", "Mannheim", "München", "Münster", "Stuttgart" };

            string[] ireland = new string[] { "Cork" };

            string[] italy = new string[] { "Bergamo", "Reggio Emilia", "Torino" };

            string[] mexico = new string[] { "México D.F." };

            string[] norway = new string[] { "Stavern" };

            string[] poland = new string[] { "Warszawa" };

            string[] portugal = new string[] { "Lisboa" };

            string[] spain = new string[] { "Barcelona", "Madrid", "Sevilla" };

            string[] sweden = new string[] { "Bräcke", "Luleå" };

            string[] switzerland = new string[] { "Bern", "Genève" };

            string[] uk = new string[] { "Colchester", "Hedge End", "London" };

            string[] usa = new string[] { "Albuquerque", "Anchorage", "Boise", "Butte", "Elgin", "Eugene", "Kirkland", "Lander", "Portland", "San Francisco", "Seattle", "Walla Walla" };

            string[] venezuela = new string[] { "Barquisimeto", "Caracas", "I. de Margarita", "San Cristóbal" };

            ShipCity.Add("Argentina", argentina);
            ShipCity.Add("Austria", austria);
            ShipCity.Add("Belgium", belgium);
            ShipCity.Add("Brazil", brazil);
            ShipCity.Add("Canada", canada);
            ShipCity.Add("Denmark", denmark);
            ShipCity.Add("Finland", finland);
            ShipCity.Add("France", france);
            ShipCity.Add("Germany", germany);
            ShipCity.Add("Ireland", ireland);
            ShipCity.Add("Italy", italy);
            ShipCity.Add("Mexico", mexico);
            ShipCity.Add("Norway", norway);
            ShipCity.Add("Poland", poland);
            ShipCity.Add("Portugal", portugal);
            ShipCity.Add("Spain", spain);
            ShipCity.Add("Sweden", sweden);
            ShipCity.Add("Switzerland", switzerland);
            ShipCity.Add("UK", uk);
            ShipCity.Add("USA", usa);
            ShipCity.Add("Venezuela", venezuela);
        }

        string[] CustomerID = new string[]
        {
            "ALFKI",
            "FRANS",
            "MEREP",
            "FOLKO",
            "SIMOB",
            "WARTH",
            "VAFFE",
            "FURIB",
            "SEVES",
            "LINOD",
            "RISCU",
            "PICCO",
            "BLONP",
            "WELLI",
            "FOLIG"
        };

        string[] Phoneno = new string[]
        {
            "9420652423",
            "9123452423",
            "9420651223",
            "9420652423",
            "9420623423",
            "9235652423",
            "9942056669",
            "9942056999",
            "9677412729",
            "9677412519",
            "9842651416",
        };
    }
}
