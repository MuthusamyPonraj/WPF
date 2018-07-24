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
using System.Collections.ObjectModel;
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
            this.DataContext =this;
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

        private ObservableCollection<ScheduleData> appointmentItemSource = ScheduleData.GetData(10);

        /// <summary>
        /// Gets or sets the appointment item source.
        /// </summary>
        /// <value>The appointment item source.</value>
        public ObservableCollection<ScheduleData> AppointmentItemSource 
        {
            get
            {
                return appointmentItemSource;
            }
            set
            {
                appointmentItemSource = value;   
            }
        }
        
        }

    /// <summary>
    /// Class for Binding with Schedule Appointment
    /// </summary>
    public class ScheduleData
    {
        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <param name="count">The count.</param>
        /// <returns></returns>
        public static ObservableCollection<ScheduleData> GetData(int count)
        {
            string[] subject = new string[]
            {
                "Going to Park",
                "Meet the doc",
                "Meeting with William",
                "Car wash",
                "Visit to Mary's house",
                "Restart my home server"
            };

            string[] location = new string[]
            {
                "Benkinson road",
                "1st floor",
                "2nd floor",
                "Park road",
                "Hutchison road"
            };

            var data = new ObservableCollection<ScheduleData>();
            var rand = new Random();
            var startTime = DateTime.Now.Date.SubractDays(count / 2).AddHours(8);
            for (int i = 0; i < count; i++)
            {
                var tStartTime = startTime.AddDays(i);
                var tEndTime = tStartTime.AddHours(rand.Next(count));
                tEndTime = (tStartTime >= tEndTime) ? tStartTime.AddMinutes(30) : tEndTime;
                var sData = new ScheduleData() { StartTime = tStartTime, EndTime = tEndTime, Subject = subject[rand.Next(5)], Location = location[rand.Next(5)] };
                data.Add(sData);
            }

            return data;
        }

        /// <summary>
        /// Gets or sets the subject.
        /// </summary>
        /// <value>The subject.</value>
        public string Subject { get; set; }
        /// <summary>
        /// Gets or sets the location.
        /// </summary>
        /// <value>The location.</value>
        public string Location { get; set; }
        /// <summary>
        /// Gets or sets the start time.
        /// </summary>
        /// <value>The start time.</value>
        public DateTime StartTime { get; set; }
        /// <summary>
        /// Gets or sets the end time.
        /// </summary>
        /// <value>The end time.</value>
        public DateTime EndTime { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is all day.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is all day; otherwise, <c>false</c>.
        /// </value>
        public bool IsAllDay { get; set; }
    }
}
