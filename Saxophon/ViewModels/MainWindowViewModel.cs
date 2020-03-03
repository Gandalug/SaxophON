using System;
using System.Collections.ObjectModel;
using System.Windows.Media.Imaging;
using Saxophon.Resources;

namespace Saxophon.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        private bool _isMessageVisible;
        private string _popupText;
        private ObservableCollection<NoteViewModel> _notes = new ObservableCollection<NoteViewModel>();
        public MainWindowViewModel()
        {
            AddNoteCommand = new RelayCommand(ExecuteAddNoteCommand, CanExecuteAddNoteCommand);
            DeleteNoteCommand = new RelayCommand(ExecuteDeleteNoteCommand, CanExecuteDeleteNoteCommand);
            SaveCommand = new RelayCommand(ExecuteSaveCommand, CanExecuteSaveCommand);
        }
        
        public bool IsMessageVisible
        {
            get => _isMessageVisible;
            set
            {
                _isMessageVisible = value;
                OnPropertyChanged(nameof(IsMessageVisible));
            }
        }
        
        public string PopupText
        {
            get => _popupText;
            set
            {
                _popupText = value;
                OnPropertyChanged(nameof(PopupText));
            }
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
            var image = new BitmapImage(new Uri("pack://application:,,,/Saxophon;component/Resources/Add_16x.png"));
            Notes.Add(new NoteViewModel{ Name = "a", Image = image});
        }

        public RelayCommand DeleteNoteCommand { get; set; }

        private bool CanExecuteDeleteNoteCommand(object parameter)
        {
            return true;
        }

        private void ExecuteDeleteNoteCommand(object parameter)
        {
            var image = new BitmapImage(new Uri("pack://application:,,,/Saxophon;component/Resources/Cancel_16x.png"));
            Notes.Add(new NoteViewModel{ Name = "d", Image = image});
        }
        public RelayCommand SaveCommand { get; set; }

        private bool CanExecuteSaveCommand(object parameter)
        {
            return true;
        }

        private void ExecuteSaveCommand(object parameter)
        {
            IsMessageVisible = false;
            PopupText = "Note sheet was created";
            IsMessageVisible = true;
        }
    }
}