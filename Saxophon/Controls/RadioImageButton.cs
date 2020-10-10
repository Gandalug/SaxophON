using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Saxophon.Controls
{
    public class RadioImageButton : RadioButton
    {
        static RadioImageButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(RadioImageButton), new FrameworkPropertyMetadata(typeof(ImageButton)));
        }

        public static readonly DependencyProperty ImageSourceProperty = DependencyProperty.Register(
            nameof(ImageSource), typeof(ImageSource), typeof(RadioImageButton), new PropertyMetadata(default(ImageSource)));

        public ImageSource ImageSource
        {
            get => (ImageSource) GetValue(ImageSourceProperty);
            set => SetValue(ImageSourceProperty, value);
        }
    }
}