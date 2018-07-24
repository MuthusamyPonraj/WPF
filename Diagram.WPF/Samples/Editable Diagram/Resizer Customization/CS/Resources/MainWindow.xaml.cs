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
using Syncfusion.Windows.Diagram ;

namespace ResizerHandleDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

       private void ResizerSelection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Resizerhandle.SelectedIndex == 0)
            {
                Node nos = new Node(Guid.NewGuid());
            if (diagramview.SelectionList.Count > 0)
            {
                foreach (INodeGroup shape in diagramview.SelectionList)
                {
                    if (shape is Node)
                    {

                        nos = shape as Node;
                        //ResourceDictionary res = (ResourceDictionary)Application.LoadComponent(new Uri("style2.xaml", UriKind.Relative));

                        Style sty1 = Application.Current.Resources["TopResizerThumpTemplate1"] as Style;
                        Style sty2 = Application.Current.Resources["LeftResizerThumpTemplate1"] as Style;
                        Style sty3 = Application.Current.Resources["RightResizerThumpTemplate1"] as Style;
                        Style sty4 = Application.Current.Resources["BottomResizerThumpTemplate1"] as Style;
                        Style sty5 = Application.Current.Resources["TopLeftCornerResizerThumpTemplate1"] as Style;
                        Style sty6 = Application.Current.Resources["TopRightCornerResizerThumpTemplate1"] as Style;
                        Style sty7 = Application.Current.Resources["BottomLeftCornerResizerThumpTemplate1"] as Style;
                        Style sty8 = Application.Current.Resources["BottomRightCornerResizerThumpTemplate1"] as Style;

                        nos.TopResizer = sty1;
                        nos.LeftResizer = sty2;
                        nos.RightResizer = sty3;
                        nos.BottomResizer = sty4;
                        nos.TopLeftCornerResizer = sty5;
                        nos.TopRightCornerResizer = sty6;
                        nos.BottomLeftCornerResizer = sty7;
                        nos.BottomRightCornerResizer = sty8;
                    }
                }
            }
            else
            {
                MessageBox.Show("Selection.Count is 0");
            }

        
            }
            else if (Resizerhandle.SelectedIndex == 1)
            {
                Node nos = new Node(Guid.NewGuid());
                if (diagramview.SelectionList.Count > 0)
                {
                    foreach (INodeGroup shape in diagramview.SelectionList)
                    {
                        if (shape is Node)
                        {
                            nos = shape as Node;

                            Style sty1 = Application.Current.Resources["TopResizerThumpTemplate2"] as Style;
                            Style sty2 = Application.Current.Resources["LeftResizerThumpTemplate2"] as Style;
                            Style sty3 = Application.Current.Resources["RightResizerThumpTemplate2"] as Style;
                            Style sty4 = Application.Current.Resources["BottomResizerThumpTemplate2"] as Style;
                            Style sty5 = Application.Current.Resources["TopLeftCornerResizerThumpTemplate2"] as Style;
                            Style sty6 = Application.Current.Resources["TopRightCornerResizerThumpTemplate2"] as Style;
                            Style sty7 = Application.Current.Resources["BottomLeftCornerResizerThumpTemplate2"] as Style;
                            Style sty8 = Application.Current.Resources["BottomRightCornerResizerThumpTemplate2"] as Style;


                            nos.TopResizer = sty1;
                            nos.LeftResizer = sty2;

                            nos.RightResizer = sty3;

                            nos.BottomResizer = sty4;

                            nos.TopLeftCornerResizer = sty5;

                            nos.TopRightCornerResizer = sty6;

                            nos.BottomLeftCornerResizer = sty7;

                            nos.BottomRightCornerResizer = sty8;

                        }
                    }
                }
                else
                {
                    MessageBox.Show("Selection.Count is 0");

                }
            }
            else if (Resizerhandle.SelectedIndex == 2)
            {
                Node nos = new Node(Guid.NewGuid());
                if (diagramview.SelectionList.Count > 0)
                {
                    foreach (INodeGroup shape in diagramview.SelectionList)
                    {
                        if (shape is Node)
                        {

                            nos = shape as Node;
                            //ResourceDictionary res = (ResourceDictionary)Application.LoadComponent(new Uri("style3.xaml", UriKind.Relative));


                            Style sty1 = Application.Current.Resources["TopResizerThumpTemplate"] as Style;
                            Style sty2 = Application.Current.Resources["LeftResizerThumpTemplate"] as Style;
                            Style sty3 = Application.Current.Resources["RightResizerThumpTemplate"] as Style;
                            Style sty4 = Application.Current.Resources["BottomResizerThumpTemplate"] as Style;
                            Style sty5 = Application.Current.Resources["TopLeftCornerResizerThumpTemplate"] as Style;
                            Style sty6 = Application.Current.Resources["TopRightCornerResizerThumpTemplate"] as Style;
                            Style sty7 = Application.Current.Resources["BottomLeftCornerResizerThumpTemplate"] as Style;
                            Style sty8 = Application.Current.Resources["BottomRightCornerResizerThumpTemplate"] as Style;

                            nos.TopResizer = sty1;
                            nos.LeftResizer = sty2;
                            nos.RightResizer = sty3;
                            nos.BottomResizer = sty4;
                            nos.TopLeftCornerResizer = sty5;
                            nos.TopRightCornerResizer = sty6;
                            nos.BottomLeftCornerResizer = sty7;
                            nos.BottomRightCornerResizer = sty8;
                        }
                    }

                }
                else
                {
                    MessageBox.Show("Selection.Count is 0");
                }

            }
        }
    }
}
