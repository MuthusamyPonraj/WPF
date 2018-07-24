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
using System.Windows.Threading;
using Syncfusion.Windows.Gauge;

namespace CarDashboard_new
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        double gear = 0;
        DispatcherTimer rpmtimer;
        DispatcherTimer speedtimer;
        DispatcherTimer fueltimer;
        DispatcherTimer temptimer;
        DispatcherTimer lefttimer;
        DispatcherTimer righttimer;

        double rpm = 0;
        static double fuelLevel = 20;

        double tireCircumference = 6.30;
        double finalGearRatio = 4.86;

        /// <summary>
        /// Initializes a new instance of the <see cref="Window1"/> class.
        /// </summary>
        public Window1()
        {            
            InitializeComponent();
            rpmtimer = new DispatcherTimer();
            rpmtimer.Interval = TimeSpan.FromMilliseconds(0);
            rpmtimer.Tick += new EventHandler(rpmTimer_Tick);

            speedtimer = new DispatcherTimer();
            speedtimer.Interval = TimeSpan.FromMilliseconds(0);
            speedtimer.Tick += new EventHandler(speedtimer_Tick);

            fueltimer = new DispatcherTimer();
            fueltimer.Interval = TimeSpan.FromSeconds(7);
            fueltimer.Tick += new EventHandler(fueltimer_Tick);

            temptimer = new DispatcherTimer();
            temptimer.Interval = TimeSpan.FromSeconds(10);
            temptimer.Tick += new EventHandler(temptimer_Tick);

            lefttimer = new DispatcherTimer();
            lefttimer.Interval = TimeSpan.FromSeconds(1);
            lefttimer.Tick += new EventHandler(lefttimer_Tick);

            righttimer = new DispatcherTimer();
            righttimer.Interval = TimeSpan.FromSeconds(1);
            righttimer.Tick += new EventHandler(righttimer_Tick);           
        }

        /// <summary>
        /// Handles the Tick event of the righttimer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void righttimer_Tick(object sender, EventArgs e)
        {
            if (rindicator.Value != 5) 
                rindicator.Value = 5;
            else
                rindicator.Value=6;
        }

        /// <summary>
        /// Handles the Tick event of the lefttimer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void lefttimer_Tick(object sender, EventArgs e)
        {
            if (lindicator.Value != 5)
                lindicator.Value = 5;
            else
                lindicator.Value = 6;
        }

        /// <summary>
        /// Handles the Tick event of the temptimer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void temptimer_Tick(object sender, EventArgs e)
        {
            LSmallpointer.Value += 2;
            if (LSmallpointer.Value == 100)
            {
                speedtimer.Stop();
                rpmtimer.Stop();
                fueltimer.Stop();
                temptimer.Stop();
                gear = 0;
                RMediumpointer.AnimationDuration = 1000;
                RMediumpointer.Value = 0;
                speedometerPointer.AnimationDuration = 1000;
                speedometerPointer.Value = 0;
                LMediumpointer.Value = 0;
                LSmallpointer.AnimationDuration = 1000;
                LSmallpointer.Value = 0;
                RSmallpointer.Value = 0;
            }
        }

        /// <summary>
        /// Handles the Tick event of the fueltimer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void fueltimer_Tick(object sender, EventArgs e)
        {
            fuelLevel -= 1;
            LMediumpointer.Value = fuelLevel;
            if (fuelLevel == 0)
            {
                speedtimer.Stop();
                rpmtimer.Stop();
                fueltimer.Stop();
                temptimer.Stop();
                gear = 0;
                RMediumpointer.AnimationDuration = 1000;
                RMediumpointer.Value = 0;
                speedometerPointer.AnimationDuration = 1000;
                speedometerPointer.Value = 0;
                LMediumpointer.Value = 0;
                LSmallpointer.AnimationDuration = 1000;
                LSmallpointer.Value = 0;
                RSmallpointer.Value = 0;
            }
        }

        /// <summary>
        /// Handles the Tick event of the speedtimer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void speedtimer_Tick(object sender, EventArgs e)
        {
            if (gear == 1)
            {
                speedometerPointer.Value = (RMediumpointer.Value * 1000 * tireCircumference) / (3.78 * finalGearRatio * 88);
            }
            else if (gear == 2)
            {
                speedometerPointer.Value = (RMediumpointer.Value * 1000 * tireCircumference) / (2.06 * finalGearRatio * 88);
            }
            else if (gear == 3)
            {
                speedometerPointer.Value = (RMediumpointer.Value * 1000 * tireCircumference) / (1.23 * finalGearRatio * 88);
            }
            else if (gear == 4)
            {
                speedometerPointer.Value = (RMediumpointer.Value * 1000 * tireCircumference) / (0.83 * finalGearRatio * 88);
            }
        }

        /// <summary>
        /// Handles the Tick event of the rpmTimer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void rpmTimer_Tick(object sender, EventArgs e)
        {
            if (gear == 1)
            {                
                rpm += 0.009;
                rpmtimer.Interval = TimeSpan.FromMilliseconds(0);
                RMediumpointer.Value = rpm;
                if (rpm >= 5.8)
                {
                    rpm = 3.2;
                    gear = 2;
                }
            }
            if (gear == 2)
            {
                rpm += 0.009;
                rpmtimer.Interval = TimeSpan.FromMilliseconds(0);
                RMediumpointer.Value = rpm;
                if (rpm >= 5.8)
                {
                    rpm = 3.2;
                    gear = 3;
                }
            }
            if (gear == 3)
            {
                rpm += 0.009;
                rpmtimer.Interval = TimeSpan.FromMilliseconds(0);
                RMediumpointer.Value = rpm;
                if (rpm >= 5.8)
                {
                    rpm = 3.8;
                    gear = 4;
                }
            }
            if (gear == 4)
            {
                rpm += 0.009;
                if (rpm > 8)
                {
                    rpmtimer.Interval = TimeSpan.FromMilliseconds(10);
                    rpm = 7.9;                    
                }
                RMediumpointer.Value = rpm;
            }
        }

        /// <summary>
        /// Handles the Click event of the StartButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            if (rpmtimer.IsEnabled == false)
            {
                gear = 1;
                rpm = 0;
                RMediumpointer.AnimationDuration = 500;
                speedometerPointer.AnimationDuration = 500;
                LMediumpointer.AnimationDuration = 500;
                LSmallpointer.AnimationDuration = 4000;
                RSmallpointer.AnimationDuration = 4000;
                LSmallpointer.Value = 40;
                RSmallpointer.Value = 2.5;

                if (fuelLevel != 0)
                {
                    LMediumpointer.Value = fuelLevel;
                    rpmtimer.Start();
                    speedtimer.Start();
                    fueltimer.Start();
                    temptimer.Start();
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the StopButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void StopButton_Click(object sender, RoutedEventArgs e)
        {            
            speedtimer.Stop();
            rpmtimer.Stop();
            fueltimer.Stop();
            temptimer.Stop();
            gear = 0;

            RMediumpointer.AnimationDuration = 4000;
            speedometerPointer.AnimationDuration = 4000;
            LMediumpointer.AnimationDuration = 4000;

            RMediumpointer.Value = 0;            
            speedometerPointer.Value = 0;            
            LMediumpointer.Value = 0;
            LSmallpointer.Value = 0;
            RSmallpointer.Value = 0;
        }

        /// <summary>
        /// Handles the Checked event of the LeftRadioButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void LeftRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            lefttimer.Start();
            righttimer.Stop();
            rindicator.Value = 6;
        }

        /// <summary>
        /// Handles the Checked event of the RightRadioButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void RightRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            righttimer.Start();
            lefttimer.Stop();
            lindicator.Value = 6;
        }

        /// <summary>
        /// Handles the Checked event of the ParkingRadioButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void ParkingRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            righttimer.Stop();
            lefttimer.Stop();
            rindicator.Value = 6;
            lindicator.Value = 6;
            righttimer.Start();
            lefttimer.Start();
        }

        /// <summary>
        /// Handles the Checked event of the OffRadioButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void OffRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (righttimer != null)
            {
                righttimer.Stop();
                lefttimer.Stop();
                rindicator.Value = 6;
                lindicator.Value = 6;
            }
        }

        /// <summary>
        /// Handles the Click event of the RefuelButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void RefuelButton_Click(object sender, RoutedEventArgs e)
        {
            if (fueltimer.IsEnabled == true)
            {
                fuelLevel = 20;
                LMediumpointer.Value = 20;
            }
            else
                fuelLevel = 20;
        }
    }
}
