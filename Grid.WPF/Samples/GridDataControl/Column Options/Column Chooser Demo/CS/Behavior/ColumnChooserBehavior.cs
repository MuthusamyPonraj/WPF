using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Interactivity;
using Syncfusion.Windows.Controls.Grid;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ColumnChooserDemo.Behavior
{
    class ColumnChooserBehavior : TargetedTriggerAction<Button>
    {
        /// <summary>
        /// Gets or sets the target object.
        /// </summary>
        /// <value>The target object.</value>
        public object TargetObject
        {
            get { return (object)GetValue(TargetObjectProperty); }
            set { SetValue(TargetObjectProperty, value); }
        }

        public static readonly DependencyProperty TargetObjectProperty =
            DependencyProperty.Register("TargetObject", typeof(object), typeof(ColumnChooserBehavior));


        /// <summary>
        /// Invokes the specified parameter.
        /// </summary>
        /// <param name="parameter">The parameter.</param>
        protected override void Invoke(object parameter)
        {
            var gridDatacontrol = TargetObject as GridDataControl;
            gridDatacontrol.ShowColumnChooser((Chooser) =>
            {
                Chooser.Title = "Customized Column Chooser";
                Chooser.CanAddHiddenColumns = (gridDatacontrol.DataContext as ViewModel).CanAddHiddenColumns;
            });
        }
    }
}
