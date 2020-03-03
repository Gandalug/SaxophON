using System;
using System.Collections.ObjectModel;
using System.Timers;
using System.Windows.Media.Imaging;
using Saxophon.Resources;
using Timer = System.Timers.Timer;

namespace Saxophon.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        private bool _isMessageVisible;
        private bool _isOverlayVisible;
        private string _popupText;
        private ObservableCollection<NoteViewModel> _notes = new ObservableCollection<NoteViewModel>();
        public MainWindowViewModel()
        {
            NewFileCommand = new RelayCommand(ExecuteNewFileCommand, CanExecuteNewFileCommand);
            LoadFileCommand = new RelayCommand(ExecuteLoadFileCommand, CanExecuteLoadFileCommand);
            SaveCommand = new RelayCommand(ExecuteSaveCommand, CanExecuteSaveCommand);
            CreateDocumentCommand = new RelayCommand(ExecuteCreateDocumentCommand, CanExecuteCreateDocumentCommand);
            DeleteNoteCommand = new RelayCommand(ExecuteDeleteNoteCommand, CanExecuteDeleteNoteCommand);
            
            IsOverlayVisible = true;
            var timer = new Timer();
            timer.Interval = 2000;
            timer.Elapsed += OnTimedEvent;
            timer.Enabled = true;
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
        
        public bool IsOverlayVisible
        {
            get => _isOverlayVisible;
            set
            {
                _isOverlayVisible = value;
                OnPropertyChanged(nameof(IsOverlayVisible));
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

        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            var timer = (Timer) sender;
            IsOverlayVisible = false;
            timer.Enabled = false;
            timer.Dispose();
        }

        public RelayCommand NewFileCommand { get; set; }

        private bool CanExecuteNewFileCommand(object parameter)
        {
            return true;
        }

        private void ExecuteNewFileCommand(object parameter)
        {
            var image = new BitmapImage(new Uri("pack://application:,,,/Saxophon;component/Resources/Add_16x.png"));
            Notes.Add(new NoteViewModel{ Name = "a", Image = image});
        }

        public RelayCommand LoadFileCommand { get; set; }

        private bool CanExecuteLoadFileCommand(object parameter)
        {
            return true;
        }

        private void ExecuteLoadFileCommand(object parameter)
        {
            var image = new BitmapImage(new Uri("pack://application:,,,/Saxophon;component/Resources/Folder_16x.png"));
            Notes.Add(new NoteViewModel{ Name = "a", Image = image});
        }

        public RelayCommand CreateDocumentCommand { get; set; }

        private bool CanExecuteCreateDocumentCommand(object parameter)
        {
            return true;
        }

        private void ExecuteCreateDocumentCommand(object parameter)
        {
            var image = new BitmapImage(new Uri("pack://application:,,,/Saxophon;component/Resources/Document_16x.png"));
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