using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Syncfusion.Windows.Shared;

namespace BlendStylingDemo
{ 
    public class MovieInfo:NotificationObject
    {
        private string movie;
        private string orderId;
        private string name;
        private string seatNo;
        private string theatre;
        private string city;      

        /// <summary>
        /// Gets or sets the movie.
        /// </summary>
        /// <value>The movie.</value>
        public string Movie
        {
            get
            {
                return movie;
            }
            set
            {
                movie = value;
                RaisePropertyChanged("Movie");
            }
        }

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
                RaisePropertyChanged("Movie");
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
                RaisePropertyChanged("Movie");
            }
        }

        /// <summary>
        /// Gets or sets the seat no.
        /// </summary>
        /// <value>The seat no.</value>
        public string SeatNo
        {
            get
            {
                return seatNo;
            }
            set
            {
                seatNo = value;
                RaisePropertyChanged("Movie");
            }
        }

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
                RaisePropertyChanged("Movie");
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
                RaisePropertyChanged("Movie");
            }
        }
    }
}

