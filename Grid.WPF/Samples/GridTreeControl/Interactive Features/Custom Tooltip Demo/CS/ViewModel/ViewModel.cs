using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;

namespace CustomToolTipDemo
{
    public class ViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModel"/> class.
        /// </summary>
        public ViewModel()
        {
            this.PopulateWithSampleData();
        }

        private List<CarInfo> _CarDetails;

        /// <summary>
        /// Gets or sets the car details.
        /// </summary>
        /// <value>The car details.</value>
        public List<CarInfo> CarDetails
        {
            get { return _CarDetails; }
            set { _CarDetails = value; }
        }

        private List<BitmapImage> images;

        /// <summary>
        /// Populates the with sample data.
        /// </summary>
        public void PopulateWithSampleData()
        {
            images = new List<BitmapImage>();
            CarDetails = new List<CarInfo>();
            CarDetails.Add(new CarInfo() { Title = "  BMW", ReportsTo = -1, ID = 2 });
            CarDetails.Add(new CarInfo() { Title = "  Audi", ReportsTo = -1, ID = 3 });
            CarDetails.Add(new CarInfo() { Title = "  Porsche", ReportsTo = -1, ID = 4 });
            CarDetails.Add(new CarInfo() { Title = "  VolksWagen", ReportsTo = -1, ID = 5 });
            CarDetails.Add(new CarInfo() { Title = "  Ferrari", ReportsTo = -1, ID = 7 });
            CarDetails.Add(new CarInfo() { Title = "  Ford", ReportsTo = -1, ID = 8 });
            //BMW


            CarDetails.Add(new CarInfo() { Model = "BMW-M3", ImageName = "BMW-M3", RootImage = "BMW", Cost = 68550, Tax = 0.10, Year = 2010, Weight = 1400, Height = 1, ID = 9, Rating = 5, ReportsTo = 2, Title = "M3", Features = "Hailed by some critics as the best-rounded car currently in production, the BMW M3 coupe features razor-sharp handling." });
            CarDetails.Add(new CarInfo() { Model = "BMW-Z4", ImageName = "BMW-Gina", RootImage = "BMW", Cost = 48650, Year = 2009, Tax = 0.15, Weight = 1470, Height = 1.2, ID = 10, Rating = 4, ReportsTo = 2, Title = "Z4", Features = "The Z4 M is powered by a 3.2-litre straight-six engine (S54B32). Acceleration to 60 mph (96 km/h) comes in 4.8 seconds and top speed is limited electronically to 156 mph (251 km/h)." });
            CarDetails.Add(new CarInfo() { Model = "BMW-M5", ImageName = "BMW-M5", RootImage = "BMW", Cost = 85700, Year = 2012, Tax = 0.5, Weight = 1200, Height = 1, ID = 11, Rating = 4, ReportsTo = 2, Title = "M5", Features = "The most powerful engine ever fitted in a series-produced model from BMW M GmbH, the innovative Active M Differential." });

            //Audi          

            CarDetails.Add(new CarInfo() { Model = "Audi-A3", ImageName = "Audi-A3", RootImage = "Audi", Cost = 30850, Tax = .10, Year = 2010, Weight = 1000, Height = 1.2, ID = 12, Rating = 5, ReportsTo = 3, Title = "A3", Features = "The luxurious appearance of these 17inch wheels is a refined complement to the A3. Audi has officially revealed the 3-door variant of the all-new A3." });
            CarDetails.Add(new CarInfo() { Model = "Audi-A5", ImageName = "Audi-Locus", RootImage = "Audi", Cost = 44700, Tax = .15, Year = 2009, Weight = 1600, Height = 1.6, ID = 13, Rating = 3, ReportsTo = 3, Title = "A5", Features = "A curved sharp edged line starts at the very front, flowing through the middle section.Highest levels of integrated connectivity in the segment with Audi." });
            CarDetails.Add(new CarInfo() { Model = "Audi-Q7", ImageName = "Audi-Q7", RootImage = "Audi", Cost = 51450, Tax = .5, Year = 2006, Weight = 1000, Height = 1.2, ID = 14, Rating = 5, ReportsTo = 3, Title = "Q7", Features = "German automobile manufacturer, Audi unveiled its luxury Sports Utility Vehicle (SUV) Q7 in India in 2006." });
            CarDetails.Add(new CarInfo() { Model = "Audi-R8", ImageName = "Audi-R8", RootImage = "Audi", Cost = 136800, Tax = .20, Year = 2012, Weight = 1200, Height = 1.3, ID = 15, Rating = 3, ReportsTo = 3, Title = "R8", Features = "The Audi R8 is an all-wheel-drive, mid-engined sports car that shares a platform and other mechanical components with the Lamborghini Gallardo supercar." });

            //Porsche

            CarDetails.Add(new CarInfo() { Model = "Porsche-911", ImageName = "Porsche-911", RootImage = "Porsche", Cost = 185000, Tax = .20, Year = 2012, Weight = 1000, Height = 1, ID = 16, Rating = 5, ReportsTo = 4, Title = "911", Features = "Traditionally, the 2012 Porsche 911 variants have always come with incremental improvements – be it increased power." });
            CarDetails.Add(new CarInfo() { Model = "Porsche-997", ImageName = "Porsche-997", RootImage = "Porsche", Cost = 195000, Tax = .15, Year = 2010, Weight = 800, Height = 1, ID = 18, Rating = 5, ReportsTo = 4, Title = "977", Features = "Mansory Switzerland AG, the subsidiary of its parent company situated in Germany, has presented its latest tuning program for the Porsche 997." });

            //VolksWagen

            CarDetails.Add(new CarInfo() { Model = "VolksWagen-Beetle", ImageName = "VW-JeDesign", RootImage = "VolksWagen", Cost = 20390, Tax = .25, Year = 2011, Weight = 2000, Height = 1.6, ID = 21, Rating = 5, ReportsTo = 5, Title = "Beetle", Features = "Visually, the Beetle receives a rear bumper diffuser insertted, which features openings for the twin double 90 mm tailpipes attached to rear silencer." });
            CarDetails.Add(new CarInfo() { Model = "VolksWagen-Jetta", ImageName = "VW-Jetta", RootImage = "VolksWagen", Cost = 19545, Tax = .25, Year = 2010, Weight = 2000, Height = 1.6, ID = 22, Rating = 5, ReportsTo = 5, Title = "Jetta", Features = "Sophisticated and sleek, the all-new Jetta GLI sports a honeycomb grille, red brake calipers, smoked tail lights and dual exhaust with tips." });
            CarDetails.Add(new CarInfo() { Model = "VolksWagen-Golf", ImageName = "VW-Golf", RootImage = "VolksWagen", Cost = 34590, Tax = .25, Year = 2009, Weight = 2000, Height = 1.6, ID = 21, Rating = 5, ReportsTo = 5, Title = "Golf", Features = "Air conditioning 'Climatic' Body-coloured door handles Driver's knee airbag Electrically heated and adjustable door mirrors Multifunction compute" });


            ////Ferrari

            CarDetails.Add(new CarInfo() { Model = "Ferrari-F430", ImageName = "Ferrari-430", RootImage = "Ferrari", Cost = 186925, Tax = .15, Year = 2011, Weight = 800, Height = 1, ID = 27, Rating = 2, ReportsTo = 7, Title = "F430", Features = "The new F430 Ferrari Berlinetta has a light, compact 4,300 cc 90¡ V8 engine, which punches out 490 cavalli." });
            CarDetails.Add(new CarInfo() { Model = "Ferrari-Dino-MP20", ImageName = "Ferrari-Dino", RootImage = "Ferrari", Cost = 295000, Tax = .20, Year = 2011, Weight = 800, Height = 1, ID = 28, Rating = 3, ReportsTo = 7, Title = "Dino-MP20", Features = "Mexes like other modding groups have been learning the ropes of the rFactor 2 development." });
            CarDetails.Add(new CarInfo() { Model = "Ferrari-Enzo", ImageName = "Ferrari-Enzo", RootImage = "Ferrari", Cost = 313088, Tax = .15, Year = 2010, Weight = 800, Height = 1, ID = 19, Rating = 5, ReportsTo = 7, Title = "Enzo", Features = "The race track has always been the testing ground for the advanced technological research that later went into Ferrari's road cars." });

            //Ford

            CarDetails.Add(new CarInfo() { Model = "Ford-Explorer", ImageName = "Ford-Explorer", RootImage = "Ford", Cost = 31980, Tax = .15, Year = 2011, Weight = 1200, Height = 1.8, ID = 29, Rating = 3, ReportsTo = 8, Title = "Explorer", Features = "The Ford Explorer is incredibly capable. It starts with the structure – strong and supportive, thanks to high-tech materials." });
            CarDetails.Add(new CarInfo() { Model = "Ford-EcoSport", ImageName = "Ford-AirStream", RootImage = "Ford", Cost = 30945, Tax = .20, Year = 2012, Weight = 1000, Height = 1.6, ID = 30, Rating = 2, ReportsTo = 8, Title = "EcoSport", Features = "The concept is powered by a plug-in hydrogen hybrid fuel cell drivetrain - called HySeries Drive that operates under electric power." });
            CarDetails.Add(new CarInfo() { Model = "Ford-Fiesta", ImageName = "Ford-Fiesta", RootImage = "Ford", Cost = 14100, Tax = .10, Year = 2008, Weight = 700, Height = 1.2, ID = 29, Rating = 3, ReportsTo = 8, Title = "Fiesta", Features = "Fuel efficient and fun - the 2012 Fiesta is both. The Fiesta SE with the SFE Package delivers up to 40 mpg hwy.2" });
        }
    }
}