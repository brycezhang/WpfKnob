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

namespace WpfKnob
{
    /// <summary>
    /// Interaction logic for KnobControl.xaml
    /// </summary>
    public partial class KnobControl : UserControl
    {
        public KnobControl()
        {
            InitializeComponent();
        }

        #region 控件值

        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(double), typeof(KnobControl), new PropertyMetadata(ValueChanged));

        private static void ValueChanged(DependencyObject s, DependencyPropertyChangedEventArgs e)
        {
            var control = s as KnobControl;
            if (control != null)
            {
                control.ArcSlider.EndAngle = (double)e.NewValue * 3.6;
                control.TxtPercent.Text = ((double)e.NewValue).ToString("f0");
            }
        }

        public double Value
        {
            get { return (double)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        #endregion

        #region Arc控件的宽度

        public static readonly DependencyProperty ArcThicknessProperty =
            DependencyProperty.Register("ArcThickness", typeof(double), typeof(KnobControl), new PropertyMetadata(ArcThicknessChanged));

        public double ArcThickness
        {
            get { return (double)GetValue(ArcThicknessProperty); }
            set { SetValue(ArcThicknessProperty, value); }
        }

        private static void ArcThicknessChanged(DependencyObject s, DependencyPropertyChangedEventArgs e)
        {
            var control = s as KnobControl;
            if (control != null)
            {
                control.ArcBack.ArcThickness = (double) e.NewValue;
                control.ArcSlider.ArcThickness = (double)e.NewValue;
            }
        }

        #endregion

        #region 背景色、前景色
        
        public static readonly DependencyProperty ArcBackgroundProperty =
            DependencyProperty.Register("ArcBackground", typeof(Brush), typeof(KnobControl), new PropertyMetadata(ArcBackgroundChanged));

        public Brush ArcBackground
        {
            get { return (Brush) GetValue(ArcBackgroundProperty); }
            set { SetValue(ArcBackgroundProperty, value); }
        }

        private static void ArcBackgroundChanged(DependencyObject s, DependencyPropertyChangedEventArgs e)
        {
            var control = s as KnobControl;
            if (control != null)
            {
                control.ArcBack.Fill = e.NewValue as Brush;
            }
        }

        public static readonly DependencyProperty ArcForegroundProperty =
            DependencyProperty.Register("ArcForeground", typeof(Brush), typeof(KnobControl), new PropertyMetadata(ArcForegroundChanged));

        public Brush ArcForeground
        {
            get { return (Brush) GetValue(ArcForegroundProperty); }
            set { SetValue(ArcForegroundProperty, value); }
        }

        private static void ArcForegroundChanged(DependencyObject s, DependencyPropertyChangedEventArgs e)
        {
            var control = s as KnobControl;
            if (control != null)
            {
                control.ArcSlider.Fill = e.NewValue as Brush;
            }
        }

        #endregion

        #region 文本前景色、字体大小

        public static readonly DependencyProperty TextForegroundProperty =
            DependencyProperty.Register("TextForeground", typeof(Brush), typeof(KnobControl), new PropertyMetadata(TextForegroundChanged));

        public Brush TextForeground
        {
            get { return (Brush) GetValue(TextForegroundProperty); }
            set { SetValue(TextForegroundProperty, value); }
        }

        private static void TextForegroundChanged(DependencyObject s, DependencyPropertyChangedEventArgs e)
        {
            var control = s as KnobControl;
            if (control != null)
            {
                control.TxtPercent.Foreground = e.NewValue as Brush;
            }
        }

        public static readonly DependencyProperty TextFontSizeProperty =
            DependencyProperty.Register("TextFontSize", typeof(double), typeof(KnobControl), new PropertyMetadata(TextFontSizeChanged));

        public double TextFontSize
        {
            get { return (double)GetValue(TextFontSizeProperty); }
            set { SetValue(TextFontSizeProperty, value); }
        }

        private static void TextFontSizeChanged(DependencyObject s, DependencyPropertyChangedEventArgs e)
        {
            var control = s as KnobControl;
            if (control != null)
            {
                control.TxtPercent.FontSize = (double) e.NewValue;
            }
        }

        #endregion

        #region 控件大小

        public static readonly DependencyProperty ArcSizeProperty =
            DependencyProperty.Register("ArcSize", typeof(double), typeof(KnobControl), new PropertyMetadata(ArcSizeChanged));

        public double ArcSize
        {
            get { return (double) GetValue(ArcSizeProperty); }
            set { SetValue(ArcSizeProperty, value); }
        }

        private static void ArcSizeChanged(DependencyObject s, DependencyPropertyChangedEventArgs e)
        {
            var control = s as KnobControl;
            if (control != null)
            {
                control.Width = control.Height
                    = control.LayoutRoot.Width
                    = control.LayoutRoot.Height

                    = control.ArcSlider.Width 
                    = control.ArcSlider.Height

                    = control.ArcBack.Width 
                    = control.ArcBack.Height

                    = (double)e.NewValue;
            }
        }

        #endregion
    }
}