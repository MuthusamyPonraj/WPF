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
    public class MovieDetails:NotificationObject
    {
        private string movie;
        private string imageLink;
        /// <summary>
        /// Gets or sets the image link.
        /// </summary>
        /// <value>The image link.</value>
        public string ImageLink
        {
            get
            {
                return imageLink; 
            }
            set
            {
                imageLink = value;
                RaisePropertyChanged("ImageLink");
            }
        }

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
    }
}
