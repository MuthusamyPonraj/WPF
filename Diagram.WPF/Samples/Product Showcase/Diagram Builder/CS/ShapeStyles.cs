using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Media.Effects;
using System.Windows;
using Syncfusion.Windows.Diagram;
using System.Windows.Shapes;

namespace DiagramBuilder_2010
{
    public class ShapeStyles : DependencyObject, INotifyPropertyChanged
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the shape fill.
        /// </summary>
        /// <value>The shape fill.</value>
        public Brush Fill
        {
            get { return (Brush)GetValue(FillProperty); }
            set { SetValue(FillProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Fill.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FillProperty =
            DependencyProperty.Register("Fill", typeof(Brush), typeof(ShapeStyles), new UIPropertyMetadata(Brushes.Transparent));


        /// <summary>
        /// Gets or sets the shape stroke.
        /// </summary>
        /// <value>The shape stroke.</value>
        public Brush Stroke
        {
            get { return (Brush)GetValue(StrokeProperty); }
            set { SetValue(StrokeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Stroke.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StrokeProperty =
            DependencyProperty.Register("Stroke", typeof(Brush), typeof(ShapeStyles), new UIPropertyMetadata(null));

        public Effect Effect
        {
            get { return (Effect)GetValue(EffectProperty); }
            set { SetValue(EffectProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Effect.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EffectProperty =
            DependencyProperty.Register("Effect", typeof(Effect), typeof(ShapeStyles), new UIPropertyMetadata(null));



        public DoubleCollection StrokeDashArray
        {
            get { return (DoubleCollection)GetValue(StrokeDashArrayProperty); }
            set { SetValue(StrokeDashArrayProperty, value); }
        }

        // Using a DependencyProperty as the backing store for StrokeDashArray.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StrokeDashArrayProperty =
            DependencyProperty.Register("StrokeDashArray", typeof(DoubleCollection), typeof(ShapeStyles), new UIPropertyMetadata(null));



        public PenLineCap StrokeDashCap
        {
            get { return (PenLineCap)GetValue(StrokeDashCapProperty); }
            set { SetValue(StrokeDashCapProperty, value); }
        }

        // Using a DependencyProperty as the backing store for StrokeDashCap.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StrokeDashCapProperty =
            DependencyProperty.Register("StrokeDashCap", typeof(PenLineCap), typeof(ShapeStyles), new UIPropertyMetadata(null));

        public PenLineCap StrokeEndLineCap
        {
            get { return (PenLineCap)GetValue(StrokeEndLineCapProperty); }
            set { SetValue(StrokeEndLineCapProperty, value); }
        }

        // Using a DependencyProperty as the backing store for StrokeEndLineCap.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StrokeEndLineCapProperty =
            DependencyProperty.Register("StrokeEndLineCap", typeof(PenLineCap), typeof(ShapeStyles), new UIPropertyMetadata(null));


        public PenLineCap StrokeStartLineCap
        {
            get { return (PenLineCap)GetValue(StrokeStartLineCapProperty); }
            set { SetValue(StrokeStartLineCapProperty, value); }
        }

        // Using a DependencyProperty as the backing store for StrokeStartLineCap.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StrokeStartLineCapProperty =
            DependencyProperty.Register("StrokeStartLineCap", typeof(PenLineCap), typeof(ShapeStyles), new UIPropertyMetadata(null));



        public double StrokeDashOffset
        {
            get { return (double)GetValue(StrokeDashOffsetProperty); }
            set { SetValue(StrokeDashOffsetProperty, value); }
        }

        // Using a DependencyProperty as the backing store for StrokeDashOffset.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StrokeDashOffsetProperty =
            DependencyProperty.Register("StrokeDashOffset", typeof(double), typeof(ShapeStyles), new UIPropertyMetadata(null));



        public PenLineJoin StrokeLineJoin
        {
            get { return (PenLineJoin)GetValue(StrokeLineJoinProperty); }
            set { SetValue(StrokeLineJoinProperty, value); }
        }

        // Using a DependencyProperty as the backing store for StrokePenLineJoin.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StrokeLineJoinProperty =
            DependencyProperty.Register("StrokeLineJoin", typeof(PenLineJoin), typeof(ShapeStyles), new UIPropertyMetadata(null));



        public double StrokeMiterLimit
        {
            get { return (double)GetValue(StrokeMiterLimitProperty); }
            set { SetValue(StrokeMiterLimitProperty, value); }
        }

        // Using a DependencyProperty as the backing store for StrokeMiterLimit.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StrokeMiterLimitProperty =
            DependencyProperty.Register("StrokeMiterLimit", typeof(double), typeof(ShapeStyles), new UIPropertyMetadata(null));


        public double StrokeThickness
        {
            get { return (double)GetValue(StrokeThicknessProperty); }
            set { SetValue(StrokeThicknessProperty, value); }
        }

        // Using a DependencyProperty as the backing store for StrokeThickness.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StrokeThicknessProperty =
            DependencyProperty.Register("StrokeThickness", typeof(double), typeof(ShapeStyles), new UIPropertyMetadata(null));

        public bool IsPreview
        {
            get { return (bool)GetValue(IsPreviewProperty); }
            set { SetValue(IsPreviewProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsNull.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsPreviewProperty =
            DependencyProperty.Register("IsPreview", typeof(bool), typeof(ShapeStyles), new UIPropertyMetadata(false));

        #endregion

        #region Methods

        public ShapeStyles Clone()
        {
            return new ShapeStyles()
            {
                IsPreview = this.IsPreview,
                Fill = this.Fill,
                Effect = this.Effect,
                Stroke = this.Stroke,
                StrokeDashArray = this.StrokeDashArray,
                StrokeDashCap = this.StrokeDashCap,
                StrokeDashOffset = this.StrokeDashOffset,
                StrokeEndLineCap = this.StrokeEndLineCap,
                StrokeMiterLimit = this.StrokeMiterLimit,
                StrokeLineJoin = this.StrokeLineJoin,
                StrokeStartLineCap = this.StrokeStartLineCap,
                StrokeThickness = this.StrokeThickness
            };
        }


        #endregion

        #region PropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);
            if (this.PropertyChanged != null && m_FireEvents)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(e.Property.Name));
            }
        }
        #endregion

        private bool m_FireEvents = true;

        internal void SetProperties(Node n)
        {
            if (n != null)
            {
                m_FireEvents = false;
                Path p = n.Template.FindName("PART_Shape", n) as Path;
                if (p != null)
                {
                    Fill = p.GetValue(Path.FillProperty) as Brush;
                    Effect = p.GetValue(Path.EffectProperty) as Effect;
                    Stroke = p.GetValue(Path.StrokeProperty) as Brush;
                    StrokeDashArray = p.GetValue(Path.StrokeDashArrayProperty) as DoubleCollection;
                    StrokeDashCap = (PenLineCap)p.GetValue(Path.StrokeDashCapProperty);
                    StrokeDashOffset = (double)p.GetValue(Path.StrokeDashOffsetProperty);
                    StrokeEndLineCap = (PenLineCap)p.GetValue(Path.StrokeEndLineCapProperty);
                    StrokeMiterLimit = (double)p.GetValue(Path.StrokeMiterLimitProperty);
                    StrokeLineJoin = (PenLineJoin)p.GetValue(Path.StrokeLineJoinProperty);
                    StrokeStartLineCap = (PenLineCap)p.GetValue(Path.StrokeStartLineCapProperty);
                    StrokeThickness = (double)p.GetValue(Path.StrokeThicknessProperty);
                }               
                m_FireEvents = true;
            }
        }
    }
}
