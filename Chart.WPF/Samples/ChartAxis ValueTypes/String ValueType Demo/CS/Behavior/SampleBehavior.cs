using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Interactivity;

namespace AxisStringValueTypeDemo
{
    public class SampleBehavior:Behavior<MainWindow>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            this.AssociatedObject.IsAutoSetRangeState.Unchecked += new System.Windows.RoutedEventHandler(IsAutoSetRangeState_Unchecked);
            
            this.AssociatedObject.IsAutoSetRangeState.Checked += new System.Windows.RoutedEventHandler(IsAutoSetRangeState_Checked);
            this.AssociatedObject.Interval.TextChanged+=Interval_TextChanged;
        }

        private void Interval_TextChanged(object sender, System.Windows.RoutedEventArgs e)
        {
            TextBox Interval = sender as TextBox;
            if (Interval.Text != "0" && Interval.Text != "")
            {
                this.AssociatedObject.PrimaryAxis.Interval = double.Parse(Interval.Text);
            }
        }

        void IsIndexedState_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            this.AssociatedObject.Chart.Areas[0].PrimaryAxis.IsAutoSetRange = true;
        }

        void IsAutoSetRangeState_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            this.AssociatedObject.PrimaryAxis.Interval = double.NaN;
        }
        void IsAutoSetRangeState_Unchecked(object sender, System.Windows.RoutedEventArgs e)
        {
          //  this.AssociatedObject.PrimaryAxisGroupBox.Visibility = System.Windows.Visibility.Visible;
          
        }
    }
}
