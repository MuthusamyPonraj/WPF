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
using Syncfusion.Windows.Gauge;
using Syncfusion.Windows.Shared;

namespace LinearGaugeDemo
{

    public partial class Window1 : Window
    {

        /// <summary>
        /// Interaction logic for Window1.xaml
        /// </summary>
        
        #region Private Members

        /// <summary>
        /// Private Members
        /// </summary>

        TextBlock tt = new TextBlock();

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Window1"/> class.
        /// </summary>
        public Window1()
        {
            InitializeComponent();
            InitLog();
        }
        #endregion

        /// <summary>
        /// Gauge's value changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private void Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AddToLog(e.Property.Name.ToString(), e.OldValue.ToString(), e.NewValue.ToString());
        }

        #region Helper methods

        /// <summary>
        /// Initializes the Log.
        /// </summary>
        public void InitLog()
        {
            linearGauge.OrientationChanged += new PropertyChangedCallback(Changed);
            (m_scale.Pointers[0] as LinearPointer).PointerWidthChanged += new PropertyChangedCallback(Changed);
            (m_scale.Pointers[1] as LinearMarkerPointer).PointerLengthChanged += new PropertyChangedCallback(Changed);
            (m_scale.Pointers[1] as LinearMarkerPointer).MarkerStyleChanged += new PropertyChangedCallback(Changed);
            (m_scale.Pointers[1] as LinearMarkerPointer).PointerPlacementChanged += new PropertyChangedCallback(Changed);
            m_scale.ScaleBarSizeChanged += new PropertyChangedCallback(Changed);
            //m_scale.BorderWidthChanged += new PropertyChangedCallback(Changed);
            (m_scale.Ticks[0] as TickBase).AngleChanged += new PropertyChangedCallback(Changed);
            (m_scale.Ticks[0] as TickBase).TickPlacementChanged += new PropertyChangedCallback(Changed);
            (m_scale.Ticks[1] as LinearMarkTick).TickShapeChanged += new PropertyChangedCallback(Changed);
            (m_scale.Ticks[2] as TickBase).AngleChanged += new PropertyChangedCallback(Changed);
            (m_scale.Ticks[2] as TickBase).DistanceFromScaleChanged += new PropertyChangedCallback(Changed);
            (m_scale.Ticks[2] as TickBase).TickPlacementChanged += new PropertyChangedCallback(Changed);
            (m_scale.Ranges[0] as LinearRange).StartWidthChanged += new PropertyChangedCallback(Changed);
            (m_scale.Ranges[0] as LinearRange).EndWidthChanged += new PropertyChangedCallback(Changed);
            (m_scale.Ranges[0] as LinearRange).DistanceFromScaleChanged += new PropertyChangedCallback(Changed);
            (m_scale.Ranges[0] as LinearRange).RangePositionChanged += new PropertyChangedCallback(Changed);
            this.colorPicker1.ColorChanged += new PropertyChangedCallback(Changed);
        }        

