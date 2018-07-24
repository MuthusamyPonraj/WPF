using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Syncfusion.Windows.Shared;

namespace CustomizedDataBoundTemplateDemo
{    
    public class MovieInfo:NotificationObject
    {
        private string movieName;

        /// <summary>
        /// Gets or sets the name of the movie.
        /// </summary>
        /// <value>The name of the movie.</value>
        public string MovieName
        {
            get 
            {
                return movieName; 
            }
            set
            {
                movieName = value;
                RaisePropertyChanged("MovieName");
            }
        }
        private FoodSelectionInfo foodSelection;

        /// <summary>
        /// Gets or sets the food selection.
        /// </summary>
        /// <value>The food selection.</value>
        public FoodSelectionInfo FoodSelection
        {
            get 
            {
                return foodSelection; 
            }
            set
            {
                foodSelection = value;
                RaisePropertyChanged("MovieName");
            }
        }

        private OrderInfo orderDetails;

        /// <summary>
        /// Gets or sets the order details.
        /// </summary>
        /// <value>The order details.</value>
        public OrderInfo OrderDetails
        {
            get 
            {
                return orderDetails; 
            }
            set
            {
                orderDetails = value;
                RaisePropertyChanged("OrderDetails");
            }
        }

        private MovieDetails movieDetails;

        /// <summary>
        /// Gets or sets the movie details.
        /// </summary>
        /// <value>The movie details.</value>
        public MovieDetails MovieDetails
        {
            get 
            {
                return movieDetails; 
            }
            set
            {
                movieDetails = value;
                RaisePropertyChanged("MovieDetails");
            }
        }

        private TheatreDetails theatreDetails;

        /// <summary>
        /// Gets or sets the theatre details.
        /// </summary>
        /// <value>The theatre details.</value>
        public TheatreDetails TheatreDetails
        {
            get
            {
                return theatreDetails;
            }
            set
            {
                theatreDetails = value;
                RaisePropertyChanged("TheatreDetails");
            }
        }

        private SeatDetails seatDetails;

        /// <summary>
        /// Gets or sets the seat details.
        /// </summary>
        /// <value>The seat details.</value>
        public SeatDetails SeatDetails
        {
            get
            {
                return seatDetails; 
            }
            set
            {
                seatDetails = value;
                RaisePropertyChanged("SeatDetails");
            }
        }        
    }   
}
