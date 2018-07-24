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

namespace DigitalGaugeDemo
{

    public partial class Window1 : Window
    {
        /// <summary>
        /// Interaction logic for Window1.xaml
        /// </summary>

        #region Private Members

        /// <summary>
        /// PrivateMembers
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
            EventsLog();
        }

        public void EventsLog()
        {
            // Subscribe the CenterFrameFillColor property changed event
            //digitalGauge.CenterFrameFillColorChanged += new PropertyChangedCallback(digitalGauge_CenterFrameFillColorChanged);
            // Subscribe the CharacterCount property changed event
            digitalGauge.CharacterCountChanged += new PropertyChangedCallback(digitalGauge_CharacterCountChanged);
            // Subscribe the CharacterHeight property changed event
            digitalGauge.CharacterHeightChanged += new PropertyChangedCallback(digitalGauge_CharacterHeightChanged);
            // Subscribe the CharacterSpacing property changed event
            digitalGauge.CharacterSpacingChanged += new PropertyChangedCallback(digitalGauge_CharacterSpacingChanged);
            // Subscribe the CharacterType property changed event
            digitalGauge.CharacterTypeChanged += new PropertyChangedCallback(digitalGauge_CharacterTypeChanged);
            // Subscribe the DimmedBrush property changed event            
            digitalGauge.DimmedBrushChanged += new PropertyChangedCallback(digitalGauge_DimmedBrushChanged);
            // Subscribe the Foreground property changed event            
            //digitalGauge.ForegroundChanged += new PropertyChangedCallback(digitalGauge_ForegroundBrushChanged);
            // Subscribe the SegmentSpacing property changed event
            digitalGauge.SegmentSpacingChanged += new PropertyChangedCallback(digitalGauge_SegmentSpacingChanged);
            // Subscribe the SegmentWidth property changed event
            digitalGauge.SegmentWidthChanged += new PropertyChangedCallback(digitalGauge_SegmentWidthChanged);
            // Subscribe the Value property changed event
            digitalGauge.ValueChanged += new PropertyChangedCallback(digitalGauge_ValueChanged);
            // Subscribe the SkewAngleX property changed event
            digitalGauge.SkewAngleXChanged += new PropertyChangedCallback(digitalGauge_SkewAngleXChanged);
            // Subscribe the SkewAngleY property changed event
            digitalGauge.SkewAngleYChanged += new PropertyChangedCallback(digitalGauge_SkewAngleYChanged);

        }

        #endregion

        #region Events 

