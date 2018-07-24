using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using Syncfusion.Windows.Controls.Grid;
using System.Windows;
using System.Windows.Media;

namespace CustomizedDataBoundTemplateDemo
{
    public class ViewModel
    {
        private List<MovieInfo> _MovieDetails;

        /// <summary>
        /// Gets or sets the movie details.
        /// </summary>
        /// <value>The movie details.</value>
        public List<MovieInfo> MovieDetails
        {
            get
            {
                if (_MovieDetails == null)
                {
                    _MovieDetails = this.GetMovieData();
                }
                return _MovieDetails;
            }
            set
            {
                _MovieDetails = value;
            }
        }

        /// <summary>
        /// Gets the movie data.
        /// </summary>
        /// <returns></returns>
        private List<MovieInfo> GetMovieData()
        {
            var record = new List<MovieInfo>();
            if (record != null)
            {
                record.Add(new MovieInfo()
                {
                    MovieName = "Kung Fu Panda 2",
                    OrderDetails = new OrderInfo() { OrderId = "10062", Name = "Smith" },
                    MovieDetails = new MovieDetails() { Movie = "Kung Fu Panda 2", ImageLink = "Kungfupanda2.jpeg" },
                    SeatDetails = new SeatDetails() { SeatNo = "A-12", NumberOfSeats = 1 },
                    TheatreDetails = new TheatreDetails() { Theatre = "Modern", City = "New York" },
                    FoodSelection = new FoodSelectionInfo() { Pepsi = true, Coffee = false, Coke = false, Popcorn = true, Tea = false }
                });
                record.Add(new MovieInfo()
                    {
                        MovieName = "Toy Story 3",
                        OrderDetails = new OrderInfo() { OrderId = "10942", Name = "William" },
                        MovieDetails = new MovieDetails() { Movie = "Toy Story 3", ImageLink = "Toystory3.jpeg" },
                        SeatDetails = new SeatDetails() { SeatNo = "F23,24,25,26", NumberOfSeats = 4 },
                        TheatreDetails = new TheatreDetails() { Theatre = "Lodo", City = "New Jersy" },
                        FoodSelection = new FoodSelectionInfo() { Pepsi = true, Coffee = false, Coke = false, Popcorn = true, Tea = false }
                    });
                record.Add(new MovieInfo()
                {
                    MovieName = "Shrek",
                    OrderDetails = new OrderInfo() { OrderId = "10643",Name = "Johnson"  },
                    MovieDetails = new MovieDetails() { Movie = "Shrek", ImageLink = "Shrek.jpeg" },
                    SeatDetails = new SeatDetails() { SeatNo = "B-16, 17", NumberOfSeats = 2 },
                    TheatreDetails = new TheatreDetails() { Theatre = "Greek", City = "New York" },
                    FoodSelection = new FoodSelectionInfo() { Pepsi = true, Coffee = false, Coke = false, Popcorn = true, Tea = false }
                });

                record.Add(new MovieInfo()
                {
                    MovieName = "Ice Age 3",
                    OrderDetails = new OrderInfo() { OrderId = "10767", Name = "Johnson" },
                    MovieDetails = new MovieDetails() { Movie = "Ice Age3", ImageLink = "Iceage3.jpeg" },
                    SeatDetails = new SeatDetails() { SeatNo = "B-16, 17", NumberOfSeats = 2 },
                    TheatreDetails = new TheatreDetails() { Theatre = "Greek", City = "New York" },
                    FoodSelection = new FoodSelectionInfo() {  Pepsi = true, Coffee = false, Coke = false, Popcorn = true, Tea = false }
                });

                record.Add(new MovieInfo()
                {
                    MovieName = "The Hang Over Part - II",
                    OrderDetails = new OrderInfo() { OrderId = "10865", Name = "Jerald" },
                    MovieDetails = new MovieDetails() { Movie = "The Hangover Part II", ImageLink = "Thehangoverpart3.jpeg" },
                    SeatDetails = new SeatDetails() {  SeatNo = "A-12", NumberOfSeats = 1 },
                    TheatreDetails = new TheatreDetails() {Theatre = "Modern", City = "New York" },
                    FoodSelection = new FoodSelectionInfo() { Pepsi = true, Coffee = false, Coke = false, Popcorn = true, Tea = false }
                });
                record.Add(new MovieInfo()
                {
                    MovieName = "Avatar",
                    OrderDetails = new OrderInfo() { OrderId = "10765", Name = "William" },
                    MovieDetails = new MovieDetails() { Movie = "Avatar", ImageLink = "Avatar.jpeg" },
                    SeatDetails = new SeatDetails() { SeatNo = "F23,24,25,26", NumberOfSeats = 4 },
                    TheatreDetails = new TheatreDetails() { Theatre = "Lodo", City = "New Jersy" },
                    FoodSelection = new FoodSelectionInfo() { Pepsi = true, Coffee = false, Coke = false, Popcorn = true, Tea = false }
                });
            }
            return record;
        }
    }
}
