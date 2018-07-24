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
using Syncfusion.Windows.Shared;

namespace CustomizedDataBoundTemplateDemo
{
    public class OrderInfo:NotificationObject
    {
        private string orderId;

        private string name;

        /// <summary>
        /// Gets or sets the order id.
        /// </summary>
        /// <value>The order id.</value>
        public string OrderId
        {
            get
            {
                return orderId;
            }
            set
            {
                orderId = value;
                RaisePropertyChanged("OrderId");
            }
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                RaisePropertyChanged("Name");
            }
        }
    }
}
