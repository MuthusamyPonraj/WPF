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
        /// Handles the TextChanged event of the ValueTextBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Controls.TextChangedEventArgs"/> instance containing the event data.</param>
        private void ValueTextBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.digitalGauge1.Value = this.ValueTextBox1.Text;
        }
        /// <summary>
        /// Handles the TextChanged event of the ValueTextBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Controls.TextChangedEventArgs"/> instance containing the event data.</param>
        private void ValueTextBox2_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.digitalGauge2.Value = this.ValueTextBox2.Text;
        }
        /// <summary>
        /// Handles the TextChanged event of the ValueTextBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Controls.TextChangedEventArgs"/> instance containing the event data.</param>
        private void ValueTextBox3_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.digitalGauge3.Value = this.ValueTextBox3.Text;
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
        /// Orientations the seven click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void OrientationSevenClick1(object sender, RoutedEventArgs e)
        {
            digitalGauge1.CharacterType = CharacterType.SegmentSeven;
        }
        /// <summary>
        /// Orientations the fourteen click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void OrientationFourteenClick1(object sender, RoutedEventArgs e)
        {
            digitalGauge1.CharacterType = CharacterType.SegmentFourteen;
        }
        /// <summary>
        /// Orientations the seven click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void OrientationSevenClick2(object sender, RoutedEventArgs e)
        {
            digitalGauge2.CharacterType = CharacterType.SegmentSeven;
        }
        /// <summary>
        /// Orientations the fourteen click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void OrientationFourteenClick2(object sender, RoutedEventArgs e)
        {
            digitalGauge2.CharacterType = CharacterType.SegmentFourteen;
        }
        /// <summary>
        /// Orientations the seven click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void OrientationSevenClick3(object sender, RoutedEventArgs e)
        {
            digitalGauge3.CharacterType = CharacterType.SegmentSeven;
        }
        /// <summary>
        /// Orientations the fourteen click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void OrientationFourteenClick3(object sender, RoutedEventArgs e)
        {
            digitalGauge3.CharacterType = CharacterType.SegmentFourteen;
        }
        #endregion       
    }
}
