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
    public class TheatreDetails:NotificationObject
    {
        private string theatre;
        private string city;
        /// <summary>
        /// Gets or sets the theatre.
        /// </summary>
        /// <value>The theatre.</value>
        public string Theatre
        {
            get
            {
                return theatre;
            }
            set
            {
                theatre = value;
                RaisePropertyChanged("Theatre");
            }
        }

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        /// <value>The city.</value>
        public string City
        {
            get
            {
                return city;
            }
            set
            {
                city = value;
                RaisePropertyChanged("City");
            }
        }
    }
}
