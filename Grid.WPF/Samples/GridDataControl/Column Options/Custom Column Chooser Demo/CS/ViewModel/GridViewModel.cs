using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Windows.Resources;
using System.Windows;
using System.ComponentModel;
using System.Windows.Data;
using Syncfusion.Windows.Shared;
using Syncfusion.Windows.Controls.Grid;

namespace ColumnChooserCustomization
{
    public class GridViewModel : NotificationObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GridViewModel"/> class.
        /// </summary>
        public GridViewModel()
        {
            this.AlbumCollection = GetAlbumCollection();
            _ColumnChooserCommand = new DelegateCommand<object>(ColumnChooserCommandHandler);
        }

        private List<AlbumDataModel> _albumCollection;

        /// <summary>
        /// Gets or sets the album collection.
        /// </summary>
        /// <value>The album collection.</value>
        public List<AlbumDataModel> AlbumCollection
        {
            get 
            {
                return _albumCollection; 
            }
            set
            {
                _albumCollection = value;
            }
        }

        #region Delegate Command
        
        private readonly DelegateCommand<object> _ColumnChooserCommand;

        /// <summary>
        /// Gets the column chooser command.
        /// </summary>
        /// <value>The column chooser command.</value>
        public DelegateCommand<object> ColumnChooserCommand
        {
            get { return _ColumnChooserCommand; }
        }

        public void ColumnChooserCommandHandler(object param)
        {
                    
        }
        #endregion

        /// <summary>
        /// Gets the album collection.
        /// </summary>
        /// <returns></returns>
        static List<AlbumDataModel> GetAlbumCollection()
        {
            // In a real application, the data would come from an external source,
            // but for this demo let's keep things simple and use a resource file.
            string customerDataFile = @"..\..\Data\AlbumList.xml";
            using (Stream stream = GetResourceStream(customerDataFile))
            using (XmlReader xmlRdr = new XmlTextReader(stream))
                return
                    (from customerElem in XDocument.Load(xmlRdr).Element("AlbumList").Elements("Album")
                     select CreateData(
                        (int)customerElem.Attribute("TrackID"),
                        (string)customerElem.Attribute("Title"),
                        (string)customerElem.Attribute("Composer"),
                        (double)customerElem.Attribute("Time"),
                        (string)customerElem.Attribute("Artist"),
                        (string)customerElem.Attribute("Album"),
                        (int)customerElem.Attribute("ReleaseYear"),
                        (string)customerElem.Attribute("Label"),
                        (string)customerElem.Attribute("Type"),                        
                        (int)customerElem.Attribute("Rating")
                        )).ToList();
        }


        /// <summary>
        /// Creates the data.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="title">The title.</param>
        /// <param name="composer">The composer.</param>
        /// <param name="time">The time.</param>
        /// <param name="artist">The artist.</param>
        /// <param name="album">The album.</param>
        /// <param name="releaseyear">The releaseyear.</param>
        /// <param name="lable">The lable.</param>
        /// <param name="type">The type.</param>
        /// <param name="rating">The rating.</param>
        /// <returns></returns>
        static  AlbumDataModel CreateData(int id, string title, string composer, double time, string artist, string album, int releaseyear, string lable, string type, int rating)
        {
            return new AlbumDataModel
            {

                TrackID = id,
                Composer = composer,
                Title = title,
                Album = album,
                Artist = artist,
                Label = lable,
                Rating = rating,
                ReleaseYear = releaseyear,
                Time = time,
                Type = type
            };
        }

        /// <summary>
        /// Gets the resource stream.
        /// </summary>
        /// <param name="resourceFile">The resource file.</param>
        /// <returns></returns>
        static Stream GetResourceStream(string resourceFile)
        {
            Uri uri = new Uri(resourceFile, UriKind.RelativeOrAbsolute);

            StreamResourceInfo info = Application.GetResourceStream(uri);
            if (info == null || info.Stream == null)
                throw new ApplicationException("Missing resource file: " + resourceFile);

            return info.Stream;
        }       
    }
    
}
