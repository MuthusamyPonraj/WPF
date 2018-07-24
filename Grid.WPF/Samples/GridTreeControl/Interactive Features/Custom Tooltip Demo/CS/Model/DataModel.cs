using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;
using System.Globalization;
using System.Windows.Data;
using Syncfusion.Windows.Shared;

namespace CustomToolTipDemo
{
    /// <summary>
    /// Code for Cars class
    /// </summary>
    public class CarInfo : NotificationObject
    {
        private double cost;

        /// <summary>
        /// Gets or sets the cost.
        /// </summary>
        /// <value>The cost.</value>
        public double Cost
        {
            get
            {
                return cost;
            }

            set
            {
                cost = value;
                RaisePropertyChanged("Cost");
            }
        }

        private string imageName;

        /// <summary>
        /// Gets or sets the name of the image.
        /// </summary>
        /// <value>The name of the image.</value>
        public string ImageName
        {
            get
            {
                return imageName;
            }
            set
            {
                imageName = value;
                RaisePropertyChanged("ImageName");
            }
        }

        private string features;

        /// <summary>
        /// Gets or sets the features.
        /// </summary>
        /// <value>The features.</value>
        public string Features
        {
            get
            {
                return features;
            }
            set
            {
                features = value;
                RaisePropertyChanged("Features");
            }
        }

        private string rootImage;

        /// <summary>
        /// Gets or sets the root image.
        /// </summary>
        /// <value>The root image.</value>
        public string RootImage
        {
            get
            {
                return rootImage;
            }
            set
            {
                rootImage = value;
                RaisePropertyChanged("RootImage");
            }
        }

        private double tax;

        /// <summary>
        /// Gets or sets the tax.
        /// </summary>
        /// <value>The tax.</value>
        public double Tax
        {
            get
            {
                return tax;
            }
            set
            {
                tax = value;
                RaisePropertyChanged("Tax");
            }
        }

        private int year;

        /// <summary>
        /// Gets or sets the year.
        /// </summary>
        /// <value>The year.</value>
        public int Year
        {
            get
            {
                return year;
            }
            set
            {
                year = value;
                RaisePropertyChanged("Year");
            }
        }

        int id;
        /// <summary>
        /// Gets or sets the ID.
        /// </summary>
        /// <value>The ID.</value>
        public int ID
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
                RaisePropertyChanged("ID");
            }
        }

        int reportsTo;
        /// <summary>
        /// Gets or sets the reports to.
        /// </summary>
        /// <value>The reports to.</value>
        public int ReportsTo
        {
            get
            {
                return reportsTo;
            }
            set
            {
                reportsTo = value;
                RaisePropertyChanged("ReportsTo");
            }
        }

        string model;

        /// <summary>
        /// Gets or sets the model.
        /// </summary>
        /// <value>The model.</value>
        public string Model
        {
            get
            {
                return model;
            }
            set
            {
                model = value;
                RaisePropertyChanged("Model");
            }
        }

        private string title;
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
                RaisePropertyChanged("Title");
            }
        }

        int? rating;
        /// <summary>
        /// Gets or sets the rating.
        /// </summary>
        /// <value>The rating.</value>
        public int? Rating
        {
            get
            {
                return rating;
            }
            set
            {
                rating = value;
                RaisePropertyChanged("Rating");
            }
        }

        int imageIndex;
        /// <summary>
        /// Gets or sets the index of the image.
        /// </summary>
        /// <value>The index of the image.</value>
        public int ImageIndex
        {
            get
            {
                return imageIndex;
            }
            set
            {
                imageIndex = value;
                RaisePropertyChanged("ImageIndex");
            }
        }

        double? height;
        /// <summary>
        /// Gets or sets the height.
        /// </summary>
        /// <value>The height.</value>
        public double? Height
        {
            get
            {
                return height;
            }
            set
            {
                height = value;
                RaisePropertyChanged("Height");
            }
        }

        double? weight;
        /// <summary>
        /// Gets or sets the weight.
        /// </summary>
        /// <value>The weight.</value>
        public double? Weight
        {
            get
            {
                return weight;
            }
            set
            {
                weight = value;
                RaisePropertyChanged("Weight");
            }
        }
    }
}
