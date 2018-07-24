using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Syncfusion.Windows.Controls.Grid;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Data;
using System.Collections;

namespace BlendStylingDemo
{    

    class ViewModel
    {
        #region PrivateMembers
        private List<MovieInfo> movieDetails;        
        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModel"/> class.
        /// </summary>
        public ViewModel()
        {
            MovieDetails = this.GetMovieRecords();
            
        }
        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the movie details.
        /// </summary>
        /// <value>The movie details.</value>
        public List<MovieInfo> MovieDetails
        {
            get
            {
                return movieDetails;
            }
            set
            {
                movieDetails = value;                
            }
        }
        #endregion

        #region Private Method

        /// <summary>
        /// Gets the movie records.
        /// </summary>
        /// <returns></returns>
        public List<MovieInfo> GetMovieRecords()
        {
            List<MovieInfo> moviesRecord = new List<MovieInfo>();
            moviesRecord.Add(new MovieInfo() { OrderId = "10062", Movie = "Kung Fu Panda 2", Name = "Smith", SeatNo = "A-12", Theatre = "Modern", City = "Canada" });
            moviesRecord.Add(new MovieInfo() { OrderId = "10942", Movie = "Toy Story 3", Name = "William", SeatNo = "F23,24,25,26", Theatre = "Lodo", City = "UK" });
            moviesRecord.Add(new MovieInfo() { OrderId = "10643", Movie = "Shrek", Name = "Johnson", SeatNo = "B-16, 17", Theatre = "Greek", City = "Canada" });
            moviesRecord.Add(new MovieInfo() { OrderId = "10645", Movie = "The Priest", Name = "Smith", SeatNo = "A-12", Theatre = "Modern", City = "Canada" });
            moviesRecord.Add(new MovieInfo() { OrderId = "10765", Movie = "Avatar", Name = "William", SeatNo = "F23,24,25,26", Theatre = "Lodo", City = "UK" });
            moviesRecord.Add(new MovieInfo() { OrderId = "10767", Movie = "Ice Age3", Name = "Johnson", SeatNo = "B-16, 17", Theatre = "Greek", City = "Canada" });
            moviesRecord.Add(new MovieInfo() { OrderId = "10865", Movie = "The Hangover Part II", Name = "Smith", SeatNo = "A-12", Theatre = "Modern", City = "Canada" });
            moviesRecord.Add(new MovieInfo() { OrderId = "10978", Movie = "Kung Fu Panda 2", Name = "William", SeatNo = "F23,24,25,26", Theatre = "Lodo", City = "UK" });
            moviesRecord.Add(new MovieInfo() { OrderId = "10567", Movie = "Up", Name = "Johnson", SeatNo = "B-16, 17", Theatre = "Greek", City = "Canada" });
            moviesRecord.Add(new MovieInfo() { OrderId = "10062", Movie = "Toy Story 3", Name = "Smith", SeatNo = "A-12", Theatre = "Modern", City = "Canada" });
            moviesRecord.Add(new MovieInfo() { OrderId = "10942", Movie = "Shrek", Name = "William", SeatNo = "F23,24,25,26", Theatre = "Lodo", City = "UK" });
            moviesRecord.Add(new MovieInfo() { OrderId = "10643", Movie = "The Priest", Name = "Johnson", SeatNo = "B-16, 17", Theatre = "Greek", City = "Canada" });
            moviesRecord.Add(new MovieInfo() { OrderId = "10645", Movie = "Avatar", Name = "Smith", SeatNo = "A-12", Theatre = "Modern", City = "Canada" });
            moviesRecord.Add(new MovieInfo() { OrderId = "10765", Movie = "Ice Age3", Name = "William", SeatNo = "F23,24,25,26", Theatre = "Lodo", City = "UK" });
            moviesRecord.Add(new MovieInfo() { OrderId = "10767", Movie = "The Priest", Name = "Johnson", SeatNo = "B-16, 17", Theatre = "Greek", City = "Canada" });
            moviesRecord.Add(new MovieInfo() { OrderId = "10865", Movie = "The Hangover Part II", Name = "Smith", SeatNo = "A-12", Theatre = "Modern", City = "Canada" });
            moviesRecord.Add(new MovieInfo() { OrderId = "10978", Movie = "Ice Age3", Name = "William", SeatNo = "F23,24,25,26", Theatre = "Lodo", City = "UK" });
            moviesRecord.Add(new MovieInfo() { OrderId = "10567", Movie = "Avatar", Name = "Johnson", SeatNo = "B-16, 17", Theatre = "Greek", City = "Canada" });
            moviesRecord.Add(new MovieInfo() { OrderId = "10062", Movie = "Toy Story 3", Name = "Smith", SeatNo = "A-12", Theatre = "Modern", City = "Canada" });
            moviesRecord.Add(new MovieInfo() { OrderId = "10942", Movie = "Shrek", Name = "William", SeatNo = "F23,24,25,26", Theatre = "Lodo", City = "UK" });
            moviesRecord.Add(new MovieInfo() { OrderId = "10643", Movie = "Up", Name = "Johnson", SeatNo = "B-16, 17", Theatre = "Greek", City = "Canada" });
            moviesRecord.Add(new MovieInfo() { OrderId = "10645", Movie = "Up", Name = "Smith", SeatNo = "A-12", Theatre = "Modern", City = "Canada" });
            moviesRecord.Add(new MovieInfo() { OrderId = "10765", Movie = "The Priest", Name = "William", SeatNo = "F23,24,25,26", Theatre = "Lodo", City = "UK" });
            moviesRecord.Add(new MovieInfo() { OrderId = "10767", Movie = "The Hangover Part II", Name = "Johnson", SeatNo = "B-16, 17", Theatre = "Greek", City = "Canada" });
            moviesRecord.Add(new MovieInfo() { OrderId = "10865", Movie = "Toy Story 3", Name = "Smith", SeatNo = "A-12", Theatre = "Modern", City = "Canada" });
            moviesRecord.Add(new MovieInfo() { OrderId = "10978", Movie = "The Hangover Part II", Name = "William", SeatNo = "F23,24,25,26", Theatre = "Lodo", City = "UK" });
            moviesRecord.Add(new MovieInfo() { OrderId = "10567", Movie = "Shrek", Name = "Johnson", SeatNo = "B-16, 17", Theatre = "Greek", City = "Canada" });
            return moviesRecord;
        }
        #endregion
    }
}
