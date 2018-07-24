#region Copyright Syncfusion Inc. 2001 - 2011
// Copyright Syncfusion Inc. 2001 - 2011. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Syncfusion.Windows.Shared;

namespace BlendStylingDemo
{
    public class BookInfo : NotificationObject
    {
        /// <summary>
        /// Gets or sets the ISBN.
        /// </summary>
        /// <value>The ISBN.</value>
        private string _isbn;
        public string ISBN
        {
            get
            {
                return _isbn;
            }
            set
            {
                _isbn = value;
                RaisePropertyChanged("ISBN");
            }
        }

        /// <summary>
        /// Gets or sets the name of the author.
        /// </summary>
        /// <value>The name of the author.</value>
        private string _authorname;
        public string AuthorName
        {
            get
            {
                return _authorname;
            }
            set
            {
                _authorname = value;
                RaisePropertyChanged("AuthorName");
            }
        }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        private string _title;
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
                RaisePropertyChanged("Title");
            }
        }

        /// <summary>
        /// Gets or sets the pulication year.
        /// </summary>
        /// <value>The pulication year.</value>
        private string _PulicationYear;
        public string PulicationYear
        {
            get
            {
                return _PulicationYear;
            }
            set
            {
                _PulicationYear = value;
                RaisePropertyChanged("PulicationYear");
            }
        }

        /// <summary>
        /// Gets or sets the name of the publisher.
        /// </summary>
        /// <value>The name of the publisher.</value>
        private string _publishername;
        public string PublisherName
        {
            get
            {
                return _publishername;
            }
            set
            {
                _publishername = value;
                RaisePropertyChanged("PublisherName");
            }
        }

        /// <summary>
        /// Gets or sets the binding.
        /// </summary>
        /// <value>The binding.</value>
        private string _binding;
        public string Binding
        {
            get
            {
                return _binding;
            }
            set
            {
                _binding = value;
            }
        }

        /// <summary>
        /// Gets or sets the retail price.
        /// </summary>
        /// <value>The retail price.</value>
        private double _retailprice;
        public double RetailPrice
        {
            get
            {
                return _retailprice;
            }
            set
            {
                _retailprice = value;
                RaisePropertyChanged("RetailPrice");
            }
        }

        /// <summary>
        /// Gets or sets the no in hand.
        /// </summary>
        /// <value>The no in hand.</value>
        private int _noinhand;
        public int NoInHand
        {
            get
            {
                return _noinhand;
            }
            set
            {
                _noinhand = value;
                RaisePropertyChanged("NoInHand");
            }
        }

        List<BookInfo> _children;
        /// <summary>
        /// Gets or sets the children.
        /// </summary>
        /// <value>The children.</value>
        public List<BookInfo> Children
        {
            get
            {
                return _children;
            }
            set
            {
                _children = value;
                RaisePropertyChanged("Children");
            }
        }
    }
}

