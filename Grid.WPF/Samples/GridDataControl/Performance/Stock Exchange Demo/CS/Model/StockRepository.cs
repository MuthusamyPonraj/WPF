using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace StockExchangeDemo
{
    public class StockRepository
    {
        public ObservableCollection<StockData> data;

        /// <summary>
        /// Initializes a new instance of the <see cref="StockRepository"/> class.
        /// </summary>
        public StockRepository()
        {
            this.data = new ObservableCollection<StockData>();
            this.InitData();
        }

        /// <summary>
        /// Inits the data.
        /// </summary>
        private void InitData()
        {
            for (int counter = 0; counter < 5; counter++)
            {
                data.Add(

                    new StockData()
                    {
                        Symbol = "MSFT",
                        Account = "AmericanFunds",
                        LastTrade = 25.81,
                        Change = 0.40,
                        PreviousClose = 25.68,
                        Open = 26.17,
                        Volume = 78120512
                    });

                data.Add(new StockData()
                {
                    Symbol = "GOOG",
                    Account = "ChildrenCollegeSavings",
                    LastTrade = 20.11,
                    Change = 0.43,
                    PreviousClose = 22.12,
                    Open = 21.23,
                    Volume = 54231243
                });
                data.Add(new StockData()
                {
                    Symbol = "YAHO",
                    Account = "DayTrading",
                    LastTrade = 33.23,
                    Change = 0.50,
                    PreviousClose = 23.23,
                    Open = 21.23,
                    Volume = 65432354
                });
                data.Add(new StockData()
                {
                    Symbol = "NBD",
                    Account = "RetirementSavings",
                    LastTrade = 24.23,
                    Change = -0.10,
                    PreviousClose = 23.23,
                    Open = 12.23,
                    Volume = 35432354
                });
                data.Add(new StockData()
                {
                    Symbol = "YSD",
                    Account = "FidelityFunds",
                    LastTrade = 9.23,
                    Change = -0.24,
                    PreviousClose = 12.10,
                    Open = 4.3,
                    Volume = 5432354
                });
            }
        }

        /// <summary>
        /// Gets the stocks.
        /// </summary>
        /// <value>The stocks.</value>
        public ObservableCollection<StockData> Stocks
        {
            get
            {
                return this.data;
            }
        }
    }
}
