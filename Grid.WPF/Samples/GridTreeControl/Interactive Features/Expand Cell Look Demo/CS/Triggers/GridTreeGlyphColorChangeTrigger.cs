using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Interactivity;
using Syncfusion.Windows.Controls.Grid;
using System.Windows.Media;

namespace ExpandCellLook
{
    class GridTreeGlyphColorChangeTrigger : TargetedTriggerAction<GridTreeControl>
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
            DependencyProperty.Register("TargetObject", typeof(object), typeof(GridTreeGlyphColorChangeTrigger), new PropertyMetadata());

        /// <summary>
        /// Invokes the specified parameter.
        /// </summary>
        /// <param name="parameter">The parameter.</param>
        protected override void Invoke(object parameter)
        {
            SetColorsBasedOnComboBox();
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
