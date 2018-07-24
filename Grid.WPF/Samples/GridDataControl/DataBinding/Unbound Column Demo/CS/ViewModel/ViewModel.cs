using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Collections;
using System.ComponentModel;
using Syncfusion.Windows.Controls.Grid;

namespace UnboundColumnDemo
{
    class ViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModel"/> class.
        /// </summary>
        public ViewModel()
        {
            
            CountryDetails = GetCountryDetails();
        }

        private ObservableCollection<CountryDetails> _countryDetails;

        /// <summary>
        /// Gets or sets the country details.
        /// </summary>
        /// <value>The country details.</value>
        public ObservableCollection<CountryDetails> CountryDetails
        {
            get
            {
                return _countryDetails;
            }
            set
            {
                _countryDetails = value;
            }
        }

        /// <summary>
        /// Gets the country details.
        /// </summary>
        /// <returns></returns>
        private ObservableCollection<CountryDetails> GetCountryDetails()
        {
            ObservableCollection<CountryDetails> CountryDetails = new ObservableCollection<CountryDetails>();
            CountryDetails.Add(new CountryDetails()
            {
                CountryName = "China",
                Area = 9596960.00,
                Image = @"..\..\Images\China.jpg",
                Population = 1339190000,
                RankInPopulation = 1,
                RankinArea = 4,
                PopulationPercentage = Math.Round((1339190000.00 / 6965000000.00) * 100, 2)

            });

            CountryDetails.Add(new CountryDetails()
            {
                CountryName = "India",
                Area = 3287590.00,
                Image = @"..\..\Images\India.jpg",
                Population = 1184639000,
                RankInPopulation = 2,
                RankinArea = 7,
                PopulationPercentage = Math.Round((1184639000.00 / 6965000000.00) * 100, 2)

            });
            CountryDetails.Add(new CountryDetails()
            {
                CountryName = "USA",
                Area = 9629091.00,
                Image = @"..\..\Images\USA.jpg",
                Population = 309975000,
                RankInPopulation = 3,
                RankinArea = 3,
                PopulationPercentage = Math.Round((309975000.00 / 6965000000.00) * 100, 2)

            });
            CountryDetails.Add(new CountryDetails()
            {
                CountryName = "Indonesia",
                Area = 1919440.00,
                Image = @"..\..\Images\Indonesia.jpg",
                Population = 234181400,
                RankInPopulation = 4,
                RankinArea = 15,
                PopulationPercentage = Math.Round((234181400.00 / 6965000000.00) * 100, 2)

            });
            CountryDetails.Add(new CountryDetails()
            {
                CountryName = "Brazil",
                Area = 8511965.00,
                Image = @"..\..\Images\Brazil.jpg",
                Population = 193364000,
                RankInPopulation = 5,
                RankinArea = 5,
                PopulationPercentage = Math.Round((193364000.00 / 6965000000.00) * 100, 2)

            });

            CountryDetails.Add(new CountryDetails()
            {
                CountryName = "Pakistan",
                Area = 803940.00,
                Image = @"..\..\Images\Pakistan.jpg",
                Population = 170260000,
                RankInPopulation = 6,
                RankinArea = 36,
                PopulationPercentage = Math.Round((170260000.00 / 6965000000.00) * 100, 2)

            });
            CountryDetails.Add(new CountryDetails()
            {
                CountryName = "Bangladesh",
                Area = 144000.00,
                Image = @"..\..\Images\Bangladesh.jpg",
                Population = 164425000,
                RankInPopulation = 7,
                RankinArea = 95,
                PopulationPercentage = Math.Round((164425000.00 / 6965000000.00) * 100, 2)

            });
            CountryDetails.Add(new CountryDetails()
            {
                CountryName = "Nigeria",
                Area = 923768.00,
                Image = @"..\..\Images\Nigeria.jpg",
                Population = 158259000,
                RankInPopulation = 8,
                RankinArea = 32,
                PopulationPercentage = Math.Round((158259000.00 / 6965000000.00) * 100, 2)


            });
            CountryDetails.Add(new CountryDetails()
            {
                CountryName = "Russia",
                Area = 17075200.00,
                Image = @"..\..\Images\Russia.jpg",
                Population = 141927297,
                RankInPopulation = 9,
                RankinArea = 1,
                PopulationPercentage = Math.Round((141927297.00 / 6965000000.00) * 100, 2)

            });
            CountryDetails.Add(new CountryDetails()
            {
                CountryName = "Japan",
                Area = 377835.00,
                Image = @"..\..\Images\Japan.jpg",
                Population = 127380000,
                RankInPopulation = 10,
                RankinArea = 62,
                PopulationPercentage = Math.Round((127380000.00 / 6965000000.00) * 100, 2)
            }); 
            return CountryDetails;            
        }       
    }
}
