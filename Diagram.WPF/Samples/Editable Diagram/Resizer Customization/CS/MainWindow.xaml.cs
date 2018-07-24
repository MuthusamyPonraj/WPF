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

namespace ResizerHandleDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        #region Constructor

        public MainWindow()
        {
            InitializeComponent();
            //Creating the Node
            CreateNode();
            //Register the NodeDrop evnet
            diagramView.NodeDrop += new NodeDroppedEventHandler(diagramView_NodeDrop);
        }

        //In NodeDrop event ,the Resizer style will be invoked
        void diagramView_NodeDrop(object sender, NodeDroppedRoutedEventArgs evtArgs)
        {
            if (diagramModel.Nodes.Count > 0)
            {
                if (Resizerstyle.SelectedIndex == 0)
                {
                    ChangeResizer("");
                }
                else if (Resizerstyle.SelectedIndex == 1)
                {
                    ChangeResizer("1");
                }
                else if (Resizerstyle.SelectedIndex == 2)
                {
                    ChangeResizer("2");
                }
            }
        }
        #endregion

        #region Private functions

        //Defines Node Creation
        private void CreateNode()
        {
            Node custom = AddNode("Rectangle", 200, 100, Shapes.Rectangle);
            Node defaultt = AddNode("Ellipse", 350, 250, Shapes.Ellipse);
            Node visio = AddNode("RoundedSquare", 500, 100, Shapes.RoundedSquare);
        }

        //Defines the nodes and adds them to the model.
        private Node AddNode(string name, double offsetX, double offsetY, Shapes s)
        {
            Node node = new Node(Guid.NewGuid(), name);
            node.OffsetX = offsetX;
            node.OffsetY = offsetY;
            node.Shape = s;
            node.Label = name;
            node.IsLabelEditable = true;
            node.IsSelected = true;
            diagramModel.Nodes.Add(node);
            Resizerstyle.SelectedIndex = 1;
            return node;
        }
        #endregion

        #region Change Resizer Style

        //Defines the Different Style for ResizeHandler 
        private void ChangeResizer(string s)
        {
            foreach (Node shape in diagramModel.Nodes)
            {
                if (shape is Node)
                {
                    Node n = shape as Node;
                    n.TopResizer = Application.Current.Resources["TopResizerThumpTemplate" + s] as Style;
                    n.LeftResizer = Application.Current.Resources["LeftResizerThumpTemplate" + s] as Style;
                    n.RightResizer = Application.Current.Resources["RightResizerThumpTemplate" + s] as Style;
                    n.BottomResizer = Application.Current.Resources["BottomResizerThumpTemplate" + s] as Style;
                    n.TopLeftCornerResizer = Application.Current.Resources["TopLeftCornerResizerThumpTemplate" + s] as Style;
                    n.TopRightCornerResizer = Application.Current.Resources["TopRightCornerResizerThumpTemplate" + s] as Style;
                    n.BottomLeftCornerResizer = Application.Current.Resources["BottomLeftCornerResizerThumpTemplate" + s] as Style;
                    n.BottomRightCornerResizer = Application.Current.Resources["BottomRightCornerResizerThumpTemplate" + s] as Style;
                }
            }
        }

        //Intializing the Resizer style
        private void window_Loaded(object sender, RoutedEventArgs e)
        {

            ChangeResizer("1");
        }

        //Change the Styke of the Resizer
        private void ComboBoxItemAdv_Selected(object sender, RoutedEventArgs e)
        {
            ComboBoxItem comboboxitem = (sender as ComboBoxItem);
            switch (comboboxitem.Name)
            {
                case "Style1":
                    ChangeResizer("");
                    break;
                case "Style2":
                    ChangeResizer("1");
                    break;
                case "Style3":
                    ChangeResizer("2"); ;
                    break;
            }
        }
        #endregion

    }
}