        /// <summary>
        /// Digitals the gauge_ SkewAngleX changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        void digitalGauge_SkewAngleXChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AddToLog(e.Property.Name.ToString(), e.OldValue.ToString(), e.NewValue.ToString());
        }

        /// <summary>
        /// Digitals the gauge_ SkewAngleY changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        void digitalGauge_SkewAngleYChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AddToLog(e.Property.Name.ToString(), e.OldValue.ToString(), e.NewValue.ToString());
        }

        /// <summary>
        /// Digitals the gauge_ value changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        void digitalGauge_ValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AddToLog(e.Property.Name.ToString(), e.OldValue.ToString(), e.NewValue.ToString());      
        }

        /// <summary>
        /// Digitals the gauge_ segment width changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        void digitalGauge_SegmentWidthChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AddToLog(e.Property.Name.ToString(), e.OldValue.ToString(), e.NewValue.ToString());
        }

        /// <summary>
        /// Digitals the gauge_ segment spacing changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        void digitalGauge_SegmentSpacingChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AddToLog(e.Property.Name.ToString(), e.OldValue.ToString(), e.NewValue.ToString());
        }

        /// <summary>
        /// Digitals the gauge_ dimmed brush changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        void digitalGauge_DimmedBrushChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AddToLog(e.Property.Name.ToString(), e.OldValue.ToString(), e.NewValue.ToString());
        }

        /// <summary>
        /// Digitals the gauge_ foreground brush changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        void digitalGauge_ForegroundBrushChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AddToLog(e.Property.Name.ToString(), e.OldValue.ToString(), e.NewValue.ToString());
        }

        /// <summary>
        /// Digitals the gauge_ character type changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        void digitalGauge_CharacterTypeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AddToLog(e.Property.Name.ToString(), e.OldValue.ToString(), e.NewValue.ToString());
        }

        /// <summary>
        /// Digitals the gauge_ character spacing changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        void digitalGauge_CharacterSpacingChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AddToLog(e.Property.Name.ToString(), e.OldValue.ToString(), e.NewValue.ToString());
        }

        /// <summary>
        /// Digitals the gauge_ character height changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        void digitalGauge_CharacterHeightChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AddToLog(e.Property.Name.ToString(), e.OldValue.ToString(), e.NewValue.ToString());  
        }

        /// <summary>
        /// Digitals the gauge_ character count changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        void digitalGauge_CharacterCountChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AddToLog(e.Property.Name.ToString(), e.OldValue.ToString(), e.NewValue.ToString());   
        }

        /// <summary>
        /// Digitals the gauge_ center frame fill color changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        void digitalGauge_CenterFrameFillColorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AddToLog(e.Property.Name.ToString(), e.OldValue.ToString(), e.NewValue.ToString());
        }

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


        
        #endregion

        #region Helper methods



        /// <summary>
        /// Handles the TextChanged event of the ValueTextBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Controls.TextChangedEventArgs"/> instance containing the event data.</param>
        private void ValueTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {            
            this.digitalGauge.Value = this.ValueTextBox.Text;
        }
        /// <summary>
        /// Handles the Click event of the Button control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.digitalGauge.Template = this.Resources["LinearGaugeTemplate"] as ControlTemplate;
        }
        /// <summary>
        /// Characters the spacing slider value changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedPropertyChangedEventArgs&lt;System.Double&gt;"/> instance containing the event data.</param>
        void CharacterSpacingSliderValueChanged(object d, RoutedPropertyChangedEventArgs<double> e)
        {
            this.digitalGauge.CharacterSpacing = this.CharacterSpacingSlider.Value;
        }
        /// <summary>
        /// Segments the spacing slider value changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedPropertyChangedEventArgs&lt;System.Double&gt;"/> instance containing the event data.</param>
        void SegmentSpacingSliderValueChanged(object d, RoutedPropertyChangedEventArgs<double> e)
        {
            this.digitalGauge.SegmentSpacing = this.SegmentSpacingSlider.Value;
        }
        /// <summary>
        /// Characters the count slider value changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedPropertyChangedEventArgs&lt;System.Double&gt;"/> instance containing the event data.</param>
        void CharacterCountSliderValueChanged(object d, RoutedPropertyChangedEventArgs<double> e)
        {
            try
            {
                this.digitalGauge.CharacterCount = (int)this.CharacterCountSlider.Value -2;
            }
            catch { }
        }
        /// <summary>
        /// Segments the width slider value changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedPropertyChangedEventArgs&lt;System.Double&gt;"/> instance containing the event data.</param>
        void SegmentWidthSliderValueChanged(object d, RoutedPropertyChangedEventArgs<double> e)
        {
            this.digitalGauge.SegmentWidth = this.SegmentWidthSlider.Value;
        }
        /// <summary>
        /// Characters the height slider value changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedPropertyChangedEventArgs&lt;System.Double&gt;"/> instance containing the event data.</param>
        void CharacterHeightSliderValueChanged(object d, RoutedPropertyChangedEventArgs<double> e)
        {
            this.digitalGauge.CharacterHeight = this.CharacterHeightSlider.Value;
        }
        /// <summary>
        /// Skews the X angle value changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedPropertyChangedEventArgs&lt;System.Double&gt;"/> instance containing the event data.</param>
        void SkewXAngleValueChanged(object d, RoutedPropertyChangedEventArgs<double> e)
        {
            this.digitalGauge.SkewAngleX = this.SkewXAngleSlider.Value;
        }
        /// <summary>
        /// Skews the Y angle value changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedPropertyChangedEventArgs&lt;System.Double&gt;"/> instance containing the event data.</param>
        void SkewYAngleValueChanged(object d, RoutedPropertyChangedEventArgs<double> e)
        {
            this.digitalGauge.SkewAngleY = this.SkewYAngleSlider.Value;
        }
        /// <summary>
        /// Colors the picker2 color changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        void ColorPicker2ColorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (this.digitalGauge != null)
            {
                this.digitalGauge.Foreground = new SolidColorBrush(this.colorPicker2.Color);
            }
        }
        /// <summary>
        /// Colors the picker3 color changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        void ColorPicker3ColorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (this.digitalGauge != null)
            {
                this.digitalGauge.DimmedBrush = new SolidColorBrush(this.colorPicker3.Color);
            }
        }
        /// <summary>
        /// Orientations the seven click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void OrientationSevenClick(object sender, RoutedEventArgs e)
        {
            digitalGauge.CharacterType = CharacterType.SegmentSeven;
        }
        /// <summary>
        /// Orientations the fourteen click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void OrientationFourteenClick(object sender, RoutedEventArgs e)
        {
            digitalGauge.CharacterType = CharacterType.SegmentFourteen;
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
    }
}
