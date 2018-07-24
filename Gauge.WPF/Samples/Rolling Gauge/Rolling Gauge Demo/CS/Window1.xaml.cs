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

namespace RollingGaugeDemo
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            this.cmbunitposition.ItemsSource = new List<UnitPosition> { UnitPosition.Start, UnitPosition.End };
            this.cmbdirection.ItemsSource = new List<Direction> { Direction.AnitClockwise, Direction.Clockwise };
            this.Loaded += new RoutedEventHandler(Window1_Loaded);
        }

        void Window1_Loaded(object sender, RoutedEventArgs e)
        {
            this.cmbdirection.SelectedItem = Direction.Clockwise;
            this.rollingGauge1.IsNumeric = false;
            this.rollingGauge1.SegmentCount = 10;
            this.txtrollvalue.Text = "syncfusion";
        }

        private void isnumeric_Click(object sender, RoutedEventArgs e)
        {
            if (this.isnumeric.IsChecked == true)
            {
                this.numericgauge_sp.Visibility = Visibility.Visible;
                this.rollinggauge_sp.Visibility = Visibility.Collapsed;
                this.rollingGauge1.IsNumeric = true;
                this.txtminvalue.Text = "0";
                this.rollingGauge1.MinValue = 0;
                this.txtmaxvalue.Text = "9999";
                this.rollingGauge1.MaxValue = 9999;
                this.value_numeric.Text = "0";
            }
            else
            {
                this.numericgauge_sp.Visibility = Visibility.Collapsed;
                this.rollinggauge_sp.Visibility = Visibility.Visible;
                this.rollingGauge1.IsNumeric = false;
                this.rollingGauge1.SegmentCount = 10;
                this.txtrollvalue.Text = "syncfusion";
                this.rollingGauge1.Value = "syncfusion";
                this.cmbdirection.SelectedItem = Direction.Clockwise;
            }
        }

        private void cmbdirection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.rollingGauge1.Direction = (Direction)this.cmbdirection.SelectedItem;
        }

        private void txtrollvalue_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.rollingGauge1.Value = this.txtrollvalue.Text == "" ? " " : this.txtrollvalue.Text;
        }

        private void Border_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = false;
            if (e.Key == Key.Up)
            {
                if (this.rollingGauge1.IsNumeric == true)
                {
                    double value;
                    double.TryParse(this.rollingGauge1.Value, out value);
                    this.value_numeric.Text = (value + 1).ToString();
                    this.rollingGauge1.Value = this.value_numeric.Text;
                    e.Handled = true;
                }
            }
            if (e.Key == Key.Down)
            {
                if (this.rollingGauge1.IsNumeric == true)
                {
                    double value;
                    double.TryParse(this.rollingGauge1.Value, out value);
                    this.value_numeric.Text = (value - 1).ToString();
                    this.rollingGauge1.Value = this.value_numeric.Text;
                    e.Handled = true;
                }
            }
        }

        private void value_numeric_LostFocus(object sender, RoutedEventArgs e)
        {
            this.rollingGauge1.Value = this.value_numeric.Text;
        }

        private void value_numeric_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                this.rollingGauge1.Value = this.value_numeric.Text;
                e.Handled = true;
            }
        }

        private void rollingGauge1_ValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (rollingGauge1.IsNumeric)
                this.value_numeric.Text = this.rollingGauge1.Value;
            else
                this.txtrollvalue.Text = this.rollingGauge1.Value;
        }
    }

    public class TextToIntegerConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int temp;
            int.TryParse(value.ToString(), out temp);
            return temp;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value.ToString();
        }
    }

    public class TextToDoubleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            double temp;
            double.TryParse(value.ToString(), out temp);
            return temp;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value.ToString();
        }
    }
}
