using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Syncfusion.Windows.Shared;

namespace UnboundColumns
{
    public class CarInfo : NotificationObject
    {
        private int _Quantity;

        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        /// <value>The quantity.</value>
        public int Quantity
        {
            get
            {
                return _Quantity;
            }
            set
            {
                _Quantity = value;
                RaisePropertyChanged("Quantity");
            }
        }

        private int _Discount;

        /// <summary>
        /// Gets or sets the discount.
        /// </summary>
        /// <value>The discount.</value>
        public int Discount
        {
            get
            {
                return _Discount;
            }
            set
            {
                _Discount = value;
                RaisePropertyChanged("Discount");
            }
        }

        private double cost;

        /// <summary>
        /// Gets or sets the cost.
        /// </summary>
        /// <value>The cost.</value>
        public double Cost
        {
            get
            {
                return cost;
            }

            set
            {
                cost = value;
                RaisePropertyChanged("Cost");
            }
        }

        private double tax;

        /// <summary>
        /// Gets or sets the tax.
        /// </summary>
        /// <value>The tax.</value>
        public double Tax
        {
            get
            {
                return tax;
            }
            set
            {
                tax = value;
                RaisePropertyChanged("Tax");
            }
        }

        private int year;

        /// <summary>
        /// Gets or sets the year.
        /// </summary>
        /// <value>The year.</value>
        public int Year
        {
            get
            {
                return year;
            }
            set
            {
                year = value;
                RaisePropertyChanged("Year");
            }
        }

        int id;
        /// <summary>
        /// Gets or sets the ID.
        /// </summary>
        /// <value>The ID.</value>
        public int ID
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
                RaisePropertyChanged("ID");
            }
        }

        int reportsTo;
        /// <summary>
        /// Gets or sets the reports to.
        /// </summary>
        /// <value>The reports to.</value>
        public int ReportsTo
        {
            get
            {
                return reportsTo;
            }
            set
            {
                reportsTo = value;
                RaisePropertyChanged("ReportsTo");
            }
        }

        string model;

        /// <summary>
        /// Gets or sets the model.
        /// </summary>
        /// <value>The model.</value>
        public string Model
        {
            get
            {
                return model;
            }
            set
            {
                model = value;
                RaisePropertyChanged("Model");
            }
        }

        private string title;
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
                RaisePropertyChanged("Title");
            }
        }
    }
}
