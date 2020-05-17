using Saxophon.Models;
using System.Windows.Media.Imaging;

namespace Saxophon.ViewModels
{
    public class NoteViewModel : BaseViewModel
    {
        public Note Note { get; set; }
        public BitmapImage Image { get; set; }
    }
}
