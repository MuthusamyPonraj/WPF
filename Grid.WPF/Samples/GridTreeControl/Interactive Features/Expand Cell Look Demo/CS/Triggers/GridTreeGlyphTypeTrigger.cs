using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Interactivity;
using Syncfusion.Windows.Controls.Grid;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ExpandCellLook
{
    class GridTreeGlyphTypeTrigger:TargetedTriggerAction<GridTreeControl>
    {
        /// <summary>
        /// Gets or sets the target object.
        /// </summary>
        /// <value>The target object.</value>
        public object TargetObject
        {
            get { return (object)GetValue(TargetObjectProperty); }
            set { SetValue(TargetObjectProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TargetObject.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TargetObjectProperty =
            DependencyProperty.Register("TargetObject", typeof(object), typeof(GridTreeGlyphTypeTrigger), new PropertyMetadata());

        /// <summary>
        /// Invokes the specified parameter.
        /// </summary>
        /// <param name="parameter">The parameter.</param>
        protected override void Invoke(object parameter)
        {
            bool customDrawingEventHooked = false;
            var treeGrid = this.TargetObject as GridTreeControl;
            if (treeGrid.InternalGrid != null)
            {
                if ((parameter as SelectionChangedEventArgs).AddedItems[0] != null)
                {
                    GridTreeExpandGlyph Item = (GridTreeExpandGlyph)((parameter as SelectionChangedEventArgs).AddedItems[0]);
                    treeGrid.InternalGrid.ExpandGlyphType = Item;
                }

                if (treeGrid.InternalGrid.ExpandGlyphType == GridTreeExpandGlyph.Custom)
                {
                    //need to subscribe to an event and provide the Glyph, bout on subscribe the first time...
                    if (!customDrawingEventHooked)
                    {
                        GridTreeExpanderCellRendererExt renderer = treeGrid.InternalGrid.CellRenderers["ExpanderCell"] as GridTreeExpanderCellRendererExt;
                        if (renderer != null)
                        {
                            renderer.GlyphDrawing += new GridTreeGlyphDrawingHandler(renderer_GlyphDrawing);
                            customDrawingEventHooked = true;
                        }
                    }
                }
                SetColorsBasedOnComboBox();
            }
        }

        /// <summary>
        /// Handles the GlyphDrawing event of the renderer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="args">The <see cref="Syncfusion.Windows.Controls.Grid.GridTreeGlyphDrawingEventArgs"/> instance containing the event data.</param>
        void renderer_GlyphDrawing(object sender, GridTreeGlyphDrawingEventArgs args)
        {
            GridTreeExpanderCellRendererExt renderer = sender as GridTreeExpanderCellRendererExt;
            if (renderer != null)
            {
                //code that draws a circle....
                PathGeometry pg = args.Geometry;
                Point pt0 = args.StartPoint;
                if (args.IsHot)
                {
                    pt0.Offset(1, 5);
                }
                else
                {
                    pt0.Offset(0, 4);
                }
                PathFigure pf = new PathFigure();
                pf.StartPoint = pt0;
                pf.IsClosed = false;
                pf.IsFilled = !args.Opened;
                double r = args.IsHot ? 4 : 5; //raduis
                pt0.Offset(0, .001); //make it essentially a full circle
                ArcSegment seg = new ArcSegment(pt0, new Size(r, r), 0, true, SweepDirection.Clockwise, true);
                pf.Segments.Add(seg);

                pg.Figures.Add(pf);
            }
        }

        /// <summary>
        /// Sets the colors based on combo box.
        /// </summary>
        private void SetColorsBasedOnComboBox()
        {
            var treeGrid = this.TargetObject as GridTreeControl;
            var viewModel = treeGrid.DataContext as ViewModel;

            if (treeGrid.InternalGrid != null)
            {
                switch (viewModel.ComboBoxIndex)
                {
                    case 0: //red
                        if (treeGrid.InternalGrid.ExpandGlyphType == GridTreeExpandGlyph.PlusMinusLines || treeGrid.InternalGrid.ExpandGlyphType == GridTreeExpandGlyph.PlusMinus)
                        {
                            treeGrid.InternalGrid.SetExpandBrushesAndPen(Brushes.Red, Brushes.Pink, new Pen(Brushes.Red, .14));
                        }
                        else
                        {
                            treeGrid.InternalGrid.SetExpandBrushesAndPen(Brushes.Red, Brushes.Pink, new Pen(Brushes.Red, .2));
                        }
                        break;
                    case 1: //green
                        if (treeGrid.InternalGrid.ExpandGlyphType == GridTreeExpandGlyph.PlusMinusLines || treeGrid.InternalGrid.ExpandGlyphType == GridTreeExpandGlyph.PlusMinus)
                        {
                            treeGrid.InternalGrid.SetExpandBrushesAndPen(Brushes.Green, Brushes.LightGreen, new Pen(Brushes.DarkGreen, .14));
                        }
                        else
                        {
                            treeGrid.InternalGrid.SetExpandBrushesAndPen(Brushes.Green, Brushes.LightGreen, new Pen(Brushes.DarkGreen, .2));
                        }
                        break;
                    case 2: //orange
                        if (treeGrid.InternalGrid.ExpandGlyphType == GridTreeExpandGlyph.PlusMinusLines || treeGrid.InternalGrid.ExpandGlyphType == GridTreeExpandGlyph.PlusMinus)
                        {
                            treeGrid.InternalGrid.SetExpandBrushesAndPen(Brushes.Orange, Brushes.OrangeRed, new Pen(Brushes.OrangeRed, .14));
                        }
                        else
                        {
                            treeGrid.InternalGrid.SetExpandBrushesAndPen(Brushes.Orange, Brushes.OrangeRed, new Pen(Brushes.OrangeRed, .2));
                        }
                        break;
                    case 3: //black
                        if (treeGrid.InternalGrid.ExpandGlyphType == GridTreeExpandGlyph.PlusMinusLines || treeGrid.InternalGrid.ExpandGlyphType == GridTreeExpandGlyph.PlusMinus)
                        {
                            treeGrid.InternalGrid.SetExpandBrushesAndPen(Brushes.Black, Brushes.LightGray, new Pen(Brushes.Black, .14));
                        }
                        else
                        {
                            treeGrid.InternalGrid.SetExpandBrushesAndPen(Brushes.Black, Brushes.LightGray, new Pen(Brushes.Black, .2));
                        }
                        break;
                    default:
                        if (treeGrid.InternalGrid.ExpandGlyphType == GridTreeExpandGlyph.PlusMinusLines || treeGrid.InternalGrid.ExpandGlyphType == GridTreeExpandGlyph.PlusMinus)
                        {
                            treeGrid.InternalGrid.SetExpandBrushesAndPen(Brushes.LightGray, Brushes.LightGray, new Pen(Brushes.Black, .14));
                        }
                        else
                        {
                            treeGrid.InternalGrid.SetExpandBrushesAndPen(Brushes.LightGray, Brushes.LightGray, new Pen(Brushes.Black, .2));
                        }
                        break;
                }
            }
        }

    }
}
