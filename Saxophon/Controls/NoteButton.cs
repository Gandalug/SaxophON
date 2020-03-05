using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Saxophon.Controls
{
    public class NoteButton : Button
    {
        static NoteButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(NoteButton), new FrameworkPropertyMetadata(typeof(NoteButton)));
        }
        
        public static readonly DependencyProperty ImageSourceProperty = DependencyProperty.Register(
            nameof(ImageSource), typeof(ImageSource), typeof(NoteButton), new PropertyMetadata(default(ImageSource)));

        public ImageSource ImageSource
        {
            get => (ImageSource) GetValue(ImageSourceProperty);
            set => SetValue(ImageSourceProperty, value);
        }
    }
}