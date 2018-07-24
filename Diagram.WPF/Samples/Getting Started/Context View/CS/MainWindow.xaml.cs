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

namespace ContextViewDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            diagramControl.Load(@"..\..\RandomDiagram.xaml");
            this.Loaded+=new RoutedEventHandler(MainWindow_Loaded);
            if (diagramModel.Nodes.Count > 10)
            {
                (diagramModel.Nodes[10] as Node).IsSelected = true;
            }
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            CreateView(ContextViewMode.Neighborhood, diagramControl, NeighbordiagramControl);
            CreateView(ContextViewMode.Predecessors, diagramControl, PredecssordiagramControl);
            CreateView(ContextViewMode.Successors, diagramControl, SuccessordiagramControl);
        }

        private void CreateView(ContextViewMode mode,DiagramControl source,DiagramControl target)
        {
            ContextViewManager ContextView = new ContextViewManager(source, target);
            ContextView.ContextViewMode = mode;
            DirectedTreeLayout layout = new DirectedTreeLayout(diagramModel, diagramView);
            diagramModel.HorizontalSpacing = 10;
            diagramModel.VerticalSpacing = 80;
            diagramModel.SpaceBetweenSubTrees = 10;
            ContextView.Layout = layout;
        }
    }
}
