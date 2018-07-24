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
using Syncfusion.Windows.Controls.Map;
using System.Collections.ObjectModel;
using Syncfusion.Windows.SampleLayout;

namespace SimpleMapsDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : SampleLayoutWindow
    {
        #region Constructor

        public MainWindow()
        {
            InitializeComponent();
            this.shapeControl.ShapeCollection.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(ShapeCollection_CollectionChanged);
        }

        void ShapeCollection_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
        }
            

        #endregion

   
     
    }
}
