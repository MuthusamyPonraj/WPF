using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Syncfusion.Windows.Controls.Schedule;

namespace Basic_Schedule_Demo
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Window1"/> class.
        /// </summary>
        public Window1()
        {
            InitializeComponent();
            this.DataContext = this;
            schedule.MoveToDate(new DateTime(2010, 6, 21));
        }
        private ScheduleType[] scheduleTypeCollection = { ScheduleType.Day, ScheduleType.WorkWeek, ScheduleType.Week, ScheduleType.Month, ScheduleType.ScheduleView };
        /// <summary>
        /// Gets or sets the schedule type collection.
        /// </summary>
        /// <value>The schedule type collection.</value>
        public ScheduleType[] ScheduleTypeCollection
        {
            get
            {
                return scheduleTypeCollection;
            }
            internal set
            {
                scheduleTypeCollection = value;
            }
        }

        /// <summary>
        /// Handles the Checked event of the CalenderVisibilitySelection control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void CalenderVisibilitySelection_Checked(object sender, RoutedEventArgs e)
        {
            if ((sender as CheckBox).IsChecked.Value)
            {
                schedule.CalendarVisibility = Visibility.Visible;
            }
            else
            {
                schedule.CalendarVisibility = Visibility.Collapsed;
            }
        }
        private TimeSpan[] thresholdTimeCollection = { new TimeSpan(0, 0, 0), new TimeSpan(0, 5, 0), new TimeSpan(0, 10, 0), new TimeSpan(0, 15, 0), new TimeSpan(0, 30, 0), new TimeSpan(1, 0, 0) };
        /// <summary>
        /// Gets or sets the threshold time collection.
        /// </summary>
        /// <value>The threshold time collection.</value>
        public TimeSpan[] ThresholdTimeCollection
        {
            get
            {
                return thresholdTimeCollection;
            }
            internal set
            {
                thresholdTimeCollection = value;
            }
        }

    }
}
