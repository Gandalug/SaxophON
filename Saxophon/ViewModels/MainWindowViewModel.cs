using System;
using System.Collections.ObjectModel;
using System.Windows.Media.Imaging;
using Saxophon.Resources;

namespace Saxophon.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        private ObservableCollection<NoteViewModel> _notes = new ObservableCollection<NoteViewModel>();
        public MainWindowViewModel()
        {
            AddNoteCommand = new RelayCommand(ExecuteAddNoteCommand, CanExecuteAddNoteCommand);
        }

        public ObservableCollection<NoteViewModel> Notes
        {
            get => _notes;
            set
            {
                _notes = value;
                OnPropertyChanged(nameof(Notes));
            }
        }

        public RelayCommand AddNoteCommand { get; set; }

        private bool CanExecuteAddNoteCommand(object parameter)
        {
            return true;
        }

        private void ExecuteAddNoteCommand(object parameter)
        {
            var image = new BitmapImage(new Uri("pack://application:,,,/Saxophon;component/Resources/horns.png"));
            Notes.Add(new NoteViewModel{ Name = "c", Image = image});
        }
    }
}