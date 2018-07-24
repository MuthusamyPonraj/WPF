#region Copyright Syncfusion Inc. 2001 - 2010
// Copyright Syncfusion Inc. 2001 - 2010. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
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
using System.Windows.Media.Animation;
using System.Diagnostics;
using Syncfusion.Windows.Shared;

namespace AnimateDemo_2008
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        //Public Variables
        Random random = new Random();

        public Window1()
        {
            InitializeComponent();

            //Clear the SymbolPaletteGroup and SymbolPaletteFilter
            diagramControl.SymbolPalette.SymbolGroups.RemoveAt(1);
            diagramControl.SymbolPalette.SymbolFilters.Remove(diagramControl.SymbolPalette.SymbolFilters[2]);

            //Skin.ShinyBlue
            //Call Animation Function
            roamAnimate(this.Roam);
            scaleAnimate(Smile);
            tossCoin(Dollar);
            skew(Snow);

        }

        #region PrivateFunctions

        //Skew Animation
        private void skew(Node Snow)
        {
            DoubleAnimation skewA = new DoubleAnimation(0, 180, new TimeSpan(0, 0, 0, 0, 3000));
            DoubleAnimation skewB = new DoubleAnimation(0, 180, new TimeSpan(0, 0, 0, 0, 3000));
            skewA.AutoReverse = true;
            skewA.RepeatBehavior = RepeatBehavior.Forever;
            TransformGroup tg = new TransformGroup();
            SkewTransform xst = new SkewTransform();
            xst.CenterX = 25;
            xst.CenterY = 25;
            SkewTransform yst = new SkewTransform();
            yst.CenterX = 25;
            yst.CenterY = 25;

            tg.Children.Add(xst);
            tg.Children.Add(yst);

            Snow.AllowResize = false;
            Snow.RenderTransform = tg;
            xst.BeginAnimation(SkewTransform.AngleXProperty, skewA);
            yst.BeginAnimation(SkewTransform.AngleYProperty, skewB);
        }

        //Toss Animation
        private void tossCoin(Node Dollar)
        {
            DoubleAnimation scaleA = new DoubleAnimation(1, 0, new TimeSpan(0, 0, 0, 0, 200));
            DoubleAnimation ttA = new DoubleAnimation(0, -100, new TimeSpan(0, 0, 0, 0, 1000));
            ttA.AutoReverse = true;
            ttA.RepeatBehavior = RepeatBehavior.Forever;
            scaleA.AutoReverse = true;
            scaleA.RepeatBehavior = RepeatBehavior.Forever;
            TransformGroup tg = new TransformGroup();
            TranslateTransform tt = new TranslateTransform();
            ScaleTransform xst = new ScaleTransform();
            ScaleTransform yst = new ScaleTransform();
            yst.CenterX = 25;
            yst.CenterY = 25;
            tg.Children.Add(yst);
            tg.Children.Add(tt);

            Dollar.AllowResize = false;
            Dollar.RenderTransform = tg;
            xst.BeginAnimation(ScaleTransform.ScaleXProperty, scaleA);
            yst.BeginAnimation(ScaleTransform.ScaleYProperty, scaleA);
            tt.BeginAnimation(TranslateTransform.YProperty, ttA);
        }

        //Scale Animation
        private void scaleAnimate(Node Smile)
        {
            Smile.RenderTransformOrigin = new Point(0, 0);
            DoubleAnimation scaleA = new DoubleAnimation(1, 2, new TimeSpan(0, 0, 0, 0, 1000));
            scaleA.AutoReverse = true;
            scaleA.RepeatBehavior = RepeatBehavior.Forever;
            TransformGroup tg = new TransformGroup();
            ScaleTransform xst = new ScaleTransform();
            xst.CenterX = 25;
            xst.CenterY = 25;
            ScaleTransform yst = new ScaleTransform();
            yst.CenterX = 25;
            yst.CenterY = 25;
            tg.Children.Add(xst);
            tg.Children.Add(yst);
            Smile.AllowResize = false;
            Smile.RenderTransform = tg;
            xst.BeginAnimation(ScaleTransform.ScaleXProperty, scaleA);
            yst.BeginAnimation(ScaleTransform.ScaleYProperty, scaleA);

        }

        void yA_Completed(object sender, EventArgs e)
        {
            foreach (Node n in diagramModel.Nodes)
            {
                if (n.Tag != null)
                {
                    (n.Tag as DoubleAnimation).Completed -= yA_Completed;
                    n.Level = (n.Level + 1) % 4;
                    roamAnimate(n);
                }
            }
        }
        //Roam Animation
        private void roamAnimate(Node n)
        {
            Point target = getPoint(n.Level, n);
            DoubleAnimation rotA;
            DoubleAnimation xA = new DoubleAnimation(n.RenderTransform.Value.OffsetX, target.X, new TimeSpan(0, 0, 0, 0, 3000));
            DoubleAnimation yA = new DoubleAnimation(n.RenderTransform.Value.OffsetY, target.Y, new TimeSpan(0, 0, 0, 0, 3000));
            DoubleAnimation sA;

            if (n.RenderTransform.Value.M11 <= 1.5)
            {
                rotA = new DoubleAnimation(0, 360, new TimeSpan(0, 0, 0, 0, 3000));
                sA = new DoubleAnimation(1, 2, new TimeSpan(0, 0, 0, 0, 3000));
            }
            else
            {
                rotA = new DoubleAnimation(360, 0, new TimeSpan(0, 0, 0, 0, 3000));
                sA = new DoubleAnimation(2, 1, new TimeSpan(0, 0, 0, 0, 3000));
            }
            n.Tag = rotA;
            rotA.Completed += new EventHandler(yA_Completed);
            TransformGroup tg = new TransformGroup();
            RotateTransform rt = new RotateTransform();
            TranslateTransform xtt = new TranslateTransform();
            TranslateTransform ytt = new TranslateTransform();
            ScaleTransform xst = new ScaleTransform();
            ScaleTransform yst = new ScaleTransform();

            tg.Children.Add(rt);
            tg.Children.Add(xst);
            tg.Children.Add(yst);
            tg.Children.Add(xtt);
            tg.Children.Add(ytt);

            n.AllowResize = false;
            n.RenderTransform = tg;
            n.RenderTransformOrigin = new Point(0.5, 0.5);

            rt.BeginAnimation(RotateTransform.AngleProperty, rotA);
            xtt.BeginAnimation(TranslateTransform.XProperty, xA);
            ytt.BeginAnimation(TranslateTransform.YProperty, yA);
            xst.BeginAnimation(ScaleTransform.ScaleXProperty, sA);
            yst.BeginAnimation(ScaleTransform.ScaleYProperty, sA);
        }

        private Point getPoint(int p, Node n)
        {
            double X = diagramView.Page.ActualWidth - n.Width;
            double Y = diagramView.Page.ActualHeight - n.Height;
            double x = 0, y = 0;
            switch (p)
            {
                case 0:
                    x = 0;
                    y = random.NextDouble() * Y;
                    break;
                case 1:
                    x = random.NextDouble() * X;
                    y = Y;
                    break;
                case 2:
                    x = X;
                    y = random.NextDouble() * Y;
                    break;
                case 3:
                    x = random.NextDouble() * X;
                    y = 0;
                    break;
            }
            x = x - n.OffsetX;
            y = y - n.OffsetY;
            return new Point(x, y);
        }
        #endregion

        #region ButteonEvent Handlers

        //Initiating the Roam Animation of the selectedNode
        private void RoamEvent(object sender, RoutedEventArgs e)
        {
            foreach (object o in diagramView.SelectionList)
            {
                if (o is Node)
                {
                    Node n = (Node)o;
                    if (n.Tag == null)
                    {
                        roamAnimate(n);
                    }
                }               
            }
            if(roam.IsChecked == true)
            {
                skew1.IsChecked = false;
                toss.IsChecked = false;
                scale.IsChecked = false;
            }
        }

        //Initiating the Skew Animation of the selectedNode
        private void skew(object sender, RoutedEventArgs e)
        {
            foreach (object o in diagramView.SelectionList)
            {
                if (o is Node)
                {
                    (o as Node).Tag = null;
                    skew(o as Node);
                }              
            }
            if(skew1.IsChecked == true)
            {
                roam.IsChecked = false;
                toss.IsChecked = false;
                scale.IsChecked = false;
            }
        }

        //Initiating the Tossing Animation of the selectedNode
        private void tossCoin(object sender, RoutedEventArgs e)
        {
            foreach (object o in diagramView.SelectionList)
            {
                if (o is Node)
                {
                    (o as Node).Tag = null;
                    tossCoin(o as Node);
                }
            }
            if(toss.IsChecked == true)
            {
                roam.IsChecked = false;
                skew1.IsChecked = false;
                scale.IsChecked = false;
            }
        }

        //Initiating the Scaling Animation of the selectedNode
        private void scaleAnimate(object sender, RoutedEventArgs e)
        {
            foreach (object o in diagramView.SelectionList)
            {
                if (o is Node)
                {
                    (o as Node).Tag = null;
                    scaleAnimate(o as Node);
                }
            }
            if(scale.IsChecked == true)
            {
                roam.IsChecked = false;
                skew1.IsChecked = false;
                toss.IsChecked = false;
            }
        }

        #endregion
    }
}
