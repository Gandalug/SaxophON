using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
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
        private bool _isButtonPanelVisible;
        private string _popupText;
        private readonly string _saveDirectoryPath = $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}/SaxophON";
        private ObservableCollection<NoteViewModel> _notes = new ObservableCollection<NoteViewModel>();
        public MainWindowViewModel()
        {
            NewFileCommand = new RelayCommand(ExecuteNewFileCommand, CanExecuteNewFileCommand);
            LoadFileCommand = new RelayCommand(ExecuteLoadFileCommand, CanExecuteLoadFileCommand);
            SaveCommand = new RelayCommand(ExecuteSaveCommand, CanExecuteSaveCommand);
            CreateDocumentCommand = new RelayCommand(ExecuteCreateDocumentCommand, CanExecuteCreateDocumentCommand);
            DeleteNoteCommand = new RelayCommand(ExecuteDeleteNoteCommand, CanExecuteDeleteNoteCommand);
            
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

        public bool IsButtonPanelVisible
        {
            get => _isButtonPanelVisible;
            set
            {
                _isButtonPanelVisible = value;
                OnPropertyChanged(nameof(IsButtonPanelVisible));
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
                            frame = BitmapDecoder.Create(new Uri("pack://application:,,,/Saxophon;component/Resources/c1.png"),
                                BitmapCreateOptions.None, BitmapCacheOption.OnLoad).Frames.First();
                        }
                        else if (Notes[count].Note == Note.d1)
                        {
                            frame = BitmapDecoder.Create(new Uri("pack://application:,,,/Saxophon;component/Resources/c1.png"),
                                BitmapCreateOptions.None, BitmapCacheOption.OnLoad).Frames.First();
                        }
                        else if (Notes[count].Note == Note.e1)
                        {
                            frame = BitmapDecoder.Create(new Uri("pack://application:,,,/Saxophon;component/Resources/c1.png"),
                                BitmapCreateOptions.None, BitmapCacheOption.OnLoad).Frames.First();
                        }
                        else if (Notes[count].Note == Note.f1)
                        {
                            frame = BitmapDecoder.Create(new Uri("pack://application:,,,/Saxophon;component/Resources/c1.png"),
                                BitmapCreateOptions.None, BitmapCacheOption.OnLoad).Frames.First();
                        }
                        else
                        {
                            frame = BitmapDecoder.Create(new Uri("pack://application:,,,/Saxophon;component/Resources/c1.png"),
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

        public RelayCommand NewFileCommand { get; set; }

        private bool CanExecuteNewFileCommand(object parameter)
        {
            return true;
        }

        private void ExecuteNewFileCommand(object parameter)
        {
            if (IsButtonPanelVisible)
            {
                IsButtonPanelVisible = false;
            }
            else
            {
                IsButtonPanelVisible = true;
            }
        }

        public RelayCommand LoadFileCommand { get; set; }

        private bool CanExecuteLoadFileCommand(object parameter)
        {
            return true;
        }

        private void ExecuteLoadFileCommand(object parameter)
        {
            var image = new BitmapImage(new Uri("pack://application:,,,/Saxophon;component/Resources/Folder_16x.png"));
            Notes.Add(new NoteViewModel{ Note = Note.a1, Image = image});
        }

        public RelayCommand CreateDocumentCommand { get; set; }

        private bool CanExecuteCreateDocumentCommand(object parameter)
        {
            return IsCooledDown;
        }

        private void ExecuteCreateDocumentCommand(object parameter)
        {
            IsOverlayVisible = true;
            var timer = new Timer();
            timer.Interval = 100;
            timer.Elapsed += OnTimedEvent;
            timer.Start();
        }

        public RelayCommand DeleteNoteCommand { get; set; }

        private bool CanExecuteDeleteNoteCommand(object parameter)
        {
            return true;
        }

        private void ExecuteDeleteNoteCommand(object parameter)
        {
            var image = new BitmapImage(new Uri("pack://application:,,,/Saxophon;component/Resources/c1.png"));
            Notes.Add(new NoteViewModel{ Note = Note.d1, Image = image});
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