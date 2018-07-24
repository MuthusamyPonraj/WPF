namespace ZoomPanDemo
{
    using System;
    using System.Net;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Documents;
    using System.Windows.Ink;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Animation;
    using System.Windows.Shapes;


    #region EventHelpers

    public class PanZoomDemoEventHelpers
    {
        public static readonly DependencyProperty TextChangedProperty = DependencyProperty.RegisterAttached("TextChanged", typeof(ICommand), typeof(PanZoomDemoEventHelpers), new PropertyMetadata(null, new PropertyChangedCallback(OnTextChanged)));
        private static void OnTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            TextBox txtBox = d as TextBox;
            if (txtBox != null)
            {
                txtBox.LostFocus += new RoutedEventHandler(txtBox_LostFocus);
            }
        }

        static void txtBox_LostFocus(object sender, RoutedEventArgs e)
        {
            PanZoomDemoEventHelpers.GetTextChanged(sender as TextBox).Execute(null);
        }

        public static ICommand GetTextChanged(DependencyObject d)
        {
            return (ICommand)d.GetValue(TextChangedProperty);
        }
        public static void SetTextChanged(DependencyObject d, ICommand value)
        {
            d.SetValue(TextChangedProperty, value);
        }
    }

    #endregion
}
