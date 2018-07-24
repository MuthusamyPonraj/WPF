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
using System.Windows.Threading;

namespace PointerDemo_2008
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
        private StateIndicator m_indicator;
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
            m_indicator = new StateIndicator();
            m_indicator.StateRanges.Add(new StateRange(180, 240,m_indicator.ActiveBackgroundBrush));
            m_indicator.FontSize = 12;
            m_indicator.FontFamily = new FontFamily("Verdana");
            m_indicator.Text = "Off";
            m_indicator.ActiveText = "On";
            m_indicator.IndicatorWidth = 20;
            m_indicator.IndicatorHeight = 20;
            m_indicator.Location = new Point(58, 80);
            m_indicator.IndicatorStyle = IndicatorStyle.CircularLED;

            circularGauge1.StateIndicators.Add(m_indicator);           
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(500);
            // Subscribe the Tick property changed event 
            timer.Tick += new EventHandler(timer_Tick);

        }

        #endregion

        #region Events 

        /// <summary>
        /// Add the log entry for events
        /// </summary>
        /// <param name="prop"></param>
        /// <param name="oldvalue"></param>
        /// <param name="newvalue"></param>
        public void AddToLog(string prop, string oldvalue, string newvalue)
        {
            txtevent.FontSize = 12;
            txtevent.TextWrapping = TextWrapping.Wrap;
            txtevent.Text = txtevent.Text + prop +
                " Value Changed Event Fired [Old Value :" + oldvalue + "],[New Value :" + newvalue + "] \n";
            Scroll.ScrollToBottom();
        }
        /// <summary>
        /// Circulars the pointer_ value changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private void CircularPointer_ValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (m_indicator != null)
            {
                m_indicator.Value = (CircularScale.Pointers[0] as CircularPointer).Value;
            }

            AddToLog(e.Property.Name.ToString(), e.OldValue.ToString(), e.NewValue.ToString());
            
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
            Random r = new Random();

            (CircularScale.Pointers[0] as CircularPointer).Value = r.Next(0, 240);
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
        /// Pointer1s the slider value changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedPropertyChangedEventArgs&lt;System.Double&gt;"/> instance containing the event data.</param>
        void Pointer1SliderValueChanged(object d, RoutedPropertyChangedEventArgs<double> e)
        {
            if (CircularScale != null)
            {
                (CircularScale.Pointers[0] as CircularPointer).Value = this.Pointer1ValueSlider.Value;
            }
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

        /// <summary>
        /// Clear the Events
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void OnClear(object sender, EventArgs args)
        {
            txtevent.Text = "";
        }

        /// <summary>
        /// Checking the contextmenu for clearing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void Contextmenu_chk(object sender, EventArgs args)
        {
            if (txtevent.Text == "")
                cm.Visibility = Visibility.Collapsed;
            else
                cm.Visibility = Visibility.Visible;
        }

        #endregion

    }
}
