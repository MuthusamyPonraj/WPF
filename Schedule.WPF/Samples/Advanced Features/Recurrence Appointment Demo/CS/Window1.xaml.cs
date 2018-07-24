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
using Syncfusion.Windows.Controls;
using Syncfusion.Windows.Controls.Schedule;
using System.Collections.ObjectModel;

namespace Basic_Schedule_Demo
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            
        }

        private void DailyButton_Click(object sender, RoutedEventArgs e)
        {
            this.schedule.Model.Appointments.Clear();
            ScheduleAppointment recurrence = new ScheduleAppointment();
            recurrence.IsRecurrenceAppointment = true;
            recurrence.StartRecurrenceTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            recurrence.StartTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day).AddHours(8);
            recurrence.EndTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day).AddHours(8).AddMinutes(30);
            recurrence.Subject = "Daily Recurrence";
            this.schedule.Model.Appointments.Add(recurrence);
            var newdats = new ObservableCollection<DateTime>();
            for (int i = 0; i < 7; i++)
            {
                newdats.Add(recurrence.StartTime.AddDays(i));   
            }
            this.schedule.Model.SelectedDates = newdats;
        }

        private void WeeklyButton_Click(object sender, RoutedEventArgs e)
        {
            this.schedule.Model.Appointments.Clear();
            ScheduleAppointment recurrence = new ScheduleAppointment();
            recurrence.IsRecurrenceAppointment = true;
            recurrence.CurrentRecurrencePatternMode = RecurrencePatternMode.Weekly;
            recurrence.StartRecurrenceTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            recurrence.StartTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day).AddHours(8);
            recurrence.EndTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day).AddHours(8).AddMinutes(30);
            recurrence.Subject = "Every Monday Recurrence";
            recurrence.IsWeeklyMondaySelected = true;
            this.schedule.Model.Appointments.Add(recurrence);
            var newdats = new ObservableCollection<DateTime>();
            for (int i = 0; i < 7; i++)
            {
                newdats.Add(recurrence.StartTime.AddDays(i));
            }
            this.schedule.Model.SelectedDates = newdats;
        }

        private void WorkWeekButton_Click(object sender, RoutedEventArgs e)
        {
            this.schedule.Model.Appointments.Clear();
            ScheduleAppointment recurrence = new ScheduleAppointment();
            recurrence.IsRecurrenceAppointment = true;
            recurrence.StartRecurrenceTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            recurrence.StartTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day).AddHours(8);
            recurrence.EndTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day).AddHours(8).AddMinutes(30);
            recurrence.Subject = "Every Week Days Recurrence";
            recurrence.IsDailyCustomDays = false;
            this.schedule.Model.Appointments.Add(recurrence); 
            var newdats = new ObservableCollection<DateTime>();
            for (int i = 0; i < 7; i++)
            {
                newdats.Add(recurrence.StartTime.AddDays(i));
            }
            this.schedule.Model.SelectedDates = newdats;
        }
    }
}
