namespace Imagery_Service_Demo
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
    using System.Collections.Generic;

    public class BingMapEventEventHelpers
    {
        #region Command Attached Property

        public static readonly DependencyProperty CommandProperty = DependencyProperty.RegisterAttached("Command", typeof(ICommand), typeof(BingMapEventEventHelpers), new PropertyMetadata(null, new PropertyChangedCallback(OnCommandChanged)));

        private static void OnCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue != null)
            {
                (d as Button).Click += new RoutedEventHandler(BingMapEventEventHelpers_Click);
            }
        }

        static void BingMapEventEventHelpers_Click(object sender, RoutedEventArgs e)
        {
            List<object> param = new List<object>();
            param.Add(BingMapEventEventHelpers.GetParameter(sender as DependencyObject));
            param.Add((sender as Button).Name.ToString());
            BingMapEventEventHelpers.GetCommand(sender as Button).Execute(param);
        }

   
        public static ICommand GetCommand(DependencyObject d)
        {
            return (ICommand)d.GetValue(CommandProperty);
        }

        public static void SetCommand(DependencyObject d, ICommand value)
        {
            d.SetValue(CommandProperty, value);
        }

        #endregion

        #region Parameter Property

        public static readonly DependencyProperty ParamerterProperty = DependencyProperty.RegisterAttached("Parameter", typeof(object), typeof(BingMapEventEventHelpers), new PropertyMetadata(null));

        public static object GetParameter(DependencyObject d)
        {
            return (object)d.GetValue(ParamerterProperty);
        }

        public static void SetParameter(DependencyObject d, object value)
        {
            d.SetValue(ParamerterProperty, value);
        }

        #endregion

    }
}
