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

namespace GaugeControlChecking
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
            InitializeLog();
        }

        /// <summary>
        /// Initializes the log.
        /// </summary>
        public void InitializeLog()
        {

            m_scale.ScaleBarSizeChanged += new PropertyChangedCallback(m_scale_ScaleBarSizeChanged);
            m_scale.StartAngleChanged += new PropertyChangedCallback(m_scale_StartAngleChanged);
            //m_scale.BorderWidthChanged += new PropertyChangedCallback(m_scale_BorderWidthChanged);
            m_scale.RadiusChanged += new PropertyChangedCallback(m_scale_RadiusChanged);
            m_scale.GapSweepAngleChanged += new PropertyChangedCallback(m_scale_GapSweepAngleChanged);
            m_scale.MajorIntervalValueChanged += new PropertyChangedCallback(m_scale_MajorIntervalValueChanged);
            m_scale.MinorIntervalValueChanged += new PropertyChangedCallback(m_scale_MinorIntervalValueChanged);
            m_scale.MaximumChanged += new PropertyChangedCallback(m_scale_MaximumChanged);
            m_scale.PointerCapChanged += new PropertyChangedCallback(m_scale_PointerCapChanged);
            majorLabelTick.AngleChanged += new PropertyChangedCallback(majorLabelTick_AngleChanged);
            majorLabelTick.TickPlacementChanged += new PropertyChangedCallback(majorLabelTick_TickPlacementChanged);
            minorTick.AngleChanged += new PropertyChangedCallback(minorTick_AngleChanged);
            majorTick.AngleChanged += new PropertyChangedCallback(majorTick_AngleChanged);
            minorTick.TickPlacementChanged += new PropertyChangedCallback(minorTick_TickPlacementChanged);
            minorTick.TickShapeChanged += new PropertyChangedCallback(minorTick_TickShapeChanged);
            minorTick.TickStyleChanged += new PropertyChangedCallback(minorTick_TickStyleChanged);
            majorLabelTick.DistanceFromScaleChanged += new PropertyChangedCallback(majorLabelTick_DistanceFromScaleChanged);
            range.RangePositionChanged += new PropertyChangedCallback(range_RangePositionChanged);
            range.DistanceFromScaleChanged += new PropertyChangedCallback(range_DistanceFromScaleChanged);
            //range.BorderWidthChanged += new PropertyChangedCallback(range_BorderWidthChanged);
            range.StartValueChanged += new PropertyChangedCallback(range_StartValueChanged);
            range.EndValueChanged += new PropertyChangedCallback(range_EndValueChanged);
            //range.BorderBrushChanged += new PropertyChangedCallback(range_BorderBrushChanged);
            range.StartWidthChanged += new PropertyChangedCallback(range_StartWidthChanged);
            range.EndWidthChanged += new PropertyChangedCallback(range_EndWidthChanged);
            pointer1.ValueChanged += new PropertyChangedCallback(pointer1_ValueChanged);
            pointer1.PointerLengthChanged += new PropertyChangedCallback(pointer2_PointerLengthChanged);
            pointer1.PointerWidthChanged += new PropertyChangedCallback(pointer2_PointerWidthChanged);
            pointer1.PointerNeedleTypeChanged += new PropertyChangedCallback(pointer2_PointerNeedleTypeChanged);
            pointer1.MarkerStyleChanged += new PropertyChangedCallback(pointer2_MarkerStyleChanged);
            pointer1.NeedleStyleChanged += new PropertyChangedCallback(pointer2_NeedleStyleChanged);
            pointer1.PointerPlacementChanged += new PropertyChangedCallback(pointer1_PointerPlacementChanged);
            m_indicator.StateIndicatorHeightChanged += new PropertyChangedCallback(m_indicator_StateIndicatorHeightChanged);
            m_indicator.StateIndicatorWidthChanged += new PropertyChangedCallback(m_indicator_StateIndicatorWidthChanged);
            m_indicator.IndicatorStyleChanged += new PropertyChangedCallback(m_indicator_IndicatorStyleChanged);
            this.Loaded += new RoutedEventHandler(Window1Loaded);
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
            eventlog.Items.Add(tt);
            Scroll.ScrollToBottom();
        }

        /// <summary>
        /// Majors the label tick_ tick placement changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        void majorLabelTick_TickPlacementChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AddToLog(e.Property.Name.ToString(), e.OldValue.ToString(), e.NewValue.ToString());

        }

        /// <summary>
        /// Majors the label tick_ angle changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        void majorLabelTick_AngleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AddToLog(e.Property.Name.ToString(), e.OldValue.ToString(), e.NewValue.ToString());
        }

        /// <summary>
        /// Majors the label tick_ distance from scale changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        void majorLabelTick_DistanceFromScaleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AddToLog(e.Property.Name.ToString(), e.OldValue.ToString(), e.NewValue.ToString());
        }

        /// <summary>
        /// Minors the tick_ tick style changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        void minorTick_TickStyleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AddToLog(e.Property.Name.ToString(), e.OldValue.ToString(), e.NewValue.ToString());
        }

        /// <summary>
        /// Gauges the image_ resize mode changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        void gaugeImage_ResizeModeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AddToLog(e.Property.Name.ToString(), e.OldValue.ToString(), e.NewValue.ToString());
        }



        /// <summary>
        /// Minors the tick_ tick shape changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        void minorTick_TickShapeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AddToLog(e.Property.Name.ToString(), e.OldValue.ToString(), e.NewValue.ToString());
        }

        /// <summary>
        /// Minors the tick_ tick placement changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        void minorTick_TickPlacementChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AddToLog(e.Property.Name.ToString(), e.OldValue.ToString(), e.NewValue.ToString());
        }

        /// <summary>
        /// Majors the tick_ angle changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        void majorTick_AngleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AddToLog(e.Property.Name.ToString(), e.OldValue.ToString(), e.NewValue.ToString());
        }

        /// <summary>
        /// Minors the tick_ angle changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        void minorTick_AngleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AddToLog(e.Property.Name.ToString(), e.OldValue.ToString(), e.NewValue.ToString());
        }

        /// <summary>
        /// Pointer1_s the pointer placement changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        void pointer1_PointerPlacementChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AddToLog(e.Property.Name.ToString(), e.OldValue.ToString(), e.NewValue.ToString());
        }

        /// <summary>
        /// Pointer2_s the needle style changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        void pointer2_NeedleStyleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AddToLog(e.Property.Name.ToString(), e.OldValue.ToString(), e.NewValue.ToString());
        }

        /// <summary>
        /// Pointer2_s the marker style changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        void pointer2_MarkerStyleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AddToLog(e.Property.Name.ToString(), e.OldValue.ToString(), e.NewValue.ToString());
        }

        /// <summary>
        /// Pointer2_s the pointer needle type changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        void pointer2_PointerNeedleTypeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AddToLog(e.Property.Name.ToString(), e.OldValue.ToString(), e.NewValue.ToString());
        }

        /// <summary>
        /// Pointer2_s the pointer width changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        void pointer2_PointerWidthChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AddToLog(e.Property.Name.ToString(), e.OldValue.ToString(), e.NewValue.ToString());
        }

        /// <summary>
        /// Pointer2_s the pointer length changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        void pointer2_PointerLengthChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AddToLog(e.Property.Name.ToString(), e.OldValue.ToString(), e.NewValue.ToString());
        }

        /// <summary>
        /// Pointer2_s the value changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        void pointer2_ValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AddToLog(e.Property.Name.ToString(), e.OldValue.ToString(), e.NewValue.ToString());
        }

        /// <summary>
        /// Pointer1_s the value changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        void pointer1_ValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AddToLog(e.Property.Name.ToString(), e.OldValue.ToString(), e.NewValue.ToString());
        }

        /// <summary>
        /// Range_s the end width changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        void range_EndWidthChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {

            AddToLog(e.Property.Name.ToString(), e.OldValue.ToString(), e.NewValue.ToString());
        }

        /// <summary>
        /// Range_s the start width changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        void range_StartWidthChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AddToLog(e.Property.Name.ToString(), e.OldValue.ToString(), e.NewValue.ToString());
        }

        /// <summary>
        /// Range_s the border brush changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        void range_BorderBrushChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AddToLog(e.Property.Name.ToString(), e.OldValue.ToString(), e.NewValue.ToString());
        }

        /// <summary>
        /// Range_s the end value changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        void range_EndValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AddToLog(e.Property.Name.ToString(), e.OldValue.ToString(), e.NewValue.ToString());
        }

        /// <summary>
        /// Range_s the start value changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        void range_StartValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AddToLog(e.Property.Name.ToString(), e.OldValue.ToString(), e.NewValue.ToString());
        }

        /// <summary>
        /// Range_s the border width changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        void range_BorderWidthChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AddToLog(e.Property.Name.ToString(), e.OldValue.ToString(), e.NewValue.ToString());
        }

        /// <summary>
        /// Range_s the distance from scale changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        void range_DistanceFromScaleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AddToLog(e.Property.Name.ToString(), e.OldValue.ToString(), e.NewValue.ToString());
        }

        /// <summary>
        /// Range_s the range position changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        void range_RangePositionChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AddToLog(e.Property.Name.ToString(), e.OldValue.ToString(), e.NewValue.ToString());
        }

        /// <summary>
        /// M_scale_s the pointer cap changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        void m_scale_PointerCapChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
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
        /// M_scale_s the minor interval value changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        void m_scale_MinorIntervalValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
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
        /// M_scale_s the gap sweep angle changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        void m_scale_GapSweepAngleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
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
        /// M_scale1_s the radius changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        void m_scale1_RadiusChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
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
        /// M_scale_s the start angle changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        void m_scale_StartAngleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
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
        /// M_indicator_s the indicator style changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        void m_indicator_IndicatorStyleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AddToLog(e.Property.Name.ToString(), e.OldValue.ToString(), e.NewValue.ToString());
        }

        /// <summary>
        /// M_indicator_s the state indicator width changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        void m_indicator_StateIndicatorWidthChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AddToLog(e.Property.Name.ToString(), e.OldValue.ToString(), e.NewValue.ToString());

        }

        /// <summary>
        /// M_indicator_s the state indicator height changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        void m_indicator_StateIndicatorHeightChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AddToLog(e.Property.Name.ToString(), e.OldValue.ToString(), e.NewValue.ToString());

        }
        #endregion

        #region Helper Methods

        /// <summary>
        /// Window1s the loaded.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void Window1Loaded(object sender, RoutedEventArgs e)
        {
            (m_scale.Pointers[0] as CircularPointer).PointerLength = this.Pointer1LengthSlider.Value;
            (m_scale.Pointers[0] as CircularPointer).PointerWidth = this.Pointer1WidthSlider.Value;

            int count = m_scale.Ticks.Count;
            for (int i = 0; i < count; i++)
            {
                if (m_scale.Ticks[i] is CircularMarkTick)
                {
                    CircularMarkTick tick = m_scale.Ticks[i] as CircularMarkTick;
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

            switch (this.PointerPositionComboBox.SelectedIndex)
            {
                case 0:
                    (m_scale.Pointers[0] as CircularPointer).PointerPlacement = ScalePlacement.Inside;
                    break;
                case 1:
                    (m_scale.Pointers[0] as CircularPointer).PointerPlacement = ScalePlacement.Cross;
                    break;
                case 2:
                    (m_scale.Pointers[0] as CircularPointer).PointerPlacement = ScalePlacement.Outside;
                    break;
            }
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
                    if (m_scale.Ticks[i] is CircularMarkTick)
                    {
                        CircularMarkTick tick = m_scale.Ticks[i] as CircularMarkTick;
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
                    if (m_scale.Ticks[i] is CircularMarkTick)
                    {
                        CircularMarkTick tick = m_scale.Ticks[i] as CircularMarkTick;
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
                    if (m_scale.Ticks[i] is CircularLabelTick)
                    {
                        CircularLabelTick tick = m_scale.Ticks[i] as CircularLabelTick;
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
            if (circularGauge1 != null)
            {
                if (this.circularGauge1.StateIndicators.Count > 0)
                {
                    StateIndicator indicator = this.circularGauge1.StateIndicators[0];
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
        }

        /// <summary>
        /// Pointers the type changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.Controls.SelectionChangedEventArgs"/> instance containing the event data.</param>
        void PointerTypeChanged(object d, SelectionChangedEventArgs e)
        {
            if (m_scale != null && NeedleStyleComboBox!=null)
            {
                switch (this.PointerTypeComboBox.SelectedIndex)
                {
                    // Set PointerNeedleType as Needle
                    case 0:
                        (m_scale.Pointers[0] as CircularPointer).PointerNeedleType = PointerNeedleType.Needle;
                        NeedleStyleComboBox.IsEnabled = true;
                        MarkerStyleComboBox.IsEnabled = false;
                        PointerPositionComboBox.IsEnabled = false;
                        Pointer1LengthSlider.IsEnabled = true;
                        Pointer1LengthSlider.Value = 150;
                        break;
                    // Set PointerNeedleType as Marker
                    case 1:
                        (m_scale.Pointers[0] as CircularPointer).PointerNeedleType = PointerNeedleType.Marker;
                        NeedleStyleComboBox.IsEnabled = false;
                        MarkerStyleComboBox.IsEnabled = true;
                        PointerPositionComboBox.IsEnabled = true;
                        Pointer1LengthSlider.Value = 50;
                        Pointer1LengthSlider.IsEnabled = false;
                        break;
                    // Set PointerNeedleType as Bar
                    case 2:
                        (m_scale.Pointers[0] as CircularPointer).PointerNeedleType = PointerNeedleType.Bar;
                        NeedleStyleComboBox.IsEnabled = false;
                        MarkerStyleComboBox.IsEnabled = false;
                        PointerPositionComboBox.IsEnabled = false;
                        Pointer1LengthSlider.IsEnabled = false;
                        Pointer1LengthSlider.Value = 150;
                        break;
                }
            }
        }

        /// <summary>
        /// Markers the style changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.Controls.SelectionChangedEventArgs"/> instance containing the event data.</param>
        void MarkerStyleChanged(object d, SelectionChangedEventArgs e)
        {
            if (m_scale != null)
            {
                switch (this.MarkerStyleComboBox.SelectedIndex)
                {
                    // Set MarkerStyle as Rectangle
                    case 0:
                        (m_scale.Pointers[0] as CircularPointer).MarkerStyle = MarkerStyle.Rectangle;
                        break;
                    // Set MarkerStyle as Ellipse
                    case 1:
                        (m_scale.Pointers[0] as CircularPointer).MarkerStyle = MarkerStyle.Ellipse;
                        break;
                    // Set MarkerStyle as Triangle
                    case 2:
                        (m_scale.Pointers[0] as CircularPointer).MarkerStyle = MarkerStyle.Triangle;
                        break;
                    // Set MarkerStyle as Diamond
                    case 3:
                        (m_scale.Pointers[0] as CircularPointer).MarkerStyle = MarkerStyle.Diamond;
                        break;
                    // Set MarkerStyle as Trapezoid
                    case 4:
                        (m_scale.Pointers[0] as CircularPointer).MarkerStyle = MarkerStyle.Trapezoid;
                        break;
                    // Set MarkerStyle as Pentagon
                    case 5:
                        (m_scale.Pointers[0] as CircularPointer).MarkerStyle = MarkerStyle.Pentagon;
                        break;
                }
            }
        }

        /// <summary>
        /// Needles the style changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.Controls.SelectionChangedEventArgs"/> instance containing the event data.</param>
        void NeedleStyleChanged(object d, SelectionChangedEventArgs e)
        {
            if (m_scale != null)
            {
                switch (this.NeedleStyleComboBox.SelectedIndex)
                {
                    // Set NeedleStyle as Triangle
                    case 0:
                        (m_scale.Pointers[0] as CircularPointer).NeedleStyle = NeedleStyle.Triangle;
                        break;
                    // Set NeedleStyle as Rectangle
                    case 1:
                        (m_scale.Pointers[0] as CircularPointer).NeedleStyle = NeedleStyle.Rectangle;
                        break;
                    // Set NeedleStyle as Trapezoid
                    case 2:
                        (m_scale.Pointers[0] as CircularPointer).NeedleStyle = NeedleStyle.Trapezoid;
                        break;
                    // Set NeedleStyle as Arrow
                    case 3:
                        (m_scale.Pointers[0] as CircularPointer).NeedleStyle = NeedleStyle.Arrow;
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
                switch (this.PointerPositionComboBox.SelectedIndex)
                {
                    // Set PointerPlacement as Inside
                    case 0:
                        (m_scale.Pointers[0] as CircularPointer).PointerPlacement = ScalePlacement.Inside;
                        break;
                    // Set PointerPlacement as Cross
                    case 1:
                        (m_scale.Pointers[0] as CircularPointer).PointerPlacement = ScalePlacement.Cross;
                        break;
                    // Set PointerPlacement as Outside
                    case 2:
                        (m_scale.Pointers[0] as CircularPointer).PointerPlacement = ScalePlacement.Outside;
                        break;
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
                        (m_scale.Ranges[0] as CircularRange).RangePosition = ScalePlacement.Inside;
                        break;
                    // Set RangePosition as Cross
                    case 1:
                        (m_scale.Ranges[0] as CircularRange).RangePosition = ScalePlacement.Cross;
                        break;
                    // Set RangePosition as Outside
                    case 2:
                        (m_scale.Ranges[0] as CircularRange).RangePosition = ScalePlacement.Outside;
                        break;
                }
            }
        }

        /// <summary>
        /// Maximum Slider value changed.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedPropertyChangedEventArgs"/> instance containing the event data.</param>
        private void MaximumSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (pointer1 != null)
            {
                if (pointer1.Value > MaximumSlider.Value)
                {
                    pointer1.Value = MaximumSlider.Value;
                }
                if (range.EndValue > MaximumSlider.Value)
                {
                    range.EndValue = MaximumSlider.Value;
                }
                if (range.StartValue > MaximumSlider.Value)
                {
                    range.StartValue = MaximumSlider.Value;
                }
            }
        }

        /// <summary>
        /// Minimum Slider value changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedPropertyChangedEventArgs"/> instance containing the event data.</param>
        private void MinimumSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (pointer1.Value < MinimumSlider.Value)
            {
                pointer1.Value = MinimumSlider.Value;
            }
            if (range.StartValue < MinimumSlider.Value)
            {
                range.StartValue = MinimumSlider.Value;
            }
            if (range.EndValue < MinimumSlider.Value)
            {
                range.EndValue = MinimumSlider.Value;
            }
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

        private void pointer1_ValueChanged_1(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            circularGauge1.StateIndicators[0].Value = Convert.ToDouble(e.NewValue);
        }
    }
}
