using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Syncfusion.Windows.Shared;

namespace ComboBoxCellEditorsDemo
{
    public class ShipDataModel : NotificationObject
    {

        private string _Shipcity;

        /// <summary>
        /// Gets or sets the shipcity.
        /// </summary>
        /// <value>The shipcity.</value>
        public string Shipcity
        {
            get { return _Shipcity; }
            set
            {
                _Shipcity = value;
                RaisePropertyChanged("Shipcity");
            }
        }

        private string _Shipcountry;

        /// <summary>
        /// Gets or sets the shipcountry.
        /// </summary>
        /// <value>The shipcountry.</value>
        public string Shipcountry
        {
            get { return _Shipcountry; }
            set
            {
                _Shipcountry = value;
                RaisePropertyChanged("Shipcountry");
            }
        }
    }
}
