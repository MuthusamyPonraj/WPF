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
using System.Windows.Media.Effects;

namespace PageSettingsDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Public variables

        //declaring the public variables
        DropShadowEffect drop = new DropShadowEffect();
        #endregion

        public MainWindow()
        {
            InitializeComponent();

            ///Initialize Ruler
            diagramView.HorizontalRuler = new HorizontalRuler();
            diagramView.VerticalRuler = new VerticalRuler();
            diagramControl.IsSymbolPaletteEnabled = true;
            //Gridlines
            (diagramView.Page as DiagramPage).GridHorizontalOffset = 60;
            (diagramView.Page as DiagramPage).GridVerticalOffset = 160;
            createNodes();
            InitailizePage();
        }

        #region Event Handlers

        //Reset the Vaues in Left field
        private void BoundaryLeft_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!Parsevalue((sender as TextBox).Text.ToString()))
            {
                (sender as TextBox).Text = "0";
            }
        }

        //Reset the Vaues in TOp field
        private void BoundaryTop_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!Parsevalue((sender as TextBox).Text.ToString()))
            {
                (sender as TextBox).Text = "0";
            }
        }

        //Reset the Vaues in Width field
        private void BoundaryWidth_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!Parsevalue((sender as TextBox).Text.ToString()))
            {
                (sender as TextBox).Text = "0";
            }
        }

        //Reset the Vaues in Height field
        private void BoundaryHeight_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!Parsevalue((sender as TextBox).Text.ToString()))
            {
                (sender as TextBox).Text = "0";
            }
        }

        //Set the Boundary area
        private void BoundaryArea_Click(object sender, RoutedEventArgs e)
        {
            if (double.Parse(this.BoundaryWidth.Text) >= 0 && double.Parse(this.BoundaryHeight.Text) >= 0)
            {
                Rect newvalue = new Rect(double.Parse(this.BoundaryLeft.Text), double.Parse(this.BoundaryTop.Text), double.Parse(this.BoundaryWidth.Text), double.Parse(this.BoundaryHeight.Text));
                diagramView.BoundaryConstraintsArea = newvalue;
                diagramView.Page.InvalidateMeasure();
            }
            else
            {
                MessageBox.Show("Size should not be Negative");
            }
        }

        //Reset the Vaues in LeftMagin field
        private void leftmargin_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!Parsevalue((sender as TextBox).Text.ToString()))
            {
                (sender as TextBox).Text = "0";
            }
        }

        //Reset the Vaues in TopMagin field
        private void TopMargin_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!Parsevalue((sender as TextBox).Text.ToString()))
            {
                (sender as TextBox).Text = "0";
            }
        }

        //Reset the Vaues in RightMagin field
        private void RightMargin_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!Parsevalue((sender as TextBox).Text.ToString()))
            {
                (sender as TextBox).Text = "0";
            }
        }

        //Reset the Vaues in BottomMagin field
        private void BottomMargin_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!Parsevalue((sender as TextBox).Text.ToString()))
            {
                (sender as TextBox).Text = "0";
            }
        }

        //set teh Margin to the DiagramPage
        private void ApplyMargin_Click(object sender, RoutedEventArgs e)
        {
            Thickness pagethickness = new Thickness(double.Parse(this.leftmargin.Text), double.Parse(this.TopMargin.Text), double.Parse(this.RightMargin.Text), double.Parse(this.BottomMargin.Text));
            diagramView.PageMargin = pagethickness;
            diagramView.Page.InvalidateMeasure();
        }

        //For Setting the PageBackground
        private void PageBackgroundCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.PageBackgroundCombo.SelectedIndex >= 0)
            {
                diagramView.PageBackground = (this.PageBackgroundCombo.SelectedItem as ComboBoxItem).Background;
            }
        }

        //For Setting the OffpageBackground
        private void OffpageBackgroundCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.OffpageBackgroundCombo.SelectedIndex >= 0)
            {
                diagramView.OffPageBackground = (this.OffpageBackgroundCombo.SelectedItem as ComboBoxItem).Background;
            }
        }

        //For Setting the PageEffect
        private void PageEffectCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (this.PageEffectCombo.SelectedIndex >= 0)
            {
                ApplyPageEffect(this.PageEffectCombo.SelectedIndex);
            }

        }

        //Parse the value as double
        private bool Parsevalue(string value)
        {
            double valu;
            if (double.TryParse(value, out valu))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //set teh page effect to the DiagramPage
        private void ApplyPageEffect(int i)
        {
            switch (i)
            {
                case 0:
                    CreateEffect(0, 0, 0, 0, 0, 0);
                    break;
                case 1:
                    CreateEffect(10, 110, 69, 39, 320, 10);
                    break;
                case 2:
                    CreateEffect(15, 170, 180, 39, -350, 5);
                    break;
                case 3:
                    CreateEffect(20, 210, 150, 89, 450, 10);
                    break;
                case 4:
                    CreateEffect(30, 150, 100, 120, -300, 12);
                    break;
                default:
                    CreateEffect(25, 79, 148, 205, 450, -2);
                    break;
            }
        }

        //Desired effect is created with teh color ,radius and direction
        private void CreateEffect(int blurradius, int color1, int color2, int color3, int direction, int Shadowdepth)
        {
            drop.BlurRadius = blurradius;
            drop.Color = new Color { R = (byte)color1, G = (byte)color2, B = (byte)color3 };
            drop.Direction = direction;
            drop.ShadowDepth = Shadowdepth;
            drop.Opacity = 1;
            diagramView.BackgroundEffect = drop;
        }
        #endregion

        #region HelperMethods

        //Initialize the DiagramPage with Size
        private void InitailizePage()
        {
            diagramView.PageMargin = new Thickness(40, 10, 10, 50);
            diagramView.BoundaryConstraintsArea = new Rect(10, 20, 775, 1400);
            diagramView.PageBackground = new SolidColorBrush(Colors.White);
            diagramView.OffPageBackground = new SolidColorBrush(Colors.SteelBlue);
            diagramView.SizeToContent = false;
            UpdateRightPanelValue();
        }

        //Upadte the Panel
        private void UpdateRightPanelValue()
        {
            this.leftmargin.Text = "40";
            this.TopMargin.Text = "10";
            this.RightMargin.Text = "10";
            this.BottomMargin.Text = "50";
            this.BoundaryLeft.Text = "10";
            this.BoundaryTop.Text = "20";
            this.BoundaryWidth.Text = "775";
            this.BoundaryHeight.Text = "1400";
        }

        //Craete the Nodes
        public void createNodes()
        {
            //Defines the nodes and adds them to the model.
            Node TextBook = addNode(new SolidColorBrush(Colors.LightSteelBlue), "TextBook", 300, 50, 0, Shapes.FlowChart_Decision, "Text Book/CD-ROM", "FlowChart_Decision", 150, 80, "SubtleEffectPurpleStyle");
            Node CDROM = addNode(new SolidColorBrush(Colors.LightSteelBlue), "CDROM", 520, 210, 1, Shapes.RoundedSquare, "CD-ROM", "RoundedSquare", 150, 50, "SubtleEffectOrangeStyle");
            Node Illustrations = addNode(new SolidColorBrush(Colors.LightSteelBlue), "Illustrations", 315, 350, 1, Shapes.RoundedSquare, "Illustrations", "RoundedSquare", 150, 50, "SubtleEffectOrangeStyle");
            Node Interface = addNode(new SolidColorBrush(Colors.LightSteelBlue), "Interface", 335, 650, 1, Shapes.RoundedSquare, "Interface", "RoundedSquare", 150, 50, "SubtleEffectOrangeStyle");
            Node FinalReview = addNode(new SolidColorBrush(Colors.LightSkyBlue), "FinalReview", 220, 1215, 1, Shapes.RoundedSquare, "Final Review", "RoundedSquare", 150, 50, "SubtleEffectOrangeStyle");
            Node Publish = addNode(new SolidColorBrush(Colors.LightSkyBlue), "Publish", 220, 1316, 1, Shapes.RoundedSquare, "Publish", "RoundedSquare", 150, 50, "SubtleEffectOrangeStyle");
            Node Integration = addNode(new SolidColorBrush(Colors.LightGreen), "Integration", 485, 805, 1, Shapes.RoundedSquare, "Integration", "RoundedSquare", 150, 50, "SubtleEffectOrangeStyle");
            Node Testing = addNode(new SolidColorBrush(Colors.LightGreen), "Testing", 485, 945, 1, Shapes.RoundedSquare, "Testing", "RoundedSquare", 150, 50, "SubtleEffectOrangeStyle");
            Node HelpFile = addNode(new SolidColorBrush(Colors.LightGreen), "HelpFile", 295, 945, 1, Shapes.RoundedSquare, "Help File", "RoundedSquare", 150, 50, "SubtleEffectOrangeStyle");
            Node Review = addNode(new SolidColorBrush(Colors.SteelBlue), "Review", 400, 1080, 1, Shapes.RoundedSquare, "Review", "RoundedSquare", 150, 50, "SubtleEffectOrangeStyle");
            Node ReferenceBook = addNode(new SolidColorBrush(Colors.LightSteelBlue), "ReferenceBook", 45, 210, 1, Shapes.RoundedSquare, "Reference Book", "RoundedSquare", 150, 50, "SubtleEffectOrangeStyle");
            Node CopyEditing = addNode(new SolidColorBrush(Colors.LightSteelBlue), "CopyEditing", 45, 650, 1, Shapes.RoundedSquare, "Copy Editing", "RoundedSquare", 150, 50, "SubtleEffectOrangeStyle");
            Node FirstProof = addNode(new SolidColorBrush(Colors.LightSteelBlue), "FirstProof", 45, 805, 1, Shapes.RoundedSquare, "First Proof", "RoundedSquare", 150, 50, "SubtleEffectOrangeStyle");
            Node SecondProof = addNode(new SolidColorBrush(Colors.LightSteelBlue), "SecondProof", 45, 945, 1, Shapes.RoundedSquare, "Second Proof", "RoundedSquare", 150, 50, "SubtleEffectOrangeStyle");
            Node DocumentComplete = addNode(new SolidColorBrush(Colors.LightSteelBlue), "DocumentComplete", 45, 1080, 1, Shapes.RoundedSquare, "Document Complete", "RoundedSquare", 150, 50, "SubtleEffectOrangeStyle");
            Node MulipleChoiceQuestions = addNode(new SolidColorBrush(Colors.LightSeaGreen), "MulipleChoiceQuestions", 600, 350, 1, Shapes.RoundedSquare, "Muliple Choice Questions", "RoundedSquare", 150, 50, "SubtleEffectOrangeStyle");
            Node Writing = addNode(new SolidColorBrush(Colors.LightSeaGreen), "Writing", 600, 500, 1, Shapes.RoundedSquare, "Writing", "RoundedSquare", 150, 50, "SubtleEffectOrangeStyle");
            Node Editing = addNode(new SolidColorBrush(Colors.LightSeaGreen), "Editing", 600, 650, 1, Shapes.RoundedSquare, "Editing", "RoundedSquare", 150, 50, "SubtleEffectOrangeStyle");

            //Creates the connections for the nodes.
            Connect(CDROM, MulipleChoiceQuestions, DecoratorShape.Circle, DecoratorShape.Arrow);
            Connect(MulipleChoiceQuestions, Writing, DecoratorShape.Circle, DecoratorShape.Arrow);
            Connect(Writing, Editing, DecoratorShape.Circle, DecoratorShape.Arrow);
            Connect(Editing, Integration, DecoratorShape.Circle, DecoratorShape.Arrow);
            Connect(Integration, Testing, DecoratorShape.Circle, DecoratorShape.Arrow);
            Connect(Testing, Review, DecoratorShape.Circle, DecoratorShape.Arrow);
            Connect(HelpFile, Review, DecoratorShape.Circle, DecoratorShape.Arrow);
            Connect(Interface, Integration, DecoratorShape.Circle, DecoratorShape.Arrow);
            Connect(TextBook, CDROM, DecoratorShape.Circle, DecoratorShape.Arrow);
            Connect(TextBook, ReferenceBook, DecoratorShape.Circle, DecoratorShape.Arrow);
            Connect(ReferenceBook, CopyEditing, DecoratorShape.Circle, DecoratorShape.Arrow);
            Connect(CopyEditing, FirstProof, DecoratorShape.Circle, DecoratorShape.Arrow);
            Connect(FirstProof, SecondProof, DecoratorShape.Circle, DecoratorShape.Arrow);
            Connect(SecondProof, DocumentComplete, DecoratorShape.Circle, DecoratorShape.Arrow);
            Connect(DocumentComplete, FinalReview, DecoratorShape.Circle, DecoratorShape.Arrow);
            Connect(FinalReview, Publish, DecoratorShape.Circle, DecoratorShape.Arrow);
            Connect(Review, FinalReview, DecoratorShape.Circle, DecoratorShape.Arrow);
            Connect(Illustrations, CopyEditing, DecoratorShape.Circle, DecoratorShape.Arrow);
        }

        //Craete the Connections
        private void Connect(Node headnode, Node tailnode, DecoratorShape headdecorator, DecoratorShape taildecorator)
        {
            LineConnector conn = new LineConnector();
            conn.HeadNode = headnode;
            conn.TailNode = tailnode;
            conn.HeadDecoratorShape = headdecorator;
            conn.TailDecoratorShape = taildecorator;
            conn.ConnectorType = ConnectorType.Orthogonal;
            conn.LineStyle.Stroke = new SolidColorBrush(Colors.LightSteelBlue);
            conn.TailDecoratorStyle.Stroke = new SolidColorBrush(Colors.SteelBlue);
            conn.TailDecoratorStyle.Fill = new SolidColorBrush(Colors.SteelBlue);
            conn.HeadDecoratorStyle.Stroke = new SolidColorBrush(Colors.SteelBlue);
            conn.HeadDecoratorStyle.Fill = new SolidColorBrush(Colors.SteelBlue);
            diagramModel.Connections.Add(conn);
        }

        //Add the Node to DiagramModel
        private Node addNode(SolidColorBrush background, String name, double offsetx, double offsety, Int32 level, Shapes shape, String label, String tooltip, double width, double height, string CustomStyle)
        {
            Node node = new Node(Guid.NewGuid(), name);
            node.OffsetX = offsetx;
            node.OffsetY = offsety;
            node.Background = background;
            node.Level = level;
            //node.Shape = shape;
            node.Label = label;
            node.ToolTip = tooltip;
            node.Width = width;
            node.Height = height;
            node.LabelVerticalAlignment = VerticalAlignment.Center;
            diagramModel.Nodes.Add(node);
            return node;
        }
        #endregion
    }
}
