using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WpfAppSlider
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            UpdateBackgroundColor();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            UpdateBackgroundColor();
        }

        private void UpdateBackgroundColor()
        {
            // 컨트롤이 null인지 확인
            if (sliderRed == null || sliderGreen == null || sliderBlue == null ||
                labelRedValue == null || labelGreenValue == null || labelBlueValue == null ||
                radioNormal == null || radioInvert == null || radioGrayscale == null)
            {
                return;
            }

            byte red = (byte)sliderRed.Value;
            byte green = (byte)sliderGreen.Value;
            byte blue = (byte)sliderBlue.Value;
            Color color = Color.FromRgb(red, green, blue);

            if (radioInvert.IsChecked == true)
            {
                color = Color.FromRgb((byte)(255 - red), (byte)(255 - green), (byte)(255 - blue));
            }
            else if (radioGrayscale.IsChecked == true)
            {
                byte gray = (byte)((red + green + blue) / 3);
                color = Color.FromRgb(gray, gray, gray);
            }

            this.Background = new SolidColorBrush(color);
            labelRedValue.Content = red.ToString();
            labelGreenValue.Content = green.ToString();
            labelBlueValue.Content = blue.ToString();
        }
    }
}
