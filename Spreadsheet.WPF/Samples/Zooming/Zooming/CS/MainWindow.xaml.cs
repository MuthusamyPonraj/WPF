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
using Syncfusion.Windows.Tools.Controls;
using System.IO;
using Syncfusion.Windows.Controls.Spreadsheet;
using System.ComponentModel;
using Syncfusion.XlsIO;
using Zooming.ViewModel;

namespace Zooming
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : RibbonWindow,IMainView
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainViewModel(this);
        }

        public void ZoomIn()
        {
            this.SpreadsheetZoomSlider.Value += 0.1;
        }

        public void ZoomOut()
        {
            this.SpreadsheetZoomSlider.Value -= 0.1;
        }

        public void ZoomScaleChanged()
        {
            if (this.spreadSheetControl.GridProperties.ActiveSpreadsheetGrid != null)
                this.spreadSheetControl.GridProperties.ActiveSpreadsheetGrid.ZoomScale = this.SpreadsheetZoomSlider.Value;
        }
    }
}
