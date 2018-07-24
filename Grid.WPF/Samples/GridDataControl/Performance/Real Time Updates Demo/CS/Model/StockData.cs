using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Syncfusion.Windows.Shared;

namespace RealTimeUpdatesDemo
{
    public class StockData : NotificationObject, INotifyPropertyChanging
    {
        #region Private Members

        private string symbol;
        private string account;
        private double lastTrade;
        private double change;
        private double previousClose;
        private double open;
        private long volume;

        #endregion

        /// <summary>
        /// Gets or sets the symbol.
        /// </summary>
        /// <value>The symbol.</value>
        public string Symbol
        {
            get
            {
                return symbol;
            }
            set
            {
                this.OnPropertyChanging("Symbol"); 
                symbol = value;
                RaisePropertyChanged("Symbol");
            }
        }

        /// <summary>
        /// Gets or sets the account.
        /// </summary>
        /// <value>The account.</value>
        public string Account
        {
            get
            {
                return account;
            }
            set
            {
                this.OnPropertyChanging("Account"); 
                account = value;
                RaisePropertyChanged("Account");
            }
        }

        /// <summary>
        /// Gets or sets the last trade.
        /// </summary>
        /// <value>The last trade.</value>
        public double LastTrade
        {
            get
            {
                return lastTrade;
            }
            set
            {
                this.OnPropertyChanging("LastTrade"); 
                lastTrade = value;
                RaisePropertyChanged("LastTrade");
            }
        }

        /// <summary>
        /// Gets or sets the change.
        /// </summary>
        /// <value>The change.</value>
        public double Change
        {
            get
            {
                return change;
            }
            set
            {
                this.OnPropertyChanging("Change"); 
                change = value;
                RaisePropertyChanged("Change");
            }
        }

        /// <summary>
        /// Gets or sets the previous close.
        /// </summary>
        /// <value>The previous close.</value>
        public double PreviousClose
        {
            get
            {
                return previousClose;
            }
            set
            {
                this.OnPropertyChanging("PreviousClose"); 
                previousClose = value;
                RaisePropertyChanged("PreviousClose");
            }
        }

        /// <summary>
        /// Gets or sets the open.
        /// </summary>
        /// <value>The open.</value>
        public double Open
        {
            get
            {
                return open;
            }
            set
            {
                this.OnPropertyChanging("Open"); 
                open = value;
                RaisePropertyChanged("Open");
            }
        }

        /// <summary>
        /// Gets or sets the volume.
        /// </summary>
        /// <value>The volume.</value>
        public long Volume
        {
            get
            {
                return volume;
            }
            set
            {
                this.OnPropertyChanging("Volume"); 
                volume = value;
                RaisePropertyChanged("Volume");
            }
        }

        /// <summary>
        /// Initializes the on.
        /// </summary>
        /// <param name="other">The other.</param>
        public void InitializeOn(StockData other)
        {
            this.Symbol = other.Symbol;
            this.LastTrade = other.LastTrade;
            this.Change = other.Change;
            this.PreviousClose = other.PreviousClose;
            this.Open = other.Open;
            this.Volume = other.Volume;
        }

        #region INotifyPropertyChanging Members

        public event PropertyChangingEventHandler PropertyChanging;

        /// <summary>
        /// Called when [property changing].
        /// </summary>
        /// <param name="name">The name.</param>
        protected virtual void OnPropertyChanging(string name)
        {
            if (PropertyChanging != null)
            {
                PropertyChanging(this, new PropertyChangingEventArgs(name));
            }
        }
        #endregion
    }
}