        /// <summary>
        /// Orientations the vertical click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void OrientationVerticalClick(object sender, RoutedEventArgs e)
        {
            linearGauge.Width = linearGauge.Height;
            linearGauge.Height = double.NaN;
            linearGauge.Orientation = GaugeOrientation.Vertical;
        }
        /// <summary>
        /// Orientations the horizontal click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void OrientationHorizontalClick(object sender, RoutedEventArgs e)
        {
            linearGauge.Height= linearGauge.Width;
            linearGauge.Width = double.NaN;
            linearGauge.Orientation = GaugeOrientation.Horizontal;
        }
        private void Window1Loaded(object sender, RoutedEventArgs e)
        {
        }
        /// <summary>
        /// Colors the picker1 color changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        void ColorPicker1ColorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (this.linearGauge != null)
            {
                this.linearGauge.Background = new SolidColorBrush(this.colorPicker1.Color);
            }
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
                (m_scale.Pointers[0] as LinearPointer).Value = this.Pointer1ValueSlider.Value;
                (m_scale.Pointers[1] as LinearPointer).Value = this.Pointer1ValueSlider.Value;
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
        /// Scales the border width slider value changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedPropertyChangedEventArgs&lt;System.Double&gt;"/> instance containing the event data.</param>
        void ScaleBorderWidthSliderValueChanged(object d, RoutedPropertyChangedEventArgs<double> e)
        {
            if (m_scale != null)
                m_scale.BorderWidth = this.ScaleBorderWidthSlider.Value;
        }
        /// <summary>
        /// Tickses the angle slider value changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedPropertyChangedEventArgs&lt;System.Double&gt;"/> instance containing the event data.</param>
        void TicksAngleSliderValueChanged(object d, RoutedPropertyChangedEventArgs<double> e)
        {
            if (m_scale != null)
                (m_scale.Ticks[0] as TickBase).Angle = this.TicksAngleSlider.Value;
        }
        /// <summary>
        /// Tickses the position changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.Controls.SelectionChangedEventArgs"/> instance containing the event data.</param>
        void TicksPositionChanged(object d, SelectionChangedEventArgs e)
        {
            if (m_scale != null)
            {
                int count = m_scale.Ticks.Count;
                for (int i = 0; i < count; i++)
                {
                    if (m_scale.Ticks[i] is LinearMarkTick)
                    {
                        LinearMarkTick tick = m_scale.Ticks[i] as LinearMarkTick;
                        switch (this.TicksPositionComboBox.SelectedIndex)
                        {
                            // Set TickPlacement as Inside 
                            case 0:
                                tick.TickPlacement = ScalePlacement.Inside;
                                break;
                            // Set TickPlacement as Cross 
                            case 1:
                                tick.TickPlacement = ScalePlacement.Cross;
                                break;
                            // Set TickPlacement as Outside 
                            case 2:
                                tick.TickPlacement = ScalePlacement.Outside;
                                break;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Tickses the shape changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.Controls.SelectionChangedEventArgs"/> instance containing the event data.</param>
        void TicksShapeChanged(object d, SelectionChangedEventArgs e)
        {
            if (m_scale != null)
            {
                int count = m_scale.Ticks.Count;
                for (int i = 0; i < count; i++)
                {
                    if (m_scale.Ticks[i] is LinearMarkTick)
                    {
                        LinearMarkTick tick = m_scale.Ticks[i] as LinearMarkTick;
                        switch (this.TicksShapeComboBox.SelectedIndex)
                        {
                            // Set TickShape as Rectangle
                            case 0:
                                tick.TickShape = TickShape.Rectangle;
                                
                                break;
                            // Set TickShape as RoundedRectangle
                            case 1:
                                tick.TickShape = TickShape.RoundedRectangle;
                                break;
                            // Set TickShape as Ellipse
                            case 2:
                                tick.TickShape = TickShape.Ellipse;
                                break;
                            // Set TickShape as Triangle
                            case 3:
                                tick.TickShape = TickShape.Triangle;
                                break;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Labelses the angle slider value changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedPropertyChangedEventArgs&lt;System.Double&gt;"/> instance containing the event data.</param>
        void LabelsAngleSliderValueChanged(object d, RoutedPropertyChangedEventArgs<double> e)
        {
            if (m_scale != null)
                (m_scale.Ticks[2] as TickBase).Angle = this.LabelsAngleSlider.Value;
        }
        /// <summary>
        /// Labelses the position changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.Controls.SelectionChangedEventArgs"/> instance containing the event data.</param>
        void LabelsPositionChanged(object d, SelectionChangedEventArgs e)
        {
            if (m_scale != null)
            {
                int count = m_scale.Ticks.Count;
                for (int i = 0; i < count; i++)
                {
                    if (m_scale.Ticks[i] is LinearLabelTick)
                    {
                        LinearLabelTick tick = m_scale.Ticks[i] as LinearLabelTick;
                        switch (this.LabelsPositionComboBox.SelectedIndex)
                        {
                            // Set TickPlacement as Inside
                            case 0:
                                tick.TickPlacement = ScalePlacement.Inside;                                
                                break;
                            // Set TickPlacement as Cross
                            case 1:
                                tick.TickPlacement = ScalePlacement.Cross;
                                break;
                            // Set TickPlacement as Outside
                            case 2:
                                tick.TickPlacement = ScalePlacement.Outside;
                                break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Indicators the style changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.Controls.SelectionChangedEventArgs"/> instance containing the event data.</param>
        void IndicatorStyleChanged(object d, SelectionChangedEventArgs e)
        {
           
            if (this.linearGauge.StateIndicators.Count > 0)
            {
                StateIndicator indicator = this.linearGauge.StateIndicators[0];
                switch (this.IndicatorStyleComboBox.SelectedIndex)
                {
                    // Set IndicatorStyle as CircularLED
                    case 0:
                        indicator.IndicatorStyle = IndicatorStyle.CircularLED;
                        break;
                    // Set IndicatorStyle as RectangularLED
                    case 1:
                        indicator.IndicatorStyle = IndicatorStyle.RectangularLED;
                        break;
                    // Set IndicatorStyle as RoundedRectangularLED
                    case 2:
                        indicator.IndicatorStyle = IndicatorStyle.RoundedRectangularLED;
                        break;
                    // Set IndicatorStyle as Text
                    case 3:
                        indicator.IndicatorStyle = IndicatorStyle.Text;
                        break;
                }
            }
        }
        /// <summary>
        /// Labelses the distance slider value changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedPropertyChangedEventArgs&lt;System.Double&gt;"/> instance containing the event data.</param>
        void LabelsDistanceSliderValueChanged(object d, RoutedPropertyChangedEventArgs<double> e)
        {
            if (m_scale != null)
                (m_scale.Ticks[2] as TickBase).DistanceFromScale = this.LabelsDistanceSlider.Value;
        }
        /// <summary>
        /// Pointer1s the width slider value changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedPropertyChangedEventArgs&lt;System.Double&gt;"/> instance containing the event data.</param>
        void Pointer1WidthSliderValueChanged(object d, RoutedPropertyChangedEventArgs<double> e)
        {
            if (m_scale != null)
            {
                (m_scale.Pointers[0] as LinearPointer).PointerWidth = this.Pointer1WidthSlider.Value;
                //( m_scale.Pointers[ 1 ] as LinearPointer ).PointerWidth = this.Pointer1WidthSlider.Value;
            }
        }
        /// <summary>
        /// Pointer1s the length slider value changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedPropertyChangedEventArgs&lt;System.Double&gt;"/> instance containing the event data.</param>
        void Pointer1LengthSliderValueChanged(object d, RoutedPropertyChangedEventArgs<double> e)
        {
            if (m_scale != null && m_scale.Pointers[1] is LinearMarkerPointer)
                (m_scale.Pointers[1] as LinearMarkerPointer).PointerLength = this.Pointer1LengthSlider.Value;
        }
        /// <summary>
        /// Distances from scale slider value changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedPropertyChangedEventArgs&lt;System.Double&gt;"/> instance containing the event data.</param>
        void DistanceFromScaleSliderValueChanged(object d, RoutedPropertyChangedEventArgs<double> e)
        {
            if (m_scale != null)
                (m_scale.Ranges[0] as LinearRange).DistanceFromScale = this.DistanceFromScaleSlider.Value;
        }
        /// <summary>
        /// Starts the width slider value changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedPropertyChangedEventArgs&lt;System.Double&gt;"/> instance containing the event data.</param>
        void StartWidthSliderValueChanged(object d, RoutedPropertyChangedEventArgs<double> e)
        {
            if (m_scale != null)
                (m_scale.Ranges[0] as LinearRange).StartWidth = this.StartWidthSlider.Value;
        }
        /// <summary>
        /// Ends the width slider value changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedPropertyChangedEventArgs&lt;System.Double&gt;"/> instance containing the event data.</param>
        void EndWidthSliderValueChanged(object d, RoutedPropertyChangedEventArgs<double> e)
        {
            if (m_scale != null)
                (m_scale.Ranges[0] as LinearRange).EndWidth = this.EndWidthSlider.Value;
        }
        /// <summary>
        /// Starts the value slider value changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedPropertyChangedEventArgs&lt;System.Double&gt;"/> instance containing the event data.</param>
        void StartValueSliderValueChanged(object d, RoutedPropertyChangedEventArgs<double> e)
        {
            if (m_scale != null)
                (m_scale.Ranges[0] as LinearRange).StartValue =RangeStartValueSlider.Value;
        }
        /// <summary>
        /// Ends the value slider value changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedPropertyChangedEventArgs&lt;System.Double&gt;"/> instance containing the event data.</param>
        void EndValueSliderValueChanged(object d, RoutedPropertyChangedEventArgs<double> e)
        {
            if (m_scale != null)
                (m_scale.Ranges[0] as LinearRange).EndValue = this.RangeEndValueSlider.Value;
        }

        /// <summary>
        /// Markers the style changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.Controls.SelectionChangedEventArgs"/> instance containing the event data.</param>
        void MarkerStyleChanged(object d, SelectionChangedEventArgs e)
        {
            if (m_scale != null && m_scale.Pointers[1] is LinearMarkerPointer)
            {
                switch (this.MarkerStyleComboBox.SelectedIndex)
                {
                    // Set MarkerStyle as Rectangle
                    case 0:
                        (m_scale.Pointers[1] as LinearMarkerPointer).MarkerStyle = MarkerStyle.Rectangle;
                        break;
                    // Set MarkerStyle as Ellipse
                    case 1:
                        (m_scale.Pointers[1] as LinearMarkerPointer).MarkerStyle = MarkerStyle.Ellipse;
                        break;
                    // Set MarkerStyle as Triangle
                    case 2:
                        (m_scale.Pointers[1] as LinearMarkerPointer).MarkerStyle = MarkerStyle.Triangle;
                        break;
                    // Set MarkerStyle as Diamond
                    case 3:
                        (m_scale.Pointers[1] as LinearMarkerPointer).MarkerStyle = MarkerStyle.Diamond;
                        break;
                    // Set MarkerStyle as Trapezoid
                    case 4:
                        (m_scale.Pointers[1] as LinearMarkerPointer).MarkerStyle = MarkerStyle.Trapezoid;
                        break;
                    // Set MarkerStyle as Pentagon
                    case 5:
                        (m_scale.Pointers[1] as LinearMarkerPointer).MarkerStyle = MarkerStyle.Pentagon;
                        break;
                }
            }
        }
        /// <summary>
        /// Pointers the position changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.Controls.SelectionChangedEventArgs"/> instance containing the event data.</param>
        void PointerPositionChanged(object d, SelectionChangedEventArgs e)
        {
            if (m_scale != null)
            {
                if (m_scale.Pointers[1] is LinearMarkerPointer)
                {
                    switch (this.PointerPositionComboBox.SelectedIndex)
                    {
                        // Set PointerPlacement as Inside
                        case 0:
                            (m_scale.Pointers[1] as LinearMarkerPointer).PointerPlacement = ScalePlacement.Inside;
                            break;
                        // Set PointerPlacement as Cross
                        case 1:
                            (m_scale.Pointers[1] as LinearMarkerPointer).PointerPlacement = ScalePlacement.Cross;
                            break;
                        // Set PointerPlacement as Outside
                        case 2:
                            (m_scale.Pointers[1] as LinearMarkerPointer).PointerPlacement = ScalePlacement.Outside;
                            break;
                    }
                }
            }
        }
        /// <summary>
        /// Ranges the position changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.Controls.SelectionChangedEventArgs"/> instance containing the event data.</param>
        void RangePositionChanged(object d, SelectionChangedEventArgs e)
        {
            if (m_scale != null)
            {
                switch (this.RangePositionComboBox.SelectedIndex)
                {
                    // Set RangePosition as Inside
                    case 0:
                        (m_scale.Ranges[0] as LinearRange).RangePosition = ScalePlacement.Inside;
                        DistanceFromScaleSlider.IsEnabled = true; 
                        break;
                    // Set RangePosition as Cross
                    case 1:
                        (m_scale.Ranges[0] as LinearRange).RangePosition = ScalePlacement.Cross;
                        DistanceFromScaleSlider.IsEnabled = true; 
                        break;

                    // Set RangePosition as Outside
                    case 2:
                        (m_scale.Ranges[0] as LinearRange).RangePosition = ScalePlacement.Outside;
                        DistanceFromScaleSlider.IsEnabled = true; 
                        break;
                }
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
        /// Handles the Click event of the Button control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.linearGauge.Template = this.Resources["LinearGaugeTemplate"] as ControlTemplate;
        }

        /// <summary>
        /// Clear the Events
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void OnClear(object sender, EventArgs args)
        {
            eventlog.Items.Clear();
        }

        /// <summary>
        /// Checking the contextmenu for clearing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void Contextmenu_chk(object sender, EventArgs args)
        {
            if (tt.Text == "")
                cm.Visibility = Visibility.Collapsed;
            else
                cm.Visibility = Visibility.Visible;
        }
        #endregion

        #region Events 

        /// <summary>
        /// Adds to log.
        /// </summary>
        /// <param name="prop">The prop.</param>
        /// <param name="oldvalue">The oldvalue.</param>
        /// <param name="newvalue">The newvalue.</param>
        public void AddToLog(string prop, string oldvalue, string newvalue)
        {
            TextBlock tt = new TextBlock();
            tt = new TextBlock();
            tt.FontSize = 12;

            tt.Text = prop + " Value Changed Event Fired [Old Value :" + oldvalue + "], [New Value :" + newvalue + "]";
            if (eventlog != null)
            {
                eventlog.Items.Add(tt);
                Scroll.ScrollToBottom();
            }
        }

        /// <summary>
        /// Pointers the value changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        void PointerValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (m_indicator != null && m_scale != null)
            {
                m_indicator.Value = (m_scale.Pointers[0] as LinearPointer).Value;
                AddToLog(e.Property.Name.ToString(), e.OldValue.ToString(), e.NewValue.ToString());
            }
        }
        /// <summary>
        /// Linears the mark tick_ tick height changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private void LinearMarkTick_TickHeightChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AddToLog(e.Property.Name.ToString(), e.OldValue.ToString(), e.NewValue.ToString());
        }

        /// <summary>
        /// Linears the range_ start value changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private void LinearRange_StartValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AddToLog(e.Property.Name.ToString(), e.OldValue.ToString(), e.NewValue.ToString());
        }

        /// <summary>
        /// Linears the range_ end value changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private void LinearRange_EndValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AddToLog(e.Property.Name.ToString(), e.OldValue.ToString(), e.NewValue.ToString());
        }

        /// <summary>
        /// States the range_ start value changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private void StateRange_StartValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AddToLog(e.Property.Name.ToString(), e.OldValue.ToString(), e.NewValue.ToString());
        }

        /// <summary>
        /// States the range_ end value changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private void StateRange_EndValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AddToLog(e.Property.Name.ToString(), e.OldValue.ToString(), e.NewValue.ToString());
        }

        /// <summary>
        /// M_scale_s the major interval value changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private void m_scale_MajorIntervalValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AddToLog(e.Property.Name.ToString(), e.OldValue.ToString(), e.NewValue.ToString());
        }

        /// <summary>
        /// M_scale_s the minor interval value changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private void m_scale_MinorIntervalValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AddToLog(e.Property.Name.ToString(), e.OldValue.ToString(), e.NewValue.ToString());
        }

        /// <summary>
        /// Linears the mark tick_ tick height changed_1.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private void LinearMarkTick_TickHeightChanged_1(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AddToLog(e.Property.Name.ToString(), e.OldValue.ToString(), e.NewValue.ToString());
        }

        /// <summary>
        /// Linears the mark tick_ tick width changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private void LinearMarkTick_TickWidthChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AddToLog(e.Property.Name.ToString(), e.OldValue.ToString(), e.NewValue.ToString());
        }

        /// <summary>
        /// M_indicator_s the indicator style changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private void m_indicator_IndicatorStyleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AddToLog(e.Property.Name.ToString(), e.OldValue.ToString(), e.NewValue.ToString());
        }

        #endregion

        
    }
}
