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

namespace MultiScaleDemo_2008
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
        private CircularScale m_scale;
        private CircularScale m_scale1;        

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
            m_scale = new CircularScale();
            m_scale.ShadowOffset = 1;
            m_scale.Minimum = 0;
            m_scale.Maximum = 100;
            m_scale.MinorIntervalValue = 5;
            m_scale.MajorIntervalValue = 20;
            m_scale.StartAngle = 120;
            m_scale.GapSweepAngle = 300;
            m_scale.ScaleBarSize = 7;
            m_scale.Radius = 60;
            m_scale.BorderWidth = 1.0;
            

            m_scale1 = new CircularScale();
            m_scale1.ShadowOffset = 1;
            m_scale1.Minimum = 0;
            m_scale1.Maximum = 100;
            m_scale1.MinorIntervalValue = 5;
            m_scale1.MajorIntervalValue = 10;
            m_scale1.StartAngle = 120;
            m_scale1.GapSweepAngle = 300;
            m_scale1.ScaleBarSize = 0.5;
            m_scale1.Radius = 40;
            m_scale1.BorderWidth = 1.2;
                       
            
            this.circularGauge1.Scales.Add(m_scale);
            this.circularGauge1.Scales.Add(m_scale1);


            CircularLabelTick majorLabelTick = new CircularLabelTick();
            majorLabelTick.FontSize = 13;
            majorLabelTick.TickStyle = TickStyle.MajorTick;            
            majorLabelTick.TickPlacement = ScalePlacement.Inside;
            majorLabelTick.DistanceFromScale = 5;

            CircularMarkTick majorTick = new CircularMarkTick();
            majorTick.TickWidth = 5;
            majorTick.TickHeight = 10;
            majorTick.TickStyle = TickStyle.MajorTick;          
            majorTick.TickShape = TickShape.RoundedRectangle;
            

            CircularMarkTick minorTick = new CircularMarkTick();
            minorTick.TickWidth = 1;
            minorTick.TickHeight = 4;
            minorTick.TickStyle = TickStyle.MinorTick;
            
            CircularLabelTick majorLabelTick1 = new CircularLabelTick();
            majorLabelTick1.FontSize = 11;
            majorLabelTick1.TickStyle = TickStyle.MajorTick;
           

            majorLabelTick1.TickPlacement = ScalePlacement.Inside;
            majorLabelTick1.DistanceFromScale = 5;

            CircularMarkTick majorTick1 = new CircularMarkTick();
            majorTick1.TickWidth = 4;
            majorTick1.TickHeight = 9;
            majorTick1.TickStyle = TickStyle.MajorTick;           
            majorTick1.TickShape = TickShape.Ellipse;
            
            CircularMarkTick minorTick1 = new CircularMarkTick();
            minorTick1.TickWidth = 1;
            minorTick1.TickHeight = 4;
            minorTick1.TickStyle = TickStyle.MinorTick;
           

            m_scale.Ticks.Add(minorTick);
            m_scale.Ticks.Add(majorTick);
            m_scale.Ticks.Add(majorLabelTick);

            m_scale1.Ticks.Add(minorTick1);
            m_scale1.Ticks.Add(majorTick1);
            m_scale1.Ticks.Add(majorLabelTick1);


            m_scale.PointerCap.PointerCapRadius = 7;
            m_scale1.PointerCap.PointerCapRadius = 7;
          

            CircularPointer pointer1 = new CircularPointer();
         
            pointer1.BorderWidth = 0.3;
            pointer1.PointerLength = 40;
            pointer1.PointerWidth = 10;
            pointer1.PointerPlacement = ScalePlacement.Outside;
            

            CircularPointer pointer3 = new CircularPointer();
           
            pointer3.BorderWidth = 0.3;
            pointer3.PointerLength = 70;
            pointer3.PointerWidth = 10;
            pointer3.Value = 50;
            pointer3.PointerPlacement = ScalePlacement.Outside;

            
            m_scale.Pointers.Add(pointer1);
            m_scale1.Pointers.Add(pointer3);

            // Subscribe GapSweepAngle property changed event 
            m_scale.GapSweepAngleChanged += new PropertyChangedCallback(m_scale_GapSweepAngleChanged);
            // Subscribe GapSweepAngle property changed event 
            m_scale1.GapSweepAngleChanged += new PropertyChangedCallback(m_scale1_GapSweepAngleChanged);
            // Subscribe Location property changed event 
            m_scale.LocationChanged += new PropertyChangedCallback(m_scale_LocationChanged);
            // Subscribe Location property changed event 
            m_scale1.LocationChanged += new PropertyChangedCallback(m_scale1_LocationChanged);
            // Subscribe Maximum property changed event 
            m_scale.MaximumChanged += new PropertyChangedCallback(m_scale_MaximumChanged);
            // Subscribe Maximum property changed event 
            m_scale1.MaximumChanged += new PropertyChangedCallback(m_scale1_MaximumChanged);
            // Subscribe Minimum property changed event 
            m_scale1.MinimumChanged += new PropertyChangedCallback(m_scale1_MinimumChanged);
            // Subscribe Minimum property changed event 
            m_scale.MinimumChanged += new PropertyChangedCallback(m_scale_MinimumChanged);
            // Subscribe MajorIntervalValue property changed event 
            m_scale.MajorIntervalValueChanged += new PropertyChangedCallback(m_scale_MajorIntervalValueChanged);
            // Subscribe MinorIntervalValue property changed event 
            m_scale.MinorIntervalValueChanged += new PropertyChangedCallback(m_scale1_MinorIntervalValueChanged);
            // Subscribe StartAngle property changed event 
            m_scale.StartAngleChanged += new PropertyChangedCallback(m_scale_StartAngleChanged);
            // Subscribe StartAngle property changed event 
            m_scale1.StartAngleChanged += new PropertyChangedCallback(m_scale1_StartAngleChanged);
            // Subscribe Radius property changed event 
            m_scale.RadiusChanged += new PropertyChangedCallback(m_scale_RadiusChanged);
            // Subscribe Radius property changed event 
            m_scale1.RadiusChanged += new PropertyChangedCallback(m_scale1_RadiusChanged);
            // Subscribe BorderWidth property changed event 
            //m_scale.BorderWidthChanged += new PropertyChangedCallback(m_scale_BorderWidthChanged);
            // Subscribe BorderWidth property changed event 
            //m_scale1.BorderWidthChanged += new PropertyChangedCallback(m_scale1_BorderWidthChanged);
            // Subscribe ScaleBarSize property changed event 
            m_scale.ScaleBarSizeChanged += new PropertyChangedCallback(m_scale_ScaleBarSizeChanged);
            // Subscribe ScaleBarSize property changed event 
            m_scale1.ScaleBarSizeChanged += new PropertyChangedCallback(m_scale1_ScaleBarSizeChanged);
            // Subscribe Value property changed event 
            (m_scale.Pointers[0] as CircularPointer).ValueChanged+=new PropertyChangedCallback(Changed);

            ScaleRadiusSlider.Value = 90;
            ScaleRadiusSlider1.Value = 60;
        }

        #endregion

        #region Events 
        /// <summary>
        /// Outer Pointer Value changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        void Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AddToLog(e.Property.Name.ToString(), e.OldValue.ToString(), e.NewValue.ToString());
        }

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
        /// M_scale1_s the scale bar size changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        void m_scale1_ScaleBarSizeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
           
            AddToLog(e.Property.Name.ToString(), e.OldValue.ToString(), e.NewValue.ToString());
           
        }

        /// <summary>
        /// M_scale_s the scale bar size changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        void m_scale_ScaleBarSizeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AddToLog(e.Property.Name.ToString(), e.OldValue.ToString(), e.NewValue.ToString());
        }

        /// <summary>
        /// M_scale1_s the border width changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        void m_scale1_BorderWidthChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
           
            AddToLog(e.Property.Name.ToString(), e.OldValue.ToString(), e.NewValue.ToString());
        }

        /// <summary>
        /// M_scale_s the border width changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        void m_scale_BorderWidthChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
           
            AddToLog(e.Property.Name.ToString(), e.OldValue.ToString(), e.NewValue.ToString());
        }

        /// <summary>
        /// M_scale1_s the radius changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        void m_scale1_RadiusChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AddToLog(e.Property.Name.ToString(), e.OldValue.ToString(), e.NewValue.ToString());
        }

        /// <summary>
        /// M_scale_s the radius changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        void m_scale_RadiusChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AddToLog(e.Property.Name.ToString(), e.OldValue.ToString(), e.NewValue.ToString());
        }

        /// <summary>
        /// M_scale1_s the start angle changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        void m_scale1_StartAngleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AddToLog(e.Property.Name.ToString(), e.OldValue.ToString(), e.NewValue.ToString());
        }

        /// <summary>
        /// M_scale_s the start angle changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        void m_scale_StartAngleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AddToLog(e.Property.Name.ToString(), e.OldValue.ToString(), e.NewValue.ToString());
        }

        /// <summary>
        /// M_scale1_s the minor interval value changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        void m_scale1_MinorIntervalValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AddToLog(e.Property.Name.ToString(), e.OldValue.ToString(), e.NewValue.ToString());
        }

        /// <summary>
        /// M_scale_s the major interval value changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        void m_scale_MajorIntervalValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AddToLog(e.Property.Name.ToString(), e.OldValue.ToString(), e.NewValue.ToString());
        }

        /// <summary>
        /// M_scale_s the minimum changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        void m_scale_MinimumChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AddToLog(e.Property.Name.ToString(), e.OldValue.ToString(), e.NewValue.ToString());
        }

        /// <summary>
        /// M_scale1_s the minimum changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        void m_scale1_MinimumChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AddToLog(e.Property.Name.ToString(), e.OldValue.ToString(), e.NewValue.ToString());
        }

        /// <summary>
        /// M_scale1_s the maximum changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        void m_scale1_MaximumChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AddToLog(e.Property.Name.ToString(), e.OldValue.ToString(), e.NewValue.ToString());
        }

        /// <summary>
        /// M_scale_s the maximum changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        void m_scale_MaximumChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AddToLog(e.Property.Name.ToString(), e.OldValue.ToString(), e.NewValue.ToString());
        }

        /// <summary>
        /// M_scale1_s the location changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        void m_scale1_LocationChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AddToLog(e.Property.Name.ToString(), e.OldValue.ToString(), e.NewValue.ToString());
        }

        /// <summary>
        /// M_scale_s the location changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        void m_scale_LocationChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AddToLog(e.Property.Name.ToString(), e.OldValue.ToString(), e.NewValue.ToString());
        }

        /// <summary>
        /// M_scale1_s the gap sweep angle changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        void m_scale1_GapSweepAngleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AddToLog(e.Property.Name.ToString(), e.OldValue.ToString(), e.NewValue.ToString());
        }

        /// <summary>
        /// M_scale_s the gap sweep angle changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        void m_scale_GapSweepAngleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AddToLog(e.Property.Name.ToString(), e.OldValue.ToString(), e.NewValue.ToString());
        }

        #endregion

        #region Helper Methods 

        /// <summary>
        /// Scales the radius slider value changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedPropertyChangedEventArgs&lt;System.Double&gt;"/> instance containing the event data.</param>
        void ScaleRadiusSliderValueChanged(object d, RoutedPropertyChangedEventArgs<double> e)
        {
            if (m_scale != null)
                if (ScaleRadiusSlider.Value <= 8)
                {
                    m_scale.GapSweepAngle = -5;
                }
                else
                {
                    m_scale.Radius = this.ScaleRadiusSlider.Value;
                    m_scale.GapSweepAngle = SweepAngleSlider.Value;                
                   
                }            
        }

        /// <summary>
        /// Scales the bar size slider value changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedPropertyChangedEventArgs&lt;System.Double&gt;"/> instance containing the event data.</param>
        void ScaleBarSizeSliderValueChanged(object d, RoutedPropertyChangedEventArgs<double> e)
        {
            if (m_scale != null)
                m_scale.ScaleBarSize = this.ScaleBarSizeSlider.Value;
        }
               

        /// <summary>
        /// Starts the angle slider value changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedPropertyChangedEventArgs&lt;System.Double&gt;"/> instance containing the event data.</param>
        void StartAngleSliderValueChanged(object d, RoutedPropertyChangedEventArgs<double> e)
        {
            if (m_scale != null)
                m_scale.StartAngle = this.StartAngleSlider.Value;
        }
        /// <summary>
        /// Sweeps the angle slider value changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedPropertyChangedEventArgs&lt;System.Double&gt;"/> instance containing the event data.</param>
        void SweepAngleSliderValueChanged(object d, RoutedPropertyChangedEventArgs<double> e)
        {
            if (m_scale != null)
                m_scale.GapSweepAngle = this.SweepAngleSlider.Value -15;
        }

       

        

        /// <summary>
        /// Minimums the slider value changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedPropertyChangedEventArgs&lt;System.Double&gt;"/> instance containing the event data.</param>
        void MinimumSliderValueChanged(object d, RoutedPropertyChangedEventArgs<double> e)
        {
            if (m_scale != null)
            {
                m_scale.Minimum = this.MinimumSlider.Value;                
            }
        }

        /// <summary>
        /// Maximums the slider value changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedPropertyChangedEventArgs&lt;System.Double&gt;"/> instance containing the event data.</param>
        void MaximumSliderValueChanged(object d, RoutedPropertyChangedEventArgs<double> e)
        {
            if (m_scale != null)
            {
                m_scale.Maximum = this.MaximumSlider.Value;              
            }
        }

        /// <summary>
        /// Majors the interval slider value changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedPropertyChangedEventArgs&lt;System.Double&gt;"/> instance containing the event data.</param>
        void MajorIntervalSliderValueChanged(object d, RoutedPropertyChangedEventArgs<double> e)
        {
            if (m_scale != null)
                m_scale.MajorIntervalValue = this.MajorIntervalSlider.Value;
        }
        /// <summary>
        /// Minors the interval slider value changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedPropertyChangedEventArgs&lt;System.Double&gt;"/> instance containing the event data.</param>
        void MinorIntervalSliderValueChanged(object d, RoutedPropertyChangedEventArgs<double> e)
        {
            if (m_scale != null)
                m_scale.MinorIntervalValue = this.MinorIntervalSlider.Value;
        }


        /// <summary>
        /// Pointer1s the slider value changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedPropertyChangedEventArgs&lt;System.Double&gt;"/> instance containing the event data.</param>
        void Pointer1SliderValueChanged(object d, RoutedPropertyChangedEventArgs<double> e)
        {
            if (m_scale != null)
            {
                (m_scale.Pointers[0] as CircularPointer).Value = this.Pointer1ValueSlider.Value;
            }
        }
        /// <summary>
        /// Pointer3s the slider value changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedPropertyChangedEventArgs&lt;System.Double&gt;"/> instance containing the event data.</param>
        void Pointer3SliderValueChanged(object d, RoutedPropertyChangedEventArgs<double> e)
        {
            if (m_scale1 != null)
            {
                (m_scale1.Pointers[0] as CircularPointer).Value = this.Pointer3ValueSlider1.Value;
            }
        }

        /// <summary>
        /// Starts the angle slider value changed1.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedPropertyChangedEventArgs&lt;System.Double&gt;"/> instance containing the event data.</param>
        void StartAngleSliderValueChanged1(object d, RoutedPropertyChangedEventArgs<double> e)
        {
            if (m_scale1 != null)
                m_scale1.StartAngle = this.StartAngleSlider1.Value;
        }

        /// <summary>
        /// Sweeps the angle slider value changed1.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedPropertyChangedEventArgs&lt;System.Double&gt;"/> instance containing the event data.</param>
        void SweepAngleSliderValueChanged1(object d, RoutedPropertyChangedEventArgs<double> e)
        {
            if (m_scale1 != null)
                m_scale1.GapSweepAngle = this.SweepAngleSlider1.Value-15;
        }



       
        /// <summary>
        /// Minimums the slider value changed1.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedPropertyChangedEventArgs&lt;System.Double&gt;"/> instance containing the event data.</param>
        void MinimumSliderValueChanged1(object d, RoutedPropertyChangedEventArgs<double> e)
        {
            if (m_scale1 != null)
            {
                m_scale1.Minimum = this.MinimumSlider1.Value;                
            }
        }

        /// <summary>
        /// Maximums the slider value changed1.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedPropertyChangedEventArgs&lt;System.Double&gt;"/> instance containing the event data.</param>
        void MaximumSliderValueChanged1(object d, RoutedPropertyChangedEventArgs<double> e)
        {
            if (m_scale1 != null)
            {
                m_scale1.Maximum = this.MaximumSlider1.Value;                
            }
        }

        /// <summary>
        /// Majors the interval slider value changed1.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedPropertyChangedEventArgs&lt;System.Double&gt;"/> instance containing the event data.</param>
        void MajorIntervalSliderValueChanged1(object d, RoutedPropertyChangedEventArgs<double> e)
        {
            if (m_scale1 != null)
                m_scale1.MajorIntervalValue = this.MajorIntervalSlider1.Value;
        }

        /// <summary>
        /// Minors the interval slider value changed1.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedPropertyChangedEventArgs&lt;System.Double&gt;"/> instance containing the event data.</param>
        void MinorIntervalSliderValueChanged1(object d, RoutedPropertyChangedEventArgs<double> e)
        {
            if (m_scale1 != null)
                m_scale1.MinorIntervalValue = this.MinorIntervalSlider1.Value;
        }



        /// <summary>
        /// Scales the radius slider value changed1.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedPropertyChangedEventArgs&lt;System.Double&gt;"/> instance containing the event data.</param>
        void ScaleRadiusSliderValueChanged1(object d, RoutedPropertyChangedEventArgs<double> e)
        {
            
            if (m_scale1 != null)
            {
                if (ScaleRadiusSlider1.Value <= 8)
                {
                    m_scale1.GapSweepAngle = -5;
                }
                else
                {
                    m_scale1.Radius = this.ScaleRadiusSlider1.Value;
                    m_scale1.GapSweepAngle = SweepAngleSlider1.Value;
                }
                
            }

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
