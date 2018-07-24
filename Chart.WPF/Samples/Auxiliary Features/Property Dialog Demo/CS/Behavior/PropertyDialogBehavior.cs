using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Interactivity;
using System.Windows;

namespace PropertyDialogDemo
{
    class PropertyDialogBehavior: Behavior<Window1>
    {
        protected override void OnAttached()
        {
            this.AssociatedObject.btn_PropertyDialog.Click += new RoutedEventHandler(btn_PropertyDialog_Click);
            base.OnAttached();
        }

        private void btn_PropertyDialog_Click(object sender, RoutedEventArgs e)
        {
            this.AssociatedObject.Chart1.ShowPropertyDialog();
        }
    }
}
