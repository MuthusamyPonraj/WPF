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
        }    
        #endregion

        #region Helper methods

        /// <summary>
        /// Orientations the vertical click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void OrientationVerticalClick(object sender, RoutedEventArgs e)
        {
            
            linearGauge.Scales[0].ScaleDirection = Syncfusion.Windows.Gauge.ScaleDirection.Clockwise;
            linearGauge1.Scales[0].ScaleDirection = Syncfusion.Windows.Gauge.ScaleDirection.Clockwise;
            linearGauge2.Scales[0].ScaleDirection = Syncfusion.Windows.Gauge.ScaleDirection.Clockwise;
            linearGauge3.Scales[0].ScaleDirection = Syncfusion.Windows.Gauge.ScaleDirection.Clockwise;
           
        }
        /// <summary>
        /// Orientations the horizontal click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void OrientationHorizontalClick(object sender, RoutedEventArgs e)
        {

            linearGauge.Scales[0].ScaleDirection = Syncfusion.Windows.Gauge.ScaleDirection.CounterClockwise;
            linearGauge1.Scales[0].ScaleDirection = Syncfusion.Windows.Gauge.ScaleDirection.CounterClockwise;
            linearGauge2.Scales[0].ScaleDirection = Syncfusion.Windows.Gauge.ScaleDirection.CounterClockwise;
            linearGauge3.Scales[0].ScaleDirection = Syncfusion.Windows.Gauge.ScaleDirection.CounterClockwise;
 
        }
                
     
                     
        
        #endregion

        

       
    }
}
