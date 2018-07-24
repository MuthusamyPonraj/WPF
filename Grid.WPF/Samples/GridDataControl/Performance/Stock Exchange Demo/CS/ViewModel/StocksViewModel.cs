#region Copyright Syncfusion Inc. 2001 - 2010
// Copyright Syncfusion Inc. 2001 - 2010. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Threading;
using System.Diagnostics;
using Syncfusion.Windows.Controls.Grid;
using Syncfusion.Windows.Shared;

namespace StockExchangeDemo
{
    public class StocksViewModel : StockRepository
    {
        Random r = new Random(123345345);
        DispatcherTimer timer;
        private int noOfUpdates = 500;

        /// <summary>
        /// Initializes a new instance of the <see cref="StocksViewModel"/> class.
        /// </summary>
        public StocksViewModel()
        {            
            this.AddRows(10);
            this.timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(500);
            timer.Tick += new EventHandler(timer_Tick);
            this.StartTimer();
        }

        #region Timer and updating code

        /// <summary>
        /// Sets the interval.
        /// </summary>
        /// <param name="time">The time.</param>
        public void SetInterval(TimeSpan time)
        {
            this.timer.Interval = time;
        }

        /// <summary>
        /// Starts the timer.
        /// </summary>
        public void StartTimer()
        {
            if (!this.timer.IsEnabled)
            {
                this.timer.Start();
            }
        }

        /// <summary>
        /// Stops the timer.
        /// </summary>
        public void StopTimer()
        {
            this.timer.Stop();
        }

        /// <summary>
        /// Adds the rows.
        /// </summary>
        /// <param name="count">The count.</param>
        private void AddRows(int count)
        {
            for (int i = 0; i < count; ++i)
            {
                StockData newRec = new StockData();
                newRec.Symbol = ChangeSymbol();
                newRec.Account = ChangeAccount();
                newRec.Open = Math.Round(r.NextDouble() * 30, 2);
                newRec.LastTrade = Math.Round((1 + r.NextDouble() * 50));
                double d = r.NextDouble();
                if (d < .5)
                    newRec.Change = Math.Round(d, 2);
                else
                    newRec.Change = Math.Round(d, 2) * -1;

                newRec.PreviousClose = Math.Round(r.NextDouble() * 30, 2);
                newRec.Volume = r.Next();
                data.Add(newRec);
            }
        }

        /// <summary>
        /// Changes the symbol.
        /// </summary>
        /// <returns></returns>
        private String ChangeSymbol()
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < 3; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            return builder.ToString();
        }

        /// <summary>
        /// Changes the account.
        /// </summary>
        /// <returns></returns>
        private String ChangeAccount()
        {
            Random random = new Random();
            switch (random.Next(1, 5))
            {
                case 1: return "AmericanFunds";
                case 2: return "ChildrenCollegeSavings";
                case 3: return "DayTrading";
                case 4: return "RetirementSavings";
                default: return "FidelityFunds";
            }
        }

        /// <summary>
        /// Deletes the rows.
        /// </summary>
        /// <param name="count">The count.</param>
        private void DeleteRows(int count)
        {
            if (data.Count < count)
                return;

            for (int i = 0; i < count; ++i)
            {
                int row = r.Next(data.Count);
                data.RemoveAt(row);
            }
        }

        /// <summary>
        /// Resets the refresh frequency.
        /// </summary>
        /// <param name="changesPerTick">The changes per tick.</param>
        public void ResetRefreshFrequency(int changesPerTick)
        {
            if (this.timer == null)
            {
                return;
            }

            this.StopTimer();
            this.noOfUpdates = changesPerTick;
            this.StartTimer();
        }

        /// <summary>
        /// Handles the Tick event of the timer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void timer_Tick(object sender, EventArgs e)
        {
            int startTime = DateTime.Now.Millisecond;
            ChangeRows(noOfUpdates);
        }

        /// <summary>
        /// Changes the rows.
        /// </summary>
        /// <param name="count">The count.</param>
        private void ChangeRows(int count)
        {
            if (data.Count < count)
                count = data.Count;

            for (int i = 0; i < count; ++i)
            {
                int recNo = r.Next(data.Count);
                StockData recRow = data[recNo];
                data[recNo].LastTrade = Math.Round((1 + r.NextDouble() * 50));

                recNo = r.Next(data.Count);
                double d = r.NextDouble();
                if (d < .5)
                    data[recNo].Change = Math.Round(d, 2);
                else
                    data[recNo].Change = Math.Round(d, 2) * -1;
                
                recNo = r.Next(data.Count);

                data[recNo].Open = Math.Round(r.NextDouble() * 50, 2);

                recNo = r.Next(data.Count);
                data[recNo].PreviousClose = Math.Round(r.NextDouble() * 30, 2);

                recNo = r.Next(data.Count);
                data[recNo].Volume = r.Next();
            }
        }
        #endregion
    }
}
