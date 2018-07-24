using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Interactivity;
using System.Windows;
using Syncfusion.Windows.Chart;

namespace ToolBarDemo
{
    class ToolBarBehavior : Behavior<Window1>
    {
        protected override void OnAttached()
        {
            this.AssociatedObject.btn_show.Click += new RoutedEventHandler(btn_show_Click);
            this.AssociatedObject.btn_close.Click += new RoutedEventHandler(btn_close_Click);
            this.AssociatedObject.btn_addTBItem.Click += new RoutedEventHandler(btn_addTBItem_Click);
            this.AssociatedObject.chartToolbar.SelectedItemChanged += new ChartToolBarEventHandler(chartToolbar_SelectedItemChanged);
            base.OnAttached();
        }

        private void btn_show_Click(object sender, RoutedEventArgs e)
        {
            this.AssociatedObject.Chart1.ShowToolBar();
        }

        private void btn_close_Click(object sender, RoutedEventArgs e)
        {
            this.AssociatedObject.Chart1.CloseToolBar();
        }

        private void chartToolbar_SelectedItemChanged(object sender, ChartToolBarArgs e)
        {
            ToolBarItem oldItem = (ToolBarItem)e.OldValue;
            ToolBarItem newItem = (ToolBarItem)e.NewValue;
            this.AssociatedObject.txt_oldValue.Text = oldItem.ToolTip.ToString();
            this.AssociatedObject.txt_newValue.Text = newItem.ToolTip.ToString();         
        }

        private void btn_addTBItem_Click(object sender, RoutedEventArgs e)
        {
            ToolBarItem toolBarItem = new ToolBarItem();
            toolBarItem.Text = "New";
            toolBarItem.IsDropDown = false;
            toolBarItem.ToolTip = "New Item";
            this.AssociatedObject.Chart1.ToolBar.Items.Add(toolBarItem);
        }
    }
}
