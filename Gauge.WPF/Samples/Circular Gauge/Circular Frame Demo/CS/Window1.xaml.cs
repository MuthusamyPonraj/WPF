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
using Syncfusion.Windows.Shared;
using Syncfusion.Windows.Gauge;
using System.Threading;
using System.Windows.Threading;

namespace CircularGaugeFrame_2008
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        #region Private Members

        /// <summary>
        /// Private Members 
        /// </summary>
       
        DispatcherTimer timer;

        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="Window1"/> class.
        /// </summary>
        public Window1()
        {
            InitializeComponent();
            InitializeLog();      
        }

        /// <summary>
        /// Initializes the log.
        /// </summary>
        public void InitializeLog()
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(500);
            timer.Tick += new EventHandler(timer_Tick);
        }

        #endregion

        #region Helper Methods

        /// <summary>
        /// Handles the Tick event of the timer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void timer_Tick(object sender, EventArgs e)
        {
            //Random value generation for pointers.
            Random r = new Random();

            (fullCircleFrame.Scales[0].Pointers[0] as CircularPointer).Value = r.Next(0, 100);
            (halfCircleFrame.Scales[0].Pointers[0] as CircularPointer).Value = r.Next(0, 500);
            (circularCenterGradientFrame.Scales[0].Pointers[0] as CircularPointer).Value = r.Next(0, 210);
            (circularWithDarkOuterFrame.Scales[1].Pointers[0] as CircularPointer).Value = r.Next(0, 210);
            (circularWithInnerLeftGradientFrame.Scales[0].Pointers[0] as CircularPointer).Value = r.Next(0, 100);
            (circularWithInnerTopGradientFrame.Scales[0].Pointers[0] as CircularPointer).Value = r.Next(0, 180);

            ListBox l = new ListBox();
            ListBoxItem ll = new ListBoxItem();
            
        }



        /// <summary>
        /// Handles the Click event of the Button control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            timer.Start();
        }

        /// <summary>
        /// Handles the 1 event of the Button_Click control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            timer.Stop();
        }
        #endregion
    }
}
