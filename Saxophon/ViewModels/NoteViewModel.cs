using System.Windows.Media.Imaging;

namespace Saxophon.ViewModels
{
    public class NoteViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public BitmapImage Image { get; set; }
    }
}