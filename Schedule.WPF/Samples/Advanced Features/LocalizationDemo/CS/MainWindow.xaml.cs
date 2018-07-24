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
using System.Reflection;
using System.Resources;

namespace LocalizationDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        System.Resources.ResourceManager manager;

        #region Constructor

        public MainWindow()
        {
            //Spicify the current culture as French
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("it"); //French

           
            InitializeComponent();

            //Initialize ResourceManager
            //Assembly assembly = Application.Current.GetType().Assembly;
            //manager = new System.Resources.ResourceManager("LocalizationDemo.Resources.Syncfusion.Diagram.Wpf", assembly);

           
        }

        #endregion

        #region Helper Methods

       

        #endregion

    }

    
}
