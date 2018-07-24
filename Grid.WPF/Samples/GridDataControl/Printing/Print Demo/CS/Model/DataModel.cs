using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Syncfusion.Windows.Controls.Grid;
using System.Data.SqlServerCe;
using System.Collections.ObjectModel;
using Syncfusion.Windows.Shared;

namespace PrintDemo
{
    public partial class DataModel : NotificationObject
    {
        private string _Name;

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
                RaisePropertyChanged("Name");
            }
        }

        private double _QS1;

        /// <summary>
        /// Gets or sets the Q s1.
        /// </summary>
        /// <value>The Q s1.</value>
        public double QS1
        {
            get
            {
                return _QS1;
            }
            set
            {
                _QS1 = value;
                RaisePropertyChanged("QS1");
            }
        }

        private double _QS2;

        /// <summary>
        /// Gets or sets the Q s2.
        /// </summary>
        /// <value>The Q s2.</value>
        public double QS2
        {
            get
            {
                return _QS2;
            }
            set
            {
                _QS2 = value;
                RaisePropertyChanged("QS2");
            }
        }

        private double _QS3;

        /// <summary>
        /// Gets or sets the Q s3.
        /// </summary>
        /// <value>The Q s3.</value>
        public double QS3
        {
            get
            {
                return _QS3;
            }
            set
            {
                _QS3 = value;
                RaisePropertyChanged("QS3");
            }
        }

        private double _QS4;

        /// <summary>
        /// Gets or sets the Q s4.
        /// </summary>
        /// <value>The Q s4.</value>
        public double QS4
        {
            get
            {
                return _QS4;
            }
            set
            {
                _QS4 = value;
                RaisePropertyChanged("QS4");
            }
        }

        private double _Total;

        /// <summary>
        /// Gets or sets the total.
        /// </summary>
        /// <value>The total.</value>
        public double Total
        {
            get
            {
                return _Total;
            }
            set
            {
                _Total = value;
                RaisePropertyChanged("Total");
            }
        }


        private int _Year;

        /// <summary>
        /// Gets or sets the year.
        /// </summary>
        /// <value>The year.</value>
        public int Year
        {
            get
            {
                return _Year;
            }
            set
            {
                _Year = value;
                RaisePropertyChanged("Year");
            }
        }
    }
}
