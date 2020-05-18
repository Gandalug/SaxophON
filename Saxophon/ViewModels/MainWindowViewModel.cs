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
        private Instrument _currentInstrument = Instrument.Saxophon;
        private readonly string _saveDirectoryPath = $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}/SaxophON";
        private string _fileName = $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}/SaxophON/Merged.png";
        private ObservableCollection<NoteViewModel> _notes = new ObservableCollection<NoteViewModel>();
        private PngMergeService _pngMergeService = new PngMergeService();

        public MainWindowViewModel()
        {
            ChangeInstrumentCommand = new RelayCommand(ExecuteChangeInstrumentCommand, CanExecuteChangeInstrumentCommand);
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

        public Note GetEnumNote(string param)
        {
            if(param.Equals("c1"))
            {
                return Note.c1;
            }
            if(param.Equals("cis1"))
            {
                return Note.cis1;
            }
            if(param.Equals("d1"))
            {
                return Note.d1;
            }
            if(param.Equals("dis1"))
            {
                return Note.dis1;
            }
            if(param.Equals("e1"))
            {
                return Note.e1;
            }
            if (param.Equals("es1"))
            {
                return Note.es1;
            }
            if (param.Equals("f1"))
            {
                return Note.f1;
            }
            if(param.Equals("fis1"))
            {
                return Note.fis1;
            }
            if (param.Equals("ges1"))
            {
                return Note.ges1;
            }
            if (param.Equals("g1"))
            {
                return Note.g1;
            }
            if(param.Equals("gis1"))
            {
                return Note.gis1;
            }
            if (param.Equals("as1"))
            {
                return Note.as1;
            }
            if (param.Equals("a1"))
            {
                return Note.a1;
            }
            if (param.Equals("ais1"))
            {
                return Note.ais1;
            }
            if (param.Equals("b1"))
            {
                return Note.b1;
            }
            if(param.Equals("h1"))
            {
                return Note.h1;
            }
            if (param.Equals("c2"))
            {
                return Note.c2;
            }
            if (param.Equals("cis2"))
            {
                return Note.cis2;
            }
            if (param.Equals("d2"))
            {
                return Note.d2;
            }
            if (param.Equals("dis2"))
            {
                return Note.dis2;
            }
            if (param.Equals("e2"))
            {
                return Note.e2;
            }
            if (param.Equals("es2"))
            {
                return Note.es2;
            }
            if (param.Equals("f2"))
            {
                return Note.f2;
            }
            if (param.Equals("fis2"))
            {
                return Note.fis2;
            }
            if (param.Equals("ges2"))
            {
                return Note.ges2;
            }
            if (param.Equals("g2"))
            {
                return Note.g2;
            }
            if (param.Equals("as2"))
            {
                return Note.as2;
            }
            if (param.Equals("a2"))
            {
                return Note.a2;
            }
            if (param.Equals("ais2"))
            {
                return Note.ais2;
            }
            if (param.Equals("b2"))
            {
                return Note.b2;
            }
            if (param.Equals("h2"))
            {
                return Note.h2;
            }
            if (param.Equals("c3"))
            {
                return Note.c3;
            }
            else
            {
                return Note.leer;
            }
        }
        
        public RelayCommand ChangeInstrumentCommand { get; set; }

        private bool CanExecuteChangeInstrumentCommand(object parameter)
        {
            return true;
        }

        private void ExecuteChangeInstrumentCommand(object parameter)
        {
            if (!Notes.Any())
            {
                ChangeInstrument();
                return;
            }

            var messageBoxResult = MessageBox.Show("Wenn sie das Instrument wechseln gehen alle bisherigen Änderungen verloren.", "Warnung", MessageBoxButton.OKCancel);
            if (messageBoxResult == MessageBoxResult.OK)
            {
                ChangeInstrument();
            }
        }

        private void ChangeInstrument()
        {
            Notes.Clear();
            if (CurrentInstrument == Instrument.Querflöte)
            {
                CurrentInstrument = Instrument.Saxophon;
            }
            else if (CurrentInstrument == Instrument.Saxophon)
            {
                CurrentInstrument = Instrument.Querflöte;
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
            var param = (string) parameter;
            var note = GetEnumNote(param);

            if(CurrentInstrument == Instrument.Saxophon)
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
                Notes.Add(new FluteNoteViewModel { Note = note, Image = image });
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
    }
}