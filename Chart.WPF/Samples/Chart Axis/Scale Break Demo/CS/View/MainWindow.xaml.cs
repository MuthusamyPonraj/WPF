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
using Syncfusion.Windows.Chart;
using System.Collections.ObjectModel;
using System.Reflection;
using Syncfusion.Windows.SampleLayout;

namespace ScaleBreakDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : SampleLayoutWindow
    {
        ChartBreakRangeInfo info1, info2;
        public MainWindow()
        {
            InitializeComponent();
        }       
    }
}
