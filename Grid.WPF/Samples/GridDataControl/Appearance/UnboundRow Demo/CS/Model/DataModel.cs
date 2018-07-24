using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using Syncfusion.Windows.Shared;

namespace UnBoundRowDemo
{
    public class CountryDetails:NotificationObject
    {
        private string _countryName;
        /// <summary>
        /// Gets or sets the name of the country.
        /// </summary>
        /// <value>The name of the country.</value>
        public string CountryName
        {
            get
            {
                return _countryName;
            }
            set
            {
                _countryName = value;
                RaisePropertyChanged("CountryName");
            }
        }

        private double _population;
        /// <summary>
        /// Gets or sets the population.
        /// </summary>
        /// <value>The population.</value>
        public double Population
        {
            get
            {
                return _population;
            }
            set
            {
                _population = value;
                RaisePropertyChanged("Population");
            }
        }

        private double _area;
        /// <summary>
        /// Gets or sets the area.
        /// </summary>
        /// <value>The area.</value>
        public double Area
        {
            get
            {
                return _area;
            }
            set
            {
                _area = value;
                RaisePropertyChanged("Area");
            }
        }

        private string _image;
        /// <summary>
        /// Gets or sets the image.
        /// </summary>
        /// <value>The image.</value>
        public string Image
        {
            get
            {
                return _image;
            }
            set
            {
                _image = value;
                RaisePropertyChanged("Image");
            }
        }

        private int _rankInPopulation;
        /// <summary>
        /// Gets or sets the rank in population.
        /// </summary>
        /// <value>The rank in population.</value>
        public int RankInPopulation
        {
            get
            {
                return _rankInPopulation;
            }
            set
            {
                _rankInPopulation = value;
                RaisePropertyChanged("RankInPopulation");
            }
        }

        private int _rankinArea;
        /// <summary>
        /// Gets or sets the rankin area.
        /// </summary>
        /// <value>The rankin area.</value>
        public int RankinArea
        {
            get
            {
                return _rankinArea;
            }
            set
            {
                _rankinArea = value;
                RaisePropertyChanged("RankinArea");
            }
        }

        private double _populationPercentage;
        /// <summary>
        /// Gets or sets the population percentage.
        /// </summary>
        /// <value>The population percentage.</value>
        public double PopulationPercentage
        {
            get
            {
                return _populationPercentage;
            }
            set
            {
                _populationPercentage = value;
                RaisePropertyChanged("PopulationPercentage");
            }
        }

        private double _populationDensity;
        /// <summary>
        /// Gets or sets the population density.
        /// </summary>
        /// <value>The population density.</value>
        public double PopulationDensity
        {
            get
            {
                return _populationDensity;
            }
            set
            {
                _populationDensity = value;
                RaisePropertyChanged("PopulationDensity");
            }
        }
    }  
}
