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
using System.Collections.ObjectModel;
using System.Reflection;
using Syncfusion.Windows.Chart;
using Syncfusion.Windows.SampleLayout;

namespace CustomChartTypeDemo_2008
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : SampleLayoutWindow
    {
        ObservableCollection<Data> chartData = new ObservableCollection<Data>();
        public Window1()
        {
            InitializeComponent();
            chart.Areas[0].Series[0].ChartType = new HybridChartType();
        }
    }

    
}
