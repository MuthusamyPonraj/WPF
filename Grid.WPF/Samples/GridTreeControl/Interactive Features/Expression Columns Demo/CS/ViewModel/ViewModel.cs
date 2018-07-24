using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnboundColumns
{
    public class ViewModel
    {
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

        /// <summary>
        /// Populates the with sample data.
        /// </summary>
        public void PopulateWithSampleData()
        {
            Random r = new Random();
            CarDetails = new List<CarInfo>();
            CarDetails.Add(new CarInfo() { Title = "  BMW", ReportsTo = -1, ID = 2 });
            CarDetails.Add(new CarInfo() { Title = "  Audi", ReportsTo = -1, ID = 3 });
            CarDetails.Add(new CarInfo() { Title = "  Porsche", ReportsTo = -1, ID = 4 });
            CarDetails.Add(new CarInfo() { Title = "  VolksWagen", ReportsTo = -1, ID = 5 });
            CarDetails.Add(new CarInfo() { Title = "  Ferrari", ReportsTo = -1, ID = 7 });
            CarDetails.Add(new CarInfo() { Title = "  Ford", ReportsTo = -1, ID = 8 });
            //BMW

            CarDetails.Add(new CarInfo() { Model = "BMW-M3", Cost = 68550, Tax = 0.10, Year = 2010, ID=9, Quantity = r.Next(1, 25), Discount = r.Next(1, 8), ReportsTo = 2, Title = "M3" });
            CarDetails.Add(new CarInfo() { Model = "BMW-Z4", Cost = 48650, Year = 2009, Tax = 0.15, ID=10, Quantity = r.Next(1, 25), Discount = r.Next(1, 8), ReportsTo = 2, Title = "Z4" });
            CarDetails.Add(new CarInfo() { Model = "BMW-M5", Cost = 85700, Year = 2012, Tax = 0.5, ID=11, Quantity = r.Next(1, 25), Discount = r.Next(1, 8), ReportsTo = 2, Title = "M5" });

            //Audi          

            CarDetails.Add(new CarInfo() { Model = "Audi-A3", Cost = 30850, Tax = .10, Year = 2010, Quantity = r.Next(1, 25), Discount = r.Next(1, 8), ID = 12, ReportsTo = 3, Title = "A3" });
            CarDetails.Add(new CarInfo() { Model = "Audi-A5", Cost = 44700, Tax = .15, Year = 2009, Quantity = r.Next(1, 25), Discount = r.Next(1, 8), ID = 13, ReportsTo = 3, Title = "A5" });
            CarDetails.Add(new CarInfo() { Model = "Audi-Q7", Cost = 51450, Tax = .5, Year = 2006, Quantity = r.Next(1, 25), Discount = r.Next(1, 8), ID = 14, ReportsTo = 3, Title = "Q7" });
            CarDetails.Add(new CarInfo() { Model = "Audi-R8", Cost = 136800, Tax = .20, Year = 2012, Quantity = r.Next(1, 25), Discount = r.Next(1, 8), ID = 15, ReportsTo = 3, Title = "R8" });

            //Porsche

            CarDetails.Add(new CarInfo() { Model = "Porsche-911", Cost = 185000, Tax = .20, Year = 2012, Quantity = r.Next(1, 25), Discount = r.Next(1, 8), ID = 16, ReportsTo = 4, Title = "911" });
            CarDetails.Add(new CarInfo() { Model = "Porsche-997", Cost = 195000, Tax = .15, Year = 2010, Quantity = r.Next(1, 25), Discount = r.Next(1, 8), ID = 18, ReportsTo = 4, Title = "977" });

            //VolksWagen

            CarDetails.Add(new CarInfo() { Model = "VolksWagen-Beetle", Cost = 20390, Tax = .25, Year = 2011, Quantity = r.Next(1, 25), Discount = r.Next(1, 8), ID = 21, ReportsTo = 5, Title = "Beetle" });
            CarDetails.Add(new CarInfo() { Model = "VolksWagen-Jetta", Cost = 19545, Tax = .25, Year = 2010, Quantity = r.Next(1, 25), Discount = r.Next(1, 8), ID = 22, ReportsTo = 5, Title = "Jetta" });
            CarDetails.Add(new CarInfo() { Model = "VolksWagen-Golf", Cost = 34590, Tax = .25, Year = 2009, Quantity = r.Next(1, 25), Discount = r.Next(1, 8), ID = 23, ReportsTo = 5, Title = "Golf" });

            ////Ferrari

            CarDetails.Add(new CarInfo() { Model = "Ferrari-F430", Cost = 186925, Tax = .15, Year = 2011, Quantity = r.Next(1, 25), Discount = r.Next(1, 8), ID = 27, ReportsTo = 7, Title = "F430" });
            CarDetails.Add(new CarInfo() { Model = "Ferrari-Dino-MP20", Cost = 295000, Tax = .20, Year = 2011, Quantity = r.Next(1, 25), Discount = r.Next(1, 8), ID = 28, ReportsTo = 7, Title = "Dino-MP20" });
            CarDetails.Add(new CarInfo() { Model = "Ferrari-Enzo", Cost = 313088, Tax = .15, Year = 2010, Quantity = r.Next(1, 25), Discount = r.Next(1, 8), ID = 19, ReportsTo = 7, Title = "Enzo" });

            //Ford

            CarDetails.Add(new CarInfo() { Model = "Ford-Explorer", Cost = 31980, Tax = .15, Year = 2011, Quantity = r.Next(1, 25), Discount = r.Next(1, 8), ID = 29, ReportsTo = 8, Title = "Explorer" });
            CarDetails.Add(new CarInfo() { Model = "Ford-EcoSport", Cost = 30945, Tax = .20, Year = 2012, Quantity = r.Next(1, 25), Discount = r.Next(1, 8), ID = 30, ReportsTo = 8, Title = "EcoSport" });
            CarDetails.Add(new CarInfo() { Model = "Ford-Fiesta", Cost = 14100, Tax = .10, Year = 2008, Quantity = r.Next(1, 25), Discount = r.Next(1, 8), ID = 29, ReportsTo = 8, Title = "Fiesta" });
        }
    }
}
