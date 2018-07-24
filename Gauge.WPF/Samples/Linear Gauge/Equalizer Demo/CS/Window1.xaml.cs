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

namespace Equalizer_Demo
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        DispatcherTimer timer;
        LinearScale currentScale;
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
            timer.Interval = TimeSpan.FromMilliseconds(1000);            
            timer.Tick += new EventHandler(timer_Tick);
            currentScale = m_scale1;
            slider.Value = currentScale.Pointers[1].Value;
        }       

        /// <summary>
        /// Handles the Tick event of the timer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void timer_Tick(object sender, EventArgs e)
        {
            Random r = new Random();

            markerpointer.Value = r.Next(0, 100);
            markerpointer2.Value = r.Next(0, 100);
            markerpointer3.Value = r.Next(0, 100);
            markerpointer4.Value = r.Next(0, 100);
            markerpointer5.Value = r.Next(0, 100);
            markerpointer6.Value = r.Next(0, 100);
            markerpointer7.Value = r.Next(0, 100);
            markerpointer8.Value = r.Next(0, 100);
            markerpointer9.Value = r.Next(0, 100);

            if (slider != null)
            {
                slider.Value = currentScale.Pointers[1].Value;
            }

        }

        /// <summary>
        /// Handles the Click event of the StartButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            timer.Start();
        }

        /// <summary>
        /// Handles the Click event of the StopButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
        }

        /// <summary>
        /// Handles the SelectionChanged event of the FrequencyComboBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Controls.SelectionChangedEventArgs"/> instance containing the event data.</param>
        private void FrequencyComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox c = sender as ComboBox;
            switch (c.SelectedIndex)
            {
                case 0:
                    currentScale = m_scale1;
                    break;
                case 1:
                    currentScale = m_scale2;
                    break;
                case 2:
                    currentScale = m_scale3;
                    break;
                case 3:
                    currentScale = m_scale4;
                    break;
                case 4:
                    currentScale = m_scale5;
                    break;
                case 5:
                    currentScale = m_scale6;
                    break;
                case 6:
                    currentScale = m_scale7;
                    break;
                case 7:
                    currentScale = m_scale8;
                    break;
                case 8:
                    currentScale = m_scale9;
                    break;
            }
            if (slider != null)
            {
                slider.Value = currentScale.Pointers[1].Value;
            }
        }

        /// <summary>
        /// Handles the ValueChanged event of the Slider control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedPropertyChangedEventArgs&lt;System.Double&gt;"/> instance containing the event data.</param>
        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (currentScale.Pointers[1] is LinearMarkerPointer)
            {
                currentScale.Pointers[1].Value = e.NewValue;
            }
        }

        /// <summary>
        /// Handles the Click event of the ResetButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            currentScale.Pointers[1].Value = 50;
            if (slider != null)
            {
                slider.Value = 50;
            }
        }

        /// <summary>
        /// Handles the Click event of the ResetAllButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void ResetAllButton_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < linearGauge.Scales.Count; i++)
            {
                linearGauge.Scales[i].Pointers[1].Value = 50;
            }
            
            if (slider != null)
            {
                slider.Value = 50;
            }
        }

        /// <summary>
        /// Handles the SelectionChanged event of the EffectComboBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Controls.SelectionChangedEventArgs"/> instance containing the event data.</param>
        private void EffectComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox c = sender as ComboBox;
            switch (c.SelectedIndex)
            {
                case 0:
                    markerpointer.Value = 50;
                    markerpointer2.Value = 50;
                    markerpointer3.Value = 50;
                    markerpointer4.Value = 50;
                    markerpointer5.Value = 50;
                    markerpointer6.Value = 50;
                    markerpointer7.Value = 50;
                    markerpointer8.Value = 50;
                    markerpointer9.Value = 50;
                    break;
                case 1:
                    markerpointer.Value = 20;
                    markerpointer2.Value = 40;
                    markerpointer3.Value = 50;
                    markerpointer4.Value = 35;
                    markerpointer5.Value = 40;
                    markerpointer6.Value = 30;
                    markerpointer7.Value = 58;
                    markerpointer8.Value = 73;
                    markerpointer9.Value = 50;
                    break;
                case 2:
                    markerpointer.Value = 20;
                    markerpointer2.Value = 25;
                    markerpointer3.Value = 30;
                    markerpointer4.Value = 35;
                    markerpointer5.Value = 40;
                    markerpointer6.Value = 45;
                    markerpointer7.Value = 55;
                    markerpointer8.Value = 60;
                    markerpointer9.Value = 65;
                    break;
                case 3:
                    markerpointer.Value = 40;
                    markerpointer2.Value = 45;
                    markerpointer3.Value = 50;
                    markerpointer4.Value = 55;
                    markerpointer5.Value = 45;
                    markerpointer6.Value = 50;
                    markerpointer7.Value = 60;
                    markerpointer8.Value = 65;
                    markerpointer9.Value = 70;
                    break;
                case 4:
                    markerpointer.Value = 30;
                    markerpointer2.Value = 40;
                    markerpointer3.Value = 90;
                    markerpointer4.Value = 30;
                    markerpointer5.Value = 55;
                    markerpointer6.Value = 20;
                    markerpointer7.Value = 70;
                    markerpointer8.Value = 25;
                    markerpointer9.Value = 60;
                    break;
            }
        }        
    }
}
