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
using Syncfusion.Windows.Controls.Grid;
using System.Collections.ObjectModel;
using Syncfusion.Windows.Shared;


namespace ColumnBasedSizingDemo
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : ChromelessWindow
    {
        public Window1()
        {
            InitializeComponent();
            
            this.DataContext = new ColumnBasedSizingDemo.ViewModel();
        }

        //void unitTypeCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    this.dataGrid.ColumnSizer = (GridControlLengthUnitType)this.unitTypeCombo.SelectedValue;
        //    this.dataGrid.Model.InvalidateCell(GridRangeInfo.Table());
        //}              
    }
}
