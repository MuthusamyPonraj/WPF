using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Interactivity;
using Syncfusion.Windows.Controls.Spreadsheet;
using Syncfusion.Windows.Shared;
using System.Windows.Controls;
using System.Windows;

namespace CommandBindingDemo.Behavior
{
    public class SelectionChangedTrigger : TargetedTriggerAction<SpreadsheetControl>
    {
#if Framework3_5
        public DependencyObject  TargetObject
        {
            get { return (DependencyObject )GetValue(TargetObjectProperty); }
            set { SetValue(TargetObjectProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TargetObject.
        public static readonly DependencyProperty TargetObjectProperty =
            DependencyProperty.Register("TargetObject", typeof(DependencyObject ), typeof(SelectionChangedTrigger), new UIPropertyMetadata(null));
#endif
        protected override void Invoke(object parameter)
        {
            if (this.Target != null && this.AssociatedObject != null)
            {
                if (this.AssociatedObject is ComboBox)
                {
                    string VisualStyle = (this.AssociatedObject as ComboBox).SelectedItem.ToString();
                    SkinStorage.SetVisualStyle(this.Target, VisualStyle);
        }
    }
        }
    }
}
