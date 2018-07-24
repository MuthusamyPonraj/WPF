using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Data;
using Syncfusion.Windows.Shared;

namespace DataBoundTemplateDemo
{
    public class CustomerDetails : NotificationObject
    {
        private string _CustomerID;

        /// <summary>
        /// Gets or sets the customer ID.
        /// </summary>
        /// <value>The customer ID.</value>
        public string CustomerID
        {
            get
            {
                return _CustomerID;
            }
            set
            {
                _CustomerID = value;
                RaisePropertyChanged("CustomerID");
            }
        }

        private string _Name;

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name
        {
            get 
            { 
                return _Name; }
            set 
            { 
                _Name = value;
                RaisePropertyChanged("Name");
            }
        }
    }
}
