using System.Windows.Media.Imaging;
using Saxophon.Models;

namespace Saxophon.ViewModels
{
    public class NoteViewModel : BaseViewModel
    {
        public Note Note { get; set; }
        public BitmapImage Image { get; set; }
    }
}