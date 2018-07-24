#region Copyright Syncfusion Inc. 2001 - 2013
// Copyright Syncfusion Inc. 2001 - 2013. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Interactivity;
using Syncfusion.Windows.Controls.Spreadsheet;
using System.Windows.Controls;
using Syncfusion.Windows.Tools.Controls;
using Syncfusion.Windows.Shared;
using System.Windows.Threading;


namespace VisualStyleDemo.Behavior
{
    class SpreadsheetRibbonTrigger : TargetedTriggerAction<SpreadsheetControl>
    {
        RibbonBar VisualStyleRibbonBar;
        protected override void Invoke(object parameter)
        {
            if (this.AssociatedObject != null && this.AssociatedObject is SpreadsheetRibbon)
            {
                SpreadsheetRibbon Ribbon = this.AssociatedObject as SpreadsheetRibbon;
                if (Ribbon.OthersRibbonTab != null && VisualStyleRibbonBar == null)
                {
                    ComboBox comb = new ComboBox();
                    comb.Items.Add("Office2010Blue");
                    comb.Items.Add("Office2010Black");
                    comb.Items.Add("Office2010Silver");
                    comb.SelectedIndex = 0;
                    comb.SelectionChanged += new SelectionChangedEventHandler(ComboBox_SelectionChanged);
                    VisualStyleRibbonBar = new RibbonBar();
                    VisualStyleRibbonBar.Header = "Visual Styles";
                    VisualStyleRibbonBar.Items.Add(comb);
                    Ribbon.OthersRibbonTab.Items.Add(VisualStyleRibbonBar);
                }
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var c = (sender as ComboBox).SelectedItem;
            if (this.AssociatedObject != null && this.Target != null)
            {
                SkinStorage.SetVisualStyle(this.AssociatedObject, c.ToString());
                this.Dispatcher.BeginInvoke(new Action(() =>
                {
                    SkinStorage.SetVisualStyle(this.Target, c.ToString());
                }), DispatcherPriority.ApplicationIdle);
                
            }
        }
    }
}
