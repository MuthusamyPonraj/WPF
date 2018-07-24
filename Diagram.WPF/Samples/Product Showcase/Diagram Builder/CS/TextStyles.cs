using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.ComponentModel;
using System.Windows.Media;
using Syncfusion.Windows.Diagram;

namespace DiagramBuilder_2010
{
    public class TextStyles : DependencyObject, INotifyPropertyChanged
    {
        #region Dependency Propertry

        public FontFamily LabelFontFamily
        {
            get { return (FontFamily)GetValue(LabelFontFamilyProperty); }
            set { SetValue(LabelFontFamilyProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FontName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LabelFontFamilyProperty =
            DependencyProperty.Register("LabelFontFamily", typeof(FontFamily), typeof(TextStyles), new PropertyMetadata(null));

        public double LabelFontSize
        {
            get { return (double)GetValue(LabelFontSizeProperty); }
            set { SetValue(LabelFontSizeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FontSize.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LabelFontSizeProperty =
            DependencyProperty.Register("LabelFontSize", typeof(double), typeof(TextStyles), new PropertyMetadata(null));

        public TextAlignment LabelTextAlignment
        {
            get { return (TextAlignment)GetValue(LabelTextAlignmentProperty); }
            set { SetValue(LabelTextAlignmentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LabelTextAlignment.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LabelTextAlignmentProperty =
            DependencyProperty.Register("LabelTextAlignment", typeof(TextAlignment), typeof(TextStyles), new PropertyMetadata(null));

        public Brush LabelForeground
        {
            get { return (Brush)GetValue(LabelForegroundProperty); }
            set { SetValue(LabelForegroundProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FontForeground.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LabelForegroundProperty =
            DependencyProperty.Register("LabelForeground", typeof(Brush), typeof(TextStyles), new PropertyMetadata(Brushes.Black));

        public FontWeight LabelFontWeight
        {
            get { return (FontWeight)GetValue(LabelFontWeightProperty); }
            set { SetValue(LabelFontWeightProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LabelFontWeight.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LabelFontWeightProperty =
            DependencyProperty.Register("LabelFontWeight", typeof(FontWeight), typeof(TextStyles), new PropertyMetadata(FontWeights.Black));


        public FontStyle LabelFontStyle
        {
            get { return (FontStyle)GetValue(LabelFontStyleProperty); }
            set { SetValue(LabelFontStyleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LabelFontStyle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LabelFontStyleProperty =
            DependencyProperty.Register("LabelFontStyle", typeof(FontStyle), typeof(TextStyles), new PropertyMetadata(FontStyles.Normal));

        public TextDecorationLocation Underline
        {
            get { return (TextDecorationLocation)GetValue(UnderlineProperty); }
            set { SetValue(UnderlineProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Underline.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty UnderlineProperty =
            DependencyProperty.Register("Underline", typeof(TextDecorationLocation), typeof(TextStyles), new PropertyMetadata(null));

        public HorizontalAlignment LabelHorizontalAlignment
        {
            get { return (HorizontalAlignment)GetValue(LabelHorizontalAlignmentProperty); }
            set { SetValue(LabelHorizontalAlignmentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LabelHorizontalAlignment.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LabelHorizontalAlignmentProperty =
            DependencyProperty.Register("LabelHorizontalAlignment", typeof(HorizontalAlignment), typeof(TextStyles), new PropertyMetadata(HorizontalAlignment.Left));

        public VerticalAlignment LabelVerticalAlignment
        {
            get { return (VerticalAlignment)GetValue(LabelVerticalAlignmentProperty); }
            set { SetValue(LabelVerticalAlignmentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LabelVerticalAlignment.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LabelVerticalAlignmentProperty =
            DependencyProperty.Register("LabelVerticalAlignment", typeof(VerticalAlignment), typeof(TextStyles), new PropertyMetadata(VerticalAlignment.Top));
        #endregion

        public TextDecorationCollection LabelTextDecorations
        {
            get { return (TextDecorationCollection)GetValue(LabelTextDecorationsProperty); }
            set { SetValue(LabelTextDecorationsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LabelTextDecorations.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LabelTextDecorationsProperty =
            DependencyProperty.Register("LabelTextDecorations", typeof(TextDecorationCollection), typeof(TextStyles));

        #region Methods

        public TextStyles Clone()
        {
            return new TextStyles()
            {
                LabelFontFamily = this.LabelFontFamily,
                LabelFontSize = this.LabelFontSize,
                LabelFontStyle = this.LabelFontStyle,
                LabelFontWeight = this.LabelFontWeight,
                LabelForeground = this.LabelForeground,
                LabelHorizontalAlignment = this.LabelHorizontalAlignment,
                LabelTextAlignment = this.LabelTextAlignment,
                LabelVerticalAlignment = this.LabelVerticalAlignment,
                LabelTextDecorations = this.LabelTextDecorations
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

        private bool m_FireEvents = true;

        internal void SetProperties(Node n)
        {
            m_FireEvents = false;
            LabelFontFamily = n.LabelFontFamily;
            LabelFontSize = n.LabelFontSize;
            LabelFontStyle = n.LabelFontStyle;
            LabelFontWeight = n.LabelFontWeight;
            LabelForeground = n.LabelForeground;
            LabelHorizontalAlignment = n.LabelHorizontalAlignment;
            LabelTextAlignment = n.LabelTextAlignment;
            LabelVerticalAlignment = n.LabelVerticalAlignment;
            LabelTextDecorations = n.LabelTextDecorations;
            m_FireEvents = true;
        }

        #endregion
    }
}
