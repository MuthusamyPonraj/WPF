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
       
        private ScheduleType[] scheduleTypeCollection = { ScheduleType.Day, ScheduleType.WorkWeek, ScheduleType.Week, ScheduleType.ScheduleView, ScheduleType.Month };
        /// <summary>
        /// Gets the schedule type collection.
        /// </summary>
        /// <value>The schedule type collection.</value>
        public ScheduleType[] ScheduleTypeCollection
        {
            get
            {
                return scheduleTypeCollection;
            }
        }
        private TimeInterval[] timeIntervalCollection = { TimeInterval.FiveMin, TimeInterval.SixMin, TimeInterval.TenMin, TimeInterval.FifteenMin, TimeInterval.TwentyMin, TimeInterval.ThirtyMin, TimeInterval.OneHour };
        /// <summary>
        /// Gets or sets the time interval collection.
        /// </summary>
        /// <value>The time interval collection.</value>
        public TimeInterval[] TimeIntervalCollection
        {
            get
            {
                return timeIntervalCollection;
            }
            internal set
            {
                timeIntervalCollection = value;
            }
        }

        private Visibility[] scheduleCalendarVisibilityCollection = { Visibility.Visible, Visibility.Collapsed };
        /// <summary>
        /// Gets or sets the schedule calendar visibility collection.
        /// </summary>
        /// <value>The schedule calendar visibility collection.</value>
        public Visibility[] ScheduleCalendarVisibilityCollection
        {
            get
            {
                return scheduleCalendarVisibilityCollection;
            }
            internal set
            {
                scheduleCalendarVisibilityCollection = value;
            }
        }

        private int[] calenderCountSelectionCollection = { 1, 2, 3 };
        /// <summary>
        /// Gets or sets the calender count selection collection.
        /// </summary>
        /// <value>The calender count selection collection.</value>
        public int[] CalenderCountSelectionCollection
        {
            get
            {
                return calenderCountSelectionCollection;
            }
            internal set
            {
                calenderCountSelectionCollection = value;
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

        /// <summary>
        /// Handles the Checked event of the TitleBarVisibilitySelection control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void TitleBarVisibilitySelection_Checked(object sender, RoutedEventArgs e)
        {
            if ((sender as CheckBox).IsChecked.Value)
            {
                schedule.TitleBarVisibility = Visibility.Visible;
            }
            else
            {
                schedule.TitleBarVisibility = Visibility.Collapsed;
            }
        }
        /// <summary>
        /// Handles the Click event of the WorkingDays control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void WorkingDays_Click(object sender, RoutedEventArgs e)
        {

            string workingdays = "";
            if (SundayCheckBox.IsChecked == true)
            {
                workingdays = workingdays + "Sunday,";
            }
            if (MondayCheckBox.IsChecked == true)
            {
                workingdays = workingdays + "Monday,";
            }
            if (TuesdayCheckBox.IsChecked == true)
            {
                workingdays = workingdays + "Tuesday,";
            }
            if (WednesdayCheckBox.IsChecked == true)
            {
                workingdays = workingdays + "Wednesday,";
            }
            if (ThursdayCheckBox.IsChecked == true)
            {
                workingdays = workingdays + "Thursday,";
            }
            if (FridayCheckBox.IsChecked == true)
            {
                workingdays = workingdays + "Friday,";
            }
            if (SaturdayCheckBox.IsChecked == true)
            {
                workingdays = workingdays + "Saturday,";
            }
            if (workingdays != "")
            {
                workingdays = workingdays.Remove(workingdays.Length - 1);
                schedule.WorkingDays = workingdays;
            }
        }



    }
}
