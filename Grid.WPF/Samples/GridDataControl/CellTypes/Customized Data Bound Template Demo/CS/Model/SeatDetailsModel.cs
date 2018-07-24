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
    public class SeatDetails:NotificationObject
    {
        private string seatNo;
        private int numberOfSeats;

        /// <summary>
        /// Gets or sets the number of seats.
        /// </summary>
        /// <value>The number of seats.</value>
        public int NumberOfSeats
        {
            get
            {
                return numberOfSeats; 
            }
            set
            {
                numberOfSeats = value;
                RaisePropertyChanged("NumberOfSeats");
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
                RaisePropertyChanged("SeatNo");
            }
        }
    }
}
