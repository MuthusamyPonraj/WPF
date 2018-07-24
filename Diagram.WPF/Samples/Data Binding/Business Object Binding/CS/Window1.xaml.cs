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
using Syncfusion.Windows.Diagram;
using Syncfusion.Windows.Shared;

namespace BusinessObjectBindingDemo_2008
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();

            //Root Ndde
            Node n = new Node();
            //Specifting content template for the root node.
            n.ContentTemplate = App.Current.Resources["RootNodeTemplate"] as DataTemplate;
            n.Content = "Country Sales List";

            //Adding the rootnode to the model.
            this.diagramModel.Nodes.Add(n);

            //Specifying the layout root.
            this.diagramModel.LayoutRoot = n;

            //Specifying spacing between properties.
            diagramModel.VerticalSpacing = 70;
            diagramModel.HorizontalSpacing = 30;
        }
    }
}
