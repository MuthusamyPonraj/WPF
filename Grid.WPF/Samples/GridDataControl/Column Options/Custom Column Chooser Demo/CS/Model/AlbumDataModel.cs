using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Syncfusion.Windows.Shared;

namespace ColumnChooserCustomization
{
    public class AlbumDataModel : NotificationObject
    {

        #region Fields

        private int _trackID;

        /// <summary>
        /// Gets or sets the track ID.
        /// </summary>
        /// <value>The track ID.</value>
        public int TrackID
        {
            get { return _trackID; }
            set
            {
                _trackID = value;
                RaisePropertyChanged("TrackID");
            }
        }

        private string _title;

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                RaisePropertyChanged("Title");
            }
        }

        private double _time;

        /// <summary>
        /// Gets or sets the time.
        /// </summary>
        /// <value>The time.</value>
        public double Time
        {
            get { return _time; }
            set
            {
                _time = value;
                RaisePropertyChanged("Time");
            }
        }

        private string _artist;

        /// <summary>
        /// Gets or sets the artist.
        /// </summary>
        /// <value>The artist.</value>
        public string Artist
        {
            get { return _artist; }
            set
            {
                _artist = value;
                RaisePropertyChanged("Artist");
            }
        }

        private string _album;

        /// <summary>
        /// Gets or sets the album.
        /// </summary>
        /// <value>The album.</value>
        public string Album
        {
            get { return _album; }
            set
            {
                _album = value;
                RaisePropertyChanged("Album");
            }
        }

        private string _composer;

        /// <summary>
        /// Gets or sets the composer.
        /// </summary>
        /// <value>The composer.</value>
        public string Composer
        {
            get { return _composer; }
            set
            {
                _composer = value;
                RaisePropertyChanged("Composer");
            }
        }

        private int _releaseYear;

        /// <summary>
        /// Gets or sets the release year.
        /// </summary>
        /// <value>The release year.</value>
        public int ReleaseYear
        {
            get { return _releaseYear; }
            set
            {
                _releaseYear = value;
                RaisePropertyChanged("ReleaseYear");
            }
        }

        private string _label;

        /// <summary>
        /// Gets or sets the label.
        /// </summary>
        /// <value>The label.</value>
        public string Label
        {
            get { return _label; }
            set
            {
                _label = value;
                RaisePropertyChanged("Label");
            }
        }

        private string _type;

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        public string Type
        {
            get { return _type; }
            set
            {
                _type = value;
                RaisePropertyChanged("Type");
            }
        }
        
        private int _rating;

        /// <summary>
        /// Gets or sets the rating.
        /// </summary>
        /// <value>The rating.</value>
        public int Rating
        {
            get { return _rating; }
            set
            {
                _rating = value;
                RaisePropertyChanged("Rating");
            }
        }
        #endregion   
       
    }
}
