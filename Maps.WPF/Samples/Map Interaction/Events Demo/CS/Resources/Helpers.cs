
namespace EventsDemo
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows;
    using System.Windows.Media;

    public class Helpers
    {
        public Helpers()
        {
        }
        static MainWindow mainWindow;
        public static readonly DependencyProperty HandleEventsProperty = DependencyProperty.RegisterAttached("HandleEvents", typeof(object), typeof(Helpers), new PropertyMetadata(false, new PropertyChangedCallback(OnHandleEventsChanged)));

        public static object GetHandleEvents(DependencyObject d)
        {
            return (object)d.GetValue(HandleEventsProperty);
        }

        public static void SetHandleEvents(DependencyObject d, bool value)
        {
            d.SetValue(HandleEventsProperty, value);
        }


        public static void OnHandleEventsChanged(DependencyObject dobj, DependencyPropertyChangedEventArgs args)
        {

            mainWindow = args.NewValue as MainWindow;
            if (mainWindow != null)
            {
                mainWindow.btnReset.Click += new RoutedEventHandler(btnReset_Click);
            }
        }

        static void btnReset_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.Map.ZoomResetCommand.Execute(null);
            mainWindow.Map.PanResetCommand.Execute(null);
        }
        internal static T FindParent<T>(UIElement control) where T : UIElement
        {
            if (control != null)
            {
                UIElement p = VisualTreeHelper.GetParent(control) as UIElement;
                if (p != null)
                {
                    if (p is T)
                        return p as T;
                    else
                        return Helpers.FindParent<T>(p);
                }
            }
            return null;
        }
    }
}
