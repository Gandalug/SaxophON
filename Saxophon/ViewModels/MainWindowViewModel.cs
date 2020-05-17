using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Timers;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Saxophon.Models;
using Saxophon.Resources;
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
        private ObservableCollection<NoteViewModel> _notes = new ObservableCollection<NoteViewModel>();
        public MainWindowViewModel()
        {
            ChangeInstrumentCommand = new RelayCommand(ExecuteChangeInstrumentCommand, CanExecuteChangeInstrumentCommand);
            PopMessageCommand = new RelayCommand(ExecutePopMessageCommand, CanExecutePopMessageCommand);
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
            timer.Dispose();
            CreatePng();
        }
        
        private void OnTimedCooldownEvent(object sender, ElapsedEventArgs e)
        {
            var timer = (Timer) sender;
            timer.Enabled = false;
            timer.Dispose();
            IsCooledDown = true;
        }

        public void CreatePng()
        {
            BitmapFrame frame = BitmapDecoder.Create(new Uri("pack://application:,,,/Saxophon;component/Resources/SaxophonLeer.png"),
                BitmapCreateOptions.None, BitmapCacheOption.OnLoad).Frames.First();

            int imageWidth = frame.PixelWidth;
            int imageHeight = frame.PixelHeight;

            int count = 0;

            int countRows = 4;
            int countColumns = 10;

            DrawingVisual drawingVisual = new DrawingVisual();
            using (DrawingContext drawingContext = drawingVisual.RenderOpen())
            {
                for (int i = 0; i < countRows; i++)
                {
                    for (int j = 0; j < countColumns; j++)
                    {
                        if (Notes.Count <= count)
                        {
                            frame = BitmapDecoder.Create(new Uri("pack://application:,,,/Saxophon;component/Resources/SaxophonLeer.png"),
                                BitmapCreateOptions.None, BitmapCacheOption.OnLoad).Frames.First();
                        }
                        else if (Notes[count].Note == Note.c1)
                        {
                            frame = BitmapDecoder.Create(new Uri("pack://application:,,,/Saxophon;component/Resources/Saxophone/c1.png"),
                                BitmapCreateOptions.None, BitmapCacheOption.OnLoad).Frames.First();
                        }
                        else if (Notes[count].Note == Note.cis1)
                        {
                            frame = BitmapDecoder.Create(new Uri("pack://application:,,,/Saxophon;component/Resources/Saxophone/cis1.png"),
                                BitmapCreateOptions.None, BitmapCacheOption.OnLoad).Frames.First();
                        }
                        else if (Notes[count].Note == Note.d1)
                        {
                            frame = BitmapDecoder.Create(new Uri("pack://application:,,,/Saxophon;component/Resources/Saxophone/d1.png"),
                                BitmapCreateOptions.None, BitmapCacheOption.OnLoad).Frames.First();
                        }
                        else if (Notes[count].Note == Note.dis1)
                        {
                            frame = BitmapDecoder.Create(new Uri("pack://application:,,,/Saxophon;component/Resources/Saxophone/dis1.png"),
                                BitmapCreateOptions.None, BitmapCacheOption.OnLoad).Frames.First();
                        }
                        else if (Notes[count].Note == Note.e1)
                        {
                            frame = BitmapDecoder.Create(new Uri("pack://application:,,,/Saxophon;component/Resources/Saxophone/e1.png"),
                                BitmapCreateOptions.None, BitmapCacheOption.OnLoad).Frames.First();
                        }
                        else if (Notes[count].Note == Note.f1)
                        {
                            frame = BitmapDecoder.Create(new Uri("pack://application:,,,/Saxophon;component/Resources/Saxophone/f1.png"),
                                BitmapCreateOptions.None, BitmapCacheOption.OnLoad).Frames.First();
                        }
                        else if (Notes[count].Note == Note.fis1)
                        {
                            frame = BitmapDecoder.Create(new Uri("pack://application:,,,/Saxophon;component/Resources/Saxophone/fis1.png"),
                                BitmapCreateOptions.None, BitmapCacheOption.OnLoad).Frames.First();
                        }
                        else if (Notes[count].Note == Note.g1)
                        {
                            frame = BitmapDecoder.Create(new Uri("pack://application:,,,/Saxophon;component/Resources/Saxophone/g1.png"),
                                BitmapCreateOptions.None, BitmapCacheOption.OnLoad).Frames.First();
                        }
                        else if (Notes[count].Note == Note.gis1)
                        {
                            frame = BitmapDecoder.Create(new Uri("pack://application:,,,/Saxophon;component/Resources/Saxophone/gis1.png"),
                                BitmapCreateOptions.None, BitmapCacheOption.OnLoad).Frames.First();
                        }
                        else if (Notes[count].Note == Note.a1)
                        {
                            frame = BitmapDecoder.Create(new Uri("pack://application:,,,/Saxophon;component/Resources/Saxophone/a1.png"),
                                BitmapCreateOptions.None, BitmapCacheOption.OnLoad).Frames.First();
                        }
                        else if (Notes[count].Note == Note.b1)
                        {
                            frame = BitmapDecoder.Create(new Uri("pack://application:,,,/Saxophon;component/Resources/Saxophone/b1.png"),
                                BitmapCreateOptions.None, BitmapCacheOption.OnLoad).Frames.First();
                        }
                        else if (Notes[count].Note == Note.h1)
                        {
                            frame = BitmapDecoder.Create(new Uri("pack://application:,,,/Saxophon;component/Resources/Saxophone/h1.png"),
                                BitmapCreateOptions.None, BitmapCacheOption.OnLoad).Frames.First();
                        }
                        else
                        {
                            frame = BitmapDecoder.Create(new Uri("pack://application:,,,/Saxophon;component/Resources/SacophonLeer.png"),
                                BitmapCreateOptions.None, BitmapCacheOption.OnLoad).Frames.First();
                        }

                        drawingContext.DrawImage(frame, new Rect(imageWidth * j, imageHeight * i, imageWidth, imageHeight));
                        count++;
                    }
                }
            }

            RenderTargetBitmap targetBitmap = new RenderTargetBitmap(imageWidth * countColumns, imageHeight * countRows, 96, 96, PixelFormats.Pbgra32);
            targetBitmap.Render(drawingVisual);

            PngBitmapEncoder bitmapEncoder = new PngBitmapEncoder();
            bitmapEncoder.Frames.Add(BitmapFrame.Create(targetBitmap));

            using (Stream stream = File.Create($"{_saveDirectoryPath}/Merged.png"))
            {
                bitmapEncoder.Save(stream);
            }

            IsOverlayVisible = false;
            IsMessageVisible = false;
            PopupText = "Note sheet was created";
            IsMessageVisible = true;
            IsCooledDown = false;
            CreateDocumentCommand.RaiseCanExecuteChanged();
            var timer = new Timer();
            timer.Interval = 10000;
            timer.Elapsed += OnTimedCooldownEvent;
            timer.Start();
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
            if(param.Equals("f1"))
            {
                return Note.f1;
            }
            if(param.Equals("fis1"))
            {
                return Note.fis1;
            }
            if(param.Equals("g1"))
            {
                return Note.g1;
            }
            if(param.Equals("gis1"))
            {
                return Note.gis1;
            }
            if(param.Equals("a1"))
            {
                return Note.a1;
            }
            if(param.Equals("b1"))
            {
                return Note.b1;
            }
            if(param.Equals("h1"))
            {
                return Note.h1;
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
            var messageBoxResult = MessageBox.Show("Wenn sie das Instrument wechseln gehen alle bisherigen Änderungen verloren.", "Warnung", MessageBoxButton.OKCancel);

            if (messageBoxResult == MessageBoxResult.OK)
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
            IsOverlayVisible = true;
            var timer = new Timer();
            timer.Interval = 100;
            timer.Elapsed += OnTimedEvent;
            timer.Start();
        }
        public RelayCommand PopMessageCommand { get; set; }

        private bool CanExecutePopMessageCommand(object parameter)
        {
            return true;
        }

        private void ExecutePopMessageCommand(object parameter)
        {
            IsMessageVisible = false;
            PopupText = "Note sheet was created";
            IsMessageVisible = true;
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
                if (Notes.Count >= 440)
                {
                    MessageBox.Show("Es passt leider nicht mehr auf diese Seite.", "Warnung");
                    return;
                }
                var image = new BitmapImage(new Uri($"pack://application:,,,/Saxophon;component/Resources/Querfloete/{param}.png"));
                Notes.Add(new FluteNoteViewModel { Note = note, Image = image });
            }
        }
    }
}