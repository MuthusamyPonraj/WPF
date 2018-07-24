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
using System.Windows.Shapes;
using Syncfusion.Windows.Tools.Controls;
using System.Windows.Markup;
using System.Windows.Media.Effects;
using Syncfusion.Windows.Diagram;
namespace DiagramBuilder_2010
{
    /// <summary>
    /// Interaction logic for ChildWindow.xaml
    /// </summary>
    public partial class ChildWindow : Window
    {
        internal DiagramView diagramView1;
        static int BackgroundIndex, OffPageBackgroundIndex, PageEffectIndex, PageSettingIndex, PageSetting2Index;
        public ChildWindow(DiagramView pagewindow)
        {
            InitializeComponent();
            diagramView1 = pagewindow as DiagramView;
            this.OKButton.Click += new RoutedEventHandler(OKButton_Click);
            this.ResetButon.Click += new RoutedEventHandler(ResetButon_Click);
            this.SizeToContentCheckBox.Checked += new RoutedEventHandler(SizeToContentCheckBox_Checked);
            this.SizeToContentCheckBox.Unchecked += new RoutedEventHandler(SizeToContentCheckBox_Unchecked);
            this.BoundaryConstraintsEnabledCheckBox.Checked += new RoutedEventHandler(BoundaryConstraintsEnabledCheckBox_Checked);
            if (!(bool)this.SpecifySize.IsChecked)
            {
                this.BoundaryBlock.IsHitTestVisible = false;
                this.BoundaryTextBox.IsHitTestVisible = false;
            }
            this.SizeToContentCheckBox.IsChecked = diagramView1.SizeToContent;
            updatevalue();
            this.Loaded += new RoutedEventHandler(ChildWindow_Loaded);
            this.Closed += new EventHandler(ChildWindow_Closed);
            this.ShowDialog();
        }

        void ChildWindow_Loaded(object sender, RoutedEventArgs e)
        {
           
            this.OKButton.Click += new RoutedEventHandler(OKButton_Click);
            this.ResetButon.Click += new RoutedEventHandler(ResetButon_Click);
            this.SizeToContentCheckBox.Checked += new RoutedEventHandler(SizeToContentCheckBox_Checked);
            this.SizeToContentCheckBox.Unchecked += new RoutedEventHandler(SizeToContentCheckBox_Unchecked);
            this.BoundaryConstraintsEnabledCheckBox.Checked += new RoutedEventHandler(BoundaryConstraintsEnabledCheckBox_Checked);
            if (!(bool)this.SpecifySize.IsChecked)
            {
                this.BoundaryBlock.IsHitTestVisible = false;
                this.BoundaryTextBox.IsHitTestVisible = false;
                this.BoundaryBlock.Opacity = 0.5;
                this.BoundaryTextBox.Opacity = 0.5;
            }
            this.SizeToContentCheckBox.IsChecked = diagramView1.SizeToContent;
            this.BoundaryConstraintsEnabledCheckBox.IsChecked = diagramView1.BoundaryConstraintsEnabled;
            this.PageBackgroundCombo.SelectedIndex = BackgroundIndex;
            this.OffPageBackgroundCombo.SelectedIndex = OffPageBackgroundIndex;
            this.PageEffectCombo.SelectedIndex = PageEffectIndex;
            updatevalue();
        }
        #region Helper Methods

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void ChildWindow_Closed(object sender, EventArgs e)
        {
            BackgroundIndex = this.PageBackgroundCombo.SelectedIndex;
            OffPageBackgroundIndex = this.OffPageBackgroundCombo.SelectedIndex;
            PageEffectIndex = this.PageEffectCombo.SelectedIndex;
            PageSettingIndex = this.PageSettings.SelectedIndex;
            PageSetting2Index = this.PageSettings2.SelectedIndex;
        }

