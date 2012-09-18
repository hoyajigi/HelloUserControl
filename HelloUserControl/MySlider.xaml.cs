using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// 사용자 정의 컨트롤 항목 템플릿에 대한 설명은 http://go.microsoft.com/fwlink/?LinkId=234236에 나와 있습니다.

namespace HelloUserControl
{
    public sealed partial class MySlider : UserControl
    {


        public int SliderValue
        {
            get { return (int)GetValue(SliderValueProperty); }
            set { SetValue(SliderValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SliderValue.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SliderValueProperty =
            DependencyProperty.Register("SliderValue", typeof(int), typeof(MySlider), new PropertyMetadata(0,onSliderValueChanged));

        private static void onSliderValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            MySlider ms = d as MySlider;
            if (ms != null)
            {
                ms.setSliderValue((int)e.NewValue);
            }
        }

        private void setSliderValue(int p)
        {
            slider.Value = p;
        }

        public event EventHandler<SliderChangedEventArgs> SliderChanged;

        private void OnSliderChanged(SliderChangedEventArgs args)
        {
            if (SliderChanged == null)
                return;
            SliderChanged(this, args);
        }

        public class SliderChangedEventArgs : EventArgs
        {
            public int Value { get; set; }
            public SliderChangedEventArgs(int V)
            {
                this.Value = V;
            }
        }

        public MySlider()
        {
            this.InitializeComponent();
        }

        private void slider_ValueChanged_1(object sender, RangeBaseValueChangedEventArgs e)
        {
            OnSliderChanged(new SliderChangedEventArgs((int)e.NewValue));
        }
    }
}
