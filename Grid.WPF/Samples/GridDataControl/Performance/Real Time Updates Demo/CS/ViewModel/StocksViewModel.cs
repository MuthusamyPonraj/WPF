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
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Threading;
using System.Diagnostics;
using System.Collections.Specialized;
using System.Collections;
using Syncfusion.Windows.Controls.Grid;
using System.Windows.Data;
using System.Windows.Controls;
using System.Windows;
using Syncfusion.Windows.Controls.Scroll;
using System.Windows.Media;
using Syncfusion.Windows.Controls.Cells;
using Syncfusion.Windows.Shared;

namespace RealTimeUpdatesDemo
{
    public class StocksViewModel : NotificationObject, IDisposable
    {
        #region Members

        ObservableCollection<StockData> data;
        Random r = new Random(123345345);
        internal DispatcherTimer timer;
        private bool enableTimer = false;
        private DelegateCommand<object> btonClick;
        private object _SelectedItem;
        private double timerValue;
        private string _ButtonContnt;
        private int noOfUpdates = 500;
        bool startLog = false;
        ArrayList StockSymbols = new ArrayList();
        string[] accounts = new string[]{
            "AmericanFunds",
            "ChildrenCollegeSavings",
            "DayTrading",
            "RetirementSavings",
            "MountainRanges",
            "FidelityFunds",
            "Mortages",
            "HousingLoands"
        };
        
        #endregion

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

        /// <summary>
        /// Gets the combo collection.
        /// </summary>
        /// <value>The combo collection.</value>
        public List<int> ComboCollection
        {
            get
            {
                return new List<int> { 500, 5000, 50000, 500000 };
            }
        }

        #region Constructor

        /// <summary>
        /// Gets or sets the selected item.
        /// </summary>
        /// <value>The selected item.</value>
        public object SelectedItem
        {
            get 
            { 
                return _SelectedItem; 
            }
            set 
            { 
                _SelectedItem = value;
                RaisePropertyChanged("SelectedItem");
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StocksViewModel"/> class.
        /// </summary>
        public StocksViewModel()
        {
            this.data = new ObservableCollection<StockData>();
            this.AddRows(1000);
            this.timer = new DispatcherTimer();
            this.ResetRefreshFrequency(500);
            timer.Interval = TimeSpan.FromMilliseconds(1);
            timer.Tick += new EventHandler(timer_Tick);
            btonClick = new DelegateCommand<object>(ButtonClicked,CanButtonClick);
            this.ButtonContnt = "Start Timer";
        }
        #endregion

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
                this.timer.IsEnabled = true;
                this.timer.Start();
            }
        }

        /// <summary>
        /// Gets or sets the timer value.
        /// </summary>
        /// <value>The timer value.</value>
        public double TimerValue
        {
            get 
            { 
                return timerValue; 
            }
            set
            {
                timerValue = value;
                this.timer.Interval = TimeSpan.FromMilliseconds(timerValue);
                RaisePropertyChanged("TimerValue");
            }
        }

        /// <summary>
        /// Gets or sets the button contnt.
        /// </summary>
        /// <value>The button contnt.</value>
        public string ButtonContnt
        {
            get 
            { 
                return _ButtonContnt; 
            }
            set 
            { 
                _ButtonContnt = value;
                RaisePropertyChanged("ButtonContnt");
            }
        }

        /// <summary>
        /// Gets the bton click.
        /// </summary>
        /// <value>The bton click.</value>
        public DelegateCommand<object> BtonClick
        {
            get { return btonClick; }
        }

        /// <summary>
        /// Determines whether this instance [can button click].
        /// </summary>
        /// <returns>
        /// 	<c>true</c> if this instance [can button click]; otherwise, <c>false</c>.
        /// </returns>
        bool CanButtonClick(object param)
        {
            return true;
        }

        /// <summary>
        /// Buttons the clicked.
        /// </summary>
        /// <param name="param">The param.</param>
        /// 
        void ButtonClicked(object param)
        {
            if (ButtonContnt.Equals("Start Timer"))
            {
                this.EnableTimer = true;
                this.startLog = true;
                this.StartTimer();
                ButtonContnt = "Stop Timer";
            }
            else
            {
                this.EnableTimer = false;
                this.startLog = false;
                this.StopTimer();
                ButtonContnt = "Start Timer";
            }
        }

        /// <summary>
        /// Stops the timer.
        /// </summary>
        public void StopTimer()
        {
            this.timer.IsEnabled = false;
            this.timer.Stop();
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
        /// Gets or sets a value indicating whether [enable timer].
        /// </summary>
        /// <value><c>true</c> if [enable timer]; otherwise, <c>false</c>.</value>
        public bool EnableTimer
        {
            get
            {
                return this.enableTimer;
            }
            set
            {
                this.enableTimer = value;
            }
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
                newRec.Account = ChangeAccount(i);
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

            do
            {
                builder = new StringBuilder();
                for (int i = 0; i < 4; i++)
                {
                    ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                    builder.Append(ch);
                }

            } while (StockSymbols.Contains(builder.ToString()));

            StockSymbols.Add(builder.ToString());
            return builder.ToString();
        }

        /// <summary>
        /// Changes the account.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        private String ChangeAccount(int index)
        {
            return accounts[index % accounts.Length];
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

            if (!this.noOfUpdates.Equals(changesPerTick))
            {
                this.StopTimer();
                this.noOfUpdates = changesPerTick;
                if (enableTimer)
                    this.StartTimer();
            }
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

                double d = r.NextDouble();
                if (d < .5)
                    data[recNo].Change = Math.Round(d, 2);
                else
                    data[recNo].Change = Math.Round(d, 2) * -1;
                data[recNo].Open = Math.Round(r.NextDouble() * 50, 2);
                data[recNo].PreviousClose = Math.Round(r.NextDouble() * 30, 2);
                data[recNo].Volume = r.Next();
            }
        }

        #endregion

        #region IDisposable Members

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            if (this.timer != null)
            {
                this.timer.Tick -= new EventHandler(timer_Tick);
                this.StopTimer();
            }
        }

        #endregion
    }
}