        static ComboBox LoadComboBox(ComboBox comboBox)
        {

            ComboBox combo = XamlReader.Parse(@" <ComboBox xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/presentation"" 
    xmlns:x=""http://schemas.microsoft.com/winfx/2006/xaml"">
            <ComboBoxItem Content=""AliceBlue"" Background=""AliceBlue""/>
            <ComboBoxItem Content=""AntiqueWhite"" Background=""AntiqueWhite""/>
            <ComboBoxItem Content=""Aqua"" Background=""Aqua""/>
            <ComboBoxItem Content=""AquaMarine"" Background=""AquaMarine""/>
            <ComboBoxItem Content=""Azure"" Background=""Azure""/>
            <ComboBoxItem Content=""Beige"" Background=""Beige""/>
            <ComboBoxItem Content=""Bisque"" Background=""Bisque""/>
            <ComboBoxItem Content=""Black"" Background=""Black""/>
            <ComboBoxItem Content=""BlanchedAlmond"" Background=""BlanchedAlmond""/>
            <ComboBoxItem Content=""Blue"" Background=""Blue""/>
            <ComboBoxItem Content=""BlueViolet"" Background=""BlueViolet""/>
            <ComboBoxItem Content=""Brown"" Background=""Brown""/>
            <ComboBoxItem Content=""BurlyWood"" Background=""BurlyWood""/>
            <ComboBoxItem Content=""CadetBlue"" Background=""CadetBlue""/>
            <ComboBoxItem Content=""Chartreuse"" Background=""Chartreuse""/>
            <ComboBoxItem Content=""Chocolate"" Background=""Chocolate""/>
            <ComboBoxItem Content=""Coral"" Background=""Coral""/>
            <ComboBoxItem Content=""CornflowerBlue"" Background=""CornflowerBlue""/>
            <ComboBoxItem Content=""Cornsilk"" Background=""Cornsilk""/>
            <ComboBoxItem Content=""Crimson"" Background=""Crimson""/>
            <ComboBoxItem Content=""Cyan"" Background=""Cyan""/>
            <ComboBoxItem Content=""DarkBlue"" Background=""DarkBlue""/>
            <ComboBoxItem Content=""DarkCyan"" Background=""DarkCyan""/>
            <ComboBoxItem Content=""DarkGoldenrod"" Background=""DarkGoldenrod""/>
            <ComboBoxItem Content=""DarkGray"" Background=""DarkGray""/>
            <ComboBoxItem Content=""DarkGreen"" Background=""DarkGreen""/>
            <ComboBoxItem Content=""DarkKhaki"" Background=""DarkKhaki""/>
            <ComboBoxItem Content=""DarkMagenta"" Background=""DarkMagenta""/>
            <ComboBoxItem Content=""DarkOliveGreen"" Background=""DarkOliveGreen""/>
            <ComboBoxItem Content=""DarkOrange"" Background=""DarkOrange""/>
            <ComboBoxItem Content=""DarkOrchid"" Background=""DarkOrchid""/>
            <ComboBoxItem Content=""DarkRed"" Background=""DarkRed""/>
            <ComboBoxItem Content=""DarkSalmon"" Background=""DarkSalmon""/>
            <ComboBoxItem Content=""DarkSeaGreen"" Background=""DarkSeaGreen""/>
            <ComboBoxItem Content=""DarkSlateBlue"" Background=""DarkSlateBlue""/>
            <ComboBoxItem Content=""DarkSlateGray"" Background=""DarkSlateGray""/>
            <ComboBoxItem Content=""DarkTurquoise"" Background=""DarkTurquoise""/>
            <ComboBoxItem Content=""DarkViolet"" Background=""DarkViolet""/>
            <ComboBoxItem Content=""DeepPink"" Background=""DeepPink""/>
            <ComboBoxItem Content=""DeepSkyBlue"" Background=""DeepSkyBlue""/>
            <ComboBoxItem Content=""DimGray"" Background=""DimGray""/>
            <ComboBoxItem Content=""DodgerBlue"" Background=""DodgerBlue""/>
            <ComboBoxItem Content=""Firebrick"" Background=""Firebrick""/>
            <ComboBoxItem Content=""FloralWhite"" Background=""FloralWhite""/>
            <ComboBoxItem Content=""ForestGreen"" Background=""ForestGreen""/>
            <ComboBoxItem Content=""Fuchsia"" Background=""Fuchsia""/>
            <ComboBoxItem Content=""Gainsboro"" Background=""Gainsboro""/>
            <ComboBoxItem Content=""GhostWhite"" Background=""GhostWhite""/>
            <ComboBoxItem Content=""Gold"" Background=""Gold""/>
            <ComboBoxItem Content=""Goldenrod"" Background=""Goldenrod""/>
            <ComboBoxItem Content=""Gray"" Background=""Gray""/>
            <ComboBoxItem Content=""Green"" Background=""Green""/>
            <ComboBoxItem Content=""GreenYellow"" Background=""GreenYellow""/>
            <ComboBoxItem Content=""Honeydew"" Background=""Honeydew""/>
            <ComboBoxItem Content=""HotPink"" Background=""HotPink""/>
            <ComboBoxItem Content=""IndianRed"" Background=""IndianRed""/>
            <ComboBoxItem Content=""Indigo"" Background=""Indigo""/>
            <ComboBoxItem Content=""Ivory"" Background=""Ivory""/>
            <ComboBoxItem Content=""Khaki"" Background=""Khaki""/>
            <ComboBoxItem Content=""Lavender"" Background=""Lavender""/>
            <ComboBoxItem Content=""LavenderBlush"" Background=""LavenderBlush""/>
            <ComboBoxItem Content=""LawnGreen"" Background=""LawnGreen""/>
            <ComboBoxItem Content=""LemonChiffon"" Background=""LemonChiffon""/>
            <ComboBoxItem Content=""LightBlue"" Background=""LightBlue""/>
            <ComboBoxItem Content=""LightCoral"" Background=""LightCoral""/>
            <ComboBoxItem Content=""LightCyan"" Background=""LightCyan""/>
            <ComboBoxItem Content=""LightGoldenrodYellow"" Background=""LightGoldenrodYellow""/>
            <ComboBoxItem Content=""LightGray"" Background=""LightGray""/>
            <ComboBoxItem Content=""LightGreen"" Background=""LightGreen""/>
            <ComboBoxItem Content=""LightPink"" Background=""LightPink""/>
            <ComboBoxItem Content=""LightSalmon"" Background=""LightSalmon""/>
            <ComboBoxItem Content=""LightSeaGreen"" Background=""LightSeaGreen""/>
            <ComboBoxItem Content=""LightSkyBlue"" Background=""LightSkyBlue""/>
            <ComboBoxItem Content=""LightSlateGray"" Background=""LightSlateGray""/>
            <ComboBoxItem Content=""LightSteelBlue"" Background=""LightSteelBlue""/>
            <ComboBoxItem Content=""LightYellow"" Background=""LightYellow""/>
            <ComboBoxItem Content=""Lime"" Background=""Lime""/>
            <ComboBoxItem Content=""LimeGreen"" Background=""LimeGreen""/>
            <ComboBoxItem Content=""Linen"" Background=""Linen""/>
            <ComboBoxItem Content=""Magenta"" Background=""Magenta""/>
            <ComboBoxItem Content=""Maroon"" Background=""Maroon""/>
            <ComboBoxItem Content=""MediumAquamarine"" Background=""MediumAquamarine""/>
            <ComboBoxItem Content=""MediumBlue"" Background=""MediumBlue""/>
            <ComboBoxItem Content=""MediumOrchid"" Background=""MediumOrchid""/>
            <ComboBoxItem Content=""MediumPurple"" Background=""MediumPurple""/>
            <ComboBoxItem Content=""MediumSeaGreen"" Background=""MediumSeaGreen""/>
            <ComboBoxItem Content=""MediumSlateBlue"" Background=""MediumSlateBlue""/>
            <ComboBoxItem Content=""MediumSpringGreen"" Background=""MediumSpringGreen""/>
            <ComboBoxItem Content=""MediumTurquoise"" Background=""MediumTurquoise""/>
            <ComboBoxItem Content=""MediumVioletRed"" Background=""MediumVioletRed""/>
            <ComboBoxItem Content=""MidnightBlue"" Background=""MidnightBlue""/>
            <ComboBoxItem Content=""MintCream"" Background=""MintCream""/>
            <ComboBoxItem Content=""MistyRose"" Background=""MistyRose""/>
            <ComboBoxItem Content=""Moccasin"" Background=""Moccasin""/>
            <ComboBoxItem Content=""NavajoWhite"" Background=""NavajoWhite""/>
            <ComboBoxItem Content=""Navy"" Background=""Navy""/>
            <ComboBoxItem Content=""OldLace"" Background=""OldLace""/>
            <ComboBoxItem Content=""Olive"" Background=""Olive""/>
            <ComboBoxItem Content=""OliveDrab"" Background=""OliveDrab""/>
            <ComboBoxItem Content=""Orange"" Background=""Orange""/>
            <ComboBoxItem Content=""OrangeRed"" Background=""OrangeRed""/>
            <ComboBoxItem Content=""Orchid"" Background=""Orchid""/>
            <ComboBoxItem Content=""PaleGoldenrod"" Background=""PaleGoldenrod""/>
            <ComboBoxItem Content=""PaleGreen"" Background=""PaleGreen""/>
            <ComboBoxItem Content=""PaleTurquoise"" Background=""PaleTurquoise""/>
            <ComboBoxItem Content=""PaleVioletRed"" Background=""PaleVioletRed""/>
            <ComboBoxItem Content=""PapayaWhip"" Background=""PapayaWhip""/>
            <ComboBoxItem Content=""PeachPuff"" Background=""PeachPuff""/>
            <ComboBoxItem Content=""Peru"" Background=""Peru""/>
            <ComboBoxItem Content=""Pink"" Background=""Pink""/>
            <ComboBoxItem Content=""Plum"" Background=""Plum""/>
            <ComboBoxItem Content=""PowderBlue"" Background=""PowderBlue""/>
            <ComboBoxItem Content=""Purple"" Background=""Purple""/>
            <ComboBoxItem Content=""Red"" Background=""Red""/>
            <ComboBoxItem Content=""RosyBrown"" Background=""RosyBrown""/>
            <ComboBoxItem Content=""RoyalBlue"" Background=""RoyalBlue""/>
            <ComboBoxItem Content=""SaddleBrown"" Background=""SaddleBrown""/>
            <ComboBoxItem Content=""Salmon"" Background=""Salmon""/>
            <ComboBoxItem Content=""SandyBrown"" Background=""SandyBrown""/>
            <ComboBoxItem Content=""SeaGreen"" Background=""SeaGreen""/>
            <ComboBoxItem Content=""SeaShell"" Background=""SeaShell""/>
            <ComboBoxItem Content=""Sienna"" Background=""Sienna""/>
            <ComboBoxItem Content=""Silver"" Background=""Silver""/>
            <ComboBoxItem Content=""SkyBlue"" Background=""SkyBlue""/>
            <ComboBoxItem Content=""SlateBlue"" Background=""SlateBlue""/>
            <ComboBoxItem Content=""SlateGray"" Background=""SlateGray""/>
            <ComboBoxItem Content=""Snow"" Background=""Snow""/>
            <ComboBoxItem Content=""SpringGreen"" Background=""SpringGreen""/>
            <ComboBoxItem Content=""SteelBlue"" Background=""SteelBlue""/>
            <ComboBoxItem Content=""Tan"" Background=""Tan""/>
            <ComboBoxItem Content=""Teal"" Background=""Teal""/>
            <ComboBoxItem Content=""Thistle"" Background=""Thistle""/>
            <ComboBoxItem Content=""Tomato"" Background=""Tomato""/>
            <ComboBoxItem Content=""Transparent"" Background=""Transparent""/>
            <ComboBoxItem Content=""Turquoise"" Background=""Turquoise""/>
            <ComboBoxItem Content=""Violet"" Background=""Violet""/>
            <ComboBoxItem Content=""Wheat"" Background=""Wheat""/>
            <ComboBoxItem Content=""White"" Background=""White""/>
            <ComboBoxItem Content=""WhiteSmoke"" Background=""WhiteSmoke""/>
            <ComboBoxItem Content=""Yellow"" Background=""Yellow""/>
            <ComboBoxItem Content=""YellowGreen"" Background=""YellowGreen""/>
        </ComboBox>") as ComboBox;
            foreach (ComboBoxItem item in combo.Items)
            {
                ComboBoxItem citem = new ComboBoxItem();
                citem.Height = 20;
                citem.Content = item.Content;
                citem.Background = item.Background;
                comboBox.Items.Add(citem);
            }
            return comboBox;
        }

        private void SpecifySize_Checked(object sender, RoutedEventArgs e)
        {
            this.BoundaryStack.IsHitTestVisible = true;
            this.BoundaryStack.Opacity = 1;
            this.OrignalSize.IsChecked = false;
            this.PageSettings.IsEnabled = false;
            this.PageSettings2.IsEnabled = false;
            this.BoundaryBlock.IsHitTestVisible = true;
            this.BoundaryTextBox.IsHitTestVisible = true;
            this.BoundaryBlock.Opacity = 1;
            this.BoundaryTextBox.Opacity = 1;
        }

        private void OrignalSize_Checked(object sender, RoutedEventArgs e)
        {
            if (this.BoundaryStack != null)
            {
                this.SizeToContentCheckBox.IsChecked = false;
                this.BoundaryBlock.IsHitTestVisible = false;
                this.BoundaryBlock.Opacity = 0.5;
                this.BoundaryTextBox.IsHitTestVisible = false;
                this.BoundaryTextBox.Opacity = 0.5;
                this.PageSettings.IsEnabled = true;
                this.PageSettings2.IsEnabled = true;
                this.SpecifySize.IsChecked = false;

            }
        }

        private void boundaryLeft_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!Parsevalue((sender as TextBox).Text.ToString()))
            {
                (sender as TextBox).Text = "0";
            }
        }

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
        private void boundaryRight_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!Parsevalue((sender as TextBox).Text.ToString()))
            {
                (sender as TextBox).Text = "0";
            }
        }

        private void boundaryWidth_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!Parsevalue((sender as TextBox).Text.ToString()))
            {
                (sender as TextBox).Text = "0";
            }
        }

        private void boundaryHeight_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!Parsevalue((sender as TextBox).Text.ToString()))
            {
                (sender as TextBox).Text = "0";
            }
        }

        private void ApplyMargin_Checked(object sender, RoutedEventArgs e)
        {
            this.PageMargin1.IsHitTestVisible = true;
            this.PageMargin1.Opacity = 1;
            this.PageMargin2.IsHitTestVisible = true;
            this.PageMargin2.Opacity = 1;
        }

        private void ApplyMargin_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void LeftMargin_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!Parsevalue((sender as TextBox).Text.ToString()))
            {
                (sender as TextBox).Text = "0";
            }
        }

        private void TopMargin_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!Parsevalue((sender as TextBox).Text.ToString()))
            {
                (sender as TextBox).Text = "0";
            }
        }

        private void RightMargin_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!Parsevalue((sender as TextBox).Text.ToString()))
            {
                (sender as TextBox).Text = "0";
            }
        }

        private void BottomMargin_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!Parsevalue((sender as TextBox).Text.ToString()))
            {
                (sender as TextBox).Text = "0";
            }
        }

        #endregion

        #region NewFeaturesVolume3
        private void PageSize_Click(object sender, RoutedEventArgs e)
        {
           
        }

        void ResetButon_Click(object sender, RoutedEventArgs e)
        {
            updatevalue();
            this.OrignalSize.IsChecked = true;
            this.SizeToContentCheckBox.IsChecked = false;
            this.LeftMargin.Text = "0";
            this.TopMargin.Text = "0";
            this.RightMargin.Text ="0";
            this.BottomMargin.Text = "0";
            this.PageBackgroundCombo.SelectedIndex = 0;
            this.OffPageBackgroundCombo.SelectedIndex = 0;
            this.PageEffectCombo.SelectedIndex = 0;
            diagramView1.BoundaryConstraintsArea = new Rect(50, 50, 1030, 1190);
            this.OKButton_Click(sender, e);
        }
        internal void updatevalue()
        {
            this.boundaryLeft.Text = diagramView1.BoundaryConstraintsArea.Left.ToString();
            this.boundaryRight.Text = diagramView1.BoundaryConstraintsArea.Top.ToString();
            this.boundaryWidth.Text = diagramView1.BoundaryConstraintsArea.Width.ToString();
            this.boundaryHeight.Text = diagramView1.BoundaryConstraintsArea.Height.ToString();
            this.LeftMargin.Text = diagramView1.PageMargin.Left.ToString();
            this.TopMargin.Text = diagramView1.PageMargin.Top.ToString();
            this.RightMargin.Text = diagramView1.PageMargin.Right.ToString();
            this.BottomMargin.Text = diagramView1.PageMargin.Bottom.ToString();
        }
        void BoundaryConstraintsEnabledCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            this.SizeToContentCheckBox.IsChecked = false;
        }

        void SizeToContentCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            if ((bool)this.SpecifySize.IsChecked)
            {
                this.BoundaryBlock.IsHitTestVisible = true;
                this.BoundaryTextBox.IsHitTestVisible = true;
                this.BoundaryBlock.Opacity = 1;
                this.BoundaryTextBox.Opacity = 1;
            }
        }

        void SizeToContentCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            this.BoundaryConstraintsEnabledCheckBox.IsChecked = false;
            this.BoundaryBlock.IsHitTestVisible = false;
            this.BoundaryTextBox.IsHitTestVisible = false;
            this.BoundaryBlock.Opacity = 0.5;
            this.BoundaryTextBox.Opacity = 0.5;
        }
        internal void OKButton_Click(object sender, RoutedEventArgs e)
        {

            Thickness pagethickness = new Thickness(double.Parse(this.LeftMargin.Text), double.Parse(this.TopMargin.Text), double.Parse(this.RightMargin.Text), double.Parse(this.BottomMargin.Text));
            diagramView1.PageMargin = pagethickness;
            if ((bool)this.BoundaryConstraintsEnabledCheckBox.IsChecked)
            {
                diagramView1.BoundaryConstraintsEnabled = true;
            }
            else
            {
                diagramView1.BoundaryConstraintsEnabled = false;
            }
            if ((bool)this.SizeToContentCheckBox.IsChecked)
            {
                diagramView1.SizeToContent = true;
                this.PageSettings.SelectedIndex = -1;
                this.PageSettings2.SelectedIndex = -1;
                this.boundaryHeight.Text = string.Empty;
                this.boundaryRight.Text = string.Empty;
                this.boundaryWidth.Text = string.Empty;
                this.boundaryHeight.Text = string.Empty;
            }
            else
            {
                diagramView1.SizeToContent = false;
                if ((bool)this.OrignalSize.IsChecked)
                {
                    if ((this.PageSettings as ListBox).SelectedIndex == 0)
                    {
                        if ((this.PageSettings2 as ListBox).SelectedIndex == 0)
                        {
                            diagramView1.BoundaryConstraintsArea = new Rect(50, 50, 850, 1190);
                        }
                        else
                        {
                            diagramView1.BoundaryConstraintsArea = new Rect(50, 50, 1900, 2300);
                        }
                    }
                    if ((this.PageSettings as ListBox).SelectedIndex == 1)
                    {
                        if ((this.PageSettings2 as ListBox).SelectedIndex == 0)
                        {
                            diagramView1.BoundaryConstraintsArea = new Rect(50, 50, 1190, 850);
                        }
                        else
                        {
                            diagramView1.BoundaryConstraintsArea = new Rect(50, 50, 2300, 1900);
                        }
                    }
                }
                else
                {
                    this.PageSettings.SelectedIndex = -1;
                    this.PageSettings2.SelectedIndex = -1;
                }
                if ((bool)this.SpecifySize.IsChecked)
                {
                    ApplyBoundaryValue();
                }
            }
            if (this.PageBackgroundCombo.SelectedIndex >= 0)
            {
                diagramView1.PageBackground = (this.PageBackgroundCombo.SelectedItem as ComboBoxItem).Background;
            }
            if (this.OffPageBackgroundCombo.SelectedIndex >= 0)
            {
                diagramView1.OffPageBackground = (this.OffPageBackgroundCombo.SelectedItem as ComboBoxItem).Background;
            }
            ApplyPageEffect(this.PageEffectCombo.SelectedIndex);
            this.Close();
            diagramView1.Page.InvalidateMeasure();
        }
        private void ApplyBoundaryValue()
        {
            Rect newvalue = new Rect(double.Parse(this.boundaryLeft.Text), double.Parse(this.boundaryRight.Text), double.Parse(this.boundaryWidth.Text), double.Parse(this.boundaryHeight.Text));
            diagramView1.BoundaryConstraintsArea = newvalue;
        }

        private void ApplyPageEffect(int i)
        {
            switch (i)
            {
                case 0:
                    CreateEffect(0, 0, 0, 0, 0, 0);
                    break;
                case 1:
                    CreateEffect(10, 110, 69, 39, 100, 20);
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
        private void CreateEffect(int blurradius, int color1, int color2, int color3, int direction, int Shadowdepth)
        {
            drop.BlurRadius = blurradius;
            drop.Color = new Color { R = (byte)color1, G = (byte)color2, B = (byte)color3 };
            drop.Direction = direction;
            drop.ShadowDepth = Shadowdepth;
            diagramView1.BackgroundEffect = drop;
        }

        DropShadowEffect drop = new DropShadowEffect();
        #endregion
    }
}
