using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Timers;
using System.Windows;
using System.Windows.Media.Imaging;
using Microsoft.Win32;
using Saxophon.Models;
using Saxophon.Resources;
using Saxophon.Services;
using Timer = System.Timers.Timer;

namespace Saxophon.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        private bool _isMessageVisible;
        private bool _isOverlayVisible;
        private bool _isCooledDown;
        private string _popupText;
        private Instrument _currentInstrument = Instrument.Dudelsack;
        private readonly string _saveDirectoryPath = $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}/SaxophON";
        private string _fileName = $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}/SaxophON/Merged.png";
        private ObservableCollection<NoteViewModel> _notes = new ObservableCollection<NoteViewModel>();
        private PngMergeService _pngMergeService = new PngMergeService();
        private NoteEnumerationService _noteEnumerationService = new NoteEnumerationService();

        public MainWindowViewModel()
        {
            ChangeToBagpipesCommand = new RelayCommand(ExecuteChangeToBagpipesCommand, CanExecuteChangeToBagpipesCommand);
            ChangeToSaxophoneCommand = new RelayCommand(ExecuteChangeToSaxophoneCommand, CanExecuteChangeToSaxophoneCommand);
            ChangeToFluteCommand = new RelayCommand(ExecuteChangeToFluteCommand, CanExecuteChangeToFluteCommand);
            TestCommand = new RelayCommand(ExecuteTestCommand, CanExecuteTestCommand);
            CreateDocumentCommand = new RelayCommand(ExecuteCreateDocumentCommand, CanExecuteCreateDocumentCommand);
            DeleteAllCommand = new RelayCommand(ExecuteDeleteAllCommand, CanExecuteDeleteAllCommand);
            DeleteNoteCommand = new RelayCommand(ExecuteDeleteNoteCommand, CanExecuteDeleteNoteCommand);
            AddNoteCommand = new RelayCommand(ExecuteAddNoteCommand, CanExecuteAddNoteCommand);
            
            if (!Directory.Exists(_saveDirectoryPath))
            {
                Directory.CreateDirectory(_saveDirectoryPath);
            }

            IsCooledDown = true;
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
        
        public bool IsCooledDown
        {
            get => _isCooledDown;
            set
            {
                _isCooledDown = value;
                OnPropertyChanged(nameof(IsCooledDown));
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

        public Instrument CurrentInstrument 
        { 
            get => _currentInstrument;
            set
            {
                _currentInstrument = value;
                OnPropertyChanged(nameof(CurrentInstrument));
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
            timer.Enabled = false;
            timer.Elapsed -= OnTimedEvent;
            if (CurrentInstrument == Instrument.Querflöte)
            {
                _pngMergeService.CreateFlutePng(Notes, _fileName);
            }
            else if(CurrentInstrument == Instrument.Saxophon)
            {
                _pngMergeService.CreateSaxophonePng(Notes, _fileName);
            }
            else if (CurrentInstrument == Instrument.Dudelsack)
            {
                _pngMergeService.CreateBagpipesPng(Notes, _fileName);
            }

            IsOverlayVisible = false;
            IsMessageVisible = false;
            PopupText = "Note sheet was created";
            IsMessageVisible = true;
            IsCooledDown = false;
            CreateDocumentCommand.RaiseCanExecuteChanged();
            timer.Interval = 10000;
            timer.Elapsed += OnTimedCooldownEvent;
            timer.Start();
        }
        
        private void OnTimedCooldownEvent(object sender, ElapsedEventArgs e)
        {
            var timer = (Timer) sender;
            timer.Enabled = false;
            timer.Dispose();
            IsCooledDown = true;
        }

        public RelayCommand ChangeToBagpipesCommand { get; set; }

        private bool CanExecuteChangeToBagpipesCommand(object parameter)
        {
            return true;
        }

        private void ExecuteChangeToBagpipesCommand(object parameter)
        {
            if(CurrentInstrument == Instrument.Dudelsack)
            {
                return;
            }

            if (!Notes.Any())
            {
                ChangeInstrument(Instrument.Dudelsack);
                return;
            }

            var messageBoxResult = MessageBox.Show("Wenn sie das Instrument wechseln gehen alle bisherigen Änderungen verloren.", "Warnung", MessageBoxButton.OKCancel);
            if (messageBoxResult == MessageBoxResult.OK)
            {
                ChangeInstrument(Instrument.Dudelsack);
            }
        }

        public RelayCommand ChangeToSaxophoneCommand { get; set; }

        private bool CanExecuteChangeToSaxophoneCommand(object parameter)
        {
            return true;
        }

        private void ExecuteChangeToSaxophoneCommand(object parameter)
        {
            if (CurrentInstrument == Instrument.Saxophon)
            {
                return;
            }

            if (!Notes.Any())
            {
                ChangeInstrument(Instrument.Saxophon);
                return;
            }

            var messageBoxResult = MessageBox.Show("Wenn sie das Instrument wechseln gehen alle bisherigen Änderungen verloren.", "Warnung", MessageBoxButton.OKCancel);
            if (messageBoxResult == MessageBoxResult.OK)
            {
                ChangeInstrument(Instrument.Saxophon);
            }
        }

        public RelayCommand ChangeToFluteCommand { get; set; }

        private bool CanExecuteChangeToFluteCommand(object parameter)
        {
            return true;
        }

        private void ExecuteChangeToFluteCommand(object parameter)
        {
            if (CurrentInstrument == Instrument.Querflöte)
            {
                return;
            }

            if (!Notes.Any())
            {
                ChangeInstrument(Instrument.Querflöte);
                return;
            }

            var messageBoxResult = MessageBox.Show("Wenn sie das Instrument wechseln gehen alle bisherigen Änderungen verloren.", "Warnung", MessageBoxButton.OKCancel);
            if (messageBoxResult == MessageBoxResult.OK)
            {
                ChangeInstrument(Instrument.Querflöte);
            }
        }

        public RelayCommand CreateDocumentCommand { get; set; }

        private bool CanExecuteCreateDocumentCommand(object parameter)
        {
            if(IsCooledDown && Notes.Any())
            {
                return true;
            }

            return false;
        }

        private void ExecuteCreateDocumentCommand(object parameter)
        {
            var dialog = new SaveFileDialog();
            dialog.FileName = "Noten";
            dialog.DefaultExt = ".png";
            dialog.Filter = "Png images (.png)|*.png";

            var result = dialog.ShowDialog();
            if (result == true)
            {
                _fileName = dialog.FileName;
            }

            IsOverlayVisible = true;
            var timer = new Timer();
            timer.Interval = 100;
            timer.Elapsed += OnTimedEvent;
            timer.Start();
        }
        
        public RelayCommand DeleteAllCommand { get; set; }

        private bool CanExecuteDeleteAllCommand(object parameter)
        {
            return Notes.Any();
        }

        private void ExecuteDeleteAllCommand(object parameter)
        {
            var messageBoxResult = MessageBox.Show("Wollen sie wirklich alle löschen?", "Warnung", MessageBoxButton.YesNo);

            if (messageBoxResult == MessageBoxResult.Yes)
            {
                Notes.Clear();
            }
        }

        public RelayCommand DeleteNoteCommand { get; set; }

        private bool CanExecuteDeleteNoteCommand(object parameter)
        {
            return Notes.Any();
        }

        private void ExecuteDeleteNoteCommand(object parameter)
        {
            Notes.RemoveAt(Notes.Count -1);
        }

        public RelayCommand AddNoteCommand { get; set; }

        private bool CanExecuteAddNoteCommand(object parameter)
        {
            return true;
        }

        private void ExecuteAddNoteCommand(object parameter)
        {
            var param = (string)parameter;
            var note = _noteEnumerationService.GetEnumNote(param);

            if (CurrentInstrument == Instrument.Dudelsack)
            {
                if (Notes.Count >= 40)
                {
                    MessageBox.Show("Es passt leider nicht mehr auf diese Seite.", "Warnung");
                    return;
                }
                var image = new BitmapImage(new Uri($"pack://application:,,,/Saxophon;component/Resources/Dudelsack/{param}.png"));
                Notes.Add(new BagpipesViewModel { Note = note, Image = image });
            }
            else if(CurrentInstrument == Instrument.Saxophon)
            {
                if(Notes.Count >= 40)
                {
                    MessageBox.Show("Es passt leider nicht mehr auf diese Seite.","Warnung");
                    return;
                }
                var image = new BitmapImage(new Uri($"pack://application:,,,/Saxophon;component/Resources/Saxophone/{param}.png"));
                Notes.Add(new SaxophoneNoteViewModel{Note = note, Image = image});
            }
            else if(CurrentInstrument == Instrument.Querflöte)
            {
                if (Notes.Count >= 45)
                {
                    MessageBox.Show("Es passt leider nicht mehr auf diese Seite.", "Warnung");
                    return;
                }
                var image = new BitmapImage(new Uri($"pack://application:,,,/Saxophon;component/Resources/Querfloete/{param}.png"));
                Notes.Add(new FluteNoteViewModel { Note = note, Image = image});
            }
        }

        public RelayCommand TestCommand { get; set; }

        private bool CanExecuteTestCommand(object parameter)
        {
            return true;
        }

        private void ExecuteTestCommand(object parameter)
        {
            IsMessageVisible = false;
            PopupText = "I am a test message, just ignore me!";
            IsMessageVisible = true;
        }

        private void ChangeInstrument(Instrument instrument)
        {
            Notes.Clear();
            CurrentInstrument = instrument;
        }
    }
}